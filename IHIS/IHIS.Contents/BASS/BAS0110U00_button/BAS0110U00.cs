#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
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
	/// BAS0110에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0110U00 : XScreen
	{
        private XPanel pnlTop;
		private XPanel pnlBottom;
        private XLabel xLabel1;
		private XLabel xLabel2;
		private XTextBox txtAddress;
		private XFindBox fbxJohapGubun;
        private XDisplayBox dbxJohapGubunName;
		private XFindWorker fwkCommon;
		private FindColumnInfo findColumnInfo1;
		private FindColumnInfo findColumnInfo2;
		private XButtonList btnList;
        private SingleLayout layCommon;
        private SingleLayout layJohapGubun;
		private SingleLayout layZipCode2;
		private SingleLayout layDupCheck;
        private PictureBox pictureBox1;
		private XLabel xLabel3;
		private XDatePicker dtpJukyongDate;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XEditGrid grdJohap;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XGridHeader xGridHeader1;
        private SingleLayoutItem singleLayoutItem4;
        private XLabel xLabel4;
        private XTextBox txtJohap;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private Container components = null;

		public BAS0110U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            layCommon.ParamList = new List<string>(new String[] { "f_code" });
            layZipCode2.ParamList = new List<string>(new String[] { "f_zip_code1", "f_zip_code2" });
            grdJohap.ParamList = new List<string>(new String[] { "f_johap_gubun", "f_start_date", "f_johap" });

            //set ExecuteQuery
		    fwkCommon.ExecuteQuery = LoadDataFwkCommon;
		    layCommon.ExecuteQuery = LoadDataLayCommon;
		    layJohapGubun.ExecuteQuery = LoadDataLayJohapGubun;
		    layZipCode2.ExecuteQuery = LoadDataLayZipCode2;
		    grdJohap.ExecuteQuery = LoadDataGrdJohap;
		}


	    #region CloudService

        private List<object[]> LoadDataGrdJohap(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110U00GrdJohapArgs args = new BAS0110U00GrdJohapArgs();
            args.JohapGubun = bc["f_johap_gubun"] != null ? bc["f_johap_gubun"].VarValue : "";
            args.Johap = bc["f_johap"] != null ? bc["f_johap"].VarValue : "";
            args.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            BAS0110U00GrdJohapResult result = CloudService.Instance.Submit<BAS0110U00GrdJohapResult, BAS0110U00GrdJohapArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0110U00GrdJohapListItemInfo item in result.ListGrdJohap)
                {
                    object[] objects = 
				{ 
					item.Johap, 
					item.StartDate, 
					item.JohapName, 
					item.JohapGubun, 
					item.ZipCode1, 
					item.ZipCode2, 
					item.Address, 
					item.Cd, 
					item.BoheomjaNo, 
					item.DodobuhyeunNo, 
					item.LawNo, 
					item.Address1, 
					item.Tel, 
					item.Giho, 
					item.Remark, 
					item.CheckDigitYn
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        private List<object[]> LoadDataLayZipCode2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110U00LayZipCode2Args args = new BAS0110U00LayZipCode2Args();
            args.ZipCode1 = bc["f_zip_code1"] != null ? bc["f_zip_code1"].VarValue : "";
            args.ZipCode2 = bc["f_zip_code2"] != null ? bc["f_zip_code2"].VarValue : "";
            BAS0110U00LayZipCode2Result result = CloudService.Instance.Submit<BAS0110U00LayZipCode2Result, BAS0110U00LayZipCode2Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.ZipName
                });
            }
            return res;
        } 



        private List<object[]> LoadDataLayJohapGubun(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110U00getCodeNameArgs args = new BAS0110U00getCodeNameArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            BAS0110U00CodeNameResult result =
                CloudService.Instance.Submit<BAS0110U00CodeNameResult, BAS0110U00getCodeNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.CodeName
                });
            }
            return res;
        }

        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110U00getCodeNameArgs args = new BAS0110U00getCodeNameArgs();
            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            BAS0110U00CodeNameResult result =
                CloudService.Instance.Submit<BAS0110U00CodeNameResult, BAS0110U00getCodeNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.CodeName
                });
            }
            return res;
        }

        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        BAS0110U00FwkCommonArgs args = new BAS0110U00FwkCommonArgs();
	        args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
	        BAS0110U00FwkCommonResult result =
	            CloudService.Instance.Submit<BAS0110U00FwkCommonResult, BAS0110U00FwkCommonArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ComboListItemInfo item in result.ListInfo)
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


        private bool SaveGrdJoHap()
        {
            List<BAS0110U00GrdJohapListItemInfo> inputList = GetListFromGrdJoHap();
            if (inputList.Count == 0)
            {
                return true;
            }
            if (!Validation_Check(inputList))
            {
                return false;
            }

            BAS0110U00TransactionalArgs args = new BAS0110U00TransactionalArgs(inputList, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0110U00TransactionalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }


        private bool Validation_Check(List<BAS0110U00GrdJohapListItemInfo> inputList)
        {
            bool value = true;
            string messg = "";
            this.mCheck = "";
            foreach (BAS0110U00GrdJohapListItemInfo info in inputList)
            {
                if (info.RowState == DataRowState.Added.ToString() || info.RowState == DataRowState.Modified.ToString())
                {
                    if (info.Johap == "")
                    {
                        messg += Resource.BAS0110U00_TEXT8;
                        value = false;
                    }
                    if (info.StartDate == "")
                    {
                        if (value == false)
                        {
                            messg += ",";
                        }
                        messg += Resource.BAS0110U00_TEXT9;
                        value = false;
                    }
                    if (info.JohapName == "")
                    {
                        if (value == false)
                        {
                            messg += ",";
                        }
                        messg += Resource.BAS0110U00_TEXT10;
                        value = false;
                    }
                    if (info.JohapGubun == "")
                    {
                        if (value == false)
                        {
                            messg += ",";
                        }
                        messg += Resource.BAS0110U00_TEXT11;
                        value = false;
                    }
                    if (value == false)
                    {
                        this.mCheck = messg;
                        return value;
                    }
                }
            }
            this.mCheck = messg;
            return value;
        }

	    private List<BAS0110U00GrdJohapListItemInfo> GetListFromGrdJoHap()
	    {
	        List<BAS0110U00GrdJohapListItemInfo> dataList = new List<BAS0110U00GrdJohapListItemInfo>();
	        for (int i = 0; i < grdJohap.RowCount; i++)
	        {
	            if (grdJohap.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                BAS0110U00GrdJohapListItemInfo info = new BAS0110U00GrdJohapListItemInfo();
                info.Johap = grdJohap.GetItemString(i, "johap");
                info.StartDate = grdJohap.GetItemString(i, "start_date");
                info.JohapName = grdJohap.GetItemString(i, "johap_name");
                info.JohapGubun = grdJohap.GetItemString(i, "johap_gubun");
                info.ZipCode1 = grdJohap.GetItemString(i, "zip_code1");
                info.ZipCode2 = grdJohap.GetItemString(i, "zip_code2");
                info.Address = grdJohap.GetItemString(i, "address");
                info.Cd = grdJohap.GetItemString(i, "cd");
                info.BoheomjaNo = grdJohap.GetItemString(i, "boheomja_no");
                info.DodobuhyeunNo = grdJohap.GetItemString(i, "dodobuhyeun_no");
                info.LawNo = grdJohap.GetItemString(i, "law_no");
                info.Address1 = grdJohap.GetItemString(i, "address1");
                info.Tel = grdJohap.GetItemString(i, "tel");
                info.Giho = grdJohap.GetItemString(i, "giho");
                info.Remark = grdJohap.GetItemString(i, "remark");
                info.CheckDigitYn = grdJohap.GetItemString(i, "check_digit_yn");
	            info.RowState = grdJohap.GetRowState(i).ToString();

                dataList.Add(info);
	        }

	        if (grdJohap.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdJohap.DeletedRowTable.Rows)
	            {
                    BAS0110U00GrdJohapListItemInfo info = new BAS0110U00GrdJohapListItemInfo();
	                info.Johap = row["johap"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.JohapGubun = row["johap_gubun"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0110U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtJohap = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxJohapGubunName = new IHIS.Framework.XDisplayBox();
            this.fbxJohapGubun = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAddress = new IHIS.Framework.XTextBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layJohapGubun = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layZipCode2 = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.grdJohap = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJohap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtJohap);
            this.pnlTop.Controls.Add(this.xLabel4);
            this.pnlTop.Controls.Add(this.dtpJukyongDate);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.dbxJohapGubunName);
            this.pnlTop.Controls.Add(this.fbxJohapGubun);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // txtJohap
            // 
            resources.ApplyResources(this.txtJohap, "txtJohap");
            this.txtJohap.Name = "txtJohap";
            this.txtJohap.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtJohap_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // dtpJukyongDate
            // 
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            this.dtpJukyongDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJukyongDate_DateValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dbxJohapGubunName
            // 
            resources.ApplyResources(this.dbxJohapGubunName, "dbxJohapGubunName");
            this.dbxJohapGubunName.Name = "dbxJohapGubunName";
            // 
            // fbxJohapGubun
            // 
            this.fbxJohapGubun.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxJohapGubun, "fbxJohapGubun");
            this.fbxJohapGubun.Name = "fbxJohapGubun";
            this.fbxJohapGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJohapGubun_DataValidating);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = "保険区分照会";
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "gubun";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "gubun_name";
            this.findColumnInfo2.ColWidth = 155;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // txtAddress
            // 
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.Name = "txtAddress";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtAddress);
            this.pnlBottom.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
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
            this.singleLayoutItem1.BindControl = this.dbxJohapGubunName;
            this.singleLayoutItem1.DataName = "JohapGubunName";
            // 
            // layJohapGubun
            // 
            this.layJohapGubun.ExecuteQuery = null;
            this.layJohapGubun.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layJohapGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJohapGubun.ParamList")));
            this.layJohapGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layJohapGubun_QueryStarting);
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "code_name";
            // 
            // layZipCode2
            // 
            this.layZipCode2.ExecuteQuery = null;
            this.layZipCode2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layZipCode2.ParamList")));
            this.layZipCode2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layZipCode2_QueryStarting);
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "code_name";
            // 
            // grdJohap
            // 
            this.grdJohap.AddedHeaderLine = 1;
            this.grdJohap.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
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
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdJohap.ColPerLine = 12;
            this.grdJohap.Cols = 12;
            this.grdJohap.ControlBinding = true;
            resources.ApplyResources(this.grdJohap, "grdJohap");
            this.grdJohap.ExecuteQuery = null;
            this.grdJohap.FixedRows = 2;
            this.grdJohap.HeaderHeights.Add(23);
            this.grdJohap.HeaderHeights.Add(19);
            this.grdJohap.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdJohap.Name = "grdJohap";
            this.grdJohap.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJohap.ParamList")));
            this.grdJohap.QuerySQL = resources.GetString("grdJohap.QuerySQL");
            this.grdJohap.Rows = 3;
            this.grdJohap.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdJohap_GridColumnChanged);
            this.grdJohap.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdJohap_GridFindClick);
            this.grdJohap.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdJohap_GridCellFocusChanged);
            this.grdJohap.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJohap_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 13;
            this.xEditGridCell1.CellName = "johap";
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "start_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 60;
            this.xEditGridCell3.CellName = "johap_name";
            this.xEditGridCell3.CellWidth = 160;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "johap_gubun";
            this.xEditGridCell4.CellWidth = 60;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.FindWorker = this.fwkCommon;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 3;
            this.xEditGridCell7.CellName = "zip_code1";
            this.xEditGridCell7.CellWidth = 49;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 4;
            this.xEditGridCell8.CellName = "zip_code2";
            this.xEditGridCell8.CellWidth = 49;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 80;
            this.xEditGridCell9.CellName = "address";
            this.xEditGridCell9.CellWidth = 150;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 2;
            this.xEditGridCell10.CellName = "cd";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "boheomja_no";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dodobuhyeun_no";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "law_no";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "address1";
            this.xEditGridCell14.CellWidth = 300;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 15;
            this.xEditGridCell15.CellName = "tel";
            this.xEditGridCell15.CellWidth = 100;
            this.xEditGridCell15.Col = 9;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 60;
            this.xEditGridCell16.CellName = "giho";
            this.xEditGridCell16.CellWidth = 172;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.RowSpan = 2;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.txtAddress;
            this.xEditGridCell18.CellLen = 4000;
            this.xEditGridCell18.CellName = "remark";
            this.xEditGridCell18.CellWidth = 267;
            this.xEditGridCell18.Col = 10;
            this.xEditGridCell18.DisplayMemoText = true;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "check_digit_yn";
            this.xEditGridCell19.CellWidth = 106;
            this.xEditGridCell19.Col = 11;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 5;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 49;
            // 
            // BAS0110U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdJohap);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.pnlTop);
            this.Name = "BAS0110U00";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0110U00_Closing);
            this.Load += new System.EventHandler(this.BAS0110U00_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJohap)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 코드별 자릿수

		const int CD_LENGTH = 1;
		const int BOHEOMJA_NO_LENGTH = 3;
		const int DODOBUHYEUN_NO_LENGTH = 2;
		const int LAW_NO_LENGTH = 2;

		#endregion

		#region Parssing

		private void ParssingJohapBunho()
		{
			string johap = grdJohap.GetItemString(grdJohap.CurrentRowNumber, "johap");
			int length = johap.Length;
			string cd = "";
			string boheomja = "";
			string dodobuhyeun = "";
			string lawNo = "";

			// CD 파싱
			if ( length - CD_LENGTH >= 0 )
			{
				cd = johap.Substring(length - CD_LENGTH, CD_LENGTH);
			}

			// 보험자 번호 파싱
			if (length - CD_LENGTH - BOHEOMJA_NO_LENGTH >= 0)
			{
				boheomja = johap.Substring(length - CD_LENGTH - BOHEOMJA_NO_LENGTH, BOHEOMJA_NO_LENGTH);
			}

			// 부현번호 파싱
			if (length - CD_LENGTH - BOHEOMJA_NO_LENGTH - DODOBUHYEUN_NO_LENGTH >= 0)
			{
				dodobuhyeun = johap.Substring(length - CD_LENGTH - BOHEOMJA_NO_LENGTH - DODOBUHYEUN_NO_LENGTH, DODOBUHYEUN_NO_LENGTH);
			}

			// 법별번호
			if (length - CD_LENGTH - BOHEOMJA_NO_LENGTH - DODOBUHYEUN_NO_LENGTH - LAW_NO_LENGTH >= 0 )
			{
				lawNo = johap.Substring(length - CD_LENGTH - BOHEOMJA_NO_LENGTH - DODOBUHYEUN_NO_LENGTH - LAW_NO_LENGTH, LAW_NO_LENGTH);
			}

			grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "cd", cd);
			grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "boheomja_no", boheomja);
			grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "dodobuhyeun_no", dodobuhyeun);
			grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "law_no", lawNo);

		}

		#endregion

		#region 버튼리스트
        private string mMsg = "";
        private string mCap = "";
        string mCheck = "";
        bool boolSave = true;
		private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
		{
            boolSave = true;

			switch(e.Func)
			{
				case FunctionType.Insert:
					grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "johap_gubun", fbxJohapGubun.Text);
                    grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					//this.grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "direct_receipt_yn", "N");
					break;

                case FunctionType.Update:

                    //if (grdJohap.SaveLayout())
                    //{
                    //    mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.BAS0110U00_TEXT1;

                    //    mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resource.BAS0110U00_TEXT2;

                    //    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //else
                    //{
                    //    boolSave = false;

                    //    mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.BAS0110U00_TEXT3;
                    //    if (Service.ErrFullMsg == "")
                    //    {
                    //        string mesg = NetInfo.Language == LangMode.Ko ? "를 입력하여주십시요." : Resource.BAS0110U00_TEXT4;
                    //        mMsg = mCheck + mesg;

                    //        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.BAS0110U00_TEXT5;
                    //        mMsg += "\r\n" + Service.ErrFullMsg;
                    //        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    return;
                    //}

                    if (SaveGrdJoHap())
                    {
                        mMsg = Resource.BAS0110U00_TEXT1;

                        mCap = Resource.BAS0110U00_TEXT2;

                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.grdJohap.QueryLayout(true);
                    }
                    else
                    {
                        boolSave = false;

                        mCap = Resource.BAS0110U00_TEXT3;
                        if (mCheck != "")
                        {
                            string mesg = Resource.BAS0110U00_TEXT4;
                            mMsg = mCheck + mesg;

                            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mMsg = Resource.BAS0110U00_TEXT5;
                            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    break;
                case FunctionType.Reset:
                    dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    break;
			}
		}


	    #endregion

		#region 다이나믹 서비스 Pre/Post

        //그리드에 보험명셋팅용
        private void layJohapGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            layJohapGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        //중복체크용
        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layZipCode2_QueryStarting(object sender, CancelEventArgs e)
        {
            layZipCode2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layZipCode2.SetBindVarValue("f_zip_code1", grdJohap.GetItemString(grdJohap.CurrentRowNumber, "zip_code1"));
            layZipCode2.SetBindVarValue("f_zip_code2", grdJohap.GetItemString(grdJohap.CurrentRowNumber, "zip_code2"));
        }
    
        private void grdJohap_QueryStarting(object sender, CancelEventArgs e)
        {
            grdJohap.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdJohap.SetBindVarValue("f_johap_gubun", fbxJohapGubun.GetDataValue());
            grdJohap.SetBindVarValue("f_start_date", dtpJukyongDate.GetDataValue());
            grdJohap.SetBindVarValue("f_johap", txtJohap.GetDataValue());
        }

        //디스플레이박스에 보험명 셋팅용
        private void layCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCommon.SetBindVarValue("f_code", fbxJohapGubun.Text);
        }

        private void fbxJohapGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            layCommon.QueryLayout();

            grdJohap.QueryLayout(true);
        }

		#endregion

		#region Grid 이벤트

		private void grdJohap_GridFindClick(object sender, GridFindClickEventArgs e)
		{
			if (e.ColName == "address1")
			{
				CommonItemCollection param = new CommonItemCollection();
				param.Add("SearchGubun", "Address");
				param.Add("address", grdJohap.GetItemString(e.RowNumber, e.ColName) );

				OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
			}
			else if (e.ColName == "zip_code1")
			{
				CommonItemCollection param = new CommonItemCollection();
				param.Add("SearchGubun", "zipCode");
				param.Add("zip_code1", grdJohap.GetItemString(e.RowNumber, e.ColName));
				param.Add("zip_code2", grdJohap.GetItemString(e.RowNumber, "zip_code2"));

				OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
			}
		}

		private void grdJohap_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
		{
//			switch (e.ColName)
//			{
//				case "zip_code1":
//					this.grdJohap.SetItemValue(e.RowNumber, "zip_code2", "");
//					break;
//			}

		}

		private void grdJohap_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
		{
            string msg = "";
            e.Cancel = false;

            if (e.ChangeValue.ToString() == "")
            {
                SetMsg(msg);
                return;
            }
			switch(e.ColName)
			{
				case "johap":
                case "start_date":
                    if (DupCheck(grdJohap.GetItemString(e.RowNumber, "johap"), grdJohap.GetItemString(e.RowNumber, "start_date")))
					{
						msg = (Resource.BAS0110U00_TEXT6);
						SetMsg(msg, MsgType.Error);
						e.Cancel = true;
					}
					ParssingJohapBunho();
					break;
                case "johap_gubun":
//                    layDupCheck.QuerySQL = @" SELECT 'Y'
//                                                     FROM BAS0102 A
//                                                    WHERE A.HOSP_CODE = :f_hosp_code 
//                                                      AND A.CODE_TYPE = 'JOHAP_GUBUN'
//                                                      AND A.CODE      = :f_code ";
//                    layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                    layDupCheck.SetBindVarValue("f_code", e.ChangeValue.ToString());
//                    layDupCheck.QueryLayout();

                    BAS0110U00GrdJohapGubunArgs args = new BAS0110U00GrdJohapGubunArgs();
			        args.Code = e.ChangeValue.ToString();
			        args.ColName = "johap_gubun";
			        BAS0110U00GrdJohapGubunResult result =
			            CloudService.Instance.Submit<BAS0110U00GrdJohapGubunResult, BAS0110U00GrdJohapGubunArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result != "Y")
                    {
                        msg = (Resource.BAS0110U00_TEXT7);
                        SetMsg(msg, MsgType.Error);
                        e.Cancel = true;
                    }

                    //if (layDupCheck.GetItemValue("dup_yn").ToString() != "Y")
                    //{
                    //    msg = (NetInfo.Language == LangMode.Ko ? "등록되지않은보험구분입니다." : Resource.BAS0110U00_TEXT7);
                    //    SetMsg(msg, MsgType.Error);
                    //    e.Cancel = true;
                    //}
					break;
				case "zip_code2":
                    if (grdJohap.GetItemString(e.RowNumber, "zip_code1") !="")
                    {
//                        layDupCheck.QuerySQL = @" SELECT A.ZIP_NAME1 || A.ZIP_NAME2 || A.ZIP_NAME3 ZIP_NAME
//                                                         FROM BAS0123 A
//                                                         WHERE A.HOSP_CODE = :f_hosp_code 
//                                                           AND A.ZIP_CODE1 = :f_zip_code1
//                                                           AND A.ZIP_CODE2 = :f_zip_code2 ";
//                        layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                        layDupCheck.SetBindVarValue("f_zip_code1", grdJohap.GetItemString(e.RowNumber, "zip_code1"));
//                        layDupCheck.SetBindVarValue("f_zip_code2", e.ChangeValue.ToString());
//                        layDupCheck.QueryLayout();
//                        grdJohap.SetItemValue(e.RowNumber, "address1", layDupCheck.GetItemValue("dup_yn").ToString());

                        BAS0110U00GrdJohapGubunArgs args2 = new BAS0110U00GrdJohapGubunArgs();
                        args2.ColName = "zip_code2";
                        args2.ZipCode1 = grdJohap.GetItemString(e.RowNumber, "zip_code1");
                        args2.ZipCode2 = e.ChangeValue.ToString();
                        BAS0110U00GrdJohapGubunResult result2 =
                        CloudService.Instance.Submit<BAS0110U00GrdJohapGubunResult, BAS0110U00GrdJohapGubunArgs>(args2);
                        if (result2.ExecutionStatus == ExecutionStatus.Success && result2.Result != null)
                        {
                            grdJohap.SetItemValue(e.RowNumber, "address1", result2.Result);
                        }
                    }
					break;
			}
		}

		#endregion

		#region 데이터 Dup Check

		private bool DupCheck(string aValue, string aJohapYMD)
		{
			if (grdJohap.DeletedRowTable != null)
			{
				foreach (DataRow dr in grdJohap.DeletedRowTable.Rows)
				{
					if (dr["johap"].ToString()     == aValue &&
                        dr["start_date"].ToString() == aJohapYMD)
					{
						return false;
					}
				}
			}

			// 현재 그리드에서 찾는다.
			for (int i=0; i<grdJohap.RowCount; i++)
			{
				if (i != grdJohap.CurrentRowNumber &&
					grdJohap.GetItemString(i, "johap")     == aValue &&
                    grdJohap.GetItemString(i, "start_date") == aJohapYMD)
				{
					return true;
				}
			}

            // DB에서 체크한다.
//            layDupCheck.QuerySQL = @" SELECT 'Y'
//                                             FROM BAS0110
//                                            WHERE HOSP_CODE   = :f_hosp_code
//                                              AND JOHAP_GUBUN = :f_gubun
//                                              AND START_DATE  = :f_start_date
//                                              AND JOHAP       = :f_johap";
//            layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            layDupCheck.SetBindVarValue("f_johap", aValue);
//            layDupCheck.SetBindVarValue("f_start_date", aJohapYMD);
//            layDupCheck.SetBindVarValue("f_johap_gubun", grdJohap.GetItemString(grdJohap.CurrentRowNumber, "johap_gubun"));
//            layDupCheck.QueryLayout();

            //tungtx
            BAS0110U00LayDupCheckArgs args = new BAS0110U00LayDupCheckArgs();
		    args.Gubun = grdJohap.GetItemString(grdJohap.CurrentRowNumber, "johap_gubun");
		    args.Johap = aValue;
		    args.StartDate = aJohapYMD;
		    BAS0110U00LayDupCheckResult result =
		        CloudService.Instance.Submit<BAS0110U00LayDupCheckResult, BAS0110U00LayDupCheckArgs>(args);

            //if (layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
			if (result.ExecutionStatus == ExecutionStatus.Success && result.LayChk == "Y")
			{
				return true;
			}
			return false;
		}

		#endregion


		#region InitScreen 

		private void InitScreen ()
		{
			dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
		}

		#endregion
	
		public override object Command(string command, CommonItemCollection commandParam)
		{
			// TODO:  BAS0110U00.Command 구현을 추가합니다.
			switch(command)
			{
				case "BAS0123Q00":
                    grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "zip_code1", commandParam["zip_code1"]);
                    grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "zip_code2", commandParam["zip_code2"]);
                    grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "address1", commandParam["address"]);
                    //this.grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "zip_code1", ((MultiLayout)commandParam["BAS0123"]).LayoutTable.Rows[0]["zip_code1"].ToString());
                    //grdJohap.SetFocusToItem(grdJohap.CurrentRowNumber, "zip_code2");
                    //grdJohap.SetEditorValue(((MultiLayout)commandParam["BAS0123"]).LayoutTable.Rows[0]["zip_code2"].ToString());
                    //grdJohap.SetFocusToItem(grdJohap.CurrentRowNumber, "address1");
					//this.grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "zip_code2", ((MultiLayout)commandParam["BAS0123"]).LayoutTable.Rows[0]["zip_code2"].ToString());
                    //this.grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "address", ((MultiLayout)commandParam["BAS0123"]).LayoutTable.Rows[0]["zip_name1"].ToString()
                    //                           + ((MultiLayout)commandParam["BAS0121"]).LayoutTable.Rows[0]["zip_name2"].ToString());
                    //this.grdJohap.SetItemValue(grdJohap.CurrentRowNumber, "address", ((MultiLayout)commandParam["BAS0123"]).LayoutTable.Rows[0]["address"].ToString());
					break;
			}
			return base.Command (command, commandParam);
		}

		#region Screen Load

		private void BAS0110U00_Load(object sender, EventArgs e)
		{
			InitScreen();
            //grdJohap.SavePerformer = new XSavePeformer(this);
            grdJohap.QueryLayout(true);
		}
		#endregion


        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private BAS0110U00 parent = null;

