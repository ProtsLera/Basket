using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

namespace WindowsFormsApplication4
{
    struct basket
    {
        public int MyScore;
        public string MyPlayerName;
        public string MyTeam;
        public override string ToString()
        {
            return string.Format("Score: {0}, PlayerName: {1}, Team: {2}", MyScore, MyPlayerName, MyTeam);
        }
    }
    public partial class MyBasket : Form
    {
        BasketBall basketball = new BasketBall();
        public MyBasket()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> list = new List<TextBox>();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                { 
                    list.Add((TextBox)c);
                }       
            }
            string JSONstring;
            JSONstring = basketball.ReadHtml();
            string[] separators = { "},", "}" };
            JSONstring = JSONstring.Trim(new Char[] { '[', ']' });
            string[] JSON = JSONstring.Split(separators, StringSplitOptions.None);
            var BS = new List<basket>();
            for (int i = 0; i < JSON.Length - 1; i++)
            {
                JSON[i] = JSON[i] + "}";
                basketball = JsonConvert.DeserializeObject<BasketBall>(JSON[i]);
                BS.Add(new basket { MyScore = basketball.Score, MyPlayerName = basketball.PlayerName, MyTeam = basketball.Team });
            }
            var SortedUsers = from u in BS
                              orderby u.MyScore
                              select u;
            int Counter= 0;
            foreach (basket u in SortedUsers)
            {
                char y = u.MyTeam[0];
                if (y == 'C') { continue; }
                list[Counter].Text = u.MyPlayerName.ToString();
                list[Counter + 5].Text = u.MyScore.ToString();
                Counter= Counter + 1;

            }Counter= 10;
            foreach (basket u in SortedUsers)
            {
                char OneName = u.MyTeam[0];
                if (OneName == 'L') { continue; }
                list[Counter].Text = u.MyPlayerName.ToString();
                list[Counter + 5].Text = u.MyScore.ToString();
                Counter = Counter + 1;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
