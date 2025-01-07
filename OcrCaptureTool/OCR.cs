using BPUtil;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace OcrCaptureTool
{
	public static class OCR
	{
		static TesseractEngine slowEngine = null;
		static TesseractEngine fastEngine = null;
		/// <summary>
		/// Returns the text found in the given image.
		/// </summary>
		/// <param name="img">Image to process.</param>
		/// <param name="useFastModel">True to use the faster but less accurate English model.</param>
		/// <returns></returns>
		public static string GetTextFromImage(Bitmap img, bool useFastModel)
		{
			TesseractEngine engine;
			if (useFastModel)
			{
				if (fastEngine == null)
					fastEngine = new TesseractEngine("tessdata", "engfast", EngineMode.Default);
				engine = fastEngine;
			}
			else
			{
				if (slowEngine == null)
					slowEngine = new TesseractEngine("tessdata", "eng", EngineMode.Default);
				engine = slowEngine;
			}
			try
			{
				// have to load Pix via a bitmap since Pix doesn't support loading a stream.
				using (Pix pix = PixConverter.ToPix(img))
				{
					using (Page page = engine.Process(pix))
					{
						string text = page.GetText();// + "\n\n" + "Mean Confidence: " + page.GetMeanConfidence();
						text = text.Replace("\n", "\r\n");
						return text;
					}
				}
			}
			catch
			{
				if (useFastModel)
				{
					fastEngine.Dispose();
					fastEngine = null;
				}
				else
				{
					slowEngine.Dispose();
					slowEngine = null;
				}
				throw;
			}
		}
		public static void Dispose()
		{
			slowEngine?.Dispose();
			fastEngine?.Dispose();
		}
	}
}
