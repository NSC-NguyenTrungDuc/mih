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
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.Framework;
using IHIS.SCHS.Properties;

#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201U10에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201U10 : IHIS.Framework.XScreen
	{
		private int mDragStartRowNumber;
		private int mDragX;
		private int mDragY;
		private bool mlsDragable;


		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdReserList;
		private IHIS.Framework.XEditGrid grdOrderList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XDataWindow dwReserPrint;
		private IHIS.Framework.MultiLayout layReserPrint;
        private IHIS.Framework.MultiLayout layReserComment;
        private IHIS.Framework.MultiLayout layReserInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private SingleLayout laySCH0201;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XComboItem xComboItem3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SCH0201U10()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //set ParamList
            this.grdOrderList.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date" });
            this.grdReserList.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date" });
            this.layReserInfo.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date" });

            //set ExecuteQuery
		    grdOrderList.ExecuteQuery = LoadDataGrdOrderList;
		    grdReserList.ExecuteQuery = LoadDataGrdReserList;
		}

	    #region CloudService

        private List<object[]> LoadDataGrdReserList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH0201U10GrdReserListArgs args = new SCH0201U10GrdReserListArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            SCH0201U10GrdReserListResult result = CloudService.Instance.Submit<SCH0201U10GrdReserListResult, SCH0201U10GrdReserListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.DateValue)
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



        private List<object[]> LoadDataGrdOrderList(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        SCH0201U10GrdOrderListArgs args = new SCH0201U10GrdOrderListArgs();
	        args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
	        args.ReserDate = bc["f_reser_date"] != null ? bc["f_reser_date"].VarValue : "";
	        SCH0201U10GrdOrderListResult result =
	            CloudService.Instance.Submit<SCH0201U10GrdOrderListResult, SCH0201U10GrdOrderListArgs>(
	                args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (SCH0201U10GrdOrderListInfo item in result.GrdOrderList)
	            {
	                object[] objects =
	                {
	                    item.Pkkey,
	                    item.Gubun,
	                    item.Gwa,
	                    item.GwaName,
	                    item.Doctor,
	                    item.DoctorName,
	                    item.HangmogCode,
	                    item.HangmogName,
	                    item.ReserTime,
	                    item.Seq,
	                    item.Sort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201U10));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.grdReserList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dwReserPrint = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layReserPrint = new IHIS.Framework.MultiLayout();
            this.layReserComment = new IHIS.Framework.MultiLayout();
            this.layReserInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.laySCH0201 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdOrderList);
            this.xPanel2.Controls.Add(this.grdReserList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOrderList
            // 
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.ApplyPaintEventToAllColumn = true;
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell8,
            this.xEditGridCell4,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdOrderList.ColPerLine = 6;
            this.grdOrderList.Cols = 7;
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(38);
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.grdOrderList.ToolTipActive = true;
            this.grdOrderList.UseDefaultTransaction = false;
            this.grdOrderList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOrderList_GiveFeedback);
            this.grdOrderList.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOrderList_DragEnter);
            this.grdOrderList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrderList_MouseDown);
            this.grdOrderList.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOrderList_DragDrop);
            this.grdOrderList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdOrderList_MouseMove);
            this.grdOrderList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderList_GridCellPainting);
            this.grdOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderList_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "pkkey";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell3.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell3.CellName = "gubun";
            this.xEditGridCell3.CellWidth = 153;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem2,
            this.xComboItem1,
            this.xComboItem3});
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "N";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "J";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell4.CellName = "gwa_name";
            this.xEditGridCell4.CellWidth = 125;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "doctor";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell10.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell10.CellName = "doctor_name";
            this.xEditGridCell10.CellWidth = 88;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell5.CellName = "hangmog_name";
            this.xEditGridCell5.CellWidth = 275;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell6.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell6.CellName = "reser_time";
            this.xEditGridCell6.CellWidth = 108;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell7.CellName = "seq";
            this.xEditGridCell7.CellWidth = 41;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdReserList
            // 
            resources.ApplyResources(this.grdReserList, "grdReserList");
            this.grdReserList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1});
            this.grdReserList.ColPerLine = 1;
            this.grdReserList.Cols = 2;
            this.grdReserList.ExecuteQuery = null;
            this.grdReserList.FixedCols = 1;
            this.grdReserList.FixedRows = 1;
            this.grdReserList.HeaderHeights.Add(21);
            this.grdReserList.Name = "grdReserList";
            this.grdReserList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdReserList.ParamList")));
            this.grdReserList.RowHeaderVisible = true;
            this.grdReserList.Rows = 2;
            this.grdReserList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdReserList_RowFocusChanged);
            this.grdReserList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdReserList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "reser_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 115;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.dwReserPrint);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // dwReserPrint
            // 
            resources.ApplyResources(this.dwReserPrint, "dwReserPrint");
            this.dwReserPrint.DataWindowObject = "dw_reser_list_01";
            this.dwReserPrint.LibraryList = "SCHS\\schs.sch0201u10.pbd";
            this.dwReserPrint.Name = "dwReserPrint";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, global::IHIS.SCHS.Properties.Resources.TEXT5, -1, global::IHIS.SCHS.Properties.Resources.TEXT5),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.SCHS.Properties.Resources.TEXT10, -1, global::IHIS.SCHS.Properties.Resources.TEXT10)});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layReserPrint
            // 
            this.layReserPrint.ExecuteQuery = null;
            this.layReserPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserPrint.ParamList")));
            // 
            // layReserComment
            // 
            this.layReserComment.ExecuteQuery = null;
            this.layReserComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserComment.ParamList")));
            // 
            // layReserInfo
            // 
            this.layReserInfo.ExecuteQuery = null;
            this.layReserInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.layReserInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserInfo.ParamList")));
            this.layReserInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserInfo_QueryStarting);
            this.layReserInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserInfo_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
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
            this.multiLayoutItem5.DataName = "reser_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "hangmog_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "reser_time";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "move_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "reser_day";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "age";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "birth";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "suname2";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "jundal_part";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "reser_move_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "hangmog_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jundal_table";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "hope_date";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // laySCH0201
            // 
            this.laySCH0201.ExecuteQuery = null;
            this.laySCH0201.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.laySCH0201.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySCH0201.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "jundal_part";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "reser_date";
            // 
            // SCH0201U10
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "SCH0201U10";
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserInfo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            //this.grdOrderList.SavePerformer = new XSavePerformer(this);

			if (this.OpenParam != null ) 
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				return;
			}
			else
			{
				// 이전 스크린의 등록번호를 가져온다
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

				if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
				{
					// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
					patientInfo = XScreen.GetOtherScreenBunHo(this, true);
				}

				if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
					return;
				}
				else
				{
					//paBox.SetPatientID("000400017");
				}
			}
		}


		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			grdOrderList.Reset();
            this.grdReserList.QueryLayout(false);
		}

		private void grdReserList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            this.grdOrderList.QueryLayout(false);
		}

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch( e.Func )
			{
				case FunctionType.Update:
					e.IsBaseCall = false;

                    //try
                    //{
                    //    PreSave();
                    //    Service.BeginTransaction();

                    //    if (!this.grdOrderList.SaveLayout())
                    //        throw new Exception();

                    //    Service.CommitTransaction();
                    //    XMessageBox.Show("保存しました。", "保存", MessageBoxIcon.Information);
                    //}
                    //catch
                    //{
                    //    Service.RollbackTransaction();
                    //    XMessageBox.Show("保存に失敗しました。\r\n" + Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                    //}
					break;
				case FunctionType.Print:
					
					ReserPrint();
					break;
				default:
					break;
			}
		}

		private void ReserPrint()
		{
            //layReserInfo.Reset();
            //dwReserPrint.Reset();

            //this.layReserInfo.SetBindVarValue("f_reser_date", grdReserList.GetItemString(grdReserList.CurrentRowNumber, "reser_date"));

            //if (this.layReserInfo.QueryLayout(true))
            //{
            //    if (layReserInfo.RowCount > 0)
            //    {
            //        dwReserPrint.FillData(layReserInfo.LayoutTable);
            //        dwReserPrint.Print();
            //    }
            //}
            if (this.paBox.BunHo == "")
            {
                string msg = (NetInfo.Language == LangMode.Ko ? Resources.TEXT1
                    : Resources.TEXT2);
                XMessageBox.Show(msg, Resources.TEXT3, MessageBoxButtons.OK);
                return;
            }
            
            ReserPrint("%", "Y"); //"Y" 화면 열고 프린트 하고 바로 닫음
		}
        #region 예약증 출력
        private void ReserPrint(string gwa, string auto_close)
        {
            //검사(진료)예약표 출력
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("auto_close", auto_close);
            openParams.Add("total_query_yn", "N");
            openParams.Add("bunho", this.paBox.BunHo.ToString());
            //openParams.Add("reser_date", this.xdtReserDate.GetDataValue().ToString());
            openParams.Add("reser_date", grdReserList.GetItemString(grdReserList.CurrentRowNumber, "reser_date"));
            openParams.Add("gwa", gwa);

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseSizable, openParams);

        }
        #endregion
		private void grdOrderList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNumber = -1;

			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowNumber = this.grdOrderList.GetHitRowNumber(e.Y);
				if(rowNumber < 0) return;

