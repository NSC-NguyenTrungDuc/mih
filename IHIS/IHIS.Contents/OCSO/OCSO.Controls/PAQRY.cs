using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.OCSO.Properties;
using IHIS.Framework;

namespace IHIS.OCSO
{
	/// <summary>
	/// CHANGETIME에 대한 요약 설명입니다.
	/// </summary>
	public class PAQRY : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XMstGrid grdPa;
		private System.Windows.Forms.Timer timer1;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XTextBox tbxSuname;
		private IHIS.Framework.XLabel lab;
        private XComboItem xComboItem3;
        private XLabel lbTitle;
		private System.ComponentModel.IContainer components;


        #region field
        private string mBunho = "";
        private string mJubsuYn = "";
        private XEditGridCell xEditGridCell5;
        private string mOrderDate = "";
        #endregion


		public PAQRY()
		{
			InitializeComponent();

            //tungtx
            grdPa.ParamList = new List<string>(new String[] { "f_suname", "f_order_date", "f_jubsu_yn", "f_bunho", "f_gwa_name", "f_order_time" });
		    grdPa.ExecuteQuery = LoadDataGrdPa;
		}

		public PAQRY(string aOrderDate, string aJubsuYn)
		{
			InitializeComponent();

            //tungtx
            grdPa.ParamList = new List<string>(new String[] { "f_suname", "f_order_date", "f_jubsu_yn", "f_bunho", "f_gwa_name", "f_order_time" });
            grdPa.ExecuteQuery = LoadDataGrdPa;

            mOrderDate = aOrderDate;
            mJubsuYn = aJubsuYn;

            if (aJubsuYn == "Y")
            {
                lbTitle.Text = Resources.CPL_TEXT8;
                lbTitle.ForeColor = new XColor(Color.Crimson);
            }
            else
            {
                lbTitle.Text = Resources.CPL_TEXT9;
                lbTitle.ForeColor = new XColor(Color.Teal);
            }
		}

	    #region CloudService load data for controls

