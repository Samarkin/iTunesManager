using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			propertyGrid1.SelectedObject = Settings.Default;
		}

		private void SettingsFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.Save();
			if (e.CloseReason == CloseReason.ApplicationExitCall) return;

			e.Cancel = true;
			MessageBox.Show("Changes will take effect only after next run", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			Hide();
		}
	}
}
