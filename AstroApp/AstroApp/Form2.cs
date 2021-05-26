using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AstroApp.Properties;

namespace AstroApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("nap.rtf");
            pictureBox1.Load("nap.jpg");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("merkur.rtf");
            pictureBox1.Load("merkur.jpg");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("venusz.rtf");
            pictureBox1.Load("venusz.jpg");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("fold.rtf");
            pictureBox1.Load("fold.jpg");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("mars.rtf");
            pictureBox1.Load("mars.jpg");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("jupiter.rtf");
            pictureBox1.Load("jupiter.jpg");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("szaturnusz.rtf");
            pictureBox1.Load("szaturnusz.jpg");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("uranusz.rtf");
            pictureBox1.Load("uranusz.jpg");
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("neptunusz.rtf");
            pictureBox1.Load("neptunusz.jpg");
        }



    }
}
