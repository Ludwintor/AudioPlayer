using Collections;
using NAudio.Wave;

namespace AudioPlayer.Audio
{
    public sealed class Playlist : Collections.LinkedList<Composition>, IDisposable
    {
        public event Action? TrackEnded;

        private readonly WaveOutEvent _outputDevice;
        private AudioFileReader? _audioFile;
        private LinkedListItem<Composition>? _current;
        private bool _isMuted;
        private bool _forcedStop;

        public Playlist()
        {
            _outputDevice = new WaveOutEvent();
            _outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
            _forcedStop = false;
        }

        public LinkedListItem<Composition>? Current => _current;

        public bool IsPlaying => _outputDevice.PlaybackState == PlaybackState.Playing;

        public TimeSpan CurrentTime => _audioFile?.CurrentTime ?? TimeSpan.Zero;

        public TimeSpan TotalTime => _audioFile?.TotalTime ?? TimeSpan.Zero;

        public float Volume 
        { 
            get => _outputDevice.Volume;
            set
            {
                _outputDevice.Volume = value;
                _isMuted = false;
            }
        }

        public bool IsMuted
        {
            get => _isMuted;
            set
            {
                _isMuted = value;
                _outputDevice.Volume = value ? 0f : _outputDevice.Volume;
            }
        }

        public Composition? NextTrack()
        {
            if (_current == null)
                throw new NullReferenceException();
            PlayTrack(_current.Next!);
            return _current.Value;
        }

        public Composition? PreviousTrack()
        {
            if (_current == null)
                throw new NullReferenceException();
            PlayTrack(_current.Prev!);
            return _current.Value;
        }

        public void PlayAll(LinkedListItem<Composition> startingTrack)
        {
            ValidateNode(startingTrack);
            PlayTrack(startingTrack);
        }

        public void Stop()
        {
            _forcedStop = true;
            _outputDevice.Stop();
            ClearCurrent();
        }

        public void Resume()
        {
            _outputDevice.Play();
        }

        public void Pause()
        {
            _outputDevice.Pause();
        }

        public void Dispose()
        {
            if (_outputDevice.PlaybackState != PlaybackState.Stopped)
                Stop();
            _outputDevice.Dispose();
        }

        private void PlayTrack(LinkedListItem<Composition> track)
        {
            if (_current != null)
                Stop();
            _current = track;
            _audioFile = new(track.Value.FilePath);
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

            NextTrack();
            TrackEnded?.Invoke();
        }
    }
}