	    private List<object[]> LoadDataGrdPa(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        CPL2010U00PaqryGrdPaArgs args = new CPL2010U00PaqryGrdPaArgs();
	        args.Suname = bc["f_suname"] != null ? bc["f_suname"].VarValue : "";
	        args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
	        args.JubsuYn = bc["f_jubsu_yn"] != null ? bc["f_jubsu_yn"].VarValue : "";
	        args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
	        args.GwaName = bc["f_gwa_name"] != null ? bc["f_gwa_name"].VarValue : "";
	        args.OrderTime = bc["f_order_time"] != null ? bc["f_order_time"].VarValue : "";
	        args.MJubsuYn = mJubsuYn;
	        CPL2010U00PaqryGrdPaResult result =
	            CloudService.Instance.Submit<CPL2010U00PaqryGrdPaResult, CPL2010U00PaqryGrdPaArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (CPL2010U00PaqryGrdPaListItemInfo item in result.GrdPaList)
	            {
	                object[] objects =
	                {
	                    item.Bunho,
	                    item.Suname,
	                    item.InOutGubun,
	                    item.GwaName,
	                    item.OrderTime,
	                    item.TodayYn,
	                    item.ReserYn,
	                    item.DoctorName
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAQRY));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.lab = new IHIS.Framework.XLabel();
            this.tbxSuname = new IHIS.Framework.XTextBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdPa = new IHIS.Framework.XMstGrid();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTitle = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.lab);
            this.xPanel1.Controls.Add(this.tbxSuname);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // lab
            // 
            this.lab.AccessibleDescription = null;
            this.lab.AccessibleName = null;
            resources.ApplyResources(this.lab, "lab");
            this.lab.Font = null;
            this.lab.Image = null;
            this.lab.Name = "lab";
            // 
            // tbxSuname
            // 
            this.tbxSuname.AccessibleDescription = null;
            this.tbxSuname.AccessibleName = null;
            resources.ApplyResources(this.tbxSuname, "tbxSuname");
            this.tbxSuname.BackgroundImage = null;
            this.tbxSuname.Name = "tbxSuname";
            this.tbxSuname.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.tbxSuname_DataValidating);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, "HotPink"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdPa
            // 
            resources.ApplyResources(this.grdPa, "grdPa");
            this.grdPa.ApplyPaintEventToAllColumn = true;
            this.grdPa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell39,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell2,
            this.xEditGridCell1,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdPa.ColPerLine = 6;
            this.grdPa.ColResizable = true;
            this.grdPa.Cols = 7;
            this.grdPa.ControlBinding = true;
            this.grdPa.ExecuteQuery = null;
            this.grdPa.FixedCols = 1;
            this.grdPa.FixedRows = 1;
            this.grdPa.HeaderHeights.Add(35);
            this.grdPa.Name = "grdPa";
            this.grdPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPa.ParamList")));
            this.grdPa.RowHeaderVisible = true;
            this.grdPa.Rows = 2;
            this.grdPa.ToolTipActive = true;
            this.grdPa.DoubleClick += new System.EventHandler(this.grdPa_DoubleClick);
            this.grdPa.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPa_GridCellPainting);
            this.grdPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPa_QueryStarting);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "bunho";
            this.xEditGridCell39.CellWidth = 94;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.EnableSort = true;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "suname";
            this.xEditGridCell41.CellWidth = 65;
            this.xEditGridCell41.Col = 4;
            this.xEditGridCell41.EnableSort = true;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "in_out_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 107;
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "order_time";
            this.xEditGridCell1.CellWidth = 45;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.Mask = "##:##";
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "today_yn";
            this.xEditGridCell3.CellWidth = 73;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "N";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "Y";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Z";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "reser_yn";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "doctor_name";
            this.xEditGridCell5.CellWidth = 75;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTitle
            // 
            this.lbTitle.AccessibleDescription = null;
            this.lbTitle.AccessibleName = null;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbTitle.EdgeRounding = false;
            this.lbTitle.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Teal);
            this.lbTitle.Image = null;
            this.lbTitle.Name = "lbTitle";
            // 
            // PAQRY
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdPa);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Icon = null;
            this.Name = "PAQRY";
            this.Load += new System.EventHandler(this.PAQRY_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PAQRY_Closing);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.lbTitle, 0);
            this.Controls.SetChildIndex(this.grdPa, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.grdPa.QueryLayout(false);
		}

		private void grdPa_DoubleClick(object sender, System.EventArgs e)
		{
            if (this.grdPa.CurrentRowNumber < 0)
                return;

			mBunho = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"bunho");

			this.btnList.PerformClick(FunctionType.Process);
		}

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process : 

					mBunho = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber,"bunho");
					IXScreen screen = XScreen.FindScreen("CPLS", "CPL2010U00");

					if(screen != null)
					{
						IHIS.Framework.CommonItemCollection command = new CommonItemCollection();
						command.Add("bunho", mBunho);
						screen.Command("bunho", command);
					}

					e.IsBaseCall = false;
					e.IsSuccess = true;

					break;
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Query);
		}

		#region From Load/Closing

		private void PAQRY_Load(object sender, System.EventArgs e)
		{
			this.timer1.Start();
		}

		private void PAQRY_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//this.WindowState = FormWindowState.Minimized;
		}

		#endregion

		internal void SetBlood(string order_date, string jubsuState)
		{
			this.timer1.Stop();
            
            mJubsuYn = jubsuState;
            mOrderDate = order_date;

            if (mJubsuYn == "Y")
            {
                lbTitle.Text = Resources.CPL_TEXT8;
                lbTitle.ForeColor = new XColor(Color.Crimson);
            }
            else
            {
                lbTitle.Text = Resources.CPL_TEXT9;
                lbTitle.ForeColor = new XColor(Color.Teal);
            }
			this.grdPa.QueryLayout(false);
			this.timer1.Start();
		}

		private void grdPa_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( e.ColName == "today_yn" )
			{
                // 외래 : 당일실시 or 당일결과, 예약일,희망일 = sysdate
                if (this.grdPa.GetItemString(e.RowNumber, "today_yn") == "Z")
                    e.ForeColor = Color.Red;

                if (this.grdPa.GetItemString(e.RowNumber, "today_yn") == "Y")
                    e.ForeColor = Color.Blue;
			}
		}

		private void tbxSuname_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.grdPa.QueryLayout(false);
		}

		#region property
		public string Bunho
		{
			get { return mBunho;}
		}
		#endregion

        private void grdPa_QueryStarting(object sender, CancelEventArgs e)
        {

//            if (mJubsuYn == "Y")
//            {
//                grdPa.QuerySQL = @"SELECT A.BUNHO
//                                     , B.SUNAME
//                                     , A.IN_OUT_GUBUN
//                                     , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE) GWA_NAME
//                                     , DECODE(FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),NULL,A.ORDER_TIME,FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)) ORDER_TIME
//                                     , MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
//                                     , FN_SCH_RESER_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)          RESER_YN
//                                     , A.DOCTOR_NAME
//                                  FROM OUT0101 B
//                                     , CPL2010 A
//                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                   AND B.HOSP_CODE    = A.HOSP_CODE 
//                                   AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
//                                    OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
//                                   AND DECODE(A.JUBSU_DATE,NULL,'N','Y') LIKE :f_jubsu_yn
//                                   AND A.IN_OUT_GUBUN   = 'O'
//                                   AND B.BUNHO          = A.BUNHO
//                                   AND ((A.BUNHO        LIKE '%'||:f_bunho       ||'%')
//                                    OR  (B.SUNAME       LIKE '%'||:f_suname      ||'%')
//                                    --OR  (A.IN_OUT_GUBUN LIKE '%'||:f_in_out_gubun||'%')
//                                    OR  (A.GWA_NAME     LIKE '%'||:f_gwa_name    ||'%')
//                                    OR  (A.ORDER_TIME   LIKE '%'||:f_order_time  ||'%'))
//                                    GROUP BY A.BUNHO, B.SUNAME, A.IN_OUT_GUBUN, 
//                                             FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE), 
//                                             DECODE(FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),NULL,A.ORDER_TIME,FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)),  
//                                             FN_SCH_RESER_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),
//                                             A.DOCTOR_NAME
//
//                                 ORDER BY ORDER_TIME DESC";
//            }
//            else
//            {
//                grdPa.QuerySQL = @"SELECT A.BUNHO
//                                     , B.SUNAME
//                                     , A.IN_OUT_GUBUN
//                                     , FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE) GWA_NAME
//                                     , DECODE(FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),NULL,A.ORDER_TIME,FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)) ORDER_TIME
//                                     , MAX(FN_CPL_SPECIMEN_PRN_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003))   TODAY_YN
//                                     , FN_SCH_RESER_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)          RESER_YN
//                                     , A.DOCTOR_NAME
//                                  FROM OUT0101 B
//                                     , CPL2010 A
//                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                   AND B.HOSP_CODE    = A.HOSP_CODE 
//                                   AND ((A.ORDER_DATE     = TO_DATE(:f_order_date) AND A.RESER_DATE IS NULL )
//                                    OR  (A.RESER_DATE     = TO_DATE(:f_order_date) ))
//                                   AND DECODE(A.JUBSU_DATE,NULL,'N','Y') LIKE :f_jubsu_yn
//                                   AND A.IN_OUT_GUBUN   = 'O'
//                                   AND B.BUNHO          = A.BUNHO
//                                   AND ((A.BUNHO        LIKE '%'||:f_bunho       ||'%')
//                                    OR  (B.SUNAME       LIKE '%'||:f_suname      ||'%')
//                                    --OR  (A.IN_OUT_GUBUN LIKE '%'||:f_in_out_gubun||'%')
//                                    OR  (A.GWA_NAME     LIKE '%'||:f_gwa_name    ||'%')
//                                    OR  (A.ORDER_TIME   LIKE '%'||:f_order_time  ||'%'))
//                                    GROUP BY A.BUNHO, B.SUNAME, A.IN_OUT_GUBUN, 
//                                             FN_BAS_LOAD_GWA_NAME(A.GWA,SYSDATE), 
//                                             DECODE(FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),NULL,A.ORDER_TIME,FN_SCH_RESER_TIME(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003)),  
//                                             FN_SCH_RESER_YN(A.IN_OUT_GUBUN,A.FKOCS1003,A.FKOCS2003),
//                                             A.DOCTOR_NAME
//
//                                 ORDER BY ORDER_TIME";
//            }




            this.grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPa.SetBindVarValue("f_suname", tbxSuname.GetDataValue());            
            this.grdPa.SetBindVarValue("f_order_date", mOrderDate);
            this.grdPa.SetBindVarValue("f_jubsu_yn", mJubsuYn);

        }

        public void TimerControl(bool isStart)
        {
            if (isStart)
            {
                if(timer1.Enabled == false)
                    timer1.Start();
            }
            else
            {
                if(timer1.Enabled == true)
                    timer1.Stop();
            }
        }
	}
}
