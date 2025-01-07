using BPUtil.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrCaptureTool.Web.MVC
{
	public class GetCurrentTextContent : LocalhostControllerBase
	{
		public ActionResult Index()
		{
			Context.AddResponseHeader("Access-Control-Allow-Origin", "*");
			return PlainText(MainForm.Current.GetCurrentText());
		}
		public ActionResult StreamingWebSocket()
		{
			Context.AddResponseHeader("Access-Control-Allow-Origin", "*");
			return StatusCode("400 Not Implemented");
		}
	}
}