//				string draginfo = "[" + this.grdOrderList.GetItemString(rowNumber, "hangmog_name") + "]";
//				DragHelper.CreateDragCursor(this.grdOrderList,draginfo,this.Font);
//				this.grdOrderList.DoDragDrop(this.grdOrderList.GetItemString(rowNumber, "pkkey"), DragDropEffects.Move);

				this.mlsDragable = true;
				this.mDragX = e.X;
				this.mDragY = e.Y;
			}
		}

		private void grdOrderList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void grdOrderList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;

			if((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}

		private void grdOrderList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
            XEditGrid grd = sender as XEditGrid;
			
			Point clientPoint = grd.PointToClient(new Point(e.X, e.Y));

			if (mDragStartRowNumber < 0) return;

			int rowNumber = -1;

			rowNumber = grd.GetHitRowNumber(clientPoint.Y);

			if (rowNumber < 0 || rowNumber == this.mDragStartRowNumber) return;

            if (!CheckTimeValidation(mDragStartRowNumber, rowNumber))
            {
                XMessageBox.Show(Resources.TEXT4, Resources.TEXT5, MessageBoxIcon.Warning);
                return;
            }

			GridDataRowChange(mDragStartRowNumber, rowNumber);
			//
            //try
            //{
            //    PreSave();

            //    Service.BeginTransaction();
            //    if (!this.grdOrderList.SaveLayout())
            //        throw new Exception();

            //    Service.CommitTransaction();
            //    XMessageBox.Show(Resources.TEXT6, Resources.TEXT7, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    Service.RollbackTransaction();
            //    XMessageBox.Show(Resources.TEXT8 + Service.ErrFullMsg, Resources.TEXT9, MessageBoxIcon.Error);
            //}
            this.grdOrderList.QueryLayout(false);

			this.mDragStartRowNumber = -1;			
		}

        private bool CheckTimeValidation(int startRowNum, int currentRowNum)
        {
            MultiLayout copyLay = this.grdOrderList.CopyToLayout();
           // MultiLayout tLay = this.grdOrderList.CopyToLayout();
           // tLay.Reset();

            string tempTime1 = copyLay.GetItemString(startRowNum, "reser_time").Replace(":", "");
            string tempTime2 = "";

            //for (int i = 0; i < copyLay.RowCount; i++)
            //{
            //    if (copyLay.GetItemString(i, "reser_time") == ":") continue;
            //    if (i == startRowNum) continue;

            //    if (i == currentRowNum)
            //    {
            //        if (startRowNum < currentRowNum)
            //        {
            //            tLay.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
            //        }

            //        tLay.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[startRowNum]);

            //        if (startRowNum > currentRowNum)
            //        {
            //            tLay.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
            //        }
            //    }
            //    else
            //    {
            //        tLay.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
            //    }
            //}

            if (tempTime1 != "")
            {
                for (int i = 0; i < copyLay.RowCount; i++)
                {
                    if (copyLay.GetItemString(i, "reser_time") == "") continue;
                    if (i == startRowNum) continue;

                    tempTime2 = copyLay.GetItemString(i, "reser_time").Replace(":", "");

                    if (i < currentRowNum)
                    {
                        if (Convert.ToInt32(tempTime1) < Convert.ToInt32(tempTime2))
                            return false;
                    }
                    else
                    {
                        if (startRowNum < currentRowNum)
                        {
                            if (Convert.ToInt32(tempTime1) < Convert.ToInt32(tempTime2))
                                return false;                        
                        }
                        else
                        {
                            if (Convert.ToInt32(tempTime1) > Convert.ToInt32(tempTime2))
                                return false;
                        }
                    }
                }
            }
                return true;
        }

		private void GridDataRowChange(int aFromRowNumber, int aToRowNumber)
		{
			MultiLayout copyLay = this.grdOrderList.CopyToLayout();

			this.grdOrderList.Reset();

			for (int i=0; i<copyLay.RowCount; i++)
			{
				if (i == aFromRowNumber) continue; 

				if (i == aToRowNumber) 
				{
                    if (aFromRowNumber < aToRowNumber)
                        this.grdOrderList.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);

					this.grdOrderList.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[aFromRowNumber]);

                    if (aFromRowNumber > aToRowNumber)
                        this.grdOrderList.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
				}
                else
                {
                    this.grdOrderList.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
                }
			}

			this.grdOrderList.DisplayData();
			this.grdOrderList.SelectRow(aToRowNumber);
		}

		private void grdOrderList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid ;

			if (e.Button == MouseButtons.Left &&
				mlsDragable && (Math.Abs(e.X - mDragX) > 3 || Math.Abs(e.Y - mDragY) > 3))
			{
				mlsDragable = false;

				int rowNumber = grd.GetHitRowNumber(mDragY);

				string dragInfo = "[" + grd.GetItemString(rowNumber, "hangmog_name") + "]";
				mDragStartRowNumber = grd.CurrentRowNumber;
				DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
				grd.DoDragDrop(rowNumber, DragDropEffects.Move);
			}
		
		}

        private void grdReserList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdReserList.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrderList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdOrderList.SetBindVarValue("f_reser_date", this.grdReserList.GetItemString(this.grdReserList.CurrentRowNumber, "reser_date"));
        }

        //사용안됨.
        private void layReserInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //object t_reser_move_name = null;

