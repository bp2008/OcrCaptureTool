using OcrCaptureTool.Properties;
using OcrCaptureTool.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OcrCaptureTool
{
	internal static class Program
	{
		public static OcrCaptureToolSettings settings;
		public static WebServer webServer;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			settings = new OcrCaptureToolSettings();
			settings.Load();
			settings.SaveIfNoExist();
			webServer = new WebServer();
			webServer.SetBindings(settings.webServerPort, settings.webServerPort);
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			finally
			{
				webServer.Stop();
			}

		}
	}
}
