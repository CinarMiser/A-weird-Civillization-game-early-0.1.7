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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a1.Visible = true;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = false;
            purposepanel.Visible = true;
            GameTimepanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = true;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = false;
            purposepanel.Visible = false;
            GameTimepanel.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = true;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = true;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = true;
            a6.Visible = false;
            a7.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = true;
            a7.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = true;
        }
    }
}
