using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            var html = string.Format(@"{0}",url);
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            int count = 0;
            var nodes = htmlDoc.DocumentNode.SelectNodes("//figure//img");
            WebClient myWebClient = new WebClient();
            foreach (var img in nodes)
            {
                string urlImage = img.GetAttributeValue("data-src", "");
                if(urlImage == "")
                {
                    urlImage = img.GetAttributeValue("src", "");
                }
                myWebClient.DownloadFile(urlImage, string.Format(@"D:\CrawImage\{0}", "image" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + count + ".png"));
                count++;
            }
            MessageBox.Show("DONE!");
        }
    }
}
