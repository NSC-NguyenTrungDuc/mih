#region 사용 NameSpace 지정
using System;
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
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using System.Collections.Generic;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0203U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0203U00 : IHIS.Framework.XScreen
	{
		private bool isgrdP1Save = false;
        //private bool isgrdP2Save = false;

        //private bool isP1Saved = false;
        //private bool isP2Saved = false;

        private string mMemb = "";
		//Message처리
		string mbxMsg = "", mbxCap = "";

        //hospital code
        string mHospCode = EnvironInfo.HospCode;

        private System.Windows.Forms.TreeView tvwSlip_Info;
        private IHIS.Framework.XButtonList xButtonList1;
        //private IHIS.Framework.XEditGrid grdOCS0203_P2;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel lblSelectAll_P1;
		private IHIS.Framework.XLabel lblSelectAll_P2;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XComboBox cboMemb;
		private IHIS.Framework.XLabel xLabel5;
        private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XLabel lblGwa;
		private IHIS.Framework.XComboBox cboGwa;
		private IHIS.Framework.MultiLayout laySlip_Info;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private XEditGrid grdOCS0203_P1;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell9;
        private MultiLayout layOCS0212;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private XHospBox xHospBox1;
	    private UpdateResult updateResult = new UpdateResult();
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0203U00()
		{
            mHospCode = UserInfo.HospCode;
            if (String.IsNullOrEmpty(mHospCode))
            {
                mHospCode = EnvironInfo.HospCode;
            }

			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //SaveLayoutList.Add(grdOCS0203_P1);
			//SaveLayoutList.Add(grdOCS0203_P2);

            //grdOCS0203_P1.SavePerformer = new XSavePerformer(this);
			//grdOCS0203_P2.SavePerformer = grdOCS0203_P1.SavePerformer;

            //set ParamList
            grdOCS0203_P1.ParamList = new List<String>(new String[] { "f_memb", "f_slip_code", "f_hosp_code" });
            layOCS0212.ParamList = new List<String>(new String[] { "f_memb", "f_slip_code", "f_hosp_code" });
            laySlip_Info.ParamList = new List<String>(new String[] { "f_memb", "f_hosp_code" });

            //set ExecuteQuery
            grdOCS0203_P1.ExecuteQuery = LoadDataGrdOCS0203;
            layOCS0212.ExecuteQuery = LoadDataLayOCS0212;
            laySlip_Info.ExecuteQuery = LoadDataLaySlipInfo;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0203U00));
            this.tvwSlip_Info = new System.Windows.Forms.TreeView();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xHospBox1 = new IHIS.Framework.XHospBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0203_P1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.lblSelectAll_P1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.lblSelectAll_P2 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.cboMemb = new IHIS.Framework.XComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.laySlip_Info = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS0212 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0203_P1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0212)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            // 
            // tvwSlip_Info
            // 
            this.tvwSlip_Info.AccessibleDescription = null;
            this.tvwSlip_Info.AccessibleName = null;
            this.tvwSlip_Info.AllowDrop = true;
            resources.ApplyResources(this.tvwSlip_Info, "tvwSlip_Info");
            this.tvwSlip_Info.BackColor = System.Drawing.SystemColors.Window;
            this.tvwSlip_Info.BackgroundImage = null;
            this.tvwSlip_Info.Font = null;
            this.tvwSlip_Info.HideSelection = false;
            this.tvwSlip_Info.HotTracking = true;
            this.tvwSlip_Info.ImageList = this.ImageList;
            this.tvwSlip_Info.Name = "tvwSlip_Info";
            this.tvwSlip_Info.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.tvwSlip_Info_GiveFeedback);
            this.tvwSlip_Info.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwSlip_Info_DragDrop);
            this.tvwSlip_Info.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSlip_Info_AfterSelect);
            this.tvwSlip_Info.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvwSlip_Info_DragEnter);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "memb";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "slip_code";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "position";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "seq";
            this.xEditGridCell14.CellWidth = 33;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell14.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "display_yn";
            this.xEditGridCell13.CellWidth = 34;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell13.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "often_use";
            this.xEditGridCell20.CellWidth = 33;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell20.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.CellName = "hangmog_code";
            this.xEditGridCell15.CellWidth = 106;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell15.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellName = "hangmog_name";
            this.xEditGridCell16.CellWidth = 202;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell16.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "display_yn_inp";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "bulyong_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "new_flag";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xHospBox1);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xHospBox1
            // 
            this.xHospBox1.AccessibleDescription = null;
            this.xHospBox1.AccessibleName = null;
            resources.ApplyResources(this.xHospBox1, "xHospBox1");
            this.xHospBox1.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox1.BackgroundImage = null;
            this.xHospBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox1.HospCode = "";
            this.xHospBox1.Name = "xHospBox1";
            this.xHospBox1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox1_DataValidating);
            this.xHospBox1.FindClick += new System.EventHandler(this.xHospBox1_FindClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdOCS0203_P1);
            this.xPanel2.Controls.Add(this.lblSelectAll_P1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOCS0203_P1
            // 
            resources.ApplyResources(this.grdOCS0203_P1, "grdOCS0203_P1");
            this.grdOCS0203_P1.ApplyPaintEventToAllColumn = true;
            this.grdOCS0203_P1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell5,
            this.xEditGridCell19,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell21,
            this.xEditGridCell9});
            this.grdOCS0203_P1.ColPerLine = 3;
            this.grdOCS0203_P1.Cols = 3;
            this.grdOCS0203_P1.ExecuteQuery = null;
            this.grdOCS0203_P1.FixedRows = 1;
            this.grdOCS0203_P1.HeaderHeights.Add(21);
            this.grdOCS0203_P1.Name = "grdOCS0203_P1";
            this.grdOCS0203_P1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0203_P1.ParamList")));
            this.grdOCS0203_P1.QuerySQL = resources.GetString("grdOCS0203_P1.QuerySQL");
            this.grdOCS0203_P1.Rows = 2;
            this.grdOCS0203_P1.RowStateCheckOnPaint = false;
            this.grdOCS0203_P1.ToolTipActive = true;
            this.grdOCS0203_P1.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0203_P1_DragEnter);
            this.grdOCS0203_P1.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0203_P1.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0203_P1_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "memb";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "slip_code";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.CellName = "seq";
            this.xEditGridCell5.CellWidth = 36;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "often_use";
            this.xEditGridCell19.CellWidth = 54;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell19.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.CellName = "hangmog_code";
            this.xEditGridCell6.CellWidth = 92;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.CellName = "hangmog_name";
            this.xEditGridCell7.CellWidth = 226;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "bulyong_yn";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "new_flag";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // lblSelectAll_P1
            // 
            this.lblSelectAll_P1.AccessibleDescription = null;
            this.lblSelectAll_P1.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll_P1, "lblSelectAll_P1");
            this.lblSelectAll_P1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll_P1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll_P1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll_P1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll_P1.ImageList = this.ImageList;
            this.lblSelectAll_P1.Name = "lblSelectAll_P1";
            this.lblSelectAll_P1.Tag = "1";
            this.lblSelectAll_P1.Click += new System.EventHandler(this.lblSelectAll_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.lblSelectAll_P2);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // lblSelectAll_P2
            // 
            this.lblSelectAll_P2.AccessibleDescription = null;
            this.lblSelectAll_P2.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll_P2, "lblSelectAll_P2");
            this.lblSelectAll_P2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll_P2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll_P2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll_P2.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll_P2.ImageList = this.ImageList;
            this.lblSelectAll_P2.Name = "lblSelectAll_P2";
            this.lblSelectAll_P2.Tag = "2";
            this.lblSelectAll_P2.Click += new System.EventHandler(this.lblSelectAll_Click);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.lblGwa);
            this.xPanel4.Controls.Add(this.cboGwa);
            this.xPanel4.Controls.Add(this.cboMemb);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // lblGwa
            // 
            this.lblGwa.AccessibleDescription = null;
            this.lblGwa.AccessibleName = null;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            this.lblGwa.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblGwa.Image = null;
            this.lblGwa.Name = "lblGwa";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.DropDownWidth = 100;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // cboMemb
            // 
            this.cboMemb.AccessibleDescription = null;
            this.cboMemb.AccessibleName = null;
            resources.ApplyResources(this.cboMemb, "cboMemb");
            this.cboMemb.BackgroundImage = null;
            this.cboMemb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMemb.ImageList = this.ImageList;
            this.cboMemb.Name = "cboMemb";
            this.cboMemb.SelectedIndexChanged += new System.EventHandler(this.cboMemb_SelectedIndexChanged);
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
            // laySlip_Info
            // 
            this.laySlip_Info.ExecuteQuery = null;
            this.laySlip_Info.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.laySlip_Info.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySlip_Info.ParamList")));
            this.laySlip_Info.QuerySQL = resources.GetString("laySlip_Info.QuerySQL");
            this.laySlip_Info.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySlip_Info_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "slip_gubun";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "slip_gubun_name";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "slip_code";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "slip_name";
            this.multiLayoutItem4.IsNotNull = true;
            // 
            // layOCS0212
            // 
            this.layOCS0212.ExecuteQuery = null;
            this.layOCS0212.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layOCS0212.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS0212.ParamList")));
            this.layOCS0212.QuerySQL = resources.GetString("layOCS0212.QuerySQL");
            this.layOCS0212.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS0212_QueryStarting);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "hangmog_code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "often_use";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "memb";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "memb_gubun";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "hosp_code";
            // 
            // OCS0203U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.tvwSlip_Info);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0203U00";
            this.UserChanged += new System.EventHandler(this.OCS0203U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0203U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0203_P1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0212)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			if(command == "F") return base.Command (command, commandParam);
            mMemb = commandParam["memb"].ToString();
			
			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
            //if (true)
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox1.Visible = true;
                xButtonList1.SetEnabled(FunctionType.Update, false);
            }
            else
            {
                xHospBox1.Visible = false;
            }

			base.OnLoad (e);

			IHIS.Framework.MultiLayout  layoutGwa = this.LoadGwa();
			cboGwa.SetComboItems(layoutGwa.LayoutTable, "gwa_name", "gwa", XComboSetType.AppendAll);
			cboGwa.SelectedIndex = 0;

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{			
			/// 사용자 변경 Event Call ////////////////////////////////
			this.OCS0203U00_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////
		}

		private void OCS0203U00_UserChanged(object sender, System.EventArgs e)
		{
			//clear
			tvwSlip_Info.Nodes.Clear();
			this.grdOCS0203_P1.Reset();
            //this.grdOCS0203_P2.Reset();
			
			//memb reset
			this.cboMemb.DataSource = null;
            
			if( UserInfo.UserGroup == "ADMIN")
			{
				lblGwa.Visible = true;
				cboGwa.Visible = true;

				IHIS.Framework.MultiLayout  layoutMemb = this.LoadAllMemb();
				cboMemb.SetComboItems(layoutMemb.LayoutTable, "memb_name", "memb", XComboSetType.AppendNone);
			}
			else
			{
                //lblGwa.Visible = false;
                //cboGwa.Visible = false;
                
				XComboItem cboItem;			
            
				//해당 사용자 User
				if(UserInfo.SlipOpenID.Trim() != "")
				{
					cboItem = new XComboItem(UserInfo.SlipOpenID, GetOCSCOM_USER_NAME(UserInfo.SlipOpenID), 5); 
					cboMemb.ComboItems.Add(cboItem);
				}
				else if(UserInfo.UserGubun == UserType.Doctor)
				{
					cboItem = new XComboItem(UserInfo.UserID, GetOCSCOM_USER_NAME(UserInfo.UserID), 5); 
					cboMemb.ComboItems.Add(cboItem);
				}
                        
				//공통 User를 가져온다.
				if(UserInfo.SlipOpenID != UserInfo.SlipComID && UserInfo.SlipComID.Trim() != "")
				{
					cboItem = new XComboItem(UserInfo.SlipComID, GetOCSCOM_USER_NAME(UserInfo.SlipComID), 6); 
					cboMemb.ComboItems.Add(cboItem);
				}
				else
				{
					string slip_com_id = GetOCSCOM_USER_ID("SLIP", UserInfo.UserID);
					if(UserInfo.SlipOpenID != slip_com_id && slip_com_id != "")
					{
						cboItem = new XComboItem(slip_com_id, GetOCSCOM_USER_NAME(slip_com_id), 6); 
						cboMemb.ComboItems.Add(cboItem);
					}
				}
			
				//사용자 서식지정보 Load
				cboMemb.RefreshComboItems();
			}
            if (cboGwa.SelectedIndex == 0)
            {
                this.cboGwa.SetDataValue(UserInfo.Gwa);
                
            }
			if ( cboMemb.ComboItems.Count > 0 || cboMemb.DataSource != null )
                this.cboMemb.SetDataValue(UserInfo.DoctorID);	
			else
			{
				mbxMsg =  Resources.TEXT1 ;
				mbxCap =  Resources.TEXT3 ;
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				this.Close();
			}
		}
		#endregion

		#region [사용자 combo]
		/// <summary>
		/// 사용자변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboMemb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            mMemb = cboMemb.SelectedValue.ToString();
			
			laySlip_Info.QueryLayout(true);

			//Show TreeView 
			ShowSlip_Info();
		}

		private MultiLayout LoadGwa()
		{
			IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("gwa"     , DataType.String);
			layoutCombo.LayoutItems.Add("gwa_name", DataType.String);
			layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT A.GWA, A.GWA_NAME                                               
//                                       FROM VW_BAS_GWA A                                                    
//                                      WHERE ( A.OUT_JUBSU_YN   = 'Y'  OR A.IPWON_YN = 'Y' )                 
//                                        AND A.START_DATE  = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, TRUNC(SYSDATE) )
//                                        AND A.HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE
//                                      ORDER BY A.GWA";

		    layoutCombo.ExecuteQuery = LoadDataGwa;

			layoutCombo.QueryLayout(false);

			return layoutCombo;
		}

		private MultiLayout LoadAllMemb()
		{
			IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

			//SLIP_GUBUN DataLayout;
			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("memb"     , DataType.String);
			layoutCombo.LayoutItems.Add("memb_name", DataType.String);
			layoutCombo.InitializeLayoutTable();


//            layoutCombo.QuerySQL = @"SELECT DOCTOR, '['||DOCTOR||']'||DOCTOR_NAME  MEMB_NAME
//                                       FROM  BAS0270
//                                      WHERE
//                                         SYSDATE BETWEEN START_DATE AND END_DATE
//                                         AND DOCTOR_GWA LIKE :f_gwa
//                                         AND  HOSP_CODE     =:f_hosp_code 
//                                      ORDER BY DOCTOR";

            layoutCombo.ParamList = new List<string>(new String[] { "f_gwa", "f_hosp_code" });
            layoutCombo.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
            layoutCombo.SetBindVarValue("f_hosp_code", mHospCode);
		    layoutCombo.ExecuteQuery = LoadDataAllMemb;

//            layoutCombo.QuerySQL = @"SELECT A.MEMB, '['||A.MEMB||']'||A.MEMB_NAME  MEMB_NAME
//                                       FROM OCS0130 A, BAS0270 B                              
//                                      WHERE B.DOCTOR = A.MEMB
//                                        AND B.HOSP_CODE = A.HOSP_CODE                                 
//                                        AND NVL(B.END_DATE, SYSDATE ) >= TRUNC(SYSDATE)  
//                                    --    AND NVL(B.TONGGYE_DOCTOR, SUBSTR(B.DOCTOR, 3, 6)) = SUBSTR(B.DOCTOR, 3, 6)
//                                    --    AND NVL(SUBSTR(B.TONGGYE_DOCTOR, 3, 6), B.DOCTOR)  = B.DOCTOR        
//                                        AND B.DOCTOR_GWA LIKE :f_gwa 
//                                        AND A.HOSP_CODE     = :f_hosp_code 
//                                      ORDER BY A.MEMB";


			layoutCombo.QueryLayout(false);

			return layoutCombo;
		}
		#endregion

		#region [진료과 combo]
		private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IHIS.Framework.MultiLayout layoutMemb = this.LoadAllMemb();
            cboMemb.SetComboItems(layoutMemb.LayoutTable, "memb_name", "memb", XComboSetType.AppendNone);
			cboMemb.SelectedIndex = 0;
		}
		#endregion

		#region [사용자공통 USER를 가져옵니다.]
		/// <summary>
		/// 해당 사용자의 공통 USER ID를 가져옵니다.
		/// </summary>
		/// <param name="aUser_gubun">공통사용자구분</param>
		/// <param name="aUser_id">사용자ID</param>
		/// <returns></returns>
		private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
		{
			string comUser_id = "";

            //string cmdText = ""
            //    + " SELECT FN_OCS_LOAD_MEMB_COMID(:f_aUser_gubun, :f_aUser_id) "
            //    + "   FROM DUAL ";

            //IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_aUser_gubun",aUser_gubun);
            //bindVars.Add("f_aUser_id",aUser_id);

            //object retComUserID = Service.ExecuteScalar(cmdText,bindVars);

            OCS0203U00GetOCSCOMUserIDArgs args = new OCS0203U00GetOCSCOMUserIDArgs(aUser_gubun, aUser_id);
		    OCS0203U00GetOCSCOMUserIDResult result =
		        CloudService.Instance.Submit<OCS0203U00GetOCSCOMUserIDResult, OCS0203U00GetOCSCOMUserIDArgs>(args);

            //if(retComUserID != null)
			if(result.ExecutionStatus == ExecutionStatus.Success)
                //comUser_id = retComUserID.ToString();
				comUser_id = result.Result;

			return comUser_id;
		}

		private string GetOCSCOM_USER_NAME(string aUser_id)
		{
			string comUser_name = "";

            //string cmdText = ""
            //    + " SELECT MEMB_NAME "
            //    + "   FROM OCS0130   "
            //    + "  WHERE MEMB      = :f_aUser_id"
            //    +"     AND HOSP_CODE = :f_hosp_code";

            //IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_aUser_id",aUser_id);
            //bindVars.Add("f_hosp_code", mHospCode);

            //object retComUserName = Service.ExecuteScalar(cmdText,bindVars);

            OCS0203U00GetOCSCOMUserNameArgs args = new OCS0203U00GetOCSCOMUserNameArgs(mHospCode, aUser_id);
            OCS0203U00GetOCSCOMUserNameResult result =
                CloudService.Instance.Submit<OCS0203U00GetOCSCOMUserNameResult, OCS0203U00GetOCSCOMUserNameArgs>(args);
                    
            //if(retComUserName != null)
			if(result.ExecutionStatus == ExecutionStatus.Success)
                //comUser_name = retComUserName.ToString();
				comUser_name = result.MembName;

			return comUser_name;
		}

		#endregion

		#region [TreeView Slip Info]
		private void ShowSlip_Info()
		{
			//clear
			tvwSlip_Info.Nodes.Clear();
			this.grdOCS0203_P1.Reset();
            //this.grdOCS0203_P2.Reset();
			
			if(laySlip_Info.RowCount < 1) return;
            
			string slip_gubun = "";			
			TreeNode node;

			foreach(DataRow row in laySlip_Info.LayoutTable.Rows)
			{
				if(slip_gubun != row["slip_gubun"].ToString())
				{
					node = new TreeNode( row["slip_gubun_name"].ToString() );
					node.Tag = row["slip_gubun"].ToString();
					tvwSlip_Info.Nodes.Add(node);
					slip_gubun = row["slip_gubun"].ToString();
				}

				node = new TreeNode( row["slip_name"].ToString() );
				node.Tag = row["slip_code"].ToString();
				tvwSlip_Info.Nodes[tvwSlip_Info.Nodes.Count -1].Nodes.Add(node);
			}

			tvwSlip_Info.ExpandAll();

			if(tvwSlip_Info.Nodes.Count > 0) tvwSlip_Info.SelectedNode = tvwSlip_Info.Nodes[0].Nodes[0];
		}

		private void tvwSlip_Info_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(tvwSlip_Info.SelectedNode.Parent == null) return;

			ShowOCS0203(tvwSlip_Info.SelectedNode.Tag.ToString());
		}
		#endregion

		#region [Show OCS0203]
		/// <summary>
		/// 해당 사용자의 서식지에 대한 항목정보(OCS0203)를 Load합니다.
		/// </summary>
		private void ShowOCS0203(string arSlip_code)
		{
			//Position Ⅰ
			grdOCS0203_P1.SetBindVarValue("f_memb", mMemb);
			grdOCS0203_P1.SetBindVarValue("f_slip_code", arSlip_code);
			//grdOCS0203_P1.SetBindVarValue("f_position", "1");
            grdOCS0203_P1.SetBindVarValue("f_hosp_code", mHospCode);
			grdOCS0203_P1.QueryLayout(true);

			lblSelectAll_P1.ImageIndex = 3;
			lblSelectAll_P1.Text = Resources.TEXT8;

            setOCS0212();

            ////Position Ⅱ
            //grdOCS0203_P2.SetBindVarValue("f_memb", mMemb);
            //grdOCS0203_P2.SetBindVarValue("f_slip_code", arSlip_code);
            //grdOCS0203_P2.SetBindVarValue("f_position", "2");
            //grdOCS0203_P2.SetBindVarValue("f_hosp_code", mHospCode);
            //grdOCS0203_P2.QueryLayout(true);

            //lblSelectAll_P2.ImageIndex = 3;
            //lblSelectAll_P2.Text = " 全体選択";
		}
		#endregion

		#region [전체선택]
		private void lblSelectAll_Click(object sender, System.EventArgs e)
		{
			XLabel lbl = sender as XLabel;

			if(lbl.ImageIndex == 3)
			{
				if(lbl.Tag.ToString() == "1")
					grdSelectAll(this.grdOCS0203_P1, "Y");
                //else
                //    grdSelectAll(this.grdOCS0203_P2, "Y");

				lbl.ImageIndex = 4;
				lbl.Text = Resources.TEXT9;
			}
			else
			{
				if(lbl.Tag.ToString() == "1")
					grdSelectAll(this.grdOCS0203_P1, "N");
                //else
                //    grdSelectAll(this.grdOCS0203_P2, "N");

				lbl.ImageIndex = 3;
				lbl.Text = Resources.TEXT8;
			}
		}
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
		private void grdSelectAll(XGrid grdObject, string select)
		{					
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{
				//grdObject.SetItemValue(rowIndex, "display_yn", select);
				grdObject.SetItemValue(rowIndex, "often_use", select);
			}
		}
		#endregion

		#region [선택한 Row 위치변경]
		/// <summary>
		/// 선택한 Row (from row)를 to row위치로 가져간다.
		/// </summary>
		/// <param name="grd">해당 Grid</param>
		/// <param name="fromRowNum">대상 row위치  </param>
		/// <param name="toRowNum"  >변경할 row위치</param>
		private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
		{
			if( fromRowNum < 0 || toRowNum < 0 ||
				fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount ) return;

			int currentColNum = grd.CurrentColNumber;
			if(currentColNum == -1) currentColNum = 0;

			MultiLayout copyLay = grd.CopyToLayout();
			grd.LayoutTable.Rows.Clear();

			for(int i = 0; i < copyLay.RowCount; i++ )
			{
				if( i == fromRowNum )
					continue;

				//변경위치로 Row를 가져간다.
				if( i == toRowNum )
				{
					if( fromRowNum < toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
					
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

					if( fromRowNum > toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
				}
				else
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
			}

			grd.DisplayData();
			grd.SetFocusToItem(toRowNum, currentColNum);	
			grd.SelectRow(toRowNum);
		}
		#endregion

		#region [Drag row]
		private void SetSequence()
		{
			for(int i = 0; i < grdOCS0203_P1.RowCount; i++)
			{
				grdOCS0203_P1.SetItemValue(i, "seq", i + 1);
			}

            //for(int i = 0; i < grdOCS0203_P2.RowCount; i++)
            //{
            //    grdOCS0203_P2.SetItemValue(i, "seq", i + 1);
            //}
		}

        //private void grdOCS0203_P1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (grdOCS0203_P1.GetHitRowNumber(e.Y) < 0 || grdOCS0203_P1.CurrentColNumber < 1) return;
        //    //if(grdOCS0203_P1.GetHitRowNumber(e.Y) < 0 || grdOCS0203_P1.CurrentColNumber < 3) return;		
        //    int    curRowIndex = grdOCS0203_P1.GetHitRowNumber(e.Y);
        //    string dragInfo = "[" + grdOCS0203_P1.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS0203_P1.GetItemString(curRowIndex, "hangmog_name");
        //    DragHelper.CreateDragCursor(grdOCS0203_P1, dragInfo, this.Font);			
        //    grdOCS0203_P1.DoDragDrop(grdOCS0203_P1.GetItemString(curRowIndex, "position") + "|" + curRowIndex.ToString(), DragDropEffects.Move);
        //}

        //private void grdOCS0203_P1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    // Client Point
        //    string fromPosition = e.Data.GetData("System.String").ToString().Split('|')[0];
        //    int fromRowNum      = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
        //    Point clientPoint = grdOCS0203_P1.PointToClient(new Point(e.X, e.Y));

        //    if(fromPosition == "1")
        //    {
        //        //같은 grid내에서는 위치바꿈
        //        int toRowNum = grdOCS0203_P1.GetHitRowNumber(clientPoint.Y);

        //        if(toRowNum == fromRowNum || toRowNum < 0 ) 
        //        {
        //            //Edit상태로 만든다.
        //            grdOCS0203_P1.SetFocusToItem(toRowNum, grdOCS0203_P1.CurrentColNumber);				
        //            return;
        //        }

        //        AlterGridRowPosition(grdOCS0203_P1, fromRowNum, toRowNum);
        //    }
        //    else
        //    {
        //        //grid가 다른 경우에는 Row trans
        //        //position 변경
        //        DataRow moveRow = grdOCS0203_P2.LayoutTable.Rows[fromRowNum];
        //        moveRow["position"] = "1";
        //        grdOCS0203_P1.LayoutTable.ImportRow(moveRow);
        //        grdOCS0203_P1.DisplayData();
        //        grdOCS0203_P1.SetFocusToItem(grdOCS0203_P1.RowCount -1, 0);
				
        //        grdOCS0203_P2.DeleteRow(fromRowNum);
        //        grdOCS0203_P2.DeletedRowTable.Clear();
        //    }

        //    SetSequence();
        //}

        //private void grdOCS0203_P2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (grdOCS0203_P2.GetHitRowNumber(e.Y) < 0 || grdOCS0203_P2.CurrentColNumber < 1) return;
        //    //if(grdOCS0203_P2.GetHitRowNumber(e.Y) < 0 || grdOCS0203_P2.CurrentColNumber <3) return;
        //    int    curRowIndex = grdOCS0203_P2.GetHitRowNumber(e.Y);
        //    string dragInfo = "[" + grdOCS0203_P2.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS0203_P2.GetItemString(curRowIndex, "hangmog_name");
        //    DragHelper.CreateDragCursor(grdOCS0203_P2, dragInfo, this.Font);
        //    grdOCS0203_P2.DoDragDrop(grdOCS0203_P2.GetItemString(curRowIndex, "position") + "|" + curRowIndex.ToString(), DragDropEffects.Move);
        //}

        //private void grdOCS0203_P2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        //{	
        //    // Client Point
        //    string fromPosition = e.Data.GetData("System.String").ToString().Split('|')[0];
        //    int fromRowNum      = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
        //    Point clientPoint = grdOCS0203_P2.PointToClient(new Point(e.X, e.Y));

        //    if(fromPosition == "2")
        //    {
        //        //같은 grid내에서는 위치바꿈				
        //        int toRowNum = grdOCS0203_P2.GetHitRowNumber(clientPoint.Y);

        //        if(toRowNum == fromRowNum || toRowNum < 0 ) 
        //        {
        //            //Edit상태로 만든다.
        //            grdOCS0203_P2.SetFocusToItem(toRowNum, grdOCS0203_P2.CurrentColNumber);				
        //            return;
        //        }

        //        AlterGridRowPosition(grdOCS0203_P2, fromRowNum, toRowNum);
        //    }
        //    else
        //    {
        //        //grid가 다른 경우에는 Row trans
        //        //position 변경
        //        DataRow moveRow = grdOCS0203_P1.LayoutTable.Rows[fromRowNum];
        //        moveRow["position"] = "2";
        //        grdOCS0203_P2.LayoutTable.ImportRow(moveRow);
        //        grdOCS0203_P2.DisplayData();
        //        grdOCS0203_P2.SetFocusToItem(grdOCS0203_P2.RowCount - 1, 0);
				
        //        grdOCS0203_P1.DeleteRow(fromRowNum);
        //        grdOCS0203_P1.DeletedRowTable.Clear();
        //    }
            
        //    //seq 변경
        //    SetSequence();
		
        //}

        //private void grdOCS0203_P1_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;
        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}

        //private void grdOCS0203_P2_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;
        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}

		private void grdOCS0203_P1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{				
			e.Effect = DragDropEffects.Move;  // Move 표시	
		}

        //private void grdOCS0203_P2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        //{				
        //    e.Effect = DragDropEffects.Move;  // Move 표시	
        //}

		private void grdOCS0203_P1_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_yn"].ToString() == "Y")
				e.ForeColor = Color.Red;
		}

        //private void grdOCS0203_P2_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        //{
        //    if(e.DataRow["bulyong_yn"].ToString() == "Y")
        //        e.ForeColor = Color.Red;
        //}

		private void tvwSlip_Info_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Point clientPoint = tvwSlip_Info.PointToClient(new Point(e.X, e.Y));

			if(tvwSlip_Info.GetNodeAt(clientPoint) == null) return;
			tvwSlip_Info.SelectedNode = tvwSlip_Info.GetNodeAt(clientPoint);
		}

		private void tvwSlip_Info_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시	
		}

		private void tvwSlip_Info_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{	
				Cursor.Current = DragHelper.DragCursor;
			}
		}
		#endregion

		#region [Button List]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					laySlip_Info.QueryLayout(true);
					ShowSlip_Info();
					break;
				case FunctionType.Reset:
					e.IsBaseCall = false;
					if(tvwSlip_Info.SelectedNode.Parent == null) return;
					ShowOCS0203(tvwSlip_Info.SelectedNode.Tag.ToString());
					break;
				case FunctionType.Update:
                    
                    if (mMemb == "") 
                    {
                        mbxMsg = Resources.TEXT11; 
                        mbxCap =  Resources.TEXT13;
                        XMessageBox.Show(mbxMsg, mbxCap);  
                        e.IsBaseCall = false;

                    }
                    else
                    {
                        SaveOCS0203U00();                        
                    }
  					break;
				case FunctionType.Delete:
					break;
				default:
					break;
			}
		}

	    #endregion

		#region [SaveEnd]
		private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			switch(e.CallerID)
			{
				case '1':
                    //isgrdP1Save = e.IsSuccess;
					isgrdP1Save = updateResult.Result;
                    //isP1Saved = true;
					break;
                //case '2':
                //    isgrdP2Save = e.IsSuccess;
                //    isP2Saved = true;
                //    break;
			}

            if (isgrdP1Save)
            //if(isP1Saved && isP2Saved)

			{
                if (isgrdP1Save)
                    //if(isgrdP1Save && isgrdP2Save)

				{

                    mbxMsg = Resources.TEXT14;
                    SetMsg(mbxMsg);
                    XMessageBox.Show(mbxMsg, Resources.TEXT16);//ADD
					
				}
				else
				{
					mbxMsg =  Resources.TEXT17;
					mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = Resources.TEXT19;
					XMessageBox.Show(mbxMsg, mbxCap);
				}
				isgrdP1Save =false;
                //isP1Saved = false;
                //isgrdP2Save = false;
                //isP2Saved = false;
			}

		}
        #endregion

        #region 각 그리드에 바인드변수 설정
        private void laySlip_Info_QueryStarting(object sender, CancelEventArgs e)
        {
            laySlip_Info.SetBindVarValue("f_memb",      mMemb);
            laySlip_Info.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        public void setOCS0212()
        {
            XEditGrid grd = this.grdOCS0203_P1;

            this.layOCS0212.QueryLayout(true);

            for (int i = 0; i < this.layOCS0212.RowCount; i++)
            {
                for (int k = 0; k < this.grdOCS0203_P1.RowCount; k++)
                {
                    if (this.grdOCS0203_P1.GetItemString(k, "hangmog_code") == this.layOCS0212.GetItemString(i, "hangmog_code"))
                    {
                        this.grdOCS0203_P1.SetItemValue(k, "often_use", "Y");
                    }
                }
            }

        }
        #region [XSavePerformer Class]
        //private class XSavePerformer : IHIS.Framework.ISavePerformer
        //{
        //    private OCS0203U00 parent = null;

        //    public XSavePerformer(OCS0203U00 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        string cmdText = "";
        //        bool retbl = false;
        //        item.BindVarList.Add("f_user_id",UserInfo.UserID);
        //        item.BindVarList.Add("f_hosp_code", parent.mHospCode);

        //        switch(callerID)
        //        {
        //            case '1':
        //                switch(item.RowState)
        //                {
        //                    case DataRowState.Added :
        //                        retbl = true;
        //                        break;
        //                    case DataRowState.Modified :
        //                        cmdText = parent.SqlText(item.BindVarList);
        //                        retbl = Service.ExecuteNonQuery(cmdText,item.BindVarList);
        //                        break;
        //                    case DataRowState.Deleted :
        //                        retbl = true;
        //                        break;
        //                }
        //                break;
        //            //case '2':
        //            //    switch(item.RowState)
        //            //    {
        //            //        case DataRowState.Added :
        //            //            retbl = true;
        //            //            break;
        //            //        case DataRowState.Modified :
        //            //            cmdText = parent.SqlText(item.BindVarList);
        //            //            retbl = Service.ExecuteNonQuery(cmdText,item.BindVarList);
        //            //            break;
        //            //        case DataRowState.Deleted :
        //            //            retbl = true;
        //            //            break;
        //            //    }
        //            //    break;
        //        }

        //        return retbl;
        //    }
        //}
		#endregion

		#region [Return SqlText]
//        private string SqlText(BindVarCollection bindList)
//        {
//            string sqlText = "";

//            string cmdText = "SELECT 'Y'"
//                            + "  FROM OCS0212"
//                            + " WHERE MEMB         = :f_memb"
//                            + "	 AND HANGMOG_CODE = :f_hangmog_code"
//                            + "   AND HOSP_CODE    = :f_hosp_code"
//                            + "	 AND ROWNUM = 1";

//            //string cmdText = "SELECT 'Y'"
//            //                +"  FROM OCS0203"
//            //                +" WHERE MEMB         = :f_memb"
//            //                +"	 AND HANGMOG_CODE = :f_hangmog_code"
//            //                +"   AND HOSP_CODE    = :f_hosp_code"
//            //                +"	 AND ROWNUM = 1";
//            IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_memb",bindList["f_memb"].VarValue);
//            bindVars.Add("f_hangmog_code", bindList["f_hangmog_code"].VarValue);
//            bindVars.Add("f_hosp_code",    bindList["f_hosp_code"].VarValue);

//            object retVal = Service.ExecuteScalar(cmdText,bindVars);

//            if (retVal != null)
//            {
//                sqlText = @"UPDATE OCS0212
//                               SET UPD_ID         = :f_user_id   , 
//                                   UPD_DATE       = SYSDATE      ,  
//                                   SEQ            = :f_seq       , 
//                                   OFTEN_USE      = :f_often_use   
//                             WHERE MEMB           = :f_memb          
//                               AND HANGMOG_CODE   = :f_hangmog_code
//                               AND HOSP_CODE      = :f_hosp_code";
//            }
//            else
//            {
//                sqlText = @"INSERT INTO OCS0212
//                                  ( SYS_DATE, 
//                                    SYS_ID, 
//                                    UPD_DATE, 
//                                    UPD_ID,
//                                    MEMB_GUBUN,
//                                    MEMB,
//                                    HANGMOG_CODE,
//                                    SEQ,
//                                    OFTEN_USE, 
//                                    HOSP_CODE)
//                            VALUES
//                                  ( SYSDATE, 
//                                    :f_user_id,
//                                    SYSDATE, 
//                                    :f_user_id,
//                                    1,
//                                    :f_memb, 
//                                    :f_hangmog_code,
//                                    :f_seq,
//                                    :f_often_use,
//                                    :f_hosp_code    )";
//            }


////            if(retVal != null)
////            {
////                sqlText = @"UPDATE OCS0203
////                               SET UPD_ID         = :f_user_id   , 
////                                   UPD_DATE       = SYSDATE      , 
////                                   POSITION       = :f_position  , 
////                                   SEQ            = :f_seq       , 
////                                   DISPLAY_YN     = :f_display_yn, 
////                                   DISPLAY_YN_INP = :f_display_yn, 
////                                   OFTEN_USE      = :f_often_use   
////                             WHERE MEMB           = :f_memb          
////                               AND HANGMOG_CODE   = :f_hangmog_code
////                               AND HOSP_CODE      = :f_hosp_code";
////            }
////            else
////            {
////                sqlText = @"INSERT INTO OCS0203
////                                  ( SYS_DATE       , SYS_ID     , UPD_DATE, UPD_ID,
////                                    MEMB           , SLIP_CODE  , HANGMOG_CODE   ,
////                                    POSITION       , SEQ        , DISPLAY_YN     ,
////                                    DISPLAY_YN_INP , OFTEN_USE  , HOSP_CODE)
////                            VALUES
////                                  ( SYSDATE , :f_user_id ,SYSDATE, :f_user_id    ,
////                                    :f_memb           , :f_slip_code  , :f_hangmog_code ,
////                                    :f_position       , :f_seq        , :f_display_yn   ,
////                                    :f_display_yn_inp , :f_often_use  , :f_hosp_code    )";
////            }

//            return sqlText;
//        }
		#endregion

        private void layOCS0212_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS0212.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS0212.SetBindVarValue("f_memb", cboMemb.GetDataValue());
            this.layOCS0212.SetBindVarValue("f_slip_code", this.tvwSlip_Info.SelectedNode.Tag.ToString());
            
        }

        private void OCS0203U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.cboMemb.SetDataValue(UserInfo.DoctorID);
        }

        #region [Cloud Service]

        /// <summary>
        /// load data for cboMemb
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataAllMemb(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0203U00LoadAllMembArgs args = new OCS0203U00LoadAllMembArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            OCS0203U00LoadAllMembResult result = CloudService.Instance.Submit<OCS0203U00LoadAllMembResult, OCS0203U00LoadAllMembArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.CboList)
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
        /// get data for grdOCS0203_P1
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdOCS0203(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0203U00GrdOcs0203P1Args args = new OCS0203U00GrdOcs0203P1Args();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            OCS0203U00GrdOcs0203P1Result result = CloudService.Instance.Submit<OCS0203U00GrdOcs0203P1Result, OCS0203U00GrdOcs0203P1Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0203U00GrdOcs0203P1Info item in result.InfoList)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.SlipCode, 
					item.Value999, 
					item.NValue, 
					item.HangmogCode, 
					item.HangmogName,
                    item.BulyongYn,
                    item.NewFlag
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// load data for layOCS0212
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLayOCS0212(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0203U00LayOCS0212Args args = new OCS0203U00LayOCS0212Args();
            args.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            OCS0203U00LayOCS0212Result result = CloudService.Instance.Submit<OCS0203U00LayOCS0212Result, OCS0203U00LayOCS0212Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0203U00LayOCS0212Info item in result.InfoList)
                {
                    object[] objects = 
				{ 
					item.HangmogCode, 
					item.OftenUse, 
					item.Memb, 
					item.MembGubun, 
					item.HospCode
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for laySlip_Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataLaySlipInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0203U00LaySlipArgs args = new OCS0203U00LaySlipArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            OCS0203U00LaySlipResult result = CloudService.Instance.Submit<OCS0203U00LaySlipResult, OCS0203U00LaySlipArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0203U00LaySlipInfo item in result.InfoList)
                {
                    object[] objects = 
				{ 
					item.SlipGubun, 
					item.SlipGubunName, 
					item.SlipCode, 
					item.SlipName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for cboGwa
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0203U00LoadGwaArgs args = new OCS0203U00LoadGwaArgs();
            args.HospCode = mHospCode;
            OCS0203U00LoadGwaResult result = CloudService.Instance.Submit<OCS0203U00LoadGwaResult, OCS0203U00LoadGwaArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.CboList)
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
        /// save layout
        /// </summary>
        private void SaveOCS0203U00()
        {
            OCS0203U00SaveLayoutArgs args = new OCS0203U00SaveLayoutArgs();
            args.InfoList = CreateListForSaveLayout();
            if (args.InfoList.Count == 0)
            {
                updateResult.Result = true;
                return;
            }
            args.HospCode = mHospCode;
            args.UserId = UserInfo.UserID;

            updateResult = CloudService.Instance.Submit<UpdateResult, OCS0203U00SaveLayoutArgs>(args);
        }

        /// <summary>
        /// create list of object from grdOCS0203_P1
        /// </summary>
        /// <returns></returns>
	    private List<OCS0203U00GrdOcs0203P1Info> CreateListForSaveLayout()
	    {
	        List<OCS0203U00GrdOcs0203P1Info> dataList = new List<OCS0203U00GrdOcs0203P1Info>();
	        for (int i = 0; i < grdOCS0203_P1.RowCount; i++)
	        {
	            if (grdOCS0203_P1.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }
                OCS0203U00GrdOcs0203P1Info info = new OCS0203U00GrdOcs0203P1Info();
                info.Memb = grdOCS0203_P1.GetItemString(i, "memb");
                info.SlipCode = grdOCS0203_P1.GetItemString(i, "slip_code");
                info.Seq = grdOCS0203_P1.GetItemString(i, "seq");
                info.OftenUsed = grdOCS0203_P1.GetItemString(i, "often_use");
                info.HangmogCode = grdOCS0203_P1.GetItemString(i, "hangmog_code");
                info.HangmogName = grdOCS0203_P1.GetItemString(i, "hangmog_name");
                dataList.Add(info);
	        }
	        return dataList;
	    }

	    #endregion

        private void xHospBox1_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox1.HospCode;
            xButtonList1.PerformClick(FunctionType.Query);

            //reload combo box
            IHIS.Framework.MultiLayout layoutGwa = this.LoadGwa();
            cboGwa.SetComboItems(layoutGwa.LayoutTable, "gwa_name", "gwa", XComboSetType.AppendAll);
            cboGwa.SelectedIndex = 0;

            IHIS.Framework.MultiLayout layoutMemb = this.LoadAllMemb();
            cboMemb.SetComboItems(layoutMemb.LayoutTable, "memb_name", "memb", XComboSetType.AppendNone);
        }

        private void xHospBox1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = xHospBox1.HospCode;
                xButtonList1.PerformClick(FunctionType.Query);

                //reload combo box
                IHIS.Framework.MultiLayout layoutGwa = this.LoadGwa();
                cboGwa.SetComboItems(layoutGwa.LayoutTable, "gwa_name", "gwa", XComboSetType.AppendAll);
                cboGwa.SelectedIndex = 0;

                IHIS.Framework.MultiLayout layoutMemb = this.LoadAllMemb();
                cboMemb.SetComboItems(layoutMemb.LayoutTable, "memb_name", "memb", XComboSetType.AppendNone);
            }
        }
    }
}

