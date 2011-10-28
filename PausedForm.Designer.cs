namespace WindowsFormsApplication1
{
	partial class PausedForm
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
			this.pausedLabel = new System.Windows.Forms.Label();
			this.growTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pausedLabel
			// 
			this.pausedLabel.AutoEllipsis = true;
			this.pausedLabel.BackColor = System.Drawing.Color.Transparent;
			this.pausedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pausedLabel.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.pausedLabel.ForeColor = System.Drawing.Color.Black;
			this.pausedLabel.Location = new System.Drawing.Point(0, 0);
			this.pausedLabel.Name = "pausedLabel";
			this.pausedLabel.Size = new System.Drawing.Size(64, 35);
			this.pausedLabel.TabIndex = 0;
			this.pausedLabel.Text = "PAUSED";
			this.pausedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// growTimer
			// 
			this.growTimer.Interval = 10;
			this.growTimer.Tick += new System.EventHandler(this.GrowTimerTick);
			// 
			// PausedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(64, 35);
			this.Controls.Add(this.pausedLabel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PausedForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "PausedForm";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label pausedLabel;
		private System.Windows.Forms.Timer growTimer;
	}
}