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
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0101U00 : IHIS.Framework.XScreen
    {
        bool isgrdOCS0101Save = false;
        bool isgrdOCS0102Save = false;

        bool isSaved0101 = false;
        bool isSaved0102 = false;

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XEditGrid grdOCS0102;
        private IHIS.Framework.XMstGrid grdOCS0101;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XButton btnSpecimen;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XButton btnSlipPrint;
        private Panel panel1;
        private XDisplayBox dbxHospName;
        private XFindBox fbxHospitalCode;
        private XLabel xLabel2;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem1;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;




        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0101U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            //this.SaveLayoutList.Add(grdOCS0101);
            //this.SaveLayoutList.Add(grdOCS0102);
            //this.grdOCS0101.SavePerformer = new XSavePerformer(this);
            //this.grdOCS0102.SavePerformer = this.grdOCS0101.SavePerformer;

            //set ParamList

            grdOCS0102.ParamList = new List<string>(new String[] { "f_slip_gubun" });
            this.layCommon.ParamList = new List<string>(new String[] { "f_hosp_code" });

            //set ExecuteQuery
            grdOCS0101.ExecuteQuery = LoadDataGrdOcs0101;
            grdOCS0102.ExecuteQuery = LoadDataGrdOcs0102;
            this.fwkCommon.ExecuteQuery = LoadDataFwkCommon;
            this.layCommon.ExecuteQuery = LoadDataLayCommon;

            CheckUpdateBtnListStatus();
        }

        #region Cloud Service

        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.HospName
                });
            }
            return res;
        }

        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }
        /// <summary>
        /// get data for grdOCS0101 from Cloud
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdOcs0101(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0101U00GrdOcs0101InitArgs args = new OCS0101U00GrdOcs0101InitArgs();
            args.HospCode = mHospCode;
            OCS0101U00GrdOcs0101InitResult result =
                CloudService.Instance.Submit<OCS0101U00GrdOcs0101InitResult, OCS0101U00GrdOcs0101InitArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0101U00GrdOcs0101ListItemInfo item in result.ListGrd0cs0101Init)
                {
                    object[] objects =
                    {
                        item.SlipGubun,
                        item.SlipGubunName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for grdOCS0102
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdOcs0102(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0101U00GrdOcs0102InitArgs args = new OCS0101U00GrdOcs0102InitArgs();
            args.SlipGubun = bc["f_slip_gubun"] != null ? bc["f_slip_gubun"].VarValue : "";
            args.HospCode = mHospCode;
            OCS0101U00GrdOcs0102InitResult result = CloudService.Instance.Submit<OCS0101U00GrdOcs0102InitResult, OCS0101U00GrdOcs0102InitArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0101U00GrdOcs0102ListItemInfo item in result.ListGrd0cs0102Init)
                {
                    object[] objects = 
				{ 
					item.SlipGubun, 
					item.SlipCode, 
					item.SlipName, 
					item.SpecimenText
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private void SaveOCS0101U00()
        {
            if (!ExecuteBeforeSave()) return;

            List<OCS0101U00GrdOcs0101ListItemInfo> input_grdOCS0101 = GetListFromGrdOCS0101();
            List<OCS0101U00GrdOcs0102ListItemInfo> input_grdOCS0102 = GetListFromGrdOCS0102();
            if (input_grdOCS0101.Count == 0 && input_grdOCS0102.Count == 0)
            {
                mbxMsg = Resources.MSG010_MSG;
                SetMsg(mbxMsg);
                XMessageBox.Show(mbxMsg, Resources.MSG010_CAP);//ADD　
                return;
            }

            OCS0101U00TransactionalArgs args = new OCS0101U00TransactionalArgs(input_grdOCS0101, input_grdOCS0102,
                UserInfo.UserID, mHospCode);

            OCS0101U00TransactionalResult saveLayoutResult =
                CloudService.Instance.Submit<OCS0101U00TransactionalResult, OCS0101U00TransactionalArgs>(args);

            if (saveLayoutResult.ExecutionStatus == ExecutionStatus.Success && saveLayoutResult.ResultOcs0101 &&
                saveLayoutResult.ResultOcs0102)
            {
                mbxMsg = Resources.MSG010_MSG;
                SetMsg(mbxMsg);
                XMessageBox.Show(mbxMsg, Resources.MSG010_CAP, MessageBoxIcon.Information); //ADD　
                this.grdOCS0101.QueryLayout(false);
            }
            else
            {
                mbxMsg = Resources.MSG011_MSG;
                mbxCap = Resources.MSG018_MSG_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        ///<summary>
        /// checkValidate
        /// </summary>
        private bool checkValidate()
        {
            List<OCS0101U00GrdOcs0101ListItemInfo> input_grdOCS0101 = GetListFromGrdOCS0101();
            List<OCS0101U00GrdOcs0102ListItemInfo> input_grdOCS0102 = GetListFromGrdOCS0102();

            foreach (OCS0101U00GrdOcs0101ListItemInfo list0101 in input_grdOCS0101)
            {
                if (string.IsNullOrEmpty(list0101.SlipGubun) || string.IsNullOrEmpty(list0101.SlipGubunName))
                {
                    return false;
                }
            }

            foreach (OCS0101U00GrdOcs0102ListItemInfo list0102 in input_grdOCS0102)
            {
                if (string.IsNullOrEmpty(list0102.SlipCode) || string.IsNullOrEmpty(list0102.SlipGubun) ||
                    string.IsNullOrEmpty(list0102.SlipName))
                {
                    return false;
                }
            }
            return true;

        }
        private List<OCS0101U00GrdOcs0102ListItemInfo> GetListFromGrdOCS0102()
        {
            List<OCS0101U00GrdOcs0102ListItemInfo> dataList = new List<OCS0101U00GrdOcs0102ListItemInfo>();
            for (int i = 0; i < grdOCS0102.RowCount; i++)
            {
                if (grdOCS0102.GetRowState(i) == DataRowState.Unchanged)
                    continue;

                OCS0101U00GrdOcs0102ListItemInfo info = new OCS0101U00GrdOcs0102ListItemInfo();
                info.SlipGubun = grdOCS0101.GetItemString(grdOCS0101.CurrentRowNumber, "slip_gubun");
                info.SlipCode = grdOCS0102.GetItemString(i, "slip_code");
                info.SlipName = grdOCS0102.GetItemString(i, "slip_name");
                info.SpecimenText = grdOCS0102.GetItemString(i, "specimen_ext");
                info.RowState = grdOCS0102.GetRowState(i).ToString();

                if (TypeCheck.IsNull(info.SlipCode) || TypeCheck.IsNull(info.SlipName))
                {
                    throw new Exception();
                }
                dataList.Add(info);
            }
            if (grdOCS0102.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0102.DeletedRowTable.Rows)
                {
                    OCS0101U00GrdOcs0102ListItemInfo info = new OCS0101U00GrdOcs0102ListItemInfo();
                    info.SlipGubun = grdOCS0101.GetItemString(grdOCS0101.CurrentRowNumber, "slip_gubun");
                    info.SlipCode = row["slip_code"].ToString();
                    info.SlipName = row["slip_name"].ToString();
                    info.SpecimenText = row["specimen_ext"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }

            return dataList;
        }

        private List<OCS0101U00GrdOcs0101ListItemInfo> GetListFromGrdOCS0101()
        {
            List<OCS0101U00GrdOcs0101ListItemInfo> dataList = new List<OCS0101U00GrdOcs0101ListItemInfo>();
            for (int i = 0; i < grdOCS0101.RowCount; i++)
            {
                if (grdOCS0101.GetRowState(i) == DataRowState.Unchanged)
                    continue;
                OCS0101U00GrdOcs0101ListItemInfo info = new OCS0101U00GrdOcs0101ListItemInfo();
                info.SlipGubun = grdOCS0101.GetItemString(i, "slip_gubun");
                info.SlipGubunName = grdOCS0101.GetItemString(i, "slip_gubun_name");
                info.RowState = grdOCS0101.GetRowState(i).ToString();

                if (TypeCheck.IsNull(info.SlipGubun))
                {
                    throw new Exception();
                }
                dataList.Add(info);
            }
            if (grdOCS0101.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0101.DeletedRowTable.Rows)
                {
                    OCS0101U00GrdOcs0101ListItemInfo info = new OCS0101U00GrdOcs0101ListItemInfo();
                    info.SlipGubun = row["slip_gubun"].ToString();
                    info.SlipGubunName = row["slip_gubun_name"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }

            return dataList;
        }

        private bool ExecuteBeforeSave()
        {
            AcceptData();
            //grdOCS0101
            for (int rowIndex = 0; rowIndex < grdOCS0101.RowCount; rowIndex++)
            {
                if (grdOCS0101.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0101.GetItemString(rowIndex, "slip_gubun").Trim() == "")
                    {
                        mbxMsg = Resources.MSG020_MSG;
                        mbxCap = Resources.MSG014_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                        grdOCS0101.SetFocusToItem(rowIndex, "slip_gubun");
                        return false;
                        //grdOCS0101.DeleteRow(rowIndex);
                        //rowIndex = rowIndex - 1;
                        //continue;
                    }
                }

                if (grdOCS0101.GetItemString(rowIndex, "slip_gubun_name").Trim() == "")
                {
                    mbxMsg = Resources.MSG008_MSG;
                    mbxCap = Resources.MSG002_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                    grdOCS0101.SetFocusToItem(rowIndex, "slip_gubun_name");
                    return false;
                }
            }

            //grdOCS0102
            for (int rowIndex = 0; rowIndex < grdOCS0102.RowCount; rowIndex++)
            {
                if (grdOCS0102.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0102.GetItemString(rowIndex, "slip_code").Trim() == "")
                    {
                        mbxMsg = Resources.MSG021_MSG;
                        mbxCap = Resources.MSG014_CAP;

                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                        grdOCS0102.SetFocusToItem(rowIndex, "slip_code");
                        return false;
                        //grdOCS0102.DeleteRow(rowIndex);
                        //rowIndex = rowIndex - 1;
                        //continue;
                    }
                }

                //서식지명
                if (grdOCS0102.GetItemString(rowIndex, "slip_name").Trim() == "")
                {
                    mbxMsg = Resources.MSG019_MSG;
                    mbxCap = Resources.MSG019_MSG_CAP;

                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                    grdOCS0102.SetFocusToItem(rowIndex, "slip_name");
                    return false;
                }
            }
            return true;
        }

        #endregion




        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0101U00));
            this.grdOCS0102 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0101 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.btnSpecimen = new IHIS.Framework.XButton();
            this.btnSlipPrint = new IHIS.Framework.XButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbxHospName = new IHIS.Framework.XDisplayBox();
            this.fbxHospitalCode = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOCS0102
            // 
            this.grdOCS0102.ApplyAutoInsertion = true;
            this.grdOCS0102.CallerID = '2';
            this.grdOCS0102.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell17});
            this.grdOCS0102.ColPerLine = 2;
            this.grdOCS0102.ColResizable = true;
            this.grdOCS0102.Cols = 3;
            this.grdOCS0102.ExecuteQuery = null;
            this.grdOCS0102.FixedCols = 1;
            this.grdOCS0102.FixedRows = 1;
            this.grdOCS0102.FocusColumnName = "slip_code";
            this.grdOCS0102.HeaderHeights.Add(33);
            resources.ApplyResources(this.grdOCS0102, "grdOCS0102");
            this.grdOCS0102.MasterLayout = this.grdOCS0101;
            this.grdOCS0102.Name = "grdOCS0102";
            this.grdOCS0102.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0102.ParamList")));
            this.grdOCS0102.QuerySQL = resources.GetString("grdOCS0102.QuerySQL");
            this.grdOCS0102.RowHeaderVisible = true;
            this.grdOCS0102.Rows = 2;
            this.grdOCS0102.ToolTipActive = true;
            this.grdOCS0102.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.SaveStarting);
            this.grdOCS0102.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0102_GridColumnChanged);
            this.grdOCS0102.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdOCS0102_MouseClick);
            this.grdOCS0102.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0102.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOCS0102_ItemValueChanging);
            this.grdOCS0102.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0102_GridColumnProtectModify);
            this.grdOCS0102.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0102_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "slip_gubun";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "slip_code";
            this.xEditGridCell4.CellWidth = 75;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.CellLen = 40;
            this.xEditGridCell5.CellName = "slip_name";
            this.xEditGridCell5.CellWidth = 397;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 1;
            this.xEditGridCell17.CellName = "specimen_ext";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // grdOCS0101
            // 
            this.grdOCS0101.ApplyAutoInsertion = true;
            this.grdOCS0101.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdOCS0101.ColPerLine = 2;
            this.grdOCS0101.Cols = 3;
            this.grdOCS0101.ExecuteQuery = null;
            this.grdOCS0101.FixedCols = 1;
            this.grdOCS0101.FixedRows = 1;
            this.grdOCS0101.FocusColumnName = "slip_gubun";
            this.grdOCS0101.HeaderHeights.Add(29);
            resources.ApplyResources(this.grdOCS0101, "grdOCS0101");
            this.grdOCS0101.Name = "grdOCS0101";
            this.grdOCS0101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0101.ParamList")));
            this.grdOCS0101.QuerySQL = "SELECT NVL(A.SLIP_GUBUN     , \' \') SLIP_GUBUN,\r\n       NVL(A.SLIP_GUBUN_NAME, \' \'" +
                ") SLIP_GUBUN_NAME\r\n  FROM OCS0101 A\r\n WHERE A.HOSP_CODE\t= :f_hosp_code\r\n ORDER B" +
                "Y 1";
            this.grdOCS0101.RowHeaderVisible = true;
            this.grdOCS0101.Rows = 2;
            this.grdOCS0101.ToolTipActive = true;
            this.grdOCS0101.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.SaveStarting);
            this.grdOCS0101.CheckDetailLayout += new System.ComponentModel.CancelEventHandler(this.grdOCS0101_CheckDetailLayout);
            this.grdOCS0101.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0101_GridColumnChanged);
            this.grdOCS0101.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdOCS0101_MouseClick);
            this.grdOCS0101.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0101.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdOCS0101_RowFocusChanging);
            this.grdOCS0101.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0101_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "slip_gubun";
            this.xEditGridCell1.CellWidth = 77;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.AutoInsertAtEnterKey = true;
            this.xEditGridCell2.CellLen = 80;
            this.xEditGridCell2.CellName = "slip_gubun_name";
            this.xEditGridCell2.CellWidth = 218;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // btnSpecimen
            // 
            resources.ApplyResources(this.btnSpecimen, "btnSpecimen");
            this.btnSpecimen.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecimen.Image")));
            this.btnSpecimen.Name = "btnSpecimen";
            this.btnSpecimen.Click += new System.EventHandler(this.btnSpecimen_Click);
            // 
            // btnSlipPrint
            // 
            resources.ApplyResources(this.btnSlipPrint, "btnSlipPrint");
            this.btnSlipPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnSlipPrint.Image")));
            this.btnSlipPrint.Name = "btnSlipPrint";
            this.btnSlipPrint.Click += new System.EventHandler(this.btnSlipPrint_Click);
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.btnSpecimen);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Controls.Add(this.btnSlipPrint);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dbxHospName);
            this.panel1.Controls.Add(this.fbxHospitalCode);
            this.panel1.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // dbxHospName
            // 
            resources.ApplyResources(this.dbxHospName, "dbxHospName");
            this.dbxHospName.Name = "dbxHospName";
            // 
            // fbxHospitalCode
            // 
            this.fbxHospitalCode.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxHospitalCode, "fbxHospitalCode");
            this.fbxHospitalCode.Name = "fbxHospitalCode";
            this.fbxHospitalCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalCode_DataValidating);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = "病院コード";
            this.fwkCommon.InputSQL = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "hosp";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "hosp_name";
            this.findColumnInfo4.ColWidth = 155;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            this.layCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCommon_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxHospName;
            this.singleLayoutItem1.DataName = "HospitalName";
            // 
            // OCS0101U00
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdOCS0102);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdOCS0101);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "OCS0101U00";
            this.Load += new System.EventHandler(this.OCS0101_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private void OCS0101_Load(object sender, EventArgs e)
        {
            //this.grdUserGrp.SavePerformer = new XSavePeformer(this);
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                this.panel1.Visible = true;
                this.mHospCode = fbxHospitalCode.Text;
                //this.grdOCS0101.Height = 424;
                //this.grdOCS0102.Height = 424;
                //this.grdOCS0101.Location = new Point(5, 51);
                //this.grdOCS0102.Location = new Point(5, 51);
                grdOCS0101.ReadOnly = false;
            }
            else
            {
                this.panel1.Visible = false;
                this.mHospCode = UserInfo.HospCode;
                this.grdOCS0101.Height = 545;
                this.grdOCS0102.Height = 545;
                this.grdOCS0101.Location = new Point(0, 5);
                this.grdOCS0102.Location = new Point(331, 5);
                grdOCS0101.ReadOnly = true;
            }
        }

        private void CheckUpdateBtnListStatus()
        {
            if (this.CurrMQLayout == null) // Init screen
            {
                if (UserInfo.AdminType != AdminType.SuperAdmin)
                    UpdateBtnListStatus(false);
                else
                    UpdateBtnListStatus(true);

                return;
            }
            else if (this.CurrMQLayout == grdOCS0101) // Grd master is focused
            {
                if (UserInfo.AdminType != AdminType.SuperAdmin)
                    UpdateBtnListStatus(false);
                else
                    UpdateBtnListStatus(true);
            }
            else
            {
                UpdateBtnListStatus(true);
            }
        }

        private void UpdateBtnListStatus(bool isActive)
        {
            xButtonList1.SetEnabled(FunctionType.Insert, isActive);
            xButtonList1.SetEnabled(FunctionType.Delete, isActive);
            xButtonList1.SetEnabled(FunctionType.Update, isActive);
        }

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            //Set M/D Relation
            grdOCS0102.SetRelationKey("slip_gubun", "slip_gubun");

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0101;
            this.CurrMQLayout = this.grdOCS0101;

            // this function is not necessary
            //CreateCombo();

            grdOCS0101.QueryLayout(false);
        }
        #endregion

        #region [Combo 생성]
        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layCombo = new MultiLayout();

            //처방구분 
            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = " SELECT CODE, CODE||': '||CODE_NAME CODE_NAME"
                              + "   FROM OCS0132 "
                              + "  WHERE CODE_TYPE = 'ORDER_GUBUN_BAS' "
                              + "    AND HOSP_CODE = '" + mHospCode + "'"
                              + "  ORDER BY CODE ";

            if (layCombo.QueryLayout(false))
            {
                grdOCS0102.SetComboItems("order_gubun", layCombo.LayoutTable, "code_name", "code");
            }

            //Input Control 
            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("input_control", DataType.String);
            layCombo.LayoutItems.Add("input_control_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = " SELECT INPUT_CONTROL, INPUT_CONTROL||': '||INPUT_CONTROL_NAME INPUT_CONTROL_NAME"
                              + "   FROM OCS0133 "
                              + "  WHERE HOSP_CODE = '" + mHospCode + "'";

            if (layCombo.QueryLayout(false))
            {
                grdOCS0102.SetComboItems("input_control", layCombo.LayoutTable, "input_control_name", "input_control");
            }

            //DV Time 
            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = " SELECT CODE, CODE||': '||CODE_NAME CODE_NAME"
                              + "   FROM OCS0132 "
                              + "  WHERE CODE_TYPE = 'DV_TIME' "
                              + "    AND HOSP_CODE = '" + mHospCode + "'"
                              + "  ORDER BY CODE ";

            if (layCombo.QueryLayout(false))
            {
                grdOCS0102.SetComboItems("dv_time", layCombo.LayoutTable, "code_name", "code");
            }

            //입력형태 
            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = " SELECT CODE, CODE||': '||CODE_NAME CODE_NAME"
                              + "   FROM OCS0132 "
                              + "  WHERE CODE_TYPE = 'INPUT_TYPE' "
                              + "    AND HOSP_CODE = '" + mHospCode + "'"
                              + "  ORDER BY CODE ";

            if (layCombo.QueryLayout(false))
            {
                grdOCS0102.SetComboItems("input_type", layCombo.LayoutTable, "code_name", "code");
            }
        }
        #endregion

        #region [grdOCS0101 Event]
        private void grdOCS0101_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XMstGrid mstGrid = sender as XMstGrid;

            if (mstGrid.CurrentRowNumber < 0) return;

            string slip_gubun;
            slip_gubun = mstGrid.GetItemString(mstGrid.CurrentRowNumber, "slip_gubun");

            int chk = 0;

            try
            {
                foreach (object obj in this.Controls)
                {
                    if (obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
                    {
                        chk = chk + ((XGrid)obj).RowCount;
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid)
                    {
                        foreach (DataRow row in ((XEditGrid)obj).LayoutTable.Rows)
                            if (row.RowState != DataRowState.Added) chk = chk + 1;

                        chk = chk + ((XEditGrid)obj).DeletedRowCount;

                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid)
                    {
                        foreach (DataRow row in ((XMstGrid)obj).LayoutTable.Rows)
                            if (row.RowState != DataRowState.Added) chk = chk + 1;

                        chk = chk + ((XMstGrid)obj).DeletedRowCount;
                    }
                }
            }
            catch
            {
            }

            if (chk > 0)
            {
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void grdOCS0101_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "slip_gubun":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdOCS0101.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0101.GetItemString(i, "slip_gubun").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG001_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    //Check Origin Data
                    //string cmdText = " SELECT 'Y' "
                    //               + "   FROM OCS0101 "
                    //               + "  WHERE SLIP_GUBUN = :f_value"
                    //               + "    AND ROWNUM     = 1 "
                    //               + "    AND HOSP_CODE  = :f_hosp_code";

                    //BindVarCollection bindVars = new BindVarCollection();
                    //bindVars.Add("f_value", e.ChangeValue.ToString());
                    //bindVars.Add("f_hosp_code", mHospCode);
                    //object retVal = Service.ExecuteScalar(cmdText, bindVars);

                    OCS0101U00Grd0101CheckDataArgs args = new OCS0101U00Grd0101CheckDataArgs(e.ChangeValue.ToString(), mHospCode);

                    OCS0101U00Grd0101CheckDataResult result =
                        CloudService.Instance.Submit<OCS0101U00Grd0101CheckDataResult, OCS0101U00Grd0101CheckDataArgs>(
                            args);

                    //if (retVal != null && retVal.ToString().Equals("Y"))
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.ChkResult == "Y")
                    {
                        mbxMsg = Resources.MSG001_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0101_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateBtnListStatus();
        }

        #endregion

        #region [grdOCS0102 Event]
        private void grdOCS0102_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;
            string cmdText = "";
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            switch (e.ColName)
            {
                case "slip_code":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdOCS0102.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0102.GetItemString(i, "slip_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG002_MSG;
                                mbxCap = Resources.MSG002_CAP;
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    //Check Origin Data
                    //cmdText = " SELECT 'Y' "
                    //        + "   FROM OCS0102 "
                    //        + "  WHERE SLIP_CODE  = :f_value"
                    //        + "    AND ROWNUM     = 1 "
                    //        + "    AND HOSP_CODE  = :f_hosp_code";

                    //bindVars.Clear();
                    //bindVars.Add("f_value", e.ChangeValue.ToString());
                    //bindVars.Add("f_hosp_code", mHospCode);
                    //retVal = Service.ExecuteScalar(cmdText, bindVars);

                    OCS0101U00Grd0102CheckDataArgs args = new OCS0101U00Grd0102CheckDataArgs(e.ChangeValue.ToString(), mHospCode);
                    OCS0101U00Grd0102CheckDataResult result =
                        CloudService.Instance.Submit<OCS0101U00Grd0102CheckDataResult, OCS0101U00Grd0102CheckDataArgs>(
                            args);

                    //if (retVal != null && retVal.ToString().Equals("Y"))
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.ChkResult == "Y")
                    {
                        mbxMsg = Resources.MSG003_MSG;
                        mbxCap = Resources.MSG002_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;


                default:
                    break;
            }
        }

        private void grdOCS0102_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            switch (e.ColName)
            {
                case "specimen_yn":
                    if (e.DataRow["specimen_ext"].ToString() == "Y" || e.DataRow.RowState == DataRowState.Added)
                        e.Protect = true;
                    else
                        e.Protect = false;
                    break;
                default:
                    e.Protect = false;
                    break;
            }
        }

        private void grdOCS0102_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            switch (e.ColName)
            {
                case "specimen_yn":
                    //검체등록여부가 Y일때 검체등록창을 show한다.
                    if (e.ChangeValue.ToString() == "Y")
                        CallSpecimen(e.RowNumber);
                    break;
                default:
                    break;
            }
        }
        private void grdOCS0102_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateBtnListStatus();
        }

        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    grdOCS0101.QueryLayout(false);
                    grdOCS0102.QueryLayout(false);
                    break;
                case FunctionType.Insert:
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                        e.IsBaseCall = true;
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }

                    break;
                case FunctionType.Update:
                    //try
                    //{
                    SaveOCS0101U00();
                    //}
                    //catch
                    //{
                    //    mbxMsg = Resources.MSG011_MSG;
                    //    mbxCap = Resources.MSG018_MSG_CAP;
                    //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    break;
                case FunctionType.Delete:
                    if (this.CurrMSLayout == grdOCS0102)
                    {
                        if (this.CurrMSLayout.CurrentRowNumber < 0) return;

                        if (preDeleteOCS0102())
                            e.IsBaseCall = true;
                        else
                            e.IsBaseCall = false;
                    }
                    break;
                case FunctionType.Close:

                    e.IsBaseCall = false;

                    string sFunc = "";
                    string sMsg = "";

                    sFunc = Find_AddedRowState_OCS0102();


                    if (sFunc == "N")
                    {
                        sFunc = Find_AddedRowState_OCS0101();
                        if (sFunc == "N")
                        {
                            e.IsBaseCall = true;

                        }
                    }

                    if (sFunc != "N")
                    {
                        if (sFunc == "U")
                            sMsg = Resources.MSG004_1_MSG;
                        else
                            sMsg = Resources.MSG004_2_MSG;

                        sMsg = sMsg + Resources.MSG005_MSG;


                        if (XMessageBox.Show(sMsg, Resources.MSG005_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            xButtonList1.PerformClick(FunctionType.Update);
                        }
                        e.IsBaseCall = true;

                    }

                    break;

                default:
                    break;
            }
        }



        private bool preDeleteOCS0102()
        {
            IHIS.Framework.SingleLayout layCommon = new SingleLayout();
            bool returnValue = true;

            int currRowIndex = grdOCS0102.CurrentRowNumber;
            if (grdOCS0102.LayoutTable.Rows[currRowIndex].RowState == DataRowState.Added)
                return returnValue;

            string slip_code = grdOCS0102.GetItemString(currRowIndex, "slip_code").Trim();

            //항목코드존재여부
            //layCommon.Reset();
            //layCommon.QuerySQL = " SELECT 'Y' "
            //                   + "   FROM OCS0103 "
            //                   + "  WHERE SLIP_CODE  = '" + slip_code + "' "
            //                   + "    AND ROWNUM     = 1 "
            //                   + "    AND HOSP_CODE  = '" + mHospCode + "'";

            //layCommon.LayoutItems.Clear();
            //layCommon.LayoutItems.Add("check");

            //if (layCommon.QueryLayout())
            //{
            //    if (layCommon.GetItemValue("check").ToString().Equals("Y"))
            //    {
            //        mbxMsg = Resources.MSG006_MSG;
            //        mbxCap = Resources.MSG002_CAP;
            //        XMessageBox.Show(mbxMsg, mbxCap);
            //        returnValue = false;
            //    }
            //}

            ////검체존재여부
            //layCommon.Reset();
            //layCommon.QuerySQL = " SELECT 'Y' "
            //                   + "   FROM OCS0106 "
            //                   + "  WHERE SLIP_CODE  = '" + slip_code + "' "
            //                   + "    AND ROWNUM     = 1 "
            //                   + "    AND HOSP_CODE  = '" + mHospCode + "'";

            //layCommon.LayoutItems.Clear();
            //layCommon.LayoutItems.Add("check");


            //if (layCommon.QueryLayout())
            //{
            //    if (layCommon.GetItemValue("check").ToString().Equals("Y"))
            //    {
            //        mbxMsg = Resources.MSG007_MSG;
            //        mbxCap = Resources.MSG002_CAP;
            //        XMessageBox.Show(mbxMsg, mbxCap);
            //        returnValue = false;
            //    }
            //}

            OCS0101PreDeleteOcs0102CheckArgs args = new OCS0101PreDeleteOcs0102CheckArgs(slip_code, mHospCode);
            OCS0101PreDeleteOcs0102CheckResult result =
                CloudService.Instance.Submit<OCS0101PreDeleteOcs0102CheckResult, OCS0101PreDeleteOcs0102CheckArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.Ocs0103Result == "Y")
                {
                    mbxMsg = Resources.MSG006_MSG;
                    mbxCap = Resources.MSG002_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap);
                    returnValue = false;
                }

                if (result.Ocs0106Result == "Y")
                {
                    mbxMsg = Resources.MSG007_MSG;
                    mbxCap = Resources.MSG002_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap);
                    returnValue = false;
                }
            }

            return returnValue;
        }
        #endregion

        #region [서식지별 검체등록]
        private void btnSpecimen_Click(object sender, System.EventArgs e)
        {
            CallSpecimen(grdOCS0102.CurrentRowNumber);
        }

        /// <summary>
        /// this function is never used
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CallSpecimen(int rowIndex)
        {
            //if (rowIndex < 0) return;

            //string slip_code = grdOCS0102.GetItemString(rowIndex, "slip_code").Trim();
            //if (slip_code == "") return;

            //try
            //{
            //    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            //    frmOCS0106 frm = new frmOCS0106(slip_code);
            //    frm.ShowDialog();

            //    //검체존재여부확인
            //    //항목코드존재여부
            //    string cmdText = " SELECT 'Y' "
            //                   + "   FROM OCS0106 "
            //                   + "  WHERE SLIP_CODE  = :f_slip_code"
            //                   + "    AND ROWNUM     = 1 "
            //                   + "    AND HOSP_CODE  = :f_hosp_code";

            //    IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            //    bindVars.Add("f_slip_code", slip_code);
            //    bindVars.Add("f_hosp_code", mHospCode);
            //    object retVal = Service.ExecuteScalar(cmdText, bindVars);

            //    if (retVal != null && retVal.ToString().Equals("Y"))
            //        grdOCS0102.SetItemValue(rowIndex, "specimen_ext", "Y");
            //    else
            //        grdOCS0102.SetItemValue(rowIndex, "specimen_ext", "N");
            //}
            //finally
            //{
            //    Cursor.Current = System.Windows.Forms.Cursors.Default;
            //}
        }
        #endregion

        #region [서식지출력]
        private void btnSlipPrint_Click(object sender, System.EventArgs e)
        {
            XScreen.OpenScreen(this, "OCS0101R00", ScreenOpenStyle.ResponseSizable);
        }
        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }
            return celReturn;
        }
        #endregion

        #region [SaveStart / SaveEnd]
        private void SaveStarting(object sender, GridRecordEventArgs e)
        {
            //AcceptData();
            ////grdOCS0101
            //for (int rowIndex = 0; rowIndex < grdOCS0101.RowCount; rowIndex++)
            //{
            //    if (grdOCS0101.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
            //    {
            //        //Key값이 없으면 삭제처리
            //        if (grdOCS0101.GetItemString(rowIndex, "slip_gubun").Trim() == "")
            //        {
            //            grdOCS0101.DeleteRow(rowIndex);
            //            rowIndex = rowIndex - 1;
            //            continue;
            //        }
            //    }

            //    if (grdOCS0101.GetItemString(rowIndex, "slip_gubun_name").Trim() == "")
            //    {
            //        mbxMsg = Resources.MSG008_MSG;
            //        mbxCap = Resources.MSG002_CAP;
            //        XMessageBox.Show(mbxMsg, mbxCap);
            //        grdOCS0101.SetFocusToItem(rowIndex, "slip_gubun_name");
            //    }
            //}

            ////grdOCS0102
            //for (int rowIndex = 0; rowIndex < grdOCS0102.RowCount; rowIndex++)
            //{
            //    if (grdOCS0102.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
            //    {
            //        //Key값이 없으면 삭제처리
            //        if (grdOCS0102.GetItemString(rowIndex, "slip_code").Trim() == "")
            //        {
            //            grdOCS0102.DeleteRow(rowIndex);
            //            rowIndex = rowIndex - 1;
            //            continue;
            //        }
            //    }

            //    //서식지명
            //    if (grdOCS0102.GetItemString(rowIndex, "slip_name").Trim() == "")
            //    {
            //        mbxMsg = Resources.MSG009_MSG;
            //        mbxCap = Resources.MSG002_CAP;

            //        XMessageBox.Show(mbxMsg, mbxCap);
            //        grdOCS0102.SetFocusToItem(rowIndex, "slip_name");
            //    }
            //}
        }

        private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            //switch (e.CallerID)
            //{
            //    case '1':
            //        isgrdOCS0101Save = e.IsSuccess;
            //        isSaved0101 = true;
            //        break;
            //    case '2':
            //        isgrdOCS0102Save = e.IsSuccess;
            //        isSaved0102 = true;
            //        break;
            //}

            //if (isSaved0101 && isSaved0102)
            //{
            //    if (isgrdOCS0101Save && isgrdOCS0102Save)
            //    {
            //        mbxMsg = Resources.MSG010_MSG;
            //        SetMsg(mbxMsg);
            //        XMessageBox.Show(mbxMsg, Resources.MSG010_CAP);//ADD　
            //    }
            //    else
            //    {
            //        mbxMsg = Resources.MSG011_MSG;
            //        mbxMsg += "\r\n[" + e.ErrMsg + "]";//ADD
            //        mbxCap = "Save Error";

            //        XMessageBox.Show(mbxMsg, mbxCap);
            //    }
            //    isgrdOCS0101Save = false;
            //    isSaved0101 = false;
            //    isgrdOCS0102Save = false;
            //    isSaved0102 = false;
            //}
        }
        #endregion

        #region [각 그리드에 바인드변수 설정]
        private void grdOCS0101_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0101.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS0102_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0102.SetBindVarValue("f_slip_gubun", grdOCS0101.GetItemString(grdOCS0101.CurrentRowNumber, "slip_gubun"));
            grdOCS0102.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region [XSavePerformer Class]
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {
        //            private OCS0101U00 parent = null;

        //            public XSavePerformer(OCS0101U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("f_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                switch (callerID)
        //                {
        //                    case '1':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:


        //                                cmdText = @"INSERT INTO OCS0101		     
        //                                            (SYS_DATE, SYS_ID, SLIP_GUBUN, SLIP_GUBUN_NAME, HOSP_CODE,UPD_DATE,UPD_ID)
        //                                        VALUES  
        //                                            (SYSDATE, :f_user_id, :f_slip_gubun, :f_slip_gubun_name, :f_hosp_code,SYSDATE, :f_user_id)";
        //                                //UPD_DATE,UPD_ID 주가                                

        //                                break;
        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE OCS0101
        //											   SET UPD_ID	   	    = :f_user_id,
        //												   UPD_DATE         = SYSDATE,
        //											  	   SLIP_GUBUN_NAME  = :f_slip_gubun_name
        //											 WHERE SLIP_GUBUN       = :f_slip_gubun
        //                                               AND HOSP_CODE        = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE OCS0101 
        //											 WHERE SLIP_GUBUN = :f_slip_gubun
        //                                               AND HOSP_CODE  = :f_hosp_code";
        //                                break;
        //                        }
        //                        break;
        //                    case '2':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:


        //                                cmdText = @"INSERT INTO OCS0102
        //                                                    (SYS_DATE    , SYS_ID       , SLIP_GUBUN    ,
        //                                                    SLIP_CODE    , SLIP_NAME    , HOSP_CODE     ,UPD_DATE    ,UPD_ID)
        //                                            VALUES  
        //                                                    (SYSDATE     , :f_user_id   , :f_slip_gubun , 
        //                                                    :f_slip_code , :f_slip_name , :f_hosp_code  ,SYSDATE     , :f_user_id  )";
        //                                // UPD_DATE,UPD_ID 주가

        //                                break;
        //                            case DataRowState.Modified:
        //                                cmdText = @"UPDATE OCS0102             
        //                                               SET UPD_ID           = :f_user_id         ,
        //                                                   UPD_DATE         = SYSDATE            ,
        //                                                   SLIP_NAME        = :f_slip_name                                                                     
        //                                             WHERE SLIP_GUBUN       = :f_slip_gubun
        //                                               AND SLIP_CODE        = :f_slip_code
        //                                               AND HOSP_CODE        = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted:
        //                                cmdText = @"DELETE OCS0102 
        //											 WHERE SLIP_GUBUN = :f_slip_gubun
        //											   AND SLIP_CODE  = :f_slip_code
        //                                               AND HOSP_CODE  = :f_hosp_code";
        //                                break;
        //                        }
        //                        break;
        //                }
        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }
        #endregion

        #region [grdOCS0101_RowFocusChanging]
        private void grdOCS0101_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {

            string sMsg = "";

            if (Find_AddedRowState_OCS0102() != "N")
            {


                if (Find_AddedRowState_OCS0102() == "U")
                {
                    sMsg = Resources.MSG004_1_MSG;
                }
                else
                {
                    sMsg = Resources.MSG004_2_MSG;
                }

                sMsg = sMsg + Resources.MSG005_MSG;


                if (XMessageBox.Show(sMsg, Resources.MSG005_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xButtonList1.PerformClick(FunctionType.Update);
                }
                else
                {
                    return;
                }

            }

        }
        #endregion

        #region grdOCS0102に追加・削除した行が未保存かチェック
        private string Find_AddedRowState_OCS0102()
        {

            //詳細に行追加
            for (int i = 0; i < this.grdOCS0102.RowCount; i++)
            {
                if (this.grdOCS0102.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                    this.grdOCS0102.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                    return "U";
            }

            //詳細を削除
            if (this.grdOCS0102.DeletedRowTable != null &&
                this.grdOCS0102.DeletedRowTable.Rows.Count > 0)
            {
                return "D";
            }

            //何もないとき
            return "N";

        }
        #endregion

        #region grdOCS0101に追加・削除した行が未保存かチェック
        private string Find_AddedRowState_OCS0101()
        {

            //詳細に行追加
            for (int i = 0; i < this.grdOCS0101.RowCount; i++)
            {
                if (this.grdOCS0101.LayoutTable.Rows[i].RowState == DataRowState.Added ||
                    this.grdOCS0101.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                    return "U";
            }

            //詳細を削除
            if (this.grdOCS0101.DeletedRowTable != null &&
                this.grdOCS0101.DeletedRowTable.Rows.Count > 0)
            {
                return "D";
            }

            //何もないとき
            return "N";

        }
        #endregion

        private void fbxHospitalCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalCode.Text;

            this.layCommon.QueryLayout();

            this.grdOCS0101.QueryLayout(true);
        }

        private void layCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
        }

    }
}

