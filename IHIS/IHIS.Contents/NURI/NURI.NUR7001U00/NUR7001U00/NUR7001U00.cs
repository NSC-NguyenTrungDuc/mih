#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURI.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Models.Nuri;

#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR7001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR7001U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
		//팝업화면으로 오픈이 됐을 때 해당 화면이 팝업으로
		//오픈(flag = "Y")이 된건지 아니면 메뉴에 의해 오픈(flag = "N")이 됐는지
		//여부를 판단한다.
		//그리고 팝업으로 오픈 후 데이터 저장을 했을 때 
		//화면을 오픈시킨 화면에 데이터 변경이 있다는 플래그를 던져주기위해
		//flag = "S"로 바꾼다.
		private string flag = "N";
		#endregion

		#region 자동생성
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlButtonlist;
		private IHIS.Framework.XEditGrid grdNur7001;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XLabel lblHeight;
		private IHIS.Framework.XEditMask emkHeight;
		private IHIS.Framework.XEditMask emkWeight;
		private IHIS.Framework.XLabel lblWeight;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XLabel lblMeasure_date;
		private IHIS.Framework.XDatePicker dtpMeasure_date;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XLabel lblBp;
		private IHIS.Framework.XEditMask emkBp_to;
		private System.Windows.Forms.Label lblDash;
		private IHIS.Framework.XEditMask emkBp_from;
		private IHIS.Framework.XLabel lblPluse;
		private IHIS.Framework.XEditMask emkPluse;
		private IHIS.Framework.XLabel lblBody_heat;
		private IHIS.Framework.XEditMask emkBody_heat;
		private IHIS.Framework.XLabel lblSpo2;
		private IHIS.Framework.XEditMask emkSpo2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditMask emkMeasure_time;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XLabel lblBreath;
		private IHIS.Framework.XEditMask emkBreath;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XLabel xLabel3;
        private XLabel xLabel2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR7001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
