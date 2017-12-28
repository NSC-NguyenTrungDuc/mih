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
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using System.Drawing.Printing;
using IHIS.INJS.Properties;

#endregion

namespace IHIS.INJS
{
	/// <summary>
	/// INJ1002U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INJ1002U01 : IHIS.Framework.XScreen
    {
        #region 자동생성
        private System.Windows.Forms.Panel pnlFill;
		private IHIS.Framework.XPatientBox patInfo;
		private System.Windows.Forms.Panel pnlButton;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XCalendar calInjReser;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XMstGrid grdOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.MultiLayout layReserDate;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell5;
        private XButton btnReserOrder;
        private IContainer components;
        #endregion
        private XButton btnPrintCalendar;
        private MultiLayoutItem multiLayoutItem1;

        private bool mIsSaveSuccess = true;

	    private const string CACHE_INJ1002U01_COMBO_LIST_ITEM_KEYS = "Cbo.xEditGridCell19.GrdOrder";

        #region 생성자
        public INJ1002U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            ChangeDisplay();

            this.grdOrder.ParamList = new List<string>(new String[] { "f_hosp_code", "f_bunho", "f_reser_date" });
            this.grdOrder.ExecuteQuery = LoadDataGrdOrder;

            this.layReserDate.ParamList = new List<string>(new String[] { "f_hosp_code", "f_bunho" });
            this.layReserDate.ExecuteQuery = LoadDataLayReserDate;
		}

        private void ChangeDisplay()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                IHIS.Framework.BizCodeHelper.ApplyCommonFont(grdOrder);

