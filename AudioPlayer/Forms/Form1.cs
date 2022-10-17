using AudioPlayer.Audio;
using AudioPlayer.Extensions;
using AudioPlayer.Properties;
using Collections;

namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly Playlist _playlist;
        private readonly Bitmap _playButtonImage;
        private readonly Bitmap _pauseButtonImage;

        public Form1()
        {
            InitializeComponent();
            _playlist = new Playlist();
            _openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 file|*.mp3|WAV file|*.wav|AIFF file|*.aiff|WMA file|*.wma",
                Multiselect = true,
                ValidateNames = true,
                CheckPathExists = true
            };
            _playButtonImage = Resources.play;
            _pauseButtonImage = Resources.pause;
            _playlist.TrackEnded += Playlist_TrackEnded;
        }

        private void PlayTrack(LinkedListItem<Composition> track)
        {
            _playlist.PlayAll(track);
            SetTrackInfo(track);
            _playButton.BackgroundImage = _pauseButtonImage;
        }

        private void SetTrackInfo(LinkedListItem<Composition>? track)
        {
            _currentTrackLabel.Text = track?.Value.Name ?? string.Empty;
            _totalTimeLabel.Text = _playlist.TotalTime.ToString("mm':'ss");
            _playbackProgress.Maximum = (int)_playlist.TotalTime.TotalSeconds;
            if (track != null)
            {
                int index = _playlist.IndexOf(track.Value);
                _playlistBox.OverrideColor(index, Color.Green);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _volumeSlider.Value = (int)(_playlist.Volume * _volumeSlider.Maximum);
            _playlistBox.Items.Clear();
            _playButton.BackgroundImage = _playButtonImage;
            SetTrackInfo(null);
            _playbackTimer.Interval = (int)(1f / 30f * 1000f);
            _playbackTimer.Enabled = true;
        }

        private void Playlist_TrackEnded()
        {
            SetTrackInfo(_playlist.Current);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (_playlist.Current == null)
            {
                if (_playlist.First == null)
                    return;
                PlayTrack(_playlist.First);
            }
            else if (_playlist.IsPlaying)
            {
                _playlist.Pause();
                _playButton.BackgroundImage = _playButtonImage;
            }
            else
            {
                _playlist.Resume();
                _playButton.BackgroundImage = _pauseButtonImage;
            }
        }

        private void PlaylistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = _playlistBox.IndexFromPoint(e.Location);
            if (index >= 0)
                PlayTrack(_playlist.GetNode(index));
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (_playlistBox.SelectedIndices[0] >= 0)
                _playlistBox.MoveItemUp(_playlistBox.SelectedIndices[0]);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (_playlistBox.SelectedIndex >= 0)
                _playlistBox.MoveItemDown(_playlistBox.SelectedIndex);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            foreach (string path in _openFileDialog.FileNames)
            {
                Composition track = new(path);
                _playlist.Add(track);
                _playlistBox.Items.Add(track.Name);
            }
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (_playlist.Current != null)
            {
                _playlist.NextTrack();
                SetTrackInfo(_playlist.Current);
            }
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            if (_playlist.Current != null)
            {
                _playlist.PreviousTrack();
                SetTrackInfo(_playlist.Current);
            }
        }

        private void VolumeSlider_Scroll(object sender, EventArgs e)
        {
            _playlist.Volume = _volumeSlider.Value / (float)_volumeSlider.Maximum;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _playlist.Dispose();
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            _currentTimeLabel.Text = _playlist.CurrentTime.ToString("mm':'ss");
            _playbackProgress.Value = (int)_playlist.CurrentTime.TotalSeconds;
        }
    }
}