//            this.SaveLayoutList.Add(this.grdNur7001);
            //this.grdNur7001.SavePerformer = new XSavePerformer(this);

            
                this.grdNur7001.ParamList = CreateListParam();
               

		        //IList<object[]> data = GetDataForManagePatient();
		        this.grdNur7001.ExecuteQuery = GetDataForManagePatient;
		    

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR7001U00));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlButtonlist = new System.Windows.Forms.Panel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNur7001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.dtpMeasure_date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.emkHeight = new IHIS.Framework.XEditMask();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.emkWeight = new IHIS.Framework.XEditMask();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.emkBp_from = new IHIS.Framework.XEditMask();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.emkBp_to = new IHIS.Framework.XEditMask();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.emkBody_heat = new IHIS.Framework.XEditMask();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.emkPluse = new IHIS.Framework.XEditMask();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.emkSpo2 = new IHIS.Framework.XEditMask();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.emkMeasure_time = new IHIS.Framework.XEditMask();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.emkBreath = new IHIS.Framework.XEditMask();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.lblHeight = new IHIS.Framework.XLabel();
            this.lblWeight = new IHIS.Framework.XLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.lblBreath = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.lblSpo2 = new IHIS.Framework.XLabel();
            this.lblBody_heat = new IHIS.Framework.XLabel();
            this.lblPluse = new IHIS.Framework.XLabel();
            this.lblDash = new System.Windows.Forms.Label();
            this.lblBp = new IHIS.Framework.XLabel();
            this.lblMeasure_date = new IHIS.Framework.XLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlButtonlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur7001)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
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
            // pnlButtonlist
            // 
            this.pnlButtonlist.AccessibleDescription = null;
            this.pnlButtonlist.AccessibleName = null;
            resources.ApplyResources(this.pnlButtonlist, "pnlButtonlist");
            this.pnlButtonlist.BackgroundImage = null;
            this.pnlButtonlist.Controls.Add(this.btnList);
            this.pnlButtonlist.Font = null;
            this.pnlButtonlist.Name = "pnlButtonlist";
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
            // grdNur7001
            // 
            resources.ApplyResources(this.grdNur7001, "grdNur7001");
            this.grdNur7001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdNur7001.ColPerLine = 11;
            this.grdNur7001.Cols = 12;
            this.grdNur7001.ControlBinding = true;
            this.grdNur7001.EnableMultiSelection = true;
            this.grdNur7001.ExecuteQuery = null;
            this.grdNur7001.FixedCols = 1;
            this.grdNur7001.FixedRows = 1;
            this.grdNur7001.FocusColumnName = "measure_date";
            this.grdNur7001.HeaderHeights.Add(35);
            this.grdNur7001.Name = "grdNur7001";
            this.grdNur7001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNur7001.ParamList")));
            this.grdNur7001.QuerySQL = resources.GetString("grdNur7001.QuerySQL");
            this.grdNur7001.ReadOnly = true;
            this.grdNur7001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNur7001.RowHeaderVisible = true;
            this.grdNur7001.Rows = 2;
            this.grdNur7001.ToolTipActive = true;
            this.grdNur7001.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNur7001_SaveEnd);
            this.grdNur7001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur7001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 8;
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.SuppressRepeating = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.BindControl = this.dtpMeasure_date;
            this.xEditGridCell2.CellName = "measure_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 96;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.InvalidDateIsStringEmpty = false;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // dtpMeasure_date
            // 
            this.dtpMeasure_date.AccessibleDescription = null;
            this.dtpMeasure_date.AccessibleName = null;
            resources.ApplyResources(this.dtpMeasure_date, "dtpMeasure_date");
            this.dtpMeasure_date.BackgroundImage = null;
            this.dtpMeasure_date.IsVietnameseYearType = false;
            this.dtpMeasure_date.Name = "dtpMeasure_date";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "seq";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.emkHeight;
            this.xEditGridCell3.CellName = "height";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell3.CellWidth = 54;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.DecimalDigits = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.GeneralNumberFormat = true;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // emkHeight
            // 
            this.emkHeight.AccessibleDescription = null;
            this.emkHeight.AccessibleName = null;
            resources.ApplyResources(this.emkHeight, "emkHeight");
            this.emkHeight.BackgroundImage = null;
            this.emkHeight.DecimalDigits = 1;
            this.emkHeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkHeight.EditVietnameseMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkHeight.GeneralNumberFormat = true;
            this.emkHeight.IsVietnameseYearType = false;
            this.emkHeight.Name = "emkHeight";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.emkWeight;
            this.xEditGridCell4.CellName = "weight";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell4.CellWidth = 57;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.DecimalDigits = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.GeneralNumberFormat = true;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // emkWeight
            // 
            this.emkWeight.AccessibleDescription = null;
            this.emkWeight.AccessibleName = null;
            resources.ApplyResources(this.emkWeight, "emkWeight");
            this.emkWeight.BackgroundImage = null;
            this.emkWeight.DecimalDigits = 2;
            this.emkWeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkWeight.EditVietnameseMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkWeight.GeneralNumberFormat = true;
            this.emkWeight.IsVietnameseYearType = false;
            this.emkWeight.Name = "emkWeight";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.emkBp_from;
            this.xEditGridCell5.CellName = "bp_from";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 53;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // emkBp_from
            // 
            this.emkBp_from.AccessibleDescription = null;
            this.emkBp_from.AccessibleName = null;
            resources.ApplyResources(this.emkBp_from, "emkBp_from");
            this.emkBp_from.BackgroundImage = null;
            this.emkBp_from.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkBp_from.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkBp_from.GeneralNumberFormat = true;
            this.emkBp_from.IsVietnameseYearType = false;
            this.emkBp_from.Name = "emkBp_from";
            this.emkBp_from.Tag = "bp_from";
            this.emkBp_from.Leave += new System.EventHandler(this.emk_Leave);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.emkBp_to;
            this.xEditGridCell6.CellName = "bp_to";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 53;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // emkBp_to
            // 
            this.emkBp_to.AccessibleDescription = null;
            this.emkBp_to.AccessibleName = null;
            resources.ApplyResources(this.emkBp_to, "emkBp_to");
            this.emkBp_to.BackgroundImage = null;
            this.emkBp_to.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkBp_to.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkBp_to.GeneralNumberFormat = true;
            this.emkBp_to.IsVietnameseYearType = false;
            this.emkBp_to.Name = "emkBp_to";
            this.emkBp_to.Tag = "bp_to";
            this.emkBp_to.Leave += new System.EventHandler(this.emk_Leave);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.emkBody_heat;
            this.xEditGridCell7.CellLen = 5;
            this.xEditGridCell7.CellName = "body_heat";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell7.CellWidth = 60;
            this.xEditGridCell7.Col = 8;
            this.xEditGridCell7.DecimalDigits = 1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // emkBody_heat
            // 
            this.emkBody_heat.AccessibleDescription = null;
            this.emkBody_heat.AccessibleName = null;
            resources.ApplyResources(this.emkBody_heat, "emkBody_heat");
            this.emkBody_heat.BackgroundImage = null;
            this.emkBody_heat.DecimalDigits = 1;
            this.emkBody_heat.EditMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkBody_heat.EditVietnameseMaskType = IHIS.Framework.MaskType.Decimal;
            this.emkBody_heat.GeneralNumberFormat = true;
            this.emkBody_heat.IsVietnameseYearType = false;
            this.emkBody_heat.Name = "emkBody_heat";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.emkPluse;
            this.xEditGridCell8.CellName = "pulse";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 46;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // emkPluse
            // 
            this.emkPluse.AccessibleDescription = null;
            this.emkPluse.AccessibleName = null;
            resources.ApplyResources(this.emkPluse, "emkPluse");
            this.emkPluse.BackgroundImage = null;
            this.emkPluse.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkPluse.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkPluse.GeneralNumberFormat = true;
            this.emkPluse.IsVietnameseYearType = false;
            this.emkPluse.Name = "emkPluse";
            this.emkPluse.Tag = "pulse";
            this.emkPluse.Leave += new System.EventHandler(this.emk_Leave);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "suname";
            this.xEditGridCell10.CellWidth = 120;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.SuppressRepeating = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.emkSpo2;
            this.xEditGridCell11.CellName = "spo2";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 47;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // emkSpo2
            // 
            this.emkSpo2.AccessibleDescription = null;
            this.emkSpo2.AccessibleName = null;
            resources.ApplyResources(this.emkSpo2, "emkSpo2");
            this.emkSpo2.BackgroundImage = null;
            this.emkSpo2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkSpo2.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkSpo2.GeneralNumberFormat = true;
            this.emkSpo2.IsVietnameseYearType = false;
            this.emkSpo2.Name = "emkSpo2";
            this.emkSpo2.Tag = "spo2";
            this.emkSpo2.Leave += new System.EventHandler(this.emk_Leave);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.emkMeasure_time;
            this.xEditGridCell12.CellName = "measure_time";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell12.CellWidth = 70;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.Mask = "HH:MI";
            // 
            // emkMeasure_time
            // 
            this.emkMeasure_time.AccessibleDescription = null;
            this.emkMeasure_time.AccessibleName = null;
            resources.ApplyResources(this.emkMeasure_time, "emkMeasure_time");
            this.emkMeasure_time.BackgroundImage = null;
            this.emkMeasure_time.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkMeasure_time.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkMeasure_time.IsVietnameseYearType = false;
            this.emkMeasure_time.Mask = "HH:MI";
            this.emkMeasure_time.Name = "emkMeasure_time";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.emkBreath;
            this.xEditGridCell13.CellName = "breath";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 67;
            this.xEditGridCell13.Col = 10;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // emkBreath
            // 
            this.emkBreath.AccessibleDescription = null;
            this.emkBreath.AccessibleName = null;
            resources.ApplyResources(this.emkBreath, "emkBreath");
            this.emkBreath.BackgroundImage = null;
            this.emkBreath.EditMaskType = IHIS.Framework.MaskType.Number;
            this.emkBreath.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.emkBreath.GeneralNumberFormat = true;
            this.emkBreath.IsVietnameseYearType = false;
            this.emkBreath.Name = "emkBreath";
            this.emkBreath.Tag = "breath";
            this.emkBreath.Leave += new System.EventHandler(this.emk_Leave);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "upd_id";
            this.xEditGridCell14.CellWidth = 89;
            this.xEditGridCell14.Col = 11;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.grdNur7001);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // lblHeight
            // 
            this.lblHeight.AccessibleDescription = null;
            this.lblHeight.AccessibleName = null;
            resources.ApplyResources(this.lblHeight, "lblHeight");
            this.lblHeight.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHeight.EdgeRounding = false;
            this.lblHeight.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHeight.Image = null;
            this.lblHeight.Name = "lblHeight";
            // 
            // lblWeight
            // 
            this.lblWeight.AccessibleDescription = null;
            this.lblWeight.AccessibleName = null;
            resources.ApplyResources(this.lblWeight, "lblWeight");
            this.lblWeight.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblWeight.EdgeRounding = false;
            this.lblWeight.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblWeight.Image = null;
            this.lblWeight.Name = "lblWeight";
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.xLabel3);
            this.pnlFill.Controls.Add(this.xLabel2);
            this.pnlFill.Controls.Add(this.emkBreath);
            this.pnlFill.Controls.Add(this.lblBreath);
            this.pnlFill.Controls.Add(this.emkMeasure_time);
            this.pnlFill.Controls.Add(this.xLabel1);
            this.pnlFill.Controls.Add(this.emkSpo2);
            this.pnlFill.Controls.Add(this.lblSpo2);
            this.pnlFill.Controls.Add(this.emkBody_heat);
            this.pnlFill.Controls.Add(this.lblBody_heat);
            this.pnlFill.Controls.Add(this.emkPluse);
            this.pnlFill.Controls.Add(this.lblPluse);
            this.pnlFill.Controls.Add(this.emkBp_from);
            this.pnlFill.Controls.Add(this.lblDash);
            this.pnlFill.Controls.Add(this.emkBp_to);
            this.pnlFill.Controls.Add(this.lblBp);
            this.pnlFill.Controls.Add(this.dtpMeasure_date);
            this.pnlFill.Controls.Add(this.lblMeasure_date);
            this.pnlFill.Controls.Add(this.emkHeight);
            this.pnlFill.Controls.Add(this.lblWeight);
            this.pnlFill.Controls.Add(this.emkWeight);
            this.pnlFill.Controls.Add(this.lblHeight);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
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
            // lblBreath
            // 
            this.lblBreath.AccessibleDescription = null;
            this.lblBreath.AccessibleName = null;
            resources.ApplyResources(this.lblBreath, "lblBreath");
            this.lblBreath.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBreath.EdgeRounding = false;
            this.lblBreath.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBreath.Image = null;
            this.lblBreath.Name = "lblBreath";
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
            // lblSpo2
            // 
            this.lblSpo2.AccessibleDescription = null;
            this.lblSpo2.AccessibleName = null;
            resources.ApplyResources(this.lblSpo2, "lblSpo2");
            this.lblSpo2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSpo2.EdgeRounding = false;
            this.lblSpo2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblSpo2.Image = null;
            this.lblSpo2.Name = "lblSpo2";
            // 
            // lblBody_heat
            // 
            this.lblBody_heat.AccessibleDescription = null;
            this.lblBody_heat.AccessibleName = null;
            resources.ApplyResources(this.lblBody_heat, "lblBody_heat");
            this.lblBody_heat.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBody_heat.EdgeRounding = false;
            this.lblBody_heat.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBody_heat.Image = null;
            this.lblBody_heat.Name = "lblBody_heat";
            // 
            // lblPluse
            // 
            this.lblPluse.AccessibleDescription = null;
            this.lblPluse.AccessibleName = null;
            resources.ApplyResources(this.lblPluse, "lblPluse");
            this.lblPluse.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPluse.EdgeRounding = false;
            this.lblPluse.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPluse.Image = null;
            this.lblPluse.Name = "lblPluse";
            // 
            // lblDash
            // 
            this.lblDash.AccessibleDescription = null;
            this.lblDash.AccessibleName = null;
            resources.ApplyResources(this.lblDash, "lblDash");
            this.lblDash.Font = null;
            this.lblDash.Name = "lblDash";
            // 
            // lblBp
            // 
            this.lblBp.AccessibleDescription = null;
            this.lblBp.AccessibleName = null;
            resources.ApplyResources(this.lblBp, "lblBp");
            this.lblBp.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBp.EdgeRounding = false;
            this.lblBp.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBp.Image = null;
            this.lblBp.Name = "lblBp";
            // 
            // lblMeasure_date
            // 
            this.lblMeasure_date.AccessibleDescription = null;
            this.lblMeasure_date.AccessibleName = null;
            resources.ApplyResources(this.lblMeasure_date, "lblMeasure_date");
            this.lblMeasure_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblMeasure_date.EdgeRounding = false;
            this.lblMeasure_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblMeasure_date.Image = null;
            this.lblMeasure_date.Name = "lblMeasure_date";
            // 
            // NUR7001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButtonlist);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR7001U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR7001U00_Closing);
            this.UserChanged += new System.EventHandler(this.NUR7001U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR7001U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlButtonlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur7001)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "bunho":
					msg = Resources.MSG001_MSG;
					caption = Resources.MSG001_CAP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "height":
					msg = Resources.MSG002_MSG;
					caption = (Resources.MSG001_CAP);
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "weight":
					msg = Resources.MSG003_MSG;
					caption = (Resources.MSG001_CAP);
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;

                case "bp":
                    msg = Resources.MSG004_MSG;
                    caption = (Resources.MSG001_CAP);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;

				case "save":
					msg = Resources.MSG005_MSG;
					caption = (Resources.MSG001_CAP);
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "measure_date":
					msg = Resources.MSG006_MSG;
					caption = (Resources.MSG001_CAP);
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = Resources.MSG007_MSG;
					caption = Resources.MSG001_CAP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = Resources.MSG008_MSG;
                    msg += "\r\n[" + SaveErrFullMsg + "]";
					caption = Resources.MSG008_CAP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			int count = 0;

			if (this.paBox.BunHo.ToString() == "") return;

            if(this.grdNur7001.QueryLayout(false))
			{
				if (this.grdNur7001.RowCount == 0)
				{
					this.btnList.PerformClick(FunctionType.Insert);
				}
				else
				{
					for (int i = 0; i < this.grdNur7001.RowCount; i++)
					{
						if (this.grdNur7001.GetItemString(i, "measure_date").Replace("/", "").Replace("-", "") == EnvironInfo.GetSysDate().ToString("yyyyMMdd"))
						{
							count++;
						}
					}

					if (count == 0)
					{
						this.btnList.PerformClick(FunctionType.Insert);
					}
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
        }

        private void grdNur7001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNur7001.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNur7001.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
		#endregion

		#region Screen Load
        private string mHospCode = "";
		private void NUR7001U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.mHospCode = EnvironInfo.HospCode;
			this.CurrMSLayout = this.grdNur7001;
		
			if(this.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				this.flag       = this.OpenParam["flag"].ToString();
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.paBox.SetPatientID(patientInfo.BunHo);
					this.btnList.Focus();
				}
			}
	    }
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}
					if(this.paBox.BunHo.ToString() == "")
					{
						this.GetMessage("bunho");
						e.IsBaseCall = false;
						this.paBox.Focus();
					}
					else
					{
						GetQuery();
					}
					break;

				case FunctionType.Insert:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}
					if(this.paBox.BunHo.ToString().Trim() == "")
					{
						this.GetMessage("bunho");
						e.IsBaseCall = false;
					}
					
					this.CurrMSLayout = this.grdNur7001;
					
					if(this.grdNur7001.RowCount > 0)
					{
						int i = 0;
						for(i = 0; i < this.grdNur7001.RowCount; i++)
						{
							if(this.grdNur7001.LayoutTable.Rows[i].RowState == DataRowState.Added)
							{
								this.GetMessage("save");
								e.IsBaseCall = false;
                                return;
							}
						}
					}
                    e.IsBaseCall = false;
                    this.grdNur7001.InsertRow(this.grdNur7001.RowCount);
					break;

				case FunctionType.Update:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}
					if(this.grdNur7001.LayoutTable.Rows.Count > 0)
					{
						int i = 0;

						for(i = 0; i < this.grdNur7001.RowCount; i++)
						{
							if(this.grdNur7001.GetItemString(i, "measure_date").ToString().Trim() == "")
							{
								this.GetMessage("measure_date");
								e.IsBaseCall = false;
								this.grdNur7001.SetFocusToItem(this.grdNur7001.CurrentRowNumber, "measure_date");
								break;
							}

                            try
                            {

                                if (this.grdNur7001.GetItemInt(i, "bp_to") < this.grdNur7001.GetItemInt(i, "bp_from"))
                                {
                                    this.GetMessage("bp");
                                    e.IsBaseCall = false;
                                    this.grdNur7001.UnSelectAll();
                                    this.grdNur7001.SelectRow(i);
                                    this.emkBp_to.Focus();
                                    break;
                                }
                            }
                            catch { }

						   
						    
						    /* 원래주석
//							if(this.grdNur7001.GetItemString(i, "height").ToString().Trim() == "")
//							{
//								this.GetMessage("height");
//								e.IsBaseCall = false;
//								this.grdNur7001.SetFocusToItem(this.grdNur7001.CurrentRowNumber, "height");
//								break;
//							}
//
//							if(this.grdNur7001.GetItemString(i, "weight").ToString().Trim() == "")
//							{
//								this.GetMessage("weight");
//								e.IsBaseCall = false;
//								this.grdNur7001.SetFocusToItem(this.grdNur7001.CurrentRowNumber, "weight");
//								break;
//							}
                              */
						}
					}

                    //tungtx
			        if (e.IsBaseCall)
			        {
			            bool updateResult = SaveGrdNur7001();
			            SaveErrFullMsg = "";
			            if (updateResult)
			            {
                            if (this.flag == "Y")
                            {
                                this.flag = "S";
                            }
                            this.GetMessage("save_true");
			                mIsSaveSuccess = true;
                            this.grdNur7001.QueryLayout(false);
			            }
			            else
			            {
			                SaveErrFullMsg = Service.ErrFullMsg;
			                //SaveErrFullMsg = e.ErrMsg;
			                this.GetMessage("save_false");
			            }
			        }
					break;
				case FunctionType.Close:
					break;
				default:
					break;
			}
		}

	    private bool SaveGrdNur7001()
	    {
	        List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> inputList = GetListFromGrdNur7001();
            if (inputList == null || inputList.Count == 0)
	        {
	            return true;
	        }

            NuriNUR7001U00SaveLayoutArgs args = new NuriNUR7001U00SaveLayoutArgs(UserInfo.UserID, inputList);
	        UpdateResult result = CloudService.Instance.Submit<UpdateResult, NuriNUR7001U00SaveLayoutArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            return result.Result;
	        }
	        return false;
	    }

	    private List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> GetListFromGrdNur7001()
	    {
	        List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> dataList = new List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo>();
	        for (int i = 0; i < grdNur7001.RowCount; i++)
	        {
	            if (grdNur7001.GetRowState(i)  == DataRowState.Unchanged)
	            {
	                continue;
	            }

	            NuriNUR7001U00MeasurePhysicalConditionListItemInfo info = new NuriNUR7001U00MeasurePhysicalConditionListItemInfo();
                info.Bunho = grdNur7001.GetItemString(i, "bunho");
                info.MeasureDate = grdNur7001.GetItemString(i, "measure_date");
                info.Seq = grdNur7001.GetItemString(i, "seq");
                info.Height = grdNur7001.GetItemString(i, "height");
                info.Weight = grdNur7001.GetItemString(i, "weight");
                info.BpFrom = grdNur7001.GetItemString(i, "bp_from");
                info.BpTo = grdNur7001.GetItemString(i, "bp_to");
                info.BodyHeat = grdNur7001.GetItemString(i, "body_heat");
                info.Pulse = grdNur7001.GetItemString(i, "pulse");
                info.Suname = grdNur7001.GetItemString(i, "suname");
                info.Spo2 = grdNur7001.GetItemString(i, "spo2");
                info.MeasureTime = grdNur7001.GetItemString(i, "measure_time");
                info.Breath = grdNur7001.GetItemString(i, "breath");
                info.UpdId = grdNur7001.GetItemString(i, "upd_id");
	            info.RowState = grdNur7001.GetRowState(i).ToString();

                dataList.Add(info);
	        }

            if (grdNur7001.DeletedRowTable != null && grdNur7001.DeletedRowTable.Rows.Count > 0)
	        {
                foreach (DataRow row in grdNur7001.DeletedRowTable.Rows)
	            {
                    NuriNUR7001U00MeasurePhysicalConditionListItemInfo info = new NuriNUR7001U00MeasurePhysicalConditionListItemInfo();
	                info.Bunho = row["bunho"].ToString();
                    info.MeasureDate = row["measure_date"].ToString();
                    info.Seq = row["seq"].ToString();
	                info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
	            }
	        }
	        return dataList;
	    }

	    #endregion

		#region 버튼리스트에서 버튼 클릭 후 이벤트
        private bool mIsSaveSuccess = true;
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if (this.paBox.BunHo.ToString().Trim() != "")
					{
						this.grdNur7001.AcceptData();
						this.grdNur7001.SetItemValue(this.grdNur7001.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString().Trim());
						this.grdNur7001.SetItemValue(this.grdNur7001.CurrentRowNumber, "suname", this.paBox.SuName.ToString());
						this.grdNur7001.SetItemValue(this.grdNur7001.CurrentRowNumber, "measure_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
						this.grdNur7001.SetItemValue(this.grdNur7001.CurrentRowNumber, "measure_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
						this.emkHeight.Focus();
					}
					break;

                case FunctionType.Update:
                    //tungtx
                    //to be deleted

                    //mIsSaveSuccess = e.IsSuccess;
                    break;

				default:
					break;
			}
		}
		#endregion

		#region 환자를 선택을 하고 난 후 이벤트
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				GetQuery();
			}
		}
		#endregion

		#region 저장 후 이벤트
        String SaveErrFullMsg;
        private void grdNur7001_SaveEnd(object sender, SaveEndEventArgs e)
        {
            //SaveErrFullMsg = "";
            //if (e.IsSuccess)
            //{
            //    this.grdNur7001.QueryLayout(false);

            //    if (this.flag == "Y")
            //    {
            //        this.flag = "S";
            //    }
            //    this.GetMessage("save_true");
            //    return;
            //}
            //else
            //{
            //    SaveErrFullMsg = Service.ErrFullMsg;
            //    //SaveErrFullMsg = e.ErrMsg;
            //    this.GetMessage("save_false");
            //    return;
            //}

        }
		#endregion

		#region 사용자변경이 있을 때
		private void NUR7001U00_UserChanged(object sender, System.EventArgs e)
		{
			this.CurrMSLayout = this.grdNur7001;
		
			if(this.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
				this.flag       = this.OpenParam["flag"].ToString();
			}
		}
		#endregion

        #region XSavePerformer

