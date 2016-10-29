namespace cam_aforge
{
    partial class CamForm
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
            this.components = new System.ComponentModel.Container();
            this.picFrame = new System.Windows.Forms.PictureBox();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbCapability = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.lblinfo = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblRectsize = new System.Windows.Forms.Label();
            this.panPreview = new System.Windows.Forms.Panel();
            this.cbxNormal = new System.Windows.Forms.CheckBox();
            this.cbxReverse = new System.Windows.Forms.CheckBox();
            this.cbxFlip = new System.Windows.Forms.CheckBox();
            this.cbxRotate90 = new System.Windows.Forms.CheckBox();
            this.cbxRotate270 = new System.Windows.Forms.CheckBox();
            this.cbxRotate180 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxQuality = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBackcolor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panPreview.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFrame
            // 
            this.picFrame.BackColor = System.Drawing.Color.Transparent;
            this.picFrame.Location = new System.Drawing.Point(196, 8);
            this.picFrame.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picFrame.Name = "picFrame";
            this.picFrame.Size = new System.Drawing.Size(480, 360);
            this.picFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFrame.TabIndex = 0;
            this.picFrame.TabStop = false;
            this.picFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFrame_MouseDown);
            this.picFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picFrame_MouseMove);
            this.picFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picFrame_MouseUp);
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(12, 24);
            this.cmbSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(167, 20);
            this.cmbSource.TabIndex = 1;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择视频来源";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 97);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(168, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始预览(&A)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.start_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(11, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(168, 40);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(2, 17);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 12);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "就绪..";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 316);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "视频源属性设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DisplayProperty_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 351);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Crossbar属性设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DisplayCrossbarProperty_Click);
            // 
            // cmbCapability
            // 
            this.cmbCapability.FormattingEnabled = true;
            this.cmbCapability.Location = new System.Drawing.Point(12, 61);
            this.cmbCapability.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbCapability.Name = "cmbCapability";
            this.cmbCapability.Size = new System.Drawing.Size(167, 20);
            this.cmbCapability.TabIndex = 9;
            this.cmbCapability.SelectedIndexChanged += new System.EventHandler(this.cmbCapability_SelectedIndexChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(11, 132);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(168, 29);
            this.btnCapture.TabIndex = 10;
            this.btnCapture.Text = "截图(&C)";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // tbxDir
            // 
            this.tbxDir.Location = new System.Drawing.Point(12, 236);
            this.tbxDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(168, 21);
            this.tbxDir.TabIndex = 11;
            this.tbxDir.Text = "C:\\审计图片\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "截图目录";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "截图文件名";
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(12, 279);
            this.tbxFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(168, 21);
            this.tbxFile.TabIndex = 13;
            this.tbxFile.Text = "111.jpg";
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblinfo.ForeColor = System.Drawing.Color.Red;
            this.lblinfo.Location = new System.Drawing.Point(13, 419);
            this.lblinfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(65, 17);
            this.lblinfo.TabIndex = 15;
            this.lblinfo.Text = "等待截图...";
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Transparent;
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(160, 120);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 16;
            this.picPreview.TabStop = false;
            this.picPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseDown);
            this.picPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseMove);
            this.picPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseUp);
            // 
            // lblRectsize
            // 
            this.lblRectsize.AutoSize = true;
            this.lblRectsize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRectsize.ForeColor = System.Drawing.Color.Red;
            this.lblRectsize.Location = new System.Drawing.Point(203, 341);
            this.lblRectsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRectsize.Name = "lblRectsize";
            this.lblRectsize.Size = new System.Drawing.Size(56, 17);
            this.lblRectsize.TabIndex = 17;
            this.lblRectsize.Text = "截图尺寸";
            // 
            // panPreview
            // 
            this.panPreview.Controls.Add(this.picPreview);
            this.panPreview.Location = new System.Drawing.Point(314, 74);
            this.panPreview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(160, 120);
            this.panPreview.TabIndex = 18;
            this.panPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panPreview_Paint);
            this.panPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panPreview_MouseDown);
            this.panPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panPreview_MouseMove);
            this.panPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panPreview_MouseUp);
            // 
            // cbxNormal
            // 
            this.cbxNormal.AutoSize = true;
            this.cbxNormal.Location = new System.Drawing.Point(196, 373);
            this.cbxNormal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxNormal.Name = "cbxNormal";
            this.cbxNormal.Size = new System.Drawing.Size(120, 16);
            this.cbxNormal.TabIndex = 19;
            this.cbxNormal.Text = "正常截图（重置）";
            this.cbxNormal.UseVisualStyleBackColor = true;
            this.cbxNormal.CheckedChanged += new System.EventHandler(this.cbxNormal_CheckedChanged);
            // 
            // cbxReverse
            // 
            this.cbxReverse.AutoSize = true;
            this.cbxReverse.Location = new System.Drawing.Point(7, 13);
            this.cbxReverse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxReverse.Name = "cbxReverse";
            this.cbxReverse.Size = new System.Drawing.Size(48, 16);
            this.cbxReverse.TabIndex = 20;
            this.cbxReverse.Text = "镜像";
            this.cbxReverse.UseVisualStyleBackColor = true;
            this.cbxReverse.CheckedChanged += new System.EventHandler(this.cbxReverse_CheckedChanged);
            // 
            // cbxFlip
            // 
            this.cbxFlip.AutoSize = true;
            this.cbxFlip.Location = new System.Drawing.Point(7, 30);
            this.cbxFlip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxFlip.Name = "cbxFlip";
            this.cbxFlip.Size = new System.Drawing.Size(48, 16);
            this.cbxFlip.TabIndex = 21;
            this.cbxFlip.Text = "翻转";
            this.cbxFlip.UseVisualStyleBackColor = true;
            this.cbxFlip.CheckedChanged += new System.EventHandler(this.cbxFlip_CheckedChanged);
            // 
            // cbxRotate90
            // 
            this.cbxRotate90.AutoSize = true;
            this.cbxRotate90.Location = new System.Drawing.Point(71, 13);
            this.cbxRotate90.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxRotate90.Name = "cbxRotate90";
            this.cbxRotate90.Size = new System.Drawing.Size(108, 16);
            this.cbxRotate90.TabIndex = 22;
            this.cbxRotate90.Text = "顺时针旋转90度";
            this.cbxRotate90.UseVisualStyleBackColor = true;
            this.cbxRotate90.CheckedChanged += new System.EventHandler(this.cbxRotate90_CheckedChanged);
            // 
            // cbxRotate270
            // 
            this.cbxRotate270.AutoSize = true;
            this.cbxRotate270.Location = new System.Drawing.Point(71, 30);
            this.cbxRotate270.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxRotate270.Name = "cbxRotate270";
            this.cbxRotate270.Size = new System.Drawing.Size(108, 16);
            this.cbxRotate270.TabIndex = 23;
            this.cbxRotate270.Text = "逆时针旋转90度";
            this.cbxRotate270.UseVisualStyleBackColor = true;
            this.cbxRotate270.CheckedChanged += new System.EventHandler(this.cbxRotate270_CheckedChanged);
            // 
            // cbxRotate180
            // 
            this.cbxRotate180.AutoSize = true;
            this.cbxRotate180.Location = new System.Drawing.Point(185, 13);
            this.cbxRotate180.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxRotate180.Name = "cbxRotate180";
            this.cbxRotate180.Size = new System.Drawing.Size(78, 16);
            this.cbxRotate180.TabIndex = 24;
            this.cbxRotate180.Text = "旋转180度";
            this.cbxRotate180.UseVisualStyleBackColor = true;
            this.cbxRotate180.CheckedChanged += new System.EventHandler(this.cbxRotate180_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxReverse);
            this.groupBox2.Controls.Add(this.cbxRotate180);
            this.groupBox2.Controls.Add(this.cbxFlip);
            this.groupBox2.Controls.Add(this.cbxRotate270);
            this.groupBox2.Controls.Add(this.cbxRotate90);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(405, 365);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(270, 50);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // tbxQuality
            // 
            this.tbxQuality.Location = new System.Drawing.Point(271, 392);
            this.tbxQuality.MaxLength = 3;
            this.tbxQuality.Name = "tbxQuality";
            this.tbxQuality.Size = new System.Drawing.Size(27, 21);
            this.tbxQuality.TabIndex = 26;
            this.tbxQuality.Text = "90";
            this.tbxQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxQuality_KeyPress);
            this.tbxQuality.Leave += new System.EventHandler(this.tbxQuality_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 395);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "JPG压缩质量";
            // 
            // cbxBackcolor
            // 
            this.cbxBackcolor.FormattingEnabled = true;
            this.cbxBackcolor.Location = new System.Drawing.Point(338, 393);
            this.cbxBackcolor.Name = "cbxBackcolor";
            this.cbxBackcolor.Size = new System.Drawing.Size(51, 20);
            this.cbxBackcolor.TabIndex = 27;
            this.cbxBackcolor.SelectedIndexChanged += new System.EventHandler(this.cbxBackcolor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 374);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "截图背景色";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(100, 211);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(78, 22);
            this.btnPath.TabIndex = 29;
            this.btnPath.Text = "选择目录";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // CamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 442);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxBackcolor);
            this.Controls.Add(this.tbxQuality);
            this.Controls.Add(this.cbxNormal);
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.lblRectsize);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.cmbCapability);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.picFrame);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "CamForm";
            this.Text = "视频截图 v1.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panPreview.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFrame;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbCapability;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblRectsize;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.CheckBox cbxNormal;
        private System.Windows.Forms.CheckBox cbxReverse;
        private System.Windows.Forms.CheckBox cbxFlip;
        private System.Windows.Forms.CheckBox cbxRotate90;
        private System.Windows.Forms.CheckBox cbxRotate270;
        private System.Windows.Forms.CheckBox cbxRotate180;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBackcolor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPath;
    }
}

