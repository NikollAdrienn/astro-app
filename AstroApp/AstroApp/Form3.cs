using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;

namespace AstroApp
{


    public partial class Form3 : Form
    {

        WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();
        int nr, nota = 0, intreb_curent;
        Collection<intrebare> intrebari = new Collection<intrebare>();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            song.URL = "click.mp3";
            if (radioButton1.Checked && intrebari[intreb_curent].varianta_corecta == 1) nota++;
            if (radioButton2.Checked && intrebari[intreb_curent].varianta_corecta == 2) nota++;
            if (radioButton3.Checked && intrebari[intreb_curent].varianta_corecta == 3) nota++;
            if (radioButton4.Checked && intrebari[intreb_curent].varianta_corecta == 4) nota++;
            nr++;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (nr > intrebari.Count)
            {
                song.URL = "win.mp3";
                
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                label1.Visible = false;
                button1.Visible = false;
                MessageBox.Show("Gratulálok!  " + nota + " pontot ért el.");
            }

            else
            {
                Random r = new Random();
                int x;
                do { x = r.Next(intrebari.Count); } while (intrebari[x].afisat == true);
                label1.Text = intrebari[x].text;
                radioButton1.Text = intrebari[x].raspuns1;
                radioButton2.Text = intrebari[x].raspuns2;
                radioButton3.Text = intrebari[x].raspuns3;
                radioButton4.Text = intrebari[x].raspuns4;
                intrebari[x].afisat = true;
                intreb_curent = x;
            }
        }

          private void Form3_Load(object sender, EventArgs e)
          {
              radioButton1.Visible = false;
              radioButton2.Visible = false;
              radioButton3.Visible = false;
              radioButton4.Visible = false;
              label1.Visible = false;
              button1.Visible = false;
          }

        private void newToolStripMeniItem_Click(object sender, EventArgs e)
        {
            nr = 1;
            label1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            button1.Visible = true;
            
            StreamReader sr = new StreamReader("quiz.txt");
            while (!sr.EndOfStream)
            {
                intrebare i = new intrebare();
                i.text = sr.ReadLine();
                i.raspuns1 = sr.ReadLine();
                i.raspuns2 = sr.ReadLine();
                i.raspuns3 = sr.ReadLine();
                i.raspuns4 = sr.ReadLine();
                i.varianta_corecta = Convert.ToInt32(sr.ReadLine());
                intrebari.Add(i);
            }
            sr.Close();

            Random r = new Random();
            int x = r.Next(intrebari.Count);
            label1.Text = intrebari[x].text;
            radioButton1.Text = intrebari[x].raspuns1;
            radioButton2.Text = intrebari[x].raspuns2;
            radioButton3.Text = intrebari[x].raspuns3;
            radioButton4.Text = intrebari[x].raspuns4;
            intrebari[x].afisat = true;
            intreb_curent = x;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void mouseOn(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void mouseOut(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}