//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private NUR7001U00 parent = null;
//            //private BindVarCollection bc;

//            public XSavePerformer(NUR7001U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, IHIS.Framework.RowDataItem item)
//            {
//                //string cmdText = "";
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                //tungtx
//                bool executeOk = false;
//                switch (item.RowState)
//                {
//                    case DataRowState.Added:

////                        cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1
////                                      FROM NUR7001
////                                     WHERE HOSP_CODE = :f_hosp_code
////                                       AND BUNHO = :f_bunho
////                                       AND MEASURE_DATE = TO_DATE(:f_measure_date, 'YYYY/MM/DD')";

////                        Object retSeq = Service.ExecuteScalar(cmdText, item.BindVarList);
////                        item.BindVarList.Add("f_new_seq",retSeq.ToString());

////                        cmdText = @"INSERT INTO NUR7001 (SYS_DATE       , SYS_ID      ,  UPD_ID,      HOSP_CODE, 
////                                                         UPD_DATE       , BUNHO       ,
////                                                         MEASURE_DATE   , SEQ         ,
////                                                         VALD           , HEIGHT      , 
////                                                         WEIGHT         , BP_FROM     , 
////                                                         BP_TO          , BODY_HEAT   ,
////                                                         PULSE          , SPO2        ,
////                                                         MEASURE_TIME   , BREATH)
////                                    VALUES              (SYSDATE        , :q_user_id  , :q_user_id,  :f_hosp_code, 
////                                                         SYSDATE        , :f_bunho    ,
////                                                         TO_DATE(:f_measure_date, 'YYYY/MM/DD') , :f_new_seq  ,
////                                                         'Y'            , :f_height   ,
////                                                         :f_weight      , :f_bp_from  ,
////                                                         :f_bp_to       , :f_body_heat,
////                                                         :f_pulse       , :f_spo2     ,
////                                                         :f_measure_time, :f_breath)  ";

