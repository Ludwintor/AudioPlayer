using System.Runtime.InteropServices;
using AudioPlayer.Exceptions;
using Collections;
using NAudio.Wave;

namespace AudioPlayer.Audio
{
    public sealed class Playlist : Collections.LinkedList<Composition>, IDisposable
    {
        /// <summary>
        /// Raised when current track finished playing
        /// </summary>
        public event Action? TrackEnded;

        private readonly WaveOutEvent _outputDevice;
        private AudioFileReader? _audioFile;
        private LinkedListItem<Composition>? _current;
        private float _volume;
        private bool _isMuted;
        private bool _forcedStop;

        /// <summary>
        /// Constructs new playlist instance
        /// </summary>
        public Playlist()
        {
            _outputDevice = new WaveOutEvent();
            _outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            _forcedStop = false;
        }

        /// <summary>
        /// Gets current playing track node
        /// </summary>
        public LinkedListItem<Composition>? Current => _current;

        /// <summary>
        /// Gets <see langword="true"/> if current track is playing, <see langword="false"/> if stopped or paused
        /// </summary>
        public bool IsPlaying => _outputDevice.PlaybackState == PlaybackState.Playing;

        /// <summary>
        /// Gets current playback time or zero, if no track playing
        /// </summary>
        public TimeSpan CurrentTime => _audioFile?.CurrentTime ?? TimeSpan.Zero;

        /// <summary>
        /// Gets total playback time or zero, if no track playing
        /// </summary>
        public TimeSpan TotalTime => _audioFile?.TotalTime ?? TimeSpan.Zero;

        /// <summary>
        /// Gets or sets playback volume in range [0, 1]
        /// </summary>
        public float Volume 
        {
            get => _volume;
            set
            {
                _volume = value;
                if (!IsMuted)
                    _outputDevice.Volume = value;
            }
        }

        /// <summary>
        /// Gets or sets playback mute state
        /// </summary>
        public bool IsMuted 
        { 
            get => _isMuted; 
            set
            {
                _isMuted = value;
                _outputDevice.Volume = value ? 0f : _volume;
            }
        }

        /// <summary>
        /// Starts playing next track in a playlist
        /// </summary>
        /// <returns>Next track</returns>
        /// <exception cref="NullReferenceException">If current track is <see langword="null"/></exception>
        /// <exception cref="FileNotFoundException">If track is not found</exception>
        /// <exception cref="FileInvalidException">If track file is invalid</exception>
        public Composition? NextTrack()
        {
            if (_current == null)
                throw new NullReferenceException();
            PlayTrack(_current.Next!);
            return _current.Value;
        }

        /// <summary>
        /// Starts playing previous track in a playlist
        /// </summary>
        /// <returns>Previous track</returns>
        /// <exception cref="NullReferenceException">If current track is <see langword="null"/></exception>
        /// <exception cref="FileNotFoundException">If track is not found</exception>
        /// <exception cref="FileInvalidException">If track file is invalid</exception>
        public Composition? PreviousTrack()
        {
            if (_current == null)
                throw new NullReferenceException();
            PlayTrack(_current.Prev!);
            return _current.Value;
        }

        /// <summary>
        /// Starts playing whole playlist starting from provided track
        /// </summary>
        /// <param name="startingTrack">Track node to start from</param>
        /// <exception cref="FileNotFoundException">If track is not found</exception>
        /// <exception cref="FileInvalidException">If track file is invalid</exception>
        public void PlayAll(LinkedListItem<Composition> startingTrack)
        {
            ValidateNode(startingTrack);
            PlayTrack(startingTrack);
        }

        /// <summary>
        /// Sets current playback time
        /// </summary>
        /// <param name="seconds">New position in seconds</param>
        /// <exception cref="NullReferenceException">If current track is <see langword="null"/></exception>
        public void Seek(float seconds)
        {
            if (_current == null)
                throw new NullReferenceException();
            _audioFile!.CurrentTime = TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Stops current playback completely
        /// </summary>
        public void Stop()
        {
            if (_outputDevice.PlaybackState != PlaybackState.Stopped)
            {
                _forcedStop = true;
                _outputDevice.Stop();
            }
            ClearCurrent();
        }

        /// <summary>
        /// Resumes current playback after pause
        /// </summary>
        public void Resume()
        {
            if (_outputDevice.PlaybackState == PlaybackState.Paused)
                _outputDevice.Play();
        }

        /// <summary>
        /// Pauses current playback
        /// </summary>
        public void Pause()
        {
            if (_outputDevice.PlaybackState == PlaybackState.Playing)
                _outputDevice.Pause();
        }

        /// <summary>
        /// Free all resources taken by audio playing
        /// </summary>
        public void Dispose()
        {
            if (_outputDevice.PlaybackState != PlaybackState.Stopped)
                Stop();
            _outputDevice.Dispose();
        }

        /// <summary>
        /// Play next track
        /// </summary>
        /// <param name="track"></param>
        /// <exception cref="FileNotFoundException">If track file doesn't found</exception>
        /// <exception cref="FileInvalidException">If track file is invalid</exception>
        private void PlayTrack(LinkedListItem<Composition> track)
        {
            if (!File.Exists(track.Value.FilePath))
                throw new FileNotFoundException("Track can't be found", track.Value.FilePath);
            AudioFileReader newAudio;
            try
            {
                newAudio = new(track.Value.FilePath);
            }
            catch (COMException e)
            {
                throw new FileInvalidException("Track file is corrupted or wrong format", track.Value.FilePath, e);
            }
            if (_current != null)
                Stop();
            _audioFile = newAudio;
            _current = track;
            _outputDevice.Init(_audioFile);
            _outputDevice.Play();
        }

        private void ClearCurrent()
        {
            _current = null;
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
        }

        private void OutputDevice_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (_forcedStop)
            {
                _forcedStop = false;
                return;
            }
            TrackEnded?.Invoke();
        }
    }
}
