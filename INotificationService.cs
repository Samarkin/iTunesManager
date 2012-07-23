using System;

namespace WindowsFormsApplication1
{
	public interface INotificationService
	{
		void Notify(string message);
		void ReportError(string message);
	}
}