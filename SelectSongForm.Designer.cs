namespace WindowsFormsApplication1
{
	partial class SelectSongForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.artistComboBox = new System.Windows.Forms.ComboBox();
			this.playlistLabel = new System.Windows.Forms.Label();
			this.songLabel = new System.Windows.Forms.Label();
			this.songComboBox = new System.Windows.Forms.ComboBox();
			this.playButton = new System.Windows.Forms.Button();
			this.shuffleButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// artistComboBox
			// 
			this.artistComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.artistComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.artistComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.artistComboBox.FormattingEnabled = true;
			this.artistComboBox.Location = new System.Drawing.Point(12, 25);
			this.artistComboBox.Name = "artistComboBox";
			this.artistComboBox.Size = new System.Drawing.Size(260, 21);
			this.artistComboBox.TabIndex = 1;
			this.artistComboBox.Leave += new System.EventHandler(this.ArtistComboBoxLeave);
			// 
			// playlistLabel
			// 
			this.playlistLabel.AutoSize = true;
			this.playlistLabel.Location = new System.Drawing.Point(12, 9);
			this.playlistLabel.Name = "playlistLabel";
			this.playlistLabel.Size = new System.Drawing.Size(71, 13);
			this.playlistLabel.TabIndex = 0;
			this.playlistLabel.Text = "Playlist name:";
			// 
			// songLabel
			// 
			this.songLabel.AutoSize = true;
			this.songLabel.Location = new System.Drawing.Point(12, 49);
			this.songLabel.Name = "songLabel";
			this.songLabel.Size = new System.Drawing.Size(35, 13);
			this.songLabel.TabIndex = 2;
			this.songLabel.Text = "Song:";
			// 
			// songComboBox
			// 
			this.songComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.songComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.songComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.songComboBox.FormattingEnabled = true;
			this.songComboBox.Location = new System.Drawing.Point(12, 65);
			this.songComboBox.Name = "songComboBox";
			this.songComboBox.Size = new System.Drawing.Size(260, 21);
			this.songComboBox.TabIndex = 3;
			// 
			// playButton
			// 
			this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.playButton.Location = new System.Drawing.Point(116, 92);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(75, 23);
			this.playButton.TabIndex = 4;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
			// 
			// shuffleButton
			// 
			this.shuffleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.shuffleButton.Location = new System.Drawing.Point(197, 92);
			this.shuffleButton.Name = "shuffleButton";
			this.shuffleButton.Size = new System.Drawing.Size(75, 23);
			this.shuffleButton.TabIndex = 5;
			this.shuffleButton.Text = "Shuffle";
			this.shuffleButton.UseVisualStyleBackColor = true;
			this.shuffleButton.Click += new System.EventHandler(this.PlayButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(12, 92);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(0, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.TabStop = false;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// SelectSongForm
			// 
			this.AcceptButton = this.shuffleButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(284, 122);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.shuffleButton);
			this.Controls.Add(this.playButton);
			this.Controls.Add(this.songComboBox);
			this.Controls.Add(this.songLabel);
			this.Controls.Add(this.playlistLabel);
			this.Controls.Add(this.artistComboBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SelectSongForm";
			this.Text = "Song Selection";
			this.VisibleChanged += new System.EventHandler(this.SelectSongFormVisibleChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectSongFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox artistComboBox;
		private System.Windows.Forms.Label playlistLabel;
		private System.Windows.Forms.Label songLabel;
		private System.Windows.Forms.ComboBox songComboBox;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Button shuffleButton;
		private System.Windows.Forms.Button cancelButton;
	}
}