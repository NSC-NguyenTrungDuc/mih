using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.DRGS
{
    public partial class AntibioticList : XForm
    {
        public AntibioticList()
        {
            InitializeComponent();
        }

        private void AntibioticList_Load(object sender, EventArgs e)
        {
            this.btnList.PerformClick(IHIS.Framework.FunctionType.Query);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdAntibioticList.QueryLayout(true);

                    break;

                case FunctionType.Close:
                    break;
            }
        }
    }
}
