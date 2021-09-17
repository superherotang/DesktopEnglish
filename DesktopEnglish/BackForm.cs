using DesktopEnglish.entity;
using DesktopEnglish.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEnglish
{
    public partial class BackForm : Form
    {

        private Point loc1;
        private Point loc2;
        private MainForm childForm;//此为副窗体
        private string configFilePath;
        private string routineFilePath;
        private string path;
        private string words;
        public string ukMp3 = "";
        public string usMp3 = "";
        WMPLib.WindowsMediaPlayer wmp;
        public BackForm()
        {
            InitializeComponent();

            wmp = new WMPLib.WindowsMediaPlayer();


            this.ShowInTaskbar = false;
            toolStripSeparator1.Enabled = false;
            configFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.dat");
            routineFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "routine.dat");
            this.ContextMenuStrip = contextMenuStrip1;
            Init();
            //字体背景

            //背景读取
            Hashtable para = new Hashtable();
            object obj = EncryptUtilSeal.DecryptObject(routineFilePath);
            para = obj as Hashtable;

            this.Opacity = Convert.ToDouble(para["opacity"].ToString()); // 窗体透明度
            this.BackColor = ColorTranslator.FromHtml(para["backColor"].ToString());
            this.childForm = new MainForm(this);
            loc1 = childForm.Location;
            loc2 = this.Location;
            this.childForm.Owner = this;    // 这支所属窗体              
            this.childForm.Dock = DockStyle.Fill;
            //右下角
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - base.Height - 40);

            childForm.LocationChanged += (s, ee) =>
            {
                var c = childForm.Location;
                this.Location = new Point(loc2.X + c.X - loc1.X, loc2.Y + c.Y - loc1.Y);
            };
            childForm.SizeChanged += (s, ee) =>
            {
                var c = childForm.Size;
                this.Size = c;
            };
            childForm.ContextMenuStrip = contextMenuStrip1;
            this.childForm.Show();

            this.childForm.BringToFront();
            //childForm.Location = new Point(this.Location.X, this.Location.Y);
            this.childForm.Size = new Size(this.Size.Width, this.Height);
            mouseControl();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            UpdateStyles();
        }



        private void Init()
        {
            path = Application.StartupPath + "\\words\\";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.txt");
            for (int i = 0; i < files.Length; i++)
            {

                //ToolStripItem item = new ToolStripMenuItem();
                ToolStripMenuItem item = new ToolStripMenuItem();
                String formatName = files[i].Name.Replace(".txt", "");
                item.Text = formatName;
                item.Name = "item" + i;
                contextMenuStrip1.Items.Add(item);
            }

            if (!File.Exists(routineFilePath))
            {
                Routine.initRoutineSetting();
            }

            if (File.Exists(configFilePath))
            {
                //读取
                Hashtable para = new Hashtable();
                object obj = EncryptUtilSeal.DecryptObject(configFilePath);
                para = obj as Hashtable;
                string txtChecked = para["txtChecked"].ToString();
                bool txtYes = CheckedItem(txtChecked);
                if (txtYes == false)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStrip1.Items["item0"];
                    item.Checked = true;
                    Hashtable para2 = new Hashtable();
                    para2.Add("txtChecked", item.Text);
                    EncryptUtilSeal.EncryptObject(para2, configFilePath);
                    words = item.Text;
                }
                else
                {
                    words = txtChecked;
                }
            }
            else
            {
                ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStrip1.Items["item0"];
                item.Checked = true;
                Hashtable para2 = new Hashtable();
                para2.Add("txtChecked", item.Text);
                EncryptUtilSeal.EncryptObject(para2, configFilePath);
                words = item.Text;
            }
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //此代码也是能实现窗体移动效果的，调用微软API函数
        void mouseControl()
        {
            this.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }


            };
        }




        //// <summary>

        //// 窗体四个角圆角化
        //// </summary>
        //// <param name="e"></param>
        //protected override void OnResize(EventArgs e)
        //{

        //    base.OnResize(e);

        //    int Rgn = Win32.CreateRoundRectRgn(3, 3, this.Width - 1, this.Height - 1, 5, 5);
        //    Win32.SetWindowRgn(this.Handle, Rgn, true);

        //    if (this.childForm != null)

        //        this.childForm.Size = new Size(this.Size.Width - 17, this.Height - 39);
        //}




        //private const int WM_NCHITTEST = 0x84;
        //private const int HTCLIENT = 0x1;
        //private const int HTCAPTION = 0x2;
        ////实现移动主窗体，并可放大，缩小
        //protected override void WndProc(ref Message message)
        //{
        //    base.WndProc(ref message);

        //    if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
        //    {
        //        message.Result = (IntPtr)HTCAPTION;
        //    }
        //}


        //副窗体随主窗体位置移动
        private void BackForm_LocationChanged(object sender, EventArgs e)
        {
            if (this.childForm != null)
            {


                childForm.Location = new Point(this.Location.X, this.Location.Y);


            }
        }

        private void tsm_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsm_setting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            //form.ShowDialog();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                GC.Collect();
            }
            form.Dispose();
        }

        public bool CheckedItem(string txtChecked)
        {
            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Name == "toolStripSeparator1")
                {
                    continue;
                }
                ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStrip1.Items[i];
                //不是当前项的取消选择
                if (item.Text == txtChecked)
                {
                    item.Checked = true; //设选中状态为true
                    return true;
                }

            }
            return false;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "tsm_close" ||
                e.ClickedItem.Name == "tsm_setting" ||
                e.ClickedItem.Name == "tsm_pause" ||
                e.ClickedItem.Name == "tsm_ukMp3" ||
                e.ClickedItem.Name == "tsm_usMp3"
                )
            {
                return;
            }
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            IsCheckedControl(item);
            GC.Collect();

        }

        /// <summary>
        /// 设置右键菜单单选
        /// </summary>
        /// <param name="cms">参数-右键可选项类</param>
        public void IsCheckedControl(ToolStripMenuItem cms)
        {

            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Name == "toolStripSeparator1")
                {
                    continue;
                }
                ToolStripMenuItem item = (ToolStripMenuItem)contextMenuStrip1.Items[i];
                //不是当前项的取消选择
                if (item.Text == cms.Text)
                {
                    Hashtable para = new Hashtable();
                    para.Add("txtChecked", item.Text);
                    EncryptUtilSeal.EncryptObject(para, configFilePath);
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

        private void BackForm_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }
        /// <summary>
        /// 设置窗体的Region
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 50);
            this.Region = new Region(FormPath);

        }
        /// <summary>
        /// 绘制圆角路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }

        private void tsm_pause_Click(object sender, EventArgs e)
        {
            if (tsm_pause.Name == "暂停")
            {
                childForm.timerWord.Enabled = false;
                tsm_pause.Name = "开始";
            }
            else
            {
                childForm.timerWord.Enabled = true;
                tsm_pause.Name = "暂停";
            }

        }

        private void tsm_ukMp3_Click(object sender, EventArgs e)
        {
            // wmp.URL = ukMp3;
            // wmp.Ctlcontrols.play();//播放文件
            
            wmp.URL = ukMp3;
            wmp.controls.play();
            GC.Collect();

        }

        private void tsm_usMp3_Click(object sender, EventArgs e)
        {

            // wmp.URL = usMp3;
            //wmp.Ctlcontrols.play();//播放文件
            wmp.URL = usMp3;
            wmp.controls.play();
            GC.Collect();
        }
    }
}
