#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Phys;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Phys;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.PHYS.Properties;

#endregion

namespace IHIS.PHYS
{
    public partial class PHY0001U00 : IHIS.Framework.XScreen
    {
        public PHY0001U00()
        {
            InitializeComponent();

            grdRehaSinryouryouCode.ExecuteQuery = ExecuteQueryGrdRehaSinryouryouCodeInfo;

            grdOCS0132.ParamList = new List<string>(new String[] { "f_code_type" });
            grdOCS0132.ExecuteQuery = ExecuteQueryGrdOCS0132Info;
        }

        private void grdOCS0132_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS0132.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0132.SetBindVarValue("f_code_type", "REHA_AUTO_SINRYOURYOU");
        }

        private void PHYS0001U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            /*this.grdOCS0132.SavePerformer = new XSavePerformer(this);
            this.grdRehaSinryouryouCode.SavePerformer = this.grdOCS0132.SavePerformer;*/

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdOCS0132.QueryLayout(false);
                    this.grdRehaSinryouryouCode.QueryLayout(false);
                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;
                    bool updateResult = SaveLayout();
                    if (!updateResult)
                    {
                        XMessageBox.Show(Resources.MSG_1, Resources.Caption_1);
                        return;
                    }

                    /*if (!this.grdOCS0132.SaveLayout())
                    {
                        XMessageBox.Show("保存に失敗しました｡", "確認");
                        return;
                    }

                    if (!this.grdRehaSinryouryouCode.SaveLayout())
                    {
                        XMessageBox.Show("保存に失敗しました｡", "確認");
                        return;
                    }*/
                    
