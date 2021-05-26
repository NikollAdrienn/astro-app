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
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.galaxy;
            song.URL = "galaxy.mp3";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            button1.Visible = true;
            timer1.Stop();
            this.BackgroundImage = Resources.spacehand;
        }
    }
}
