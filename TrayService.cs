using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication1
{
	public class TrayService : INotificationService, IDisposable
	{
		private NotifyIcon _icon;
		private VisualService[] _services;
		public TrayService(VisualService[] visualServices)
		{
			_icon = new NotifyIcon {
				Icon = new Icon(GetType(), "Main.ico"),
				ContextMenu = new ContextMenu(
					visualServices
						.Select(service => new MenuItem(service.MenuEntry, (o,e) => service.Activate()))
						.Concat(new[] {
							new MenuItem("-"),
							new MenuItem("E&xit", (o,e) => Application.Exit())
						}).ToArray()
					),
				Text = "iTunes",
				Visible = true
			};
			if (visualServices.Length > 0)
			{
				_icon.ContextMenu.MenuItems.OfType<MenuItem>().First().DefaultItem = true;
				Action a = visualServices.First().Activate;
				_icon.DoubleClick += (o, e) => a();
			}
			_services = visualServices;
			Application.ApplicationExit += ApplicationExit;
		}

		public void Notify(string message)
		{
			_icon.ShowBalloonTip(1000, "iTunes manager", message, ToolTipIcon.Info);
		}

		public void ReportError(string message)
		{
			_icon.ShowBalloonTip(1000, "iTunes manager", message, ToolTipIcon.Error);
		}

		void ApplicationExit(object sender, EventArgs e)
		{
			Dispose();
		}

		public void Dispose()
		{
			if(_icon != null)
			{
				_icon.Visible = false;
				_icon.Dispose();
				_icon = null;
			}
			foreach (var visualService in _services)
			{
				visualService.Dispose();
			}
			_services = new VisualService[0];
		}
	}
}
