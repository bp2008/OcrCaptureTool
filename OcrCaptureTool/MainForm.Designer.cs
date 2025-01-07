namespace OcrCaptureTool
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btnAddRegion = new System.Windows.Forms.Button();
			this.lblCurrentRegion = new System.Windows.Forms.Label();
			this.cbUseFastModel = new System.Windows.Forms.CheckBox();
			this.cbPreview = new System.Windows.Forms.CheckBox();
			this.lblWebLink = new System.Windows.Forms.LinkLabel();
			this.trackBarTargetFPS = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTargetFPS = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudWebPort = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTargetFPS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWebPort)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.Location = new System.Drawing.Point(388, 137);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(400, 301);
			this.txtOutput.TabIndex = 0;
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox.Location = new System.Drawing.Point(12, 137);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(370, 301);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 1;
			this.pictureBox.TabStop = false;
			// 
			// btnAddRegion
			// 
			this.btnAddRegion.Location = new System.Drawing.Point(12, 12);
			this.btnAddRegion.Name = "btnAddRegion";
			this.btnAddRegion.Size = new System.Drawing.Size(189, 47);
			this.btnAddRegion.TabIndex = 2;
			this.btnAddRegion.Text = "Select Region To Capture";
			this.btnAddRegion.UseVisualStyleBackColor = true;
			this.btnAddRegion.Click += new System.EventHandler(this.btnAddRegion_Click);
			// 
			// lblCurrentRegion
			// 
			this.lblCurrentRegion.AutoSize = true;
			this.lblCurrentRegion.Location = new System.Drawing.Point(207, 29);
			this.lblCurrentRegion.Name = "lblCurrentRegion";
			this.lblCurrentRegion.Size = new System.Drawing.Size(93, 13);
			this.lblCurrentRegion.TabIndex = 3;
			this.lblCurrentRegion.Text = "Current Region: ...";
			// 
			// cbUseFastModel
			// 
			this.cbUseFastModel.AutoSize = true;
			this.cbUseFastModel.Checked = true;
			this.cbUseFastModel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseFastModel.Location = new System.Drawing.Point(12, 65);
			this.cbUseFastModel.Name = "cbUseFastModel";
			this.cbUseFastModel.Size = new System.Drawing.Size(197, 17);
			this.cbUseFastModel.TabIndex = 4;
			this.cbUseFastModel.Text = "Use Fast OCR model (less accurate)";
			this.cbUseFastModel.UseVisualStyleBackColor = true;
			this.cbUseFastModel.CheckedChanged += new System.EventHandler(this.cbUseFastModel_CheckedChanged);
			// 
			// cbPreview
			// 
			this.cbPreview.AutoSize = true;
			this.cbPreview.Checked = true;
			this.cbPreview.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPreview.Location = new System.Drawing.Point(12, 88);
			this.cbPreview.Name = "cbPreview";
			this.cbPreview.Size = new System.Drawing.Size(182, 17);
			this.cbPreview.TabIndex = 5;
			this.cbPreview.Text = "Preview Captured Region Below:";
			this.cbPreview.UseVisualStyleBackColor = true;
			this.cbPreview.CheckedChanged += new System.EventHandler(this.cbPreview_CheckedChanged);
			// 
			// lblWebLink
			// 
			this.lblWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWebLink.Location = new System.Drawing.Point(210, 9);
			this.lblWebLink.Name = "lblWebLink";
			this.lblWebLink.Size = new System.Drawing.Size(578, 13);
			this.lblWebLink.TabIndex = 6;
			this.lblWebLink.TabStop = true;
			this.lblWebLink.Text = "Web server is starting...";
			this.lblWebLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblWebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWebLink_LinkClicked);
			// 
			// trackBarTargetFPS
			// 
			this.trackBarTargetFPS.Location = new System.Drawing.Point(238, 86);
			this.trackBarTargetFPS.Maximum = 30;
			this.trackBarTargetFPS.Minimum = 1;
			this.trackBarTargetFPS.Name = "trackBarTargetFPS";
			this.trackBarTargetFPS.Size = new System.Drawing.Size(246, 45);
			this.trackBarTargetFPS.TabIndex = 7;
			this.trackBarTargetFPS.Value = 15;
			this.trackBarTargetFPS.Scroll += new System.EventHandler(this.trackBarTargetFPS_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(244, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Target FPS:";
			// 
			// lblTargetFPS
			// 
			this.lblTargetFPS.AutoSize = true;
			this.lblTargetFPS.Location = new System.Drawing.Point(314, 66);
			this.lblTargetFPS.Name = "lblTargetFPS";
			this.lblTargetFPS.Size = new System.Drawing.Size(19, 13);
			this.lblTargetFPS.TabIndex = 9;
			this.lblTargetFPS.Text = "15";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(507, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Web Server Port Number:";
			// 
			// nudWebPort
			// 
			this.nudWebPort.Location = new System.Drawing.Point(642, 67);
			this.nudWebPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudWebPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWebPort.Name = "nudWebPort";
			this.nudWebPort.Size = new System.Drawing.Size(79, 20);
			this.nudWebPort.TabIndex = 11;
			this.nudWebPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWebPort.ValueChanged += new System.EventHandler(this.nudWebPort_ValueChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.nudWebPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblTargetFPS);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBarTargetFPS);
			this.Controls.Add(this.lblWebLink);
			this.Controls.Add(this.cbPreview);
			this.Controls.Add(this.cbUseFastModel);
			this.Controls.Add(this.lblCurrentRegion);
			this.Controls.Add(this.btnAddRegion);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.txtOutput);
			this.Name = "MainForm";
			this.Text = "OCR Capture Tool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTargetFPS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWebPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button btnAddRegion;
		private System.Windows.Forms.Label lblCurrentRegion;
		private System.Windows.Forms.CheckBox cbUseFastModel;
		private System.Windows.Forms.CheckBox cbPreview;
		private System.Windows.Forms.LinkLabel lblWebLink;
		private System.Windows.Forms.TrackBar trackBarTargetFPS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTargetFPS;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudWebPort;
	}
}

