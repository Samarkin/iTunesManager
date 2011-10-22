using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.ApplicationExitCall) return;
			e.Cancel = true;
			switch(MessageBox.Show("Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
			{
				case DialogResult.Yes:
					Settings.Default.Save();
					break;
				case DialogResult.No:
					Settings.Default.Reload();
					break;
				case DialogResult.Cancel:
					return;
			}
			Hide();
		}

		private void SettingsFormVisibleChanged(object sender, System.EventArgs e)
		{
			if (Visible)
				propertyGrid1.SelectedObject = Settings.Default;
		}
	}
}
