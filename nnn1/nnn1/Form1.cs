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
    }
}
