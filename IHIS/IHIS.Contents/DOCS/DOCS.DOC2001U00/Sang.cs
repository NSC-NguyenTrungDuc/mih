using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.DOCS
{
    public partial class Sang : XForm
    {
        private string mBunho = "";

        private string sangname = "";

        private string mIOGubun = "I";

        public string Sangname
        {
            get { return sangname; }
        }
        

        public Sang()
		{
			InitializeComponent();
		}

        public Sang(string aBunho, string aIOGubun)
        {
            InitializeComponent();

            mBunho = aBunho;
            mIOGubun = aIOGubun;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.paBox.SetPatientID(mBunho);
            if (mIOGubun == "I")
            {
                this.tabIOGubun.SelectedTab = this.tabIOGubun.TabPages[1];
            }
            else
            {
                this.tabIOGubun.SelectedTab = this.tabIOGubun.TabPages[0];
            }
        }

        private void grdOutSang_MouseDown(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                this.setSangName();
            }
        }

        private void setSangName()
        {
            if (this.grdOutSang.CurrentRowNumber > -1)
            {
                sangname = this.grdOutSang.GetItemString(this.grdOutSang.CurrentRowNumber, "display_sang_name");
            }
            this.Close();
        }

        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOutSang.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdOutSang.SetBindVarValue("f_gwa", this.CboBuseo.GetDataValue());
            this.grdOutSang.SetBindVarValue("f_io_gubun", this.mIOGubun);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdOutSang.QueryLayout(true);
                    break;
                case FunctionType.Process:
                    this.setSangName();
                    break;
            }
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdOutSang.Reset();
        }

        private void tabIOGubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage page in tabIOGubun.TabPages)
            {
                if (tabIOGubun.SelectedTab == page)
                {
                    if(page.TabIndex == 0)
                    {
                        mIOGubun = "O";
                    }
                    else
                    {
                        mIOGubun = "I";
                    }
                }
                this.btnList.PerformClick(FunctionType.Query);
            }

        }

       
    }
}