//                        //tungtx
//                        NuriNUR7001U00InsertNUR7001NewArgs argsInsert = new NuriNUR7001U00InsertNUR7001NewArgs();
//                        argsInsert.BodyHeat = item.BindVarList["f_body_heat"].VarValue;
//                        argsInsert.BpFrom = item.BindVarList["f_bp_from"].VarValue;
//                        argsInsert.BpTo = item.BindVarList["f_bp_to"].VarValue;
//                        argsInsert.Breath = item.BindVarList["f_breath"].VarValue;
//                        argsInsert.Bunho = item.BindVarList["f_bunho"].VarValue;
//                        argsInsert.Height = item.BindVarList["f_height"].VarValue;
//                        argsInsert.MeasureDate = item.BindVarList["f_measure_date"].VarValue;
//                        argsInsert.MeasureTime = item.BindVarList["f_measure_time"].VarValue;
//                        argsInsert.Pulse = item.BindVarList["f_pulse"].VarValue;
//                        argsInsert.Spo2 = item.BindVarList["f_spo2"].VarValue;
//                        argsInsert.UserId = item.BindVarList["q_user_id"].VarValue;
//                        argsInsert.Weight = item.BindVarList["f_weight"].VarValue;

//                        UpdateResult result =
//                            CloudService.Instance.Submit<UpdateResult, NuriNUR7001U00InsertNUR7001NewArgs>(argsInsert);
//                        executeOk = result.Result;

