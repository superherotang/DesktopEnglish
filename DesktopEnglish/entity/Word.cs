using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopEnglish.entity
{
    class Word
    {
        private string wordStr;
        private string yinbiao;
        private ArrayList explain;
        private string ukMp3;
        private string usMp3;

        public Word(string wordStr, string yinbiao, ArrayList explain, string ukMp3, string usMp3)
        {
            this.wordStr = wordStr;
            this.yinbiao = yinbiao;
            this.explain = explain;
            this.ukMp3 = ukMp3;
            this.usMp3 = usMp3;
        }
        public Word()
        {
            this.wordStr = "";
            this.yinbiao = "";
            this.explain = null;
            this.ukMp3 = "";
            this.usMp3 = "";
        }
        public string WordStr { get => wordStr; set => wordStr = value; }
        public string Yinbiao { get => yinbiao; set => yinbiao = value; }
        public ArrayList Explain { get => explain; set => explain = value; }
        public string UkMp3 { get => ukMp3; set => ukMp3 = value; }
        public string UsMp3 { get => usMp3; set => usMp3 = value; }
    }
}
