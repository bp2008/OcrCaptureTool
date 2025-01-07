using BPUtil;
using OcrCaptureTool.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OcrCaptureTool
{
	public partial class MainForm : Form
	{
		bool requestedStop = false;
		BackgroundWorker bw;
		/// <summary>
		/// A static reference to the current MainForm instance.
		/// </summary>
		public static MainForm Current = null;
		public OCRPayload lastPayload = null;
		int lastPort = 0;
		int timeMsBetweenCaptures => (int)Math.Round(1000.0 / NumberUtil.Clamp(Program.settings.targetFPS, 1, 120));

		public MainForm()
		{
			Current = this;
			InitializeComponent();

			AcceptUserSelectedRectangle(Program.settings.captureRegion);
			cbUseFastModel.Checked = Program.settings.fastModel;
			cbPreview.Checked = Program.settings.preview;
			trackBarTargetFPS.Value = Program.settings.targetFPS;
			lblTargetFPS.Text = Program.settings.targetFPS.ToString();
			nudWebPort.Value = Program.settings.webServerPort;

			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.DoWork += Bw_DoWork;
			bw.ProgressChanged += Bw_ProgressChanged;
			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			bw.RunWorkerAsync();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		public class OCRPayload
		{
			public Bitmap bmp;
			public string text;
			public string error;
		}

		private void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				while (!bw.CancellationPending)
				{
					stopwatch.Restart();

					BPUtil.SimpleHttp.HttpServerBase.Binding[] bindings = Program.webServer.GetBindings();
					if (bindings.Length > 0 && bindings[0].Endpoint.Port != 0)
						bw.ReportProgress(bindings[0].Endpoint.Port);

					bool hadError = false;
					if (!Program.settings.captureRegion.IsEmpty)
					{
						try
						{
							if (bw.CancellationPending)
								return;

							OCRPayload payload = new OCRPayload();
							try
							{
								payload.bmp = ScreenCapture.CaptureScreenshotRect(Program.settings.captureRegion);
							}
							catch (Exception ex)
							{
								hadError = true;
								Logger.Debug(ex);
								payload.error = "Screen Capture Error." + Environment.NewLine + ex.ToString();
							}
							try
							{
								if (!hadError)
									payload.text = OCR.GetTextFromImage(payload.bmp, Program.settings.fastModel);
							}
							catch (Exception ex)
							{
								hadError = true;
								Logger.Debug(ex);
								payload.bmp.Dispose();
								payload.bmp = null;
								payload.error = "OCR Error." + Environment.NewLine + ex.ToString();
							}
							bw.ReportProgress(0, payload);
						}
						catch (Exception ex)
						{
							hadError = true;
							Logger.Debug(ex);
							bw.ReportProgress(0, new OCRPayload() { error = ex.ToString() });
						}
					}
					if (hadError)
					{
						CountdownStopwatch countdown = CountdownStopwatch.StartNew(TimeSpan.FromSeconds(1));
						while (!countdown.Finished && !bw.CancellationPending)
							Thread.Sleep((int)Math.Min(countdown.RemainingMilliseconds, 100));
					}
					long remainingMs = timeMsBetweenCaptures-stopwatch.ElapsedMilliseconds;
					while (remainingMs > 0 && !bw.CancellationPending)
					{
						Thread.Sleep((int)Math.Min(remainingMs, 100));
						remainingMs = timeMsBetweenCaptures - stopwatch.ElapsedMilliseconds;
					}
				}
			}
			catch (Exception ex)
			{
				bw.ReportProgress(0, new OCRPayload() { text = "An error occurred. Please restart this program. " + Environment.NewLine + ex.ToString() });
			}
		}

		private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage != 0)
			{
				// This progress report is informing us of the current web server port.
				if (lastPort != e.ProgressPercentage)
				{
					lastPort = e.ProgressPercentage;
					lblWebLink.Text = "http://localhost:" + lastPort + "/GetCurrentTextContent";
				}
				return;
			}
			OCRPayload payload = (OCRPayload)e.UserState;
			lastPayload = payload;
			if (payload.error != null)
			{
				txtOutput.Text = payload.error;
				Image oldImage = pictureBox.Image;
				pictureBox.Image = null;
				if (oldImage != null)
					oldImage.Dispose();
				payload.bmp?.Dispose();
				return;
			}
			else
			{
				if (Program.settings.preview)
				{
					Image oldImage = pictureBox.Image;
					pictureBox.Image = payload.bmp;
					if (oldImage != null)
						oldImage.Dispose();
					txtOutput.Text = payload.text;
				}
				else
				{
					if (txtOutput.Text != "OCR OK")
						txtOutput.Text = "OCR OK";
					payload.bmp?.Dispose();
				}
			}
		}

		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Image oldImage = pictureBox.Image;
			pictureBox.Image = null;
			if (oldImage != null)
				oldImage.Dispose();
			txtOutput.Text = "An error occurred.";
			this.Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!requestedStop)
			{
				requestedStop = true;
				e.Cancel = true;
				bw.CancelAsync();
			}
		}

		public void AcceptUserSelectedRectangle(Rectangle region)
		{
			if (Program.settings.captureRegion != region)
			{
				Program.settings.captureRegion = region;
				Program.settings.Save();
			}
			lblCurrentRegion.Text = "Current Region: " + region.ToString();
		}

		private void btnAddRegion_Click(object sender, EventArgs e)
		{
			SnippingTool.DrawOverlayAcrossAllScreens(this);
		}

		private void cbUseFastModel_CheckedChanged(object sender, EventArgs e)
		{
			if (Program.settings.fastModel != cbUseFastModel.Checked)
			{
				Program.settings.fastModel = cbUseFastModel.Checked;
				Program.settings.Save();
			}
		}
		/// <summary>
		/// Returns the current OCR text or null.
		/// </summary>
		/// <returns></returns>
		public string GetCurrentText()
		{
			return lastPayload?.text;
		}

		private void cbPreview_CheckedChanged(object sender, EventArgs e)
		{
			if (Program.settings.preview != cbPreview.Checked)
			{
				Program.settings.preview = cbPreview.Checked;
				Program.settings.Save();
			}
		}

		private void trackBarTargetFPS_Scroll(object sender, EventArgs e)
		{
			if (Program.settings.targetFPS != trackBarTargetFPS.Value)
			{
				Program.settings.targetFPS = trackBarTargetFPS.Value;
				Program.settings.Save();
				lblTargetFPS.Text = Program.settings.targetFPS.ToString();
			}
		}

		private void nudWebPort_ValueChanged(object sender, EventArgs e)
		{
			if (Program.settings.webServerPort != (int)nudWebPort.Value)
			{
				Program.settings.webServerPort = (int)nudWebPort.Value;
				Program.settings.Save();
				lblWebLink.Text = "Web server is starting...";
				lastPort = 0;
				Program.webServer.SetBindings(Program.settings.webServerPort, Program.settings.webServerPort);
			}
		}

		private void lblWebLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lblWebLink.Text.StartsWith("http"))
				Process.Start(lblWebLink.Text);
		}
	}
}
