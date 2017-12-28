#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0260U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0260U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XEditGrid grdBuseo;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpBuseoYMD;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XFindWorker fwkBuseoGubun;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XPanel pnlBotton;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
        private SingleLayout layDupCheck;
        private SingleLayoutItem singleLayoutItem1;
        private XEditGridCell xEditGridCell3;
        private XGridHeader xGridHeader1;
        private ColorDialog cdlColor;
        private XEditGridCell xEditGridCell7;
        private XHospBox xHospBox;
        private XEditGridCell xEditGridCell14;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0260U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            this.grdBuseo.ParamList = new List<string>(new String[] { "f_start_date" });
            this.layDupCheck.ParamList = new List<string>(new String[] { "f_start_date", "f_code" });

            //ExecuteQuery
		    this.grdBuseo.ExecuteQuery = LoadDataGrdBuseo;
		    this.layDupCheck.ExecuteQuery = LoadDataLayDupCheck;
		    this.fwkBuseoGubun.ExecuteQuery = LoadDataFwkBuseoGubun;
            //this.xFindWorkerDepartment.ExecuteQuery = LoadDataDepatments;


            // https://sofiamedix.atlassian.net/browse/MED-12151
            this.fwkBuseoGubun.FormText = Resource.TEXT14;
		}

	    #region CloudService 

        private IList<object[]> LoadDataFwkBuseoGubun(BindVarCollection varlist)
        {
            // 2015.06.22 updated by AnhNV
            //List<object[]> res = new List<object[]>();
            //BASSFwkBuseoGubunArgs args = new BASSFwkBuseoGubunArgs();
            //ComboResult result =
            //    CacheService.Instance.Get<BASSFwkBuseoGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_BASS_FWK_BUSEOGUBUN, args,
            //        delegate(ComboResult comboResult)
            //        {
            //            return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
            //                   comboResult.ComboItem.Count > 0;
            //        });
            //if (result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    List<ComboListItemInfo> cboList = result.ComboItem;
            //    foreach (ComboListItemInfo info in cboList)
            //    {
            //        res.Add(new object[]
            //        {
            //            info.Code,
            //            info.CodeName
            //        });
            //    }
            //}
            //return res;

            IList<object[]> lObj = new List<object[]>();

            Bas0260U00fwkBuseoGubunArgs args = new Bas0260U00fwkBuseoGubunArgs();
            args.HospCode = this.mHospCode;
            ComboResult res = CacheService.Instance.Get<Bas0260U00fwkBuseoGubunArgs, ComboResult>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }

        private IList<object[]> LoadDataXEditGridCell19(BindVarCollection varlist)
        {
            // 2015.06.22 updated by AnhNV
            //List<object[]> res = new List<object[]>();
            //BASSCboInputGubunArgs args = new BASSCboInputGubunArgs();
            //ComboResult result =
            //    CacheService.Instance.Get<BASSCboInputGubunArgs, ComboResult>(
            //        Constants.CacheKeyCbo.CACHE_BASS_XEDITGRIDCELL_19, args,
            //        delegate(ComboResult comboResult)
            //        {
            //            return comboResult.ExecutionStatus == ExecutionStatus.Success && comboResult.ComboItem != null &&
            //                   comboResult.ComboItem.Count > 0;
            //        });
            //if (result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    List<ComboListItemInfo> cboList = result.ComboItem;
            //    foreach (ComboListItemInfo info in cboList)
            //    {
            //        res.Add(new object[]
            //        {
            //            info.Code,
            //            info.CodeName
            //        });
            //    }
            //}
            //return res;

            IList<object[]> lObj = new List<object[]>();

            Bas0260U00xEditGridCell19Args args = new Bas0260U00xEditGridCell19Args();
            args.HospCode = UserInfo.HospCode;
            //args.HospCode = "K02";
            ComboResult res = CacheService.Instance.Get<Bas0260U00xEditGridCell19Args, ComboResult>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }

        private List<object[]> LoadDataLayDupCheck(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Bas0260U00LayDupCheckArgs args = new Bas0260U00LayDupCheckArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            args.HospCode = this.mHospCode;
            Bas0260U00LayDupCheckResult result = CloudService.Instance.Submit<Bas0260U00LayDupCheckResult, Bas0260U00LayDupCheckArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDupResult
                });
            }
            return res;
        }

        private List<object[]> LoadDataDepatments(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Bass0260U00DepartmentArgs args = new Bass0260U00DepartmentArgs();
            args.GwaName = "";
            args.BuseoGubun = "";
            Bass0260U00DepartmentResult result = CloudService.Instance.Submit<Bass0260U00DepartmentResult, Bass0260U00DepartmentArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (Bass0260U00DepartmentInfo item in result.ItemInfo)
                {
                    object[] objects =
	                {
	                    item.BuseoCode,
	                    item.BuseoName
	                };
                    res.Add(objects);
                }
            }
            res.Add(new object[] { "abc", "def" });
            return res;
        }

        private List<object[]> LoadDataGrdBuseo(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        Bas0260U00grdBuseoInitArgs args = new Bas0260U00grdBuseoInitArgs();
	        args.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            args.HospCode = this.mHospCode;
	        Bas0260U00grdBuseoInitResult result =
	            CloudService.Instance.Submit<Bas0260U00grdBuseoInitResult, Bas0260U00grdBuseoInitArgs>(
	                args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
                int i = 0;
	            foreach (BAS0260GrdBuseoListItemInfo item in result.GrdInit)
	            {
                    string useYn = "N";
                    if (i % 2 == 0) useYn = "Y";
                    i++;
	                object[] objects =
	                {
	                    item.BuseoCode,
	                    item.BuseoName,
	                    item.ParentBuseo,
	                    item.BuseoGubun,
	                    item.GwaGubun,
	                    item.Gwa,
	                    item.GwaName,
	                    item.ParentGwa,
	                    item.OutJubsuYn,
	                    item.IpwonYn,
	                    item.OutSlipYn,
	                    item.InpSlipYn,
	                    item.EuryoseoYn,
	                    item.OutMoveYn,
	                    item.OutJundalPartYn,
	                    item.InpJundalPartYn,
	                    item.InputGubun,
	                    item.MoveComment,
	                    item.Tel,
	                    item.GwaEname,
	                    item.GwaSname,
	                    item.GwaSort1,
	                    item.GwaSort2,
	                    item.Rmk,
	                    item.EndDate,
	                    item.StartDate,
	                    item.BuseoName2,
	                    item.GwaColor,
	                    item.HpcHoDongYn,
	                    item.AddDoctor,
	                    item.GwaNameKana,
                        "",
                        item.UseYn
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        private bool SaveGridBuseo()
        {
            List<BAS0260GrdBuseoListItemInfo> inputList = GetListFromGrdBuseo();
            if (inputList.Count == 0)
            {
                return true;
            }
            Bas0260U00TransactionalArgs args = new Bas0260U00TransactionalArgs(inputList, UserInfo.UserID, this.mHospCode);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, Bas0260U00TransactionalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

	    private List<BAS0260GrdBuseoListItemInfo> GetListFromGrdBuseo()
	    {
	        List<BAS0260GrdBuseoListItemInfo> dataList = new List<BAS0260GrdBuseoListItemInfo>();
	        for (int i = 0; i < grdBuseo.RowCount; i++)
	        {
	            if (grdBuseo.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                BAS0260GrdBuseoListItemInfo info = new BAS0260GrdBuseoListItemInfo();
                info.BuseoCode = grdBuseo.GetItemString(i, "buseo_code");
                info.BuseoName = grdBuseo.GetItemString(i, "buseo_name");
                info.ParentBuseo = grdBuseo.GetItemString(i, "parent_buseo");
                info.BuseoGubun = grdBuseo.GetItemString(i, "buseo_gubun");
                info.GwaGubun = grdBuseo.GetItemString(i, "gwa_gubun");
                info.Gwa = grdBuseo.GetItemString(i, "gwa");
                info.GwaName = grdBuseo.GetItemString(i, "gwa_name");
                info.ParentGwa = grdBuseo.GetItemString(i, "parent_gwa");
                info.OutJubsuYn = grdBuseo.GetItemString(i, "out_jubsu_yn");
                info.IpwonYn = grdBuseo.GetItemString(i, "ipwon_yn");
                info.OutSlipYn = grdBuseo.GetItemString(i, "out_slip_yn");
                info.InpSlipYn = grdBuseo.GetItemString(i, "inp_slip_yn");
                info.EuryoseoYn = grdBuseo.GetItemString(i, "euryoseo_yn");
                info.OutMoveYn = grdBuseo.GetItemString(i, "out_move_yn");
                info.OutJundalPartYn = grdBuseo.GetItemString(i, "out_jundal_part_yn");
                info.InpJundalPartYn = grdBuseo.GetItemString(i, "inp_jundal_part_yn");
                info.InputGubun = grdBuseo.GetItemString(i, "input_gubun");
                info.MoveComment = grdBuseo.GetItemString(i, "move_comment");
                info.Tel = grdBuseo.GetItemString(i, "tel");
                info.GwaEname = grdBuseo.GetItemString(i, "gwa_e_name");
                info.GwaSname = grdBuseo.GetItemString(i, "gwa_s_name");
                info.GwaSort1 = grdBuseo.GetItemString(i, "gwa_sort1");
                info.GwaSort2 = grdBuseo.GetItemString(i, "gwa_sort2");
                info.Rmk = grdBuseo.GetItemString(i, "rmk");
                info.EndDate = grdBuseo.GetItemString(i, "end_date");
                info.StartDate = grdBuseo.GetItemString(i, "start_date");
                info.BuseoName2 = grdBuseo.GetItemString(i, "buseo_name2");
                info.GwaColor = grdBuseo.GetItemString(i, "gwa_color");
                info.HpcHoDongYn = grdBuseo.GetItemString(i, "hpc_ho_dong_yn");
                info.AddDoctor = grdBuseo.GetItemString(i, "add_doctor");
                info.GwaNameKana = grdBuseo.GetItemString(i, "gwa_name2");
                info.UseYn = grdBuseo.GetItemString(i, "use_yn");
	            info.RowSate = grdBuseo.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdBuseo.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdBuseo.DeletedRowTable.Rows)
	            {
                    BAS0260GrdBuseoListItemInfo info = new BAS0260GrdBuseoListItemInfo();
                    info.BuseoCode = row["buseo_code"].ToString();
                    info.StartDate = row["start_date"].ToString();
	                info.RowSate = DataRowState.Deleted.ToString();

                    dataList.Add(info);
	            }
	        }
	        return dataList;
	    }

	    #endregion

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0260U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.dtpBuseoYMD = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdBuseo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.fwkBuseoGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlBotton = new IHIS.Framework.XPanel();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.cdlColor = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuseo)).BeginInit();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
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
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.xHospBox);
            this.pnlTop.Controls.Add(this.dtpBuseoYMD);
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
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.hospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.hospBox_FindClick);
            // 
            // dtpBuseoYMD
            // 
            this.dtpBuseoYMD.AccessibleDescription = null;
            this.dtpBuseoYMD.AccessibleName = null;
            resources.ApplyResources(this.dtpBuseoYMD, "dtpBuseoYMD");
            this.dtpBuseoYMD.BackgroundImage = null;
            this.dtpBuseoYMD.IsVietnameseYearType = false;
            this.dtpBuseoYMD.Name = "dtpBuseoYMD";
            this.dtpBuseoYMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBuseoYMD_KeyDown);
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
            // grdBuseo
            // 
            this.grdBuseo.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdBuseo, "grdBuseo");
            this.grdBuseo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell33,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell7,
            this.xEditGridCell3,
            this.xEditGridCell14});
            this.grdBuseo.ColPerLine = 32;
            this.grdBuseo.ColResizable = true;
            this.grdBuseo.Cols = 32;
            this.grdBuseo.ExecuteQuery = null;
            this.grdBuseo.FixedRows = 2;
            this.grdBuseo.HeaderHeights.Add(31);
            this.grdBuseo.HeaderHeights.Add(1);
            this.grdBuseo.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdBuseo.Name = "grdBuseo";
            this.grdBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBuseo.ParamList")));
            this.grdBuseo.Rows = 3;
            this.grdBuseo.ToolTipActive = true;
            this.grdBuseo.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdBuseo_GridButtonClick);
            this.grdBuseo.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBuseo_GridColumnChanged);
            this.grdBuseo.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdBuseo_GridFindClick);
            this.grdBuseo.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBuseo_GridCellPainting);
            this.grdBuseo.PreEndInitializing += new System.EventHandler(this.grdBuseo_PreEndInitializing);
            this.grdBuseo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBuseo_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "buseo_code";
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "buseo_name";
            this.xEditGridCell2.CellWidth = 150;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "parent_buseo";
            this.xEditGridCell4.CellWidth = 70;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 1;
            this.xEditGridCell33.CellName = "buseo_gubun";
            this.xEditGridCell33.CellWidth = 117;
            this.xEditGridCell33.Col = 5;
            this.xEditGridCell33.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell33.EnableSort = true;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.FindWorker = this.fwkBuseoGubun;
            this.xEditGridCell33.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsNotNull = true;
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.RowSpan = 2;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkBuseoGubun
            // 
            this.fwkBuseoGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkBuseoGubun.ExecuteQuery = null;
            this.fwkBuseoGubun.FormText = "部署区分照会";
            this.fwkBuseoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkBuseoGubun.ParamList")));
            this.fwkBuseoGubun.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkBuseoGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkBuseoGubun_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 253;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "gwa_gubun";
            this.xEditGridCell5.CellWidth = 46;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gwa";
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 20;
            this.xEditGridCell8.CellName = "gwa_name";
            this.xEditGridCell8.CellWidth = 150;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "parent_gwa";
            this.xEditGridCell9.CellWidth = 60;
            this.xEditGridCell9.Col = 9;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 1;
            this.xEditGridCell10.CellName = "out_jubsu_yn";
            this.xEditGridCell10.CellWidth = 100;
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.InitValue = "N";
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "ipwon_yn";
            this.xEditGridCell11.CellWidth = 61;
            this.xEditGridCell11.Col = 11;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.InitValue = "N";
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 1;
            this.xEditGridCell12.CellName = "out_slip_yn";
            this.xEditGridCell12.CellWidth = 73;
            this.xEditGridCell12.Col = 12;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.EnableSort = true;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.InitValue = "N";
            this.xEditGridCell12.IsNotNull = true;
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 1;
            this.xEditGridCell13.CellName = "inp_slip_yn";
            this.xEditGridCell13.CellWidth = 72;
            this.xEditGridCell13.Col = 13;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.EnableSort = true;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.InitValue = "N";
            this.xEditGridCell13.IsNotNull = true;
            this.xEditGridCell13.RowSpan = 2;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 1;
            this.xEditGridCell15.CellName = "euryoseo_yn";
            this.xEditGridCell15.CellWidth = 60;
            this.xEditGridCell15.Col = 14;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell15.EnableSort = true;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.InitValue = "N";
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 1;
            this.xEditGridCell16.CellName = "out_move_yn";
            this.xEditGridCell16.CellWidth = 60;
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.EnableSort = true;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.InitValue = "N";
            this.xEditGridCell16.RowSpan = 2;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 1;
            this.xEditGridCell17.CellName = "out_jundal_part_yn";
            this.xEditGridCell17.CellWidth = 84;
            this.xEditGridCell17.Col = 16;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.InitValue = "N";
            this.xEditGridCell17.IsNotNull = true;
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 1;
            this.xEditGridCell18.CellName = "inp_jundal_part_yn";
            this.xEditGridCell18.CellWidth = 103;
            this.xEditGridCell18.Col = 17;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell18.EnableSort = true;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.InitValue = "N";
            this.xEditGridCell18.IsNotNull = true;
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 2;
            this.xEditGridCell19.CellName = "input_gubun";
            this.xEditGridCell19.CellWidth = 120;
            this.xEditGridCell19.Col = 18;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.EnableSort = true;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 200;
            this.xEditGridCell23.CellName = "move_comment";
            this.xEditGridCell23.CellWidth = 300;
            this.xEditGridCell23.Col = 23;
            this.xEditGridCell23.EnableSort = true;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.RowSpan = 2;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 15;
            this.xEditGridCell24.CellName = "tel";
            this.xEditGridCell24.CellWidth = 70;
            this.xEditGridCell24.Col = 24;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.RowSpan = 2;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 85;
            this.xEditGridCell26.CellName = "gwa_e_name";
            this.xEditGridCell26.CellWidth = 188;
            this.xEditGridCell26.Col = 26;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.RowSpan = 2;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gwa_s_name";
            this.xEditGridCell27.CellWidth = 209;
            this.xEditGridCell27.Col = 27;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.RowSpan = 2;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "gwa_sort1";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell28.CellWidth = 146;
            this.xEditGridCell28.Col = 28;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.RowSpan = 2;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "gwa_sort2";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.CellWidth = 120;
            this.xEditGridCell29.Col = 29;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.RowSpan = 2;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 100;
            this.xEditGridCell30.CellName = "rmk";
            this.xEditGridCell30.CellWidth = 100;
            this.xEditGridCell30.Col = 19;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.RowSpan = 2;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "end_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 117;
            this.xEditGridCell31.Col = 31;
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.RowSpan = 2;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "start_date";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell32.CellWidth = 129;
            this.xEditGridCell32.Col = 30;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsNotNull = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 40;
            this.xEditGridCell34.CellName = "buseo_name2";
            this.xEditGridCell34.CellWidth = 150;
            this.xEditGridCell34.Col = 3;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell34.RowSpan = 2;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.ApplyPaintingEvent = true;
            this.xEditGridCell35.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell35.CellLen = 20;
            this.xEditGridCell35.CellName = "gwa_color";
            this.xEditGridCell35.CellWidth = 60;
            this.xEditGridCell35.Col = 21;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.Row = 1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "hpc_ho_dong_yn";
            this.xEditGridCell36.CellWidth = 111;
            this.xEditGridCell36.Col = 22;
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.RowSpan = 2;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "add_doctor";
            this.xEditGridCell37.CellWidth = 100;
            this.xEditGridCell37.Col = 25;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 40;
            this.xEditGridCell7.CellName = "gwa_name2";
            this.xEditGridCell7.CellWidth = 110;
            this.xEditGridCell7.Col = 8;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "color_button";
            this.xEditGridCell3.CellWidth = 28;
            this.xEditGridCell3.Col = 20;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.Row = 1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "use_yn";
            this.xEditGridCell14.CellWidth = 30;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 20;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 28;
            // 
            // pnlBotton
            // 
            this.pnlBotton.AccessibleDescription = null;
            this.pnlBotton.AccessibleName = null;
            resources.ApplyResources(this.pnlBotton, "pnlBotton");
            this.pnlBotton.BackgroundImage = null;
            this.pnlBotton.Controls.Add(this.btnList);
            this.pnlBotton.Font = null;
            this.pnlBotton.Name = "pnlBotton";
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // BAS0260U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdBuseo);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.pnlTop);
            this.Name = "BAS0260U00";
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuseo)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region DatePicker

		private void dtpBuseoYMD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                this.grdBuseo.QueryLayout(false);
			}
		}

		#endregion

		#region ButtonList
        private string mMsg = "";
        private string mCap = "";
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Update:

                    if (!this.ValidCheck())
                    {
                        this.grdBuseo.SetFocusToItem(validRetVal, 0);
                        return;
                    }
					
                    e.IsBaseCall = false;

                    //if (this.grdBuseo.SaveLayout())
                    if (SaveGridBuseo())
                    {
                        this.mMsg = Resource.TEXT1;

                        this.mCap = Resource.TEXT2;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.grdBuseo.QueryLayout(false);
                    }
                    else
                    {
                        this.mMsg = Resource.TEXT3;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Resource.TEXT4;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

					break;
			}
		}



	    bool isValidationOK = true;
        int validRetVal = 0;

        private bool ValidCheck()
        {
            isValidationOK = true;
            string msg = "「";
            validRetVal = this.grdBuseo.CurrentRowNumber;

            for (int i = 0; i < this.grdBuseo.RowCount; i++)
            {
                if (this.grdBuseo.GetRowState(i) == DataRowState.Added || this.grdBuseo.GetRowState(i) == DataRowState.Modified)
                {
                    if (this.grdBuseo.GetItemString(i, "buseo_code") == "")
                    {
                        msg += Resource.TEXT5;
                        isValidationOK = false;
                    }

                    if (this.grdBuseo.GetItemString(i, "buseo_name") == "")
                    {
                        msg += Resource.TEXT6;
                        isValidationOK = false;
                    }

                    if (this.grdBuseo.GetItemString(i, "buseo_gubun") == "")
                    {
                        msg += Resource.TEXT7;
                        isValidationOK = false;
                    }

                    if (!isValidationOK)
                    {
                        msg = msg.Substring(0, msg.Length - 1);
                        XMessageBox.Show(msg + "」\r\n"+Resource.TEXT8 ,Resource.TEXT9, MessageBoxIcon.Warning );
                        return false;
                    }
                }
            }
            return true;
        }

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
                    this.grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "start_date", this.dtpBuseoYMD.GetDataValue());
                    this.grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "end_date"  , "9998/12/31");

                    BunhoSelectForm popup = new BunhoSelectForm();
                    popup.ShowDialog(this);
                    if (popup.Values == null || popup.Values.Count < 9)
                    {
                        btnList.PerformClick(FunctionType.Query);
                    }
                    else
                    {
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "buseo_code", popup.Values[0]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "buseo_name", popup.Values[1]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "buseo_name2", popup.Values[2]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "buseo_gubun", popup.Values[3]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "parent_buseo", popup.Values[4]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "gwa", popup.Values[5]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "gwa_name", popup.Values[6]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "gwa_name2", popup.Values[7]);
                        grdBuseo.SetItemValue(grdBuseo.CurrentRowNumber, "parent_gwa", popup.Values[8]);
                    }                                       
					break;
				case FunctionType.Reset:
                    this.grdBuseo.Reset();
					this.dtpBuseoYMD.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpBuseoYMD.Focus();
					break;
			}
		}

		#endregion

		#region OnLoad
        private string mHospCode = "";
		protected override void OnLoad(EventArgs e)
		{
			// TODO:  BAS0260U00.OnLoad 구현을 추가합니다.

			base.OnLoad (e);

            //mHospCode = EnvironInfo.HospCode;
            //this.grdBuseo.SavePerformer = new XSavePeformer(this);

            // 2015.06.20 AnhNV Added START
            this.mHospCode = UserInfo.HospCode;
            //this.mHospCode = "K02"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
            }
            else
            {
                xHospBox.Visible = false;
            }
            // 2015.06.20 AnhNV Added END

			int width = 0;
			int height = 0;

			if (this.Opener is IHIS.Framework.MdiForm && 
				(this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			

				width = rc.Width;
				height = rc.Height;

				this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
			}

			this.dtpBuseoYMD.SetDataValue(DateTime.Today);

			this.grdBuseo.FixedCols = 3;

            this.grdBuseo.QueryLayout(false);
		}

		#endregion

		#region Grid

		private void grdBuseo_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string msg = "";
            int retVal = 0;

			switch (e.ColName)
			{
				case "buseo_code":
                    retVal = this.DupCheck(e.ChangeValue.ToString(), grdBuseo.GetItemString(e.RowNumber, "start_date"));
					
                    if (retVal == 1) // 그리드상에 부서코드,시작일이 동일한 데이타가 있을 경우
					{
                        msg = Resource.TEXT10;
                        //this.SetMsg(msg, MsgType.Error);
                        XMessageBox.Show(msg , Resource.TEXT9, MessageBoxIcon.Warning);

                        this.SetMsg(msg, MsgType.Error);
                        e.Cancel = true;

                    }
                    else if (retVal == 2)
                    {
                        msg = (Resource.TEXT11);
                        //this.SetMsg(msg, MsgType.Error);
                        DialogResult dr = XMessageBox.Show(msg + "\r\n" +
                                         Resource.TEXT12, Resource.TEXT13, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.No)
                        {
                            this.SetMsg(msg, MsgType.Error);
                            e.Cancel = true;
                        }
                    }
                    else if (retVal == 0)
					{
						this.SetMsg("");
					}
					break;

				case "start_date":
                    retVal = this.DupCheck(grdBuseo.GetItemString(e.RowNumber, "buseo_code"), e.ChangeValue.ToString());
                    
                    if (retVal == 1) // 그리드상에 부서코드,시작일이 동일한 데이타가 있을 경우
                    {
                        msg = Resource.TEXT10;
                        //this.SetMsg(msg, MsgType.Error);
                        XMessageBox.Show(msg, Resource.TEXT9, MessageBoxIcon.Warning);

                        this.SetMsg(msg, MsgType.Error);
                        e.Cancel = true;

                    }
                    else if (retVal == 2)
                    {
                        msg = (Resource.TEXT11);
                        //this.SetMsg(msg, MsgType.Error);
                        DialogResult dr = XMessageBox.Show(msg + "\r\n" +
                                         Resource.TEXT12, Resource.TEXT13, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.No)
                        {
                            this.SetMsg(msg, MsgType.Error);
                            e.Cancel = true;
                        }
                    }
                    else if (retVal == 0)
                    {
                        this.SetMsg("");
                    }
                    break;
			}
		}

		#endregion

		#region DupCheck

		private int DupCheck(string aValue, string aBuseoYMD)
		{
            //if (this.grdBuseo.DeletedRowTable != null)
            //{
            //    foreach (DataRow dr in grdBuseo.DeletedRowTable.Rows)
            //    {
            //        if (dr["buseo_code"].ToString() == aValue && dr["start_date"].ToString() == aBuseoYMD)
            //        {
            //            return false;
            //        }
            //    }
            //}
				// 현재 그리드에서 찾는다.
			for (int i=0; i<this.grdBuseo.RowCount; i++)
			{
				if (i != this.grdBuseo.CurrentRowNumber &&
					this.grdBuseo.GetItemString(i, "buseo_code") == aValue &&
					this.grdBuseo.GetItemString(i, "start_date") == aBuseoYMD)
                {
					return 1;
				}
			}

				// DB에서 체크한다.
			this.layDupCheck.QueryLayout();
			if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
			{
				return 2;
			}
	
			return 0;		
		}

		#endregion

        private void grdBuseo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBuseo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBuseo.SetBindVarValue("f_start_date", this.dtpBuseoYMD.GetDataValue());
        }

        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_code", this.grdBuseo.GetItemString(grdBuseo.CurrentRowNumber, "buseo_code"));
            this.layDupCheck.SetBindVarValue("f_start_date", this.grdBuseo.GetItemString(grdBuseo.CurrentRowNumber, "start_date"));
        }

        private void fwkBuseoGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkBuseoGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdBuseo_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            if (e.ColName == "color_button")
            {
                if (cdlColor.ShowDialog() == DialogResult.OK)
                {
                    string rgb = cdlColor.Color.R.ToString() + "," + cdlColor.Color.G.ToString() + "," + cdlColor.Color.B.ToString();
                    this.grdBuseo.SetItemValue(e.RowNumber, "gwa_color", rgb);
                }
            }

        }

        private void grdBuseo_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "gwa_color")
            {
                string rgb = this.grdBuseo.GetItemString(e.RowNumber, "gwa_color");
                if (rgb != "")
                {
                    e.ForeColor = Color.Transparent;
                    this.grdBuseo[e.RowNumber, "gwa_color"].BackColor = new XColor(Color.FromArgb(int.Parse(rgb.Split(',')[0]), int.Parse(rgb.Split(',')[1]), int.Parse(rgb.Split(',')[2])));
                    this.grdBuseo[e.RowNumber, "gwa_color"].SelectedBackColor = new XColor(Color.FromArgb(int.Parse(rgb.Split(',')[0]), int.Parse(rgb.Split(',')[1]), int.Parse(rgb.Split(',')[2])));
                }
            }

        }


        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private BAS0260U00 parent = null;