//            string cmdText = @"SELECT FN_BAS_LOAD_GWA_POSITION(A.GWA,SYSDATE) RESER_MOVE_NAME
//                                  FROM OUT1001 A
//                                 WHERE A.HOSP_CODE   = :f_hosp_code 
//                                   AND A.BUNHO       = :f_bunho
//                                   AND A.NAEWON_DATE = :f_reser_date
//                                   AND A.GWA         = :f_gwa
//                                   AND A.RESER_YN    = 'Y'
//                                   AND ROWNUM        = 1";

            BindVarCollection bc = new BindVarCollection();

            for (int i = 0; i < this.layReserInfo.RowCount; i++)
            {
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_bunho", this.layReserInfo.GetItemString(i, "bunho"));
                bc.Add("f_reser_date", this.layReserInfo.GetItemString(i, "reser_date"));
                bc.Add("f_gwa", this.layReserInfo.GetItemString(i, "gwa"));

                //t_reser_move_name = Service.ExecuteScalar(cmdText, bc);
                SCH0201U10LayReserInfoQueryEndArgs args = new SCH0201U10LayReserInfoQueryEndArgs();
                args.Bunho = this.layReserInfo.GetItemString(i, "bunho");
                args.ReserDate = this.layReserInfo.GetItemString(i, "reser_date");
                args.Gwa = this.layReserInfo.GetItemString(i, "gwa");

                SCH0201U10LayReserInfoQueryEndResult result =
                    CloudService.Instance
                        .Submit<SCH0201U10LayReserInfoQueryEndResult, SCH0201U10LayReserInfoQueryEndArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    this.layReserInfo.SetItemValue(i, "reser_move_name", result.ReserMoveName);
                    
                }
            }

        }

        private void layReserInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserInfo.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void PreSave()
        { 
            for(int i = 0; i<grdOrderList.RowCount; i++)
            {
                grdOrderList.SetItemValue(i, "seq", i + 1);
            }
        }

        #region XSavePerformer

