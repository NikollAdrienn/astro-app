using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstroApp
{
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
            this.Cursor = new Cursor(Properties.Resources.galaxycursor.GetHicon());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

      

        private void label_mouseOn(object sender, EventArgs e)
        {
            var lab = (Label)sender;
            lab.ForeColor = System.Drawing.Color.Aquamarine;
        }

        private void label_mousOut(object sender, EventArgs e)
        {
            var lab = (Label)sender;
            lab.ForeColor = System.Drawing.Color.Black;
        }
    }
}