                    break;

            }

        }

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            PHY0001U00 parent;

            public XSavePerformer(PHY0001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = @"";

                switch (callerID)
                {
                    case '1':

                        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                        switch (item.RowState)
                        {
                            case DataRowState.Modified:

                                cmdText = @"UPDATE OCS0132 A
                                               SET A.CODE_NAME = :f_code_name
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.CODE_TYPE = :f_code_type
                                               AND A.CODE      = :f_code
                                    ";
                                break;
                        }
                        break;

                    case '2':

                        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                        switch (item.RowState)
                        {
                            case DataRowState.Modified:

                                cmdText = @"UPDATE OCS0132 A
                                               SET A.CODE_NAME = :f_hangmog_code
                                             WHERE A.HOSP_CODE = :f_hosp_code
                                               AND A.CODE_TYPE = 'REHA_SINRYOURYOU'
                                               AND A.CODE      = :f_code
                                    ";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion 

        private void grdRehaSinryouryouCode_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), false); // 화면오픈

                    break;
            }
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        /// <param name="aMultiSelect">복수선택여부</param>
        private void OpenScreen_OCS0103Q00(string aHangmogCode, bool aMultiSelect)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", "%");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void grdRehaSinryouryouCode_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":
                    this.grdRehaSinryouryouCode.SetItemValue(e.RowNumber, "hangmog_code", e.ReturnValues[1].ToString());
                    break;
            }
        }

        #region Command
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                
                // 처치 재료
                case "OCS0103Q00":

                    if (commandParam != null)
                    {
                        MultiLayout grid = ((MultiLayout)commandParam["OCS0103"]);

                        if (commandParam.Contains("OCS0103") && grid.RowCount > 0)
                        {
                            this.grdRehaSinryouryouCode.SetItemValue(this.grdRehaSinryouryouCode.CurrentRowNumber, "hangmog_code", grid.GetItemString(0, "hangmog_code"));
                            this.grdRehaSinryouryouCode.SetItemValue(this.grdRehaSinryouryouCode.CurrentRowNumber, "hangmog_name", grid.GetItemString(0, "hangmog_name"));
                        }
                    }
                    break;

            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region Connect to cloud service
        /// <summary>
        /// ExecuteQueryGrdRehaSinryouryouCodeInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdRehaSinryouryouCodeInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY0001U00GrdRehaSinryouryouCodeArgs vPHY0001U00GrdRehaSinryouryouCodeArgs = new PHY0001U00GrdRehaSinryouryouCodeArgs();
            PHY0001U00GrdRehaSinryouryouCodeResult result = CloudService.Instance.Submit<PHY0001U00GrdRehaSinryouryouCodeResult, PHY0001U00GrdRehaSinryouryouCodeArgs>(vPHY0001U00GrdRehaSinryouryouCodeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PHY0001U00GrdRehaSinryouryouCodeInfo item in result.GrdInfo)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.HangmogCode,
                        item.HangmogName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0132Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0132Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            PHY0001U00GrdOCS0132Args vPHY0001U00GrdOCS0132Args = new PHY0001U00GrdOCS0132Args();
            vPHY0001U00GrdOCS0132Args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            PHY0001U00GrdOCS0132Result result = CloudService.Instance.Submit<PHY0001U00GrdOCS0132Result, PHY0001U00GrdOCS0132Args>(vPHY0001U00GrdOCS0132Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PHY0001U00GrdOCS0132Info item in result.GrdInfo)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.CodeType,
                        item.Ment
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// SaveLayout
        /// </summary>
        /// <returns></returns>
        private bool SaveLayout()
        {
            PHY0001U00SaveLayoutArgs args = new PHY0001U00SaveLayoutArgs();
            args.GrdOcsInfo = CreateListGrdOCS0132();
            args.GrdRehaInfo = CreateListGrdRehaSinryouryouCodeInfo();
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, PHY0001U00SaveLayoutArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus == ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }
             
        /// <summary>
        /// CreateListGrdRehaSinryouryouCodeInfo
        /// </summary>
        /// <returns></returns>
        private List<PHY0001U00GrdRehaSinryouryouCodeInfo> CreateListGrdRehaSinryouryouCodeInfo()
        {
            List<PHY0001U00GrdRehaSinryouryouCodeInfo> lstGrdRehaSinryouryouCodeInfo = new List<PHY0001U00GrdRehaSinryouryouCodeInfo>();
            for (int i = 0; i < grdRehaSinryouryouCode.RowCount; i++)
            {
                if (grdRehaSinryouryouCode.GetRowState(i) == DataRowState.Added ||
                grdRehaSinryouryouCode.GetRowState(i) == DataRowState.Modified)
                {
                    PHY0001U00GrdRehaSinryouryouCodeInfo itemInfo = new PHY0001U00GrdRehaSinryouryouCodeInfo();
                    itemInfo.Code = grdRehaSinryouryouCode.GetItemString(i, "code");
                    itemInfo.HangmogCode = grdRehaSinryouryouCode.GetItemString(i, "hangmog_code");
                    itemInfo.HangmogName = grdRehaSinryouryouCode.GetItemString(i, "hangmog_name");
                    itemInfo.RowState = grdRehaSinryouryouCode.GetRowState(i).ToString();
                    lstGrdRehaSinryouryouCodeInfo.Add(itemInfo);
                }     
            }
            return lstGrdRehaSinryouryouCodeInfo;
        }

        /// <summary>
        /// CreateListGrdOCS0132
        /// </summary>
        /// <returns></returns>
        private List<PHY0001U00GrdOCS0132Info> CreateListGrdOCS0132()
        {
            List<PHY0001U00GrdOCS0132Info> lstGrdOcs0132Infos = new List<PHY0001U00GrdOCS0132Info>();
            for (int i = 0; i < grdOCS0132.RowCount; i++)
            {
                if (grdOCS0132.GetRowState(i) == DataRowState.Added ||
                    grdOCS0132.GetRowState(i) == DataRowState.Modified)
                {
                    PHY0001U00GrdOCS0132Info grdOcs0132Info = new PHY0001U00GrdOCS0132Info();
                    grdOcs0132Info.Code = grdOCS0132.GetItemString(i, "code");
                    grdOcs0132Info.CodeName = grdOCS0132.GetItemString(i, "code_name");
                    grdOcs0132Info.CodeType = grdOCS0132.GetItemString(i, "code_type");
                    grdOcs0132Info.Ment = grdOCS0132.GetItemString(i, "ment ");
                    grdOcs0132Info.RowState = grdOCS0132.GetRowState(i).ToString();
                }
            }
            return lstGrdOcs0132Infos;
        }
        #endregion 


    }
}