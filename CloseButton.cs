using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class CloseButton : Button
	{
		private SolidBrush _backgroundBrush;
		private Brush BackgroundBrush
		{
			get
			{
				if (_backgroundBrush == null || _backgroundBrush.Color != BackColor)
					_backgroundBrush = new SolidBrush(BackColor);

				return _backgroundBrush;
			}
		}

		private Pen _foregroundPen;
		private Pen ForegroundPen
		{
			get
			{
				if (_foregroundPen == null || _foregroundPen.Color != ForeColor)
					_foregroundPen = new Pen(ForeColor, 2);
 
				return _foregroundPen;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int d = Math.Min(Width, Height);
			e.Graphics.FillRectangle(BackgroundBrush, 0, 0, d, d);
			int cx = Width / 2;
			int cy = Height / 2;
			e.Graphics.DrawLine(ForegroundPen, cx - 3, cy - 3, cx + 3, cy + 3);
			e.Graphics.DrawLine(ForegroundPen, cx + 3, cy - 3, cx - 3, cy + 3);

			var path = new GraphicsPath();
			path.AddEllipse(0, 0, d, d);
			Region = new Region(path);
		}
	}
}
