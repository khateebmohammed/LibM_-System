using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibM.PL
{
    public partial class FRM_VISITing : Form
    {
        public FRM_VISITing()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Enabled = true;
                comboBox4.Enabled = false;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                comboBox4.Enabled = true;
                comboBox1.Enabled = false;
            }
        }
    }
}
