using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduTalk
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechDemo sd = new BaiduTalk.SpeechDemo();
            sd.Tts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
