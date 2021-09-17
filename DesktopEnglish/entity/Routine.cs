using DesktopEnglish.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopEnglish.entity
{
    class Routine
    {
        private Font font;
        private Color fontColor;
        private Color backColor;
        private int speed;
        private double opacity;


        public Routine()
        {
        }

        public Routine(Font font, Color fontColor, Color backColor, int speed, double opacity)
        {
            this.font = font;
            this.fontColor = fontColor;
            this.backColor = backColor;
            this.speed = speed;
            this.Opacity = opacity;
        }

        public Font Font { get => font; set => font = value; }
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public Color BackColor { get => backColor; set => backColor = value; }
        public int Speed { get => speed; set => speed = value; }
        public double Opacity { get => opacity; set => opacity = value; }

        public static Routine initRoutineSetting()
        {
            Routine routine = new Routine();
            routine.BackColor = ColorTranslator.FromHtml("#1E1E1E");
            routine.FontColor = ColorTranslator.FromHtml("#3798D4");
            routine.Font = new Font(new FontFamily("微软雅黑"), 18);
            routine.Opacity = 0.5;
            routine.Speed = 15;
            Hashtable para = new Hashtable();
            para.Add("family", "微软雅黑");
            para.Add("fontSize", "18");
            para.Add("fontColor", "#3798D4");
            para.Add("backColor", "#1E1E1E");
            para.Add("opacity", "0.5");
            para.Add("speed", "15");
            EncryptUtilSeal.EncryptObject(para, Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "routine.dat"));
            return routine;
        }
    }
}
