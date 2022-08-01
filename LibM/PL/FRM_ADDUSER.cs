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
    public partial class FRM_ADDUSER : Form
    {
        public int ID;
        public FRM_ADDUSER()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_timer.Text = DateTime.Now.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_user.Text == "" || txt_prem.Text == "")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                   
                    //ADD
                    BL.CLS_USERS BLUSER = new BL.CLS_USERS();
                    BLUSER.Insert(txt_name.Text,txt_user.Text,txt_password.Text,txt_prem.Text,"False");
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {


                    BL.CLS_USERS BLUSER = new BL.CLS_USERS();
                    BLUSER.upadte(txt_name.Text, txt_user.Text, txt_password.Text, txt_prem.Text, ID);
                    PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }

            }
        }
    }
}
