#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// BAS0270U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class BAS0270U00 : XScreen
    {
        private XPanel pnlTop;
        private XLabel xLabel1;
        private XDatePicker dtpDoctorYMD;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGrid grdBAS0271;
        private XEditGridCell xEditGridCell19;
        private XFindWorker fwkDoctorGrade;
        private XFindWorker fwkGwa;
        private SingleLayout layDoctorGrade;
        private SingleLayout layGwa;
        private XButtonList btnList;
        private SingleLayout layDupCheck;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XFindWorker fwkDoctor;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;
        private SingleLayout layDoctorName;
        private XEditGridCell xEditGridCell22;
        private XButton btnIlgwalInsert;
        private XLabel xLabel2;
        private XTextBox txtDoctorName;
        private XEditGrid grdBAS0272;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem2;
        private XEditGridCell xEditGridCell25;
        private ColorDialog cdlColor;
        private XEditGridCell xEditGridCell26;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XEditGridCell xEditGridCell27;
        private SingleLayout layDupGwa;
        private SingleLayoutItem singleLayoutItem5;
        private XHospBox xHospBox;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private Container components = null;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private int TheFlag;
        private DataTable _dtGrdCbo;
        private string LBL_Y = "Y";
        private string LBL_N = "N";
        private string LBL_MAIN_GWA_YN = "main_gwa_yn";


        public BAS0270U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //tungtx
            //set ParamList
            this.fwkDoctor.ParamList = new List<string>(new String[] { "f_doctor_gwa", "f_find1" });
            this.fwkDoctorGrade.ParamList = new List<string>(new String[] { "f_code", "f_find1" });
            this.fwkGwa.ParamList = new List<string>(new String[] { "f_buseo_ymd", "f_find1", "f_code" });
            this.grdBAS0271.ParamList = new List<string>(new String[] { "f_doctor_ymd", "f_doctor_name" });
            this.grdBAS0272.ParamList = new List<string>(new String[] { "f_doctor_ymd", "f_doctor" });
            this.layDoctorName.ParamList = new List<string>(new String[] { "f_doctor_ymd", "f_doctor" });
            this.layDoctorGrade.ParamList = new List<string>(new String[] { "f_code" });
            this.layGwa.ParamList = new List<string>(new String[] { "f_gwa", "f_buseo_ymd" });
            this.layDupCheck.ParamList = new List<string>(new String[] { "f_doctor_ymd", "f_doctor" });

            //set ExecuteQuery
            fwkDoctor.ExecuteQuery = LoadDataFwkDoctor;
            fwkDoctorGrade.ExecuteQuery = LoadDataFwkDoctorGrade;
            fwkGwa.ExecuteQuery = LoadDataFwkGwa;
            grdBAS0271.ExecuteQuery = LoadDataGrdBAS0271;
            grdBAS0272.ExecuteQuery = LoadDataGrdBAS0272;
            InitCboGrdBAS0272Type();
            layDoctorName.ExecuteQuery = LoadDataLayDoctorName;
            layDoctorGrade.ExecuteQuery = LoadDataLayDoctorGrade;
            layGwa.ExecuteQuery = LoadDataLayGwa;
            layDupCheck.ExecuteQuery = LoadDataLayDupCheck;
        }

        #region CloudService get data for controls

        private List<object[]> LoadDataLayDoctorName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00LayDoctorNameArgs args = new BAS0270U00LayDoctorNameArgs();
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.DoctorYmd = bc["f_doctor_ymd"] != null ? bc["f_doctor_ymd"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00LayDoctorNameResult result = CloudService.Instance.Submit<BAS0270U00LayDoctorNameResult, BAS0270U00LayDoctorNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.DoctorName)
                {
                    object[] objects = 
				{ 
					item.DataValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataLayDupCheck(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00LayDupCheckArgs args = new BAS0270U00LayDupCheckArgs();
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.DoctorYmd = bc["f_doctor_ymd"] != null ? bc["f_doctor_ymd"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00LayDupCheckResult result = CloudService.Instance.Submit<BAS0270U00LayDupCheckResult, BAS0270U00LayDupCheckArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.Y)
                {
                    object[] objects = 
				{ 
					item.DataValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataLayGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00LayGwaArgs args = new BAS0270U00LayGwaArgs();
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            args.BuseoYmd = bc["f_buseo_ymd"] != null ? bc["f_buseo_ymd"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00LayGwaResult result = CloudService.Instance.Submit<BAS0270U00LayGwaResult, BAS0270U00LayGwaArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.GwaName)
                {
                    object[] objects = 
				{ 
					item.DataValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataLayDoctorGrade(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00LayDoctorGradeArgs args = new BAS0270U00LayDoctorGradeArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00LayDoctorGradeResult result = CloudService.Instance.Submit<BAS0270U00LayDoctorGradeResult, BAS0270U00LayDoctorGradeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.CodeName)
                {
                    object[] objects = 
				{ 
					item.DataValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataGrdBAS0272(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00GrdBAS0272Args args = new BAS0270U00GrdBAS0272Args();
            args.DoctorYmd = bc["f_doctor_ymd"] != null ? bc["f_doctor_ymd"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00GrdBAS0272Result result = CloudService.Instance.Submit<BAS0270U00GrdBAS0272Result, BAS0270U00GrdBAS0272Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0270U00GrdBAS0272Info item in result.GrdBAS0272)
                {
                    object[] objects = 
				{ 
					item.Doctor, 
					item.DoctorGwa, 
					item.DoctorGwaName, 
					item.MainGwaYn, 
					item.StartDate, 
					item.EndDate, 
					item.Sabun, 
					item.EndYn,
                    item.OutDiscussYn,
                    item.ReserOutYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }


        private List<object[]> LoadDataGrdBAS0271(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00GrdBAS0271Args args = new BAS0270U00GrdBAS0271Args();
            args.DoctorYmd = bc["f_doctor_ymd"] != null ? bc["f_doctor_ymd"].VarValue : "";
            args.DoctorName = bc["f_doctor_name"] != null ? bc["f_doctor_name"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00GrdBAS0271Result result = CloudService.Instance.Submit<BAS0270U00GrdBAS0271Result, BAS0270U00GrdBAS0271Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0270U00GrdBAS0271Info item in result.GrdBAS0271)
                {
                    object[] objects = 
				{ 
					item.Doctor, 
					item.DoctorName, 
					item.DoctorGrade, 
					item.CtorGradeName, 
					item.StartDate, 
					item.JubsuYn, 
					item.ReserYn, 
					item.EndDate, 
					item.OcsStatus, 
					item.LicenseBunho, 
					item.Sabun, 
					item.DoctorSign, 
					item.CpDoctorYn, 
					item.DoctorName2, 
					item.MayakLicense, 
					item.TonggyeDoctor, 
					item.CommonDoctorYn, 
					item.Button, 
					item.DoctorColor
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataFwkGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00FwkGwaArgs args = new BAS0270U00FwkGwaArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.BuseoYmd = bc["f_buseo_ymd"] != null ? bc["f_buseo_ymd"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00FwkGwaResult result = CloudService.Instance.Submit<BAS0270U00FwkGwaResult, BAS0270U00FwkGwaArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FwkList)
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


        private List<object[]> LoadDataFwkDoctor(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00FwkDoctorArgs args = new BAS0270U00FwkDoctorArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            BAS0270U00FwkDoctorResult result =
                CloudService.Instance.Submit<BAS0270U00FwkDoctorResult, BAS0270U00FwkDoctorArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0270U00FwdDoctorInfo item in result.FwkList)
                {
                    object[] objects =
	                {
	                    item.Doctor,
	                    item.DoctorName,
	                    item.DoctorGwa
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataFwkDoctorGrade(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0270U00FwkDoctorGradeArgs args = new BAS0270U00FwkDoctorGradeArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.HospCode = this.mHospCode;
            BAS0270U00FwkDoctorGradeResult result = CloudService.Instance.Submit<BAS0270U00FwkDoctorGradeResult, BAS0270U00FwkDoctorGradeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FwkList)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0270U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.txtDoctorName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpDoctorYMD = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdBAS0271 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fwkDoctorGrade = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
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
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.fwkDoctor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.fwkGwa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layDoctorGrade = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layGwa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.layDoctorName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.btnIlgwalInsert = new IHIS.Framework.XButton();
            this.grdBAS0272 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.cdlColor = new System.Windows.Forms.ColorDialog();
            this.layDupGwa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0271)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0272)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.xHospBox);
            this.pnlTop.Controls.Add(this.txtDoctorName);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.dtpDoctorYMD);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // xHospBox
            // 
            this.xHospBox.AccessibleDescription = null;
            this.xHospBox.AccessibleName = null;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.BackgroundImage = null;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox.HospCode = "";
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.AccessibleDescription = null;
            this.txtDoctorName.AccessibleName = null;
            resources.ApplyResources(this.txtDoctorName, "txtDoctorName");
            this.txtDoctorName.BackgroundImage = null;
            this.txtDoctorName.Name = "txtDoctorName";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpDoctorYMD
            // 
            this.dtpDoctorYMD.AccessibleDescription = null;
            this.dtpDoctorYMD.AccessibleName = null;
            resources.ApplyResources(this.dtpDoctorYMD, "dtpDoctorYMD");
            this.dtpDoctorYMD.BackgroundImage = null;
            this.dtpDoctorYMD.IsVietnameseYearType = false;
            this.dtpDoctorYMD.Name = "dtpDoctorYMD";
            this.dtpDoctorYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDoctorYMD_KeyDown);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdBAS0271
            // 
            this.grdBAS0271.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdBAS0271, "grdBAS0271");
            this.grdBAS0271.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell25,
            this.xEditGridCell26});
            this.grdBAS0271.ColPerLine = 17;
            this.grdBAS0271.Cols = 18;
            this.grdBAS0271.ExecuteQuery = null;
            this.grdBAS0271.FixedCols = 1;
            this.grdBAS0271.FixedRows = 2;
            this.grdBAS0271.HeaderHeights.Add(44);
            this.grdBAS0271.HeaderHeights.Add(0);
            this.grdBAS0271.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdBAS0271.Name = "grdBAS0271";
            this.grdBAS0271.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0271.ParamList")));
            this.grdBAS0271.QuerySQL = resources.GetString("grdBAS0271.QuerySQL");
            this.grdBAS0271.RowHeaderVisible = true;
            this.grdBAS0271.Rows = 3;
            this.grdBAS0271.ToolTipActive = true;
            this.grdBAS0271.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdBAS0271_GridFindSelected);
            this.grdBAS0271.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdBAS0271_GridButtonClick);
            this.grdBAS0271.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0271_GridColumnChanged);
            this.grdBAS0271.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBAS0271_RowFocusChanged);
            this.grdBAS0271.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBAS0271_GridCellPainting);
            this.grdBAS0271.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0271_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.CellWidth = 78;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "doctor_name";
            this.xEditGridCell2.CellWidth = 104;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "doctor_grade";
            this.xEditGridCell3.CellWidth = 25;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.FindWorker = this.fwkDoctorGrade;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.Row = 1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkDoctorGrade
            // 
            this.fwkDoctorGrade.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkDoctorGrade.ExecuteQuery = null;
            this.fwkDoctorGrade.FormText = "医師等級照会";
            this.fwkDoctorGrade.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkDoctorGrade.ParamList")));
            this.fwkDoctorGrade.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkDoctorGrade.ServerFilter = true;
            this.fwkDoctorGrade.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDoctorGrade_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 91;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 271;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "doctor_grade_name";
            this.xEditGridCell4.CellWidth = 67;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "start_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "jubsu_yn";
            this.xEditGridCell6.CellWidth = 67;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "reser_yn";
            this.xEditGridCell7.CellWidth = 86;
            this.xEditGridCell7.Col = 9;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "end_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 82;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "ocs_status";
            this.xEditGridCell9.CellWidth = 45;
            this.xEditGridCell9.Col = 11;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowSpan = 2;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "license_bunho";
            this.xEditGridCell10.CellWidth = 79;
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sabun";
            this.xEditGridCell11.CellWidth = 38;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 30;
            this.xEditGridCell12.CellName = "doctor_sign";
            this.xEditGridCell12.CellWidth = 72;
            this.xEditGridCell12.Col = 13;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 1;
            this.xEditGridCell13.CellName = "cp_doctor_yn";
            this.xEditGridCell13.CellWidth = 63;
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.RowSpan = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 35;
            this.xEditGridCell14.CellName = "doctor_name2";
            this.xEditGridCell14.CellWidth = 98;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "mayak_license";
            this.xEditGridCell15.CellWidth = 82;
            this.xEditGridCell15.Col = 14;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "tonggye_doctor";
            this.xEditGridCell16.CellWidth = 50;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.FindWorker = this.fwkDoctor;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkDoctor
            // 
            this.fwkDoctor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkDoctor.ExecuteQuery = null;
            this.fwkDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkDoctor.ParamList")));
            this.fwkDoctor.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkDoctor.ServerFilter = true;
            this.fwkDoctor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDoctor_QueryStarting);
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo5.ColName = "code";
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 193;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "common_doctor_yn";
            this.xEditGridCell17.CellWidth = 107;
            this.xEditGridCell17.Col = 15;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "color_button";
            this.xEditGridCell25.CellWidth = 23;
            this.xEditGridCell25.Col = 16;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.Row = 1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.ApplyPaintingEvent = true;
            this.xEditGridCell26.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell26.CellName = "doctor_color";
            this.xEditGridCell26.CellWidth = 35;
            this.xEditGridCell26.Col = 17;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 25;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 16;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 23;
            // 
            // fwkGwa
            // 
            this.fwkGwa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkGwa.ExecuteQuery = null;
            this.fwkGwa.FormText = "科照会";
            this.fwkGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGwa.ParamList")));
            this.fwkGwa.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkGwa.ServerFilter = true;
            this.fwkGwa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGwa_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "gwa";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "gwa_name";
            this.findColumnInfo4.ColWidth = 282;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 30;
            this.xEditGridCell18.CellName = "doctor";
            this.xEditGridCell18.CellWidth = 98;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsNotNull = true;
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 30;
            this.xEditGridCell19.CellName = "doctor_gwa";
            this.xEditGridCell19.CellWidth = 100;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.FindWorker = this.fwkGwa;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsNotNull = true;
            this.xEditGridCell19.IsUpdatable = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "gwa_name";
            this.xEditGridCell20.CellWidth = 171;
            this.xEditGridCell20.Col = 2;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "main_gwa_yn";
            this.xEditGridCell21.CellWidth = 120;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "start_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.CellWidth = 110;
            this.xEditGridCell22.Col = 4;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layDoctorGrade
            // 
            this.layDoctorGrade.ExecuteQuery = null;
            this.layDoctorGrade.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDoctorGrade.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDoctorGrade.ParamList")));
            this.layDoctorGrade.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDoctorGrade_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "code_name";
            // 
            // layGwa
            // 
            this.layGwa.ExecuteQuery = null;
            this.layGwa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGwa.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "gwa_name";
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "dup_yn";
            // 
            // layDoctorName
            // 
            this.layDoctorName.ExecuteQuery = null;
            this.layDoctorName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layDoctorName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDoctorName.ParamList")));
            this.layDoctorName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDoctorName_QueryStarting);
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "doctor_name";
            // 
            // btnIlgwalInsert
            // 
            this.btnIlgwalInsert.AccessibleDescription = null;
            this.btnIlgwalInsert.AccessibleName = null;
            resources.ApplyResources(this.btnIlgwalInsert, "btnIlgwalInsert");
            this.btnIlgwalInsert.BackgroundImage = null;
            this.btnIlgwalInsert.ImageIndex = 0;
            this.btnIlgwalInsert.ImageList = this.ImageList;
            this.btnIlgwalInsert.Name = "btnIlgwalInsert";
            this.btnIlgwalInsert.Click += new System.EventHandler(this.btnIlgwalInsert_Click);
            // 
            // grdBAS0272
            // 
            resources.ApplyResources(this.grdBAS0272, "grdBAS0272");
            this.grdBAS0272.ApplyPaintEventToAllColumn = true;
            this.grdBAS0272.CallerID = '2';
            this.grdBAS0272.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29});
            this.grdBAS0272.ColPerLine = 8;
            this.grdBAS0272.Cols = 8;
            this.grdBAS0272.ExecuteQuery = null;
            this.grdBAS0272.FixedRows = 1;
            this.grdBAS0272.HeaderHeights.Add(21);
            this.grdBAS0272.Name = "grdBAS0272";
            this.grdBAS0272.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0272.ParamList")));
            this.grdBAS0272.QuerySQL = resources.GetString("grdBAS0272.QuerySQL");
            this.grdBAS0272.Rows = 2;
            this.grdBAS0272.ToolTipActive = true;
            this.grdBAS0272.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0272_GridColumnChanged);
            this.grdBAS0272.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBAS0272_GridCellPainting);
            this.grdBAS0272.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0272_QueryStarting);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "end_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.CellWidth = 113;
            this.xEditGridCell23.Col = 5;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "sabun";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "end_yn";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "out_discuss_yn";
            this.xEditGridCell28.CellWidth = 180;
            this.xEditGridCell28.Col = 6;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "reser_out_yn";
            this.xEditGridCell29.CellWidth = 220;
            this.xEditGridCell29.Col = 7;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            // 
            // layDupGwa
            // 
            this.layDupGwa.ExecuteQuery = null;
            this.layDupGwa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layDupGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupGwa.ParamList")));
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "dup_yn";
            // 
            // BAS0270U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdBAS0271);
            this.Controls.Add(this.grdBAS0272);
            this.Controls.Add(this.btnIlgwalInsert);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.pnlTop);
            this.Name = "BAS0270U00";
            this.Load += new System.EventHandler(this.BAS0270U00_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0271)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0272)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Screen Load
        private string mHospCode = "";
        private void BAS0270U00_Load(object sender, EventArgs e)
        {
            //hide column doctor_name2

            if (NetInfo.Language == LangMode.Vi)
            {
                grdBAS0271.AutoSizeColumn( 3, 0);
            
            }

            // 2015.06.20 AnhNV Added START
            this.mHospCode = UserInfo.HospCode;
            //this.mHospCode = "K02"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Delete, false);
            }
            else
            {
                xHospBox.Visible = false;
            }
            // 2015.06.20 AnhNV Added END

            //mHospCode = EnvironInfo.HospCode;
            //grdBAS0271.SavePerformer = new XSavePeformer(this);
            //grdBAS0272.SavePerformer = grdBAS0271.SavePerformer;

            //int width = 0;
            //int height = 0;

            // 마스터, 디테일 Relation 
            grdBAS0272.SetRelationKey("sabun", "sabun");
            grdBAS0272.SetRelationTable("bas0272");

            if (Opener is MdiForm &&
                (OpenStyle == ScreenOpenStyle.PopUpSizable || OpenStyle == ScreenOpenStyle.PopUpFixed))
            {
                //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			

                //width = rc.Width;
                //height = rc.Height;

                //this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
            }

            grdBAS0271.FixedCols = 2;
            dtpDoctorYMD.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            dtpDoctorYMD.AcceptData();

            fwkDoctor.SetBindVarValue("f_doctor_gwa", "%");

            grdBAS0271.QueryLayout(false);

        }

        #endregion

        private void dtpDoctorYMD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdBAS0271.QueryLayout(false);
            }
        }

        #region Load Data

        private void LoadBAS0270()
        {
            grdBAS0271.QueryLayout(false);
        }

        private void InitCboGrdBAS0272Type()
        {
            _dtGrdCbo = new DataTable();
            _dtGrdCbo.Columns.Add("DisplayName", typeof(string));
            _dtGrdCbo.Columns.Add("Name", typeof(string));
            _dtGrdCbo.Rows.Add(LBL_Y, LBL_Y);
            _dtGrdCbo.Rows.Add(LBL_N, LBL_N);

            this.grdBAS0272.SetComboItems(LBL_MAIN_GWA_YN, _dtGrdCbo, "DisplayName", "Name");
        }

        #endregion

        #region 버튼리스트
        private string mMsg = "";
        private string mCap = "";
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            int rowNum = -1;
            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;
                    if (CurrMSLayout == grdBAS0271)
                    {
                        rowNum = grdBAS0271.InsertRow(-1);
                        grdBAS0271.SetItemValue(rowNum, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        grdBAS0271.SetItemValue(rowNum, "end_date", "9998/12/31");
                    }
                    else
                    {
                        rowNum = grdBAS0272.InsertRow(-1);
                        grdBAS0272.SetItemValue(rowNum, "doctor", grdBAS0271.GetItemString(grdBAS0271.CurrentRowNumber, "doctor"));
                        grdBAS0272.SetItemValue(rowNum, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        grdBAS0272.SetItemValue(rowNum, "end_date", "9998/12/31");
                        grdBAS0272.SetItemValue(rowNum, "sabun", grdBAS0271.GetItemString(grdBAS0271.CurrentRowNumber, "sabun"));
                        grdBAS0272.SetItemValue(rowNum, LBL_MAIN_GWA_YN, LBL_Y);
                    }

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    //try
                    //{
                    //    Service.BeginTransaction();

                    //    if (grdBAS0271.SaveLayout())
                    //    {
                    //        if (grdBAS0272.SaveLayout())
                    //        {
                    //            //this.grdBAS0271.QueryLayout(false);
                    //            mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resources.BAS0270U00_TEXT1;

                    //            mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resources.BAS0270U00_TEXT2;

                    //            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //        }
                    //        else
                    //            throw new Exception();
                    //    }
                    //    else
                    //        throw new Exception();

                    //    Service.CommitTransaction();
                    //}
                    //catch(Exception xe)
                    //{
                    //    Service.RollbackTransaction();
                    //    mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resources.BAS0270U00_TEXT3;

                    //    mMsg += "\r\n" + Service.ErrFullMsg;
                    //    mMsg += "\r\n" + xe.Source;

                    //    mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resources.BAS0270U00_TEXT4;

                    //    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //    break;
                    //}

                    try
                    {
                        if (SaveGridLayout())
                        {
                            mMsg = Resources.BAS0270U00_TEXT1;

                            mCap = Resources.BAS0270U00_TEXT2;

                            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {

                        mMsg = Resources.BAS0270U00_TEXT3;

                        mMsg += "\r\n" + Service.ErrFullMsg;
                        mMsg += "\r\n" + ex.Source;
                        mCap = Resources.BAS0270U00_TEXT4;
                        //XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Validate on func Validate
                    }
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdBAS0271.QueryLayout(false);
                    break;
            }
        }

        private bool SaveGridLayout()
        {
            List<BAS0270U00GrdBAS0271Info> input0271 = GetListFromGrdBAS0271();
            List<BAS0270U00GrdBAS0272Info> input0272 = GetListFromGrdBAS0272();
            if (input0271.Count == 0 && input0272.Count == 0)
            {
                return false;
            }
            BAS0270U00ExecuteArgs args = new BAS0270U00ExecuteArgs();
            args.GrdBAS0271Info = input0271;
            args.GrdBAS0272Info = input0272;
            args.UserId = UserInfo.UserID;
            args.HospCode = this.mHospCode;
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0270U00ExecuteArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!result.Result)
                {
                    string[] msgs = result.Msg.Split(Convert.ToChar(" "));
                    StringBuilder dupKeys = new StringBuilder();
                    for (int i = 0; i < msgs.Length; i++)
                    {
                        if (i == msgs.Length - 1)
                        {
                            dupKeys.Append(msgs[i]);
                        }
                        else
                        {
                            dupKeys.Append(msgs[i] + "」の「");

                        }
                    }
                    XMessageBox.Show("「" + dupKeys.ToString() + "」" + Resources.BAS0270U00_TEXT10, Resources.BAS0270U00_TEXT7, MessageBoxIcon.Warning);
                }
                return result.Result;
            }

            return false;
        }

        /// <summary>
        /// get list of object from grdBAS0272
        /// </summary>
        /// <returns></returns>
        private List<BAS0270U00GrdBAS0272Info> GetListFromGrdBAS0272()
        {
            List<BAS0270U00GrdBAS0272Info> dataList = new List<BAS0270U00GrdBAS0272Info>();
            for (int i = 0; i < grdBAS0272.RowCount; i++)
            {
                if (grdBAS0272.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                BAS0270U00GrdBAS0272Info info = new BAS0270U00GrdBAS0272Info();
                info.Doctor = grdBAS0272.GetItemString(i, "doctor");
                info.DoctorGwa = grdBAS0272.GetItemString(i, "doctor_gwa");
                info.DoctorGwaName = grdBAS0272.GetItemString(i, "gwa_name");
                info.MainGwaYn = grdBAS0272.GetItemString(i, "main_gwa_yn");
                info.StartDate = grdBAS0272.GetItemString(i, "start_date");
                info.EndDate = grdBAS0272.GetItemString(i, "end_date");
                info.Sabun = grdBAS0272.GetItemString(i, "sabun");
                info.EndYn = grdBAS0272.GetItemString(i, "end_yn");
                info.OutDiscussYn = grdBAS0272.GetItemString(i, "out_discuss_yn");
                info.ReserOutYn = grdBAS0272.GetItemString(i, "reser_out_yn");
                info.DataRowState = grdBAS0272.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdBAS0272.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdBAS0272.DeletedRowTable.Rows)
                {
                    BAS0270U00GrdBAS0272Info info = new BAS0270U00GrdBAS0272Info();
                    info.Sabun = row["sabun"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.DoctorGwa = row["doctor_gwa"].ToString();
                    info.DataRowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        /// <summary>
        /// get list of object from grdBAS0271
        /// </summary>
        /// <returns></returns>
        private List<BAS0270U00GrdBAS0271Info> GetListFromGrdBAS0271()
        {
            List<BAS0270U00GrdBAS0271Info> dataList = new List<BAS0270U00GrdBAS0271Info>();
            for (int i = 0; i < grdBAS0271.RowCount; i++)
            {
                if (grdBAS0271.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                BAS0270U00GrdBAS0271Info info = new BAS0270U00GrdBAS0271Info();
                info.Doctor = grdBAS0271.GetItemString(i, "doctor");
                info.DoctorName = grdBAS0271.GetItemString(i, "doctor_name");
                info.DoctorGrade = grdBAS0271.GetItemString(i, "doctor_grade");
                info.CtorGradeName = grdBAS0271.GetItemString(i, "doctor_grade_name");
                info.StartDate = grdBAS0271.GetItemString(i, "start_date");
                info.JubsuYn = grdBAS0271.GetItemString(i, "jubsu_yn");
                info.ReserYn = grdBAS0271.GetItemString(i, "reser_yn");
                info.EndDate = grdBAS0271.GetItemString(i, "end_date");
                info.OcsStatus = grdBAS0271.GetItemString(i, "ocs_status");
                info.LicenseBunho = grdBAS0271.GetItemString(i, "license_bunho");
                info.Sabun = grdBAS0271.GetItemString(i, "sabun");
                info.DoctorSign = grdBAS0271.GetItemString(i, "doctor_sign");
                info.CpDoctorYn = grdBAS0271.GetItemString(i, "cp_doctor_yn");
                info.DoctorName2 = grdBAS0271.GetItemString(i, "doctor_name2");
                info.MayakLicense = grdBAS0271.GetItemString(i, "mayak_license");
                info.TonggyeDoctor = grdBAS0271.GetItemString(i, "tonggye_doctor");
                info.CommonDoctorYn = grdBAS0271.GetItemString(i, "common_doctor_yn");
                info.Button = grdBAS0271.GetItemString(i, "color_button");
                info.DoctorColor = grdBAS0271.GetItemString(i, "doctor_color");
                info.DataRowState = grdBAS0271.GetRowState(i).ToString();

                if (!Validate(info)) break;

                dataList.Add(info);

            }
            if (grdBAS0271.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdBAS0271.DeletedRowTable.Rows)
                {
                    BAS0270U00GrdBAS0271Info info = new BAS0270U00GrdBAS0271Info();
                    info.Doctor = row["doctor"].ToString();
                    info.Sabun = row["sabun"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.DataRowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    //this.grdBAS0271.SetItemValue(grdBAS0271.CurrentRowNumber, "start_date", this.dtpDoctorYMD.GetDataValue());
                    break;
                case FunctionType.Reset:
                    dtpDoctorYMD.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    dtpDoctorYMD.AcceptData();
                    break;
            }
        }

        private bool Validate(BAS0270U00GrdBAS0271Info obj)
        {

            if (TypeCheck.IsNull(obj.Doctor))
            {
                XMessageBox.Show(Resources.BAS0270U00_Doctor_Null, Resources.BAS0270U00_TEXT7,
                       MessageBoxIcon.Error);
                return false;
            }
            if (NetInfo.Language != LangMode.Vi)
            {
                if (TypeCheck.IsNull(obj.DoctorName2))
                {
                    XMessageBox.Show(Resources.IlgwalInsertForm_CheckDataNULL_TEXT4, Resources.BAS0270U00_TEXT7,
                            MessageBoxIcon.Error);
                    return false;
                }
                if (!(Utilities.ValidateName(obj.DoctorName2)))
                {
                XMessageBox.Show(Resources.BAS0270U00_Doctor_Name_Incorrect, Resources.BAS0270U00_Doctor_Name_Incorrect_CAP,
                           MessageBoxIcon.Error);
                return false;
                }
            }
            if (TypeCheck.IsNull(obj.DoctorName))
            {
                XMessageBox.Show(Resources.IlgwalInsertForm_CheckDataNULL_TEXT4, Resources.BAS0270U00_TEXT7,
                        MessageBoxIcon.Error);
                return false;
            }
            if (TypeCheck.IsNull(obj.CtorGradeName))
            {
                XMessageBox.Show(Resources.BAS0270U00_CtorGradeName_Null, Resources.BAS0270U00_TEXT7,
                       MessageBoxIcon.Error);
                return false;
            }
            if (!(Utilities.ValidateName(obj.DoctorName)))
            {
                XMessageBox.Show(Resources.BAS0270U00_Doctor_Name_Incorrect, Resources.BAS0270U00_Doctor_Name_Incorrect_CAP,
                           MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region BAS0270 그리드

        private void grdBAS0271_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string msg = "";
            string name = "";

            switch (e.ColName)
            {
                case "doctor":
                    if (DupCheck(e.ChangeValue.ToString(), grdBAS0271.GetItemString(e.RowNumber, "start_date")))
                    {
                        msg = (Resources.BAS0270U00_TEXT5);

                        grdBAS0271.SetItemValue(e.RowNumber, "sabun", "");
                        SetMsg(msg, MsgType.Error);
                        e.Cancel = true;
                    }
                    grdBAS0271.SetItemValue(e.RowNumber, "sabun", e.ChangeValue);
                    break;
                case "start_date":
                    if (DupCheck(grdBAS0271.GetItemString(e.RowNumber, "doctor"), e.ChangeValue.ToString()))
                    {
                        msg = (Resources.BAS0270U00_TEXT5);

                        SetMsg(msg, MsgType.Error);
                        e.Cancel = true;
                    }
                    break;

                case "tonggye_doctor":

                    if (e.ChangeValue.ToString() == "")
                    {
                        SetMsg("");
                        return;
                    }

                    layDoctorName.SetBindVarValue("f_doctor", e.ChangeValue.ToString());

                    if (layDoctorName.QueryLayout())
                    {
                        name = layDoctorName.GetItemValue("doctor_name").ToString();

                        if (name == "")
                        {
                            msg = (Resources.BAS0270U00_grdBAS0271_GridColumnChanged_);

                            SetMsg(msg, MsgType.Error);

                            e.Cancel = true;

                            return;
                        }
                    }
                    else
                    {
                        msg = (Resources.BAS0270U00_grdBAS0271_GridColumnChanged_);

                        SetMsg(msg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }

                    SetMsg("");

                    break;

                case "doctor_grade":

                    layDoctorGrade.SetBindVarValue("f_code", e.ChangeValue.ToString());
                    layDoctorGrade.QueryLayout();
                    if (layDoctorGrade.GetItemValue("code_name").ToString() == "")
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        grdBAS0271.SetItemValue(e.RowNumber, "doctor_grade_name", layDoctorGrade.GetItemValue("code_name").ToString());
                    }

                    break;
            }
        }

        #endregion

        #region 중복체크

        private bool DupCheck(string aDoctor, string aDoctorYMD)
        {
            if (grdBAS0271.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdBAS0271.DeletedRowTable.Rows)
                {
                    if (dr["doctor"].ToString() == aDoctor &&
                        dr["start_date"].ToString() == aDoctorYMD)
                    {
                        return false;
                    }
                }
            }

            // 현재 그리드에서 찾는다.
            for (int i = 0; i < grdBAS0271.RowCount; i++)
            {
                if (i != grdBAS0271.CurrentRowNumber &&
                    grdBAS0271.GetItemString(i, "doctor") == aDoctor &&
                    grdBAS0271.GetItemString(i, "start_date") == aDoctorYMD)
                {
                    return true;
                }
            }

            // DB에서 체크한다.
            layDupCheck.QueryLayout();
            if (layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
            {
                return true;
            }

            return false;

        }
        #endregion

        private void btnIlgwalInsert_Click(object sender, EventArgs e)
        {
            //사용안됨
            IlgwalInsertForm form = new IlgwalInsertForm();

            form.ShowDialog();

            txtDoctorName.SetDataValue(form.mDoctorName);

            form.Dispose();

            btnList.PerformClick(FunctionType.Query);
        }

        private void grdBAS0271_QueryStarting(object sender, CancelEventArgs e)
        {
            grdBAS0271.SetBindVarValue("f_hosp_code", mHospCode);
            grdBAS0271.SetBindVarValue("f_doctor_ymd", dtpDoctorYMD.GetDataValue());
            grdBAS0271.SetBindVarValue("f_doctor_name", txtDoctorName.GetDataValue());
        }

        private void grdBAS0272_QueryStarting(object sender, CancelEventArgs e)
        {
            grdBAS0272.SetBindVarValue("f_hosp_code", mHospCode);
            grdBAS0272.SetBindVarValue("f_doctor_ymd", dtpDoctorYMD.GetDataValue());
            //this.grdBAS0272.SetBindVarValue("f_sabun", this.grdBAS0271.GetItemString(this.grdBAS0271.CurrentRowNumber, "sabun"));
            grdBAS0272.SetBindVarValue("f_doctor", grdBAS0271.GetItemString(grdBAS0271.CurrentRowNumber, "doctor"));


        }

        private void grdBAS0271_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            grdBAS0271.SetItemValue(e.RowNumber, "doctor_grade_name", e.ReturnValues[1].ToString());
        }

        private void grdBAS0272_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            switch (e.ColName)
            {
                case "doctor_gwa":

                    if (e.ChangeValue.ToString() == "")
                        return;

                    //중복과 체크
                    for (int i = 0; i < grdBAS0272.RowCount; i++)
                    {
                        if (e.RowNumber == i)
                            continue;

                        if (grdBAS0272.GetItemString(i, "doctor_gwa") == e.ChangeValue.ToString())
                        {
                            XMessageBox.Show(Resources.BAS0270U00_TEXT6, Resources.BAS0270U00_TEXT7, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }


                    layGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layGwa.SetBindVarValue("f_gwa", e.ChangeValue.ToString());
                    layGwa.SetBindVarValue("f_buseo_ymd", grdBAS0272.GetItemString(e.RowNumber, "start_date"));
                    layGwa.QueryLayout();
                    if (layGwa.GetItemValue("gwa_name").ToString() == "")
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        grdBAS0272.SetItemValue(e.RowNumber, "gwa_name", layGwa.GetItemValue("gwa_name").ToString());
                    }

                    break;
            }

        }

        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layDupCheck.SetBindVarValue("f_doctor", grdBAS0271.GetItemString(grdBAS0271.CurrentRowNumber, "doctor"));
            layDupCheck.SetBindVarValue("f_doctor_ymd", grdBAS0271.GetItemString(grdBAS0271.CurrentRowNumber, "start_date"));
        }

        private void layDoctorName_QueryStarting(object sender, CancelEventArgs e)
        {
            layDoctorName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layDoctorName.SetBindVarValue("f_doctor_ymd", dtpDoctorYMD.GetDataValue());
        }

        private void grdBAS0271_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdBAS0272.QueryLayout(false);
        }

        private void fwkGwa_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkGwa.SetBindVarValue("f_buseo_ymd", grdBAS0272.GetItemString(grdBAS0272.CurrentRowNumber, "start_date"));
        }

        private void fwkDoctorGrade_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkDoctorGrade.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkDoctor_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkDoctor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layDoctorGrade_QueryStarting(object sender, CancelEventArgs e)
        {
            layDoctorGrade.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdBAS0271_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            if (e.ColName == "color_button")
            {
                if (cdlColor.ShowDialog() == DialogResult.OK)
                {
                    string rgb = cdlColor.Color.R.ToString() + "," + cdlColor.Color.G.ToString() + "," + cdlColor.Color.B.ToString();
                    grdBAS0271.SetItemValue(e.RowNumber, "doctor_color", rgb);
                }
            }

        }

        private void grdBAS0271_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "doctor_color")
            {
                string rgb = grdBAS0271.GetItemString(e.RowNumber, "doctor_color");
                if (rgb != "")
                {
                    e.ForeColor = Color.Transparent;
                    grdBAS0271[e.RowNumber, "doctor_color"].BackColor = new XColor(Color.FromArgb(int.Parse(rgb.Split(',')[0]), int.Parse(rgb.Split(',')[1]), int.Parse(rgb.Split(',')[2])));
                    grdBAS0271[e.RowNumber, "doctor_color"].SelectedBackColor = new XColor(Color.FromArgb(int.Parse(rgb.Split(',')[0]), int.Parse(rgb.Split(',')[1]), int.Parse(rgb.Split(',')[2])));
                }
            }
        }

        #region XSavePeformer
        //        private class XSavePeformer : ISavePerformer
        //        {
        //            private BAS0270U00 parent = null;

        //            public XSavePeformer(BAS0270U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerId, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                object t_chk = "";

        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
        //                switch (callerId)
        //                {
        //                    case '1':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:

        //                                cmdText = @"SELECT 'Y'
        //                                              FROM DUAL
        //                                             WHERE EXISTS ( SELECT 'X'
        //                                                              FROM BAS0271
        //                                                             WHERE HOSP_CODE  = :f_hosp_code
        //                                                               AND DOCTOR     = :f_doctor
        //                                                               AND START_DATE = :f_start_date )";

        //                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                                if (!TypeCheck.IsNull(t_chk))
        //                                {
        //                                    if (t_chk.ToString() == "Y")
        //                                    {
        //                                        XMessageBox.Show("「" + item.BindVarList["f_doctor"].VarValue + "」" +Resources.BAS0270U00_TEXT8, Resources.BAS0270U00_TEXT7, MessageBoxIcon.Warning);
        //                                        return false;
        //                                    }
        //                                }

        //                                cmdText = @"INSERT INTO BAS0271
        //                                                 ( SYS_DATE          , SYS_ID             , UPD_DATE         , UPD_ID           , HOSP_CODE
        //                                                 , DOCTOR            , DOCTOR_NAME        , DOCTOR_GRADE     , START_DATE       , END_DATE
        //                                                 , RESER_YN          , LICENSE_BUNHO      , SABUN            , OCS_STATUS       , JUBSU_YN
        //                                                 , DOCTOR_SIGN       , CP_DOCTOR_YN       , DOCTOR_NAME2     , MAYAK_LICENSE    , TONGGYE_DOCTOR
        //                                                 , COMMON_DOCTOR_YN  , DOCTOR_COLOR       )
        //                                            VALUES
        //                                                 ( SYSDATE            , :q_user_id        , SYSDATE          , :q_user_id        , :f_hosp_code
        //                                                 , :f_doctor          , :f_doctor_name    , :f_doctor_grade  , :f_start_date     , :f_end_date
        //                                                 , :f_reser_yn        , :f_license_bunho  , :f_sabun         , :f_ocs_status     , :f_jubsu_yn
        //                                                 , :f_doctor_sign     , :f_cp_doctor_yn   , :f_doctor_name2  , :f_mayak_license  , :f_tonggye_doctor 
        //                                                 , :f_common_doctor_yn, :f_doctor_color   )";

        //                                break;

        //                            case DataRowState.Modified:

        //                                cmdText = @"UPDATE BAS0271 A
        //                                               SET A.UPD_ID            = :q_user_id
        //                                                 , A.UPD_DATE          = SYSDATE
        //                                                 , A.DOCTOR_NAME       = :f_doctor_name
        //                                                 , A.DOCTOR_GRADE      = :f_doctor_grade
        //                                                 , A.RESER_YN          = :f_reser_yn
        //                                                 , A.END_DATE          = :f_end_date
        //                                                 , A.LICENSE_BUNHO     = :f_license_bunho
        //                                                 , A.SABUN             = :f_sabun
        //                                                 , A.OCS_STATUS        = :f_ocs_status
        //                                                 , A.JUBSU_YN          = :f_jubsu_yn
        //                                                 , A.DOCTOR_SIGN       = :f_doctor_sign
        //                                                 , A.CP_DOCTOR_YN      = :f_cp_doctor_yn
        //                                                 , A.DOCTOR_NAME2      = :f_doctor_name2
        //                                                 , A.MAYAK_LICENSE     = :f_mayak_license
        //                                                 , A.TONGGYE_DOCTOR    = :f_tonggye_doctor 
        //                                                 , A.COMMON_DOCTOR_YN  = :f_common_doctor_yn
        //                                                 , A.DOCTOR_COLOR      = :f_doctor_color
        //                                             WHERE HOSP_CODE           = :f_hosp_code
        //                                               AND A.DOCTOR            = :f_doctor
        //                                               AND A.START_DATE        = :f_start_date";

        //                                break;

        //                            case DataRowState.Deleted:

        //                                cmdText = @"SELECT 'Y'
        //                                              FROM DUAL
        //                                             WHERE EXISTS ( SELECT 'X'
        //                                                              FROM BAS0272
        //                                                             WHERE HOSP_CODE = :f_hosp_code
        //                                                               AND SABUN     = :f_sabun )";

        //                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                                if (!TypeCheck.IsNull(t_chk))
        //                                {
        //                                    if (t_chk.ToString() == "Y")
        //                                    {
        //                                        XMessageBox.Show("「" + item.BindVarList["f_sabun"].VarValue + "」"+ Resources.BAS0270U00_TEXT9, Resources.BAS0270U00_TEXT7, MessageBoxIcon.Warning);
        //                                        return false;
        //                                    }
        //                                }

        //                                cmdText = @"DELETE FROM BAS0271 A
        //                                             WHERE HOSP_CODE    = :f_hosp_code
        //                                               AND A.DOCTOR     = :f_doctor
        //                                               AND A.START_DATE = :f_start_date";

        //                                break;
        //                        }
        //                        break;

        //                    case '2':
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:

        //                                cmdText = @"SELECT 'Y'
        //                                              FROM DUAL
        //                                             WHERE EXISTS ( SELECT 'X'
        //                                                              FROM BAS0272
        //                                                             WHERE HOSP_CODE  = :f_hosp_code
        //                                                               AND SABUN      = :f_sabun
        //                                                               --AND START_DATE = :f_start_date
        //                                                               AND DOCTOR_GWA = :f_doctor_gwa )";

        //                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                                if (!TypeCheck.IsNull(t_chk))
        //                                {
        //                                    if (t_chk.ToString() == "Y")
        //                                    {
        //                                        XMessageBox.Show("「" + item.BindVarList["f_sabun"].VarValue + "」の「" + item.BindVarList["f_doctor_gwa"].VarValue + "」"+ Resources.BAS0270U00_TEXT10, Resources.BAS0270U00_TEXT7, MessageBoxIcon.Warning);
        //                                        return false;
        //                                    }
        //                                }
        ////                                cmdText = @"UPDATE BAS0272
        ////                                             SET UPD_ID      = :q_user_id
        ////                                               , UPD_DATE    = SYSDATE
        ////                                               , END_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
        ////                                           WHERE HOSP_CODE   = :f_hosp_code
        ////                                             AND SABUN       = :f_sabun
        ////                                             AND DOCTOR_GWA  = :f_doctor_gwa
        ////                                             AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE ";

        ////                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

        //                                cmdText = @"INSERT INTO BAS0272
        //                                                 ( SYS_DATE         , SYS_ID         , UPD_DATE        , UPD_ID      , HOSP_CODE
        //                                                 , SABUN            , DOCTOR         , START_DATE      , END_DATE 
        //                                                 , DOCTOR_GWA       , MAIN_GWA_YN  )
        //                                            VALUES 
        //                                                 ( SYSDATE          , :q_user_id     , SYSDATE         , :q_user_id  , :f_hosp_code
        //                                                 , :f_sabun         , :f_doctor      , :f_start_date   , :f_end_date
        //                                                 , :f_doctor_gwa    , :f_main_gwa_yn )";

        //                                break;

        //                            case DataRowState.Modified:

        //                                cmdText = @"UPDATE BAS0272
        //                                               SET UPD_DATE     = SYSDATE
        //                                                 , UPD_ID       = :q_user_id
        //                                                 , END_DATE     = :f_end_date 
        //                                                 , MAIN_GWA_YN  = :f_main_gwa_yn
        //                                             WHERE HOSP_CODE    = :f_hosp_code
        //                                               AND SABUN        = :f_sabun
        //                                               AND START_DATE   = :f_start_date
        //                                               AND DOCTOR_GWA   = :f_doctor_gwa";
        //                                break;

        //                            case DataRowState.Deleted:

        //                                cmdText = @"DELETE FROM BAS0272
        //                                             WHERE HOSP_CODE  = :f_hosp_code
        //                                               AND SABUN      = :f_sabun
        //                                               AND START_DATE = :f_start_date
        //                                               AND DOCTOR_GWA = :f_doctor_gwa";

        //                                break;
        //                        }

        //                        break;
        //                }

        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }
        #endregion

        private void grdBAS0272_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["end_yn"].ToString() == "Y")
            {
                e.ForeColor = Color.Gray;
            }
        }

        private void xHospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            this.grdBAS0271.QueryLayout(true);
            this.grdBAS0272.QueryLayout(true);
        }

        private void xHospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                this.grdBAS0271.QueryLayout(true);
                this.grdBAS0272.QueryLayout(true);
            }
        }
    }
}