//            public XSavePeformer(BAS0260U00 parent)
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
//                                                              FROM BAS0260 A
//                                                             WHERE A.HOSP_CODE  = :f_hosp_code
//                                                               AND A.BUSEO_CODE = :f_buseo_code
//                                                               AND A.START_DATE <> TO_DATE(:f_start_date, 'YYYY/MM/DD')
//                                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE) ";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        cmdText = @"UPDATE BAS0260 A
//                                                       SET A.UPD_ID   = :q_user_id
//                                                         , A.UPD_DATE  = SYSDATE
//                                                         , A.END_DATE   = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1 
//                                                     WHERE A.HOSP_CODE  = :f_hosp_code
//                                                       AND A.BUSEO_CODE = :f_buseo_code
//                                                       AND A.START_DATE <> TO_DATE(:f_start_date, 'YYYY/MM/DD')
//                                                       AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

//                                        if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                        {
//                                            //return false;
//                                        }
//                                    }
//                                }

//                                cmdText = @"INSERT INTO BAS0260 
//                                                 ( SYS_DATE             , SYS_ID           , UPD_DATE        , UPD_ID            , HOSP_CODE     
//                                                 , BUSEO_CODE           , START_DATE       , BUSEO_NAME      , BUSEO_GUBUN       , PARENT_BUSEO
//                                                 , GWA                  , GWA_NAME         , PARENT_GWA      , OUT_JUBSU_YN      , IPWON_YN
//                                                 , OUT_SLIP_YN          , INP_SLIP_YN      , INPUT_GUBUN     , OUT_MOVE_YN       , OUT_JUNDAL_PART_YN
//                                                 , INP_JUNDAL_PART_YN   , EURYOSEO_YN      , TEL             , GWA_GUBUN         , MOVE_COMMENT
//                                                 , GWA_SORT2            , GWA_SORT1        , GWA_ENAME       , GWA_SNAME         , RMK
//                                                 , END_DATE             , BUSEO_NAME2     , GWA_COLOR         , HPC_HO_DONG_YN   , ADD_DOCTOR 
//                                                 , GWA_NAME_KANA        )
//                                            VALUES 
//                                                 ( SYSDATE              , :q_user_id       , SYSDATE         , :q_user_id        , :f_hosp_code
//                                                 , :f_buseo_code        , :f_start_date    , :f_buseo_name   , :f_buseo_gubun    , :f_parent_buseo
//                                                 , :f_gwa               , :f_gwa_name      , :f_parent_gwa   , :f_out_jubsu_yn   , :f_ipwon_yn
//                                                 , :f_out_slip_yn       , :f_inp_slip_yn   , :f_input_gubun  , :f_out_move_yn    , :f_out_jundal_part_yn
//                                                 , :f_inp_jundal_part_yn, :f_euryoseo_yn   , :f_tel          , :f_gwa_gubun      , :f_move_comment
//                                                 , :f_sort_key2         , :f_sort_key1     , :f_gwa_ename    , :f_gwa_sname      , :f_rmk
//                                                 , :f_end_date          , :f_buseo_name2   , :f_gwa_color    , :f_hpc_ho_dong_yn , :f_add_doctor
//                                                 , :f_gwa_name2         )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE BAS0260 A
//                                               SET A.UPD_DATE           = SYSDATE
//                                                 , A.UPD_ID             = :q_user_id
//                                                 , A.BUSEO_NAME         = :f_buseo_name
//                                                 , A.PARENT_BUSEO       = :f_parent_buseo
//                                                 , A.BUSEO_GUBUN        = :f_buseo_gubun
//                                                 , A.GWA_GUBUN          = :f_gwa_gubun
//                                                 , A.GWA                = :f_gwa
//                                                 , A.GWA_NAME           = :f_gwa_name
//                                                 , A.PARENT_GWA         = :f_parent_gwa
//                                                 , A.OUT_JUBSU_YN       = :f_out_jubsu_yn
//                                                 , A.IPWON_YN           = :f_ipwon_yn
//                                                 , A.OUT_SLIP_YN        = :f_out_slip_yn
//                                                 , A.INP_SLIP_YN        = :f_inp_slip_yn
//                                                 , A.EURYOSEO_YN        = :f_euryoseo_yn
//                                                 , A.OUT_MOVE_YN        = :f_out_move_yn
//                                                 , A.OUT_JUNDAL_PART_YN = :f_out_jundal_part_yn
//                                                 , A.INP_JUNDAL_PART_YN = :f_inp_jundal_part_yn
//                                                 , A.INPUT_GUBUN        = :f_input_gubun
//                                                 , A.MOVE_COMMENT       = :f_move_comment
//                                                 , A.TEL                = :f_tel
//                                                 , A.GWA_ENAME          = :f_gwa_ename
//                                                 , A.GWA_SNAME          = :f_gwa_sname
//                                                 , A.GWA_SORT1          = :f_sort_key1
//                                                 , A.GWA_SORT2          = :f_sort_key2
//                                                 , A.RMK                = :f_rmk
//                                                 , A.END_DATE           = :f_end_date
//                                                 , A.BUSEO_NAME2        = :f_buseo_name2
//                                                 , A.GWA_COLOR          = :f_gwa_color     
//                                                 , A.HPC_HO_DONG_YN     = :f_hpc_ho_dong_yn
//                                                 , A.ADD_DOCTOR         = :f_add_doctor
//                                                 , A.GWA_NAME_KANA      = :f_gwa_name2
//                                             WHERE A.HOSP_CODE          = :f_hosp_code
//                                               AND A.BUSEO_CODE         = :f_buseo_code
//                                               AND A.START_DATE         = :f_start_date";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"UPDATE BAS0260
//                                               SET UPD_ID      = :q_user_id
//                                                 , UPD_DATE    = SYSDATE
//                                                 , END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DDD') 
//                                             WHERE HOSP_CODE   = :f_hosp_code
//                                               AND BUSEO_CODE  = :f_buseo_code
//                                               AND END_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1 ";

