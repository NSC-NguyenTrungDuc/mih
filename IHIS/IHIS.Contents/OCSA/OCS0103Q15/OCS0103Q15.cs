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
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q15에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q15 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		private string mQuery = "0";

		//등록번호
		private string mBunho = "";
		//내원일자
		private string mNaewon_date = "";
		//진료과
		private string mGwa = "";		
		//진료의사
		private string mDoctor = "";

		//Data가 없는 경우 화면 닫을지 여부
		private bool mAuto_close = false;
		#endregion

		private IHIS.Framework.XGrid grdOCS0103;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XButton btnProClose;
		private IHIS.Framework.MultiLayout laySelectOCS0103;

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0103Q15()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q15));
            this.grdOCS0103 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnProClose = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.laySelectOCS0103 = new IHIS.Framework.MultiLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySelectOCS0103)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // grdOCS0103
            // 
            this.grdOCS0103.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOCS0103.ApplyPaintEventToAllColumn = true;
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5});
            this.grdOCS0103.ColPerLine = 3;
            this.grdOCS0103.Cols = 3;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Location = new System.Drawing.Point(6, 6);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0103.Size = new System.Drawing.Size(512, 542);
            this.grdOCS0103.TabIndex = 0;
            this.grdOCS0103.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0103_GridCellPainting);
            this.grdOCS0103.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragDrop);
            this.grdOCS0103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_MouseDown);
            this.grdOCS0103.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0103_GiveFeedback);
            this.grdOCS0103.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0103_DragEnter);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "slip_code";
            this.xGridCell1.Col = -1;
            this.xGridCell1.HeaderText = "slip_code";
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.CellName = "hangmog_code";
            this.xGridCell2.CellWidth = 90;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell2.HeaderText = "オ―ダコード";
            this.xGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridCell3
            // 
            this.xGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell3.CellName = "hangmog_name";
            this.xGridCell3.CellWidth = 359;
            this.xGridCell3.Col = 2;
            this.xGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell3.HeaderText = "オ―ダコード名";
            this.xGridCell3.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "bulyong_check";
            this.xGridCell4.Col = -1;
            this.xGridCell4.HeaderText = "bulyong_check";
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell5.CellName = "select";
            this.xGridCell5.CellWidth = 44;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell5.HeaderText = "選択";
            this.xGridCell5.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell5.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnProClose);
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 552);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(524, 38);
            this.xPanel1.TabIndex = 1;
            // 
            // btnProClose
            // 
            this.btnProClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProClose.Image = ((System.Drawing.Image)(resources.GetObject("btnProClose.Image")));
            this.btnProClose.Location = new System.Drawing.Point(137, 4);
            this.btnProClose.Name = "btnProClose";
            this.btnProClose.Size = new System.Drawing.Size(114, 28);
            this.btnProClose.TabIndex = 24;
            this.btnProClose.Text = "選択後閉じる";
            this.btnProClose.Visible = false;
            this.btnProClose.Click += new System.EventHandler(this.btnProClose_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(253, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(351, 1);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // OCS0103Q15
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.grdOCS0103);
            this.Name = "OCS0103Q15";
            this.Size = new System.Drawing.Size(524, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0103Q15_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySelectOCS0103)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event] 
		private void OCS0103Q15_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( e.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
						mBunho = OpenParam["bunho"].ToString().Trim();
					else
						return;

					if(OpenParam.Contains("gwa"))
						mGwa = OpenParam["gwa"].ToString().Trim();


					if(OpenParam.Contains("doctor"))
						mDoctor = OpenParam["doctor"].ToString().Trim();
					
					mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("naewon_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
							mNaewon_date = OpenParam["naewon_date"].ToString();
					}

					//Data가 없는 경우 화면 닫을지 여부
					if(OpenParam.Contains("auto_close"))
					{
						mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
						if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
					}

					mQuery = "1";
					
					m1GrdQueryStarting();
				}
				catch (Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");	
					this.Close();
				}

				if(grdOCS0103.QueryLayout(false))
				{
					SelectionBackColorChange(grdOCS0103);
				}
				//이전 지도료가 없는 경우 화면을 닫는다.
				if(grdOCS0103.RowCount < 1)
				{
					this.Close();
					return;
				}
				else
					if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Normal;
			}
			else
				mQuery = "0";

			if(mQuery == "0")
				btnProcess.Visible = true;
			else
				btnProcess.Visible = false;            
		}

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			PostLoad();
		}

		private void PostLoad()
		{
			//Create Return DataLayout 
			CreateLayout();
            
			if(mQuery == "0")
			{
				m0GrdQueryStarting();
				if(grdOCS0103.QueryLayout(false))
				{
					SelectionBackColorChange(grdOCS0103);
				}
			}
		}
		
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS0103
			foreach(XGridCell cell in this.grdOCS0103.CellInfos)
			{
				laySelectOCS0103.LayoutItems.Add(LayoutItem(cell.CellName, (DataType)cell.CellType));
			}

			laySelectOCS0103.InitializeLayoutTable();
		}

		private MultiLayoutItem LayoutItem(string pDataName, IHIS.Framework.DataType pDataType)
		{
			MultiLayoutItem myItem = new MultiLayoutItem();

			myItem.DataName = pDataName;
			myItem.DataType = pDataType;

			return myItem;
		}
		#endregion

		#region [Return Layout 생성]
		private void CreateReturnLayout()
		{
			this.AcceptData();

			laySelectOCS0103.Reset();
			
			for(int i = 0; i < grdOCS0103.RowCount; i++)
			{
				if(grdOCS0103.GetItemString(i, "select") == " ")
					laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103.LayoutTable.Rows[i]);

			}
			if(laySelectOCS0103.LayoutTable.Rows.Count < 1 )
				return; 
			
			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", laySelectOCS0103);
			scrOpener.Command(ScreenID, commandParams);
            
			ClearSelect();
		}		
		#endregion

		#region [grdOCS0103 Event]
		private void grdOCS0103_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			return;
		}

		private void grdOCS0103_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시
		}

		private void grdOCS0103_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}

		private void grdOCS0103_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS0103_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
				CreateReturnLayout();
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0103.CurrentColNumber == 0)
			{
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS0103.CurrentColNumber == 0)
				{	
					//불용처리된 것은 선택을 막는다.
					if(grdOCS0103.GetItemString(curRowIndex, "bulyong_check") == "Y") return;

					if(grdOCS0103.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS0103.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdOCS0103.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
					}
				}

			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				if(grdOCS0103.GetHitRowNumber(e.Y) < 0 ) return;		
				curRowIndex = grdOCS0103.GetHitRowNumber(e.Y);

				//Drag시 show info정보
				string dragInfo = "[" + grdOCS0103.GetItemString(curRowIndex, "hangmog_code") + "]" + grdOCS0103.GetItemString(curRowIndex, "hangmog_name");
				DragHelper.CreateDragCursor(grdOCS0103, dragInfo, this.Font);
				
				laySelectOCS0103.Reset();
				for(int i = 0; i < grdOCS0103.RowCount; i++)
				{
					if(grdOCS0103.GetItemString(i, "select") == " ")
						laySelectOCS0103.LayoutTable.ImportRow(grdOCS0103.LayoutTable.Rows[i]);

				}

				object[] dragData = new object[2];
				dragData[0] = this.ScreenID;
				dragData[1] = laySelectOCS0103;
				grdOCS0103.DoDragDrop( dragData, DragDropEffects.Move);
			}
		}

		#endregion

		#region [Control Event]
		private void btnProClose_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();	
			Close();
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();	
			Close();
		}
		#endregion

		#region [ButtonList Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					if(mQuery == "0")
					{
						m0GrdQueryStarting();
						if(grdOCS0103.QueryLayout(false))
						{
							SelectionBackColorChange(grdOCS0103);
						}
					}
					else
					{
						m1GrdQueryStarting();
						if(grdOCS0103.QueryLayout(false))
						{
							SelectionBackColorChange(grdOCS0103);
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region [Function]
		private void ClearSelect()
		{	
			//선택된 row Clear
			for(int i = 0; i < this.grdOCS0103.RowCount; i++)
			{
				grdOCS0103.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS0103);

			laySelectOCS0103.Reset();
		}

		private void m0GrdQueryStarting()
		{
			grdOCS0103.QuerySQL = 
							@"SELECT	A.SLIP_CODE    ,
										A.HANGMOG_CODE ,
										A.HANGMOG_NAME ,
										FN_OCS_BULYONG_CHECK_OUT(A.HANGMOG_CODE, SYSDATE)  BULYONG_CHECK 
							  FROM OCS0103 A 
							  WHERE A.SLIP_CODE     = 'T01'
							  ORDER BY HANGMOG_CODE";
		}

		private void m1GrdQueryStarting()
		{
			grdOCS0103.QuerySQL = 
							@"SELECT	A.SLIP_CODE    ,
										A.HANGMOG_CODE ,
										A.HANGMOG_NAME ,
										FN_OCS_BULYONG_CHECK_OUT(A.HANGMOG_CODE, SYSDATE)  BULYONG_CHECK
							  FROM OCS0103 A                       
							  WHERE A.SLIP_CODE     = 'T01'
							  AND EXISTS (SELECT 'X'
											FROM OCS1003 B
											WHERE B.BUNHO           = :f_bunho
											AND B.NAEWON_DATE    >= ADD_MONTHS( TO_DATE(SUBSTR(:f_naewon_date, 1, 10), 'YYYY/MM/DD'), -6 )
											AND B.GWA             = :f_gwa
											AND B.DOCTOR          = :f_doctor
											AND B.HANGMOG_CODE    = A.HANGMOG_CODE
											AND NVL(B.DC_YN, 'N') = 'N'
											AND ROWNUM          = 1 )
											ORDER BY A.HANGMOG_CODE";

			grdOCS0103.SetBindVarValue("f_bunho",mBunho);
			grdOCS0103.SetBindVarValue("f_naewon_date",mNaewon_date);
			grdOCS0103.SetBindVarValue("f_gwa",mGwa);
			grdOCS0103.SetBindVarValue("f_doctor",mDoctor);
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

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
			
		}

		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				//불용은 넘어간다.
				if(grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion
	}
}

