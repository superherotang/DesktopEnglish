using DesktopEnglish.entity;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopEnglish.utils
{
    class WordUtils
    {
        public static Word getWordDict(string wordStr) {

            string url = "https://cn.bing.com/dict/search?q="+wordStr;
            Word word = new Word();
            word.WordStr = wordStr;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string ukYin = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div[2]/div/div[1]").InnerText;
            string usYin = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div[2]/div/div[3]").InnerText;


            ukYin = HtmlFormater.ConvertToXmlDocument(ukYin).InnerText;
            usYin = HtmlFormater.ConvertToXmlDocument(ukYin).InnerText;

            string yinbiao = ukYin + "\t" + usYin;
            word.Yinbiao = yinbiao;
            HtmlNode htmlUl = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[1]/div[1]/ul");
            HtmlNodeCollection CNodes = htmlUl.ChildNodes;
            ArrayList list = new ArrayList();
            
            for (int i = 0; i < CNodes.Count()-1; i++)
            {
                list.Add(CNodes[i].FirstChild.InnerText + " " + CNodes[i].LastChild.InnerText);
                //Console.WriteLine(CNodes[i].FirstChild.InnerText + "\t" + CNodes[i].LastChild.InnerText);
            }
            word.Explain = list;
            string ukMp3Html = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div[2]/div/div[2]/a").OuterHtml;
            string ukMp3Url = getMp3Url(ukMp3Html);

            string usMp3Html = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div[2]/div/div[4]/a").OuterHtml;
            string usMp3Url = getMp3Url(usMp3Html);
            word.UkMp3 = ukMp3Url;
            word.UsMp3 = usMp3Url;
            return word;
        }

        private static string getMp3Url(string str)
        {
            Regex reg = new Regex("http(s{0,1})://.+?\\.mp3");
            string modified = reg.Matches(str)[0].Value;
            return modified;
        }

    }
}
