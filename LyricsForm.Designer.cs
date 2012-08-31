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
			this.pnlResizeS = new System.Windows.Forms.Panel();
			this.pnlResizeE = new System.Windows.Forms.Panel();
			this.pnlResizeSE = new System.Windows.Forms.Panel();
			this.pnlResizeSW = new System.Windows.Forms.Panel();
			this.pnlResizeW = new System.Windows.Forms.Panel();
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
			// pnlResizeS
			// 
			this.pnlResizeS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlResizeS.BackColor = System.Drawing.Color.Black;
			this.pnlResizeS.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.pnlResizeS.Location = new System.Drawing.Point(5, 376);
			this.pnlResizeS.Margin = new System.Windows.Forms.Padding(0);
			this.pnlResizeS.Name = "pnlResizeS";
			this.pnlResizeS.Size = new System.Drawing.Size(275, 10);
			this.pnlResizeS.TabIndex = 5;
			this.pnlResizeS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizePanelSMouseMove);
			this.pnlResizeS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizePanelVMouseDown);
			this.pnlResizeS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePanelMouseUp);
			// 
			// pnlResizeE
			// 
			this.pnlResizeE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlResizeE.BackColor = System.Drawing.Color.Black;
			this.pnlResizeE.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.pnlResizeE.Location = new System.Drawing.Point(280, 24);
			this.pnlResizeE.Margin = new System.Windows.Forms.Padding(0);
			this.pnlResizeE.Name = "pnlResizeE";
			this.pnlResizeE.Size = new System.Drawing.Size(10, 352);
			this.pnlResizeE.TabIndex = 6;
			this.pnlResizeE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizePanelEMouseMove);
			this.pnlResizeE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizePanelHMouseDown);
			this.pnlResizeE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePanelMouseUp);
			// 
			// pnlResizeSE
			// 
			this.pnlResizeSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlResizeSE.BackColor = System.Drawing.Color.Black;
			this.pnlResizeSE.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.pnlResizeSE.Location = new System.Drawing.Point(280, 376);
			this.pnlResizeSE.Name = "pnlResizeSE";
			this.pnlResizeSE.Size = new System.Drawing.Size(10, 10);
			this.pnlResizeSE.TabIndex = 7;
			this.pnlResizeSE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizePanelSEMouseMove);
			this.pnlResizeSE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizePanelHVMouseDown);
			this.pnlResizeSE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePanelMouseUp);
			// 
			// pnlResizeSW
			// 
			this.pnlResizeSW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlResizeSW.BackColor = System.Drawing.Color.Black;
			this.pnlResizeSW.Cursor = System.Windows.Forms.Cursors.SizeNESW;
			this.pnlResizeSW.Location = new System.Drawing.Point(-5, 376);
			this.pnlResizeSW.Name = "pnlResizeSW";
			this.pnlResizeSW.Size = new System.Drawing.Size(10, 10);
			this.pnlResizeSW.TabIndex = 8;
			this.pnlResizeSW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizePanelSWMouseMove);
			this.pnlResizeSW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizePanelHVMouseDown);
			this.pnlResizeSW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePanelMouseUp);
			// 
			// pnlResizeW
			// 
			this.pnlResizeW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.pnlResizeW.BackColor = System.Drawing.Color.Black;
			this.pnlResizeW.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.pnlResizeW.Location = new System.Drawing.Point(-6, 24);
			this.pnlResizeW.Margin = new System.Windows.Forms.Padding(0);
			this.pnlResizeW.Name = "pnlResizeW";
			this.pnlResizeW.Size = new System.Drawing.Size(11, 352);
			this.pnlResizeW.TabIndex = 9;
			this.pnlResizeW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizePanelWMouseMove);
			this.pnlResizeW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizePanelHMouseDown);
			this.pnlResizeW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePanelMouseUp);
			// 
			// LyricsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(285, 384);
			this.Controls.Add(this.pnlResizeW);
			this.Controls.Add(this.pnlResizeSW);
			this.Controls.Add(this.pnlResizeSE);
			this.Controls.Add(this.pnlResizeE);
			this.Controls.Add(this.pnlResizeS);
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
		private System.Windows.Forms.Panel pnlResizeS;
		private System.Windows.Forms.Panel pnlResizeE;
		private System.Windows.Forms.Panel pnlResizeSE;
		private System.Windows.Forms.Panel pnlResizeSW;
		private System.Windows.Forms.Panel pnlResizeW;
	}
}