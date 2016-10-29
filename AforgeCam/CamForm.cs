using System;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace cam_aforge
{
    public partial class CamForm : Form
    {
        #region ˽������
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;

        private int frmWidth ;
        private bool isFrameCapture = false;      //������ͼ
        private bool isbusy = false;
        private bool MenuAccessKeysAreAlwaysUnderlined;

        //picPreview��λ��
        private bool _isPressed = false;
        private Point _position = new Point(0, 0);
        private Point _startposition = new Point(0, 0);

        //��¼�����ק��С
        private int StartX = 0;
        private int StartY = 0;
        private int EndX = 0;
        private int EndY = 0;

        //��¼��ͼ
        private Bitmap originalBitmap = null;
        private Bitmap modifiedBitmap = null;
        #endregion ˽������

        //http://msdn.microsoft.com/en-us/library/ms724947.aspx
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfoRefBool(int uiAction, int uiParam, ref bool pvParam, int fWinIni);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfoBool(int uiAction, int uiParam, bool pvParam, int fWinIni);
        private const int SPI_GETKEYBOARDCUES = 0x100A;
        private const int SPI_SETKEYBOARDCUES = 0x100B;
        private bool isDragRect = false;

        #region ���캯��
        public CamForm()
        {
            InitializeComponent();
            frmWidth = this.Width;
            this.Width = 210;
            //Sets the underlining of menu access key letters. 
            //The pvParam parameter is a BOOL variable. 
            //Set pvParam to TRUE to always underline menu access keys, 
            //or FALSE to underline menu access keys only when the menu is activated from the keyboard.
            //���ð�ť��ݼ��»��ߵ���ʾ��ʽ
            SystemParametersInfoRefBool(SPI_GETKEYBOARDCUES, 0, ref MenuAccessKeysAreAlwaysUnderlined, 0);
            SystemParametersInfoBool(SPI_SETKEYBOARDCUES, 0, true, 0);
        }
        #endregion ���캯��

        #region ��ʼ������
        private void Form1_Load(object sender, EventArgs e)
        {
            InitCamList();
            this.btnCapture.Enabled = false;
            this.lblinfo.Visible = false;
            this.picPreview.Visible = false;
            btnStart.Text = "��ʼ��Ƶ(&A)";
            lblRectsize.Text = "";
            lblRectsize.Parent = this.picFrame;
            lblRectsize.BackColor = Color.FromArgb(65, 204, 212, 230);  //������͸��
            //lblRectsize.Location = new Point(0, this.picFrame.Height-20);
            panPreview.Parent = this.picFrame;
            panPreview.Location = new Point(0, this.picFrame.Height - panPreview.Height-1);
            cbxBackcolor.Items.Add(new ComboBoxItem("����", Color.FromArgb(65, 204, 212, 230)));
            cbxBackcolor.Items.Add(new ComboBoxItem("����", Color.FromArgb(65, 204, 212, 130)));
            cbxBackcolor.Items.Add(new ComboBoxItem("����", Color.FromArgb(65, 104, 112, 230)));
            cbxBackcolor.Items.Add(new ComboBoxItem("����", Color.FromArgb(65, 104, 212, 130)));            
            cbxBackcolor.AllowDrop = true;
            cbxBackcolor.SelectedIndex = 0;
        }
        #endregion ��ʼ������

        #region ��Ƶ�ɼ�����
        /// <summary>
        /// �г�ȫ����Ƶ�豸
        /// </summary>
        /// <returns></returns>
        private void InitCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cmbSource.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cmbSource.Items.Add(device.Name);
                }
                cmbSource.SelectedIndex = 0;
                lblStatus.Text = "��Ƶ�豸���ɹ�...";
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cmbSource.Items.Clear();
                lblStatus.Text = "����:û�м�⵽��Ƶ�豸!";
            }
        }

        /// <summary>
        /// ����ɼ���NewFrame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isbusy) return;
            isbusy = true;
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            try
            {
                if (isFrameCapture)
                {
                    picFrame.Image = (Image)img;
                    isFrameCapture = false;
                    try
                    {
                        //ί�б�����̼�ؼ����ܷ���
                        Invoke(new MethodInvoker(delegate()
                        {
                            string fullname = GetFullname();
                            
                            if ((EndX - StartX) != 0)
                            {
                                double scaleX = (videoSource.VideoResolution.FrameSize.Width / (double)this.picFrame.Width);
                                double scaleY = (videoSource.VideoResolution.FrameSize.Height / (double)this.picFrame.Height);
                                int x = StartX > EndX ? (int)(EndX * scaleX) : (int)(StartX * scaleX);
                                int y = StartY > EndY ? (int)(EndY * scaleY) : (int)(StartY * scaleY);
                                int w = Math.Abs((int)((EndX - StartX) * scaleX));
                                int h = Math.Abs((int)((EndY - StartY) * scaleY));
                                img = CutImage(img, x, y, w, h);
                            }
                            //������ͼ��ԭʼ����
                            originalBitmap = (Bitmap)img.Clone();
                            //׼���޸ĵ�����
                            modifiedBitmap = (Bitmap)img.Clone();

                            if (!cbxNormal.Checked)
                            {
                                if (cbxReverse.Checked) modifiedBitmap = BitmapManipulator.ReverseBitmap(modifiedBitmap);
                                if (cbxFlip.Checked) modifiedBitmap = BitmapManipulator.FlipBitmap(modifiedBitmap);
                                if (cbxRotate90.Checked) modifiedBitmap = BitmapManipulator.RotateBitmapRight90(modifiedBitmap);
                                if (cbxRotate180.Checked) modifiedBitmap = BitmapManipulator.RotateBitmapRight180(modifiedBitmap);
                                if (cbxRotate270.Checked) modifiedBitmap = BitmapManipulator.RotateBitmapRight270(modifiedBitmap);
                            }
                            int qty = int.Parse(this.tbxQuality.Text);
                            SaveAndLoadCaptureBmp(modifiedBitmap,qty, fullname);
                        }));
                    }
                    catch (Exception ex)
                    {
                        this.lblinfo.Text = ex.Message;
                    }
                }
                else
                {
                    //������
                    if ((EndX - StartX) != 0)
                    {
                        Graphics g = Graphics.FromImage(img);
                        Brush brush = new SolidBrush(Color.Red);
                        Pen pen = new Pen(brush, 1);
                        pen.DashStyle = DashStyle.Solid;
                        double scaleX = (videoSource.VideoResolution.FrameSize.Width / (double)this.picFrame.Width);
                        double scaleY = (videoSource.VideoResolution.FrameSize.Height / (double)this.picFrame.Height);
                        g.DrawRectangle(pen, new Rectangle(StartX > EndX ? (int)(EndX * scaleX) : (int)(StartX * scaleX),
                                                           StartY > EndY ? (int)(EndY * scaleY) : (int)(StartY * scaleY),
                                                           Math.Abs((int)((EndX - StartX) * scaleX)),
                                                           Math.Abs((int)((EndY - StartY) * scaleY))
                                                           ));
                        Invoke(new MethodInvoker(delegate()
                        {
                            lblRectsize.Text = "��ͼ�ߴ磺" + Math.Abs((int)((EndX - StartX) * scaleX)).ToString() + " X " 
                                                            + Math.Abs((int)((EndY - StartY) * scaleY)).ToString();
                        }));
                        pen.Dispose();
                        brush.Dispose();
                        g.Dispose();
                    }
                    else
                    {
                        Invoke(new MethodInvoker(delegate()
                        {
                            lblRectsize.Text = "";
                        }));
                    }
                    picFrame.Image = img;
                }
            }
            catch (Exception ex)
            {
                this.lblinfo.Text = ex.Message;
            }
            finally
            {
                isbusy = false;
            }
        }
        /// <summary>
        /// �ر���Ƶ�豸
        /// </summary>
        /// <returns></returns>
        private void CloseVideoSource()
        {
            if ((EndX - StartX) != 0)
            {
                isDragRect = false;
                StartX = 0;
                StartY = 0;
                EndX = 0;
                EndY = 0;
                lblRectsize.Text = "";
            }
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    this.timer1.Enabled = false;
                    Invoke(new MethodInvoker(delegate()
                    {
                        lblStatus.Text = "����ֹͣ����ͷ...";
                        groupBox1.Refresh();
                    }));
                    //��ж��NewFrame�¼������ܻᵼ��stop����������
                    videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                    //Invoke(new MethodInvoker(delegate()
                    //{
                    //    Console.Beep(1000, 200);
                    //}));

                    if (this.picFrame.Image != null)
                    {
                        this.picFrame.Image.Dispose();
                        this.picFrame.Image = null;
                    }
                    if (this.picPreview.Image != null)
                    {
                        this.picPreview.Image.Dispose();
                        this.picPreview.Image = null;
                    }
                }
            }
        }

        private void videoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            lblStatus.Text = "VideoSourceError: " + eventArgs.Description;
            CloseVideoSource();
        }
        #endregion ��Ƶ�ɼ�����

        #region ͼƬ����
        /// <summary>
        /// ͼƬ�����jpg
        /// </summary>
        /// <param name="modifyBitmap">Ҫ�����bmp</param>
        /// <param name="fullname">�����·����</param>
        /// <returns></returns>
        private void SaveAndLoadCaptureBmp(Bitmap modifyBitmap,int querty, string fullname)
        {
            if (this.picPreview.Image != null)
            {
                this.picPreview.Image.Dispose();  //Image.FromFile�������ļ���=nullҲ�����ͷš�
                this.picPreview.Image = null;
            }
            if (BmpSaveAsJPEG(modifyBitmap, fullname, querty))
            {
                this.lblinfo.Text = "�ļ�����ɹ���" + fullname + "  ---->  ��ͼʱ�䣺" + DateTime.Now;
                this.picPreview.Image = System.Drawing.Image.FromFile(fullname);
            }
            else
            {
                this.lblinfo.Text = "�ļ�����ʧ��,�����ļ����Ƿ�Ϸ���" + fullname;
                this.picPreview.Image = null;
            }
        }
        /// <summary>
        /// ����ΪJPEG��ʽ��֧��ѹ������ѡ��
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="FileName"></param>
        /// <param name="Qty"></param>
        /// <returns></returns>
        public static bool BmpSaveAsJPEG(Bitmap bmp, string FileName, int Qty)
        {
            try
            {
                EncoderParameter p;
                EncoderParameters ps;

                ps = new EncoderParameters(1);

                p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Qty);
                ps.Param[0] = p;

                bmp.Save(FileName, GetCodecInfo("image/jpeg"), ps);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// ����JPGʱ��
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns>�õ�ָ��mimeType��ImageCodecInfo</returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        /// <param name="path_source">ԭʼͼƬ·��</param>
        /// <param name="path_save">Ŀ��ͼƬ·��</param>
        /// <param name="x">����λ�õ����Ͻ�x����</param>
        /// <param name="y">����λ�õ����Ͻ�y����</param>
        /// <param name="width">Ҫ���еĿ��</param>
        /// <param name="height">Ҫ���еĸ߶�</param>
        public Bitmap CutImage(Bitmap bmp, int x, int y, int width, int height)
        {
            //���ص�ͼ
            Image img = (Image)bmp;
            int w = img.Width;
            int h = img.Height;
            //���û���
            width = width >= w ? w : width;
            height = height >= h ? h : height;
            Bitmap newimg = new Bitmap(width, height);
            //��ͼ
            Graphics g = Graphics.FromImage(newimg);
            g.DrawImage(img, 0, 0, new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            //����
            g.Dispose();
            return newimg;
        }
        #endregion ͼƬ����

        #region �ؼ�����
        private string GetFullname()
        {
            string PathName = this.tbxDir.Text;
            if (!PathName.EndsWith(@"\")) PathName += @"\";
            DirectoryInfo TheFolder = new DirectoryInfo(PathName);
            if (!TheFolder.Exists)
            {
                Directory.CreateDirectory(PathName);
            }
            string fullname = PathName + this.tbxFile.Text;
            if (!fullname.ToUpper().EndsWith(".JPG"))
            {
                fullname += ".jpg";
            }
            return fullname;
        }

        /// <summary>
        /// ���¿�ʼ��ť����ʾ��Ƶ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void start_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Contains("��ʼ"))
            {
                if (DeviceExist)
                {
                    this.btnCapture.Enabled = true;
                    this.lblinfo.Visible = true;
                    this.picPreview.Visible = true;
                    if (videoSource == null)
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[cmbSource.SelectedIndex].MonikerString);
                        cmbCapability_SelectedIndexChanged(sender, e);
                    }
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.VideoSourceError += new VideoSourceErrorEventHandler(videoSource_VideoSourceError);
                    CloseVideoSource();

                    videoSource.Start();
                    lblStatus.Text = "��Ƶ�豸������...";
                    btnStart.Text = "ֹͣ��Ƶ(&S)";
                    timer1.Enabled = true;
                    this.cmbCapability.Enabled = false;
                    this.cmbSource.Enabled = false;
                    this.Width = frmWidth;
                    this.lblinfo.Text = "����Alt-C��ͼ...";
                }
                else
                {
                    lblStatus.Text = "����:û�м�⵽��Ƶ�豸.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    lblStatus.Text = "��Ƶ�豸��ֹͣ.";
                    btnStart.Text = "��ʼ��Ƶ(&A)";
                    this.cmbCapability.Enabled = true;
                    this.cmbSource.Enabled = true;
                    this.btnCapture.Enabled = false;
                    this.lblinfo.Visible = false;
                    this.picPreview.Visible = false;
                }
                this.Width = 210;
            }
            this.btnCapture.Focus();
        }

        /// <summary>
        /// ��ʾ��Ƶ�豸��֡��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "��Ƶ�豸������... " + videoSource.FramesReceived.ToString() + " FPS";
        }

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                if (videoSource.IsRunning)
                {
                    CloseVideoSource();                    
                }
            }));
            SystemParametersInfoBool(SPI_SETKEYBOARDCUES, 0, MenuAccessKeysAreAlwaysUnderlined, 0);
        }

        /// <summary>
        /// ������ƵԴ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void DisplayProperty_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.DisplayPropertyPage(this.Handle);
            }
        }

        /// <summary>
        /// ����Crossbar����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void DisplayCrossbarProperty_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                if (videoSource.CheckIfCrossbarAvailable())
                    videoSource.DisplayCrossbarPropertyPage(this.Handle);
                else
                {
                    MessageBox.Show("Crossbar property page is not available.");
                }
            }
        }

        /// <summary>
        /// �л���Ƶ�豸����ʼ��֧�ֱַ��ʵ��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSource.SelectedIndex >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbSource.SelectedIndex].MonikerString);
                if (!videoSource.CheckIfCrossbarAvailable()) this.button2.Enabled = false;
                //����ͷ������
                VideoCapabilities[] vc = videoSource.VideoCapabilities;
                //ͨ��VideoCapabilities���Եõ�ȫ��������Ȼ������ж����÷ֱ���
                this.cmbCapability.Items.Clear();
                for (int i = 0; i < vc.Length; i++)
                {
                    VideoCapabilitiesItem item = new VideoCapabilitiesItem(vc[i]);
                    this.cmbCapability.Items.Add(item);
                }
                this.cmbCapability.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// �ı�ɼ��ֱ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void cmbCapability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCapability.SelectedItem != null)
            {
                if (videoSource != null)
                {
                    VideoCapabilitiesItem item = cmbCapability.SelectedItem as VideoCapabilitiesItem;
                    videoSource.VideoResolution = item.VideoCapability;
                }
            }
        }
        /// <summary>
        /// ���²���ͼƬ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnCapture_Click(object sender, EventArgs e)
        {
            isFrameCapture = true;
        }

        private void tbxQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 && e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == 13)
            {
                if (tbxQuality.Text.Length > 0)
                {
                    int qty = int.Parse(tbxQuality.Text);
                    if (qty < 70) tbxQuality.Text = "70";
                    if (qty > 100) tbxQuality.Text = "100";
                }
                else
                {
                    tbxQuality.Text = "90";
                }
                e.Handled = true;
            }
        }

        private void tbxQuality_Leave(object sender, EventArgs e)
        {
            if (tbxQuality.Text.Length > 0)
            {
                int qty = int.Parse(tbxQuality.Text);
                if (qty < 70) tbxQuality.Text = "70";
                if (qty > 100) tbxQuality.Text = "100";
            }
            else
            {
                tbxQuality.Text = "90";
            }
        }
        #endregion �ؼ�����

        #region �����ק����
        private void picFrame_MouseDown(object sender, MouseEventArgs e)
        {
            //������껭����
            if (isDragRect)
            {
                isDragRect = false;
                StartX = 0;
                StartY = 0;
                EndX = 0;
                EndY = 0;
                lblRectsize.Text = "";
            }
            else
            {                
                isDragRect = true;
                StartX = e.X;
                StartY = e.Y;
                EndX = StartX;
                EndY = StartY;
            }
        }
        private void picFrame_MouseUp(object sender, MouseEventArgs e)
        {
            isDragRect = false;
            if ((EndX-StartX)!=0) btnCapture_Click(sender, e);
        }
        private void picFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragRect)
            {
                EndX = e.X ;
                EndY = e.Y ;
                if (EndX > this.picFrame.Size.Width-1) EndX = this.picFrame.Size.Width-1;
                if (EndY > this.picFrame.Size.Height-1) EndY = this.picFrame.Size.Height-1;
                if (EndX < 1) EndX = 1;
                if (EndY < 1) EndY = 1;
            }
        }
        #endregion �����ק����

        #region ��ͼԤ������
        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = picPreview.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            //g.Clear(this.BackColor);
            g.DrawRectangle(pen, picPreview.ClientRectangle.X, picPreview.ClientRectangle.Y,
                            e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            g.Dispose();
        }
        //pan���߿�
        private void panPreview_Paint(object sender, PaintEventArgs e)
        {
            return;
            /*
            Rectangle rect = this.panPreview.ClientRectangle;
            ControlPaint.DrawBorder(e.Graphics,
                                rect,
                                Color.Red,
                                1,        //left                                 
                                ButtonBorderStyle.Dotted,
                                Color.Red,         //top
                                1,
                                ButtonBorderStyle.Dotted,
                                Color.Red,        //right
                                1,
                                ButtonBorderStyle.Dotted,
                                Color.Red,        //bottom
                                1,
                                ButtonBorderStyle.Dotted);
            */
        }

        private void panPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if (_isPressed)
                {
                    //this.Cursor = Cursors.SizeAll;
                    _position.X = this.panPreview.Location.X + e.X - _startposition.X;
                    _position.Y = this.panPreview.Location.Y + e.Y - _startposition.Y;
                    if (_position.X < 1) _position.X = 1;
                    if (_position.X > this.panPreview.Parent.Width - this.panPreview.Width - 1)
                    {
                        _position.X = this.panPreview.Parent.Width - this.panPreview.Width - 1;
                    }
                    if (_position.Y < 1) _position.Y = 1;
                    if (_position.Y > this.panPreview.Parent.Height - panPreview.Height - 1)
                    {
                        _position.Y = this.panPreview.Parent.Height - panPreview.Height - 1;
                    }
                    this.panPreview.Location = _position;
                }
            }
        }

        private void panPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Default;
                _isPressed = false;
            }
        }

        private void panPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                _isPressed = true;
                _startposition = new Point(e.X, e.Y);
            }
        }

        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            panPreview_MouseDown(sender, e);
        }

        private void picPreview_MouseMove(object sender, MouseEventArgs e)
        {
            panPreview_MouseMove(sender, e);
        }

        private void picPreview_MouseUp(object sender, MouseEventArgs e)
        {
            panPreview_MouseUp(sender, e);
        }
        #endregion ��ͼԤ������

        #region ���ط���
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion ���ط���

        #region CheckBox��ť
        private void cbxNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNormal.Checked)
            {
                cbxReverse.Checked = false;
                cbxFlip.Checked = false;
                cbxRotate90.Checked = false;
                cbxRotate180.Checked = false;
                cbxRotate270.Checked = false;

                string fullname = GetFullname();
                if (originalBitmap != null)
                {
                    int qty = int.Parse(this.tbxQuality.Text);
                    SaveAndLoadCaptureBmp(modifiedBitmap, qty, fullname);
                }
            }
            this.btnCapture.Focus();
        }

        private void cbxReverse_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxReverse.Checked)
            {
                cbxNormal.Checked = false;
            }
            this.btnCapture.Focus();
        }

        private void cbxFlip_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFlip.Checked)
            {
                cbxNormal.Checked = false;
            }
            this.btnCapture.Focus();
        }

        private void cbxRotate90_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRotate90.Checked)
            {
                cbxNormal.Checked = false;
                cbxRotate180.Checked = false;
                cbxRotate270.Checked = false;
            }
            this.btnCapture.Focus();
        }

        private void cbxRotate270_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRotate270.Checked)
            {
                cbxNormal.Checked = false;
                cbxRotate90.Checked = false;
                cbxRotate180.Checked = false;
            }
        }

        private void cbxRotate180_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRotate180.Checked)
            {
                cbxNormal.Checked = false;
                cbxRotate90.Checked = false;
                cbxRotate270.Checked = false;
            }
            this.btnCapture.Focus();
        }
        #endregion CheckBox��ť

        private void cbxBackcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBackcolor.SelectedItem != null)
            {
                ComboBoxItem item = cbxBackcolor.SelectedItem as ComboBoxItem;
                panPreview.BackColor = item.Color;
            }
            this.btnCapture.Focus();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath.Length > 0)
            {
                tbxDir.Text = fbd.SelectedPath + Path.DirectorySeparatorChar;
            }
        }

    }

    #region ListBox��Item����
    /// <summary>
    /// ListBox��item��
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public class VideoCapabilitiesItem
    {
        private VideoCapabilities _capability;
        public VideoCapabilities VideoCapability
        {
            get { return this._capability; }
            set { this._capability = value; }
        }
        public VideoCapabilitiesItem(VideoCapabilities vc)
        {
            _capability = vc;
        }
        public override string ToString()
        {
            return VideoCapability.FrameSize.Width.ToString() +
                   " x " +
                   VideoCapability.FrameSize.Height.ToString() +
                   "   " +
                   VideoCapability.BitCount.ToString() +
                   "λ";
        }
    }
    #endregion ListBox��Item����

    #region ComboBox��Item����
    public class ComboBoxItem  
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public ComboBoxItem(string text, Color color)
        {
            Text = text;
            Color = color;
        }
        public override string ToString()
        {
            return Text;
        }
    }
    #endregion ComboBox��Item����
}