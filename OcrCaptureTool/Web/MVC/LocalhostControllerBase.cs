using BPUtil.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrCaptureTool.Web.MVC
{
	public class LocalhostControllerBase : Controller
	{
		public override ActionResult OnAuthorization()
		{
			return Context.httpProcessor.IsLocalConnection ? null : StatusCode("403 localhost only");
		}
	}
}
