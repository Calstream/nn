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
        byte[] original;
        byte[] temp;
        int bytes;
        int stride;
        int w;
        int h;
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
                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap(ofd.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.bmp) | *.jpg; *.jpeg; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap(ofd.FileName);
                Bitmap bmp = pictureBox.Image as Bitmap;
                w = bmp.Width;
                h = bmp.Height;
                Rectangle rect = new Rectangle(0, 0, w, h);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
                int stride = bmpData.Stride;
                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                original = new byte[bytes];
                temp = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, original, 0, bytes);

                System.Runtime.InteropServices.Marshal.Copy(original, 0, ptr, bytes);

                // Unlock the bits.
                bmp.UnlockBits(bmpData);
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

        private void bin_Click(object sender, EventArgs e)
        {

            int t = (int)numericUpDown_tr.Value;
            int blue = labelColor.BackColor.B;
            int green = labelColor.BackColor.G;
            int red = labelColor.BackColor.R;
            Bitmap bmp = pictureBox.Image as Bitmap;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            //byte[] r = new byte[bytes / 3];
            //byte[] g = new byte[bytes / 3];
            //byte[] b = new byte[bytes / 3];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int count = 0;
            int stride = bmpData.Stride;

            for (int column = 0; column < bmpData.Height; column++)
            {
                for (int row = 0; row < bmpData.Width; row++)
                {
                    int bi = (column * stride) + (row * 3);
                    int gi = bi + 1;
                    int ri = gi + 1;
                    if (Math.Abs(rgbValues[bi] - blue) > t)
                    {
                        rgbValues[ri] = 0;
                        rgbValues[gi] = 0;
                        rgbValues[bi] = 0;
                        count++;
                        continue;
                    }
                    else rgbValues[bi] = 255;
                    if (Math.Abs(rgbValues[gi] - green) > t)
                    {
                        rgbValues[ri] = 0;
                        rgbValues[gi] = 0;
                        rgbValues[bi] = 0;
                        count++;
                        continue;
                    }
                    else rgbValues[gi] = 255;
                    if (Math.Abs(rgbValues[ri] - red) > t)
                    {
                        rgbValues[ri] = 0;
                        rgbValues[gi] = 0;
                        rgbValues[bi] = 0;
                        count++;
                        continue;
                    }
                    else rgbValues[ri] = 255;

                    count++;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            pictureBox.Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save";
            sfd.Filter = "Bitmap|*.bmp";
        }

        private void openTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp = pictureBox.Image as Bitmap;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            pictureBox.Refresh();
        }
    }
}
