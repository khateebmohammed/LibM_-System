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

namespace LibM.PL
{
    public partial class FRM_MAKESELL: Form
    {
        
        public int ID;
        public FRM_MAKESELL()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void FRM_ADDBOKKS_Load(object sender, EventArgs e)
        {
            BL.CLS_SELL BLSELL = new BL.CLS_SELL();
            //Load Books
            DataTable dt1 = new DataTable();
           dt1 = BLSELL.LoadBOOKS();
            dataGridView2.DataSource = dt1;
            DataTable dt2 = new DataTable();
            dt2 = BLSELL.LoadST();
            dataGridView1.DataSource = dt2;




        }

      

        private void btnadd_Click(object sender, EventArgs e)
        {
            //if (txt_title.Text=="" || txt_auther.Text=="" || txt_price.Text=="")
            //{
            //    PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
            //    FError.ShowDialog();
            //}
            //else
            //{
            //    if (ID == 0)
            //    {
            //        MemoryStream ma = new MemoryStream();
            //        cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);

            //        //ADD
            //        BL.CLS_BOOKS BLCAT =new BL.CLS_BOOKS() ;
            //        BLCAT.Insert(txt_title.Text,txt_auther.Text,comboBox1.Text,txt_price.Text,txt_date.Value.ToString(),txt_rate.Value,ma);
            //        PL.FRM_DADD Fadd = new FRM_DADD();
            //        Fadd.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MemoryStream ma = new MemoryStream();
            //        cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);

            //        BL.CLS_BOOKS BLCAT = new BL.CLS_BOOKS();
            //        BLCAT.update(txt_title.Text, txt_auther.Text, comboBox1.Text, txt_price.Text, txt_date.Value.ToString(), txt_rate.Value, ma,ID);
            //        PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
            //        fEDIT.Show();
            //        this.Close();
            //    }

            //}

        }

        private void Lb_Title_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {

            if (txt_title.Text == "")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                   
                    //ADD
                    BL.CLS_SELL BLSEEL = new BL.CLS_SELL();
                    BLSEEL.Insert(Convert.ToString( dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value),Convert.ToInt32(txt_title.Text),Convert.ToString(txt_date.Value));
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {

                    BL.CLS_SELL BLSEEL = new BL.CLS_SELL();
                    BLSEEL.upadte(Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToInt32(txt_title.Text), Convert.ToString(txt_date.Value),ID);
                    PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }

            }

        }
    }
}
