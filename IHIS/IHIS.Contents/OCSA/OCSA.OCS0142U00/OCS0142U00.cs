#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
    public partial class OCS0142U00 : IHIS.Framework.XScreen
    {

        #region 생성자

        public OCS0142U00()
        {
            InitializeComponent();

            //저장 수행자 Set
            this.grdOCS0142.SavePerformer = new XSaverPerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOCS0142);

            grdOCS0142.QueryLayout(false);
        }
        #endregion
        
        #region 초기화

        private void InitScreen()
        {
            this.cboSystem.SelectedIndex = 0;
        }

        #endregion

        #region [Control Event]

        private void grdOCS0142_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS0142.SetBindVarValue("f_input_tab", cboSystem.GetDataValue());
            this.grdOCS0142.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void cboSystem_SelectedValueChanged(object sender, EventArgs e)
        {
            this.grdOCS0142.QueryLayout(false);
        }

        private void grdOCS0142_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            int currRow = this.grdOCS0142.CurrentRowNumber;

            switch (e.ColName)
            {
                case "input_tab":
                    if (CurrMSLayout == grdOCS0142)
                    {
                        this.grdOCS0142.SetItemValue(currRow, "input_tab_name", e.ReturnValues[1]);
                    }
                    break;

                case "order_gubun":
                    this.grdOCS0142.SetItemValue(currRow, "order_gubun_name", e.ReturnValues[1]);
                    break;
            }
        }

        private void OCS0142U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 초기화
            this.InitScreen();

        }

        #endregion

        #region [Button List Event]
        private void btlList_ButtonClick(object sender, ButtonClickEventArgs e)
        {

            switch (e.Func)
            {
                case FunctionType.Insert:

                    break;

                case FunctionType.Delete:
                    if (this.CurrMQLayout == this.grdOCS0142)
                    {
                        DialogResult result = XMessageBox.Show("INPUT_TAB : 「" + grdOCS0142.GetItemString(grdOCS0142.CurrentRowNumber, "input_tab") +
                            "」\r\n" + "ORDER_GUBUN : 「" + grdOCS0142.GetItemString(grdOCS0142.CurrentRowNumber, "order_gubun")
                            + "」を本当に削除しますか？", "確認", MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                            e.IsBaseCall = false;
                    }
					break;

                case FunctionType.Update:

                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [XSavePerformer]
        private class XSaverPerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0142U00 parent = null;

            public XSaverPerformer(OCS0142U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:

                       cmdText = @"SELECT 'Y' 
                                     FROM SYS.DUAL
                                    WHERE EXISTS ( SELECT 'X'
                                                     FROM OCS0142 A
                                                    WHERE A.HOSP_CODE   = :f_hosp_code 
                                                      AND A.INPUT_TAB   = :f_input_tab
                                                      AND A.ORDER_GUBUN = :f_order_gubun )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("INPUT_TAB : 「" + item.BindVarList["f_input_tab"].VarValue + "」\r\n" +
                                                         "ORDER_GUBUN : 「" + item.BindVarList["f_order_gubun"].VarValue + "」\r\n" +
                                                         "は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                        cmdText = @"INSERT INTO OCS0142
                                      ( SYS_DATE
                                       , UPD_ID
                                       , UPD_DATE
                                       , INPUT_TAB
                                       , ORDER_GUBUN
                                       , MAIN_YN
                                       , DEFAULT_YN
                                       , SYS_ID
                                       , HOSP_CODE 
                                      )
                                      VALUES
                                       　( SYSDATE
                                         , :f_user_id
                                         , SYSDATE
                                         , :f_input_tab
                                         , :f_order_gubun
                                         , NVL(:f_main_yn    , 'N')
                                         , NVL(:f_default_yn , 'N')
                                         , :f_user_id
                                         , :f_hosp_code
                               )";
                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0142
                                       SET UPD_DATE      = SYSDATE,
                                           UPD_ID       = :f_user_id, 
                                           INPUT_TAB    = :f_input_tab,
                                           ORDER_GUBUN  = :f_order_gubun,
                                           MAIN_YN      = NVL(:f_main_yn    , 'N'),
                                           DEFAULT_YN   = NVL(:f_default_yn , 'N')
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND INPUT_TAB    = :f_input_tab
                                       AND ORDER_GUBUN  = :f_order_gubun";

                        break;

                    case DataRowState.Deleted:

                        cmdText = @"DELETE OCS0142
                                      WHERE HOSP_CODE   = :f_hosp_code
                                        AND INPUT_TAB   = :f_input_tab
                                        AND ORDER_GUBUN = :f_order_gubun";
                        break;

                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
     
        
    }
}