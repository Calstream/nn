using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nnn1
{
    public partial class Form1 : Form
    {
        int x;
        int y;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp, *.gif) | *.jpg; *.jpeg; *.png; *.bmp; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //filepath = ofd.FileName;
                //this.Text = Path.GetFileName(filepath);
                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap(ofd.FileName);
                //imExists = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp, *.gif) | *.jpg; *.jpeg; *.png; *.bmp; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //filepath = ofd.FileName;
                //this.Text = Path.GetFileName(filepath);
                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap(ofd.FileName);
                //imExists = true;
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
                Cursor.Current = Cursors.Cross;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Cursor.Current = Cursors.Cross;
                x = e.X;
                y = e.Y;
            }

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Color c = ((Bitmap)pictureBox.Image).GetPixel(x, y);

            labelColor.BackColor = c;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                l.BackColor = colorDialog1.Color;
            }
        }
    }
}
