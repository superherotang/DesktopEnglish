using DesktopEnglish.entity;
using DesktopEnglish.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DesktopEnglish
{
    public partial class MainForm : Form
    {
        private Point mPoint;
        private static string configFilePath;
        private static string routineFilePath;
        private static Routine routine;
        private List<string> wordList = new List<string>();
        private int wordC=0;
        BackForm backForm2;
        StringBuilder wordStrBuilder = new StringBuilder();
        Label lbl = new Label();
        public System.Windows.Forms.Timer timerWord;

        //private Point LDPoint;


        public MainForm(BackForm backForm)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            Init();
            //LDPoint

            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = routine.FontColor;
            this.lbl.Location = new System.Drawing.Point(20, 20);
            this.lbl.Name = "lbStr";
            this.lbl.Font = routine.Font;
            //this.lbl.Size = new System.Drawing.Size(55, 15);
            this.lbl.Text = "str";
            this.Controls.Add(this.lbl);
            lbl.MouseMove += MainForm_MouseMove;
            lbl.MouseDown += MainForm_MouseDown;
            // 

            //TimerWord
            this.components = new System.ComponentModel.Container();
            this.timerWord = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            this.timerWord.Enabled = true;
            this.timerWord.Interval = routine.Speed*1000;
            this.timerWord.Tick += new System.EventHandler(this.timerWord_Tick);


            backForm2 = backForm;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            UpdateStyles();
        }


        ///// <summary>
        ///// 边框阴影
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ClassStyle |= 0x20000;
        //        return createParams;
        //    }
        //}

        public static void flush() {
            Hashtable para = new Hashtable();
            object obj = EncryptUtilSeal.DecryptObject(routineFilePath);
            para = obj as Hashtable;
            string family = para["family"].ToString();
            int fontSize = Convert.ToInt32(para["fontSize"].ToString());
            routine.Font = new Font(new FontFamily(family), fontSize);
            routine.FontColor = ColorTranslator.FromHtml(para["fontColor"].ToString());
            routine.BackColor = ColorTranslator.FromHtml(para["backColor"].ToString());
            routine.Opacity = Convert.ToDouble(para["opacity"].ToString());
            routine.Speed = Convert.ToInt32(para["speed"].ToString());
            
        } 
        private void Init()
        {

             SetPenetrate();

            
            routine = new Routine();
            configFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.dat");
            routineFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "routine.dat");

            
            //字体背景
            if (File.Exists(routineFilePath))
            {
                Hashtable para = new Hashtable();
                object obj = EncryptUtilSeal.DecryptObject(routineFilePath);
                para = obj as Hashtable;
                string family = para["family"].ToString();
                int fontSize = Convert.ToInt32(para["fontSize"].ToString());
                routine.Font = new Font(new FontFamily(family), fontSize);
                routine.FontColor = ColorTranslator.FromHtml(para["fontColor"].ToString());
                routine.BackColor = ColorTranslator.FromHtml(para["backColor"].ToString());
                routine.Opacity = Convert.ToDouble(para["opacity"].ToString());
                routine.Speed = Convert.ToInt32(para["speed"].ToString());
            }
            else
            {
                routine = Routine.initRoutineSetting();
            }







            Hashtable paraC = new Hashtable();
            object objC = EncryptUtilSeal.DecryptObject(configFilePath);
            paraC = objC as Hashtable;
            string txtChecked = paraC["txtChecked"].ToString();

            string wordPath = AppDomain.CurrentDomain.BaseDirectory + "words\\"+txtChecked+".txt";
            string line;
            StreamReader sr = File.OpenText(wordPath);
            while ((line = sr.ReadLine()) != null)
            {
                wordList.Add(line);
            }

            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            
            GC.Collect();
        }


        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        /// <summary> 
        /// 设置窗体具有鼠标穿透效果 
        /// </summary> 
        public void SetPenetrate()
        {
            GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
            IntPtr hwnd,
            int nIndex
        );
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
            IntPtr hwnd,
            int nIndex,
            uint dwNewLong
        );



        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        //画单词------太模糊
        //private void MainForm_Paint(object sender, PaintEventArgs e)
        //{
        //    if (this.wordStrBuilder.Length == 0)
        //    {
        //        return;
        //    }

        //    Graphics g = this.CreateGraphics();
        //    Font font = routine.Font;

        //    PointF point = new PointF(0, 0);
        //    g.Clear(this.BackColor);
        //    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        //    g.DrawString(wordStrBuilder.ToString(), font,new SolidBrush(routine.FontColor), point);
        //    g.Dispose();
            
        //}

        private void timerWord_Tick(object sender, EventArgs e)
        {
            wordC++;
            this.StartWords(sender, e);
        }
        private void StartWords(object sender, EventArgs e)
        {
            
            if (wordC == wordList.Count)
            {
                wordC = 0;
            }
            Word word = WordUtils.getWordDict(wordList[wordC]);
            this.wordStrBuilder.Clear();
            wordStrBuilder.AppendLine(word.WordStr);
            wordStrBuilder.AppendLine(word.Yinbiao);
            for (int i = 0; i < word.Explain.Count; i++)
            {
                wordStrBuilder.AppendLine(word.Explain[i].ToString());
            }
            backForm2.ukMp3 = word.UkMp3;
            backForm2.usMp3 = word.UsMp3;
            //窗口画不清晰
            //this.MainForm_Paint(sender, e as PaintEventArgs);
            //Point fPoint = new Point(Location.X + Size.Width, Location.Y + Size.Width);
            Size = new Size(400, 300);
            this.lbl.Text = wordStrBuilder.ToString();
            if (lbl.Size.Width > this.Size.Width - 20)
            {
                Size = new Size(lbl.Size.Width + 40, this.Size.Width);
            }
            if (lbl.Size.Height > this.Size.Height - 20)
            {
                Size = new Size(lbl.Size.Height + 40, this.Size.Height);
            }
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - base.Height - 40);

            GC.Collect();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartWords(sender, e);

        }

    }
}
