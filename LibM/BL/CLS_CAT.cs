using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibM.BL
{
    class CLS_CAT
    {
        
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        //Load Data
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADCAT", pr);
            return dt;
        }
        //search
        public DataTable serach(string search)
        {
            SqlParameter[]pr =new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);

            DataTable dt = new DataTable();
            dt = DAL.read("P_CATSEARCH", pr);
            return dt;
        }
        // INSERT DATA
        public void Insert(string CAT_NAME)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            DAL.open();
            DAL.Excute("P_ADDCAT", pr);
            DAL.close();
        }
        // UPDATE DATA
        public void update(string CAT_NAME,int ID)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            pr[1] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_EDITCAT", pr);
            DAL.close();
        }
        // Delete DATA
        public void Delete( int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_DELETECAT", pr);
            DAL.close();
        }

    }
}
