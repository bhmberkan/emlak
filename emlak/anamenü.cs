using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace emlak
{
    public partial class anamenü : Form
    {
        public anamenü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            evekle ev = new evekle();
            ev.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            evsorgu evs = new evsorgu();
            evs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sat sat = new sat();
            sat.Show();
            this.Hide();
        }
    }
}