//        private class XSavePerformer : ISavePerformer
//        {
//            private SCH0201U10 parent;

//            public XSavePerformer(SCH0201U10 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                /* 검체검사를 제외한 순번 지정 */
//                cmdText = @"UPDATE SCH0201
//                               SET UPD_ID     = :q_user_id
//                                 , UPD_DATE   = SYSDATE
//                                 , SEQ        = :f_seq
//                             WHERE HOSP_CODE  = :f_hosp_code
//                               AND PKSCH0201  = TO_NUMBER(:f_pkkey)
//                               AND :f_gubun   = 'N'
//                               AND JUNDAL_TABLE <> 'CPL'";

//                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                {
//                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
//                        return false;
//                }

//                /* 진료예약 순번 지정 */
//                cmdText = @"UPDATE OUT1001
//                               SET UPD_ID      = :q_user_id
//                                 , UPD_DATE    = SYSDATE
//                                 , JUBSU_NO    = :f_seq
//                             WHERE HOSP_CODE   = :f_hosp_code
//                               AND RESER_YN    = 'Y'
//                               AND PKOUT1001    = :f_pkkey
//                               AND :f_gubun     = 'Y'";

//                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                {
//                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
//                        return false;
//                }

//                /* 검체검사 순번 지정 */
//                parent.laySCH0201.SetBindVarValue("f_hosp_code", item.BindVarList["f_hosp_code"].VarValue);
//                parent.laySCH0201.SetBindVarValue("f_pkkey", item.BindVarList["f_pkkey"].VarValue);