//            public XSavePeformer(BAS0110U00 parent)
//            {
//                this.parent = parent;
//            }

//            #region 입력값 체크
//            private int Validateion_Check(BindVarCollection BindVarList)
//            {
//                int value = 0;
//                string messg = "";
//                if (BindVarList["f_johap"].VarValue == "")
//                {
//                    messg += NetInfo.Language == LangMode.Ko ? "보험자번호" : Resource.BAS0110U00_TEXT8;
//                    value = 1;
//                }
//                if (BindVarList["f_start_date"].VarValue == "")
//                {
//                    if (value == 1)
//                    {
//                        messg += ",";
//                    }
//                    messg += NetInfo.Language == LangMode.Ko ? "적용일" : Resource.BAS0110U00_TEXT9;
//                    value = 1;
//                }
//                if (BindVarList["f_johap_name"].VarValue == "")
//                {
//                    if (value == 1)
//                    {
//                        messg += ",";
//                    }
//                    messg += NetInfo.Language == LangMode.Ko ? "보험자번호명" : Resource.BAS0110U00_TEXT10;
//                    value = 1;
//                }
//                if (BindVarList["f_johap_gubun"].VarValue == "")
//                {
//                    if (value == 1)
//                    {
//                        messg += ",";
//                    }
//                    messg += NetInfo.Language == LangMode.Ko ? "보험구분" : Resource.BAS0110U00_TEXT11;
//                    value = 1;
//                }
//                parent.mCheck = messg;
//                return value;
//            }
//            #endregion
//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                switch (callerId)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                if (Validateion_Check(item.BindVarList) != 0)
//                                {
//                                    return false;
//                                }
//                                cmdText = @"INSERT INTO BAS0110
//                                                  ( SYS_DATE            , SYS_ID            , UPD_DATE        , UPD_ID     , HOSP_CODE 
//                                                  , JOHAP               , START_DATE        , JOHAP_NAME
//                                                  , JOHAP_GUBUN         , ZIP_CODE1         , ZIP_CODE2
//                                                  , ADDRESS             , TEL               , JOHAP_DAEPYO
//                                                  , NEW_JOHAP           , LAW_NO            , DODOBUHYEUN_NO
//                                                  , BOHEOMJA_NO         , CD                , GIHO
//                                                  , REMARK              , CHECK_DIGIT_YN    )
//                                            VALUES
//                                                  ( SYSDATE             , :f_user_id        , SYSDATE        , :f_user_id  , :f_hosp_code 
//                                                  , :f_johap            , :f_start_date     , :f_johap_name
//                                                  , :f_johap_gubun      , :f_zip_code1      , :f_zip_code2
//                                                  , :f_address          , :f_tel            , NULL
//                                                  , NULL                , :f_law_no         , :f_dodobuhyeun_no
//                                                  , :f_boheomja_no      , :f_cd             , :f_giho
//                                                  , :f_remark           , :f_check_digit_yn    )";