//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                cmdText = @"DELETE FROM BAS0260 A
//                                              WHERE A.HOSP_CODE        = :f_hosp_code
//                                                AND A.BUSEO_CODE       = :f_buseo_code
//                                                AND A.START_DATE       = :f_start_date";

//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void grdBuseo_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell19.ExecuteQuery = LoadDataXEditGridCell19;
        }

        private void hospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            this.grdBuseo.QueryLayout(true);
        }

        private void hospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                this.grdBuseo.QueryLayout(true);
            }
        }

        private void grdBuseo_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (e.ColName == "buseo_code")
            {
                BunhoSelectForm popup = new BunhoSelectForm();
                popup.ShowDialog(this);

                if (popup.Values == null || popup.Values.Count < 9) return;

                grdBuseo.SetItemValue(e.RowNumber, "buseo_code", popup.Values[0]);
                grdBuseo.SetItemValue(e.RowNumber, "buseo_name", popup.Values[1]);
                grdBuseo.SetItemValue(e.RowNumber, "buseo_name2", popup.Values[2]);
                grdBuseo.SetItemValue(e.RowNumber, "buseo_gubun", popup.Values[3]);
                grdBuseo.SetItemValue(e.RowNumber, "parent_buseo", popup.Values[4]);
                grdBuseo.SetItemValue(e.RowNumber, "gwa", popup.Values[5]);
                grdBuseo.SetItemValue(e.RowNumber, "gwa_name", popup.Values[6]);
                grdBuseo.SetItemValue(e.RowNumber, "gwa_name2", popup.Values[7]);
                grdBuseo.SetItemValue(e.RowNumber, "parent_gwa", popup.Values[8]);
            }
        }

    }
}
