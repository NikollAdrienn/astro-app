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
    public partial class Form4 : Form
    {
        private bool _allowClick = true;
        private PictureBox _firstGuess;
        private readonly Random _random = new Random();
        private readonly Timer _clickTimer = new Timer();
        int ticks = 59;
        readonly Timer timer = new Timer { Interval = 1000 };
        WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer zene = new WMPLib.WindowsMediaPlayer();

        public Form4()
        {
            InitializeComponent();
            SetRandomImages();
            HideImages();
            StartGameTimer();
            _clickTimer.Interval = 1000;
            _clickTimer.Tick += _clickTimer_Tick;
            zene.URL = "ray.mp3";
        }

        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
		 {
		    Resources.img1,
			Resources.img2,
			Resources.img3,
			Resources.img4,
			Resources.img5,
			Resources.img6,
			Resources.img7,
			Resources.img8
		 };
            }
        }

        private void StartGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                ticks--;
                if (ticks == -1)
                {
                    timer.Stop();
                    song.URL = "wrong.mp3";
                    zene.controls.stop();
                    MessageBox.Show("Lejárt az idő!");
                    ResetImages();
                }
                var time = TimeSpan.FromSeconds(ticks);
                lblTime.Text = "00:" + time.ToString("ss");
            };
        }

        private void ResetImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            SetRandomImages();
            ticks = 59;
            timer.Start();
            zene.URL = "ray.mp3";
        }

        private void HideImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Image = Resources.img0;
            }
        }

        private PictureBox GetFreeSlot()
        {
            int num;
            do
            {
                num = _random.Next(0, PictureBoxes.Count());
            } while (PictureBoxes[num].Tag != null);
            return PictureBoxes[num];
        }

        private void SetRandomImages()
        {
            foreach (var image in Images)
            {
                GetFreeSlot().Tag = image;
                GetFreeSlot().Tag = image;
            }
        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!_allowClick) return;
            var pic = (PictureBox)sender;
            if (_firstGuess == null)
            {
                _firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;
            if (pic.Image == _firstGuess.Image && pic != _firstGuess)
            {
                song.URL = "good.mp3";
                pic.Visible = _firstGuess.Visible = false;
                _firstGuess = pic;
                HideImages();
            }
            else
            {
                _allowClick = false;
                _clickTimer.Start();
            }
            _firstGuess = null;
            if (PictureBoxes.Any(p => p.Visible)) return;
            timer.Stop();
            song.URL = "win.mp3";
            MessageBox.Show("Gratulálok! Nyertél!");
            zene.controls.stop();
            ResetImages();
        }

        private void _clickTimer_Tick(object sender, EventArgs e)
        {
            HideImages();
            _allowClick = true;
            _clickTimer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zene.controls.stop();
            timer.Stop();
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Szünet")
            {
                zene.controls.pause();
                timer.Stop();
                button1.Text = "Folytat";
            }
            else
            {
                zene.controls.play();
                timer.Start();
                button1.Text = "Szünet";
            }
        }
    }
}