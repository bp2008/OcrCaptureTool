using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BPUtil;
using BPUtil.MVC;
using BPUtil.SimpleHttp;
using OcrCaptureTool.Web.MVC;

namespace OcrCaptureTool.Web
{
	public class WebServer : HttpServer
	{
		MVCMain mvc;

		public WebServer()
		{
			mvc = new MVCMain(Assembly.GetExecutingAssembly(), typeof(GetCurrentTextContent).Namespace, (context, ex) => { Logger.Debug(ex, "Error handling web request: " + context.httpProcessor.Request.Url.ToString()); });
		}

		public override void handleGETRequest(HttpProcessor p)
		{
			if (mvc.ProcessRequest(p))
				return;
		}

		public override void handlePOSTRequest(HttpProcessor p)
		{
			if (mvc.ProcessRequest(p))
				return;
		}

		protected override void stopServer()
		{
		}
	}
}
