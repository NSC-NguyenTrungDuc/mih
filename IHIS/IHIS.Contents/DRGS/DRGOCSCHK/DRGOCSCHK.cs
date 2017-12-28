#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.INVS;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Utility;
using IHIS.DRGS.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRGOCSCHK에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRGOCSCHK : IHIS.Framework.XScreen
    {
        #region Controls

        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdOcsChk;
        private XPanel panel2;
        private XLabel xLabel1;
        private XTextBox txtJaeryoCode;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XGridHeader xGridHeader1;
        private XLabel xLabel7;
        private XTextBox txtJaeryoName;
        private XLabel xLabel6;
        private XDisplayBox dbxSmallCodeName;
        private XFindBox fbxSmallCode;
        private XLabel xLabel8;
        private XDisplayBox dbxPreSmallCodeName;
        private XFindBox fbxPreSmallCode;
        private Panel panel3;
        private XLabel xLabel9;
        private XRadioButton rbxDrgPackAll;
        private XRadioButton rbxDrgPackN;
        private XRadioButton rbxDrgPackY;
        private Panel panel7;
        private XRadioButton rbxMayakN;
        private XRadioButton rbxMayakY;
        private XRadioButton rbxMayakAll;
        private XLabel xLabel13;
        private Panel panel6;
        private XRadioButton rbxHubalN;
        private XRadioButton rbxHubalY;
        private XRadioButton rbxHubalAll;
        private XLabel xLabel12;
        private Panel panel5;
        private XRadioButton rbxPowderN;
        private XRadioButton rbxPowderY;
        private XRadioButton rbxPowderAll;
        private XLabel xLabel11;
        private Panel panel4;
        private XRadioButton rbxPhamarcyN;
        private XRadioButton rbxPhamarcyY;
        private XRadioButton rbxPhamarcyAll;
        private XLabel xLabel10;
        private Panel panel8;
        private XRadioButton rbxBeforeUseN;
        private XRadioButton rbxBeforeUseY;
        private XRadioButton rbxBeforeUseAll;
        private XLabel xLabel14;
        private XLabel xLabel15;
        private XDisplayBox dbxCautionName;
        private XFindBox fbxCautionCode;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XFindWorker fwkCautionCode;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XPanel xPanel1;
        private XPanel xPanel2;
        private XEditGrid grdOCS0108;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell70;
        private XGridHeader xGridHeader5;
        private XGridHeader xGridHeader6;
        private XEditGridCell xEditGridCell12;
        private MultiLayout layDanui;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private Panel panel9;
        private XRadioButton rbxStockN;
        private XRadioButton rbxStockY;
        private XRadioButton rbxStockAll;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XGroupBox gbox;
        private Panel panel10;
        private XRadioButton rbxWonnaeDrgN;
        private XRadioButton rbxWonnaeDrgY;
        private XRadioButton rbxWonnaeDrgAll;
        private XLabel xLabel3;
        private XPanel xPanel3;
        private XPanel xPanel4;
        private XButton btnExportExcel;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XDictComboBox cbxJaeryoGubun;
        private XComboItem xComboItem8;
        private XComboItem xComboItem9;
        private XComboItem xComboItem10;
        private XLabel xLabel4;
        private System.ComponentModel.Container components = null;
        #endregion

        private string JaeryoCode = "";
        private string JaeryoName = "";
        private string DrgPackYn = "";
        private string PhamarcyYn = "";
        private string PowerYn = "";
        private string HubalChangeYn = "";
        private string MayakYn = "";
        private string SmallCode = "";
        private string SmallCodeName = "";
        private string CautionCode = "";
        private string CautionName = "";
        private string StartDate = "";
        private string SunabDanui = "";
        private string SunabDanuiName = "";
        private string StockYn = "";
        private string SubulDanga = "";
        private string SubulQcodeOut = "";
        private string SubulQcodeOutName = "";
        private string SubulQcodeInp = "";
        private string SubulQcodeInpName = "";

        private string ChangeDanui1 = "";
        private string ChangeDanui2 = "";
        private string ChangeQty1 = "";
        private string ChangeQty2 = "";
        private string HangmogCode = "";
        private string HangmogStartDate = "";
        private string HospCode = "";
        private string OrdDanui = "";
        private string Seq = "";
        private string RowState = "";
        


        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>


        public DRGOCSCHK()
        {

            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set

            //this.grdOcsChk.SavePerformer = new XSavePerformer(this);


            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOcsChk);





            //tungtx
            this.grdOcsChk.ParamList = new List<string>(new String[] { "f_before_use_yn", "f_jaeryo_code", "f_jaeryo_name", "f_pre_small_code", "f_small_code", "f_drg_pack_yn", "f_phamarcy_yn", "f_powder_yn", "f_hubal_yn", "f_mayak_yn", "f_stock_yn", "f_hosp_code", "f_page_number", "f_wonnae_drg_yn", "f_page_number", "f_offset" });
            grdOcsChk.ExecuteQuery = LoadDataGrdOcsChk;
            grdOCS0108.ExecuteQuery = LoadDataGrdOCS0108;
            cbxJaeryoGubun.ExecuteQuery = LoadcbxJaeryoGubun;
            
            cbxJaeryoGubun.SetDictDDLB();

            fwkCautionCode.ExecuteQuery = LoadDataFwkCautionCode;

            if (!TypeCheck.IsNull(OpenParam) && OpenParam.Contains("hangmog_code"))
            {
                this.txtJaeryoCode.Text = OpenParam["hangmog_code"].ToString();

                this.grdOcsChk.QueryLayout(false);
                //this.grdOCS0108.QueryLayout(false);

                if (grdOcsChk.RowCount == 0)
                {
                    grdOcsChk.InsertRow();
                    grdOcsChk.SetItemValue(0, "hangmog_code", txtJaeryoCode.Text);

                    if (OpenParam.Contains("hangmog_name"))
                    {
                        grdOcsChk.SetItemValue(0, "hangmog_name", OpenParam["hangmog_name"].ToString());
                    }

                }
            }
        }

        private IList<object[]> LoadDataFwkCautionCode(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            DRGOCSCHKGetCautionListArgs args = new DRGOCSCHKGetCautionListArgs();
            //DRGOCSCHKGetCautionListResult result =
            //    //CacheService.Instance.Get<DRGOCSCHKGetCautionListArgs, DRGOCSCHKGetCautionListResult>(
            //    //    Constants.CacheKeyCbo.CACHE_DRG_FWK_CAUTION_LIST_KEYS, args);
            //    CloudService.Instance.Submit<DRGOCSCHKGetCautionListResult, DRGOCSCHKGetCautionListArgs>(args);
            //DRGOCSCHKGetCautionListResult result = CacheService.Instance.Get<DRGOCSCHKGetCautionListArgs, DRGOCSCHKGetCautionListResult>(args);
            
            //https://sofiamedix.atlassian.net/browse/MED-13661
            DRGOCSCHKGetCautionListResult result = CloudService.Instance.Submit<DRGOCSCHKGetCautionListResult, DRGOCSCHKGetCautionListArgs>(args);
            if (result != null)
            {
                List<ComboListItemInfo> fwkList = result.ListItem;
                if (fwkList != null && fwkList.Count > 0)
                {
                    foreach (ComboListItemInfo info in fwkList)
                    {
                        dataList.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataGrdOcsChk(BindVarCollection varlist)
        {
            string jaeryogunbun = "";
            if (cbxJaeryoGubun.GetDataValue() == "")
            {
                jaeryogunbun = "%";
            }
            else {
                jaeryogunbun = cbxJaeryoGubun.GetDataValue();
            }
            IList<object[]> dataList = new List<object[]>();

            DRGOCSCHKGrdOcsChkFullArgs args = new DRGOCSCHKGrdOcsChkFullArgs();
            args.JaeryoCode = varlist["f_jaeryo_code"].VarValue;
            args.JaeryoName = varlist["f_jaeryo_name"].VarValue;
            args.PreSmallCode = varlist["f_pre_small_code"].VarValue;
            args.SmallCode = varlist["f_small_code"].VarValue;
            args.DrgPackYn = varlist["f_drg_pack_yn"].VarValue;
            args.PhamarcyYn = varlist["f_phamarcy_yn"].VarValue;
            args.PowderYn = varlist["f_powder_yn"].VarValue;
            args.HubalYn = varlist["f_hubal_yn"].VarValue;
            args.MayakYn = varlist["f_mayak_yn"].VarValue;
            args.StockYn = varlist["f_stock_yn"].VarValue;
            args.BeforeUseYn = varlist["f_before_use_yn"].VarValue;
            args.WonnaeDrgYn = varlist["f_wonnae_drg_yn"].VarValue;
            args.JaeryoGubun = jaeryogunbun;//cbxJaeryoGubun.GetDataValue();            
            args.PageNumber = varlist["f_page_number"] != null ? varlist["f_page_number"].VarValue : "";
            args.Offset = "200";

            DRGOCSCHKGrdOcsChkFullResult res = CloudService.Instance.Submit<DRGOCSCHKGrdOcsChkFullResult, DRGOCSCHKGrdOcsChkFullArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.ListItem != null)
            {
                List<DRGOCSCHKGrdOcsChkFullInfo> grdList = res.ListItem;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRGOCSCHKGrdOcsChkFullInfo info in grdList)
                    {
                        dataList.Add(new object[]
                            {
                                info.JaeryoCode,
                                info.JaeryoName,
                                info.DrgPackYn,
                                info.PhamarcyYn,
                                info.PowerYn,
                                info.HubalChangeYn,
                                info.MayakYn,
                                info.SmallCode,
                                info.SmallCodeName,
                                info.CautionCode,
                                info.CautionName,
                                info.StartDate,
                                info.SunabDanuiName,
                                info.SunabDanui,
                                info.SubulDanuiName,
                                info.SubulDanui,
                                info.StockYn,
                                info.SubulDanga,
                                info.SubulQcodeOut,
                                info.SubulQcodeOutName,
                                info.SubulQcodeInp,
                                info.SubulQcodeInpName

                            });
                    }
                }
            }


            return dataList;
        }

        //Load data for grdOCS0108
        private IList<object[]> LoadDataGrdOCS0108(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            DRGOCSCHKgrdOCS0108Args args = new DRGOCSCHKgrdOCS0108Args();
            args.HangmogCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hangmog_code");
            args.HospCode = UserInfo.HospCode;
            args.HangmogStartdate = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "start_date"); 

            DRGOCSCHKgrdOCS0108Result result =
                CloudService.Instance.Submit<DRGOCSCHKgrdOCS0108Result, DRGOCSCHKgrdOCS0108Args>(args);
            if (result != null)
            {
                List<DRGOCSCHKgrdOCS0108Info> grdList = result.ListInfo;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DRGOCSCHKgrdOCS0108Info info in grdList)
                    {
                        dataList.Add(new object[]
                        {
                            info.HangmogCode,
                            info.OrdDanui,
                            info.Seq,
                            info.ChangeQty1,
                            info.ChangeQty2,
                            info.HospCode,
                            info.HangmogStartDate,
                            info.ChangeDanui1,
                            info.ChangeDanui2,
                            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRGOCSCHK));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdOcsChk = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.fbxCautionCode = new IHIS.Framework.XFindBox();
            this.fwkCautionCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dbxCautionName = new IHIS.Framework.XDisplayBox();
            this.panel2 = new IHIS.Framework.XPanel();
            this.gbox = new IHIS.Framework.XGroupBox();
            this.cbxJaeryoGubun = new IHIS.Framework.XDictComboBox();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.rbxWonnaeDrgN = new IHIS.Framework.XRadioButton();
            this.rbxWonnaeDrgY = new IHIS.Framework.XRadioButton();
            this.rbxWonnaeDrgAll = new IHIS.Framework.XRadioButton();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rbxBeforeUseN = new IHIS.Framework.XRadioButton();
            this.rbxBeforeUseY = new IHIS.Framework.XRadioButton();
            this.rbxBeforeUseAll = new IHIS.Framework.XRadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rbxStockN = new IHIS.Framework.XRadioButton();
            this.rbxStockY = new IHIS.Framework.XRadioButton();
            this.rbxStockAll = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtJaeryoCode = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.txtJaeryoName = new IHIS.Framework.XTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rbxMayakN = new IHIS.Framework.XRadioButton();
            this.rbxMayakY = new IHIS.Framework.XRadioButton();
            this.rbxMayakAll = new IHIS.Framework.XRadioButton();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.fbxPreSmallCode = new IHIS.Framework.XFindBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rbxHubalN = new IHIS.Framework.XRadioButton();
            this.rbxHubalY = new IHIS.Framework.XRadioButton();
            this.rbxHubalAll = new IHIS.Framework.XRadioButton();
            this.dbxPreSmallCodeName = new IHIS.Framework.XDisplayBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbxPowderN = new IHIS.Framework.XRadioButton();
            this.rbxPowderY = new IHIS.Framework.XRadioButton();
            this.rbxPowderAll = new IHIS.Framework.XRadioButton();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.fbxSmallCode = new IHIS.Framework.XFindBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbxPhamarcyN = new IHIS.Framework.XRadioButton();
            this.rbxPhamarcyY = new IHIS.Framework.XRadioButton();
            this.rbxPhamarcyAll = new IHIS.Framework.XRadioButton();
            this.dbxSmallCodeName = new IHIS.Framework.XDisplayBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbxDrgPackN = new IHIS.Framework.XRadioButton();
            this.rbxDrgPackY = new IHIS.Framework.XRadioButton();
            this.rbxDrgPackAll = new IHIS.Framework.XRadioButton();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0108 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.layDanui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnExportExcel = new IHIS.Framework.XButton();
            this.xPanel4 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcsChk)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbox.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDanui)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(2, "excel.gif");
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdOcsChk
            // 
            this.grdOcsChk.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOcsChk, "grdOcsChk");
            this.grdOcsChk.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell16,
            this.xEditGridCell14,
            this.xEditGridCell17,
            this.xEditGridCell15,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell21,
            this.xEditGridCell20,
            this.xEditGridCell22});
            this.grdOcsChk.ColPerLine = 15;
            this.grdOcsChk.Cols = 16;
            this.grdOcsChk.ControlBinding = true;
            this.grdOcsChk.ExecuteQuery = null;
            this.grdOcsChk.FixedCols = 1;
            this.grdOcsChk.FixedRows = 2;
            this.grdOcsChk.HeaderHeights.Add(21);
            this.grdOcsChk.HeaderHeights.Add(21);
            this.grdOcsChk.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOcsChk.IsAllDataQuery = true;
            this.grdOcsChk.Name = "grdOcsChk";
            this.grdOcsChk.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOcsChk.ParamList")));
            this.grdOcsChk.QuerySQL = resources.GetString("grdOcsChk.QuerySQL");
            this.grdOcsChk.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOcsChk.RowHeaderVisible = true;
            this.grdOcsChk.Rows = 3;
            this.grdOcsChk.ToolTipActive = true;
            this.grdOcsChk.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOcsChk_GridFindClick);
            this.grdOcsChk.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOcsChk_RowFocusChanged);
            this.grdOcsChk.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOcsChk_GridColumnChanged);
            this.grdOcsChk.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOcsChk_QueryStarting);
            this.grdOcsChk.PreEndInitializing += new System.EventHandler(this.grdOcsChk_PreEndInitializing_1);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderBackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 201;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "drg_pack_yn";
            this.xEditGridCell3.CellWidth = 33;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "phamarcy";
            this.xEditGridCell4.CellWidth = 50;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "powder_yn";
            this.xEditGridCell5.CellWidth = 35;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "hubal_change_yn";
            this.xEditGridCell6.CellWidth = 61;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bunryu2";
            this.xEditGridCell7.CellWidth = 35;
            this.xEditGridCell7.CheckedValue = "1";
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell7.UnCheckedValue = "0";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 5;
            this.xEditGridCell8.CellName = "small_code";
            this.xEditGridCell8.CellWidth = 75;
            this.xEditGridCell8.Col = 8;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.Row = 1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "small_code_name";
            this.xEditGridCell9.CellWidth = 216;
            this.xEditGridCell9.Col = 9;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "caution_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "caution_name";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "start_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sunab_danui";
            this.xEditGridCell13.CellWidth = 60;
            this.xEditGridCell13.Col = 11;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "sunab_danui_name";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "subul_danui";
            this.xEditGridCell14.CellWidth = 60;
            this.xEditGridCell14.Col = 12;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "subul_danui_name";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "stock_yn";
            this.xEditGridCell15.CellWidth = 60;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "subul_danga";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell18.CellWidth = 60;
            this.xEditGridCell18.Col = 13;
            this.xEditGridCell18.DecimalDigits = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "subul_qcode_out";
            this.xEditGridCell19.CellWidth = 100;
            this.xEditGridCell19.Col = 14;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell19.UserSQL = resources.GetString("xEditGridCell19.UserSQL");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "subul_qcode_out_name";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "subul_qcode_inp";
            this.xEditGridCell20.CellWidth = 100;
            this.xEditGridCell20.Col = 15;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell20.UserSQL = resources.GetString("xEditGridCell20.UserSQL");
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "subul_qcode_inp_name";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 75;
            // 
            // fbxCautionCode
            // 
            resources.ApplyResources(this.fbxCautionCode, "fbxCautionCode");
            this.fbxCautionCode.FindWorker = this.fwkCautionCode;
            this.fbxCautionCode.Name = "fbxCautionCode";
            this.fbxCautionCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxCautionCode_DataValidating);
            // 
            // fwkCautionCode
            // 
            this.fwkCautionCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCautionCode.ExecuteQuery = null;
            this.fwkCautionCode.FormText = global::IHIS.DRGS.Properties.Resources.Header1;
            this.fwkCautionCode.InputSQL = "SELECT CAUTION_CODE\r\n     , CAUTION_NAME\r\n  FROM DRG0130\r\n WHERE HOSP_CODE = fn_a" +
    "dm_load_hosp_code()\r\n ORDER BY 1";
            this.fwkCautionCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCautionCode.ParamList")));
            this.fwkCautionCode.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkCautionCode.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "caution_code";
            this.findColumnInfo1.ColWidth = 102;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "caution_name";
            this.findColumnInfo2.ColWidth = 427;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // dbxCautionName
            // 
            resources.ApplyResources(this.dbxCautionName, "dbxCautionName");
            this.dbxCautionName.Name = "dbxCautionName";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.gbox);
            this.panel2.Name = "panel2";
            // 
            // gbox
            // 
            resources.ApplyResources(this.gbox, "gbox");
            this.gbox.Controls.Add(this.cbxJaeryoGubun);
            this.gbox.Controls.Add(this.xLabel4);
            this.gbox.Controls.Add(this.panel10);
            this.gbox.Controls.Add(this.xLabel3);
            this.gbox.Controls.Add(this.panel8);
            this.gbox.Controls.Add(this.panel9);
            this.gbox.Controls.Add(this.xLabel1);
            this.gbox.Controls.Add(this.xLabel2);
            this.gbox.Controls.Add(this.txtJaeryoCode);
            this.gbox.Controls.Add(this.xLabel6);
            this.gbox.Controls.Add(this.xLabel14);
            this.gbox.Controls.Add(this.txtJaeryoName);
            this.gbox.Controls.Add(this.panel7);
            this.gbox.Controls.Add(this.xLabel7);
            this.gbox.Controls.Add(this.xLabel13);
            this.gbox.Controls.Add(this.fbxPreSmallCode);
            this.gbox.Controls.Add(this.panel6);
            this.gbox.Controls.Add(this.dbxPreSmallCodeName);
            this.gbox.Controls.Add(this.xLabel12);
            this.gbox.Controls.Add(this.xLabel8);
            this.gbox.Controls.Add(this.panel5);
            this.gbox.Controls.Add(this.xLabel9);
            this.gbox.Controls.Add(this.xLabel11);
            this.gbox.Controls.Add(this.fbxSmallCode);
            this.gbox.Controls.Add(this.panel4);
            this.gbox.Controls.Add(this.dbxSmallCodeName);
            this.gbox.Controls.Add(this.xLabel10);
            this.gbox.Controls.Add(this.panel3);
            this.gbox.Name = "gbox";
            this.gbox.Protect = true;
            this.gbox.TabStop = false;
            // 
            // cbxJaeryoGubun
            // 
            resources.ApplyResources(this.cbxJaeryoGubun, "cbxJaeryoGubun");
            this.cbxJaeryoGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem8,
            this.xComboItem9,
            this.xComboItem10});
            this.cbxJaeryoGubun.ExecuteQuery = null;
            this.cbxJaeryoGubun.Name = "cbxJaeryoGubun";
            this.cbxJaeryoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJaeryoGubun.ParamList")));
            this.cbxJaeryoGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxJaeryoGubun.UserSQL = resources.GetString("cbxJaeryoGubun.UserSQL");
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "%";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "1";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "2";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // panel10
            // 
            resources.ApplyResources(this.panel10, "panel10");
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.rbxWonnaeDrgN);
            this.panel10.Controls.Add(this.rbxWonnaeDrgY);
            this.panel10.Controls.Add(this.rbxWonnaeDrgAll);
            this.panel10.Name = "panel10";
            // 
            // rbxWonnaeDrgN
            // 
            resources.ApplyResources(this.rbxWonnaeDrgN, "rbxWonnaeDrgN");
            this.rbxWonnaeDrgN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxWonnaeDrgN.ImageList = this.ImageList;
            this.rbxWonnaeDrgN.Name = "rbxWonnaeDrgN";
            this.rbxWonnaeDrgN.UseVisualStyleBackColor = false;
            this.rbxWonnaeDrgN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxWonnaeDrgY
            // 
            resources.ApplyResources(this.rbxWonnaeDrgY, "rbxWonnaeDrgY");
            this.rbxWonnaeDrgY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxWonnaeDrgY.ImageList = this.ImageList;
            this.rbxWonnaeDrgY.Name = "rbxWonnaeDrgY";
            this.rbxWonnaeDrgY.UseVisualStyleBackColor = false;
            this.rbxWonnaeDrgY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxWonnaeDrgAll
            // 
            resources.ApplyResources(this.rbxWonnaeDrgAll, "rbxWonnaeDrgAll");
            this.rbxWonnaeDrgAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxWonnaeDrgAll.Checked = true;
            this.rbxWonnaeDrgAll.Name = "rbxWonnaeDrgAll";
            this.rbxWonnaeDrgAll.TabStop = true;
            this.rbxWonnaeDrgAll.UseVisualStyleBackColor = false;
            this.rbxWonnaeDrgAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // panel8
            // 
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.rbxBeforeUseN);
            this.panel8.Controls.Add(this.rbxBeforeUseY);
            this.panel8.Controls.Add(this.rbxBeforeUseAll);
            this.panel8.Name = "panel8";
            // 
            // rbxBeforeUseN
            // 
            resources.ApplyResources(this.rbxBeforeUseN, "rbxBeforeUseN");
            this.rbxBeforeUseN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxBeforeUseN.ImageList = this.ImageList;
            this.rbxBeforeUseN.Name = "rbxBeforeUseN";
            this.rbxBeforeUseN.UseVisualStyleBackColor = false;
            this.rbxBeforeUseN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxBeforeUseY
            // 
            resources.ApplyResources(this.rbxBeforeUseY, "rbxBeforeUseY");
            this.rbxBeforeUseY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxBeforeUseY.ImageList = this.ImageList;
            this.rbxBeforeUseY.Name = "rbxBeforeUseY";
            this.rbxBeforeUseY.UseVisualStyleBackColor = false;
            this.rbxBeforeUseY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxBeforeUseAll
            // 
            resources.ApplyResources(this.rbxBeforeUseAll, "rbxBeforeUseAll");
            this.rbxBeforeUseAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxBeforeUseAll.Checked = true;
            this.rbxBeforeUseAll.Name = "rbxBeforeUseAll";
            this.rbxBeforeUseAll.TabStop = true;
            this.rbxBeforeUseAll.UseVisualStyleBackColor = false;
            this.rbxBeforeUseAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // panel9
            // 
            resources.ApplyResources(this.panel9, "panel9");
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.rbxStockN);
            this.panel9.Controls.Add(this.rbxStockY);
            this.panel9.Controls.Add(this.rbxStockAll);
            this.panel9.Name = "panel9";
            // 
            // rbxStockN
            // 
            resources.ApplyResources(this.rbxStockN, "rbxStockN");
            this.rbxStockN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxStockN.ImageList = this.ImageList;
            this.rbxStockN.Name = "rbxStockN";
            this.rbxStockN.UseVisualStyleBackColor = false;
            this.rbxStockN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxStockY
            // 
            resources.ApplyResources(this.rbxStockY, "rbxStockY");
            this.rbxStockY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxStockY.ImageList = this.ImageList;
            this.rbxStockY.Name = "rbxStockY";
            this.rbxStockY.UseVisualStyleBackColor = false;
            this.rbxStockY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxStockAll
            // 
            resources.ApplyResources(this.rbxStockAll, "rbxStockAll");
            this.rbxStockAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxStockAll.Checked = true;
            this.rbxStockAll.Name = "rbxStockAll";
            this.rbxStockAll.TabStop = true;
            this.rbxStockAll.UseVisualStyleBackColor = false;
            this.rbxStockAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtJaeryoCode
            // 
            resources.ApplyResources(this.txtJaeryoCode, "txtJaeryoCode");
            this.txtJaeryoCode.Name = "txtJaeryoCode";
            this.txtJaeryoCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txt_DataValidating);
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel14
            // 
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.Name = "xLabel14";
            // 
            // txtJaeryoName
            // 
            resources.ApplyResources(this.txtJaeryoName, "txtJaeryoName");
            this.txtJaeryoName.Name = "txtJaeryoName";
            this.txtJaeryoName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txt_DataValidating);
            // 
            // panel7
            // 
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.rbxMayakN);
            this.panel7.Controls.Add(this.rbxMayakY);
            this.panel7.Controls.Add(this.rbxMayakAll);
            this.panel7.Name = "panel7";
            // 
            // rbxMayakN
            // 
            resources.ApplyResources(this.rbxMayakN, "rbxMayakN");
            this.rbxMayakN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxMayakN.ImageList = this.ImageList;
            this.rbxMayakN.Name = "rbxMayakN";
            this.rbxMayakN.UseVisualStyleBackColor = false;
            this.rbxMayakN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxMayakY
            // 
            resources.ApplyResources(this.rbxMayakY, "rbxMayakY");
            this.rbxMayakY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxMayakY.ImageList = this.ImageList;
            this.rbxMayakY.Name = "rbxMayakY";
            this.rbxMayakY.UseVisualStyleBackColor = false;
            this.rbxMayakY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxMayakAll
            // 
            resources.ApplyResources(this.rbxMayakAll, "rbxMayakAll");
            this.rbxMayakAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxMayakAll.Checked = true;
            this.rbxMayakAll.Name = "rbxMayakAll";
            this.rbxMayakAll.TabStop = true;
            this.rbxMayakAll.UseVisualStyleBackColor = false;
            this.rbxMayakAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel13
            // 
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.Name = "xLabel13";
            // 
            // fbxPreSmallCode
            // 
            resources.ApplyResources(this.fbxPreSmallCode, "fbxPreSmallCode");
            this.fbxPreSmallCode.Name = "fbxPreSmallCode";
            this.fbxPreSmallCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxPreSmallCode_FindClick);
            this.fbxPreSmallCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxPreSmallCode_DataValidating);
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.rbxHubalN);
            this.panel6.Controls.Add(this.rbxHubalY);
            this.panel6.Controls.Add(this.rbxHubalAll);
            this.panel6.Name = "panel6";
            // 
            // rbxHubalN
            // 
            resources.ApplyResources(this.rbxHubalN, "rbxHubalN");
            this.rbxHubalN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxHubalN.ImageList = this.ImageList;
            this.rbxHubalN.Name = "rbxHubalN";
            this.rbxHubalN.UseVisualStyleBackColor = false;
            this.rbxHubalN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxHubalY
            // 
            resources.ApplyResources(this.rbxHubalY, "rbxHubalY");
            this.rbxHubalY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxHubalY.ImageList = this.ImageList;
            this.rbxHubalY.Name = "rbxHubalY";
            this.rbxHubalY.UseVisualStyleBackColor = false;
            this.rbxHubalY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxHubalAll
            // 
            resources.ApplyResources(this.rbxHubalAll, "rbxHubalAll");
            this.rbxHubalAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxHubalAll.Checked = true;
            this.rbxHubalAll.Name = "rbxHubalAll";
            this.rbxHubalAll.TabStop = true;
            this.rbxHubalAll.UseVisualStyleBackColor = false;
            this.rbxHubalAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // dbxPreSmallCodeName
            // 
            resources.ApplyResources(this.dbxPreSmallCodeName, "dbxPreSmallCodeName");
            this.dbxPreSmallCodeName.Name = "dbxPreSmallCodeName";
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Name = "xLabel8";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rbxPowderN);
            this.panel5.Controls.Add(this.rbxPowderY);
            this.panel5.Controls.Add(this.rbxPowderAll);
            this.panel5.Name = "panel5";
            // 
            // rbxPowderN
            // 
            resources.ApplyResources(this.rbxPowderN, "rbxPowderN");
            this.rbxPowderN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPowderN.ImageList = this.ImageList;
            this.rbxPowderN.Name = "rbxPowderN";
            this.rbxPowderN.UseVisualStyleBackColor = false;
            this.rbxPowderN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxPowderY
            // 
            resources.ApplyResources(this.rbxPowderY, "rbxPowderY");
            this.rbxPowderY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPowderY.ImageList = this.ImageList;
            this.rbxPowderY.Name = "rbxPowderY";
            this.rbxPowderY.UseVisualStyleBackColor = false;
            this.rbxPowderY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxPowderAll
            // 
            resources.ApplyResources(this.rbxPowderAll, "rbxPowderAll");
            this.rbxPowderAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPowderAll.Checked = true;
            this.rbxPowderAll.Name = "rbxPowderAll";
            this.rbxPowderAll.TabStop = true;
            this.rbxPowderAll.UseVisualStyleBackColor = false;
            this.rbxPowderAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Name = "xLabel11";
            // 
            // fbxSmallCode
            // 
            resources.ApplyResources(this.fbxSmallCode, "fbxSmallCode");
            this.fbxSmallCode.Name = "fbxSmallCode";
            this.fbxSmallCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSmallCode_FindClick);
            this.fbxSmallCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSmallCode_DataValidating);
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rbxPhamarcyN);
            this.panel4.Controls.Add(this.rbxPhamarcyY);
            this.panel4.Controls.Add(this.rbxPhamarcyAll);
            this.panel4.Name = "panel4";
            // 
            // rbxPhamarcyN
            // 
            resources.ApplyResources(this.rbxPhamarcyN, "rbxPhamarcyN");
            this.rbxPhamarcyN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPhamarcyN.ImageList = this.ImageList;
            this.rbxPhamarcyN.Name = "rbxPhamarcyN";
            this.rbxPhamarcyN.UseVisualStyleBackColor = false;
            this.rbxPhamarcyN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxPhamarcyY
            // 
            resources.ApplyResources(this.rbxPhamarcyY, "rbxPhamarcyY");
            this.rbxPhamarcyY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPhamarcyY.ImageList = this.ImageList;
            this.rbxPhamarcyY.Name = "rbxPhamarcyY";
            this.rbxPhamarcyY.UseVisualStyleBackColor = false;
            this.rbxPhamarcyY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxPhamarcyAll
            // 
            resources.ApplyResources(this.rbxPhamarcyAll, "rbxPhamarcyAll");
            this.rbxPhamarcyAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxPhamarcyAll.Checked = true;
            this.rbxPhamarcyAll.Name = "rbxPhamarcyAll";
            this.rbxPhamarcyAll.TabStop = true;
            this.rbxPhamarcyAll.UseVisualStyleBackColor = false;
            this.rbxPhamarcyAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // dbxSmallCodeName
            // 
            resources.ApplyResources(this.dbxSmallCodeName, "dbxSmallCodeName");
            this.dbxSmallCodeName.Name = "dbxSmallCodeName";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Name = "xLabel10";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbxDrgPackN);
            this.panel3.Controls.Add(this.rbxDrgPackY);
            this.panel3.Controls.Add(this.rbxDrgPackAll);
            this.panel3.Name = "panel3";
            // 
            // rbxDrgPackN
            // 
            resources.ApplyResources(this.rbxDrgPackN, "rbxDrgPackN");
            this.rbxDrgPackN.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxDrgPackN.ImageList = this.ImageList;
            this.rbxDrgPackN.Name = "rbxDrgPackN";
            this.rbxDrgPackN.UseVisualStyleBackColor = false;
            this.rbxDrgPackN.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxDrgPackY
            // 
            resources.ApplyResources(this.rbxDrgPackY, "rbxDrgPackY");
            this.rbxDrgPackY.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxDrgPackY.ImageList = this.ImageList;
            this.rbxDrgPackY.Name = "rbxDrgPackY";
            this.rbxDrgPackY.UseVisualStyleBackColor = false;
            this.rbxDrgPackY.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxDrgPackAll
            // 
            resources.ApplyResources(this.rbxDrgPackAll, "rbxDrgPackAll");
            this.rbxDrgPackAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.rbxDrgPackAll.Checked = true;
            this.rbxDrgPackAll.Name = "rbxDrgPackAll";
            this.rbxDrgPackAll.TabStop = true;
            this.rbxDrgPackAll.UseVisualStyleBackColor = false;
            this.rbxDrgPackAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel15
            // 
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.Name = "xLabel15";
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = IHIS.Framework.XColor.XGridBackColor;
            this.xPanel1.Controls.Add(this.xLabel15);
            this.xPanel1.Controls.Add(this.fbxCautionCode);
            this.xPanel1.Controls.Add(this.dbxCautionName);
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.grdOcsChk);
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOCS0108
            // 
            this.grdOCS0108.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS0108, "grdOCS0108");
            this.grdOCS0108.ApplyPaintEventToAllColumn = true;
            this.grdOCS0108.CallerID = '2';
            this.grdOCS0108.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell47,
            this.xEditGridCell57,
            this.xEditGridCell93,
            this.xEditGridCell70});
            this.grdOCS0108.ColPerLine = 5;
            this.grdOCS0108.Cols = 6;
            this.grdOCS0108.ExecuteQuery = null;
            this.grdOCS0108.FixedCols = 1;
            this.grdOCS0108.FixedRows = 2;
            this.grdOCS0108.HeaderHeights.Add(23);
            this.grdOCS0108.HeaderHeights.Add(0);
            this.grdOCS0108.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5,
            this.xGridHeader6});
            this.grdOCS0108.Name = "grdOCS0108";
            this.grdOCS0108.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0108.ParamList")));
            this.grdOCS0108.QuerySQL = resources.GetString("grdOCS0108.QuerySQL");
            this.grdOCS0108.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOCS0108.RowHeaderVisible = true;
            this.grdOCS0108.Rows = 3;
            this.grdOCS0108.ToolTipActive = true;
            this.grdOCS0108.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0108_RowFocusChanged);
            this.grdOCS0108.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0108_GridColumnChanged);
            this.grdOCS0108.PreEndInitializing += new System.EventHandler(this.grdOCS0108_PreEndInitializing);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "hangmog_code";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "ord_danui";
            this.xEditGridCell89.CellWidth = 86;
            this.xEditGridCell89.Col = 1;
            this.xEditGridCell89.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.RowSpan = 2;
            this.xEditGridCell89.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "seq";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "change_qty1";
            this.xEditGridCell91.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell91.CellWidth = 55;
            this.xEditGridCell91.Col = 2;
            this.xEditGridCell91.DecimalDigits = 4;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.Row = 1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "change_qty2";
            this.xEditGridCell92.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell92.CellWidth = 55;
            this.xEditGridCell92.Col = 4;
            this.xEditGridCell92.DecimalDigits = 4;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.Row = 1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "hosp_code";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "hangmog_start_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell93.CellName = "change_danui1";
            this.xEditGridCell93.CellWidth = 83;
            this.xEditGridCell93.Col = 3;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.Row = 1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell70.CellName = "change_danui2";
            this.xEditGridCell70.CellWidth = 82;
            this.xEditGridCell70.Col = 5;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsUpdCol = false;
            this.xEditGridCell70.Row = 1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 2;
            this.xGridHeader5.ColSpan = 2;
            this.xGridHeader5.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 55;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 4;
            this.xGridHeader6.ColSpan = 2;
            this.xGridHeader6.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            this.xGridHeader6.HeaderWidth = 55;
            // 
            // layDanui
            // 
            this.layDanui.ExecuteQuery = null;
            this.layDanui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layDanui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDanui.ParamList")));
            this.layDanui.QuerySQL = "SELECT CODE, CODE_NAME\r\n  FROM OCS0132 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND " +
    "CODE_TYPE = \'ORD_DANUI\'\r\n ORDER BY 1";
            this.layDanui.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDanui_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.btnExportExcel);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Name = "xPanel3";
            // 
            // btnExportExcel
            // 
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.ImageIndex = 2;
            this.btnExportExcel.ImageList = this.ImageList;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdOCS0108);
            this.xPanel4.Controls.Add(this.xPanel1);
            this.xPanel4.Name = "xPanel4";
            // 
            // DRGOCSCHK
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.panel2);
            this.Name = "DRGOCSCHK";
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcsChk)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDanui)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdOcsChk.QueryLayout(false);
                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                                        
                    if (this.CurrMQLayout != this.grdOCS0108 & this.grdOCS0108.RowCount == 0)
                    {
                        return;
                    }else
                    {
                        this.Insert_OCS0108(this.grdOCS0108.CurrentRowNumber);
                    }

                    break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    if (this.CurrMQLayout != this.grdOCS0108 & this.grdOCS0108.RowCount == 0)
                    {
                        return;
                    }

                    e.IsBaseCall = true;

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (SaveGrdOcsChk() == true && SaveGrdOcs0108() == true)
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-12839
                        //XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG001_CAP, MessageBoxIcon.Information);
                        XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Information);

                        //this.grdOcsChk.QueryLayout(false);
                        //return;
                    }
                    else
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-12839
                        //XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                        XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);

                        //this.grdOcsChk.QueryLayout(false);
                        //return;
                    }

                    this.grdOcsChk.QueryLayout(false);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Insert_OCS0108
        private void Insert_OCS0108(int aCurrentRow)
        {
            int newRow = this.grdOCS0108.InsertRow(aCurrentRow);

            this.grdOCS0108.SetItemValue(newRow, "hosp_code", EnvironInfo.HospCode);

            this.grdOCS0108.SetItemValue(newRow, "hangmog_code", this.grdOcsChk.GetItemString(this.grdOcsChk.CurrentRowNumber, "hangmog_code"));

            this.grdOCS0108.SetItemValue(newRow, "hangmog_start_date", this.grdOcsChk.GetItemString(this.grdOcsChk.CurrentRowNumber, "start_date"));
        }
        #endregion

        #region 각 그리드에 바인드변수 설정
        private void grdOcsChk_QueryStarting(object sender, CancelEventArgs e)
        {
            string aBeforeUseYn = "%";
            if (rbxBeforeUseAll.Checked)
                aBeforeUseYn = "%";
            else if (rbxBeforeUseY.Checked)
                aBeforeUseYn = "Y";
            else
                aBeforeUseYn = "N";

            string aDrgPackYn = "%";
            if (rbxDrgPackAll.Checked)
                aDrgPackYn = "%";
            else if (rbxDrgPackY.Checked)
                aDrgPackYn = "Y";
            else
                aDrgPackYn = "N";

            string aPhamarcyYn = "%";
            if (rbxPhamarcyAll.Checked)
                aPhamarcyYn = "%";
            else if (rbxPhamarcyY.Checked)
                aPhamarcyYn = "Y";
            else
                aPhamarcyYn = "N";

            string aPowderYn = "%";
            if (rbxPowderAll.Checked)
                aPowderYn = "%";
            else if (rbxPowderY.Checked)
                aPowderYn = "Y";
            else
                aPowderYn = "N";

            string aHubalYn = "%";
            if (rbxHubalAll.Checked)
                aHubalYn = "%";
            else if (rbxHubalY.Checked)
                aHubalYn = "Y";
            else
                aHubalYn = "N";

            string aMayakYn = "%";
            if (rbxMayakAll.Checked)
                aMayakYn = "%";
            else if (rbxMayakY.Checked)
                aMayakYn = "1";
            else
                aMayakYn = "0";

            string aStockYn = "%";
            if (rbxStockAll.Checked)
                aStockYn = "%";
            else if (rbxStockY.Checked)
                aStockYn = "Y";
            else
                aStockYn = "N";

            string aWonnaeDrgYn = "%";
            if (rbxWonnaeDrgAll.Checked)
                aWonnaeDrgYn = "%";
            else if (rbxWonnaeDrgY.Checked)
                aWonnaeDrgYn = "Y";
            else
                aWonnaeDrgYn = "N";

            
            string aOffset = "200";

            grdOcsChk.SetBindVarValue("f_before_use_yn", aBeforeUseYn);
            grdOcsChk.SetBindVarValue("f_jaeryo_code", txtJaeryoCode.Text);
            grdOcsChk.SetBindVarValue("f_jaeryo_name", txtJaeryoName.Text);
            grdOcsChk.SetBindVarValue("f_pre_small_code", fbxPreSmallCode.GetDataValue());
            grdOcsChk.SetBindVarValue("f_small_code", fbxSmallCode.GetDataValue());
            grdOcsChk.SetBindVarValue("f_drg_pack_yn", aDrgPackYn);
            grdOcsChk.SetBindVarValue("f_phamarcy_yn", aPhamarcyYn);
            grdOcsChk.SetBindVarValue("f_powder_yn", aPowderYn);
            grdOcsChk.SetBindVarValue("f_hubal_yn", aHubalYn);
            grdOcsChk.SetBindVarValue("f_mayak_yn", aMayakYn);
            grdOcsChk.SetBindVarValue("f_stock_yn", aStockYn);
            grdOcsChk.SetBindVarValue("f_wonnae_drg_yn", aWonnaeDrgYn);
            grdOcsChk.SetBindVarValue("f_offset", aOffset);

            grdOcsChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        /// <summary>
        /// save all GrdOcsChk data
        /// </summary>
        /// <returns></returns>
        private bool SaveGrdOcsChk()
        {
            List<DRGOCSCHKGrdOcsChkFullInfo> grdList = LoadListFromGrdOcsChk();
            if (grdList.Count == 0)
            {
                return true;
            }

            DRGOCSCHKSaveGrdOcsChkArgs args = new DRGOCSCHKSaveGrdOcsChkArgs();
            args.HangmogCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hangmog_code");
            args.ListInfo = grdList;

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, DRGOCSCHKSaveGrdOcsChkArgs>(args);
            
            if (res == null)
            {
                return false;
            }
            else
            {
                return res.Result;
            }  
            return false;
        }

        private bool SaveGrdOcs0108()
        {
            List<DRGOCSCHKgrdOCS0108Info> grdList = LoadListFromGrdOcs0108();
            if (grdList.Count == 0)
            {
                return true;
            }

            DRGOCSCHKSaveGrdOcs0108Args args = new DRGOCSCHKSaveGrdOcs0108Args();
            args.HangmogCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hangmog_code");
            args.ListInfo = grdList;

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, DRGOCSCHKSaveGrdOcs0108Args>(args);
            if (res == null)
            {
                return false;
            }
            else
            {
                return res.Result;
            }
            return false;        
        }

        /// <summary>
        /// Get data from GrdOcsChk, fill into List object
        /// </summary>
        /// <returns></returns>
        private List<DRGOCSCHKGrdOcsChkFullInfo> LoadListFromGrdOcsChk()
        {
            List<DRGOCSCHKGrdOcsChkFullInfo> dataList = new List<DRGOCSCHKGrdOcsChkFullInfo>();
            for (int i = 0; i < grdOcsChk.RowCount; i++)
            {
                if (grdOcsChk.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                DRGOCSCHKGrdOcsChkFullInfo info = new DRGOCSCHKGrdOcsChkFullInfo();
                info.JaeryoCode = grdOcsChk.GetItemString(i, "hangmog_code");
                info.JaeryoName = grdOcsChk.GetItemString(i, "hangmog_name");
                info.DrgPackYn = grdOcsChk.GetItemString(i, "drg_pack_yn");
                info.PhamarcyYn = grdOcsChk.GetItemString(i, "phamarcy");
                info.PowerYn = grdOcsChk.GetItemString(i, "powder_yn");
                info.HubalChangeYn = grdOcsChk.GetItemString(i, "hubal_change_yn");
                info.MayakYn = grdOcsChk.GetItemString(i, "bunryu2");
                info.SmallCode = grdOcsChk.GetItemString(i, "small_code");
                info.SmallCodeName = grdOcsChk.GetItemString(i, "small_code_name");
                info.CautionCode = grdOcsChk.GetItemString(i, "caution_code");
                info.CautionName = grdOcsChk.GetItemString(i, "caution_name");
                info.StartDate = grdOcsChk.GetItemString(i, "start_date");
                info.SunabDanui = grdOcsChk.GetItemString(i, "sunab_danui");
                info.SunabDanuiName = grdOcsChk.GetItemString(i, "sunab_danui_name");
                info.StockYn = grdOcsChk.GetItemString(i, "stock_yn");
                info.SubulDanga = grdOcsChk.GetItemString(i, "subul_danga");
                info.SubulQcodeOut = grdOcsChk.GetItemString(i, "subul_qcode_out");
                info.SubulQcodeOutName = grdOcsChk.GetItemString(i, "subul_qcode_out_name");
                info.SubulQcodeInp = grdOcsChk.GetItemString(i, "subul_qcode_inp");
                info.SubulQcodeInpName = grdOcsChk.GetItemString(i, "subul_qcode_inp_name");
                info.SubulDanui = grdOcsChk.GetItemString(i, "subul_danui");
                info.SubulDanuiName = grdOcsChk.GetItemString(i, "subul_danui_name");
                info.RowState = grdOcsChk.GetRowState(i).ToString();
                dataList.Add(info);
            }
            // for delete
            if (grdOcsChk.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdOcsChk.DeletedRowTable.Rows)
                {
                    DRGOCSCHKGrdOcsChkFullInfo info = new DRGOCSCHKGrdOcsChkFullInfo();
                    info.JaeryoCode = JaeryoCode;
                    info.JaeryoName = JaeryoName;
                    info.DrgPackYn = DrgPackYn;
                    info.PhamarcyYn = PhamarcyYn;
                    info.PowerYn = PowerYn;
                    info.HubalChangeYn = HubalChangeYn;
                    info.MayakYn = MayakYn;
                    info.SmallCode = SmallCode;
                    info.SmallCodeName = SmallCodeName;
                    info.CautionCode = CautionCode;
                    info.CautionName = CautionName;
                    info.StartDate = StartDate;
                    info.SunabDanui = SunabDanui;
                    info.SunabDanuiName = SunabDanuiName;
                    info.StockYn = StockYn;
                    info.SubulDanga = SubulDanga;
                    info.SubulQcodeOut = SubulQcodeOut;
                    info.SubulQcodeOutName = SubulQcodeOutName;
                    info.SubulQcodeInp = SubulQcodeInp;
                    info.SubulQcodeInpName = SubulQcodeInpName;
                    info.RowState = "Deleted";

                    dataList.Add(info);
                }
            }
            return dataList;
        }
        private List<DRGOCSCHKgrdOCS0108Info> LoadListFromGrdOcs0108()
        {
            List<DRGOCSCHKgrdOCS0108Info> dataList = new List<DRGOCSCHKgrdOCS0108Info>();
            for (int i = 0; i < grdOCS0108.RowCount; i++)
            {
                if (grdOCS0108.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                DRGOCSCHKgrdOCS0108Info info = new DRGOCSCHKgrdOCS0108Info();
                //info.ChangeDanui1 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_danui1 ");
                info.ChangeDanui2 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_danui2");
                info.ChangeQty1 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_qty1");
                info.ChangeQty2 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_qty2");
                info.HangmogCode = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hangmog_code");
                info.HangmogStartDate = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hangmog_start_date");
                info.HospCode = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hosp_code");
                info.OrdDanui = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "ord_danui");
                info.Seq = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "seq");
                info.RowState = grdOCS0108.GetRowState(i).ToString();
                dataList.Add(info);
            }
            //for delete
            if (grdOCS0108.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdOCS0108.DeletedRowTable.Rows)
                {
                    DRGOCSCHKgrdOCS0108Info info = new DRGOCSCHKgrdOCS0108Info();
                    info.ChangeDanui1 = dr["change_danui1"].ToString();
                    info.ChangeDanui2 = dr["change_danui2"].ToString();
                    info.ChangeQty1 = dr["change_qty1"].ToString();
                    info.ChangeQty2 = dr["change_qty2"].ToString();
                    info.HangmogCode = dr["hangmog_code"].ToString();
                    info.HangmogStartDate = dr["hangmog_start_date"].ToString();
                    info.HospCode = dr["hosp_code"].ToString();
                    info.OrdDanui = dr["ord_danui"].ToString();
                    info.Seq = dr["seq"].ToString();
                    info.RowState = "Deleted";

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #region 약품 코드/ 명칭 벨리데이팅 처리 -> 재조회
        private void txt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdOcsChk.QueryLayout(false);
        }
        #endregion

        #region 파인드 벨리데이팅 처리
        private void grdOcsChk_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //string cmdStr = "SELECT CODE_NAME1 FROM DRG0141 WHERE HOSP_CODE = :f_hosp_code AND CODE1 = :f_code1";
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //bindVars.Add("f_code1", grdOcsChk.GetItemString(e.RowNumber, "small_code"));

            //object retVal = Service.ExecuteScalar(cmdStr, bindVars);

            DRGOCSCHKSmallCodeDataValidatingArgs args =
               new DRGOCSCHKSmallCodeDataValidatingArgs(grdOcsChk.GetItemString(e.RowNumber, "small_code"));
            DRGOCSCHKSmallCodeDataValidatingResult result =
                CloudService.Instance
                    .Submit<DRGOCSCHKSmallCodeDataValidatingResult, DRGOCSCHKSmallCodeDataValidatingArgs>(args);

            //if (TypeCheck.IsNull(retVal))
            if (TypeCheck.IsNull(result) || String.IsNullOrEmpty(result.CodeName1))
            {
                this.SetMsg("unmatched code", MsgType.Error);
            }
            else
            {
                //this.grdOcsChk.SetItemValue(e.RowNumber, "small_code_name", retVal.ToString());
                this.grdOcsChk.SetItemValue(e.RowNumber, "small_code_name", result.CodeName1);
            }
        }
        #endregion

        #region fields
        private string mFindParent = "";
        #endregion

        #region 효능 파인드 띄우기
        private void grdOcsChk_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (grdOcsChk.RowCount == 0) return;

            mFindParent = "grdOcsChk";
            XScreen.OpenScreen(this, "DRG0140Q00", ScreenOpenStyle.ResponseSizable);
        }
        #endregion

        #region Command 효능 받기

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "DRG0140Q00": /* 효능 코드 선택 */

                    if (commandParam.Contains("small_code"))
                    {
                        if (mFindParent == "grdOcsChk")
                        {
                            grdOcsChk.SetFocusToItem(grdOcsChk.CurrentRowNumber, "small_code");
                            grdOcsChk.SetEditorValue(commandParam["small_code"].ToString());
                            grdOcsChk.AcceptData();
                        }
                        else
                        {
                            if (commandParam.Contains("pre_small_code"))
                            {
                                fbxPreSmallCode.SetEditValue(commandParam["pre_small_code"].ToString());
                                fbxPreSmallCode.AcceptData();
                            }
                            if (commandParam.Contains("small_code"))
                            {
                                fbxSmallCode.SetEditValue(commandParam["small_code"].ToString());
                                fbxSmallCode.AcceptData();
                            }
                        }
                    }

                    break;

                case "DRG0140Q01": /* 효능 대분류 선택 */

                    if (commandParam.Contains("pre_small_code"))
                    {
                        fbxPreSmallCode.SetEditValue(commandParam["pre_small_code"].ToString());
                        fbxPreSmallCode.AcceptData();
                    }

                    break;

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion

        #region 각종 라디오 버튼 체인지 이벤트
        private void rbx_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbx = (XRadioButton)sender;
            if ( rbx.Checked )
                btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        private void fbxPreSmallCode_FindClick(object sender, CancelEventArgs e)
        {
            XScreen.OpenScreen(this, "DRG0140Q01", ScreenOpenStyle.ResponseSizable);
        }

        private void fbxSmallCode_FindClick(object sender, CancelEventArgs e)
        {
            mFindParent = "fbxSmallCode";
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("pre_small_code", fbxPreSmallCode.GetDataValue());
            XScreen.OpenScreenWithParam(this,"DRGS", "DRG0140Q00", ScreenOpenStyle.ResponseSizable,openParams);
        }

        private void fbxSmallCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                dbxSmallCodeName.SetDataValue("");
                return;
            } 
            //string cmdStr = "SELECT CODE_NAME1 FROM DRG0141 WHERE HOSP_CODE = :f_hosp_code AND CODE1 = :f_code1";
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //bindVars.Add("f_code1", e.DataValue);

            //object retVal = Service.ExecuteScalar(cmdStr, bindVars);

            DRGOCSCHKSmallCodeDataValidatingArgs args =
                new DRGOCSCHKSmallCodeDataValidatingArgs(e.DataValue);
            DRGOCSCHKSmallCodeDataValidatingResult result =
                CloudService.Instance
                    .Submit<DRGOCSCHKSmallCodeDataValidatingResult, DRGOCSCHKSmallCodeDataValidatingArgs>(args);


            //if (TypeCheck.IsNull(retVal))
            if (TypeCheck.IsNull(result) || String.IsNullOrEmpty(result.CodeName1))
            {
                this.SetMsg("unmatched code", MsgType.Error);
            }
            else
            {
                //this.dbxSmallCodeName.SetDataValue(retVal.ToString());
                this.dbxSmallCodeName.SetDataValue(result.CodeName1);
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void fbxPreSmallCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                dbxPreSmallCodeName.SetDataValue("");
                return;
            }
            //string cmdStr = "SELECT CODE_NAME FROM DRG0140 WHERE HOSP_CODE = :f_hosp_code AND CODE = :f_code";
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            //bindVars.Add("f_code", e.DataValue);

            //object retVal = Service.ExecuteScalar(cmdStr, bindVars);

            DRGOCSCHKPreSmallCodeDataValidatingArgs args = new DRGOCSCHKPreSmallCodeDataValidatingArgs(e.DataValue);
            DRGOCSCHKPreSmallCodeDataValidatingResult result =
                CloudService.Instance
                    .Submit<DRGOCSCHKPreSmallCodeDataValidatingResult, DRGOCSCHKPreSmallCodeDataValidatingArgs>(args);

           // if (TypeCheck.IsNull(retVal))
            if (TypeCheck.IsNull(result) || String.IsNullOrEmpty(result.CautionName))
            {
                this.SetMsg("unmatched code", MsgType.Error);
            }
            else
            {
                //this.dbxPreSmallCodeName.SetDataValue(retVal.ToString());
                this.dbxPreSmallCodeName.SetDataValue(result.CautionName);
                this.fbxSmallCode.SetEditValue("");
                this.fbxSmallCode.AcceptData();
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void fbxCautionCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(e.DataValue))
            {
                dbxCautionName.SetDataValue("");
                this.grdOcsChk.SetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_code", "");
                this.grdOcsChk.SetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_name", "");
                return;
            }

            //string cmdStr = "SELECT CAUTION_NAME FROM DRG0130 WHERE HOSP_CODE = :f_hosp_code AND CAUTION_CODE = :f_caution_code";
            //BindVarCollection bindVar = new BindVarCollection();
            //bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            //bindVar.Add("f_caution_code", e.DataValue);

            //object retVar = Service.ExecuteScalar(cmdStr, bindVar);

            DRGOCSCHKCautionCodeDataValidatingArgs args = new DRGOCSCHKCautionCodeDataValidatingArgs(e.DataValue);
            DRGOCSCHKCautionCodeDataValidatingResult result =
                CloudService.Instance
                    .Submit<DRGOCSCHKCautionCodeDataValidatingResult, DRGOCSCHKCautionCodeDataValidatingArgs>(args);


            //if (!TypeCheck.IsNull(retVar))
            if (!TypeCheck.IsNull(result) && !String.IsNullOrEmpty(result.CautionName))
            {
                //this.dbxCautionName.SetDataValue(retVar.ToString());
                this.dbxCautionName.SetDataValue(result.CautionName);
                this.grdOcsChk.SetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_code", e.DataValue);
                //this.grdOcsChk.SetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_name", retVar.ToString());
                this.grdOcsChk.SetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_name", result.CautionName);
            }
            else
            {
                e.Cancel = true;
                //this.SetMsg("コードを確認してください", MsgType.Error);
                this.SetMsg(Resources.MSG002_MSG, MsgType.Error);
            }
        }

        private void grdOcsChk_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.fbxCautionCode.SetDataValue(this.grdOcsChk.GetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_code"));
            this.dbxCautionName.SetDataValue(this.grdOcsChk.GetItemValue(this.grdOcsChk.CurrentRowNumber, "caution_name"));
            grdOCS0108.QueryLayout(false);
            this.DataLoadOCS0108(this.grdOcsChk.GetItemString(e.CurrentRow, "hangmog_code"), this.grdOcsChk.GetItemString(e.CurrentRow, "start_date"));
            //grdOCS0108_GridColumnChanged();

            JaeryoCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hangmog_code");
            JaeryoName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hangmog_name");
            DrgPackYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "drg_pack_yn");
            PhamarcyYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "phamarcy");
            PowerYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "powder_yn");
            HubalChangeYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "hubal_change_yn");
            MayakYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "bunryu2");
            SmallCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "small_code");
            SmallCodeName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "small_code_name");
            CautionCode = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "caution_code");
            CautionName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "caution_name");
            StartDate = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "start_date");
            SunabDanui = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "sunab_danui");
            SunabDanuiName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "sunab_danui_name");
            StockYn = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "stock_yn");
            SubulDanga = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "subul_danga");
            SubulQcodeOut = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "subul_qcode_out");
            SubulQcodeOutName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "subul_qcode_out_name");
            SubulQcodeInp = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "subul_qcode_inp");
            SubulQcodeInpName = grdOcsChk.GetItemString(grdOcsChk.CurrentRowNumber, "subul_qcode_inp_name");
            RowState = grdOcsChk.GetRowState(grdOcsChk.CurrentRowNumber).ToString();
        }

        #region Load OCS0108
        private void DataLoadOCS0108(string aHangmogCode, string aHangmogStartDate)
        {
            this.grdOCS0108.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS0108.SetBindVarValue("f_aHangmogCode", aHangmogCode);
            this.grdOCS0108.SetBindVarValue("f_aHangmogStartdate", aHangmogStartDate);
            this.grdOCS0108.QueryLayout(true);
        }
        #endregion

        #region [환산수량]
        private void grdOCS0108_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (grid.Name)
            {
                case "grdOCS0108":

                    #region 환산수량 테이블

                    if (e.ColName == "ord_danui")
                    {
                        string sunabDanui = this.grdOcsChk.GetItemString(this.grdOcsChk.CurrentRowNumber, "sunab_danui_name");
                        string subulDanui = this.grdOcsChk.GetItemString(this.grdOcsChk.CurrentRowNumber, "subul_danui_name");
                        //string sunabDanui = this.grdOCS0108.GetItemString(this.grdOCS0108.CurrentRowNumber, "ord_danui");
                        //string subulDanui = this.grdOCS0108.GetItemString(this.grdOCS0108.CurrentRowNumber, "ord_danui");


                        DataRow[] dr = layDanui.LayoutTable.Select("code = '" + e.ChangeValue + "'");

                        if (sunabDanui != null)
                        {
                            //grdOCS0108.SetItemValue(e.RowNumber, "change_danui1", dr[0]["code_name"].ToString() + "/" + sunabDanui);
                            grdOCS0108.SetItemValue(e.RowNumber, "change_danui1", grdOCS0108.GetComboDisplayValue(e.RowNumber, "ord_danui") + "/" + sunabDanui);
                        }

                        if (subulDanui != null)
                        {
                            //grdOCS0108.SetItemValue(e.RowNumber, "change_danui2", dr[0]["code_name"].ToString() + "/" + subulDanui);
                            grdOCS0108.SetItemValue(e.RowNumber, "change_danui2", grdOCS0108.GetComboDisplayValue(e.RowNumber, "ord_danui") + "/" + subulDanui);
                        }
                    }

                    if (e.ColName == "change_qty1" && grdOCS0108.GetItemString(e.RowNumber, "change_qty2") == "")
                    {
                        grdOCS0108.SetItemValue(e.RowNumber, "change_qty2", e.ChangeValue);
                    }

                    #endregion

                    break;
            }
        }

        private void layDanui_QueryStarting(object sender, CancelEventArgs e)
        {
            layDanui.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.grdOcsChk.RowCount > 0)
            {
                this.grdOcsChk.Export(true, false);



            }
        }
        #endregion

        /* ====================================== SAVEPERFORMER ====================================== */
        #region [ XSavePerformer]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRGOCSCHK parent = null;
            public XSavePerformer(DRGOCSCHK parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {

                string cmdText = "";
                object t_chk = "";
                object seq = "";
                string msg = "";
                string cap = "";

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1': // INV0110
                        #region grdOcsChk
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO INV0110 (
                                                                 JUKYONG_DATE
                                                                ,JAERYO_CODE 
                                                                ,JAERYO_NAME 
                                                                ,CHK3
                                                                ,CHK2
                                                                ,CHK1
                                                                ,TOIJANG_YN
                                                                ,BUNRYU2
                                                                ,SMALL_CODE
                                                                ,CAUTION_CODE
                                                                ,SYS_DATE
                                                                ,SYS_ID
                                                                ,HOSP_CODE
                                                                ,SUBUL_DANUI
                                                                ,STOCK_YN
                                                                ,SUBUL_DANGA
                                                                ,SUBUL_QCODE_OUT
                                                                ,SUBUL_QCODE_INP
                                                              ) VALUES (
                                                                 SYSDATE
                                                                ,:f_hangmog_code          
                                                                ,:f_hangmog_name 
                                                                ,:f_drg_pack_yn
                                                                ,:f_phamarcy
                                                                ,:f_powder_yn
                                                                ,:f_hubal_change_yn
                                                                ,:f_bunryu2
                                                                ,:f_small_code
                                                                ,:f_caution_code
                                                                ,SYSDATE
                                                                ,:q_user_id
                                                                ,:f_hosp_code
                                                                ,:f_subul_danui
                                                                ,:f_stock_yn
                                                                ,:f_subul_danga
                                                                ,:f_subul_qcode_out
                                                                ,:f_subul_qcode_inp
                                                                )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE INV0110             
                                               SET CHK3            = :f_drg_pack_yn            
                                                  ,CHK2            = :f_phamarcy     
                                                  ,CHK1            = :f_powder_yn
                                                  ,TOIJANG_YN      = :f_hubal_change_yn
                                                  ,BUNRYU2         = :f_bunryu2
                                                  ,SMALL_CODE      = :f_small_code
                                                  ,CAUTION_CODE    = :f_caution_code
                                                  ,SUBUL_DANUI     = :f_subul_danui
                                                  ,STOCK_YN        = :f_stock_yn
                                                  ,SUBUL_DANGA     = :f_subul_danga
                                                  ,SUBUL_QCODE_OUT = :f_subul_qcode_out
                                                  ,SUBUL_QCODE_INP = :f_subul_qcode_inp
                                                  ,UPD_ID          = :q_user_id
                                                  ,UPD_DATE        = SYSDATE
                                             WHERE JAERYO_CODE     = :f_hangmog_code
                                               AND HOSP_CODE       = :f_hosp_code";
                                break;

                        }
                        #endregion
                    break;

                    case '2': // OCS0108
                        #region grdOCS0108
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @" SELECT 'Y'
                                                   FROM SYS.DUAL
                                                  WHERE EXISTS ( SELECT 'X'
                                                                   FROM OCS0108" +
                                           "                  WHERE HANGMOG_CODE       = :f_hangmog_code " +
                                           "                    AND HOSP_CODE          = :f_hosp_code" +
                                           "                    AND HANGMOG_START_DATE = :f_hangmog_start_date" + //ADD SHIMO
                                           "                    AND ORD_DANUI          = :f_ord_danui ) ";


                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
                                {
                                    msg = "既に登録されているオーダ単位です。";
                                    cap = "データ確認";

                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return false;
                                }

                                // sequence 구하기
                                cmdText = " SELECT MAX(SEQ) + 1 " +
                                          "   FROM OCS0108 " +
                                          "  WHERE HOSP_CODE          = :f_hosp_code " +
                                          "    AND HANGMOG_START_DATE = :f_hangmog_start_date" +
                                          "    AND HANGMOG_CODE       = :f_hangmog_code ";


                                seq = Service.ExecuteScalar(cmdText, item.BindVarList);



                                // string aa = parent.grdOCS0103.GetItemString(

                                // XMessageBox.Show(aa, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (TypeCheck.IsNull(seq))
                                {
                                    seq = "1";
                                }

                                cmdText = @" INSERT INTO OCS0108 
                                                           ( SYS_DATE    ,    SYS_ID      ,    UPD_DATE ,    UPD_ID,
                                                             HOSP_CODE   ,    HANGMOG_CODE,    ORD_DANUI,    SEQ   ,
                                                             CHANGE_QTY1 ,    CHANGE_QTY2 ,    HANGMOG_START_DATE)
                                                      VALUES
                                                           ( SYSDATE     ,    '" + UserInfo.UserID + "', SYSDATE,     '" + UserInfo.UserID + "'," +
                                                       " :f_hosp_code  , :f_hangmog_code, :f_ord_danui, " + seq.ToString() + ", " +
                                                       " :f_change_qty1, :f_change_qty2,:f_hangmog_start_date) ";

                                break;

                            case DataRowState.Modified:

                                cmdText = @" UPDATE OCS0108
                                                    SET CHANGE_QTY1  = :f_change_qty1
                                                      , CHANGE_QTY2  = :f_change_qty2
                                                      , UPD_DATE     = SYSDATE
                                                      , UPD_ID       = '" + UserInfo.UserID + @"' 
                                                  WHERE HOSP_CODE    = :f_hosp_code
                                                    AND HANGMOG_CODE = :f_hangmog_code 
                                                    AND HANGMOG_START_DATE = :f_hangmog_start_date 
                                                    AND ORD_DANUI    = :f_ord_danui    ";

                                break;

                            case DataRowState.Deleted:



                                cmdText = @" DELETE FROM OCS0108 
                                                  WHERE HOSP_CODE           = :f_hosp_code" +
                                              "  AND HANGMOG_CODE       = :f_hangmog_code " +
                                              "  AND HANGMOG_START_DATE =  :f_hangmog_start_date " +
                                              "  AND ORD_DANUI          = :f_ord_danui";
                                // ADD HANGMOG_START_DATE SHIMO //

                                break;
                        }
                        #endregion
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdOCS0108_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell89.ExecuteQuery = GetCboOrdDanui;
        }
        #region GetCboOrdDanui
        /// <summary>
        /// GetCboOrdDanui
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboOrdDanui(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboOrdDanuiArgs args = new ComboOrdDanuiArgs();
            args.IsAll = false;
            args.HospCode = UserInfo.HospCode;
            
            ComboResult res = CloudService.Instance.Submit<ComboResult, ComboOrdDanuiArgs>(args);

            if (res.ComboItem != null)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }
            return lObj;
        }
        #endregion

        private IList<object[]> LoadcbxJaeryoGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs args = new INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs();
            ComboResult res = CloudService.Instance.Submit<ComboResult, INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs>(args, true);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in res.ComboItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName
                        
                    });
                }
                return lObj;
            }
            return null;
        }

        private void grdOcsChk_PreEndInitializing(object sender, EventArgs e)
        {

        }

        private void grdOCS0108_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //ChangeDanui1 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_danui1 ");
            ChangeDanui2 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_danui2");
            ChangeQty1 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_qty1");
            ChangeQty2 = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "change_qty2");
            HangmogCode = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hangmog_code");
            HangmogStartDate = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hangmog_start_date");
            HospCode = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "hosp_code");
            OrdDanui = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "ord_danui");
            Seq = grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "seq");
            
        }

        private void grdOcsChk_PreEndInitializing_1(object sender, EventArgs e)
        {
            xEditGridCell19.ExecuteQuery = LoadCbxForGrdCell;
            xEditGridCell20.ExecuteQuery = LoadCbxForGrdCell;
        }

        private IList<object[]> LoadCbxForGrdCell(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRGOCSCHKLoadCbxCHKArgs args = new DRGOCSCHKLoadCbxCHKArgs();


            ComboResult res = CloudService.Instance.Submit<ComboResult, DRGOCSCHKLoadCbxCHKArgs>(args);

            if (res.ComboItem != null)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }
            return lObj;
        }
    }
}

