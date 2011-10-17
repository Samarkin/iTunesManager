namespace WindowsFormsApplication1
{
	partial class OSDForm
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
			this.components = new System.ComponentModel.Container();
			this.closeTimer = new System.Windows.Forms.Timer(this.components);
			this.artworkPicture = new System.Windows.Forms.PictureBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.artistLabel = new System.Windows.Forms.Label();
			this.albumLabel = new System.Windows.Forms.Label();
			this.showHideTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.artworkPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// closeTimer
			// 
			this.closeTimer.Interval = 3000;
			// 
			// artworkPicture
			// 
			this.artworkPicture.Location = new System.Drawing.Point(0, 1);
			this.artworkPicture.Name = "artworkPicture";
			this.artworkPicture.Size = new System.Drawing.Size(100, 100);
			this.artworkPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.artworkPicture.TabIndex = 0;
			this.artworkPicture.TabStop = false;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.Location = new System.Drawing.Point(118, 11);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(94, 47);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "Title";
			// 
			// artistLabel
			// 
			this.artistLabel.AutoSize = true;
			this.artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.artistLabel.ForeColor = System.Drawing.Color.White;
			this.artistLabel.Location = new System.Drawing.Point(122, 58);
			this.artistLabel.Name = "artistLabel";
			this.artistLabel.Size = new System.Drawing.Size(46, 20);
			this.artistLabel.TabIndex = 2;
			this.artistLabel.Text = "Artist";
			// 
			// albumLabel
			// 
			this.albumLabel.AutoSize = true;
			this.albumLabel.ForeColor = System.Drawing.Color.White;
			this.albumLabel.Location = new System.Drawing.Point(123, 78);
			this.albumLabel.Name = "albumLabel";
			this.albumLabel.Size = new System.Drawing.Size(65, 13);
			this.albumLabel.TabIndex = 3;
			this.albumLabel.Text = "Album (year)";
			// 
			// showHideTimer
			// 
			this.showHideTimer.Interval = 10;
			// 
			// OSDForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(606, 102);
			this.ControlBox = false;
			this.Controls.Add(this.albumLabel);
			this.Controls.Add(this.artistLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.artworkPicture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OSDForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "OSDForm";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.artworkPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.PictureBox artworkPicture;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label artistLabel;
		private System.Windows.Forms.Label albumLabel;
		private System.Windows.Forms.Timer showHideTimer;
	}
}