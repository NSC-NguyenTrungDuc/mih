#region ｻ鄙・NameSpace ﾁ､
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.NURI;
using System.Net.Sockets;
using System.Net;
using System.Text;
#endregion


namespace IHIS.NURI
{
    public partial class EtcIpwon : IHIS.Framework.XForm
    {

        private string etcIpwonDate = "";
        private string mIpwonDate = "";
        private string mToiwonDate = "";

        public EtcIpwon(string bunho, string ipwon_date, string retrieve_yn)
        {
            InitializeComponent();

            this.grdHistory.SavePerformer = new XSavePerformer(this);
            
            mIpwonDate = ipwon_date;

            this.paBox.SetPatientID(bunho);

        }

        public string EtcIpwonDate
        {
            get { return mIpwonDate; }
        }

        public string EtcToiwonDate
        {
            get { return mToiwonDate; }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    int rowNum = this.grdHistory.InsertRow(0);

                    this.grdHistory.SetItemValue(rowNum, "ipwon_type", "7");

                    DateTime t_toiwon_date = Convert.ToDateTime(this.mIpwonDate).AddDays(-1);

                    this.grdHistory.SetItemValue(rowNum, "toiwon_date", t_toiwon_date.ToString("yyyy/MM/dd"));

                    SetProtect();

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    for (int i = 0; i < this.grdHistory.RowCount; i++)
                    {
                        // null check
                    }

                    if (this.grdHistory.SaveLayout())
                    {
                        XMessageBox.Show("保存が完了しました。", "保存完了", MessageBoxIcon.Information);
                        this.mIpwonDate = this.dtpIpwonDate.GetDataValue();
                        this.mToiwonDate = this.dtpToiwonDate.GetDataValue();
                        this.Close();

                    }
                    else
                    {
                        XMessageBox.Show("保存に失敗しました。\r\n" + Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                    }

                    break;

                case FunctionType.Query:
                    this.grdHistory.QueryLayout(false);
                    break;

                case FunctionType.Delete:

                    if(this.grdHistory.GetItemString(this.grdHistory.CurrentRowNumber, "ipwon_type") != "7")
                    {
                        e.IsBaseCall = false;

                    }

                    break;

                case FunctionType.Close:

                    break;
            }
        }

        private void fwkGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkGubun.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            fwkGubun.BindVarList.Add("f_bunho", this.paBox.BunHo);
            fwkGubun.BindVarList.Add("f_naewon_date", this.dtpIpwonDate.GetDataValue());
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.grdHistory.QueryLayout(false);
        }

        private void grdHistory_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHistory.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void cboGwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.layCommonDoctor.QueryLayout();
        }

        private void layCommonDoctor_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommonDoctor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCommonDoctor.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
        }

        private void grdHistory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this.grdHistory.GetHitRowNumber(e.Y) > -1)
                {
                    this.mIpwonDate = this.grdHistory.GetItemString(this.grdHistory.GetHitRowNumber(e.Y), "ipwon_date");
                    this.mToiwonDate = this.grdHistory.GetItemString(this.grdHistory.GetHitRowNumber(e.Y), "toiwon_date");
                    this.Close();
                }
            }
        }

        private class XSavePerformer : ISavePerformer
        {
            EtcIpwon parent;
            public XSavePerformer(EtcIpwon parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                //item.BindVarList.Add("f_ipwon_type", "7");
                item.BindVarList.Add("f_ho_code1", "etcC");
                item.BindVarList.Add("f_ho_dong1", "etcD");
                item.BindVarList.Add("f_bunho", parent.paBox.BunHo);
                item.BindVarList.Add("f_doctor", parent.txtDoctor.GetDataValue());

                switch (item.RowState)
                { 
                    case DataRowState.Added:
                        cmdText = @"SELECT INP1001_SEQ.NEXTVAL FROM DUAL";

                        object retVal = null;
                        retVal = Service.ExecuteScalar(cmdText);
                        if (TypeCheck.IsNull(retVal))
                        {
                            XMessageBox.Show("INP1001_SEQ.NEXTVAL Error");
                            return false;
                        }

                        item.BindVarList.Add("f_pkinp1001", retVal.ToString());

                        cmdText = @"INSERT INTO INP1001
                                            ( SYS_DATE          , SYS_ID            , UPD_DATE          , UPD_ID
                                            , HOSP_CODE         , PKINP1001         , BUNHO             , IPWON_DATE
                                            , IPWON_TYPE        , IPWON_TIME        , GWA               , DOCTOR            , RESIDENT          
                                            , HO_CODE1          , HO_DONG1          , FK_INP_KEY        , TOIWON_DATE
                                            , JAEWON_FLAG        )
                                       VALUES
                                            ( SYSDATE           , :f_user_id        , SYSDATE           , :f_user_id
                                            , :f_hosp_code      , :f_pkinp1001      , :f_bunho          , :f_ipwon_date
                                            , :f_ipwon_type     , '1200'            , :f_gwa            , :f_doctor        , :f_doctor     
                                            , :f_ho_code1       , :f_ho_dong1       , :f_pkinp1001      , :f_toiwon_date
                                            , 'N'                )";
                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE INP1001
                                          SET UPD_ID                = :f_user_id
                                            , UPD_DATE              = SYSDATE
                                            , GWA                   = :f_gwa
                                            , DOCTOR                = :f_doctor
                                            , RESIDENT              = :f_doctor
                                            , TOIWON_DATE           = :f_toiwon_date
                                        WHERE HOSP_CODE             = :f_hosp_code
                                          AND PKINP1001             = :f_pkinp1001";

                        break;

                    case DataRowState.Deleted:

                        cmdText = @"UPDATE INP1001
                                          SET UPD_ID          = :f_user_id
                                            , UPD_DATE        = SYSDATE
                                            , CANCEL_DATE     = TRUNC(SYSDATE)
                                            , CANCEL_USER     = :f_user_id
                                            , CANCEL_YN       = 'Y'
                                        WHERE HOSP_CODE       = :f_hosp_code
                                          AND PKINP1001       = :f_pkinp1001";

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        private void grdHistory_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //SetProtect();
        }

        private void SetProtect()
        {
            if (this.grdHistory.RowCount < 1)
            {
                this.dtpIpwonDate.Protect = true;
                this.dtpToiwonDate.Protect = true;
                this.cboGwa.Protect = true;
            }
            else
            {
                if (this.grdHistory.CurrentRowNumber > -1)
                {
                    this.dtpIpwonDate.Protect = false;
                    this.dtpToiwonDate.Protect = false;
                    this.cboGwa.Protect = false;
                
                }

                //if (this.grdHistory.GetItemString(this.grdHistory.CurrentRowNumber, "ipwon_date") == this.mIpwonDate)
                if (this.grdHistory.GetItemString(this.grdHistory.CurrentRowNumber, "ipwon_type") != "7")
                {
                    this.dtpIpwonDate.Protect = true;
                    this.dtpToiwonDate.Protect = true;
                    this.cboGwa.Protect = true;                
                }
            }
        }

        private void grdHistory_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            SetProtect();
        }

        private void grdHistory_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //if (e.DataRow["ipwon_date"].ToString() == this.mIpwonDate)
                if (e.DataRow["ipwon_type"].ToString() != "7")
                {
                    e.ForeColor = Color.LightGray;
                }

        }

    }
}