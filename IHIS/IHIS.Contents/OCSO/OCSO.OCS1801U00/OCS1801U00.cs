#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCSO.Properties;

#endregion

namespace IHIS.OCSO
{
	/// <summary>
	/// OCS1801U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS1801U00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		private string mBunho ="";
		
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdOCS1801;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XPatientBox pbxSearch;
		private IHIS.Framework.XPanel pnlPatStatus;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton1;
        private MultiLayout layOCS0801;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;

        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS1801U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1801U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.grdOCS1801 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pnlPatStatus = new IHIS.Framework.XPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.layOCS0801 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1801)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlPatStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0801)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // pbxSearch
            // 
            resources.ApplyResources(this.pbxSearch, "pbxSearch");
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.PatientSelectionFailed += new System.EventHandler(this.pbxSearch_PatientSelectionFailed);
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // grdOCS1801
            // 
            this.grdOCS1801.AddedHeaderLine = 1;
            this.grdOCS1801.ApplyPaintEventToAllColumn = true;
            this.grdOCS1801.CallerID = '2';
            this.grdOCS1801.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell5});
            this.grdOCS1801.ColPerLine = 4;
            this.grdOCS1801.Cols = 5;
            this.grdOCS1801.EnableMultiSelection = true;
            this.grdOCS1801.FixedCols = 1;
            this.grdOCS1801.FixedRows = 2;
            this.grdOCS1801.FocusColumnName = "pat_status";
            this.grdOCS1801.HeaderHeights.Add(31);
            this.grdOCS1801.HeaderHeights.Add(0);
            this.grdOCS1801.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            resources.ApplyResources(this.grdOCS1801, "grdOCS1801");
            this.grdOCS1801.Name = "grdOCS1801";
            this.grdOCS1801.QuerySQL = resources.GetString("grdOCS1801.QuerySQL");
            this.grdOCS1801.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1801.RowHeaderVisible = true;
            this.grdOCS1801.Rows = 3;
            this.grdOCS1801.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1801.SelectionModeChangeable = true;
            this.grdOCS1801.TogglingRowSelection = true;
            this.grdOCS1801.ToolTipActive = true;
            this.grdOCS1801.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1801_GridColumnChanged);
            this.grdOCS1801.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS1801_GridFindSelected);
            this.grdOCS1801.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1801_GridCellPainting);
            this.grdOCS1801.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS1801_GridFindClick);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 2;
            this.xEditGridCell36.CellName = "bunho";
            this.xEditGridCell36.Col = -1;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsNotNull = true;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AutoTabDataSelected = true;
            this.xEditGridCell37.CellLen = 2;
            this.xEditGridCell37.CellName = "pat_status";
            this.xEditGridCell37.CellWidth = 41;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell37.IsNotNull = true;
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.Row = 1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 100;
            this.xEditGridCell38.CellName = "pat_status_name";
            this.xEditGridCell38.CellWidth = 239;
            this.xEditGridCell38.Col = 2;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell38.IsNotNull = true;
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AutoTabDataSelected = true;
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "pat_status_code";
            this.xEditGridCell6.CellWidth = 65;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 100;
            this.xEditGridCell7.CellName = "pat_status_code_name";
            this.xEditGridCell7.CellWidth = 205;
            this.xEditGridCell7.Col = 4;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 200;
            this.xEditGridCell39.CellName = "ment";
            this.xEditGridCell39.Col = -1;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 2;
            this.xEditGridCell40.CellName = "seq";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 40;
            this.xEditGridCell40.Col = -1;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 1;
            this.xEditGridCell5.CellName = "indispensable_yn";
            this.xEditGridCell5.Col = -1;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderText = Resources.XGRIDHEADER2_HEADER_TEXT;
            this.xGridHeader2.HeaderWidth = 41;
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // pnlPatStatus
            // 
            resources.ApplyResources(this.pnlPatStatus, "pnlPatStatus");
            this.pnlPatStatus.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.GhostWhite);
            this.pnlPatStatus.Controls.Add(this.panel1);
            this.pnlPatStatus.Name = "pnlPatStatus";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // radioButton1
            // 
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // layOCS0801
            // 
            this.layOCS0801.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layOCS0801.QuerySQL = resources.GetString("layOCS0801.QuerySQL");
            this.layOCS0801.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS0801_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pat_status";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "pat_status_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "pat_status_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pat_status_code_name";
            // 
            // OCS1801U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlPatStatus);
            this.Controls.Add(this.grdOCS1801);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1801U00";
            resources.ApplyResources(this, "$this");
            this.HiddenDockingScreenAppearing += new System.EventHandler(this.OCS1801U00_HiddenDockingScreenAppearing);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1801)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlPatStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0801)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			this.pnlPatStatus.Controls.Clear();
            this.layOCS0801.QueryLayout(true);
			
		}

		private void OCS1801U00_HiddenDockingScreenAppearing(object sender, System.EventArgs e)
		{
			XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

			if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
			{
				// 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
				patientInfo = XScreen.GetOtherScreenBunHo(this, true);
			}

			if (patientInfo != null)
			{
                if (this.pbxSearch.BunHo != patientInfo.BunHo)
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                else
                    this.xButtonList1.PerformClick(FunctionType.Query);
			}
		
		}

		
		#endregion

		#region 환자번호입력시
		private void pbxSearch_PatientSelected(object sender, System.EventArgs e)
		{
            if (!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
                this.xButtonList1.PerformClick(FunctionType.Query);
            else
                grdOCS1801.Reset();
		}

		private void pbxSearch_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			grdOCS1801.Reset();
			DisplayData();
		}		
		#endregion		

        #region DataLoad

        private void LoadOCS1801(string aBunho)
        {
            this.grdOCS1801.SetBindVarValue("f_bunho", aBunho);
            this.grdOCS1801.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS1801.QueryLayout(true);

            this.DisplayData();
        }

        #endregion

        #region [Load Code Name]

        /// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
            object codeName = new object();
            string cmdText = "";

			if(code.Trim() == "" ) return "";

			switch (codeMode)
			{
				case "pat_status":

                    cmdText = "SELECT A.PAT_STATUS_NAME "   
						+ "  FROM OCS0801 A "
						+ " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                        + "   AND A.PAT_STATUS = '" + code + "' ";

                    codeName = Service.ExecuteScalar(cmdText);
                    
					break;

				case "pat_status_code":

					string pat_status = grdOCS1801.GetItemString(grdOCS1801.CurrentRowNumber, "pat_status");

					if(TypeCheck.IsNull(pat_status)) break;

                    cmdText = "SELECT A.PAT_STATUS_CODE_NAME "   
						+ "  FROM OCS0802 A "
                        + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
						+ "   AND A.PAT_STATUS      = '" + pat_status + "' "
						+ "   AND A.PAT_STATUS_CODE = '" + code + "' ";

                    codeName = Service.ExecuteScalar(cmdText);

					break;
				
				default:
					break;
			}

            if (TypeCheck.IsNull(codeName)) return "";
			else return codeName.ToString();
		}

		#endregion

		#region [GetFindWorker]

		private XFindWorker GetFindWorker(string findMode)
		{
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{	
				case "pat_status":
                    
					fdwCommon.AutoQuery = true;	
					fdwCommon.ServerFilter = false;
					fdwCommon.InputSQL = "SELECT A.PAT_STATUS, A.PAT_STATUS_NAME "   
						+ "  FROM OCS0801 A "
                        + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
						+ " ORDER BY A.PAT_STATUS ";
                    
					fdwCommon.FormText = Resources.FDWCOMMON_FORMTEXT_1;
					fdwCommon.ColInfos.Add("pat_status", Resources.XGRIDHEADER2_HEADER_TEXT, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("pat_status_name", Resources.FDWCOMMON_PAT_STATUS_NAME_TEXT_1, FindColType.String, 300, 0, true, FilterType.Yes);

					break;
			    
				case "pat_status_code":

					string pat_status = grdOCS1801.GetItemString(grdOCS1801.CurrentRowNumber, "pat_status");
                    
					fdwCommon.AutoQuery = true;
					fdwCommon.ServerFilter = false;
					fdwCommon.InputSQL = "SELECT A.PAT_STATUS_CODE, A.PAT_STATUS_CODE_NAME "   
						+ "  FROM OCS0802 A "
                        + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
						+ "   AND A.PAT_STATUS = '" + pat_status + "' "
						+ " ORDER BY NVL(A.SEQ, 99), A.PAT_STATUS_CODE ";
                    
					fdwCommon.FormText = Resources.FDWCOMMON_FORMTEXT_2;
					fdwCommon.ColInfos.Add("pat_status_code"     , Resources.FDWCOMMON_PAT_STATUS_CODE_TEXT_1, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("pat_status_code_name", Resources.FDWCOMMON_PAT_STATUS_CODE_NAME_TEXT_1, FindColType.String, 300, 0, true, FilterType.No);

					break;
			    
				default:
					
					break;
			}

			return fdwCommon;
		}


		#endregion

		#region [grdOCS1801 Event]

		private void grdOCS1801_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			object previousValue   = grdOCS1801.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value
			
			switch (e.ColName)
			{
				case "pat_status_code":
                    
					if(TypeCheck.IsNull(e.ChangeValue.ToString().Trim())) 
					{
						grdOCS1801.SetItemValue(e.RowNumber, "pat_status_code_name", "");
						break;
					}
                    
					//Check Origin Data
					string pat_status_code_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if( TypeCheck.IsNull(pat_status_code_name) )
					{
						mbxMsg = Resources.MSG001_MSG;
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

						this.mOrderFunc.UndoPreviousValue(grdOCS1801, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다.	
					}
					else
						grdOCS1801.SetItemValue(e.RowNumber, "pat_status_code_name", pat_status_code_name);
					
					break;

				default:
					break;
			}
		}

		private void grdOCS1801_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			switch (e.ColName)
			{
				case "pat_status_code": // Answer 코드

					((XFindBox)((XEditGridCell)grdOCS1801.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.GetFindWorker(e.ColName);

					break;

				default:

					break;
			}
		
		}
		
		
		private void grdOCS1801_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;	

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if ( (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && e.DataRow.RowState != DataRowState.Added ) ||
				((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly ) 
			{
				//e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
			}		
			
		}

		private void grdOCS1801_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			
		}

		private void grdOCS1801_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
			this.AcceptData();
		
		}

		#endregion
        
		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.LoadOCS1801(this.pbxSearch.BunHo);

                    break;
				case FunctionType.Update:

                    #region 변경 데이터 저장 부 

                    string cmdText = "";
                    string proName = "PR_OCS_OCS1801_NUR_MAPPING";
                    ArrayList invarList = new ArrayList();
                    ArrayList outvarList = new ArrayList();

                    Service.BeginTransaction();

                    try
                    {

                        foreach (DataRow dr in this.grdOCS1801.LayoutTable.Rows)
                        {
                            if (dr.RowState != DataRowState.Unchanged)
                            {
                                cmdText = "DECLARE                                                                              "
                                        + "                                                                                     "
                                        + "BEGIN                                                                                "
                                        + "                                                                                     "
                                        + "  UPDATE OCS1801                                                                     "
                                        + "     SET UPD_ID            = '" + UserInfo.UserID + "',             "
                                        + "         UPD_DATE          = SYSDATE                                   ,             "
                                        + "         PAT_STATUS        = '" + dr["pat_status"].ToString() + "',             "
                                        + "         PAT_STATUS_CODE   = '" + dr["pat_status_code"].ToString() + "',             "
                                        + "         MENT              = '" + dr["ment"].ToString() + "',             "
                                        + "         SEQ               = '" + dr["seq"].ToString() + "'              "
                                        + "   WHERE BUNHO             = '" + dr["bunho"].ToString() + "'              "
                                        + "     AND PAT_STATUS        = '" + dr["pat_status"].ToString() + "';             "
                                        + "                                                                                     "
                                        + "  IF SQL%NOTFOUND THEN                                                               "
                                        + "                                                                                     "
                                        + "    INSERT INTO OCS1801                                                              "
                                        + "         ( SYS_DATE       , SYS_ID, UPD_ID, UPD_DATE , BUNHO, PAT_STATUS ,                  "
                                        + "           PAT_STATUS_CODE, MENT  , SEQ   , HOSP_CODE      )                                   "
                                        + "    VALUES                                                                           "
                                        + "         ( SYSDATE           , '" + UserInfo.UserID + "', '" + UserInfo.UserID + "', SYSDATE  , '" + dr["bunho"].ToString() + "', '" + dr["pat_status"].ToString() + "' ,  "
                                        + "           '" + dr["pat_status_code"].ToString() + "' , '" + dr["ment"].ToString() + "'    , '" + dr["seq"].ToString() + "', '" + EnvironInfo.HospCode + "'    );                        "
                                        + "                                                                                     "
                                        + "                                                                                     "
                                        + "  END IF;                                                                            "
                                        + "                                                                                     "
                                        + "                                                                                     "
                                        + "END ;                                                                                ";

                                if (Service.ExecuteNonQuery(cmdText) == false)
                                {
                                    this.mbxMsg = Resources.MSG002_MSG + Service.ErrFullMsg;
                                    this.mbxCap = Resources.MSG002_CAP;

                                    MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    Service.RollbackTransaction();

                                    return;
                                }

                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                invarList.Clear();
                                invarList.Add(dr["bunho"].ToString());
                                invarList.Add(dr["pat_status"].ToString());
                                invarList.Add(UserInfo.UserID);
                                outvarList.Clear();

                                if (Service.ExecuteProcedure(proName, invarList, outvarList) == false)
                                {
                                    this.mbxMsg = Resources.MSG002_MSG + Service.ErrFullMsg;
                                    this.mbxCap = Resources.MSG002_CAP;

                                    MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    Service.RollbackTransaction();

                                    return;
                                }
                                else
                                {
                                    if (outvarList[0].ToString() != "0")
                                    {
                                        this.mbxMsg = Resources.MSG002_MSG + Service.ErrFullMsg;
                                        this.mbxCap = Resources.MSG002_CAP;

                                        MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        Service.RollbackTransaction();

                                        return;
                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        this.mbxMsg = Resources.MSG002_MSG + ex.Message;
                        this.mbxCap = Resources.MSG002_CAP;

                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Service.RollbackTransaction();

                        return;
                    }

                    Service.CommitTransaction();

                    #endregion

                    break;

				default:

					break;
			}	
		
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					
					break;

				default:

					break;
			}	
		
		}
		#endregion		

		#region [Display data]

		private void DisplayData()
		{
			this.pnlPatStatus.Controls.Clear();

			if( this.grdOCS1801.RowCount == 0 ) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

				pnlPatStatus.SuspendLayout();

				Panel       pnlRow = new System.Windows.Forms.Panel();
				Label       lblPatStatus;
				RadioButton rbtPatStatusCode;
                
				string oldPatStatus = "";

				int rowLocationY = 5;
				int rowIndex     = 0;
				int rowWidth     = 0;
				
				int rbtLocationX = 295;

                for (int i = 0; i < this.layOCS0801.RowCount; i++)
				{
                    if (oldPatStatus != layOCS0801.GetItemString(i, "pat_status"))
					{
						//Row가 바뀔때 Row Panel사이즈를 조정한다.
						if( i != 0 )
						{
							//pnlRow.Size = new Size( rbtLocationX, pnlRow.Size.Height);
							if( rbtLocationX > rowWidth )
								rowWidth = rbtLocationX;
						}
						
						//Row Container 생성
						pnlRow = new System.Windows.Forms.Panel();
						pnlRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
						pnlRow.BackColor = System.Drawing.Color.Honeydew;
						pnlRow.Location = new System.Drawing.Point(10, rowLocationY);
						pnlRow.Name = "pnl_" + i.ToString();
						pnlRow.Size = new System.Drawing.Size(1044, 25);
						pnlRow.TabIndex = 0;
						pnlRow.Tag =rowIndex;

						this.pnlPatStatus.Controls.Add(pnlRow);

						//Pat status 명칭 Label
						lblPatStatus = new System.Windows.Forms.Label();
						lblPatStatus.Dock = System.Windows.Forms.DockStyle.Left;
						lblPatStatus.Location = new System.Drawing.Point(0, 0);
                        lblPatStatus.Name = "lbl_" + layOCS0801.GetItemString(i, "pat_status");
						lblPatStatus.Size = new System.Drawing.Size(200, 25);
						lblPatStatus.TabIndex = 0;
                        lblPatStatus.Text = "   " + layOCS0801.GetItemString(i, "pat_status_name");
						lblPatStatus.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
						lblPatStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        lblPatStatus.Tag = layOCS0801.GetItemString(i, "pat_status");
						pnlRow.Controls.Add(lblPatStatus);

						//다음 Row위치 + 5
						rowLocationY = rowLocationY + 30;
						rowIndex ++;

						//radio item Location 초기화
						rbtLocationX = 205;

                        oldPatStatus = layOCS0801.GetItemString(i, "pat_status");
					}

					rbtPatStatusCode = new System.Windows.Forms.RadioButton();
					rbtPatStatusCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
					rbtPatStatusCode.Location = new System.Drawing.Point(rbtLocationX, 0);
                    rbtPatStatusCode.Name = "rbt_" + layOCS0801.GetItemString(i, "pat_status") + layOCS0801.GetItemString(i, "pat_status_code");
					rbtPatStatusCode.Size = new System.Drawing.Size(110, 25);
					rbtPatStatusCode.TabIndex = 0;
                    rbtPatStatusCode.Text = layOCS0801.GetItemString(i, "pat_status_code_name");
                    rbtPatStatusCode.Tag = layOCS0801.GetItemString(i, "pat_status") + "|" + layOCS0801.GetItemString(i, "pat_status_code");
					rbtPatStatusCode.Cursor = System.Windows.Forms.Cursors.Hand;
					rbtPatStatusCode.Click += new System.EventHandler(this.rbt_Click);
                    if (this.grdOCS1801.LayoutTable.Select("pat_status = '" + layOCS0801.GetItemString(i, "pat_status") + "' and pat_status_code = '" + layOCS0801.GetItemString(i, "pat_status_code") + "' ", "").Length > 0)
					{
						rbtPatStatusCode.Checked = true;
						rbtPatStatusCode.ForeColor = Color.Blue;
						rbtPatStatusCode.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					}

					pnlRow.Controls.Add(rbtPatStatusCode);

					rbtLocationX = rbtLocationX + 115;
				}

				if( rbtLocationX > rowWidth )
					rowWidth = rbtLocationX;

				//row panel을 맞춘다.
				foreach( object obj in pnlPatStatus.Controls )
				{
					if( obj.GetType().ToString().IndexOf("Panel" ) >= 0)
						((Panel)obj).Size = new Size( rowWidth, ((Panel)obj).Size.Height);
				}

				if(this.grdOCS1801.RowCount == 0)
					pnlPatStatus.Enabled = false;
				else
					pnlPatStatus.Enabled = true;


				pnlPatStatus.ResumeLayout();

			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
			}
		}

		private void rbt_Click(object sender, System.EventArgs e)
		{
			RadioButton rbt = sender as RadioButton;
			
			foreach(object obj in ((Panel)rbt.Parent).Controls)
			{
				if( obj.GetType().ToString().IndexOf("RadioButton" ) >= 0)
				{
					if( ((RadioButton)obj).Checked )
					{
						((RadioButton)obj).ForeColor = Color.Blue;
						((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

						string pat_status      = ((RadioButton)obj).Tag.ToString().Split('|')[0];
						string pat_status_code = ((RadioButton)obj).Tag.ToString().Split('|')[1];

						for(int i = 0; i < grdOCS1801.RowCount; i++)
						{
							if( grdOCS1801.GetItemString(i, "pat_status") == pat_status)
								this.grdOCS1801.SetItemValue(i, "pat_status_code", pat_status_code);
						}
						
					}
					else
					{
						((RadioButton)obj).ForeColor = Color.Black;
						((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					}
				}
			}
		}

		#endregion

        private void layOCS0801_QueryStarting(object sender, CancelEventArgs e)
        {
            layOCS0801.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
	}
}

