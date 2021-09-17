using DesktopEnglish.entity;
using DesktopEnglish.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopEnglish
{
    public partial class SettingForm : Form
    {
        string routineFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "routine.dat");
        private Point mPoint;
        private Routine routine;

        public SettingForm()
        {
            InitializeComponent();
            Init();

        }

        public delegate void updateParentData(object sender);
        public event updateParentData updateIt;
        private void Init()
        {
            routine = new Routine();
            this.Opacity = 0.8;
            this.BackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;//样式

            button1.FlatAppearance.BorderSize = 1;//去边线
            button1.FlatAppearance.MouseOverBackColor = Color.AliceBlue;//鼠标经过
            button1.FlatAppearance.MouseDownBackColor = Color.White;//鼠标按下

            button2.FlatStyle = FlatStyle.Flat;//样式
            button1.FlatAppearance.BorderSize = 1;//去边线
            button1.FlatAppearance.MouseOverBackColor = Color.AliceBlue;//鼠标经过
            button1.FlatAppearance.MouseDownBackColor = Color.White;//鼠标按下

            button4.FlatStyle = FlatStyle.Flat;//样式
            button1.FlatAppearance.BorderSize = 1;//去边线
            button1.FlatAppearance.MouseOverBackColor = Color.AliceBlue;//鼠标经过
            button1.FlatAppearance.MouseDownBackColor = Color.White;//鼠标按下

            button5.FlatStyle = FlatStyle.Flat;//样式
            button1.FlatAppearance.BorderSize = 1;//去边线
            button1.FlatAppearance.MouseOverBackColor = Color.AliceBlue;//鼠标经过
            button1.FlatAppearance.MouseDownBackColor = Color.White;//鼠标按下

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
            FormInit(routine);
        }

        private void FormInit(Routine rt) {
            trackBar1.Value = Convert.ToInt32(rt.Opacity * 10);
            lb_tmdx.Text = (rt.Opacity * 10).ToString();
            textBox1.Text = rt.Speed.ToString();
            pictureBox1.BackColor = rt.BackColor;
            pictureBox2.BackColor = rt.FontColor;
            button4.Font = rt.Font;
            button4.Text = rt.Font.FontFamily.Name;
            this.fontDialog1.Font = rt.Font;
        }

        //写入
        //Hashtable para = new Hashtable();
        //para.Add("txtChecked", "aaa");
        //    EncryptUtilSeal.EncryptObject(para, ConfigFilePath);

        //读取
        //Hashtable para = new Hashtable();
        //object obj = EncryptUtilSeal.DecryptObject(ConfigFilePath);
        //para = obj as Hashtable;
        //    string ZH = para["ZH"].ToString();
        //string MM = para["MM"].ToString();

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lb_tmdx.Text = trackBar1.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)

            {

                button4.Font = this.fontDialog1.Font;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Routine rt = Routine.initRoutineSetting();
            FormInit(rt);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void SettingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hashtable para = new Hashtable();
            para.Add("family", this.fontDialog1.Font.FontFamily.Name);
            para.Add("fontSize", ((int)this.fontDialog1.Font.Size));
            para.Add("fontColor", ColorTranslator.ToHtml(Color.FromArgb(pictureBox2.BackColor.R, pictureBox2.BackColor.G, pictureBox2.BackColor.B)));
            para.Add("backColor", ColorTranslator.ToHtml(Color.FromArgb(pictureBox1.BackColor.R, pictureBox1.BackColor.G, pictureBox1.BackColor.B)));
            Double db = Convert.ToDouble(trackBar1.Value)/10;
            if (db == 0)
            {
                db = 0.05;
            }
            para.Add("opacity", db);
            para.Add("speed", textBox1.Text);
            EncryptUtilSeal.EncryptObject(para, Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "routine.dat"));
            
        }
    }
}
