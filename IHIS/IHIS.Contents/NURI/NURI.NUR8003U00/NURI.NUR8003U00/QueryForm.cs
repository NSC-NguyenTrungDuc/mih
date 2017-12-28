using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.NURI
{
    public partial class QueryForm : IHIS.Framework.XForm
    {
        
        string hosp_code = string.Empty;
        string fkinp1001 = string.Empty;
        string bunho = string.Empty;
        string write_date = string.Empty;
        
        public QueryForm()
        {
            InitializeComponent();
        }

        public QueryForm(string i_hosp_code, string i_bunho, string i_fkinp1001, string i_write_date)
        {
            hosp_code = i_hosp_code;
            bunho = i_bunho;
            fkinp1001 = i_fkinp1001;
            write_date = i_write_date;

            InitializeComponent();
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            paBox.SetPatientID(bunho);
            grdSyochi.QueryLayout(true);
            grdBP.QueryLayout(true);
        }

        private void grdSyochi_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSyochi.SetBindVarValue("f_hosp_code", hosp_code);
            grdSyochi.SetBindVarValue("f_bunho", paBox.BunHo);
            grdSyochi.SetBindVarValue("f_fkinp1001", fkinp1001);
            grdSyochi.SetBindVarValue("f_write_date", write_date);
        }

        private void grdBP_QueryStarting(object sender, CancelEventArgs e)
        {
            grdSyochi.SetBindVarValue("f_hosp_code", hosp_code);
            grdSyochi.SetBindVarValue("f_bunho", paBox.BunHo);
            grdSyochi.SetBindVarValue("f_fkinp1001", fkinp1001);
            grdSyochi.SetBindVarValue("f_write_date", write_date);
        }

        private void grdSyochi_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            grdSyochi.DisplayData();
        }       
    }
}