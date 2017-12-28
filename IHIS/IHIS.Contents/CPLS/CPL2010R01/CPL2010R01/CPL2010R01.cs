#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010R01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010R01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
//		private IHIS.Framework.XDataWindow dwSpecimenList;
		private IHIS.Framework.MultiLayout layReserDate;
//		private IHIS.Framework.XDataWindow dwReserDate;
        private IHIS.Framework.MultiLayout laySpecimenList;
		private IHIS.Framework.XLabel xLabel7;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XButtonList btnList;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private XDictComboBox cbxHoDong;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private const string CACHE_CPLS_COMBO_HODONG = "Cpls.cbxHoDong";

		public CPL2010R01()
		{
			try
			{
				// 이 호출은 Windows Form 디자이너에 필요합니다.
				InitializeComponent();

                this.layReserDate.ParamList = new List<string>(new String[] { "f_hosp_code", "f_ho_dong", "f_from_date", "f_to_date" });
                this.laySpecimenList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_ho_dong", "f_reser_date" });

			    this.layReserDate.ExecuteQuery = LoadDataLayReserDate;
			    this.laySpecimenList.ExecuteQuery = LoadDataLaySpecimenList;
			    this.cbxHoDong.ExecuteQuery = LoadDataCbxHoDong;

			    this.cbxHoDong.SetDictDDLB();
			}
			catch ( Exception ex )
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show("StackTrace --> " + ex.StackTrace);
				//XMessageBox.Show("StackTrace --> " + ex.Source);
			}
		}

	    private IList<object[]> LoadDataCbxHoDong(BindVarCollection varlist)
	    {
            List<object[]> dataList = new List<object[]>();
            ComboHoDongArgs args = new ComboHoDongArgs();
            //ComboResult result = CacheService.Instance.Get<ComboHoDongArgs, ComboResult>(CACHE_CPLS_COMBO_HODONG, args, delegate (ComboResult result1)
            //{
            //    return result1.ExecutionStatus == ExecutionStatus.Success && result1.ComboItem != null &&
            //    result1.ComboItem.Count > 0;
            //});
            ComboResult result = CacheService.Instance.Get<ComboHoDongArgs, ComboResult>(args, delegate(ComboResult result1)
            {
                return result1.ExecutionStatus == ExecutionStatus.Success && result1.ComboItem != null &&
                result1.ComboItem.Count > 0;
            });
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<ComboListItemInfo> cboList = result.ComboItem;
	            if (cboList != null && cboList.Count > 0)
	            {
	                foreach (ComboListItemInfo info in cboList)
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

	    /// <summary>
        /// get data for laySpecimenList
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLaySpecimenList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010R01LaySpecimenListArgs args = new CPL2010R01LaySpecimenListArgs();
            args.HoDong = bc["f_ho_dong"] != null ? bc["f_ho_dong"].VarValue : "";
            args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
            CPL2010R01LaySpecimenListResult result = CloudService.Instance.Submit<CPL2010R01LaySpecimenListResult, CPL2010R01LaySpecimenListArgs>(args);
            if (result != null)
            {
                foreach (CPL2010R01LaySpecimenListItemInfo item in result.LaySpecimenList)
                {
                    object[] objects = 
				    { 
					    item.SpecimenSer, 
					    item.Bunho, 
					    item.Suname, 
					    item.DoctorName, 
					    item.SpecimenNo, 
					    item.SpecimenName, 
					    item.TubeName, 
					    item.TubeCount, 
					    item.HoDongName, 
					    item.ReserDate, 
					    item.ContKey
				    };
                    res.Add(objects);
                }
            }
            return res;
        } 



        /// <summary>
        /// Get data for layReserDate
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayReserDate(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010R01LayReserDateArgs args = new CPL2010R01LayReserDateArgs();
            args.HoDong = bc["f_ho_dong"] != null ? bc["f_ho_dong"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            CPL2010R01LayReserDateResult result = CloudService.Instance.Submit<CPL2010R01LayReserDateResult, CPL2010R01LayReserDateArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.LayList)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010R01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxHoDong = new IHIS.Framework.XDictComboBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
   //         this.dwReserDate = new IHIS.Framework.XDataWindow();
            this.xPanel3 = new IHIS.Framework.XPanel();
   //         this.dwSpecimenList = new IHIS.Framework.XDataWindow();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layReserDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.laySpecimenList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimenList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cbxHoDong);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.xLabel7);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // cbxHoDong
            // 
            this.cbxHoDong.ExecuteQuery = null;
            resources.ApplyResources(this.cbxHoDong, "cbxHoDong");
            this.cbxHoDong.Name = "cbxHoDong";
            this.cbxHoDong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxHoDong.ParamList")));
            this.cbxHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxHoDong.SelectedIndexChanged += new System.EventHandler(this.cbxHoDong_SelectedIndexChanged);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.condition_DataValidating);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.condition_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xPanel2
            // 
   //         this.xPanel2.Controls.Add(this.dwReserDate);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // dwReserDate
            // 
            //this.dwReserDate.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dwReserDate.DataWindowObject = "d_reser_date";
            //resources.ApplyResources(this.dwReserDate, "dwReserDate");
            //this.dwReserDate.LibraryList = "CPLS\\cpls.cpl2010r01.pbd";
            //this.dwReserDate.Name = "dwReserDate";
            //this.dwReserDate.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserDate_RowFocusChanged);
            // 
            // xPanel3
            // 
  //          this.xPanel3.Controls.Add(this.dwSpecimenList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // dwSpecimenList
            // 
            //this.dwSpecimenList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dwSpecimenList.DataWindowObject = "d_inp_specimen_list";
            //resources.ApplyResources(this.dwSpecimenList, "dwSpecimenList");
            //this.dwSpecimenList.LibraryList = "CPLS\\cpls.cpl2010r01.pbd";
            //this.dwSpecimenList.Name = "dwSpecimenList";
            //this.dwSpecimenList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            //this.dwSpecimenList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwSpecimenList_RowFocusChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layReserDate
            // 
            this.layReserDate.ExecuteQuery = null;
            this.layReserDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem2});
            this.layReserDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserDate.ParamList")));
            this.layReserDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserDate_QueryStarting);
            this.layReserDate.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserDate_QueryEnd);
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "reser_date";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // laySpecimenList
            // 
            this.laySpecimenList.ExecuteQuery = null;
            this.laySpecimenList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.laySpecimenList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenList.ParamList")));
            this.laySpecimenList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySpecimenList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "specimen_ser";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "doctor_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "specimen_no";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "specimen_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "tube_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "tube_count";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ho_dong_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "reser_date";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "hodong_name";
            // 
            // CPL2010R01
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel4);
            this.Name = "CPL2010R01";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL2010R01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySpecimenList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            //switch (e.Func)
            //{
            //    case FunctionType.Query:
            //        e.IsBaseCall = false;
            //        this.layReserDate.QueryLayout(true);
            //        break;
            //    case FunctionType.Print:
            //        e.IsBaseCall = false;
            //        if ( this.dwSpecimenList.RowCount > 0 )
            //        {
            //            ApplyMultiLangDwSpecimenList();
            //            this.dwSpecimenList.Reset();
            //            this.dwSpecimenList.FillData(this.laySpecimenList.LayoutTable);
            //            this.dwSpecimenList.Print();
            //        }
            //        break;
            //    default:
            //        break;				
            //}
		}

	    private void ApplyMultiLangDwSpecimenList()
	    {
            //dwSpecimenList
            //dwSpecimenList.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dwSpecimenList.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dwSpecimenList.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dwSpecimenList.Modify(string.Format("cpl0302_cpl_result_t.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dwSpecimenList.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dwSpecimenList.Modify(string.Format("before_result_t.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dwSpecimenList.Modify(string.Format("panic_yn_t.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dwSpecimenList.Modify(string.Format("cpl3020_delta_yn_t.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dwSpecimenList.Modify(string.Format("cpl0302_standard_yn_t.text = '{0}'", Properties.Resources.DW_TXT_009));
	    }

	    #region dw
		private string dwGetString(XDataWindow dw, int row, string colNm)
		{
			if(!dw.IsItemNull(row,colNm))
				return dw.GetItemString(row, colNm);
			return " ";
		}
		
		#endregion

		private void dwReserDate_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
            //string reser_date;
			
            //if ( this.dwReserDate.RowCount == 0 )
            //{
            //    ApplyMultiLangDwSpecimenList();
            //    dwSpecimenList.Reset();
            //    return;
            //}
			
            //reser_date = dwReserDate.GetItemString(dwReserDate.CurrentRow, "reser_date").ToString().Replace("-","/");

            //this.laySpecimenList.SetBindVarValue("f_reser_date", reser_date);
			
            //if(this.laySpecimenList.QueryLayout(true))
            //{
            //    ApplyMultiLangDwSpecimenList();
            //    dwSpecimenList.Reset();
            //    dwSpecimenList.FillData(laySpecimenList.LayoutTable);	
            //    dwSpecimenList.Refresh();
            //}
            //else
            //{
            //    MessageBox.Show(Service.ErrMsg);
            //}

            //dwReserDate.Refresh();
		}
		
		#region 오픈스크린
		private void CPL2010R01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			this.dtpFromDate.SetDataValue(System.DateTime.Today);
			this.dtpToDate.SetDataValue(System.DateTime.Today.AddDays(1));

			if ( !TypeCheck.IsNull(OpenParam))
			{
                if (this.OpenParam.Contains("ho_dong"))
                {
                    //fbxHoDong.SetEditValue(this.OpenParam["ho_dong"].ToString());
                    //fbxHoDong.AcceptData();

                    this.cbxHoDong.SetDataValue(this.OpenParam["ho_dong"].ToString());
                    this.cbxHoDong.AcceptData();
                }

                //if (this.OpenParam.Contains("from_date"))
                //{
                //    dtpFromDate.SetDataValue(OpenParam["from_date"].ToString());
                //    dtpFromDate.AcceptData();
                //}

                //if (this.OpenParam.Contains("to_date"))
                //{
                //    dtpToDate.SetDataValue(OpenParam["to_date"].ToString());
                //    dtpToDate.AcceptData();
                //}
				btnList.PerformClick(FunctionType.Query);
			}
		}
		#endregion

		private void dwSpecimenList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
	//		this.dwSpecimenList.Refresh();
		}


		#region 조건 벨리데이팅
		private void condition_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(!this.layReserDate.QueryLayout(true))
			{
				MessageBox.Show(Service.ErrMsg);
			}
		}
		#endregion

        private void layReserDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserDate.SetBindVarValue("f_ho_dong", this.cbxHoDong.GetDataValue());
            this.layReserDate.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.layReserDate.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
        }

        private void laySpecimenList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.laySpecimenList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySpecimenList.SetBindVarValue("f_ho_dong", this.cbxHoDong.GetDataValue());
        }

        private void layReserDate_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //ApplyMultiLangDwReserDate();
            //dwReserDate.Reset();
            //dwReserDate.FillData(layReserDate.LayoutTable);
            //dwReserDate.Refresh();

        }

	    private void ApplyMultiLangDwReserDate()
	    {
            //dwReserDate
  //          dwReserDate.Modify(string.Format("panm_t.text = '{0}'", Properties.Resources.DW_TXT_010));
	    }

	    private void cbxHoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.layReserDate.QueryLayout(true);
        }
	}
}

