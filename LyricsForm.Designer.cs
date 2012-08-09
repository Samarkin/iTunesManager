namespace WindowsFormsApplication1
{
	partial class LyricsForm
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblLyrics = new System.Windows.Forms.Label();
			this.btnClose = new WindowsFormsApplication1.CloseButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.BackColor = System.Drawing.Color.DimGray;
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(5, 3);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(275, 17);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Nothing is playing";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.lblLyrics);
			this.panel1.Location = new System.Drawing.Point(5, 24);
			this.panel1.Margin = new System.Windows.Forms.Padding(5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(275, 352);
			this.panel1.TabIndex = 3;
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			// 
			// lblLyrics
			// 
			this.lblLyrics.AutoSize = true;
			this.lblLyrics.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblLyrics.ForeColor = System.Drawing.Color.White;
			this.lblLyrics.Location = new System.Drawing.Point(3, 0);
			this.lblLyrics.Name = "lblLyrics";
			this.lblLyrics.Size = new System.Drawing.Size(92, 13);
			this.lblLyrics.TabIndex = 0;
			this.lblLyrics.Text = "No lyrics available";
			this.lblLyrics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblLyrics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblLyrics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.LightGray;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(4, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(12, 12);
			this.btnClose.TabIndex = 4;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.CloseClick);
			// 
			// LyricsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(284, 384);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblTitle);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "LyricsForm";
			this.Opacity = 0.75;
			this.ShowInTaskbar = false;
			this.Text = "LyricsForm";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.VisibleChanged += new System.EventHandler(this.LyricsFormVisibleChanged);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LyricsFormClosing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.ResizeEnd += new System.EventHandler(this.LyricsFormResized);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblLyrics;
		private CloseButton btnClose;
	}
}