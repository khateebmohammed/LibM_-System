﻿using System;
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
    public partial class FRM_START : Form
    {
        public FRM_START()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BL.CLS_USERS userfrm = new BL.CLS_USERS();
            DataTable dt = new DataTable();
            dt = userfrm.STARTLOADDTA();
            if (dt.Rows.Count > 0)
            {
                PL.FRM_MIAN frmmain = new FRM_MIAN();
                object lbname = dt.Rows[0]["CNAME"];
                object lbprem = dt.Rows[0]["CPREM"];
                frmmain.lb_prem.Text = lbname.ToString();
                frmmain.lb_name.Text = lbprem.ToString();
                frmmain.Show();
                this.Hide();
                timer1.Enabled = false;
            }
            else
            {
                PL.FRM_LOGIN frmlogin = new FRM_LOGIN();
                frmlogin.Show();
                this.Hide();
                timer1.Enabled = false;

            }

        }
    }
}
