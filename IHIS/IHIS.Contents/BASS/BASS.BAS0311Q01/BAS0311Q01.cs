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
	/// BAS0311Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0311Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGrid grdBAS0311;
		private System.Windows.Forms.ToolTip toolTip1;
		private IHIS.Framework.XTextBox txtSearchWord;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.MultiLayout layReturn;
		private IHIS.Framework.MultiLayout layNuGroup;
        private IHIS.Framework.XTabControl tabNuGroup;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
		private System.ComponentModel.IContainer components;
        private const int maxRowpage = 200;

		public BAS0311Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            grdBAS0311.ParamList = new List<string>(new String[] { "f_search_word", "f_nu_group", "f_page_number", "f_offset" });
		    grdBAS0311.ExecuteQuery = ExecuteQueryGrdBAS0311;

		    layNuGroup.ExecuteQuery = LoadLayNuGroup;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0311Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdBAS0311 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.tabNuGroup = new IHIS.Framework.XTabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnList = new IHIS.Framework.XButtonList();
            this.layReturn = new IHIS.Framework.MultiLayout();
            this.layNuGroup = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0311)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNuGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtSearchWord);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AccessibleDescription = null;
            this.txtSearchWord.AccessibleName = null;
            resources.ApplyResources(this.txtSearchWord, "txtSearchWord");
            this.txtSearchWord.BackgroundImage = null;
            this.txtSearchWord.Name = "txtSearchWord";
            this.toolTip1.SetToolTip(this.txtSearchWord, resources.GetString("txtSearchWord.ToolTip"));
            this.txtSearchWord.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchWord_DataValidating);
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
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdBAS0311);
            this.xPanel2.Controls.Add(this.tabNuGroup);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // grdBAS0311
            // 
            resources.ApplyResources(this.grdBAS0311, "grdBAS0311");
            this.grdBAS0311.ApplyPaintEventToAllColumn = true;
            this.grdBAS0311.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdBAS0311.ColPerLine = 7;
            this.grdBAS0311.Cols = 7;
            this.grdBAS0311.ExecuteQuery = null;
            this.grdBAS0311.FixedRows = 1;
            this.grdBAS0311.HeaderHeights.Add(34);
            this.grdBAS0311.Name = "grdBAS0311";
            this.grdBAS0311.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0311.ParamList")));
            this.grdBAS0311.ReadOnly = true;
            this.grdBAS0311.Rows = 2;
            this.grdBAS0311.RowStateCheckOnPaint = false;
            this.toolTip1.SetToolTip(this.grdBAS0311, resources.GetString("grdBAS0311.ToolTip"));
            this.grdBAS0311.ToolTipActive = true;
            this.grdBAS0311.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdBAS0311_MouseDown);
            this.grdBAS0311.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdBAS0311_GridCellPainting);
            this.grdBAS0311.PreEndInitializing += new System.EventHandler(this.grdBAS0311_PreEndInitializing);
            this.grdBAS0311.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0311_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sg_ymd";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "sg_code";
            this.xEditGridCell2.CellWidth = 91;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sg_name";
            this.xEditGridCell3.CellWidth = 250;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sg_name_eng";
            this.xEditGridCell4.CellWidth = 304;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bun_code";
            this.xEditGridCell5.CellWidth = 57;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "group_gubun";
            this.xEditGridCell9.CellWidth = 59;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "danui";
            this.xEditGridCell10.CellWidth = 45;
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bulyong_ymd";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 110;
            this.xEditGridCell11.Col = 6;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsJapanYearType = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowForeColor = IHIS.Framework.XColor.XGridAlterateRowBackColor;
            this.xEditGridCell12.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell12.CellName = "select_yn";
            this.xEditGridCell12.CellWidth = 55;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowForeColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell12.SelectedForeColor = IHIS.Framework.XColor.XGridSelectedCellBackColor;
            // 
            // tabNuGroup
            // 
            this.tabNuGroup.AccessibleDescription = null;
            this.tabNuGroup.AccessibleName = null;
            resources.ApplyResources(this.tabNuGroup, "tabNuGroup");
            this.tabNuGroup.BackgroundImage = null;
            this.tabNuGroup.Font = null;
            this.tabNuGroup.IDEPixelArea = true;
            this.tabNuGroup.IDEPixelBorder = false;
            this.tabNuGroup.Name = "tabNuGroup";
            this.toolTip1.SetToolTip(this.tabNuGroup, resources.GetString("tabNuGroup.ToolTip"));
            this.tabNuGroup.SelectionChanged += new System.EventHandler(this.tabNuGroup_SelectionChanged);
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.F7, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip1.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layReturn
            // 
            this.layReturn.ExecuteQuery = null;
            this.layReturn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReturn.ParamList")));
            // 
            // layNuGroup
            // 
            this.layNuGroup.ExecuteQuery = null;
            this.layNuGroup.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layNuGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layNuGroup.ParamList")));
            this.layNuGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNuGroup_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "nu_group";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "nu_group_name";
            // 
            // BAS0311Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0311Q01";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0311Q01_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0311Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0311)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNuGroup)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

        private MultiLayout mReturnLayout = new MultiLayout(); /* 리턴할 레이아웃 */
        private bool Multiselect = false;
		
		#endregion

		#region Screen Open

        string t_chungguseo = "02";
		private void BAS0311Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
			/* Fix 컬럼 설정 */
			this.grdBAS0311.FixedCols = 2;

			/* Open Param 설정 */
           
			if (this.OpenParam != null)
			{
                if (this.OpenParam.Contains("Multiselect"))
                {
                    this.Multiselect = ((bool)this.OpenParam["Multiselect"]);
                }
				// 적용일자(없으면 서비스에서 SysDate 적용 
				if (this.OpenParam.Contains("sg_ymd"))
				{
                    this.layNuGroup.SetBindVarValue("sg_ymd", this.OpenParam["sg_ymd"].ToString());
					this.grdBAS0311.SetBindVarValue("f_sg_ymd", this.OpenParam["sg_ymd"].ToString());
				}

				// 검색단어(점수코드, 점수명칭)
				if (this.OpenParam.Contains("search_word"))
				{
					this.txtSearchWord.SetDataValue(this.OpenParam["search_word"].ToString());
                    this.grdBAS0311.SetBindVarValue("search_word", this.OpenParam["search_word"].ToString());
				}

				// 보험종별(진료구분을 조회해 오기 위한 보험종별)
                //if (this.OpenParam.Contains("gubun"))
                //{
                //    //this.dsvNuGroup.SetInValue("gubun", this.OpenParam["gubun"].ToString());
                //    string gubun = this.OpenParam["gubun"].ToString();
                //    /* 자배일경우 */
                //    if (gubun == "C1" || gubun == "C2")
                //    {
                //        /* 자배 레셉토 기준 로드 */
                //        t_chungguseo = "07";
                //    }
                //    /* 노재일 경우 */
                //    else if (gubun == "E1" || gubun == "E2")
                //    {
                //        /* 노재 레셉토 기준 로드 */
                //        t_chungguseo = "05";
                //    }
                //    /* 그밖의 경우 */
                //    else
                //    {
                //        /* 그외의 모든경우는 보험 기준 */
                //        t_chungguseo = "02";
                //    }
                //}
			}

			this.layReturn = this.grdBAS0311.CloneToLayout();

			this.MakeNuGroupTab();
		}

		#endregion

		#region Screen Closing

		private void BAS0311Q01_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if ((this.mReturnLayout != null) && (this.layReturn.RowCount > 0))
			{
                CommonItemCollection param = new CommonItemCollection();
				param.Add("BAS0311", this.layReturn);
				param.Add("sg_name", this.layReturn.GetItemString(0, "sg_name"));
                ((XScreen)this.Opener).Command("BAS0311Q01", param);
			}
		}

		#endregion

		#region TextBox

		private void txtSearchWord_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "")
                this.LoadBAS0311();
			else
				this.grdBAS0311.Reset();
		}

		#endregion

		#region XEditGrid

		#region 셀 페인팅

		private void grdBAS0311_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (e.ColName == "sg_code" || e.ColName == "sg_name")
			{
				if (this.IsNotUseablePoint(e.RowNumber))
				{
					e.ForeColor = Color.Red;
					e.Font      = new Font("MS UI Gothic", 7, FontStyle.Strikeout);
				}

				// 사용안함
//				else if (this.grdBAS0311.GetItemString(e.RowNumber, "use_yn") != "Y")
//				{
//					e.ForeColor = Color.Red;
//				}
			}
		}

		#endregion

		#region MouseDown

        private bool IsExistSelectedRow(ref int aRowNumber)
        {
            for (int i = 0; i < this.grdBAS0311.RowCount; i++)
            {
                if (this.grdBAS0311.GetItemString(i, "select_yn") == "Y")
                {
                    aRowNumber = i;
                    return true;
                }
            }

            return false;
        }

        private void grdBAS0311_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid ;
			int rowNumber = -1;
            int selectedRow = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grd.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                if (grd.CurrentColName == "select_yn")
                {
                    if (this.Multiselect == false && this.IsExistSelectedRow(ref selectedRow) == true)
                    {
                        this.ClickGridCell(grd, selectedRow, false);
                    }

                    if (grd.GetItemString(rowNumber, "select_yn") == "Y")
                    {
                        if (this.Multiselect)
                        this.ClickGridCell(grd, rowNumber, false);
                    }
                    else
                    {
                        this.ClickGridCell(grd, rowNumber, true);
                    }
                }
            }

			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
                if (Multiselect == false)
                {

                } 
                else 
                {
				    rowNumber = grd.GetHitRowNumber(e.Y);

				    if (rowNumber < 0) return;

				    if (grd.CurrentColName != "select_yn")
				    {
					    this.ClickGridCell(grd, rowNumber, true);
				    }
                }
				this.MakeReturnLayout();
			}
		}

		#endregion

		#endregion

		#region Function

		#region 리턴할 레이아웃 생성

		private void MakeReturnLayout()
		{
			if (this.grdBAS0311.CurrentRowNumber < 0)
			{
				return;
			}
            this.layReturn.LayoutTable.ImportRow(this.grdBAS0311.LayoutTable.Rows[this.grdBAS0311.CurrentRowNumber]);
            //for(int i=0; i<this.grdBAS0311.RowCount; i++)
            //{
            //    if (this.grdBAS0311.GetItemString(i, "select_yn") == "Y")
            //        this.layReturn.LayoutTable.ImportRow(this.grdBAS0311.LayoutTable.Rows[i]);
            //}

			this.Close();
		}

		#endregion

		#region 누적그룹 탭 생성

		private void MakeNuGroupTab()
		{
			IHIS.X.Magic.Controls.TabPage tpgNuGroup;

			try
			{
				this.tabNuGroup.TabPages.Clear();
			}
			catch 
			{
				this.tabNuGroup.Refresh();
			}

			this.layNuGroup.QueryLayout(true);

			for (int i = 0; i<this.layNuGroup.RowCount; i++)
			{
				if (i == 0)
				{
					tpgNuGroup = new IHIS.X.Magic.Controls.TabPage(this.layNuGroup.GetItemString(i, "nu_group_name"), null, ImageList, 0);
				}
				else
				{
					tpgNuGroup = new IHIS.X.Magic.Controls.TabPage(this.layNuGroup.GetItemString(i, "nu_group_name"), null, ImageList, 1);
				}

				tpgNuGroup.Tag = this.layNuGroup.GetItemString(i, "nu_group");

				this.tabNuGroup.TabPages.Add(tpgNuGroup);
			}
		}

		#endregion

		#region 불용체크

		private bool IsNotUseablePoint(int aRowNumber)
		{
			if (this.grdBAS0311.GetItemString(aRowNumber, "bulyong_ymd") == "")
			{
				return false;
			}

			string sBulyongDate = this.grdBAS0311.GetItemString(aRowNumber, "bulyong_ymd");

			if (!TypeCheck.IsDateTime(sBulyongDate ))
			{
				return false;
			}

			if (!TypeCheck.IsDateTime(this.OpenParam["sg_ymd"].ToString()))
			{
				return false;
			}

			DateTime bulyongDate = DateTime.Parse(sBulyongDate);
			DateTime queryDate   = DateTime.Parse(this.OpenParam["sg_ymd"].ToString());

			if (bulyongDate <= queryDate)
			{
				return true;
			}

			return false;
		}

		#endregion

		#region Click Grid Cell

		private void ClickGridCell(XEditGrid aGrid, int aRowNumber, bool aIsSelect)
		{
			if (aIsSelect == false)
			{
				aGrid.SetItemValue(aRowNumber, "select_yn", "N");
				aGrid[aRowNumber, "select_yn"].Image = ImageList.Images[1];
			}
			else
			{
				aGrid.SetItemValue(aRowNumber, "select_yn", "Y");
				aGrid[aRowNumber, "select_yn"].Image = ImageList.Images[0];
			}
		}

		#endregion

		#endregion

		#region DataLoad

		private void LoadBAS0311 ()
		{
            //Fix bug MED-12651
            if (this.tabNuGroup.SelectedTab == null)
            {
                this.grdBAS0311.SetBindVarValue("f_nu_group", "%");
            }
            else
                this.grdBAS0311.SetBindVarValue("f_nu_group", this.tabNuGroup.SelectedTab.Tag.ToString());
            this.grdBAS0311.QueryLayout(false);

            for (int i = 0; i < this.grdBAS0311.RowCount; i++)
            {
                this.grdBAS0311.SetItemValue(i, "select_yn", "N");
                this.grdBAS0311[i, "select_yn"].Image = ImageList.Images[1];
            }
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{

			switch (e.Func)
			{
				case FunctionType.Process :
					e.IsBaseCall = true;

					this.MakeReturnLayout();

					break;

				case FunctionType.Query :

					e.IsBaseCall = false;

					this.LoadBAS0311();

					break;

				case FunctionType.Reset :

					break;

				case FunctionType.Close :

					break;
			}
		}
		#endregion

		#region XTabControl
		private void tabNuGroup_SelectionChanged(object sender, System.EventArgs e)
		{
			if (this.tabNuGroup.SelectedTab == null)
			{
				return;
			}

			#region Image Index 변경

			foreach (IHIS.X.Magic.Controls.TabPage selectedTpg in this.tabNuGroup.TabPages)
			{
				if (this.tabNuGroup.SelectedTab == selectedTpg)
				{
					selectedTpg.ImageIndex = 0;
				}
				else
				{
					selectedTpg.ImageIndex = 1;
				}
			}

			#endregion

			if (this.txtSearchWord.GetDataValue() == "")
			{
				if (this.grdBAS0311.RowCount > 0)
				{
					this.grdBAS0311.Reset();
				}

				return;
			}
			else
			{
				this.LoadBAS0311();
			}
		}
		#endregion

        private void grdBAS0311_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0311.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0311.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue());

            //Pc 파일상에는 자배, 노재등의 경우가 있지만 클라이언트 로직상 i_gubun를 셋팅하고 있지않으므로 그외 경우로 셋팅
            this.grdBAS0311.SetBindVarValue("t_chungguseo", "02"); 
        }

        private void layNuGroup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNuGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode); 
            this.layNuGroup.SetBindVarValue("t_chungguseo", t_chungguseo); 
        }

        private void grdBAS0311_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //for (int i = 0; i < this.grdBAS0311.RowCount; i++)
            //{
            //    if (this.grdBAS0311.GetItemString(i, "select_yn") == "Y")
            //    {
            //        this.grdBAS0311[i, "select_yn"].Image = ImageList.Images[0];
            //    }
            //    else
            //    {
            //        this.grdBAS0311[i, "select_yn"].Image = ImageList.Images[1];
            //    }
            //}
        }

        private void grdBAS0311_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell10.ExecuteQuery = LoadComboOrdDanui;
        }

        #region connect to cloud service
        /// <summary>
        /// ExecuteQueryGrdBAS0311
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdBAS0311(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0311Q01GrdBAS0311Args vBAS0311Q01GrdBAS0311Args = new BAS0311Q01GrdBAS0311Args();
            vBAS0311Q01GrdBAS0311Args.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            vBAS0311Q01GrdBAS0311Args.NuGroup = bc["f_nu_group"] != null ? bc["f_nu_group"].VarValue : "";
            vBAS0311Q01GrdBAS0311Args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            vBAS0311Q01GrdBAS0311Args.Offset = maxRowpage.ToString();
            
            BAS0311Q01GrdBAS0311Result result = CloudService.Instance.Submit<BAS0311Q01GrdBAS0311Result, BAS0311Q01GrdBAS0311Args>(vBAS0311Q01GrdBAS0311Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0311Q01GrdBAS0311Info item in result.ItemInfo)
                {
                    object[] objects =
                    {
                        item.SgYmd,
                        item.SgCode,
                        item.SgName,
                        item.SgNameKana,
                        item.BunCode,
                        item.GroupGubun,
                        item.Danui,
                        item.BulyongYmd
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadLayNuGroup(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ComboNuGroupArgs args = new ComboNuGroupArgs();
            args.IsAll = true;
            ComboResult result = CacheService.Instance.Get<ComboNuGroupArgs, ComboResult>(args);
                //CacheService.Instance.Get<ComboNuGroupArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_OCS_COMBO_ORD_DANUI_GET_ALL_KEYS, args,
                //    delegate(ComboResult comboResult)
                //    {
                //        return comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success &&
                //               comboResult.ComboItem != null && comboResult.ComboItem.Count > 0;
                //    });
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
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

        private List<object[]> LoadComboOrdDanui(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ComboOrdDanuiArgs args = new ComboOrdDanuiArgs();
            args.IsAll = true;
            //ComboResult result =
            //    CacheService.Instance.Get<ComboOrdDanuiArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCS_COMBO_ORD_DANUI_GET_ALL_KEYS, args, delegate(ComboResult comboResult)
            //    {
            //        return comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success &&
            //               comboResult.ComboItem != null && comboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboOrdDanuiArgs, ComboResult>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
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
	}
}

