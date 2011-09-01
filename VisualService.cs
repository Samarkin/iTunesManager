using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class VisualService : IDisposable
	{
		public String MenuEntry { get; set; }
		public Form Form { get; set; }
		public void Activate()
		{
			if (Form == null) return;
			if (Form.Visible)
			{
				if (Form.WindowState == FormWindowState.Minimized)
				{
					Form.WindowState = FormWindowState.Normal;
				}
				Form.Focus();
			}
			else
			{
				Form.Show();
			}
		}

		public void Dispose()
		{
			if (Form != null)
			{
				Form.Dispose();
				Form = null;
			}
		}
	}
}
