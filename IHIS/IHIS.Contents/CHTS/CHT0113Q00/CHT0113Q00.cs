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
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Models.Chts;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.Framework;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0110Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0113Q00 : IHIS.Framework.XScreen
	{
		//Message처리
		string mbxMsg = "", mbxCap = "";
        
		//Multi선택여부
		bool mMultiSelect = true;
        private DataTable mInDataRow;
        
        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XTextBox txtSearchWord;
        private IHIS.Framework.MultiLayout layCHT0110M;
		private IHIS.Framework.XButton btnProcess;
        private IHIS.Framework.MultiLayout dloReturnValue;
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
        private XEditGrid grdCHT0113;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0113Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            grdCHT0113.ParamList = new List<string>(new String[] { "f_disability_name", "f_date" });
		    grdCHT0113.ExecuteQuery = ExecuteQueryGrdCHT0113Info;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0113Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.layCHT0110M = new IHIS.Framework.MultiLayout();
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
            this.btnProcess = new IHIS.Framework.XButton();
            this.dloReturnValue = new IHIS.Framework.MultiLayout();
            this.grdCHT0113 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCHT0110M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0113)).BeginInit();
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
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AccessibleDescription = null;
            this.txtSearchWord.AccessibleName = null;
            resources.ApplyResources(this.txtSearchWord, "txtSearchWord");
            this.txtSearchWord.BackgroundImage = null;
            this.txtSearchWord.Font = null;
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchWord_DataValidating);
            this.txtSearchWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchWord_KeyPress);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "suga_sang_code";
            this.xEditGridCell22.Col = 21;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "suga_sang_code";
            this.xEditGridCell23.Col = 22;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdatable = false;
            // 
            // layCHT0110M
            // 
            this.layCHT0110M.ExecuteQuery = null;
            this.layCHT0110M.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem13});
            this.layCHT0110M.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCHT0110M.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sang_code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sang_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sang_name_han";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "sang_name_self";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "sang_name_inx";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "jukyong_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "bulyong_yn";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "suga_sang_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "suga_sang_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "junyeom_bunryu";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "junyeon_kind";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "samang_sang_group";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "samang_sang_group_name";
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Font = null;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dloReturnValue
            // 
            this.dloReturnValue.ExecuteQuery = null;
            this.dloReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloReturnValue.ParamList")));
            // 
            // grdCHT0113
            // 
            resources.ApplyResources(this.grdCHT0113, "grdCHT0113");
            this.grdCHT0113.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell7});
            this.grdCHT0113.ColPerLine = 3;
            this.grdCHT0113.Cols = 3;
            this.grdCHT0113.ExecuteQuery = null;
            this.grdCHT0113.FixedRows = 1;
            this.grdCHT0113.HeaderHeights.Add(21);
            this.grdCHT0113.Name = "grdCHT0113";
            this.grdCHT0113.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0113.ParamList")));
            this.grdCHT0113.QuerySQL = resources.GetString("grdCHT0113.QuerySQL");
            this.grdCHT0113.Rows = 2;
            this.grdCHT0113.RowStateCheckOnPaint = false;
            this.grdCHT0113.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdCHT0113_QueryEnd);
            this.grdCHT0113.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdCHT0113_MouseDown);
            this.grdCHT0113.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdCHT0113_GridCellPainting);
            this.grdCHT0113.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCHT0113_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "disability_code";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 20;
            this.xEditGridCell2.CellName = "disability_name";
            this.xEditGridCell2.CellWidth = 124;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 50;
            this.xEditGridCell3.CellName = "disability_kana_name";
            this.xEditGridCell3.CellWidth = 207;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 136;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "delete_yn";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pkcht0113";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.AlterateRowImageIndex = 0;
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "select";
            this.xEditGridCell7.CellWidth = 35;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImageList = this.ImageList;
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.RowImageIndex = 0;
            this.xEditGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CHT0113Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdCHT0113);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "CHT0113Q00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CHT0110Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCHT0110M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0113)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			CreateLayout();		
			
		}

        string date = "";

		private void CHT0110Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (this.OpenParam != null)
			{				
				if( OpenParam.Contains("sang_inx")) this.txtSearchWord.SetDataValue(this.OpenParam["sang_inx"].ToString());

				if( OpenParam.Contains("multiSelect")) 
				{
					mMultiSelect = bool.Parse(OpenParam["multiSelect"].ToString());
				}

                if (OpenParam.Contains("grdPHY8004"))
                {
                    mInDataRow = (DataTable)OpenParam["grdPHY8004"];
                }
                
                if (OpenParam.Contains("date"))
                {
                    date = OpenParam["date"].ToString();
                }

				if(!mMultiSelect)
				{
					grdCHT0113.AutoSizeColumn(0, 0);
				}
				
				LoadCHT0113();
			}
		}

		private void CreateLayout()
		{
			// LayoutItems 생성
			foreach(XGridCell cell in this.grdCHT0113.CellInfos)
			{
				dloReturnValue.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			dloReturnValue.InitializeLayoutTable();				
		}

		#endregion

		#region [Control Event]

			
		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			CreateReturnValue(mMultiSelect);
		}

		private void txtSearchWord_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadCHT0113();
		}

		#endregion	

		#region [Function]

		/// <summary>
		/// 상병정보를 조회합니다.
		/// </summary>
		private void LoadCHT0113()
		{				
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                //string search_inx = JapanTextHelper.GetFullKatakana(txtSearchWord.GetDataValue().Trim(), false);

                grdCHT0113.SetBindVarValue("f_disability_name", txtSearchWord.GetDataValue().Trim());
                grdCHT0113.SetBindVarValue("f_hosp_code",  EnvironInfo.HospCode);
                grdCHT0113.SetBindVarValue("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                if (!this.grdCHT0113.QueryLayout(false))
				{
                    XMessageBox.Show(Service.ErrFullMsg);
				}

				
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default;
                this.SetInitialOrderGridData(this.mInDataRow);
			}
		}
        private void SetInitialOrderGridData(DataTable aInData)
        {
            if (this.mInDataRow != null)
            {
                for (int i = 0; i < this.grdCHT0113.RowCount; i++)
                {
                    for (int j = 0; j < this.mInDataRow.Rows.Count; j++)
                    {
                        if (this.grdCHT0113.GetItemString(i, "pkcht0113") == this.mInDataRow.Rows[j]["fkcht0113"].ToString())
                        {
                            this.grdCHT0113.SetItemValue(i, "select", "Y");
                            break;
                        }
                    }
                }
            }
            this.grdCHT0113.ResetUpdate();
            //insert by jc [checkboxImageInitialize] 2012/11/04
            SelectionBackColorChange(this.grdCHT0113);
        }

		/// <summary>
		/// 선택한정보를 dloReturnValue로 생성합니다.		
		/// </summary>
		private void CreateReturnValue(bool multiSelect)
		{  
			dloReturnValue.LayoutTable.Rows.Clear();
			
			try
			{
				//선택한 정보 import
				if( mMultiSelect )
				{
					foreach(DataRow row in grdCHT0113.LayoutTable.Rows)
					{
						if(row["select"].ToString() == "Y")
							dloReturnValue.LayoutTable.ImportRow(row);				
					}
				}
                
				//선택한 상병이 없는 경우에는 현재 row상병을 가져간다.
				if( !multiSelect && dloReturnValue.RowCount == 0 && grdCHT0113.CurrentRowNumber >= 0)
				{
					dloReturnValue.LayoutTable.ImportRow(grdCHT0113.LayoutTable.Rows[grdCHT0113.CurrentRowNumber]);				
				}
			}
			catch
			{				
				
			}

			if(dloReturnValue.RowCount < 1) 
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病が選択されていません。ご確認下さい。" : "상병이 선택되지 않았습니다. 확인하세요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;
			}

			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "CHT0113", dloReturnValue);
			scrOpener.Command(ScreenID, commandParams);
            
			this.Close();
		}
		#endregion

		#region [DataService Event]

		private void grdCHT0110M_ServiceEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			SelectionBackColorChange(grdCHT0113);
		}

		#endregion

		#region [Button List Event]

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadCHT0113();
					break;
			}
		
		}

		#endregion		

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

            //for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //{
            //    if(data == "Y")
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
            //    }
            //    else 
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
            //    }
            //}
			
		}
		
		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.DisplayRowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "delete_yn").ToString() == "Y") continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == "Y")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
                    //for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    //{					
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    //}
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
                    //for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    //{					
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    //}
				}
			}
		}
		#endregion

        //private void grdCHT0110M_QueryEnd(object sender, QueryEndEventArgs e)
        //{
        //    //insert by jc [checkboxImageInitialize] 2012/11/04
        //    SelectionBackColorChange(this.grdCHT0113);

        //}

        private void grdCHT0113_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCHT0113.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCHT0113.SetBindVarValue("f_disability_name", txtSearchWord.GetDataValue().Trim());
            this.grdCHT0113.SetBindVarValue("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        }

        private void grdCHT0113_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //insert by jc [checkboxImageInitialize] 2012/11/04
            SelectionBackColorChange(this.grdCHT0113);
        }

        private void grdCHT0113_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (this.grdCHT0113.GetItemString(e.RowNumber, "delete_yn") == "Y")
            {
                e.ForeColor = XColor.ErrMsgForeColor.Color;
            }
        }

        private void grdCHT0113_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex;
            Image image_num = null;
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                CreateReturnValue(false);
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdCHT0113.CurrentColNumber <= 1)
            {
                curRowIndex = grdCHT0113.GetHitRowNumber(e.Y);
                if (!mMultiSelect || curRowIndex < 0) return;

                if (grdCHT0113.CurrentColNumber >= 0)
                {
                    if (this.grdCHT0113.GetItemString(curRowIndex, "delete_yn") == "Y") return;

                    if (grdCHT0113.GetItemString(curRowIndex, "select") == "N")
                    {
                        grdCHT0113.SetItemValue(curRowIndex, "select", "Y");
                        SelectionBackColorChange(grdCHT0113, curRowIndex, "Y");
                        //image_num = this.ImageList.Images[1];
                    }
                    else
                    {
                        grdCHT0113.SetItemValue(curRowIndex, "select", "N");
                        SelectionBackColorChange(grdCHT0113, curRowIndex, "N");
                        //image_num = this.ImageList.Images[0];
                    }
                    //grdCHT0113[curRowIndex, "select"].Image = image_num;
                }
                this.grdCHT0113.Refresh();
            }		
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                LoadCHT0113();
        }

        #region connect to cloud service
        /// <summary>
        /// ExecuteQueryGrdCHT0113Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdCHT0113Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0113Q00GrdCHT0113Args vCHT0113Q00GrdCHT0113Args = new CHT0113Q00GrdCHT0113Args();
            vCHT0113Q00GrdCHT0113Args.DisabilityName = bc["f_disability_name"] != null ? bc["f_disability_name"].VarValue : "";
            vCHT0113Q00GrdCHT0113Args.Date = bc["f_date"] != null ? bc["f_date"].VarValue : "";
            CHT0113Q00GrdCHT0113Result result = CloudService.Instance.Submit<CHT0113Q00GrdCHT0113Result, CHT0113Q00GrdCHT0113Args>(vCHT0113Q00GrdCHT0113Args);
            if (result != null)
            {
                foreach (CHT0113Q00GrdCHT0113Info item in result.GrdCHT0113Info)
                {
                    object[] objects = 
				{ 
					item.DisabilityCode, 
					item.DisabilityName, 
					item.DisabilityKanaName, 
					item.StartDate, 
					item.EndDate, 
					item.DeleteYn, 
					item.Pkcht0113, 
					item.N
				};
                    res.Add(objects);
                }
            }
            return res;
        }
        #endregion

    }
}

