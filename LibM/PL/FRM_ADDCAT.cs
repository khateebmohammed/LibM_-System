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
    public partial class FRM_ADDCAT : Form
    {
       public int ID;
        public FRM_ADDCAT()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_catname.Text == "")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                    //ADD
                    BL.CLS_CAT BLCAT = new BL.CLS_CAT();
                    BLCAT.Insert(txt_catname.Text);
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {
                    BL.CLS_CAT BLCAT = new BL.CLS_CAT();
                    BLCAT.update(txt_catname.Text,ID);
                    PL.FRM_DEDIT fEDIT=new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }
               
            }
           


        }
    }
}
