namespace AudioPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._playButton = new System.Windows.Forms.Button();
            this._volumeSlider = new System.Windows.Forms.TrackBar();
            this._moveUpButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            this._moveDownButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._playbackTimer = new System.Windows.Forms.Timer(this.components);
            this._playbackProgress = new System.Windows.Forms.ProgressBar();
            this._volumeButton = new System.Windows.Forms.Button();
            this._currentTrackGroup = new System.Windows.Forms.GroupBox();
            this._currentTrackLabel = new System.Windows.Forms.Label();
            this._forwardButton = new System.Windows.Forms.Button();
            this._backwardButton = new System.Windows.Forms.Button();
            this._playlistStaticLabel = new System.Windows.Forms.Label();
            this._totalTimeLabel = new System.Windows.Forms.Label();
            this._currentTimeLabel = new System.Windows.Forms.Label();
            this._playlistBox = new AudioPlayer.Forms.ListBoxExtended();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._playlistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._addPlaylistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._loadPlaylistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._playlistNameTextBox = new System.Windows.Forms.TextBox();
            this._savePlaylistButton = new System.Windows.Forms.Button();
            this._playlistTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this._volumeSlider)).BeginInit();
            this._currentTrackGroup.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._playlistTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _playButton
            // 
            this._playButton.BackColor = System.Drawing.Color.Transparent;
            this._playButton.BackgroundImage = global::AudioPlayer.Properties.Resources.play;
            this._playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._playButton.FlatAppearance.BorderSize = 0;
            this._playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._playButton.Location = new System.Drawing.Point(245, 432);
            this._playButton.Name = "_playButton";
            this._playButton.Size = new System.Drawing.Size(40, 40);
            this._playButton.TabIndex = 0;
            this._playButton.UseVisualStyleBackColor = false;
            this._playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // _volumeSlider
            // 
            this._volumeSlider.Location = new System.Drawing.Point(412, 432);
            this._volumeSlider.Maximum = 1000;
            this._volumeSlider.Name = "_volumeSlider";
            this._volumeSlider.Size = new System.Drawing.Size(113, 45);
            this._volumeSlider.TabIndex = 5;
            this._volumeSlider.TickFrequency = 200;
            this._volumeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this._volumeSlider.Scroll += new System.EventHandler(this.VolumeSlider_Scroll);
            // 
            // _moveUpButton
            // 
            this._moveUpButton.BackColor = System.Drawing.Color.Transparent;
            this._moveUpButton.BackgroundImage = global::AudioPlayer.Properties.Resources.up_arrow;
            this._moveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._moveUpButton.FlatAppearance.BorderSize = 0;
            this._moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._moveUpButton.Location = new System.Drawing.Point(7, 51);
            this._moveUpButton.Name = "_moveUpButton";
            this._moveUpButton.Size = new System.Drawing.Size(30, 30);
            this._moveUpButton.TabIndex = 7;
            this._moveUpButton.UseVisualStyleBackColor = false;
            this._moveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // _removeButton
            // 
            this._removeButton.BackColor = System.Drawing.Color.Transparent;
            this._removeButton.BackgroundImage = global::AudioPlayer.Properties.Resources.delete;
            this._removeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._removeButton.FlatAppearance.BorderSize = 0;
            this._removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._removeButton.Location = new System.Drawing.Point(7, 353);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(30, 30);
            this._removeButton.TabIndex = 8;
            this._removeButton.UseVisualStyleBackColor = false;
            this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // _moveDownButton
            // 
            this._moveDownButton.BackColor = System.Drawing.Color.Transparent;
            this._moveDownButton.BackgroundImage = global::AudioPlayer.Properties.Resources.down_arrow;
            this._moveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._moveDownButton.FlatAppearance.BorderSize = 0;
            this._moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._moveDownButton.Location = new System.Drawing.Point(7, 87);
            this._moveDownButton.Name = "_moveDownButton";
            this._moveDownButton.Size = new System.Drawing.Size(30, 30);
            this._moveDownButton.TabIndex = 9;
            this._moveDownButton.UseVisualStyleBackColor = false;
            this._moveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // _addButton
            // 
            this._addButton.BackColor = System.Drawing.Color.Transparent;
            this._addButton.BackgroundImage = global::AudioPlayer.Properties.Resources.add;
            this._addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._addButton.FlatAppearance.BorderSize = 0;
            this._addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._addButton.Location = new System.Drawing.Point(7, 288);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(30, 30);
            this._addButton.TabIndex = 10;
            this._addButton.UseVisualStyleBackColor = false;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // _playbackTimer
            // 
            this._playbackTimer.Tick += new System.EventHandler(this.PlaybackTimer_Tick);
            // 
            // _playbackProgress
            // 
            this._playbackProgress.Location = new System.Drawing.Point(175, 485);
            this._playbackProgress.Name = "_playbackProgress";
            this._playbackProgress.Size = new System.Drawing.Size(180, 10);
            this._playbackProgress.TabIndex = 11;
            this._playbackProgress.Value = 50;
            this._playbackProgress.Click += new System.EventHandler(this.PlaybackProgress_Click);
            // 
            // _volumeButton
            // 
            this._volumeButton.BackColor = System.Drawing.Color.Transparent;
            this._volumeButton.BackgroundImage = global::AudioPlayer.Properties.Resources.volume;
            this._volumeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._volumeButton.FlatAppearance.BorderSize = 0;
            this._volumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._volumeButton.Location = new System.Drawing.Point(385, 437);
            this._volumeButton.Name = "_volumeButton";
            this._volumeButton.Size = new System.Drawing.Size(30, 30);
            this._volumeButton.TabIndex = 12;
            this._volumeButton.UseVisualStyleBackColor = false;
            this._volumeButton.Click += new System.EventHandler(this.VolumeButton_Click);
            // 
            // _currentTrackGroup
            // 
            this._currentTrackGroup.Controls.Add(this._currentTrackLabel);
            this._currentTrackGroup.Location = new System.Drawing.Point(7, 421);
            this._currentTrackGroup.Name = "_currentTrackGroup";
            this._currentTrackGroup.Size = new System.Drawing.Size(126, 74);
            this._currentTrackGroup.TabIndex = 13;
            this._currentTrackGroup.TabStop = false;
            this._currentTrackGroup.Text = "Current Track";
            // 
            // _currentTrackLabel
            // 
            this._currentTrackLabel.Location = new System.Drawing.Point(6, 16);
            this._currentTrackLabel.Name = "_currentTrackLabel";
            this._currentTrackLabel.Size = new System.Drawing.Size(114, 51);
            this._currentTrackLabel.TabIndex = 0;
            this._currentTrackLabel.Text = "Psycho";
            this._currentTrackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _forwardButton
            // 
            this._forwardButton.BackColor = System.Drawing.Color.Transparent;
            this._forwardButton.BackgroundImage = global::AudioPlayer.Properties.Resources.fast_forward;
            this._forwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._forwardButton.FlatAppearance.BorderSize = 0;
            this._forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._forwardButton.Location = new System.Drawing.Point(291, 437);
            this._forwardButton.Name = "_forwardButton";
            this._forwardButton.Size = new System.Drawing.Size(30, 30);
            this._forwardButton.TabIndex = 14;
            this._forwardButton.UseVisualStyleBackColor = false;
            this._forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // _backwardButton
            // 
            this._backwardButton.BackColor = System.Drawing.Color.Transparent;
            this._backwardButton.BackgroundImage = global::AudioPlayer.Properties.Resources.fast_backward;
            this._backwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._backwardButton.FlatAppearance.BorderSize = 0;
            this._backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._backwardButton.Location = new System.Drawing.Point(209, 437);
            this._backwardButton.Name = "_backwardButton";
            this._backwardButton.Size = new System.Drawing.Size(30, 30);
            this._backwardButton.TabIndex = 15;
            this._backwardButton.UseVisualStyleBackColor = false;
            this._backwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
            // 
            // _playlistStaticLabel
            // 
            this._playlistStaticLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._playlistStaticLabel.Location = new System.Drawing.Point(40, 24);
            this._playlistStaticLabel.Name = "_playlistStaticLabel";
            this._playlistStaticLabel.Size = new System.Drawing.Size(61, 27);
            this._playlistStaticLabel.TabIndex = 1;
            this._playlistStaticLabel.Text = "Playlist";
            this._playlistStaticLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _totalTimeLabel
            // 
            this._totalTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._totalTimeLabel.Location = new System.Drawing.Point(358, 482);
            this._totalTimeLabel.Name = "_totalTimeLabel";
            this._totalTimeLabel.Size = new System.Drawing.Size(66, 15);
            this._totalTimeLabel.TabIndex = 16;
            this._totalTimeLabel.Text = "99:99";
            this._totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _currentTimeLabel
            // 
            this._currentTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._currentTimeLabel.Location = new System.Drawing.Point(133, 482);
            this._currentTimeLabel.Name = "_currentTimeLabel";
            this._currentTimeLabel.Size = new System.Drawing.Size(39, 15);
            this._currentTimeLabel.TabIndex = 17;
            this._currentTimeLabel.Text = "99:99";
            this._currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _playlistBox
            // 
            this._playlistBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._playlistBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._playlistBox.FormattingEnabled = true;
            this._playlistBox.ItemHeight = 21;
            this._playlistBox.Items.AddRange(new object[] {
            "ddd",
            "fff",
            "ggg"});
            this._playlistBox.Location = new System.Drawing.Point(-4, -3);
            this._playlistBox.Name = "_playlistBox";
            this._playlistBox.Size = new System.Drawing.Size(482, 340);
            this._playlistBox.TabIndex = 18;
            this._playlistBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PlaylistBox_MouseDoubleClick);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._playlistMenu});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(534, 24);
            this._menuStrip.TabIndex = 19;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _playlistMenu
            // 
            this._playlistMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addPlaylistMenu,
            this._loadPlaylistMenu});
            this._playlistMenu.Name = "_playlistMenu";
            this._playlistMenu.Size = new System.Drawing.Size(56, 20);
            this._playlistMenu.Text = "Playlist";
            // 
            // _addPlaylistMenu
            // 
            this._addPlaylistMenu.Name = "_addPlaylistMenu";
            this._addPlaylistMenu.Size = new System.Drawing.Size(100, 22);
            this._addPlaylistMenu.Text = "New";
            this._addPlaylistMenu.Click += new System.EventHandler(this.AddPlaylistMenu_Click);
            // 
            // _loadPlaylistMenu
            // 
            this._loadPlaylistMenu.Name = "_loadPlaylistMenu";
            this._loadPlaylistMenu.Size = new System.Drawing.Size(100, 22);
            this._loadPlaylistMenu.Text = "Load";
            this._loadPlaylistMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LoadPlaylistMenu_DropDownItemClicked);
            // 
            // _playlistNameTextBox
            // 
            this._playlistNameTextBox.Location = new System.Drawing.Point(107, 28);
            this._playlistNameTextBox.Name = "_playlistNameTextBox";
            this._playlistNameTextBox.PlaceholderText = "Enter playlist name...";
            this._playlistNameTextBox.Size = new System.Drawing.Size(317, 23);
            this._playlistNameTextBox.TabIndex = 20;
            this._playlistNameTextBox.TextChanged += new System.EventHandler(this.PlaylistNameTextBox_TextChanged);
            // 
            // _savePlaylistButton
            // 
            this._savePlaylistButton.Location = new System.Drawing.Point(430, 27);
            this._savePlaylistButton.Name = "_savePlaylistButton";
            this._savePlaylistButton.Size = new System.Drawing.Size(92, 24);
            this._savePlaylistButton.TabIndex = 21;
            this._savePlaylistButton.Text = "Save playlist";
            this._savePlaylistButton.UseVisualStyleBackColor = true;
            this._savePlaylistButton.Click += new System.EventHandler(this.SavePlaylistButton_Click);
            // 
            // _playlistTabs
            // 
            this._playlistTabs.Controls.Add(this.tabPage1);
            this._playlistTabs.Location = new System.Drawing.Point(40, 51);
            this._playlistTabs.Name = "_playlistTabs";
            this._playlistTabs.SelectedIndex = 0;
            this._playlistTabs.Size = new System.Drawing.Size(485, 364);
            this._playlistTabs.TabIndex = 22;
            this._playlistTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.PlaylistTabs_Selected);
            this._playlistTabs.Deselected += new System.Windows.Forms.TabControlEventHandler(this.PlaylistTabs_Deselected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._playlistBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 502);
            this.Controls.Add(this._playlistTabs);
            this.Controls.Add(this._savePlaylistButton);
            this.Controls.Add(this._playlistNameTextBox);
            this.Controls.Add(this._currentTimeLabel);
            this.Controls.Add(this._totalTimeLabel);
            this.Controls.Add(this._playlistStaticLabel);
            this.Controls.Add(this._backwardButton);
            this.Controls.Add(this._forwardButton);
            this.Controls.Add(this._currentTrackGroup);
            this.Controls.Add(this._volumeButton);
            this.Controls.Add(this._playbackProgress);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._moveDownButton);
            this.Controls.Add(this._removeButton);
            this.Controls.Add(this._moveUpButton);
            this.Controls.Add(this._volumeSlider);
            this.Controls.Add(this._playButton);
            this.Controls.Add(this._menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Audio Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._volumeSlider)).EndInit();
            this._currentTrackGroup.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._playlistTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button _playButton;
        private TrackBar _volumeSlider;
        private Button _moveUpButton;
        private Button _removeButton;
        private Button _moveDownButton;
        private Button _addButton;
        private System.Windows.Forms.Timer _playbackTimer;
        private ProgressBar _playbackProgress;
        private Button _volumeButton;
        private GroupBox _currentTrackGroup;
        private Label _currentTrackLabel;
        private Button _forwardButton;
        private Button _backwardButton;
        private Label _playlistStaticLabel;
        private Label _totalTimeLabel;
        private Label _currentTimeLabel;
        private Forms.ListBoxExtended _playlistBox;
        private MenuStrip _menuStrip;
        private TextBox _playlistNameTextBox;
        private Button _savePlaylistButton;
        private TabControl _playlistTabs;
        private TabPage tabPage1;
        private ToolStripMenuItem _playlistMenu;
        private ToolStripMenuItem _addPlaylistMenu;
        private ToolStripMenuItem _loadPlaylistMenu;
    }
}