//                                break;

//                            case DataRowState.Modified:
//                                if (Validateion_Check(item.BindVarList) != 0)
//                                {
//                                    return false;
//                                }
//                                cmdText = @"UPDATE BAS0110 A
//                                               SET A.UPD_DATE          = SYSDATE
//                                                 , A.UPD_ID            = :f_user_id
//                                                 , A.JOHAP_NAME        = :f_johap_name
//                                                 , A.ZIP_CODE1         = :f_zip_code1
//                                                 , A.ZIP_CODE2         = :f_zip_code2
//                                                 , A.ADDRESS           = :f_address
//                                                 , A.TEL               = :f_tel
//                                                 , A.GIHO              = :f_giho
//                                                 , A.REMARK            = :f_remark
//                                                 , A.CHECK_DIGIT_YN    = :f_check_digit_yn
//                                             WHERE A.HOSP_CODE         = :f_hosp_code 
//                                               AND A.JOHAP             = :f_johap
//                                               AND A.START_DATE        = :f_start_date
//                                               AND A.JOHAP_GUBUN       = :f_johap_gubun";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE FROM BAS0110 A
//                                             WHERE A.HOSP_CODE   = :f_hosp_code 
//                                               AND A.JOHAP       = :f_johap
//                                               AND A.START_DATE  = :f_start_date
//                                               AND A.JOHAP_GUBUN = :f_johap_gubun";

//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void dtpJukyongDate_DateValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != null) {
                grdJohap.QueryLayout(true);
            }
        }

        private void txtJohap_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdJohap.QueryLayout(true);
        }

        private void BAS0110U00_Closing(object sender, CancelEventArgs e)
        {
            if (boolSave == false)
            {
                e.Cancel = true;
            }
        }

	}
}

