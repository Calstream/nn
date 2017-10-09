using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace nnn1
{
    public partial class rescale : Form
    {
        public rescale()
        {
            InitializeComponent();
        }

        BinaryReader reader;
        BinaryWriter writer;
        double[] new_v;
        int[] old_v;
        string filepath;
        bool fileExists = false;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Binary Files|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                Text = Path.GetFileName(filepath);
                fileExists = true;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save As...";
            sfd.Filter = "Binary Files|*.bin";
        }

        private void rescaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int min = (int)num_min.Value;
            int max = (int)num_max.Value;
            if (min > max)
                MessageBox.Show("Minimum can't be greater than maximum.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (fileExists == false)
                MessageBox.Show("Please select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (var filestream = File.Open(filepath, FileMode.Open))
                using (var binaryStream = new BinaryReader(filestream))
                {
                    while (binaryStream.PeekChar() != -1)
                    {
                        old_v.
                        var integerFromFile = binaryStream.ReadInt32();
                    }
                }
            }
        }
    }
}
