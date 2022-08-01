using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LibM.BL
{
    class CLS_SELL
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        //Load Data
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADSELL", pr);
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
        public void Insert(string SNAME, string BTITLE, int PRICE, string BDATE)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);
            DAL.open();
            DAL.Excute("PR_INSERTSELL", pr);
            DAL.close();
        }
        // UPDATE DATA
        public void upadte(string SNAME, string BTITLE, int PRICE, string BDATE,int ID)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);
            pr[4] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_UPDATERTSELL", pr);
            DAL.close();
        }
        // Delete DATA
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_SELLDELETE", pr);
            DAL.close();
        }
        //search
        public DataTable serach(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SERACH", search);

            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELLSERACH", pr);
            return dt;
        }
    }
}
