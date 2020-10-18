/*
 1、改进书上例子9-10的爬虫程序。
（1）只爬取起始网站（www.cnblog.com）上的网页 
（2）只有当爬取的是html，htm，jsp，aspx、php页面时，才解析并爬取下一级URL。
（3）相对地址转成绝对地址进行爬取。
	例如：当前页面是 https://www.cnblogs.com/abc/时, 该页面中的链接 test/index.html 或者 ./test/index.html都相当于 https://www.cnblogs.com/abc/test/index.html ， ../zzz/index.html相当于 https://www.cnblogs.com/zzz/index.html 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            /*
            Uri uri1 = new Uri("http://www.cnblogs.com/dstang2000");
            Uri newuri = new Uri(uri1, "archive/2010/11/02.html");
            Console.WriteLine(newuri);
             */
            //actually the above lines are testing the class:Uri, which extremely surprised me. With it, I do not need to care about the problems of "/" in the composition of base uri and relative uri.
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
            Console.ReadKey();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html,current);//解析,并加入新的链接
                Console.WriteLine("爬行结束");
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html, string currentUrl)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+\.(html|htm|jsp|aspx|php)[""']";//configure the need 2
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;//no matter the type of the address(absolute or relative), this vertification is neccessary

                if (strRef.Substring(0,4)=="http")//denotes it is a absolute address 
                {

                        if (urls[strRef] == null&& strRef.Contains("www.cnblogs.com")) urls[strRef] = false;//configure the need 1
                }
                else
                {
                    Uri baseUri = new Uri(currentUrl);
                    Uri absoluteAddress = new Uri(baseUri, strRef);//configure the need 3
                    if (urls[absoluteAddress.ToString()]==null&&(absoluteAddress.ToString().Contains("www.cnblogs.com")))//configure the need 1
                    {
                        urls[absoluteAddress.ToString()] = false;
                    }
                }
            }
        }
    }
}
