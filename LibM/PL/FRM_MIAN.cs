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
using System.Runtime.InteropServices;

namespace LibM.PL
{
    public partial class FRM_MIAN : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (

       int nLeft,
       int nTop,
       int nRight,
       int nBottom,
       int nWidthEllispe,
       int nHeighEllipse
           );




        // $$$
        string State;
        int ID;
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
        public FRM_MIAN()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
          //  Environment.Exit(0);
            Application.Exit();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //DET BOOKS
            if (State == "BOOKS")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTHER"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    PL.FRM_DETBOOKS DETBOOKS = new FRM_DETBOOKS();
                    DETBOOKS.txt_title.Text = obj1.ToString();
                    DETBOOKS.txt_auther.Text = obj2.ToString();
                    DETBOOKS.txt_cat.Text = obj3.ToString();
                    DETBOOKS.txt_price.Text = obj4.ToString();
                    DETBOOKS.txt_date.Value = (DateTime)obj5;
                    DETBOOKS.txt_rate.Value = (int)obj6;
                    //Load Image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    DETBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(DETBOOKS);

                }
                catch { }

            }
            //Edit Student
            else if (State == "ST")
            {
                try
                {
                    PL.FRM_DETST FST = new FRM_DETST();
                    DataTable dt = new DataTable();
                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["NAME"];
                    object obj2 = dt.Rows[0]["TLOACTION"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["DEP"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FST.txt_name.Text = obj1.ToString();
                    FST.txt_location.Text = obj2.ToString();
                    FST.txt_phone.Text = obj3.ToString();
                    FST.txt_email.Text = obj4.ToString();
                    FST.txt_school.Text = obj5.ToString();
                    FST.txt_dept.Text = obj6.ToString();
                    //Load Image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FST);

                }
                catch { }


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_serach.Visible = true;

            State = "CAT";
            Lb_Title.Text = "الاصناف";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الصنف";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FRM_MIAN_Load(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_Main.Visible = false;
            Lb_Title.Text = "الرئيسة";


            button8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 20, 20));
            button9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 20, 20));
            button10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 20, 20));
            button11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 20, 20));
            button12.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button8.Width, button8.Height, 20, 20));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Add Category
            if (State == "CAT")
            {
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "اضافة";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);
            }
            //Add BOOKS
            if (State == "BOOKS")
            {
                PL.FRM_ADDBOKKS FBOOKS = new FRM_ADDBOKKS();
                FBOOKS.btnadd.ButtonText = "اضافة";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);
            }
            //Add STUDNTS
            if (State == "ST")
            {
                PL.FRM_ADDSTUDNET FBOOKS = new FRM_ADDSTUDNET();
                FBOOKS.btnadd.ButtonText = "اضافة";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);
            }
            //Add SELL
            if (State == "SELL")
            {
                PL.FRM_MAKESELL FSELL = new FRM_MAKESELL();
                FSELL.btnadd.ButtonText = "اضافة";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);
            }
            //Add BOR
            if (State == "BOR")
            {
                PL.FRM_BRO FSELL = new FRM_BRO();
                FSELL.btnadd.ButtonText = "اضافة";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);
            }
            //Add USER
            if (State == "US")
            {
                PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                FUSER.btnadd.ButtonText = "اضافة";
                FUSER.ID = 0;
                bunifuTransition1.ShowSync(FUSER);
            }
        }

        private void FRM_MIAN_Activated(object sender, EventArgs e)
        {
            //For Check Number
            //Book
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.Load();
                lb_books.Text = dt.Rows.Count.ToString();


            }
            catch  { }
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
                dt = BLCAT .Load();
                lb_cat.Text = dt.Rows.Count.ToString();


            }
            catch { }
            // For Prem
            if (lb_name.Text == "مدير")
            {
                bunifuThinButton23.Enabled = true;
                button6.Enabled = true;

            }
            else
            {
                bunifuThinButton23.Enabled = false;
                button6.Enabled = false;

            }

            if (State == "CAT")
            {
                //Load Data Cat
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLCAT.Load();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الصنف";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(State == "BOOKS")
            {
                P_HOME.Visible = false;
                P_Main.Visible = true;
                bunifuThinButton24.Visible = true;
                State = "BOOKS";
                Lb_Title.Text = "الكتب";
                //Load Data
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.Load();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[2].HeaderText = "المؤلف";
                    dataGridView1.Columns[3].HeaderText = "التصنيف";
                    dataGridView1.Columns[4].HeaderText = "السعر";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "ST")
            {
                P_HOME.Visible = false;
                P_Main.Visible = true;
                bunifuThinButton24.Visible = true;
                State = "ST";
                Lb_Title.Text = "الطلاب";
                //Load Data
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLST.Load();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الطالب";
                    dataGridView1.Columns[2].HeaderText = "السكن";
                    dataGridView1.Columns[3].HeaderText = "رقم الهاتف";
                    dataGridView1.Columns[4].HeaderText = "ايميل";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (State == "SELL")
            {
                P_HOME.Visible = false;
                P_Main.Visible = true;
                bunifuThinButton24.Visible = false;
                State = "SELL";
                Lb_Title.Text = "البيع";
                //Load Data
                try
                {
                    DataTable dt = new DataTable();
                    dt = BSELL.Load();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[2].HeaderText = "المشتري";
                    dataGridView1.Columns[3].HeaderText = "السعر";
                    dataGridView1.Columns[4].HeaderText = "التاريخ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (State == "BOR")
            {
                P_HOME.Visible = false;
                P_Main.Visible = true;
                bunifuThinButton24.Visible = false;
                State = "BOR";
                Lb_Title.Text = "الاستعارة";
                //Load Data
                try
                {
                    DataTable dt = new DataTable();
                    dt = BRO.Load();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المشتري";
                    dataGridView1.Columns[2].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[3].HeaderText = "بداية الاستعارة";
                    dataGridView1.Columns[4].HeaderText = "نهايةالاستعارة";
                    dataGridView1.Columns[5].HeaderText = "السعر";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (State == "US")
                {
                    P_HOME.Visible = false;
                    P_Main.Visible = true;
                    bunifuThinButton24.Visible = false;
                    Lb_Title.Text = "المستخدمين";
                    //Load Data
                    try
                    {
                        DataTable dt = new DataTable();
                        dt = BLUSER.Load();
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم الكامل";
                        dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
                        dataGridView1.Columns[3].HeaderText = "كلمة السر";
                        dataGridView1.Columns[4].HeaderText = "الصلاحية";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //Edit Category
            if (State == "CAT")
            {
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "تعديل";
                FCAT.txt_catname.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                FCAT.ID=Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                bunifuTransition1.ShowSync(FCAT);
            }
            //Edit Books
            else if(State == "BOOKS")
            {
                try
                {
                    PL.FRM_ADDBOKKS FBOOKS = new FRM_ADDBOKKS();
                    FBOOKS.btnadd.ButtonText = "تعديل";
                    FBOOKS.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTHER"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FBOOKS.txt_title.Text = obj1.ToString();
                    FBOOKS.txt_auther.Text = obj2.ToString();
                    FBOOKS.comboBox1.Text = obj3.ToString();
                    FBOOKS.txt_price.Text = obj4.ToString();
                    FBOOKS.txt_date.Value = (DateTime)obj5;
                    FBOOKS.txt_rate.Value = (int)obj6;
                    //Load Image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FBOOKS);

                }
                catch { }
               

            }
            //Edit Student
            else if (State == "ST")
            {
                try
                {
                    PL.FRM_ADDSTUDNET FST = new FRM_ADDSTUDNET();
                    FST.btnadd.ButtonText = "تعديل";
                    FST.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["NAME"];
                    object obj2 = dt.Rows[0]["TLOACTION"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["DEP"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FST.txt_name.Text = obj1.ToString();
                    FST.txt_loaction.Text = obj2.ToString();
                    FST.txt_phone.Text = obj3.ToString();
                    FST.txt_email.Text = obj4.ToString();
                    FST.txt_school.Text = obj5.ToString();
                    FST.txt_dept.Text = obj6.ToString();
                    //Load Image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FST);

                }
                catch { }


            }
            else if (State == "SELL")
            {
                try
                {
                    PL.FRM_MAKESELL FST = new FRM_MAKESELL();
                    FST.btnadd.ButtonText = "تعديل";
                    FST.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    
                    bunifuTransition1.ShowSync(FST);

                }
                catch { }


            }
            else if (State == "BOR")
            {
                try
                {
                    PL.FRM_BRO FST = new FRM_BRO();
                    FST.btnadd.ButtonText = "تعديل";
                    FST.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);

                    bunifuTransition1.ShowSync(FST);

                }
                catch { }


            }
            else if (State == "US")
            {
                try
                {
                    PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                    FUSER.btnadd.ButtonText = "تعديل";
                    FUSER.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);

                    bunifuTransition1.ShowSync(FUSER);

                }
                catch { }


            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //Delete Category
            if (State == "CAT")
            {
                BLCAT.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();


            }
            //DELETE BOOKS
            else if(State == "BOOKS")
            {
                BLBOOKS.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            //DELETE Studnet
            else if (State == "ST")
            {
                BLST.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            //DELETE SELL
            else if (State == "SELL")
            {
                BSELL.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            //DELETE BOR
            else if (State == "BOR")
            {
                BRO.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            //DELETE USER
            else if (State == "US")
            {
                BLUSER.Delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //Search Category
            if (State == "CAT")
            {
                DataTable dt = new DataTable();
                dt =BLCAT.serach(txt_serach.Text);
               
                dataGridView1.DataSource = dt;

            }
            //Search BOOKS
            if (State == "BOOKS")
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.serach(txt_serach.Text);

                dataGridView1.DataSource = dt;

            }
            //Search STUDENT
            if (State == "ST")
            {
                DataTable dt = new DataTable();
                dt = BLST.serach(txt_serach.Text);

                dataGridView1.DataSource = dt;

            }
            //Search SELL
            if (State == "SELL")
            {
                DataTable dt = new DataTable();
                dt = BSELL.serach(txt_serach.Text);

                dataGridView1.DataSource = dt;

            }
            //Search BOR
            if (State == "BOR")
            {
                DataTable dt = new DataTable();
                dt = BRO.serach(txt_serach.Text);

                dataGridView1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_serach.Visible = true;

            State = "SELL";
            Lb_Title.Text = "البيع";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BSELL.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[2].HeaderText = "المشتري";
                dataGridView1.Columns[3].HeaderText = "السعر";
                dataGridView1.Columns[4].HeaderText = "التاريخ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            PL.FRM_LOGIN Login = new FRM_LOGIN();
            BLUSER.logout();
            this.Hide();
            Login.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Add Category
           
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "اضافة";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Add BOOKS
            
                PL.FRM_ADDBOKKS FBOOKS = new FRM_ADDBOKKS();
                FBOOKS.btnadd.ButtonText = "اضافة";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Add STUDNTS
           
                PL.FRM_ADDSTUDNET FBOOKS = new FRM_ADDSTUDNET();
                FBOOKS.btnadd.ButtonText = "اضافة";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);
            
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            //Add SELL
           
                PL.FRM_MAKESELL FSELL = new FRM_MAKESELL();
                FSELL.btnadd.ButtonText = "اضافة";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);
            
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            //Add BOR
           
                PL.FRM_BRO FSELL = new FRM_BRO();
                FSELL.btnadd.ButtonText = "اضافة";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);
            
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            PL.FRM_REPORT Report = new FRM_REPORT();
          
            Report.Show();
        }

        private void P_MB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            if (P_MB.Size.Width == 250)
            {
                P_MB.Width = 70;
                //    button13.RightToLeft = RightToLeft.Yes;
                //    button14.RightToLeft = RightToLeft.Yes;
                //    button15.RightToLeft = RightToLeft.Yes;
                //    button16.RightToLeft = RightToLeft.Yes;
                //    button18.RightToLeft = RightToLeft.Yes;
                //    button17.RightToLeft = RightToLeft.Yes;
                //    button2.RightToLeft = RightToLeft.Yes;
                //    button3.RightToLeft = RightToLeft.Yes;
                //    button4.RightToLeft = RightToLeft.Yes;
                //    button5.RightToLeft = RightToLeft.Yes;
                //    button6.RightToLeft = RightToLeft.Yes;
                //    button7.RightToLeft = RightToLeft.Yes;
                //    button19.RightToLeft = RightToLeft.Yes;
                //    button20.RightToLeft = RightToLeft.Yes;
                //    button21.RightToLeft = RightToLeft.Yes;

                //    button14.Padding = new Padding(10,0,10,0);
                //    button13.Padding = new Padding(20, 0, 10, 0);
                //    button17.Padding = new Padding(20, 0, 10, 0);
                //    button18.Padding = new Padding(20, 0, 10, 0);
                //    button5.Padding = new Padding(20, 0, 10, 0);
                //    button4.Padding = new Padding(20, 0, 10, 0);


                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button13.Text = "";
                button14.Text = "";
                button15.Text = "";
                button16.Text = "";
                button17.Text = "";
                button18.Text = "";
                button19.Text = "";
                button20.Text = "";
                button21.Text = "";

                lb_prem.Visible = false;
                lb_name.Visible = false;
                pictureBox1.Visible = false;
            }
            else
            {
                P_MB.Width = 250;
                //    button13.RightToLeft = RightToLeft.No;
                //    button14.RightToLeft = RightToLeft.No;
                //    button15.RightToLeft = RightToLeft.No;
                //    button16.RightToLeft = RightToLeft.No;
                //    button18.RightToLeft = RightToLeft.No;
                //    button17.RightToLeft = RightToLeft.No;
                //    button2.RightToLeft = RightToLeft.No;
                //    button3.RightToLeft = RightToLeft.No;
                //    button4.RightToLeft = RightToLeft.No;
                //    button5.RightToLeft = RightToLeft.No;
                //    button6.RightToLeft = RightToLeft.No;
                //    button7.RightToLeft = RightToLeft.No;
                //    button19.RightToLeft = RightToLeft.No;
                //    button20.RightToLeft = RightToLeft.No;
                //    button21.RightToLeft = RightToLeft.No;

                //    button14.Padding = new Padding(10, 0, 35, 0);
                //    button13.Padding = new Padding(20, 0, 35, 0);
                //    button17.Padding = new Padding(20, 0, 35, 0);
                //    button18.Padding = new Padding(20, 0, 35, 0);
                //    button5.Padding = new Padding(20, 0, 35, 0);
                //    button4.Padding = new Padding(20, 0, 35, 0);


                button2.Text = "الرئيسية";
                button3.Text = "<  الأقسام والرفوف";
                button4.Text = "الأقسام";
                button5.Text = "الرفوف";
                button6.Text = "المقتنيات";
                button7.Text = "<  المرجوعات والاعارات";
                button13.Text = "المرجوعات";
                button14.Text = "الاعارات";
                button15.Text = "الزيارات";
                button16.Text = "<  الطلاب والزائرين";
                button17.Text = "الزائرين";
                button18.Text = "الطلاب";
                button19.Text = "الحجوزات";
                button20.Text = "المكتبة الالكترونية";
                button21.Text = "المستخدمين";

                lb_prem.Visible = true;
                lb_name.Visible = true;
                pictureBox1.Visible = true;
            }
        }


        private void customizeDesign()
        {
            p_dept_shelf.Visible = false;
            p_borr_return.Visible = false;
            p_std_vistor.Visible = false;
           
        }

        public void hidesubnenu()
        {
            if (p_borr_return.Visible == true)
                p_borr_return.Visible = false;


            if (p_dept_shelf.Visible == true)
                p_dept_shelf.Visible = false;

            if (p_std_vistor.Visible == true)
                p_std_vistor.Visible = false;
        }

        private void showsubmenu(Panel submenu)
        {
            
            if (submenu.Visible == false)
            {
                hidesubnenu();
                submenu.Visible = true;
            }

            else
            {
                submenu.Visible = false;
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            showsubmenu(p_dept_shelf);
        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            showsubmenu(p_borr_return);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            showsubmenu(p_std_vistor);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
        
            hidesubnenu();


            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_serach.Visible = true;

            State = "BOR";
            Lb_Title.Text = "الاستعارة";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BRO.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المشتري";
                dataGridView1.Columns[2].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[3].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[4].HeaderText = "نهايةالاستعارة";
                dataGridView1.Columns[5].HeaderText = "السعر";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button18_Click(object sender, EventArgs e)
        {
         
            hidesubnenu();



            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = true;
            txt_serach.Visible = true;

            State = "ST";
            Lb_Title.Text = "الطلاب";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الطالب";
                dataGridView1.Columns[2].HeaderText = "السكن";
                dataGridView1.Columns[3].HeaderText = "رقم الهاتف";
                dataGridView1.Columns[4].HeaderText = "ايميل";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            hidesubnenu();


            P_HOME.Visible = true;
            P_Main.Visible = false;
            Lb_Title.Text = "الرئيسة";
           
        
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
           
            hidesubnenu();


            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = true;
            txt_serach.Visible = true;
            State = "BOOKS";
            Lb_Title.Text = "الكتب";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[2].HeaderText = "المؤلف";
                dataGridView1.Columns[3].HeaderText = "التصنيف";
                dataGridView1.Columns[4].HeaderText = "السعر";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            // code
            //
            //
            hidesubnenu();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            hidesubnenu();

            P_HOME.Visible = false;
            P_Main.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_serach.Visible = false;

            State = "US";
            Lb_Title.Text = "المستخدمين";
            //Load Data
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.Load();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكامل";
                dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
                dataGridView1.Columns[3].HeaderText = "كلمة السر";
                dataGridView1.Columns[4].HeaderText = "الصلاحية";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void P_HOME_Paint(object sender, PaintEventArgs e)
        {

        }

        private void P_TB_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