//                        break;

//                    case DataRowState.Modified:
////                        cmdText = @"UPDATE NUR7001
////                                       SET UPD_ID       = :q_user_id,
////                                           UPD_DATE     = SYSDATE,
////                                           BUNHO        = :f_bunho,
////                                           MEASURE_DATE = :f_measure_date,
////                                           SEQ          = :f_seq,
////                                           VALD         = 'Y',
////                                           HEIGHT       = :f_height,
////                                           WEIGHT       = :f_weight,
////                                           BP_FROM      = :f_bp_from,
////                                           BP_TO        = :f_bp_to,
////                                           BODY_HEAT    = :f_body_heat,
////                                           PULSE        = :f_pulse,
////                                           SPO2         = :f_spo2,
////                                           MEASURE_TIME = :f_measure_time,
////                                           BREATH       = :f_breath
////                                     WHERE HOSP_CODE    = :f_hosp_code 
////                                       AND BUNHO        = :f_bunho
////                                       AND MEASURE_DATE = TO_DATE(:f_measure_date, 'YYYY/MM/DD')
////                                       AND SEQ          = :f_seq  ";

//                        //XMessageBox.Show("f_measure_date : " + item.BindVarList["f_measure_date"].VarValue);

//                        //tungtx
//                        NuriNUR7001U00UpdateNUR7001Args argsUpdate = new NuriNUR7001U00UpdateNUR7001Args();
//                        argsUpdate.BodyHeat = item.BindVarList["f_body_heat"].VarValue;
//                        argsUpdate.BpFrom = item.BindVarList["f_bp_from"].VarValue;
//                        argsUpdate.BpTo = item.BindVarList["f_bp_to"].VarValue;
//                        argsUpdate.Breath = item.BindVarList["f_breath"].VarValue;
//                        argsUpdate.Bunho = item.BindVarList["f_bunho"].VarValue;
//                        argsUpdate.Height = item.BindVarList["f_height"].VarValue;
//                        argsUpdate.MeasureDate = item.BindVarList["f_measure_date"].VarValue;
//                        argsUpdate.MeasureTime = item.BindVarList["f_measure_time"].VarValue;
//                        argsUpdate.Pulse = item.BindVarList["f_pulse"].VarValue;
//                        argsUpdate.Spo2 = item.BindVarList["f_spo2"].VarValue;
//                        argsUpdate.UserId = item.BindVarList["q_user_id"].VarValue;
//                        argsUpdate.Weight = item.BindVarList["f_weight"].VarValue;
//                        argsUpdate.Seq = item.BindVarList["f_seq"].VarValue;

