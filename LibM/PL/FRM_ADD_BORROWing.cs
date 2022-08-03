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
    public partial class FRM_ADD_BORROWing : Form
    {
        public FRM_ADD_BORROWing()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(textBox1.ReadOnly==true)
            {
                textBox1.ReadOnly = false;
            }
            else{
                textBox1.ReadOnly = true;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
