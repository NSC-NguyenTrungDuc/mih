using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.BASS
{
    public partial class BAS0355U00 : IHIS.Framework.XScreen
    {
        public BAS0355U00()
        {
            InitializeComponent();
        }

        #region [ ========= Screen 이벤트 ========== ]

        private void BAS0355U00_Load(object sender, EventArgs e)
        {
            this.grdBAS0355.SavePerformer = new XSavePeformer(this);
            this.SaveLayoutList.Add(this.grdBAS0355);

            this.InitScreen();
        }

        #endregion

        #region [ ========== Function =========== ]

        private void InitScreen()
        {
            this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            this.cboAutoOccurGubun.SetDataValue("%");
        }

        #endregion

        #region [ ========== Data Load ========== ]

        private void LoadData()
        {
            this.grdBAS0355.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
            this.grdBAS0355.SetBindVarValue("f_auto_occur_gubun", this.cboAutoOccurGubun.GetDataValue());

            this.grdBAS0355.QueryLayout(false);
        }

        #endregion

        #region [ ========== Control Event ========== ]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    this.LoadData();

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    this.grdBAS0355.SaveLayout();

                    break;

                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    int newRow = this.grdBAS0355.InsertRow(this.grdBAS0355.CurrentRowNumber);

                    this.grdBAS0355.SetItemValue(newRow, "start_date", this.dtpQueryDate.GetDataValue());
                    this.grdBAS0355.SetItemValue(newRow, "end_date", "9998/12/31");
                    if (this.cboAutoOccurGubun.GetDataValue() != "%")
                        this.grdBAS0355.SetItemValue(newRow, "auto_occur_gubun", this.cboAutoOccurGubun.GetDataValue());

                    break;

                case FunctionType.Reset :

                    e.IsBaseCall = false;

                    this.Reset();

                    this.InitScreen();

                    break;
            }
        }

        #endregion

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0355U00 parent = null;

            public XSavePeformer(BAS0355U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0355
                                                             WHERE AUTO_OCCUR_GUBUN = :f_auto_occur_gubun
                                                               AND CONDITION        = :f_condition 
                                                               AND START_DATE       = :f_start_date )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_condition"].VarValue + "」は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"INSERT INTO BAS0355
                                                 ( SYS_DATE        ,   SYS_ID   ,   UPD_DATE      ,   UPD_ID
                                                 , AUTO_OCCUR_GUBUN,   CONDITION,   CONDITION_NAME,   START_DATE
                                                 , END_DATE        ,   SG_CODE  )
                                            VALUES(SYSDATE         , :q_user_id　   , SYSDATE     ,   :q_user_id
                                                 , :f_auto_occur_gubun, :f_condition, :f_condition_name, :f_start_date
                                                 , :f_end_date     , :f_sg_code )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0355
                                               SET USER_ID = :q_user_id
                                                 , UPD_DATE = SYSDATE
                                                 , CONDITION_NAME = :f_condition_name
                                                 , END_DATE = :f_end_date
                                                 , SG_CODE  = :f_sg_code
                                             WHERE AUTO_OCCUR_GUBUN = :f_auto_occur_gubun
                                               AND CONDITION = :f_condition
                                               AND START_DATE = :f_start_date ";

                                break;

                            case DataRowState.Deleted:


                                cmdText = @"DELETE FROM BAS0355
                                                WHERE AUTO_OCCUR_GUBUN = :f_auto_occur_gubun
                                               AND CONDITION = :f_condition
                                               AND START_DATE = :f_start_date ";

                                break;
                        }
                        break;

                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
    }


}