                grdOrder.AutoSizeColumn(xEditGridCell60.Col, 50);
                grdOrder.AutoSizeColumn(xEditGridCell25.Col, 50);
                grdOrder.AutoSizeColumn(xEditGridCell16.Col, 50);
                grdOrder.AutoSizeColumn(xEditGridCell8.Col, 50);
                
            }
        }

	    private IList<object[]> LoadDataLayReserDate(BindVarCollection varlist)
	    {
            IList<object[]> dataList = new List<object[]>();
	        INJ1002U01LayReserDateArgs args = new INJ1002U01LayReserDateArgs(varlist["f_bunho"].VarValue);
            INJ1002U01LayReserDateResult result =
                CloudService.Instance.Submit<INJ1002U01LayReserDateResult, INJ1002U01LayReserDateArgs>(args);
            if (result != null)
            {
                List<DataStringListItemInfo> grdList = result.ReserDate;
                if (grdList != null && grdList.Count > 0)
                {
                    foreach (DataStringListItemInfo info in grdList)
                    {
                        dataList.Add(new object[]
	                    {
	                       info.DataValue                    
	                    });
                    }
                }
            }

            return dataList;
	    }

	    private IList<object[]> LoadDataGrdOrder(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();

	        INJ1002U01GrdOrderArgs args = new INJ1002U01GrdOrderArgs(varlist["f_bunho"].VarValue,
	            varlist["f_reser_date"].VarValue);
	        INJ1002U01GrdOrderResult result =
	            CloudService.Instance.Submit<INJ1002U01GrdOrderResult, INJ1002U01GrdOrderArgs>(args);
	        if (result != null)
	        {
	            List<INJ1002U01GrdOrderListItemInfo> grdList = result.GrdOrderList;
	            if (grdList != null && grdList.Count > 0)
	            {
	                foreach (INJ1002U01GrdOrderListItemInfo info in grdList)
	                {
	                    dataList.Add(new object[]
	                    {
	                        info.GroupSer        ,              
                            info.Pkinj1002       ,               
                            info.Fkinj1001       ,               
                            info.Fkocs1003       ,               
                            info.HangmogName     ,              
                            info.Seq             ,               
                            info.TonggyeCode     ,              
                            info.MagamDate       ,              
                            info.MagamJangso     ,              
                            info.MagamSer        ,              
                            info.ReserDate       ,              
                            info.ReserTime       ,              
                            info.JubsuDate       ,              
                            info.HangmogCode     ,              
                            info.JusaBuui        ,              
                            info.ActingJangso    ,              
                            info.ActingDate      ,              
                            info.ActingTime      ,              
                            info.CompanyCode     ,              
                            info.LotNo           ,              
                            info.ChasuCode       ,              
                            info.PwResult        ,              
                            info.CsResult        ,              
                            info.Ast             ,               
                            info.ActingFlag      ,              
                            info.SunabSuryang    ,              
                            info.SunabDate       ,              
                            info.Fkout1001       ,               
                            info.CancerYn        ,              
                            info.Bunho           ,               
                            info.RemarkChk       ,              
                            info.DcYn            ,              
                            info.JusaTongCnt     ,             
                            info.OtherBuseoYn    ,             
                            info.Jujongja        ,               
                            info.JujongjaName    ,              
                            info.YebangJujongChk ,             
                            info.ActdayChk       ,              
                            info.FnBasLoadGwaName,           
                            info.BannabYn        ,              
                            info.SkinYn          ,              
                            info.ChungguDate     ,              
                            info.OrderDate       ,              
                            info.Doctor          ,               
                            info.OrdDanui        ,              
                            info.HopeDateYn      ,             
                            info.BogyongCode     ,              
                            info.Suryang         ,               
                            info.Dv              ,               
                            info.DvTime          ,              
                            info.SlipCode        ,              
                            info.FOrderDate      ,             
                            info.MixGroup        ,              
                            info.HopeDate        ,              
                            info.OrderGubun                           
	                    });
	                }
	            }
	        }

	        return dataList;
	    }

	    #endregion

        #region 소멸자
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
        #endregion

        #region Designer generated code
        /// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1002U01));
            this.pnlFill = new System.Windows.Forms.Panel();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.calInjReser = new IHIS.Framework.XCalendar();
            this.patInfo = new IHIS.Framework.XPatientBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnPrintCalendar = new IHIS.Framework.XButton();
            this.btnReserOrder = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.layReserDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calInjReser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patInfo)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "이름바꾸기.gif");
            this.ImageList.Images.SetKeyName(2, "주사실수행관리.ico");
            this.ImageList.Images.SetKeyName(3, "5.gif");
            this.ImageList.Images.SetKeyName(4, "sun.gif");
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.grdOrder);
            this.pnlFill.Controls.Add(this.calInjReser);
            this.pnlFill.Controls.Add(this.patInfo);
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // grdOrder
            // 
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell4,
            this.xEditGridCell30,
            this.xEditGridCell19,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell9,
            this.xEditGridCell34,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell21,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell18,
            this.xEditGridCell23,
            this.xEditGridCell15,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell24,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell22,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell16,
            this.xEditGridCell59,
            this.xEditGridCell17,
            this.xEditGridCell60,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell63,
            this.xEditGridCell3,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell5,
            this.xEditGridCell76});
            this.grdOrder.ColPerLine = 12;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 13;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(31);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrder_QueryEnd);
            this.grdOrder.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOrder_SaveEnd);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.PreEndInitializing += new System.EventHandler(this.grdOrder_PreEndInitializing);
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrder_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "group_ser";
            this.xEditGridCell8.CellWidth = 29;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell27.CellName = "pkinj1002";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell28.CellName = "fkinj1001";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell29.CellName = "fkocs1003";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.CellName = "hangmog_name";
            this.xEditGridCell4.CellWidth = 207;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.DisplayMemoText = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell30.CellName = "seq";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.CellName = "tonggye_code";
            this.xEditGridCell19.CellWidth = 129;
            this.xEditGridCell19.Col = 8;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell31.CellName = "magam_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell32.CellName = "magam_jangso";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell33.CellName = "magam_ser";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.ApplyPaintingEvent = true;
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 106;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell34.CellName = "reser_time";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.CellName = "jubsu_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 73;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.ApplyPaintingEvent = true;
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 75;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell35.CellName = "jusa_buui";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell36.CellName = "acting_jangso";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell37.CellName = "acting_date";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell38.CellName = "acting_time";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell39.CellName = "company_code";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell40.CellName = "lot_no";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "chasu_code";
            this.xEditGridCell21.CellWidth = 25;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell41.CellName = "pw_result";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell42.CellName = "cs_result";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell18.ApplyPaintingEvent = true;
            this.xEditGridCell18.CellName = "ast";
            this.xEditGridCell18.CellWidth = 27;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell23.ApplyPaintingEvent = true;
            this.xEditGridCell23.CellName = "acting_flag";
            this.xEditGridCell23.CellWidth = 27;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "sunab_suryang";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell15.CellWidth = 28;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell43.CellName = "sunab_date";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell44.CellName = "fkout1001";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell24.ApplyPaintingEvent = true;
            this.xEditGridCell24.CellName = "cancer_yn";
            this.xEditGridCell24.CellWidth = 50;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell45.CellName = "bunho";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell46.CellName = "remark_chk";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell47.CellName = "dc_yn";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell48.CellName = "jusa_tong_cnt";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell49.CellName = "other_buseo_yn";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell50.CellName = "jujongja";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.CellName = "jujongja_name";
            this.xEditGridCell22.CellWidth = 66;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell51.CellName = "yebang_jujong_chk";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsUpdCol = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell52.CellName = "actday_chk";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsUpdCol = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell53.CellName = "gwa";
            this.xEditGridCell53.CellWidth = 73;
            this.xEditGridCell53.Col = 10;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsUpdCol = false;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell54.CellName = "bannab_yn";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.IsUpdCol = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell55.CellName = "skin_yn";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.IsUpdCol = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell56.CellName = "chunggu_date";
            this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsUpdCol = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = 12;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell58.CellName = "doctor";
            this.xEditGridCell58.CellWidth = 121;
            this.xEditGridCell58.Col = 11;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.ApplyPaintingEvent = true;
            this.xEditGridCell16.CellName = "ord_danui";
            this.xEditGridCell16.CellWidth = 95;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell59.CellName = "hope_date_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "bogyong_code";
            this.xEditGridCell17.CellWidth = 49;
            this.xEditGridCell17.Col = 9;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "suryang";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell60.CellWidth = 130;
            this.xEditGridCell60.Col = 4;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell60.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell25.ApplyPaintingEvent = true;
            this.xEditGridCell25.CellName = "dv";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell25.CellWidth = 110;
            this.xEditGridCell25.Col = 6;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell26.ApplyPaintingEvent = true;
            this.xEditGridCell26.CellName = "dv_time";
            this.xEditGridCell26.CellWidth = 94;
            this.xEditGridCell26.Col = 5;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell63.CellName = "slip_code";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            this.xEditGridCell63.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "naewon_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "mix_group";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hope_date";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "order_gubun";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "old_acting_flag";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // calInjReser
            // 
