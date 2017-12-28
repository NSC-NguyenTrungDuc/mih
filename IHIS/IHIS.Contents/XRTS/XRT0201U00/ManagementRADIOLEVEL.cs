using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.Framework;
using IHIS.XRTS.Properties;

namespace IHIS.XRTS
{
    public partial class ManagementRADIOLEVEL : XForm
    {
        public ManagementRADIOLEVEL()
        {
            InitializeComponent();
        }

        #region ÉVÉXÉeÉÄïœêî

        private string bunho = "";
        private string order_date = "";
        private string in_out_gubun = "";
        #endregion

        public ManagementRADIOLEVEL(string pbunho, string psuname, string psuname2, string pbirth, string psexAge, string porderDate, string in_out_gubun)
        {
            InitializeComponent();
            this.grdRadioList.SavePerformer = new XSavePerformer(this);
            this.SaveLayoutList.Add(this.grdRadioList);

            this.dbxBunho.Text = pbunho;
            this.dbxSuname.Text = psuname;
            this.dbxSuname2.Text = psuname2;

            this.dbxBirth.Text = pbirth;
            this.dbxSexAge.Text = psexAge;


            this.bunho = pbunho;
            this.order_date = porderDate;

            this.in_out_gubun = in_out_gubun;

            // cloud service
            grdRadioList.ParamList = CreateGrdRadioParamList();
            grdRadioList.ExecuteQuery = LoadGrdRadioList;
        }

        #region ManagementRADIOLEVEL_Load
        private void ManagementRADIOLEVEL_Load(object sender, EventArgs e)
        {
            this.grdRadioList.QueryLayout(true);
        }
        #endregion

        private void grdRadioList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdRadioList.Reset();

            this.grdRadioList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdRadioList.SetBindVarValue("f_order_date", order_date);
            this.grdRadioList.SetBindVarValue("f_bunho", bunho);

            this.grdRadioList.SetBindVarValue("f_in_out_gubun", this.in_out_gubun);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdRadioList.QueryLayout(true);

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    // cloud service
                    XRT0201U00RadioSaveLayoutArgs args = new XRT0201U00RadioSaveLayoutArgs();
                    args.GrdRadioListItemInfo = GetListDataForSaveLayout();
                    args.UserId = UserInfo.UserID;
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, XRT0201U00RadioSaveLayoutArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                    {
                        XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_002, Resources.CAP_002, MessageBoxIcon.Error);
                    }
                   /* if (this.grdRadioList.SaveLayout())
                    {
                        XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_002, Resources.CAP_002, MessageBoxIcon.Error);
                    }*/

                    break;

                case FunctionType.Close:
                    break;
            }
        }

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            ManagementRADIOLEVEL parent;

            public XSavePerformer(ManagementRADIOLEVEL parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Modified:

                        cmdText = @"UPDATE XRT0202
                                       SET UPD_ID           = :q_user_id
                                         , UPD_DATE         = SYSDATE
                                         , TUBE_VOL         = :f_tube_vol
                                         , TUBE_CUR         = :f_tube_cur
                                         , XRAY_TIME        = :f_xray_time
                                         , TUBE_CUR_TIME    = :f_tube_cur_time
                                         , IRRADIATION_TIME = :f_irradiation_time
                                         , XRAY_DISTANCE    = :f_xray_distance
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND FKXRT0201        = :f_fkxrt0201
                                       AND XRAY_CODE_IDX    = :f_xray_code_idx";

                        break;
                }

                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region [ä≥é“ï îÌîöó óöóè∆âÔ]
        private void btnRadioHistory_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", this.dbxBunho.Text);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT7001Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }
        #endregion

        #region cloud service

        private List<string> CreateGrdRadioParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_order_date");
            paramList.Add("f_bunho");
            paramList.Add("f_in_out_gubun");
            return paramList;
        }

        private List<object[]> LoadGrdRadioList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00GrdRadioListArgs args = new XRT0201U00GrdRadioListArgs();
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.InOutGubun = bc["f_in_out_gubun"] != null ? bc["f_in_out_gubun"].VarValue : "";
            XRT0201U00GrdRadioListResult result = CloudService.Instance.Submit<XRT0201U00GrdRadioListResult, XRT0201U00GrdRadioListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00GrdRadioListItemInfo item in result.GrdRadioListItemInfo)
                {
                    object[] objects = 
				{ 
					item.Bunho, 
					item.OrderDate, 
					item.Fkxrt0201, 
					item.XrayCode, 
					item.XrayName, 
					item.XrayGubun, 
					item.XrayCodeIdx, 
					item.XrayCodeIdxNm, 
					item.TubeVol, 
					item.TubeCur, 
					item.XrayTime, 
					item.TubeCurTime, 
					item.IrradiationTime, 
					item.XrayDistance, 
					item.DataRowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<XRT0201U00GrdRadioListItemInfo> GetListDataForSaveLayout()
        {
            List<XRT0201U00GrdRadioListItemInfo> lstResult = new List<XRT0201U00GrdRadioListItemInfo>();

            for (int i = 0; i < grdRadioList.RowCount; i++)
            {
                if (grdRadioList.GetRowState(i) == DataRowState.Modified)
                {
                    XRT0201U00GrdRadioListItemInfo item = new XRT0201U00GrdRadioListItemInfo();
                    item.TubeVol = grdRadioList.GetItemString(i, "tube_vol");
                    item.TubeCur = grdRadioList.GetItemString(i, "tube_cur");
                    item.XrayTime = grdRadioList.GetItemString(i, "xray_time");
                    item.TubeCurTime = grdRadioList.GetItemString(i, "tube_cur_time");
                    item.IrradiationTime = grdRadioList.GetItemString(i, "irradiation_time");
                    item.XrayDistance = grdRadioList.GetItemString(i, "xray_distance");
                    item.Fkxrt0201 = grdRadioList.GetItemString(i, "fkxrt0201");
                    item.XrayCodeIdx = grdRadioList.GetItemString(i, "xray_code_idx");

                    item.DataRowState = grdRadioList.GetRowState(i).ToString();
                    lstResult.Add(item);    
                }
            }
            return lstResult;
        }

        #endregion
    }
}