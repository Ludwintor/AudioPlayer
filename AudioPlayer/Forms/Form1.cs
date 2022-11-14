using AudioPlayer.Audio;
using AudioPlayer.Exceptions;
using AudioPlayer.Properties;
using Collections;
using Newtonsoft.Json;

namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        private const float DEFAULT_VOLUME = 0.5f;
        private const string PLAYLIST_SAVE_DIR = "Playlists";

        private readonly OpenFileDialog _openAudioDialog;
        private readonly Playlist _playlist;
        private readonly Bitmap _playButtonImage;
        private readonly Bitmap _pauseButtonImage;
        private readonly Bitmap _volumeButtonImage;
        private readonly Bitmap _muteButtonImage;
        private readonly Dictionary<int, Composition[]> _playlists = new();

        public Form1()
        {
            InitializeComponent();
            _playlist = new();
            LoadSavedPlaylists();
            _openAudioDialog = new OpenFileDialog
            {
                Filter = "MP3 file|*.mp3|WAV file|*.wav|AIFF file|*.aiff|WMA file|*.wma",
                Multiselect = true,
                ValidateNames = true,
                CheckPathExists = true
            };
            _playButtonImage = Resources.play;
            _pauseButtonImage = Resources.pause;
            _volumeButtonImage = Resources.volume;
            _muteButtonImage = Resources.volume_mute;
            _playlist.Volume = DEFAULT_VOLUME;
            _playlistNameTextBox.Text = _playlistTabs.SelectedTab.Text;
            _playlist.TrackEnded += Playlist_TrackEnded;
        }

        private void PlayTrack(LinkedListItem<Composition> track)
        {
            try
            {
                _playlist.PlayAll(track);
                SetTrackInfo(track);
                _playButton.BackgroundImage = _pauseButtonImage;
            }
            catch (FileNotFoundException e)
            {
                HandleTrackNotFound(e);
            }
            catch (FileInvalidException e)
            {
                HandleTrackInvalid(e);
            }
        }

        private void StopPlayback()
        {
            _playlist.Stop();
            SetTrackInfo(null);
            _playButton.BackgroundImage = _playButtonImage;
        }

        private void PlayNextTrack()
        {
            try
            {
                _playlist.NextTrack();
                SetTrackInfo(_playlist.Current);
                _playButton.BackgroundImage = _pauseButtonImage;
            }
            catch (FileNotFoundException e)
            {
                HandleTrackNotFound(e);
            }
            catch (FileInvalidException e)
            {
                HandleTrackInvalid(e);
            }
        }

        private void PlayPreviousTrack()
        {
            try
            {
                _playlist.PreviousTrack();
                SetTrackInfo(_playlist.Current);
                _playButton.BackgroundImage = _pauseButtonImage;
            }
            catch (FileNotFoundException e)
            {
                HandleTrackNotFound(e);
            }
            catch (FileInvalidException e)
            {
                HandleTrackInvalid(e);
            }
        }

        private void SetTrackInfo(LinkedListItem<Composition>? track)
        {
            _playlistBox.ClearAllColors();
            _currentTrackLabel.Text = track?.Value.Name ?? string.Empty;
            _totalTimeLabel.Text = _playlist.TotalTime.ToString("mm':'ss");
            _playbackProgress.Maximum = (int)_playlist.TotalTime.TotalSeconds;
            if (track != null)
            {
                int index = _playlist.IndexOf(track.Value);
                _playlistBox.OverrideColor(index, Color.Green);
            }
        }

        private void ResumePlayback()
        {
            _playlist.Resume();
            _playButton.BackgroundImage = _pauseButtonImage;
        }

        private void PausePlayback()
        {
            _playlist.Pause();
            _playButton.BackgroundImage = _playButtonImage;
        }

        private void Playlist_TrackEnded()
        {
            PlayNextTrack();
        }

        #region Form Events

        private void Form1_Load(object sender, EventArgs e)
        {
            _volumeSlider.Value = (int)(_playlist.Volume * _volumeSlider.Maximum);
            _playlistBox.Items.Clear();
            _playButton.BackgroundImage = _playButtonImage;
            SetTrackInfo(null);
            _playbackTimer.Interval = (int)(1f / 30f * 1000f);
            _playbackTimer.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _playlist.Dispose();
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
                PausePlayback();
            }
            else
            {
                ResumePlayback();
            }
        }

        private void VolumeButton_Click(object sender, EventArgs e)
        {
            _playlist.IsMuted = !_playlist.IsMuted;
            _volumeButton.BackgroundImage = _playlist.IsMuted ? _muteButtonImage : _volumeButtonImage;
        }

        private void PlaylistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = _playlistBox.IndexFromPoint(e.Location);
            if (index >= 0)
                PlayTrack(_playlist.GetNode(index));
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            int index = _playlistBox.SelectedIndex;
            if (index > 0)
            {
                _playlistBox.MoveItemUp(index);
                LinkedListItem<Composition> node = _playlist.GetNode(index);
                LinkedListItem<Composition> prevNode = node.Prev!;
                _playlist.Remove(node);
                _playlist.AppendBefore(prevNode, node);
            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            int index = _playlistBox.SelectedIndex;
            if (index >= 0 && index < _playlist.Count - 1)
            {
                _playlistBox.MoveItemDown(index);
                LinkedListItem<Composition> node = _playlist.GetNode(index);
                LinkedListItem<Composition> nextNode = node.Next!;
                _playlist.Remove(node);
                _playlist.AppendAfter(nextNode, node);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_openAudioDialog.ShowDialog() != DialogResult.OK)
                return;

            foreach (string path in _openAudioDialog.FileNames)
            {
                Composition track = new(path);
                _playlist.Add(track);
                _playlistBox.Items.Add(track.Name);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int index = _playlistBox.SelectedIndex;
            if (index == -1)
                return;
            LinkedListItem<Composition> track = _playlist.GetNode(index);
            if (_playlist.Current == track)
            {
                StopPlayback();
            }
            _playlist.Remove(track);
            _playlistBox.Items.RemoveAt(index);
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (_playlist.Current != null)
                PlayNextTrack();
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            if (_playlist.Current != null)
                PlayPreviousTrack();
        }

        private void VolumeSlider_Scroll(object sender, EventArgs e)
        {
            _playlist.Volume = _volumeSlider.Value / (float)_volumeSlider.Maximum;
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            _currentTimeLabel.Text = _playlist.CurrentTime.ToString("mm':'ss");
            _playbackProgress.Value = (int)_playlist.CurrentTime.TotalSeconds;
        }

        private void PlaybackProgress_Click(object sender, EventArgs e)
        {
            if (_playlist.Current == null)
                return;
            Point point = _playbackProgress.PointToClient(MousePosition);
            float position = (float)point.X / _playbackProgress.Width;
            float seconds = position * (float)_playlist.TotalTime.TotalSeconds;
            _playlist.Seek(seconds);
            _playbackProgress.Value = (int)seconds;
            ResumePlayback();
        }

        private void AddPlaylistMenu_Click(object sender, EventArgs e)
        {
            _playlistTabs.TabPages.Add($"New {_playlistTabs.TabPages.Count + 1}");
        }

        private void SavePlaylistButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(PLAYLIST_SAVE_DIR))
                Directory.CreateDirectory(PLAYLIST_SAVE_DIR);
            string name = _playlistNameTextBox.Text;
            if (string.IsNullOrEmpty(name))
                return;
            if (!_loadPlaylistMenu.DropDownItems.ContainsKey(name))
            {
                ToolStripItem item = _loadPlaylistMenu.DropDownItems.Add(name);
                item.Name = name;
            }
            else
            {
                DialogResult result = MessageBox.Show("Playlist with that name already exists\nOverwrite it?", "Confirm",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            string[] filePaths = _playlist.Select(composition => composition.FilePath).ToArray();
            string json = JsonConvert.SerializeObject(filePaths);
            File.WriteAllText(Path.Combine(PLAYLIST_SAVE_DIR, name), json);
        }

        private void LoadPlaylistMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Text;
            string path = Path.Combine(PLAYLIST_SAVE_DIR, name);
            if (!File.Exists(path))
            {
                MessageBox.Show("Playlist with that name is not found");
                _loadPlaylistMenu.DropDownItems.RemoveByKey(name);
                return;
            }
            string json = File.ReadAllText(path);
            string[] trackPaths = JsonConvert.DeserializeObject<string[]>(json)!;
            if (trackPaths == null)
                return;
            if (_playlist.Current != null)
                StopPlayback();
            _playlist.Clear();
            _playlistBox.Items.Clear();
            foreach (string trackPath in trackPaths)
            {
                Composition track = new(trackPath);
                _playlist.Add(track);
                _playlistBox.Items.Add(track.Name);
            }
            _playlistNameTextBox.Text = name;
        }

        private void PlaylistNameTextBox_TextChanged(object sender, EventArgs e)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            _playlistNameTextBox.Text = string.Join("", _playlistNameTextBox.Text.Split(invalidChars));
            _playlistNameTextBox.SelectionStart = _playlistNameTextBox.Text.Length + 1;
            _playlistTabs.SelectedTab.Text = _playlistNameTextBox.Text;
        }

        #endregion

        private void LoadSavedPlaylists()
        {
            _loadPlaylistMenu.DropDownItems.Clear();
            if (!Directory.Exists(PLAYLIST_SAVE_DIR))
                return;
            foreach (string path in Directory.GetFiles(PLAYLIST_SAVE_DIR))
            {
                string name = Path.GetFileName(path);
                ToolStripItem item = _loadPlaylistMenu.DropDownItems.Add(name);
                item.Name = name;
            }
        }

        private void HandleTrackNotFound(FileNotFoundException e)
        {
            MessageBox.Show($"File at path {e.FileName} can't be found");
        }

        private void HandleTrackInvalid(FileInvalidException e)
        {
            MessageBox.Show($"File at path {e.FileName} is corrupted or wrong format");
        }

        private void PlaylistTabs_Selected(object sender, TabControlEventArgs e)
        {
            e.TabPage!.Controls.Add(_playlistBox);
            RepopulatePlaylist(_playlists.GetValueOrDefault(e.TabPageIndex));
            _playlistNameTextBox.Text = e.TabPage.Text;
        }

        private void RepopulatePlaylist(Composition[]? tracks)
        {
            if (_playlist.Current != null)
                StopPlayback();
            _playlist.Clear();
            _playlistBox.Items.Clear();
            if (tracks == null)
                return;
            foreach (Composition track in tracks)
            {
                _playlist.Add(track);
                _playlistBox.Items.Add(track.Name);
            }
        }

        private void PlaylistTabs_Deselected(object sender, TabControlEventArgs e)
        {
            int index = e.TabPageIndex;
            _playlists[index] = _playlist.ToArray();
        }
    }
}