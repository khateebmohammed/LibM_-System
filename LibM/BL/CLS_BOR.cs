using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LibM.BL
{
    class CLS_BOR
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        //Load Data
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADBOR", pr);
            return dt;
        }
        //Load Data BOOKS
        public DataTable LoadBOOKS()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADBOOKFORSELL", pr);
            return dt;
        }
        //Load Data STUDENT
        public DataTable LoadST()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADSTFORSELL", pr);
            return dt;
        }
        // INSERT DATA
        public void Insert(string BNAME, string BTITLE,string BDATE1,string BDATE2 ,int PRICE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);
            DAL.open();
            DAL.Excute("PR_INSERTBOR", pr);
            DAL.close();
        }
        // UPADTE DATA
        public void update(string BNAME, string BTITLE, string BDATE1, string BDATE2, int PRICE,int ID)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);
            pr[5] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_EDITBRO", pr);
            DAL.close();
        }
        // Delete DATA
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_DELETEBOR", pr);
            DAL.close();
        }
        //search
        public DataTable serach(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SERACH", search);

            DataTable dt = new DataTable();
            dt = DAL.read("PR_BORSERACH", pr);
            return dt;
        }
    }
}
