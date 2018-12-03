using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractContent
{
    class HtmlParse
    {
        List<String> m_Content;
        List<String> m_Urls;
        List<List<String>> m_Output;

        public HtmlParse()
        {
            m_Output = new List<List<string>>();
            m_Urls = new List<string>();
            m_Urls.Add("http://www.phpbb.com/community/viewtopic.php?f=46&t=2159437");
            m_Urls.Add("https://www.vbulletin.com/forum/showthread.php/404497-www-vs-non-www-URL-causing-site-not-to-login");
        }

        public List<String> GetContent(String url)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            m_Content = new List<string>();

            try
            {
                HtmlWeb web = new HtmlWeb();

                HtmlDocument htmlDoc = web.Load(url);
                var result = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class,'content-text') or @class='content']");

                foreach (var data in result)
                {
                    if (!string.IsNullOrWhiteSpace(data.InnerText))
                    {

                        String strTemp = Regex.Replace(data.InnerText, @"[\r\n]+", "\n");
                        String strComplete = Regex.Replace(strTemp, @"[^\S \n]+", "");
                        m_Content.Add(strComplete);
                    }
                }
            }
            catch (Exception e)
            {

            }

            return m_Content;
        }

        public void Run()
        {
           
         foreach(String url in m_Urls)
            {
                m_Output.Add(this.GetContent(url));
            }

            print();        
        }

        private void print()
        {
            int i = 0;
            foreach(List<String> data in m_Output)
            {
                Console.WriteLine("For the url : {0}\n", m_Urls[i]);
                i++;
                int j = 1;
                foreach(String content in data)
                {
                    Console.WriteLine("{0}. {1}\n",j , content);
                    j++;
                }
            }
        }
    }
}
