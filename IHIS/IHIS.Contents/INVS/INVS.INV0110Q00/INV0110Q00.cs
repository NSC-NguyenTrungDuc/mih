#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using IHIS.INVS.Properties;

#endregion


namespace IHIS.INVS
{
	/// <summary>
	/// INV0110Q00에 대한 요약 설명입니다.
	/// </summary>
	public class INV0110Q00 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";		
		private string mHangmog_code = "";
		private bool   mMultiSelect  = true;

        //HOSP_CODE
        private string mHospCode = EnvironInfo.HospCode;

        //// INPUT TAB
        //private string mInputTab = "%";

        //// Child YN 
        //private string mChildYN = "%";

		#endregion

        #region Controls
        private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XPanel pnlQuery;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XTextBox txtJaeryo_index;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XGrid grdINV0110;
		private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.MultiLayout dloReturnValue;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
        private System.Windows.Forms.ToolTip toolTip1;
        private XGridCell xGridCell1;
		private System.ComponentModel.IContainer components;
        #endregion

        public INV0110Q00()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV0110Q00));
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.pnlQuery = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtJaeryo_index = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdINV0110 = new IHIS.Framework.XGrid();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dloReturnValue = new IHIS.Framework.MultiLayout();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlQuery.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV0110)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ImageIndex = 1;
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ImageIndex = 1;
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ImageIndex = 1;
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ImageIndex = 1;
            this.xComboItem4.ValueItem = "3";
            // 
            // pnlQuery
            // 
            this.pnlQuery.AccessibleDescription = null;
            this.pnlQuery.AccessibleName = null;
            resources.ApplyResources(this.pnlQuery, "pnlQuery");
            this.pnlQuery.BackgroundImage = null;
            this.pnlQuery.Controls.Add(this.xLabel1);
            this.pnlQuery.Controls.Add(this.xLabel3);
            this.pnlQuery.Controls.Add(this.txtJaeryo_index);
            this.pnlQuery.Controls.Add(this.xLabel2);
            this.pnlQuery.DrawBorder = true;
            this.pnlQuery.Font = null;
            this.pnlQuery.Name = "pnlQuery";
            this.toolTip1.SetToolTip(this.pnlQuery, resources.GetString("pnlQuery.ToolTip"));
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // txtJaeryo_index
            // 
            this.txtJaeryo_index.AccessibleDescription = null;
            this.txtJaeryo_index.AccessibleName = null;
            resources.ApplyResources(this.txtJaeryo_index, "txtJaeryo_index");
            this.txtJaeryo_index.BackgroundImage = null;
            this.txtJaeryo_index.Name = "txtJaeryo_index";
            this.toolTip1.SetToolTip(this.txtJaeryo_index, resources.GetString("txtJaeryo_index.ToolTip"));
            this.txtJaeryo_index.ImeModeChanged += new System.EventHandler(this.txtJaeryo_index_ImeModeChanged);
            this.txtJaeryo_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtJaeryo_index_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XGridColHeaderGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdINV0110);
            this.xPanel3.Controls.Add(this.xPanel1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // grdINV0110
            // 
            resources.ApplyResources(this.grdINV0110, "grdINV0110");
            this.grdINV0110.ApplyPaintEventToAllColumn = true;
            this.grdINV0110.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell9,
            this.xGridCell1,
            this.xGridCell7,
            this.xGridCell8});
            this.grdINV0110.ColPerLine = 3;
            this.grdINV0110.Cols = 3;
            this.grdINV0110.ExecuteQuery = null;
            this.grdINV0110.FixedRows = 1;
            this.grdINV0110.HeaderHeights.Add(26);
            this.grdINV0110.Name = "grdINV0110";
            this.grdINV0110.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV0110.ParamList")));
            this.grdINV0110.QuerySQL = resources.GetString("grdINV0110.QuerySQL");
            this.grdINV0110.Rows = 2;
            this.grdINV0110.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip1.SetToolTip(this.grdINV0110, resources.GetString("grdINV0110.ToolTip"));
            this.grdINV0110.ToolTipActive = true;
            this.grdINV0110.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdINV0110_GridContDisplayed);
            this.grdINV0110.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdINV0110_MouseDown);
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.CellName = "jaeryo_code";
            this.xGridCell4.CellWidth = 117;
            this.xGridCell4.Col = 1;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell5
            // 
            this.xGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.CellName = "jaeryo_name";
            this.xGridCell5.CellWidth = 318;
            this.xGridCell5.Col = 2;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            this.xGridCell5.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "subul_danui";
            this.xGridCell9.Col = -1;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            this.xGridCell9.IsVisible = false;
            this.xGridCell9.Row = -1;
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "subul_danui_name";
            this.xGridCell1.Col = -1;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "subul_danga";
            this.xGridCell7.Col = -1;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            this.xGridCell7.IsVisible = false;
            this.xGridCell7.Row = -1;
            // 
            // xGridCell8
            // 
            this.xGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell8.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell8.CellName = "select";
            this.xGridCell8.CellWidth = 43;
            this.xGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            this.xGridCell8.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell8.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell8.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Resources.BUTTON_NAME, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip1.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dloReturnValue
            // 
            this.dloReturnValue.ExecuteQuery = null;
            this.dloReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloReturnValue.ParamList")));
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // INV0110Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlQuery);
            this.Name = "INV0110Q00";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINV0110)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("jaeryo_code"))
					{
						if(OpenParam["jaeryo_code"].ToString().Trim() != "")
						{
							mHangmog_code = OpenParam["jaeryo_code"].ToString();
							txtJaeryo_index.SetDataValue(mHangmog_code);
						}
					}

                    if (OpenParam.Contains("multiSelection"))
                    {
                        if (TypeCheck.IsBoolean(OpenParam["multiSelection"]))
                        {
                            mMultiSelect = bool.Parse(OpenParam["multiSelection"].ToString());
                        }
                    }
				}
				catch
				{
				}
			}

			PostCallHelper.PostCall(new PostMethod(PostLoad));		
		}
		

		private void PostLoad()
		{	
			CreateLayout();	

			//mHangmog_code가 존재하면 항목정보 Load
		    if(mHangmog_code.Trim().Length > 0)
		    {
                this.txtJaeryo_index.SetDataValue(mHangmog_code);
                this.LoadINV0110();
		    }

			txtJaeryo_index.Focus();
			txtJaeryo_index.SelectAll();

			this.txtJaeryo_index.ImeMode = System.Windows.Forms.ImeMode.Disable;
		}

		private void CreateLayout()
		{
			// LayoutItems 생성
			foreach(XGridCell cell in grdINV0110.CellInfos)
			{
				dloReturnValue.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			dloReturnValue.InitializeLayoutTable();
		}
		#endregion

        #region [Button List Event]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.LoadINV0110();
                    break;

                case FunctionType.Process:
                    e.IsBaseCall = false;
                    CreateReturnValue();
                    break;
            }
        }
        #endregion

		#region [Function]
		/// <summary>
		/// 선택한정보를 dloReturnValue로 생성합니다.		
		/// </summary>
		private void CreateReturnValue()
		{  
			dloReturnValue.LayoutTable.Rows.Clear();
			
			try
			{
				//선택한 정보 import
				for(int i = 0; i < grdINV0110.RowCount; i ++)
				{
					if(grdINV0110.GetItemString(i, "select") == " ")
						dloReturnValue.LayoutTable.ImportRow(grdINV0110.LayoutTable.Rows[i]);
				}
			}
			catch
			{				
				
			}

			if(dloReturnValue.LayoutTable.Rows.Count < 1 )
			{
                mbxMsg = Resources.MSG001;
                mbxCap = Resources.MSG_XN;
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;									
			}


			//Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
            commandParams.Add("INV0110", dloReturnValue);
			scrOpener.Command(ScreenID, commandParams);
			this.Close();
		}

		/// <summary>
		/// 항목정보를 조회합니다.
		/// </summary>
        private string query_code = "";
        private void LoadINV0110()
		{			
            query_code = this.txtJaeryo_index.GetDataValue().Trim();

            //if( query_code == "%" ||
            //    query_code == "")
            //{
            //    return;	
            //}
            
			//grdHangmogInfo.SetBindVarValue("f_query_code",  query_code);
            grdINV0110.ParamList = new List<string>(new String[] {"f_page_number", "f_offset" });
            grdINV0110.ExecuteQuery = this.GetQuerySql;

            grdINV0110.SetBindVarValue("f_hosp_code",   mHospCode);           
            

            if (!grdINV0110.QueryLayout(false))
			{
                mbxMsg = Resources.MSG002;
                mbxCap = Resources.MSG_XN;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                this.txtJaeryo_index.Focus();

                return;					
			}

            if (grdINV0110.RowCount < 1)
            {
                mbxMsg = Resources.MSG003;
                mbxCap = Resources.MSG_XN;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                this.txtJaeryo_index.Focus();

                return;	
            }

            SelectionBackColorChange(grdINV0110);

            this.txtJaeryo_index.Focus();

			return;
		}

        private string LoadKatakanaFull(string aText)
        {
            string cmd = "SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aText + "' )"
                       + "  FROM DUAL ";

            object retValue = Service.ExecuteScalar(cmd);

            if (retValue == null || TypeCheck.IsNull(retValue))
                return "";

            return retValue.ToString();
        }

        private IList<object[]> GetQuerySql(BindVarCollection bc)
        {
            #region Comment by Cloud
//            string searchWord = "";
//            string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aText + "' ) FROM DUAL";
//            object returnVal = null;

//            if (aText != "%")
//            {
//                returnVal = Service.ExecuteScalar(cmd);
//            }

//            if (returnVal != null && returnVal.ToString() != "" && returnVal.ToString() != "%")
//            {
//                searchWord = returnVal.ToString();
//            }

//            cmd = @" -- INV0110 --
//                    SELECT A.JAERYO_CODE
//                         , A.JAERYO_NAME
//                         , A.SUBUL_DANUI
//                         , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', A.SUBUL_DANUI) SUBUL_DANUI_NAME 
//                         , A.SUBUL_DANGA
//                      FROM INV0110 A
//                     WHERE A.HOSP_CODE = :f_hosp_code
//                       AND A.JAERYO_NAME_INX LIKE " + "'%'||'" + searchWord + "'||'%' "
//                       + @"AND A.STOCK_YN  = 'Y'
//                     ORDER BY
//                           A.JAERYO_CODE ";

//            return cmd; 
            #endregion
            List<object[]> res = new List<object[]>();
            LoadINV0110Q00Args args = new LoadINV0110Q00Args();
            args.JaeryoNameInx = query_code != null ? query_code : "";
            args.OffSet = "200";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            LoadINV0110Q00Result result = CloudService.Instance.Submit<LoadINV0110Q00Result, LoadINV0110Q00Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (LoadINV0110Q00Info info in result.ListItem)
                {
                    object[] objects = 
                        {
                            info.JaeryoCode,
                            info.JaeryoName,
                            info.SubulDanui,
                            info.SubulDanuiName,
                            info.SubulDanga
                        };
                    res.Add(objects);
                }
            }
            return res;
        }

		private void xButton1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(JapanTextHelper.GetFullKatakana(txtJaeryo_index.GetDataValue().Trim(),true));
		
		}

		private void ClearSelect()
		{
			for(int i = 0; i < grdINV0110.RowCount; i++)
			{
				grdINV0110.SetItemValue(i, "select", "");				
			}
		}

		#endregion

		#region [Control Event]
		/// <summary>
		/// 선택한 row를 returnValue로 생성한다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnValue();		
		}

        private void txtJaeryo_index_ImeModeChanged(object sender, EventArgs e)
        {
            PostCallHelper.PostCall(new PostMethod(setIMEKana));
        }

        private void txtJaeryo_index_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.LoadINV0110();
        }

		private void setIMEKana()
		{
			this.txtJaeryo_index.ImeMode = System.Windows.Forms.ImeMode.Katakana;
		}

        #region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
        private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
        {
            XGrid grdObject = (XGrid)grd;
            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
                grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            else
                grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

            for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            {
                if (data == "Y")
                {
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                }
                else
                {
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                }
            }

        }

        private void SelectionBackColorChange(object grd)
        {
            XGrid grdObject = (XGrid)grd;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "select").ToString() == " ")
                {
                    //image 변경
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;

                        //grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new XColor(Color.Red);
                    }
                }
                else
                {
                    //image 변경
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;

                        //grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new XColor(Color.Red);
                    }
                }
            }
        }
        #endregion

        private void grdINV0110_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex;
            curRowIndex = grdINV0110.GetHitRowNumber(e.Y);
            if (curRowIndex < 0) return;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (grdINV0110.GetItemString(curRowIndex, "select") == "")
                {
                    this.grdINV0110.SetItemValue(curRowIndex, "select", " ");
                    SelectionBackColorChange(sender, curRowIndex, "Y");
                }

                CreateReturnValue();
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdINV0110.CurrentColNumber < 1)
            {
                if (grdINV0110.CurrentColNumber < 1)
                {
                    //오더를 선택하면 검색어는 clear한다.
                    txtJaeryo_index.SetDataValue("");

                    if (!mMultiSelect) this.ClearSelect();

                    if (grdINV0110.GetItemString(curRowIndex, "select") == "")
                    {
                        grdINV0110.SetItemValue(curRowIndex, "select", " ");
                        SelectionBackColorChange(sender, curRowIndex, "Y");
                    }
                    else
                    {
                        grdINV0110.SetItemValue(curRowIndex, "select", "");
                        SelectionBackColorChange(sender, curRowIndex, "N");
                    }
                }

            }
        }

        private void grdINV0110_GridContDisplayed(object sender, XGridContDisplayedEventArgs e)
        {
            SelectionBackColorChange(grdINV0110);
        }
        #endregion
    }
}
