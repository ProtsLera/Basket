using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WindowsFormsApplication4
{
    public class BasketBall
    {

        public string PlayerName { get; set; }
        public string Team { get; set; }
        public int Score { get; set; }
        public string ReadHtml()
        {
            HttpWebRequest ProxyRequest = (HttpWebRequest)WebRequest.Create("http://api.lod-misis.ru/testassignment");
            ProxyRequest.Method = "GET";
            ProxyRequest.ContentType = "application/x-www-form-urlencoded";
            ProxyRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
            ProxyRequest.KeepAlive = true;
            HttpWebResponse resp = ProxyRequest.GetResponse() as HttpWebResponse;
            string JSONstring = "";
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(1251)))
                JSONstring = sr.ReadToEnd();
            JSONstring = JSONstring.Trim();
            return JSONstring;
        }
      
    }
}