//                        UpdateResult updateResult =
//                            CloudService.Instance.Submit<UpdateResult, NuriNUR7001U00UpdateNUR7001Args>(argsUpdate);
//                        executeOk = updateResult.Result;

//                        break;

//                    case DataRowState.Deleted:
////                        cmdText = @"UPDATE NUR7001
////                                       SET UPD_ID       = :q_user_id,
////                                           UPD_DATE     = SYSDATE,
////                                           VALD         = 'N'
////                                     WHERE HOSP_CODE    = :f_hosp_code 
////                                       AND BUNHO        = :f_bunho
////                                       AND MEASURE_DATE = TO_DATE(:f_measure_date, 'YYYY/MM/DD')
////                                       AND SEQ          = :f_seq    ";

//                        //XMessageBox.Show("f_measure_date : " + item.BindVarList["f_measure_date"].VarValue);

//                        //tungtx
//                        NuriNUR7001U00UpdateValdStatusNUR7001Args argsDelete = new NuriNUR7001U00UpdateValdStatusNUR7001Args();
//                        argsDelete.Bunho = item.BindVarList["f_bunho"].VarValue;
//                        argsDelete.MeasureDate = item.BindVarList["f_measure_date"].VarValue;
//                        argsDelete.Seq = item.BindVarList["f_seq"].VarValue;
//                        argsDelete.UserId = item.BindVarList["q_user_id"].VarValue;

