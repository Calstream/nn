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
    public partial class Form2 : Form
    {
        int[] old_values;
        int[] new_values;
        public Form2()
        {
            InitializeComponent();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open...";
            ofd.Filter = "Text files (*.txt) | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
