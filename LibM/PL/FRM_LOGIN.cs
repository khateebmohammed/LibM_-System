using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace LibM.PL
{
    public partial class FRM_LOGIN : Form
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                BL.CLS_USERS CLSUSER = new BL.CLS_USERS();
                DataTable dt = new DataTable();
                dt = CLSUSER.login(txt_user.Text, txt_password.Text);
                if (dt.Rows.Count > 0)
                {
                    CLSUSER.upadteLOGIN(txt_user.Text, txt_password.Text);
                    PL.FRM_MIAN frmmain = new FRM_MIAN();
                    object lbname = dt.Rows[0]["CNAME"];
                    object lbprem = dt.Rows[0]["CPREM"];
                    frmmain.lb_prem.Text = lbname.ToString();
                    frmmain.lb_name.Text = lbprem.ToString();
                    frmmain.Show();
                    this.Close();
                }

            }catch(Exception ex)
            {
                MessageBox.Show("خطا في معلومات تسجيل الدخول");
            }

        }

        private void Pb_showPWD_Click(object sender, EventArgs e)
        {

            if (txt_password.PasswordChar == '*')
            {
                txt_password.PasswordChar = txt_user.PasswordChar;
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Btnadd_Click(object sender, EventArgs e)
        {

        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Lbl_Foreget_PSW_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
