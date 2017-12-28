using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
    public partial class OCS2005R01 : IHIS.Framework.XScreen
    {
        public OCS2005R01()
        {
            InitializeComponent();
        }

        #region Function

        private void InitScreen()
        {
            this.dtpQryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.cboHoDong.SelectedIndex = 0;
            this.cboKiGubun.SelectedIndex = 0;
        }

        #endregion

        #region Data Load

        private void LoadData(string aQueryDate, string aHoDong, string aKiGubun)
        {
            this.grdSiksa.SetBindVarValue("f_query_date", aQueryDate);
            this.grdSiksa.SetBindVarValue("f_ho_dong", aHoDong);
            this.grdSiksa.SetBindVarValue("f_ki_gubun", aKiGubun);

            this.grdSiksa.QueryLayout(true);
        }

        #endregion

        #region XButton List

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.LoadData(this.dtpQryDate.GetDataValue(), this.cboHoDong.GetDataValue(), this.cboKiGubun.GetDataValue());

                    break;

                case FunctionType.Print:

                    e.IsBaseCall = false;

                    if (this.grdSiksa.RowCount == 0)
                        return;

                    try
                    {
                        this.dwPrint.Reset();
                        this.dwPrint.FillData(this.grdSiksa.LayoutTable);

                        this.dwPrint.Print();
                    }
                    catch
                    {
                    }

                    break;
            }
        }

        #endregion

        private void OCS2005R01_Load(object sender, EventArgs e)
        {
            this.InitScreen();
        }

        private void btnSiksaPrint_Click(object sender, EventArgs e)
        {
            if (this.grdSiksa.CurrentRowNumber < 0) return;

            this.OpenScreen_OCS2005R02(this.grdSiksa.GetItemString(this.grdSiksa.CurrentRowNumber, "bunho")
                                      , this.grdSiksa.GetItemString(this.grdSiksa.CurrentRowNumber, "pkinp1001")
                                      , this.dtpQryDate.GetDataValue(), this.cboKiGubun.GetDataValue());
        }

        private void OpenScreen_OCS2005R02(string aBunho, string aFkinp1001, string aQueryDate, string aKiGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("pkinp1001", aFkinp1001);
            param.Add("date", aQueryDate);
            param.Add("ki_gubun", aKiGubun);
            param.Add("print_mode", true);

            XScreen.OpenScreenWithParam(this, "NURI", "OCS2005R02", ScreenOpenStyle.ResponseFixed, param);
        }

        private void dtpQryDate_TextChanged(object sender, EventArgs e)
        {
            this.LoadData(this.dtpQryDate.GetDataValue(), this.cboHoDong.GetDataValue(), this.cboKiGubun.GetDataValue());
        }

        private void cboHoDong_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadData(this.dtpQryDate.GetDataValue(), this.cboHoDong.GetDataValue(), this.cboKiGubun.GetDataValue());
        }
    }
}