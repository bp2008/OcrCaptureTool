using BPUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrCaptureTool
{
	public class OcrCaptureToolSettings : BPUtil.SerializableObjectJson
	{
		public Rectangle captureRegion = Rectangle.Empty;
		public int webServerPort = 21495;
		public int targetFPS = 5;
		public bool preview = true;
		public bool fastModel = true;

		protected override SerializableObjectJson DeserializeFromJson(string str)
		{
			return JsonConvert.DeserializeObject<OcrCaptureToolSettings>(str);
		}

		protected override string SerializeToJson(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}
	}
}