//                parent.laySCH0201.Reset();
//                parent.laySCH0201.QueryLayout();

//                item.BindVarList.Add("o_bunho", parent.laySCH0201.GetItemValue("bunho").ToString());
//                item.BindVarList.Add("o_reser_date", parent.laySCH0201.GetItemValue("reser_date").ToString());
//                item.BindVarList.Add("o_jundal_part", parent.laySCH0201.GetItemValue("jundal_part").ToString());

//                cmdText = @"UPDATE SCH0201
//                               SET UPD_ID      = :q_user_id
//                                 , UPD_DATE    = SYSDATE
//                                 , SEQ         = :f_seq
//                             WHERE HOSP_CODE   = :f_hosp_code
//                               AND BUNHO        = :o_bunho
//                               AND RESER_DATE   = :o_reser_date
//                               AND JUNDAL_TABLE = 'CPL'
//                               AND JUNDAL_PART  = :o_jundal_part
//                               AND :f_gubun     = 'N'";

//                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                {
//                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
//                        return false;
//                }                       


//                return true;
//            }
//        }
        #endregion 

        #region Add Multilanguage
        private void ApplyMultilanguageDW()
        {
            //dwOrderList
            dwReserPrint.Refresh();
            dwReserPrint.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_001));
            dwReserPrint.Modify(string.Format("t_17.text = '{0}'", Properties.Resources.DW_TXT_002));
            dwReserPrint.Modify(string.Format("t_18.text = '{0}'", Properties.Resources.DW_TXT_003));
            dwReserPrint.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_004));
            dwReserPrint.Modify(string.Format("t_19.text = '{0}'", Properties.Resources.DW_TXT_005));
            dwReserPrint.Modify(string.Format("t_16.text = '{0}'", Properties.Resources.DW_TXT_006));
            dwReserPrint.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_007));
            dwReserPrint.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_008));
            dwReserPrint.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_009));
            dwReserPrint.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_010));
            dwReserPrint.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_011));
            dwReserPrint.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_012));
            dwReserPrint.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_013));
            dwReserPrint.Modify(string.Format("t_14.text = '{0}'", Properties.Resources.DW_TXT_014));
            dwReserPrint.Modify(string.Format("t_22.text = '{0}'", Properties.Resources.DW_TXT_015));
            dwReserPrint.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_016));
            dwReserPrint.Modify(string.Format("t_23.text = '{0}'", Properties.Resources.DW_TXT_017));
            dwReserPrint.Modify(string.Format("t_20.text = '{0}'", Properties.Resources.DW_TXT_018));
            dwReserPrint.Modify(string.Format("t_21.text = '{0}'", Properties.Resources.DW_TXT_019));
            dwReserPrint.Modify(string.Format("t_24.text = '{0}'", Properties.Resources.DW_TXT_020));
            dwReserPrint.Modify(string.Format("t_25.text = '{0}'", Properties.Resources.DW_TXT_021));
            dwReserPrint.Modify(string.Format("t_26.text = '{0}'", Properties.Resources.DW_TXT_022));
            dwReserPrint.Modify(string.Format("t_27.text = '{0}'", Properties.Resources.DW_TXT_023));
            dwReserPrint.Modify(string.Format("t_30.text = '{0}'", Properties.Resources.DW_TXT_024));
            dwReserPrint.Modify(string.Format("t_31.text = '{0}'", Properties.Resources.DW_TXT_025));
            dwReserPrint.Modify(string.Format("t_28.text = '{0}'", Properties.Resources.DW_TXT_026));
            dwReserPrint.Modify(string.Format("t_29.text = '{0}'", Properties.Resources.DW_TXT_027));
        }
        #endregion
        private void grdOrderList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //switch(e.ColName)
            //{
            //    case "gubun":
            //    case "hangmog_name":
            //    case "seq":
                    if (e.DataRow["gubun"].ToString() == "J")
                    {
                        e.ForeColor = Color.Gray;
                    }
                //break;
            //}
        }



    }
}

