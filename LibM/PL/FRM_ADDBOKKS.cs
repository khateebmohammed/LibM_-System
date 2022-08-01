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
    public partial class FRM_ADDBOKKS : Form
    {
        
        public int ID;
        public FRM_ADDBOKKS()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            var result = OFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                cover.Image = Image.FromFile(OFD.FileName);
            }
        }

        private void FRM_ADDBOKKS_Load(object sender, EventArgs e)
        {
            try
            {
                BL.CLS_BOOKS BLBOOKS = new BL.CLS_BOOKS();
                DataTable dt = new DataTable();
                dt = BLBOOKS.LOADCAT();
                object[] obj = new object[dt.Rows.Count];
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    obj[i] = dt.Rows[i]["CAT_NAME"];
                }
                comboBox1.Items.AddRange(obj);

            }
            catch { }
     
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
            FCAT.btnadd.ButtonText = "اضافة";
            FCAT.ID = 0;
            FCAT.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_title.Text=="" || txt_auther.Text=="" || txt_price.Text=="")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                    MemoryStream ma = new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //ADD
                    BL.CLS_BOOKS BLCAT =new BL.CLS_BOOKS() ;
                    BLCAT.Insert(txt_title.Text,txt_auther.Text,comboBox1.Text,txt_price.Text,txt_date.Value.ToString(),txt_rate.Value,ma);
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {
                    MemoryStream ma = new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);

                    BL.CLS_BOOKS BLCAT = new BL.CLS_BOOKS();
                    BLCAT.update(txt_title.Text, txt_auther.Text, comboBox1.Text, txt_price.Text, txt_date.Value.ToString(), txt_rate.Value, ma,ID);
                    PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }

            }

        }
    }
}
