/*
 2、尝试使用Winform来设置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCrawler;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace WindowsFormsCrawler
{
    public partial class Form1 : Form
    {
        SimpleCrawler.SimpleCrawler WinFormCrawler = new SimpleCrawler.SimpleCrawler();
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = WinFormCrawler.urls;
        }
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//auto number
        {

            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimpleCrawler.SimpleCrawler.startUrl = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinFormCrawler.finished = false;
            WinFormCrawler.urls = new Hashtable();//because there is the potential for clicking this button more than 1 time
            WinFormCrawler.count = 0;//ensure the second and later execution in the winForm
            WinFormCrawler.urls.Add(SimpleCrawler.SimpleCrawler.startUrl, false);//加入初始页面
            new Thread(WinFormCrawler.Crawl).Start();
            MessageBox.Show("start!");
            //Thread.Sleep(5000);
            while (true)
            {
                if (WinFormCrawler.finished)
                {
                    bindingSource1.DataSource = WinFormCrawler.urls;
                    //bindingSource1.ResetBindings(false);
                    break;
                }
            }
        }
    }
}