//            resources.ApplyResources(this.calInjReser, "calInjReser");
            this.calInjReser.EnableMultiSelection = false;
//            this.calInjReser.Header.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold);
            this.calInjReser.ImageList = this.ImageList;
            this.calInjReser.MaxDate = new System.DateTime(2025, 10, 11, 0, 0, 0, 0);
            this.calInjReser.MinDate = new System.DateTime(1995, 10, 11, 0, 0, 0, 0);
            this.calInjReser.Name = "calInjReser";
            this.calInjReser.WeekDays.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.calInjReser.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calInjReser_DaySelected);
            // 
            // patInfo
            // 
            this.patInfo.AccessibleDescription = null;
            this.patInfo.AccessibleName = null;
            resources.ApplyResources(this.patInfo, "patInfo");
            this.patInfo.BackgroundImage = null;
            this.patInfo.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.patInfo.Name = "patInfo";
            this.patInfo.PatientSelectionFailed += new System.EventHandler(this.patInfo_PatientSelectionFailed);
            this.patInfo.PatientSelected += new System.EventHandler(this.patInfo_PatientSelected);
            // 
            // pnlButton
            // 
            this.pnlButton.AccessibleDescription = null;
            this.pnlButton.AccessibleName = null;
            resources.ApplyResources(this.pnlButton, "pnlButton");
            this.pnlButton.BackgroundImage = null;
            this.pnlButton.Controls.Add(this.btnPrintCalendar);
            this.pnlButton.Controls.Add(this.btnReserOrder);
            this.pnlButton.Controls.Add(this.xButtonList1);
            this.pnlButton.Font = null;
            this.pnlButton.Name = "pnlButton";
            // 
            // btnPrintCalendar
            // 
            this.btnPrintCalendar.AccessibleDescription = null;
            this.btnPrintCalendar.AccessibleName = null;
            resources.ApplyResources(this.btnPrintCalendar, "btnPrintCalendar");
            this.btnPrintCalendar.BackgroundImage = null;
            this.btnPrintCalendar.Font = null;
            this.btnPrintCalendar.Image = global::IHIS.INJS.Properties.Resources.출력;
            this.btnPrintCalendar.Name = "btnPrintCalendar";
            this.btnPrintCalendar.Click += new System.EventHandler(this.btnPrintCalendar_Click);
            // 
            // btnReserOrder
            // 
            this.btnReserOrder.AccessibleDescription = null;
            this.btnReserOrder.AccessibleName = null;
            resources.ApplyResources(this.btnReserOrder, "btnReserOrder");
            this.btnReserOrder.BackgroundImage = null;
            this.btnReserOrder.Font = null;
            this.btnReserOrder.Image = global::IHIS.INJS.Properties.Resources.출력;
            this.btnReserOrder.Name = "btnReserOrder";
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
            // layReserDate
            // 
            this.layReserDate.ExecuteQuery = null;
            this.layReserDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1});
            this.layReserDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserDate.ParamList")));
            this.layReserDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserDate_QueryStarting);
            this.layReserDate.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserDate_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "reser_date";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // INJ1002U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButton);
            this.Font = null;
            this.Name = "INJ1002U01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.INJ1002U01_Closing);
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calInjReser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patInfo)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).EndInit();
            this.ResumeLayout(false);

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
				this.patInfo.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(patInfo.BunHo))
			{
				return new XPatientInfo(patInfo.BunHo, patInfo.SuName, "", "", this.ScreenName);
			}
			return null;
		}
		#endregion

		#region Common Method Variable

        private string mHospCode = "";

        // メイン画面から渡された日付
        private string queryDate = "";

        //現在選択されている日付
        private string mCurrentDate = "";

        //新しく選択した日付
        private string mNewReserDate = "";
		#endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            mHospCode = EnvironInfo.HospCode;
            //this.grdOrder.SavePerformer = new XSavePerformer(this);

            if (this.OpenParam != null) this.queryDate = this.OpenParam["queryDate"].ToString();

            // 환자번호 입력되면 예약날짜 조회해서 달력 셋팅됨.
			if (this.OpenParam != null ) this.patInfo.SetPatientID(this.OpenParam["bunho"].ToString());
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null) this.patInfo.SetPatientID(patientInfo.BunHo);
            }
        }
        #endregion

        #region xButtonList1_ButtonClick
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:

					calInjReser.ResetCalendarDates();
					grdOrder.Reset();

					this.layReserDate.QueryLayout(true);
					break;

                case FunctionType.Update:

                    //if(this.checkReserDate()) this.grdOrder.SaveLayout();
			        if (this.checkReserDate())
			        {
			            try
			            {
			                List<INJ1002U01GrdOrderListItemInfo> inputList = GetListFromGrdorder();
			                INJ1002U01SaveLayoutArgs args = new INJ1002U01SaveLayoutArgs(inputList);
			                UpdateResult result = CloudService.Instance.Submit<UpdateResult, INJ1002U01SaveLayoutArgs>(args);
			                if (result == null ||  result.Result == false)
			                {
			                    MessageBox.Show("Save failed! Error: " + result.Msg);
			                }
			                else
			                {
			                    this.xButtonList1.PerformClick(FunctionType.Query);
			                }
			            }
			            catch (Exception ex)
			            {
							//https://sofiamedix.atlassian.net/browse/MED-10610
			                //MessageBox.Show(ex.Message);
			            }
			        }
			        break;

				default:
					break;
			}		
		}

	    private List<INJ1002U01GrdOrderListItemInfo> GetListFromGrdorder()
	    {
	        List<INJ1002U01GrdOrderListItemInfo> dataList = new List<INJ1002U01GrdOrderListItemInfo>();
	        for (int i = 0; i < grdOrder.RowCount; i++)
	        {
	            INJ1002U01GrdOrderListItemInfo info = new INJ1002U01GrdOrderListItemInfo();
	            info.ReserDate = grdOrder.GetItemString(i, "reser_date");
                info.Pkinj1002 = grdOrder.GetItemString(i, "pkinj1002");
                dataList.Add(info);
	        }
	        return dataList;
	    }

	    #endregion

		#region PatientBox
		private void patInfo_PatientSelected(object sender, System.EventArgs e)
		{
            this.layReserDate.QueryLayout(true);
		}

		private void patInfo_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			calInjReser.ResetCalendarDates();
			grdOrder.Reset();
		}
		#endregion

        #region layReserDate
        private void layReserDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserDate.SetBindVarValue("f_bunho", this.patInfo.BunHo);
        }

        private void layReserDate_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.calInjReser.ResetCalendarDates();
            
            //달력 그리기 잠시보류
            this.calInjReser.Redraw = false;
            IHIS.Framework.XCalendarDate date = null;

            if (e.IsSuccess)
            {
                if (this.layReserDate.LayoutTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in this.layReserDate.LayoutTable.Rows)
                    {
                        date = new XCalendarDate(DateTime.Parse(dr["reser_date"].ToString()));
                        //date.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PowderBlue);
                        //date.ContentAlign = System.Drawing.ContentAlignment.BottomLeft;
                        //date.ContentFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        //date.ContentText = "予約";
                        //date.ContentTextColor = new IHIS.Framework.XColor(System.Drawing.Color.DarkBlue);
                        date.ImageIndex = 4;
                        date.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        calInjReser.Dates.Add(date);
                    }
                }

                //오늘 날짜 선택해주기
                //string ds = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                //this.calInjReser.SetActiveMonth(int.Parse(ds.Substring(0, 4)), int.Parse(ds.Substring(5, 2)));
                //DateTime dt = DateTime.Parse(ds);
                //this.calInjReser.SelectDate(dt);

                // メイン画面から渡された日付を設定する。
                string ds = this.queryDate;
                if (!String.IsNullOrEmpty(ds))
                {
                    this.calInjReser.SetActiveMonth(int.Parse(ds.Substring(0, 4)), int.Parse(ds.Substring(5, 2)));
                    DateTime dt = DateTime.Parse(ds);
                    this.calInjReser.SelectDate(dt);
                }
                //this.calInjReser.SetActiveMonth(int.Parse(ds.Substring(0, 4)), int.Parse(ds.Substring(5, 2)));
                //DateTime dt = DateTime.Parse(ds);
                //this.calInjReser.SelectDate(dt);
            }

            //Redraw
            this.calInjReser.Redraw = true;

        }
		#endregion

        #region [calInjReser Event]

        private void calInjReser_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
            //this.mCurrentDate = e.DateItems[0].Date.ToString().Substring(0, 10);
            this.mCurrentDate = e.DateItems[0].Date.ToString("yyyy/MM/dd");

            grdOrder.QueryLayout(true);
        }

        //private void calInjReser_DayDoubleClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        //{
        //    //XCalendarDate item = calInjReser.Dates[e.DateItem.Date];
        //    //if (TypeCheck.IsNull(item)) return;

        //    //item.ImageIndex = 0;
        //    //calInjReser.Refresh();
        //}

        private bool checkReserDate()
        {
            bool returnVal = true;

            if(this.mNewReserDate.Equals("")) return false;

            int reserCnt = this.layReserDate.RowCount;
            if (reserCnt < 1) returnVal = false;
            else
            {
                for (int i = 0; i < reserCnt; i++)
                {
                    if (this.mNewReserDate.Equals(this.layReserDate.GetItemString(i, "reser_date")))
                        if (XMessageBox.Show(Resources.INJ1002U01_TEXT_SAVE_HK, Resources.INJ1002U01_TEXT_SAVE, MessageBoxButtons.OKCancel) != DialogResult.OK) returnVal = false;
                }

                int newDay = int.Parse(this.mNewReserDate.Replace("/", ""));
                int curDay = int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd"));

                string mixGroup = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "mix_group");
                if (curDay > newDay)
                {
                    XMessageBox.Show(Resources.INJ1002U01_TEXT_CNK, Resources.INJ1002U01_checkReserDate_予約日付選択, MessageBoxIcon.Warning);

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (mixGroup.Equals(this.grdOrder.GetItemString(i, "mix_group"))) this.grdOrder.SetItemValue(i, "reser_date", this.mCurrentDate);
                    }

                    returnVal = false;
                }
            }

            return returnVal;
        }
        #endregion

        private string mMsg = "";
        private string mCap = "";

        #region grdOrder 관련
        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrder.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdOrder.SetBindVarValue("f_bunho", this.patInfo.BunHo);
            grdOrder.SetBindVarValue("f_reser_date", this.mCurrentDate);
        }

        private void grdOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);

            // NEW予約日付を初期化
            this.mNewReserDate = "";
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "reser_date")
            {
                this.mNewReserDate = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "reser_date");

                string mixGroup = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "mix_group");

                for (int i = 0; i < this.grdOrder.RowCount; i++)
                {
                    // 
                    if (!TypeCheck.IsNull(mixGroup) && mixGroup.Equals(this.grdOrder.GetItemString(i, "mix_group"))) this.grdOrder.SetItemValue(i, "reser_date", this.mNewReserDate);
                }
            }
        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "hangmog_name")
            {
                if (e.DataRow["acting_date"].ToString() != "")
                    e.BackColor = Color.DeepSkyBlue;
            }
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            switch (e.ColName)
            {
                case "reser_date":
                    if (e.DataRow["acting_date"].ToString() != "")
                    {
                        e.Protect = true;
                        return;
                    }
                    break;
            }
            e.Protect = false;
        }

        private void grdOrder_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                DateTime selectedDate = EnvironInfo.GetSysDate();
                if (this.calInjReser.SelectedDays.Count > 0)
                {
                    selectedDate = this.calInjReser.SelectedDays[0].Date;
                }
                xButtonList1.PerformClick(FunctionType.Query);

                this.calInjReser.SelectDate(selectedDate);

                grdOrder.SetBindVarValue("f_hosp_code", this.mHospCode);
                grdOrder.SetBindVarValue("f_bunho", this.patInfo.BunHo);
                grdOrder.SetBindVarValue("f_reser_date", selectedDate.ToString("yyyy/MM/dd"));
                grdOrder.QueryLayout(false);

                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ1002U01_TEXT_SAVE_COMPLETE : "保存が完了しました。";

                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ1002U01_TEXT_SAVE_CAP : "保存完了";

                // NEW予約日付を初期化
                this.mNewReserDate = "";
            }
            else
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? Resources.INJ1002U01_TEXT_SAVE_FAILURE : "保存に失敗しました。";

                this.mMsg += "\r\n" + Service.ErrFullMsg;

                this.mCap = NetInfo.Language == LangMode.Ko ? Resources.INJ1002U01_SAVE_TB_CAP : "保存失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_date").ToString().Trim() == aGrd.GetItemValue(j, "order_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

/*        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            private INJ1002U01 parent;

            public XSavePerformer(INJ1002U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                cmdText = @"DECLARE
                              IO_MSG  VARCHAR(300);
                              IO_FLAG VARCHAR(1);
                            BEGIN
                                 UPDATE INJ1002
                                    SET RESER_DATE = TO_DATE(:f_reser_date,'YYYY/MM/DD')
                                  WHERE HOSP_CODE   = :f_hosp_code
                                    AND PKINJ1002  = :f_pkinj1002
                                    AND NVL(ACTING_FLAG, 'N')    = 'N';

                              FOR C1 IN (
                                SELECT B.FKOCS1003 FKOCS1003
                                  FROM INJ1001 B,
                                       INJ1002 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND B.HOSP_CODE = A.HOSP_CODE
                                   AND A.PKINJ1002 = :f_pkinj1002
                                   AND B.PKINJ1001 = A.FKINJ1001
                                   AND NVL(A.ACTING_FLAG, 'N')    = 'N'
                                   --AND B.ACT_DATE IS NULL  --실행된 오더는 안바뀌게
                              )LOOP
                                PR_OCS_UPDATE_HOPE_DATE('O',C1.FKOCS1003 ,TO_DATE(:f_reser_date,'YYYY/MM/DD'),IO_MSG, IO_FLAG);
                              END LOOP;
                            END;";
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion*/

        private Font printFont;
        private Font printBigFont;
        private void btnPrintCalendar_Click(object sender, EventArgs e)
        {
            //프린트 할 내용을 담을 객체 선언
            PrintDocument printDoc = new PrintDocument();
            PageSettings pSettings = new System.Drawing.Printing.PageSettings();

            //인치로 바꿔줘야함 .. 아오
            double inchX = 148 / 25.4;
            double inchY = 210 / 25.4;
            //double inchX = 148 / 27;
            //double inchY = 210 / 27;

            printFont = new Font("MS UI Gothic", 13);
            printBigFont = new Font("MS UI Gothic", 18);

            //픽셀1748, 2480. mm: 210, 148 //둘다아니고 밀리인치임...아오
            pSettings.PaperSize = new PaperSize("custom_A5", (int)(100 * inchX), (int)(100 * inchY));
            pSettings.PaperSize.RawKind = 11; //이게 프린트 종이 싸이즈설정인듯 a5
            printDoc.DefaultPageSettings = pSettings;

            printDoc.PrintPage += new PrintPageEventHandler(this.PrintCal);

            //프린터로 내용 출력
            printDoc.Print();
        }

        private void PrintCal(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString("注射予約カレンダー", printBigFont, Brushes.Black, 165, 25, new StringFormat());

            ev.Graphics.DrawString("患者番号：" + this.patInfo.BunHo, printFont, Brushes.Black, 80, 106, new StringFormat());
            ev.Graphics.DrawString(this.patInfo.SuName + " 様", printBigFont, Brushes.Black, 270, 100, new StringFormat());
            

            Bitmap bmp;
			bmp = this.calInjReser.Snapshot();
            //Bitmap bmpScaled = new Bitmap(bmp, (int)(bmp.Size.Width * 70 / 100), (int)(bmp.Size.Height * 70 / 100));

            ev.Graphics.DrawImage(bmp, 75, 180, bmp.Width, bmp.Height);
            ev.Graphics.DrawString("発行日　" + EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), printFont, Brushes.Black, 50, 680, new StringFormat());
            ev.Graphics.DrawString("岡 田 病 院", printBigFont, Brushes.Black, 380, 650, new StringFormat());
            ev.Graphics.DrawString("電話　03-3891-2231(代)", printFont, Brushes.Black, 340, 680, new StringFormat());

            ev.HasMorePages = false;
            bmp.Dispose();
            //bmpScaled.Dispose();
        }

        private void INJ1002U01_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
                e.Cancel = true;

            this.mIsSaveSuccess = true;
        }

        private void grdOrder_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell19.ExecuteQuery = LoadDataXEditGridCell19;
        }

	    private IList<object[]> LoadDataXEditGridCell19(BindVarCollection varlist)
	    {
	        IList<object[]> dataList = new List<object[]>();
            INJ1002U01LoadComboBoxArgs args = new INJ1002U01LoadComboBoxArgs();
            //INJ1002U01LoadComboBoxResult result =
            //    CacheService.Instance.Get<INJ1002U01LoadComboBoxArgs, INJ1002U01LoadComboBoxResult>(
            //        CACHE_INJ1002U01_COMBO_LIST_ITEM_KEYS, args);
            INJ1002U01LoadComboBoxResult result = CacheService.Instance.Get<INJ1002U01LoadComboBoxArgs, INJ1002U01LoadComboBoxResult>(args);
	        if (result != null)
	        {
	            List<ComboListItemInfo> cboList = result.CboList;
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
    }
}