//                        UpdateResult deleteResult =
//                            CloudService.Instance.Submit<UpdateResult, NuriNUR7001U00UpdateValdStatusNUR7001Args>(argsDelete);
//                        executeOk = deleteResult.Result;

//                        break;
//                }
//                //return Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                //tungtx
//                return executeOk;
//            }
//        }
        #endregion

        private void NUR7001U00_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
            {
                e.Cancel = true;
                return;
            }
            
			if(this.flag == "S")
			{
				IHIS.Framework.IXScreen aScreen;
				aScreen = XScreen.FindScreen(sysid, screen);

				if (aScreen == null)
				{              
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add( "NUR7001U00", "7001");
		
					XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);

				}
				else
				{
					CommonItemCollection openParams  = new CommonItemCollection();
					openParams.Add("NUT7001U00", "7001");
					this.Close();
					aScreen.Command("NUR0104U00", openParams);
				}
			}
        }

        private void emk_Leave(object sender, EventArgs e)
        {

            XEditMask emkCtl = sender as XEditMask;

            if (!TypeCheck.IsInt(emkCtl.GetDataValue()))
            {
                emkCtl.SetDataValue(0);
                grdNur7001.SetItemValue(grdNur7001.CurrentRowNumber, emkCtl.Tag.ToString(), "0");
                
            }
        }


        #region CreateListParam, GetDataForManagePatient
        private IList<object[]> GetDataForManagePatient(BindVarCollection listVarCollection )
        {
            //listVarCollection["f_hosp_code"].VarValue = "K01";
            //listVarCollection["f_bunho"].VarValue = "000000870";

            NuriNUR7001U00MeasurePhysicalConditionArgs listItemArgs = new NuriNUR7001U00MeasurePhysicalConditionArgs();
            //listItemArgs.Bunho = "000000870";
            listItemArgs.Bunho = listVarCollection["f_bunho"].VarValue;
            
            NuriNUR7001U00MeasurePhysicalConditionResult result =
                CloudService.Instance.Submit<NuriNUR7001U00MeasurePhysicalConditionResult, NuriNUR7001U00MeasurePhysicalConditionArgs>(listItemArgs);
            

            IList<object[]> lstDataResult = new List<object[]>();
            
            if (result  != null)
            {
                List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> patientListItemInfo = result.MeasurePhysicalConditionListItem;

                foreach (NuriNUR7001U00MeasurePhysicalConditionListItemInfo managePatientInfo in patientListItemInfo)
                {
                    object[] data =
                    {
                        managePatientInfo .Bunho ,
                        managePatientInfo .MeasureDate,
                        managePatientInfo.Seq,
                        managePatientInfo.Height,
                        managePatientInfo.Weight,
                        managePatientInfo.BpFrom,
                        managePatientInfo.BpTo,
                        managePatientInfo.BodyHeat,
                        managePatientInfo.Pulse,
                        managePatientInfo.Suname,
                        managePatientInfo.Spo2,
                        managePatientInfo.MeasureTime,
                        managePatientInfo.Breath,
                        managePatientInfo.UpdId,
                    };
                    lstDataResult.Add(data);
                }
            }

            return lstDataResult;
        }

        private List<string> CreateListParam()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_hosp_code");
            lstParam.Add("f_bunho");
            return lstParam;
        }
        #endregion
    }    
}

