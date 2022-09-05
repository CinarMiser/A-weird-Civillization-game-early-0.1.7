using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace a_weird_civilization
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game a = new Game();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tutorial b = new Tutorial();
            b.Show();
        }

        private void yuvarlakbuton1_Click(object sender, EventArgs e)
        {
            Updates updatepanel = new Updates();
            updatepanel.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
