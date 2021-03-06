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
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0304U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0304U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        string mDoctor = "";
        //Message처리
        string mbxMsg = "", mbxCap = "";

        string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region [SaveEnd]
        bool isgrdOCS0304Save = false;
        bool isgrdOCS0305Save = false;
        bool isgrdOCS0306Save = false;

        bool isSavedOCS0304 = false;
        bool isSavedOCS0305 = false;
        bool isSavedOCS0306 = false;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XEditGridCell xEditGridCell138;
        private IHIS.Framework.XEditGridCell xEditGridCell139;
        private IHIS.Framework.XEditGridCell xEditGridCell143;
        private IHIS.Framework.XEditGridCell xEditGridCell144;
        private IHIS.Framework.XEditGridCell xEditGridCell145;
        private IHIS.Framework.XEditGridCell xEditGridCell146;
        private IHIS.Framework.XEditGridCell xEditGridCell147;
        private IHIS.Framework.XEditGridCell xEditGridCell148;
        private IHIS.Framework.XEditGridCell xEditGridCell149;
        private IHIS.Framework.XEditGridCell xEditGridCell159;
        private IHIS.Framework.XEditGridCell xEditGridCell161;
        private IHIS.Framework.XEditGrid grdOCS0305;
        private IHIS.Framework.XMstGrid grdOCS0304;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XTextBox txtYaksok_direct_code;
        private IHIS.Framework.XButton btnDirect;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGrid grdOCS0306;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XButton btnInsertOCS0304;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0304U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(grdOCS0304);
            SaveLayoutList.Add(grdOCS0305);
            SaveLayoutList.Add(grdOCS0306);

            //grdOCS0304.SavePerformer = new XSavePerformer(this);
            //grdOCS0305.SavePerformer = grdOCS0304.SavePerformer;
            //grdOCS0306.SavePerformer = grdOCS0304.SavePerformer;


            grdOCS0304.ParamList = new List<string>(new String[] { "f_doctor", "f_yaksok_direct_code", "f_hosp_code" });
            grdOCS0305.ParamList = new List<string>(new String[] { "f_doctor", "f_yaksok_direct_code", "f_hosp_code" });
            grdOCS0306.ParamList = new List<string>(new String[] { "f_doctor", "f_yaksok_direct_code", "f_hosp_code" });

            grdOCS0304.ExecuteQuery = LoadDataGrdOCS0304;
            grdOCS0305.ExecuteQuery = LoadDataGrdOCS0305;
            grdOCS0306.ExecuteQuery = LoadDataGrdOCS0306;
        }

        private IList<object[]> LoadDataGrdOCS0306(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0304U00GrdOCS0306Args args = new OCS0304U00GrdOCS0306Args();
            args.Doctor = varlist["f_doctor"].VarValue;
            args.YaksokDirectCode = varlist["f_yaksok_direct_code"].VarValue;
            OCS0304U00GrdOCS0306Result result =
                CloudService.Instance.Submit<OCS0304U00GrdOCS0306Result, OCS0304U00GrdOCS0306Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<OcsaOCS0304U00GrdOCS0306ListInfo> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (OcsaOCS0304U00GrdOCS0306ListInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Memb,
	                        info.YaksokDirectCode,
	                        info.DirectGubun,
	                        info.DirectCode,
	                        info.DirectDetail,
	                        info.PkSeq,
	                        info.Seq,
	                        info.HangmogCode,
	                        info.Suryang,
	                        info.Nalsu,
	                        info.OrdDanui,
	                        info.BogyongCode,
	                        info.JusaCode,
	                        info.JusaSpdGubun,
	                        info.Dv,
	                        info.DvTime,
	                        info.InsulinFrom,
	                        info.InsulinTo,
	                        info.TimeGubun,
	                        info.BomSourceKey,
	                        info.BomYn
	                    });
                    }
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataGrdOCS0305(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0304U00GrdOCS0305Args args = new OCS0304U00GrdOCS0305Args();
            args.Doctor = varlist["f_doctor"].VarValue;
            args.MembGubun = "1";
            args.YaksokDirectCode = varlist["f_yaksok_direct_code"].VarValue;
            OCS0304U00GrdOCS0305Result result =
                CloudService.Instance.Submit<OCS0304U00GrdOCS0305Result, OCS0304U00GrdOCS0305Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<OcsaOCS0304U00GrdOCS0305ListInfo> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (OcsaOCS0304U00GrdOCS0305ListInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Memb,
	                        info.YaksokDirectCode,
	                        info.PkSeq,
	                        info.DirectGubun,
	                        info.NurGrName,
	                        info.DirectCode,
	                        info.NurMdName,
	                        info.DirectCont1,
	                        info.DirectCont2,
	                        info.DirectText,
	                        info.DirectContYn
	                    });
                    }
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataGrdOCS0304(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS0304U00GrdOCS0304Args args = new OCS0304U00GrdOCS0304Args();
            args.Doctor = varlist["f_doctor"].VarValue;
            args.MembGubun = "1";
            args.YaksokDirectCode = varlist["f_yaksok_direct_code"].VarValue;
            OCS0304U00GrdOCS0304Result result =
                CloudService.Instance.Submit<OCS0304U00GrdOCS0304Result, OCS0304U00GrdOCS0304Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<OcsaOCS0304U00GrdOCS0304ListInfo> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (OcsaOCS0304U00GrdOCS0304ListInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Memb,
	                        info.MembGubun,
	                        info.YaksokDirectCode,
	                        info.YaksokDirectName,
	                        info.Seq,
	                        info.Ment
	                    });
                    }
                }
            }

            return dataList;
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0304U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtYaksok_direct_code = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnInsertOCS0304 = new IHIS.Framework.XButton();
            this.btnDirect = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdOCS0306 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0304 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdOCS0305 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0306)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0304)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0305)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.txtYaksok_direct_code);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.xPictureBox1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // txtYaksok_direct_code
            // 
            this.txtYaksok_direct_code.AccessibleDescription = null;
            this.txtYaksok_direct_code.AccessibleName = null;
            resources.ApplyResources(this.txtYaksok_direct_code, "txtYaksok_direct_code");
            this.txtYaksok_direct_code.BackgroundImage = null;
            this.txtYaksok_direct_code.Name = "txtYaksok_direct_code";
            this.txtYaksok_direct_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtYaksok_direct_code_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.AccessibleDescription = null;
            this.xPictureBox1.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox1, "xPictureBox1");
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.Font = null;
            this.xPictureBox1.ImageLocation = null;
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.TabStop = false;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnInsertOCS0304);
            this.xPanel2.Controls.Add(this.btnDirect);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnInsertOCS0304
            // 
            this.btnInsertOCS0304.AccessibleDescription = null;
            this.btnInsertOCS0304.AccessibleName = null;
            resources.ApplyResources(this.btnInsertOCS0304, "btnInsertOCS0304");
            this.btnInsertOCS0304.BackgroundImage = null;
            this.btnInsertOCS0304.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertOCS0304.Font = null;
            this.btnInsertOCS0304.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertOCS0304.Image")));
            this.btnInsertOCS0304.Name = "btnInsertOCS0304";
            this.btnInsertOCS0304.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnInsertOCS0304.Click += new System.EventHandler(this.btnInsertOCS0304_Click);
            // 
            // btnDirect
            // 
            this.btnDirect.AccessibleDescription = null;
            this.btnDirect.AccessibleName = null;
            resources.ApplyResources(this.btnDirect, "btnDirect");
            this.btnDirect.BackgroundImage = null;
            this.btnDirect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirect.Font = null;
            this.btnDirect.Image = ((System.Drawing.Image)(resources.GetObject("btnDirect.Image")));
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0306
            // 
            resources.ApplyResources(this.grdOCS0306, "grdOCS0306");
            this.grdOCS0306.CallerID = '3';
            this.grdOCS0306.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28});
            this.grdOCS0306.ColPerLine = 21;
            this.grdOCS0306.Cols = 22;
            this.grdOCS0306.ExecuteQuery = null;
            this.grdOCS0306.FixedCols = 1;
            this.grdOCS0306.FixedRows = 1;
            this.grdOCS0306.HeaderHeights.Add(21);
            this.grdOCS0306.MasterLayout = this.grdOCS0304;
            this.grdOCS0306.Name = "grdOCS0306";
            this.grdOCS0306.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0306.ParamList")));
            this.grdOCS0306.QuerySQL = resources.GetString("grdOCS0306.QuerySQL");
            this.grdOCS0306.ReadOnly = true;
            this.grdOCS0306.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0306.RowHeaderVisible = true;
            this.grdOCS0306.Rows = 2;
            this.grdOCS0306.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0306_PreSaveLayout);
            this.grdOCS0306.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0306.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0306_QueryStarting);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor";
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "yaksok_direct_code";
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "direct_gubun";
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "direct_code";
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "direct_detail";
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pk_seq";
            this.xEditGridCell12.Col = 6;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "seq";
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "hangmog_code";
            this.xEditGridCell14.Col = 8;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "suryang";
            this.xEditGridCell16.Col = 9;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "nalsu";
            this.xEditGridCell17.Col = 10;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ord_danui";
            this.xEditGridCell18.Col = 11;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "bogyong_code";
            this.xEditGridCell19.Col = 12;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jusa_code";
            this.xEditGridCell20.Col = 13;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "jusa_spd_gubun";
            this.xEditGridCell21.Col = 14;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "dv";
            this.xEditGridCell22.Col = 15;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "dv_time";
            this.xEditGridCell23.Col = 16;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "insulin_from";
            this.xEditGridCell24.Col = 17;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "insulin_to";
            this.xEditGridCell25.Col = 18;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "time_gubun";
            this.xEditGridCell26.Col = 19;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "bom_source_key";
            this.xEditGridCell27.Col = 20;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bom_yn";
            this.xEditGridCell28.Col = 21;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            // 
            // grdOCS0304
            // 
            resources.ApplyResources(this.grdOCS0304, "grdOCS0304");
            this.grdOCS0304.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell15,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0304.ColPerLine = 6;
            this.grdOCS0304.Cols = 7;
            this.grdOCS0304.ExecuteQuery = null;
            this.grdOCS0304.FixedCols = 1;
            this.grdOCS0304.FixedRows = 1;
            this.grdOCS0304.FocusColumnName = "yaksok_direct_code";
            this.grdOCS0304.HeaderHeights.Add(21);
            this.grdOCS0304.Name = "grdOCS0304";
            this.grdOCS0304.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0304.ParamList")));
            this.grdOCS0304.QuerySQL = resources.GetString("grdOCS0304.QuerySQL");
            this.grdOCS0304.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0304.RowHeaderVisible = true;
            this.grdOCS0304.Rows = 2;
            this.grdOCS0304.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0304_PreSaveLayout);
            this.grdOCS0304.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0304_GridColumnChanged);
            this.grdOCS0304.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0304.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0304_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "memb_gubun";
            this.xEditGridCell15.Col = 4;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "yaksok_direct_code";
            this.xEditGridCell2.CellWidth = 102;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "yaksok_direct_name";
            this.xEditGridCell3.CellWidth = 170;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "seq";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 200;
            this.xEditGridCell5.CellName = "ment";
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOCS0306);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.grdOCS0304);
            this.xPanel3.Controls.Add(this.grdOCS0305);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // grdOCS0305
            // 
            resources.ApplyResources(this.grdOCS0305, "grdOCS0305");
            this.grdOCS0305.CallerID = '2';
            this.grdOCS0305.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell159,
            this.xEditGridCell6,
            this.xEditGridCell161});
            this.grdOCS0305.ColPerLine = 3;
            this.grdOCS0305.Cols = 4;
            this.grdOCS0305.ExecuteQuery = null;
            this.grdOCS0305.FixedCols = 1;
            this.grdOCS0305.FixedRows = 1;
            this.grdOCS0305.HeaderHeights.Add(24);
            this.grdOCS0305.MasterLayout = this.grdOCS0304;
            this.grdOCS0305.Name = "grdOCS0305";
            this.grdOCS0305.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0305.ParamList")));
            this.grdOCS0305.QuerySQL = resources.GetString("grdOCS0305.QuerySQL");
            this.grdOCS0305.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0305.RowHeaderVisible = true;
            this.grdOCS0305.Rows = 2;
            this.grdOCS0305.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0305_PreSaveLayout);
            this.grdOCS0305.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0305.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0305_GridColumnProtectModify);
            this.grdOCS0305.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0305_QueryStarting);
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "doctor";
            this.xEditGridCell138.Col = -1;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsUpdatable = false;
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "yaksok_direct_code";
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsUpdatable = false;
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "pk_seq";
            this.xEditGridCell143.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "direct_gubun";
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.CellName = "direct_gubun_name";
            this.xEditGridCell145.CellWidth = 88;
            this.xEditGridCell145.Col = 1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell145.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell145.SuppressRepeating = true;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "direct_code";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell147.CellName = "direct_code_name";
            this.xEditGridCell147.CellWidth = 157;
            this.xEditGridCell147.Col = 2;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsReadOnly = true;
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell147.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "direct_cont1";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "direct_cont2";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell159.CellLen = 2000;
            this.xEditGridCell159.CellName = "direct_text";
            this.xEditGridCell159.CellWidth = 350;
            this.xEditGridCell159.Col = 3;
            this.xEditGridCell159.DisplayMemoText = true;
            this.xEditGridCell159.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell159.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "direct_cont_yn";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "temp";
            this.xEditGridCell161.Col = -1;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsUpdatable = false;
            this.xEditGridCell161.IsVisible = false;
            this.xEditGridCell161.Row = -1;
            // 
            // OCS0304U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OCS0304U00";
            this.UserChanged += new System.EventHandler(this.OCS0304U00_UserChanged);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0306)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0304)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0305)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "NUR0110Q00": // 지시사항

                    #region
                    if (commandParam.Contains("DIRECT"))
                    {
                        SetDirectInfo((MultiLayout)commandParam["DELETEDIRECT"], (MultiLayout)commandParam["DIRECT"], (MultiLayout)commandParam["DELETEDIRECTDETAIL"], (MultiLayout)commandParam["DIRECT_DETAIL"]); ;
                    }
                    break;
                    #endregion

                case "OCS2005U00": // 지시사항

                    #region
                    if (commandParam.Contains("DIRECT"))
                    {
                        SetDirectInfo((MultiLayout)commandParam["DELETEDIRECT"], (MultiLayout)commandParam["DIRECT"], (MultiLayout)commandParam["DELETEDIRECTDETAIL"], (MultiLayout)commandParam["DIRECTDETAIL"]); ;
                    }

                    //if (commandParam.Contains("DIRECTDETAIL"))
                    //{
                    //    SetDirectInfo((MultiLayout)commandParam["DELETEDIRECT"], (MultiLayout)commandParam["DIRECT"], (MultiLayout)commandParam["DELETEDIRECTDETAIL"], (MultiLayout)commandParam["DIRECTDETAIL"]); ;
                    //}
                    break;
                    #endregion
            }

            if (command == "F") return base.Command(command, commandParam);

            return base.Command(command, commandParam);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            //Set M/D Relation
            grdOCS0305.SetRelationKey("doctor", "doctor");
            grdOCS0305.SetRelationKey("yaksok_direct_code", "yaksok_direct_code");

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0304;
            this.CurrMQLayout = this.grdOCS0304;

            /// 사용자 OCS0304U00_UserChanged Event Call ///////////////////////////////////////////////////////////////////////////
            this.OCS0304U00_UserChanged(this, new System.EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void OCS0304U00_UserChanged(object sender, System.EventArgs e)
        {
            //set Doctor
            LoadDoctor();
            grdOCS0304.QueryLayout(true);

        }

        private bool LoadDoctor()
        {

            // 입력ID를 DoctorID로 고정.
            // 이유는 OCS0130의 통계의사코드의 약속오픈ID 사용에 대해 의문. 2011/05/02.KHJ
            mDoctor = UserInfo.DoctorID;

            if (UserInfo.UserGubun != UserType.Doctor)
                mDoctor = "ADMIN";


            //mDoctor = GetDoctor_yaksok_open_id(UserInfo.DoctorID);
            /*XMessageBox.Show("UserInfo.DoctorID : " +  UserInfo.DoctorID + "\n\r" +
                             "UserInfo.YaksokOpenID : " + UserInfo.YaksokOpenID + "\n\r" +
                             "UserInfo.DoctorID : " + UserInfo.DoctorID);*/
            grdOCS0304.SetBindVarValue("f_doctor", mDoctor);
            //의사코드를 가져온다. Load BAS0280
            return true;
        }

        #endregion

        #region [사용자공통 USER를 가져옵니다.]

        /// <summary>
        /// 해당 사용자의 통계의사코드의 약속 Open_id를 가져옵니다.
        /// </summary>
        /// <param name="aDoctor"></param>
        /// <returns></returns>
        private string GetDoctor_yaksok_open_id(string aDoctor)
        {
            string doctor_yaksok_open_id = "";

            string cmdText = @"SELECT C.YAKSOK_OPEN_ID                                          
                                 FROM OCS0130 C                                            ,    
                                      ( SELECT NVL(A.TONGGYE_DOCTOR, A.DOCTOR ) DOCTOR            
                                          FROM BAS0270 A                                        
                                         WHERE A.HOSP_CODE = :f_hosp_code                        
                                           AND A.DOCTOR    = :f_doctor
                                           AND A.END_DATE  = (SELECT MAX(B.END_DATE)         
                                                                FROM BAS0270 B                 
                                                               WHERE B.HOSP_CODE = A.HOSP_CODE
                                                                 AND B.DOCTOR    = A.DOCTOR ) ) D 
                                 WHERE C.HOSP_CODE  = :f_hosp_code
                                   AND C.MEMB       = D.DOCTOR";

            IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_doctor", aDoctor);
            bindVars.Add("f_hosp_code", mHospCode);

            object retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (retVal != null)
                doctor_yaksok_open_id = retVal.ToString();
            else
                doctor_yaksok_open_id = aDoctor;

            return doctor_yaksok_open_id;
        }

        #endregion

        #region [Load Code Name]

        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "yaksok_direct_code":

                    //                    string cmdText = @"SELECT A.YAKSOK_DIRECT_NAME
                    //                                         FROM OCS0304 A
                    //                                        WHERE A.HOSP_CODE          = :f_hosp_code
                    //                                          AND A.MEMB_GUBUN         = '1'
                    //                                          AND A.YAKSOK_DIRECT_CODE = :f_code
                    //                                          AND A.MEMB               = :f_doctor";

                    //                    IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
                    //                    bindVars.Add("f_doctor",mDoctor);
                    //                    bindVars.Add("f_code",code);
                    //                    bindVars.Add("f_hosp_code", mHospCode);

                    OcsaOCS0304U00GetYaksokDirectNameArgs args = new OcsaOCS0304U00GetYaksokDirectNameArgs("1", code, mDoctor);
                    OcsaOCS0304U00GetYaksokDirectNameResult result =
                        CloudService.Instance
                            .Submit<OcsaOCS0304U00GetYaksokDirectNameResult, OcsaOCS0304U00GetYaksokDirectNameArgs>(args);


                    //object retVal = Service.ExecuteScalar(cmdText,bindVars);

                    //if(retVal == null)
                    if (result.ExecutionStatus != ExecutionStatus.Success)
                    {
                        codeName = "";
                    }
                    else
                        //codeName = retVal.ToString();
                        codeName = result.YaksokDirectName;

                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [ButtonList Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    if (this.CurrMSLayout == grdOCS0304)
                    {
                        e.IsBaseCall = false;
                        this.grdOCS0304.QueryLayout(true);
                    }

                    break;

                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    if (this.CurrMSLayout == grdOCS0304)
                    {
                        int insertRow = grdOCS0304.InsertRow(-1);
                        grdOCS0304.SetItemValue(insertRow, "doctor", mDoctor);
                    }

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    bool saveGrdOcs0304 = SaveGrdOCS0304();
                    bool saveGrdOcs0305 = SaveGrdOCS0305();
                    bool saveGrdOcs0306 = SaveGrdOCS0306();

                    if (!saveGrdOcs0304)
                    {
                        //Fix MED-12043
                        XMessageBox.Show(Resource.MSG_1,Resource.CAP_1,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                    if (!saveGrdOcs0305)
                    {
                        //Fix MED-12043
                        XMessageBox.Show(Resource.MSG_2,Resource.CAP_1,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                    if (!saveGrdOcs0306)
                    {
                        //XMessageBox.Show("SAVE OCS0306 FAILED");
                    }

                    if (saveGrdOcs0306 && saveGrdOcs0304 && saveGrdOcs0305)
                    {
                        //Fix MED-12043
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                        mbxMsg = Resource.MSG_SAVE;
                        SetMsg(mbxMsg);
                        grdOCS0304.QueryLayout(false);
                    }
                    else
                    {
                        //Fix MED-12043
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다.";
                        //mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                        mbxMsg = Resource.MSG_FAIL;
                        mbxCap = Resource.CAP_FAIL;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                    }

                    break;

                case FunctionType.Delete:

                    if (CurrMSLayout == grdOCS0304)
                    {
                        if (CheckDetailData(grdOCS0304))
                        {
                            //Fix MED-12043
                            //mbxMsg = NetInfo.Language == LangMode.Jr ? "細部内訳があり、削除することができません。\n\r 細部内訳を消してから保存してください。" : "세부내역이 있어 삭제할 수 없습니다. \n\r 세부내역을 먼저삭제하신 후 저장하십시오.";
                            //mbxCap = NetInfo.Language == LangMode.Jr ? Resource.OCS0304U00_btnDelete : "삭제";
                            mbxMsg = Resource.MSG_DELETE;
                            mbxCap = Resource.OCS0304U00_btnDelete;
                            XMessageBox.Show(mbxMsg, mbxCap);
                            e.IsBaseCall = false;
                        }
                    }

                    break;

                default:

                    break;
            }
        }

        private bool SaveGrdOCS0306()
        {
            //pre-save
            for (int rowIndex = 0; rowIndex < grdOCS0306.RowCount; rowIndex++)
            {
                if (grdOCS0306.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0306.SetItemValue(rowIndex, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0306.SetItemValue(rowIndex, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
                }
            }

            List<OcsaOCS0304U00GrdOCS0306ListInfo> inputList = GetListFromGrdOCS0306();
            if (inputList.Count == 0)
            {
                return false;
            }

            OCS0304U00GrdOCS0306SaveLayoutArgs args = new OCS0304U00GrdOCS0306SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0304U00GrdOCS0306SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<OcsaOCS0304U00GrdOCS0306ListInfo> GetListFromGrdOCS0306()
        {
            List<OcsaOCS0304U00GrdOCS0306ListInfo> dataList = new List<OcsaOCS0304U00GrdOCS0306ListInfo>();
            for (int i = 0; i < grdOCS0306.RowCount; i++)
            {
                if (grdOCS0306.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                OcsaOCS0304U00GrdOCS0306ListInfo info = new OcsaOCS0304U00GrdOCS0306ListInfo();
                info.Memb = grdOCS0306.GetItemString(i, "doctor");
                info.YaksokDirectCode = grdOCS0306.GetItemString(i, "yaksok_direct_code");
                info.DirectGubun = grdOCS0306.GetItemString(i, "direct_gubun");
                info.DirectCode = grdOCS0306.GetItemString(i, "direct_code");
                info.DirectDetail = grdOCS0306.GetItemString(i, "direct_detail");
                info.PkSeq = grdOCS0306.GetItemString(i, "pk_seq");
                info.Seq = grdOCS0306.GetItemString(i, "seq");
                info.HangmogCode = grdOCS0306.GetItemString(i, "hangmog_code");
                info.Suryang = grdOCS0306.GetItemString(i, "suryang");
                info.Nalsu = grdOCS0306.GetItemString(i, "nalsu");
                info.OrdDanui = grdOCS0306.GetItemString(i, "ord_danui");
                info.BogyongCode = grdOCS0306.GetItemString(i, "bogyong_code");
                info.JusaCode = grdOCS0306.GetItemString(i, "jusa_code");
                info.JusaSpdGubun = grdOCS0306.GetItemString(i, "jusa_spd_gubun");
                info.Dv = grdOCS0306.GetItemString(i, "dv");
                info.DvTime = grdOCS0306.GetItemString(i, "dv_time");
                info.InsulinFrom = grdOCS0306.GetItemString(i, "insulin_from");
                info.InsulinTo = grdOCS0306.GetItemString(i, "insulin_to");
                info.TimeGubun = grdOCS0306.GetItemString(i, "time_gubun");
                info.BomSourceKey = grdOCS0306.GetItemString(i, "bom_source_key");
                info.BomYn = grdOCS0306.GetItemString(i, "bom_yn");
                info.RowState = grdOCS0306.GetRowState(i).ToString();
                dataList.Add(info);
            }


            return dataList;
        }

        private bool SaveGrdOCS0305()
        {
            //pre-save
            for (int rowIndex = 0; rowIndex < grdOCS0305.RowCount; rowIndex++)
            {
                if (grdOCS0305.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0305.SetItemValue(rowIndex, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0305.SetItemValue(rowIndex, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
                }
            }

            List<OcsaOCS0304U00GrdOCS0305ListInfo> inputList = GetListFromGrdOCS0305();
            if (inputList.Count == 0)
            {
                return false;
            }

            OCS0304U00GrdOCS0305SaveLayoutArgs args = new OCS0304U00GrdOCS0305SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0304U00GrdOCS0305SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<OcsaOCS0304U00GrdOCS0305ListInfo> GetListFromGrdOCS0305()
        {
            List<OcsaOCS0304U00GrdOCS0305ListInfo> dataList = new List<OcsaOCS0304U00GrdOCS0305ListInfo>();
            for (int i = 0; i < grdOCS0305.RowCount; i++)
            {
                if (grdOCS0305.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                OcsaOCS0304U00GrdOCS0305ListInfo info = new OcsaOCS0304U00GrdOCS0305ListInfo();
                info.Memb = grdOCS0305.GetItemString(i, "doctor");
                info.YaksokDirectCode = grdOCS0305.GetItemString(i, "yaksok_direct_code");
                info.PkSeq = grdOCS0305.GetItemString(i, "pk_seq");
                info.DirectGubun = grdOCS0305.GetItemString(i, "direct_gubun");
                info.NurGrName = grdOCS0305.GetItemString(i, "direct_gubun_name");
                info.DirectCode = grdOCS0305.GetItemString(i, "direct_code");
                info.NurMdName = grdOCS0305.GetItemString(i, "direct_code_name");
                info.DirectCont1 = grdOCS0305.GetItemString(i, "direct_cont1");
                info.DirectCont2 = grdOCS0305.GetItemString(i, "direct_cont2");
                info.DirectText = grdOCS0305.GetItemString(i, "direct_text");
                info.DirectContYn = grdOCS0305.GetItemString(i, "direct_cont_yn");
                info.RowState = grdOCS0305.GetRowState(i).ToString();
                dataList.Add(info);
            }

            if (grdOCS0305.DeletedRowTable != null && grdOCS0305.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOCS0305.DeletedRowTable.Rows)
                {
                    OcsaOCS0304U00GrdOCS0305ListInfo info = new OcsaOCS0304U00GrdOCS0305ListInfo();
                    info.Memb = row["doctor"].ToString();
                    info.YaksokDirectCode = row["yaksok_direct_code"].ToString();
                    info.PkSeq = row["pk_seq"].ToString();
                    info.DirectGubun = row["direct_gubun"].ToString();
                    info.NurGrName = row["direct_gubun_name"].ToString();
                    info.DirectCode = row["direct_code"].ToString();
                    info.NurMdName = row["direct_code_name"].ToString();
                    info.DirectCont1 = row["direct_cont1"].ToString();
                    info.DirectCont2 = row["direct_cont2"].ToString();
                    info.DirectText = row["direct_text"].ToString();
                    info.DirectContYn = row["direct_cont_yn"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }

        private bool SaveGrdOCS0304()
        {
            //pre-save
            for (int rowIndex = 0; rowIndex < grdOCS0304.RowCount; rowIndex++)
            {
                if (grdOCS0304.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0304.GetItemString(rowIndex, "yaksok_direct_code").Trim() == "")
                    {
                        grdOCS0304.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0304.GetItemString(rowIndex, "seq") != (rowIndex + 1).ToString()) grdOCS0304.SetItemValue(rowIndex, "seq", rowIndex + 1);
            }

            //getList
            List<OcsaOCS0304U00GrdOCS0304ListInfo> inputList = GetListFromGrdOCS0304();
            if (inputList.Count == 0)
            {
                return false;
            }

            OCS0304U00GrdOCS0304SaveLayoutArgs args = new OCS0304U00GrdOCS0304SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0304U00GrdOCS0304SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

        private List<OcsaOCS0304U00GrdOCS0304ListInfo> GetListFromGrdOCS0304()
        {
            List<OcsaOCS0304U00GrdOCS0304ListInfo> dataList = new List<OcsaOCS0304U00GrdOCS0304ListInfo>();
            for (int i = 0; i < grdOCS0304.RowCount; i++)
            {
                if (grdOCS0304.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                OcsaOCS0304U00GrdOCS0304ListInfo info = new OcsaOCS0304U00GrdOCS0304ListInfo();
                info.Memb = grdOCS0304.GetItemString(i, "doctor");
                info.MembGubun = grdOCS0304.GetItemString(i, "memb_gubun");
                info.YaksokDirectCode = grdOCS0304.GetItemString(i, "yaksok_direct_code");
                info.YaksokDirectName = grdOCS0304.GetItemString(i, "yaksok_direct_name");
                info.Seq = grdOCS0304.GetItemString(i, "seq");
                info.Ment = grdOCS0304.GetItemString(i, "ment");
                info.RowState = grdOCS0304.GetRowState(i).ToString();
                dataList.Add(info);
            }

            if (grdOCS0304.DeletedRowTable != null && grdOCS0304.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOCS0304.DeletedRowTable.Rows)
                {
                    OcsaOCS0304U00GrdOCS0304ListInfo info = new OcsaOCS0304U00GrdOCS0304ListInfo();
                    info.Memb = row["doctor"].ToString();
                    info.YaksokDirectCode = row["yaksok_direct_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #endregion

        #region [Control Event]
        private void txtYaksok_direct_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            grdOCS0304.SetBindVarValue("f_yaksok_direct_code", e.DataValue.Trim());
            grdOCS0304.QueryLayout(true);
        }
        #endregion

        #region [grdOCS0304]
        private void grdOCS0304_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "yaksok_direct_code":

                    if (e.ChangeValue.ToString().Trim() == "")
                        break;

                    for (int i = 0; i < grdOCS0304.RowCount; i++)
                    {
                        if (i != grdOCS0304.CurrentRowNumber)
                        {
                            if (grdOCS0304.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "セット指示コードに重複値があります。 ご確認ください。" : "약속지시코드가 중복됩니다. 확인바랍니다.";
                                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdOCS0304.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdOCS0304.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    string yaksok_direct_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

                    if (yaksok_direct_name != "")
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "セット指示コードに重複値があります。 ご確認ください。" : "약속지시코드가 중복됩니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        break;
                    }

                    break;

                default:

                    break;
            }
        }
        #endregion

        #region [지사사항 Setting]
        private void btnDirect_Click(object sender, System.EventArgs e)
        {
            if (grdOCS0304.CurrentRowNumber < 0) return;

            IHIS.Framework.MultiLayout layParaOCS6005 = grdOCS0305.CopyToLayout();
            IHIS.Framework.MultiLayout layParaOCS6006 = grdOCS0306.CopyToLayout();
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("direct_mode", "3");
            openParams.Add("DIRECT", layParaOCS6005);
            openParams.Add("DIRECT_DETAIL", layParaOCS6006);

            //지시사항등록화면
            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void SetDirectInfo(MultiLayout layDeleteDirectInfo, MultiLayout layDirectInfo, MultiLayout layDeleteDirectDetailInfo, MultiLayout layDirectDetailInfo)
        {
            string direct_gubun = "", direct_code = "", pk_seq = "", seq = "";
            int insertRow = -1;

            //지시사항 등록화면에서 삭제된 건 삭제
            foreach (DataRow row in layDeleteDirectInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                for (int i = 0; i < grdOCS0305.RowCount; i++)
                {
                    if (direct_gubun == grdOCS0305.GetItemString(i, "direct_gubun") && direct_code == grdOCS0305.GetItemString(i, "direct_code"))
                    {
                        grdOCS0305.DeleteRow(i);
                        break;
                    }
                }
            }

            foreach (DataRow row in layDirectInfo.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                if (row.RowState == DataRowState.Modified)
                {
                    direct_gubun = row["direct_gubun"].ToString();
                    direct_code = row["direct_code"].ToString();


                    for (int i = 0; i < grdOCS0305.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS0305.GetItemString(i, "direct_gubun") && direct_code == grdOCS0305.GetItemString(i, "direct_code"))
                        {
                            foreach (XEditGridCell cell in grdOCS0305.CellInfos)
                            {
                                if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS0305.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            break;
                        }
                    }
                }

                //새로이 등록한 지시사항 Insert
                if (row.RowState == DataRowState.Added)
                {
                    insertRow = grdOCS0305.InsertRow(-1);

                    grdOCS0305.SetItemValue(insertRow, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0305.SetItemValue(insertRow, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));

                    foreach (XEditGridCell cell in grdOCS0305.CellInfos)
                    {
                        if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS0305.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }
                }
            }

            //지시사항 등록화면에서 삭제된 지시사항세부내역건 삭제			
            foreach (DataRow row in layDeleteDirectDetailInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                pk_seq = row["pk_seq"].ToString();
                seq = row["seq"].ToString();

                for (int i = 0; i < grdOCS0306.RowCount; i++)
                {
                    if (direct_gubun == grdOCS0306.GetItemString(i, "direct_gubun")
                        && direct_code == grdOCS0306.GetItemString(i, "direct_code")
                        && pk_seq == grdOCS0306.GetItemString(i, "pk_seq")
                        && seq == grdOCS0306.GetItemString(i, "seq")
                       )
                    {
                        grdOCS0306.DeleteRow(i);
                        break;
                    }
                }
            }


            foreach (DataRow row in layDirectDetailInfo.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                if (row.RowState == DataRowState.Modified)
                {
                    direct_gubun = row["direct_gubun"].ToString();
                    direct_code = row["direct_code"].ToString();
                    pk_seq = row["pk_seq"].ToString();
                    seq = row["seq"].ToString();


                    for (int i = 0; i < grdOCS0306.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS0306.GetItemString(i, "direct_gubun")
                            && direct_code == grdOCS0306.GetItemString(i, "direct_code")
                            && pk_seq == grdOCS0306.GetItemString(i, "pk_seq")
                            && seq == grdOCS0306.GetItemString(i, "seq")
                           )
                        {
                            foreach (XEditGridCell cell in grdOCS0306.CellInfos)
                            {
                                if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS0306.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            break;
                        }
                    }
                }

                //새로이 등록한 지시사항 Insert
                if (row.RowState == DataRowState.Added)
                {
                    insertRow = grdOCS0306.InsertRow(-1);

                    grdOCS0305.SetItemValue(insertRow, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0305.SetItemValue(insertRow, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));

                    foreach (XEditGridCell cell in grdOCS0306.CellInfos)
                    {
                        if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS0306.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }
                }
            }

        }

        #endregion

        #region [Detail Data존재여부 check]
        /// <summary>
        /// Detail Data 존재여부를 check합니다.
        /// </summary>
        private bool CheckDetailData(object aGrd)
        {
            bool returnValue = false;

            if (aGrd == null) return returnValue;

            XMstGrid mstGrid = null;

            try
            {
                mstGrid = (XMstGrid)aGrd;
            }
            catch
            {
                return returnValue;
            }

            int chk = 0;

            try
            {
                foreach (object obj in this.Controls)
                {
                    if (obj.GetType().Name.ToString().IndexOf("Panel") >= 0)
                    {
                        foreach (object panObj in ((Panel)obj).Controls)
                        {
                            if (panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
                            {
                                chk = chk + ((XGrid)panObj).RowCount;
                            }
                            else if (panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid)
                            {
                                foreach (DataRow row in ((XEditGrid)panObj).LayoutTable.Rows)
                                    if (row.RowState != DataRowState.Added) chk = chk + 1;

                                chk = chk + ((XEditGrid)panObj).DeletedRowCount;

                            }
                            else if (panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid)
                            {
                                foreach (DataRow row in ((XMstGrid)panObj).LayoutTable.Rows)
                                    if (row.RowState != DataRowState.Added) chk = chk + 1;

                                chk = chk + ((XMstGrid)panObj).DeletedRowCount;
                            }
                        }
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0)
                    {
                        foreach (object gbxObj in ((GroupBox)obj).Controls)
                        {
                            if (gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
                            {
                                chk = chk + ((XGrid)gbxObj).RowCount;
                            }
                            else if (gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid)
                            {
                                foreach (DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows)
                                    if (row.RowState != DataRowState.Added) chk = chk + 1;

                                chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;

                            }
                            else if (gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid)
                            {
                                foreach (DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows)
                                    if (row.RowState != DataRowState.Added) chk = chk + 1;

                                chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
                            }
                        }
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
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
            catch { }

            if (chk > 0)
                returnValue = true;

            return returnValue;
        }

        #endregion

        #region [grdOCS0304 Event]
        private void grdOCS0304_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0304.SetBindVarValue("f_doctor", mDoctor);
            grdOCS0304.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region [grdOCS0305 Event]
        private void grdOCS0305_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "direct_text" && e.DataRow["direct_cont_yn"].ToString() == "Y")
                e.Protect = true;
        }

        private void grdOCS0305_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0305.SetBindVarValue("f_doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
            grdOCS0305.SetBindVarValue("f_yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
            grdOCS0305.SetBindVarValue("f_hosp_code", mHospCode);
        }

        #endregion

        #region[grdOCS0306 Event]
        private void grdOCS0306_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0306.SetBindVarValue("f_doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
            grdOCS0306.SetBindVarValue("f_yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
            grdOCS0306.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region [ 저장 전 처리 ]
        private void grdOCS0304_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //grdOCS0304
            for (int rowIndex = 0; rowIndex < grdOCS0304.RowCount; rowIndex++)
            {
                if (grdOCS0304.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0304.GetItemString(rowIndex, "yaksok_direct_code").Trim() == "")
                    {
                        grdOCS0304.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0304.GetItemString(rowIndex, "seq") != (rowIndex + 1).ToString()) grdOCS0304.SetItemValue(rowIndex, "seq", rowIndex + 1);
            }
        }

        private void grdOCS0305_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //grdOCS0305
            for (int rowIndex = 0; rowIndex < grdOCS0305.RowCount; rowIndex++)
            {
                if (grdOCS0305.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0305.SetItemValue(rowIndex, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0305.SetItemValue(rowIndex, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
                }
            }
        }

        private void grdOCS0306_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            //grdOCS0306
            for (int rowIndex = 0; rowIndex < grdOCS0306.RowCount; rowIndex++)
            {
                if (grdOCS0306.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0306.SetItemValue(rowIndex, "doctor", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "doctor"));
                    grdOCS0306.SetItemValue(rowIndex, "yaksok_direct_code", grdOCS0304.GetItemString(grdOCS0304.CurrentRowNumber, "yaksok_direct_code"));
                }
            }
        }
        #endregion

        #region [SaveEnd]
        private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            switch (e.CallerID)
            {
                case '1':
                    isgrdOCS0304Save = e.IsSuccess;
                    isSavedOCS0304 = true;
                    break;
                case '2':
                    isgrdOCS0305Save = e.IsSuccess;
                    isSavedOCS0305 = true;
                    break;
                case '3':
                    isgrdOCS0306Save = e.IsSuccess;
                    isSavedOCS0306 = true;
                    break;
            }

            if (isSavedOCS0304 && isSavedOCS0305 && isSavedOCS0306)
            {
                if (isgrdOCS0304Save && isgrdOCS0305Save && isgrdOCS0306Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                    SetMsg(mbxMsg);
                    grdOCS0304.QueryLayout(false);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다.";
                    mbxMsg = mbxMsg + e.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                }

                isgrdOCS0304Save = false;
                isgrdOCS0305Save = false;
                isgrdOCS0306Save = false;

                isSavedOCS0304 = false;
                isSavedOCS0305 = false;
                isSavedOCS0306 = false;
            }
        }
        #endregion

        #region [XSavePerformer Class]
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {
        //            private OCS0304U00 parent = null;

        //            public XSavePerformer(OCS0304U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("f_user_id",UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

        //                switch(callerID)
        //                {
        //                    case '1':
        //                        switch(item.RowState)	
        //                        {
        //                            case DataRowState.Added :
        //                                cmdText = @"INSERT INTO OCS0304
        //                                                 ( SYS_DATE             , SYS_ID                , MEMB      , MEMB_GUBUN ,
        //                                                   YAKSOK_DIRECT_CODE   , YAKSOK_DIRECT_NAME    , SEQ       , MENT  , HOSP_CODE) 
        //                                             VALUES 
        //                                                 ( SYSDATE              , :f_user_id            , :f_doctor , NVL(:f_memb_gubun, '1') ,
        //                                                   :f_yaksok_direct_code, :f_yaksok_direct_name , :f_seq  , :f_ment , :f_hosp_code)";
        //                                break;
        //                            case DataRowState.Modified :
        //                                cmdText = @"UPDATE OCS0304
        //                                               SET UPD_ID             = :f_user_id           , 
        //                                                   UPD_DATE           = SYSDATE              , 
        //                                                   SEQ                = :f_seq               , 
        //                                                   YAKSOK_DIRECT_NAME = :f_yaksok_direct_name, 
        //                                                   MENT               = :f_ment 
        //                                             WHERE MEMB               = :f_doctor 
        //                                               AND MEMB_GUBUN         = '1'
        //                                               AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code
        //                                               AND HOSP_CODE          = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted :
        //                                cmdText = @"DELETE OCS0304
        //										     WHERE MEMB               = :f_doctor
        //                                               AND MEMB_GUBUN         = '1'
        //										       AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code
        //                                               AND HOSP_CODE          = :f_hosp_code";
        //                                break;
        //                        }
        //                        break;
        //                    case '2':
        //                        switch(item.RowState)
        //                        {
        //                            case DataRowState.Added :
        //                                cmdText = @"INSERT INTO OCS0305
        //                                                  ( SYS_DATE              , SYS_ID           , MEMB             , MEMB_GUBUN       ,
        //                                                    YAKSOK_DIRECT_CODE    , PK_SEQ           , DIRECT_GUBUN     , DIRECT_CODE      , 
        //                                                    DIRECT_CONT1          , DIRECT_CONT2     , DIRECT_TEXT      ,
        //                                                    HOSP_CODE   ) 
        //                                          VALUES  ( SYSDATE               , :f_user_id       , :f_doctor        , NVL(:f_memb_gubun, '1') ,
        //                                                    :f_yaksok_direct_code , NVL(:f_pk_seq, 0), :f_direct_gubun  , :f_direct_code , 
        //                                                    :f_direct_cont1       , :f_direct_cont2  , :f_direct_text   ,
        //                                                    :f_hosp_code )";
        //                                break;
        //                            case DataRowState.Modified :
        //                                cmdText = @"UPDATE OCS0305
        //                                               SET UPD_ID             = :f_user_id       , 
        //                                                   UPD_DATE           = SYSDATE          , 
        //                                                   DIRECT_GUBUN       = :f_direct_gubun  , 
        //                                                   DIRECT_CODE        = :f_direct_code   , 
        //                                                   DIRECT_CONT1       = :f_direct_cont1  , 
        //                                                   DIRECT_CONT2       = :f_direct_cont2  , 
        //                                                   DIRECT_TEXT        = :f_direct_text
        //                                             WHERE MEMB               = :f_doctor
        //                                               AND MEMB_GUBUN         = '1'
        //                                               AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code
        //                                               AND PK_SEQ             = :f_pk_seq
        //                                               AND HOSP_CODE          = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted :
        //                                cmdText = @"BEGIN 
        //                                              DELETE OCS0305 
        //                                               WHERE MEMB               = :f_doctor
        //                                                 AND MEMB_GUBUN         = '1'
        //                                                 AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code 
        //                                                 AND PK_SEQ             = :f_pk_seq
        //                                                 AND HOSP_CODE          = :f_hosp_code; 
        //                                              DELETE OCS0306 
        //                                               WHERE MEMB               = :f_doctor 
        //                                                 AND MEMB_GUBUN         = '1'
        //                                                 AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code
        //                                                 AND PK_SEQ             = :f_pk_seq
        //                                                 AND HOSP_CODE          = :f_hosp_code; 
        //                                            END;";
        //                                break;
        //                        }
        //                        break;
        //                    case '3':
        //                        switch(item.RowState)
        //                        {
        //                            case DataRowState.Added :
        //                                cmdText = @"INSERT INTO OCS0306 
        //                                                      ( SYS_DATE              , SYS_ID           , MEMB             , MEMB_GUBUN       ,
        //                                                        YAKSOK_DIRECT_CODE    , DIRECT_GUBUN     , DIRECT_CODE      , PK_SEQ           , 
        //                                                        DIRECT_DETAIL         , SEQ              , HOSP_CODE        ,
        //                                                        HANGMOG_CODE          , SURYANG          , NALSU            , ORD_DANUI        ,
        //                                                        BOGYONG_CODE          , JUSA_CODE        , JUSA_SPD_GUBUN   , DV               ,
        //                                                        DV_TIME               , INSULIN_FROM     , INSULIN_TO       , TIME_GUBUN       ,
        //                                                        BOM_SOURCE_KEY        , BOM_YN
        //                                                      )
        //                                                VALUES( SYSDATE               , :f_user_id       , :f_doctor        , NVL(:f_memb_gubun, '1'),
        //                                                        :f_yaksok_direct_code , :f_direct_gubun  , :f_direct_code   , :f_pk_seq, 
        //                                                        :f_direct_detail      , :f_seq           , :f_hosp_code     , 
        //                                                        :f_hangmog_code       , :f_suryang       , :f_nalsu         , :f_ord_danui        ,
        //                                                        :f_bogyong_code       , :f_jusa_code     , :f_jusa_spd_gubun, :f_dv               ,
        //                                                        :f_dv_time            , :f_insulin_from  , :f_insulin_to    , :f_time_gubun       ,
        //                                                        :f_bom_source_key     , :f_bom_yn
        //                                                      )";
        //                                break;
        //                            case DataRowState.Modified :
        //                                cmdText = @"UPDATE OCS0306
        //                                               SET UPD_ID             = :f_user_id      , 
        //                                                   UPD_DATE           = SYSDATE         , 
        //                                                   SEQ                = :f_seq          ,
        //                                                   HANGMOG_CODE       = :f_hangmog_code ,
        //                                                   SURYANG            = :f_surayng      ,
        //                                                   NALSU              = :f_nalsu        ,
        //                                                   ORD_DANUI          = :f_ord_danui    ,
        //                                                   BOGYONG_CODE       = :f_bogyong_code ,
        //                                                   JUSA_CODE          = :f_jusa_code    ,
        //                                                   JUSA_SPD_GUBUN     = :f_jusa_spd_gubun,
        //                                                   DV                 = :f_dv           ,
        //                                                   DV_TIME            = :f_dv_time      ,
        //                                                   INSULIN_FROM       = :f_insulin_from ,
        //                                                   INSULIN_TO         = :f_insulin_to   ,
        //                                                   TIME_GUBUN         = :f_time_gubun   ,
        //                                                   BOM_YN             = :f_bom_yn       ,
        //                                                   BOM_SOURCE_KEY     = :f_bom_source_key
        //                                             WHERE MEMB               = :f_doctor
        //                                               AND MEMB_GUBUN         = '1' 
        //                                               AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code 
        //                                               AND DIRECT_GUBUN       = :f_direct_gubun 
        //                                               AND DIRECT_CODE        = :f_direct_code 
        //                                               AND PK_SEQ             = :f_pk_seq
        //                                               AND HOSP_CODE          = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted :
        ////                                cmdText = @"DELETE OCS0306
        ////											 WHERE MEMB               = :f_doctor
        ////                                               AND MEMB_GUBUN         = '1'
        ////											   AND YAKSOK_DIRECT_CODE = :f_yaksok_direct_code
        ////											   AND DIRECT_GUBUN       = :f_direct_gubun
        ////											   AND DIRECT_CODE        = :f_direct_code
        ////											   AND PK_SEQ             = :f_pk_seq
        ////                                               AND HOSP_CODE          = :f_hosp_code";
        //                                break;
        //                        }
        //                        break;
        //                }

        //                if (cmdText == "")
        //                    return true;

        //                return Service.ExecuteNonQuery(cmdText,item.BindVarList);
        //            }
        //        }
        #endregion

        private void btnInsertOCS0304_Click(object sender, EventArgs e)
        {
            if (this.CurrMSLayout == grdOCS0304)
            {
                int insertRow = grdOCS0304.InsertRow(-1);
                grdOCS0304.SetItemValue(insertRow, "doctor", mDoctor);
            }
        }

    }
}

