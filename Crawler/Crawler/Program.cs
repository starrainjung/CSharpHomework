using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crawler
{
   
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private string html;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "https://www.360.com/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);                //加入初始页面
           
            Thread thread = new Thread(new ThreadStart(myCrawler.Crawl));
            thread.Start();
            Console.ReadKey();
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了");
            while (true)
            {
                string current = null;
              

                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
              
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面");
                html= DownLoad(current);
                urls[current] = true;
                count++;
                Parse();
            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                lock (this)
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);

                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return " ";
            }
        }
        public void Parse()
        {
            lock (html)
            {
                string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\\', '#', '>');
                    if (strRef.Length == 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            }
        }
    }

}