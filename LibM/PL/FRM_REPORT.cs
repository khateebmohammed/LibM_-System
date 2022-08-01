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
    public partial class FRM_REPORT : Form
    {
        //Instance Of Categoray
        BL.CLS_CAT BLCAT = new BL.CLS_CAT();
        //Instance Of BOOKS
        BL.CLS_BOOKS BLBOOKS = new BL.CLS_BOOKS();
        //Instance Of STUDENT
        BL.CLS_ST BLST = new BL.CLS_ST();
        //Instance Of SELL
        BL.CLS_SELL BSELL = new BL.CLS_SELL();
        //Instance OF BRO
        BL.CLS_BOR BRO = new BL.CLS_BOR();
        //Instance OF USERS
        BL.CLS_USERS BLUSER = new BL.CLS_USERS();

        public FRM_REPORT()
        {
            InitializeComponent();
        }

        private void FRM_REPORT_Load(object sender, EventArgs e)
        {
            PL.FRM_MIAN Home = new FRM_MIAN();
            lb_name.Text = Home.lb_prem.Text;
            lb_perm.Text = Home.lb_name.Text;
            lb_date.Text = DateTime.Now.ToString();
            //
            //For Check Number
            //Book
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.Load();
                lb_books.Text = dt.Rows.Count.ToString();


            }
            catch { }
            //Studnt
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.Load();
                lb_studnt.Text = dt.Rows.Count.ToString();


            }
            catch { }
            //Sell
            try
            {
                DataTable dt = new DataTable();
                dt = BSELL.Load();
                lb_sell.Text = dt.Rows.Count.ToString();


            }
            catch { }
            //BOR
            try
            {
                DataTable dt = new DataTable();
                dt = BRO.Load();
                lb_bor.Text = dt.Rows.Count.ToString();


            }
            catch { }
            //User
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.Load();
                lb_user.Text = dt.Rows.Count.ToString();


            }
            catch { }
            //CAT
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.Load();
                lb_cat.Text = dt.Rows.Count.ToString();


            }
            catch { }

        }

        private void FRM_REPORT_Activated(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(img, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(img, 0, 0);
        }
    }
}
