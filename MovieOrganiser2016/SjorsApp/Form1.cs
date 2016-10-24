using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SjorsApp
{
    public partial class Form1 : Form
    {
        List<string> woorden;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            woorden = new List<string>();
            woorden.Add("ROGGEVELD");
            woorden.Add("RECOMMANDABEL");
            woorden.Add("EX VOTO");
            woorden.Add("PRONKSTUK");
            woorden.Add("PIRATERIJ");
            woorden.Add("ONVERDUND");
            woorden.Add("ONDERNEMINGSSTRATEGIE");
            woorden.Add("KAM");
            woorden.Add("VERLEKKEREN");
            woorden.Add("BEWINDSVROUWE");
            woorden.Add("WELIJZER");
            woorden.Add("SNORKELEN");
            woorden.Add("MERCHANDISEARTIKEL");
            woorden.Add("PYJAMAJASJE");
            woorden.Add("TRANSITLAND");
            woorden.Add("RUNENSCHRIFT");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randompositie = rnd.Next(woorden.Count);
            string randomword = woorden[randompositie];
            this.textBox1.Text = randomword;

            this.textBox2.Text = woorden[rnd.Next(woorden.Count)];
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = this.textBox1.Text + " " + this.textBox2.Text;
        }
    }
}
