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
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0221Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0221Q01 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]
		// O: Open Function Call
		// M: MemoBox에서 Call
		//사용자
		string mMemb;
		//상용어구분
		string mCategory_gubun = "";
		//선택된 상용어구
		string mComment = "";
		#endregion

		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdOCS0222;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.MultiLayout dloOCS0221;
		private IHIS.Framework.XTreeView tvwOCS0221;
		private System.Windows.Forms.Splitter splitter2;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.MultiLayout dloSelectOCS0222;
		private IHIS.Framework.XPanel pnlButton;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0221Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            dloOCS0221.ParamList = new List<string>(new String[] { "f_memb", "f_category_gubun" });
		    dloOCS0221.ExecuteQuery = ExecuteQueryDloOCS0221Info;

            grdOCS0222.ParamList = new List<string>(new String[] { "f_memb", "f_seq" });
		    grdOCS0222.ExecuteQuery = ExecuteQueryGrdOCS0222Info;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0221Q01));
            this.pnlButton = new IHIS.Framework.XPanel();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0222 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dloOCS0221 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.tvwOCS0221 = new IHIS.Framework.XTreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dloSelectOCS0222 = new IHIS.Framework.MultiLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0222)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS0221)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0222)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // pnlButton
            // 
            this.pnlButton.AccessibleDescription = null;
            this.pnlButton.AccessibleName = null;
            resources.ApplyResources(this.pnlButton, "pnlButton");
            this.pnlButton.BackgroundImage = null;
            this.pnlButton.Controls.Add(this.btnProcess);
            this.pnlButton.Controls.Add(this.xButtonList1);
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Font = null;
            this.pnlButton.Name = "pnlButton";
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0222
            // 
            resources.ApplyResources(this.grdOCS0222, "grdOCS0222");
            this.grdOCS0222.CallerID = '2';
            this.grdOCS0222.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdOCS0222.ColPerLine = 2;
            this.grdOCS0222.Cols = 3;
            this.grdOCS0222.EnableMultiSelection = true;
            this.grdOCS0222.ExecuteQuery = null;
            this.grdOCS0222.FixedCols = 1;
            this.grdOCS0222.FixedRows = 1;
            this.grdOCS0222.FocusColumnName = "comment_title";
            this.grdOCS0222.HeaderHeights.Add(21);
            this.grdOCS0222.Name = "grdOCS0222";
            this.grdOCS0222.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0222.ParamList")));
            this.grdOCS0222.QuerySQL = resources.GetString("grdOCS0222.QuerySQL");
            this.grdOCS0222.RowHeaderVisible = true;
            this.grdOCS0222.Rows = 2;
            this.grdOCS0222.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0222_MouseDown);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "memb";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "seq";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "serial";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "comment_title";
            this.xEditGridCell9.CellWidth = 151;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "comment_text";
            this.xEditGridCell10.CellWidth = 341;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.DisplayMemoText = true;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "source_serial";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
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
            // 
            // dloOCS0221
            // 
            this.dloOCS0221.ExecuteQuery = null;
            this.dloOCS0221.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.dloOCS0221.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloOCS0221.ParamList")));
            this.dloOCS0221.QuerySQL = resources.GetString("dloOCS0221.QuerySQL");
            this.dloOCS0221.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dloOCS0221_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "memb";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "seq";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "category_gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "category_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "comment_limit";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // tvwOCS0221
            // 
            this.tvwOCS0221.AccessibleDescription = null;
            this.tvwOCS0221.AccessibleName = null;
            resources.ApplyResources(this.tvwOCS0221, "tvwOCS0221");
            this.tvwOCS0221.BackgroundImage = null;
            this.tvwOCS0221.ImageList = this.ImageList;
            this.tvwOCS0221.Name = "tvwOCS0221";
            this.tvwOCS0221.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwOCS0221_AfterSelect);
            // 
            // splitter2
            // 
            this.splitter2.AccessibleDescription = null;
            this.splitter2.AccessibleName = null;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.BackgroundImage = null;
            this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter2.Font = null;
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // dloSelectOCS0222
            // 
            this.dloSelectOCS0222.ExecuteQuery = null;
            this.dloSelectOCS0222.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS0222.ParamList")));
            // 
            // OCS0221Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdOCS0222);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.tvwOCS0221);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlButton);
            this.Name = "OCS0221Q01";
            this.UserChanged += new System.EventHandler(this.OCS0221Q01_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0221Q01_ScreenOpen);
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0222)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS0221)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0222)).EndInit();
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

		private void OCS0221Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{					
					if(OpenParam.Contains("category_gubun"))
						mCategory_gubun = OpenParam["category_gubun"].ToString();													
					
				}
				catch
				{
				}
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	  
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS0221Q01_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

		}
		
		/// <summary>
		/// 사용자 변경시
		/// </summary>
		/// <remarks>
		/// 사용자별 상용어를 제조회한다.
		/// </remarks>
		private void OCS0221Q01_UserChanged(object sender, System.EventArgs e)
		{
			mMemb = UserInfo.UserID.ToString();			
			
			//해당 상용어구분의 상용어구분정보를 가져온다.
            dloOCS0221.SetBindVarValue("f_memb", mMemb);
            //dloOCS0221.SetBindVarValue("f_memb", mMemb);
            dloOCS0221.SetBindVarValue("f_category_gubun", mCategory_gubun);
            dloOCS0221.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			dloOCS0221.QueryLayout(true);			
		}
		#endregion

		#region [TreeView 상용어구분]

		private void ShowOCS0221()
		{
			tvwOCS0221.Nodes.Clear();
			if(dloOCS0221.RowCount < 1) return;
            
			TreeNode node;

			string seq = "";

			foreach(DataRow row in dloOCS0221.LayoutTable.Rows)
			{
				if(seq != row["seq"].ToString())
				{
					node = new TreeNode( row["category_name"].ToString() );
					node.Tag = row["seq"].ToString();
					tvwOCS0221.Nodes.Add(node);
					seq = row["seq"].ToString();	
				}				
			}

			if(dloOCS0221.RowCount > 0) tvwOCS0221.SelectedNode = tvwOCS0221.Nodes[0];


		}

		private void tvwOCS0221_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{	
			try
			{
                mMemb = UserInfo.UserID.ToString();
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				string seq = tvwOCS0221.SelectedNode.Tag.ToString();
                this.grdOCS0222.SetBindVarValue("f_memb", mMemb);
                this.grdOCS0222.SetBindVarValue("f_seq", seq);
                this.grdOCS0222.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdOCS0222.QueryLayout(false);
				
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		#endregion

		#region [Service Control Event]
        
		/// <summary>
		/// 서비스가 종료되면 TreeView를 생성한다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dloOCS0221_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			ShowOCS0221();
		}

		#endregion
				
		#region [Return Layout 생성]
        
		private void CreateReturnLayout()
		{
			this.AcceptData();
            for (int i = 0; i < this.grdOCS0222.RowCount; i++)
            {
                if (this.grdOCS0222.IsSelectedRow(i))
                {
                    mComment += grdOCS0222.GetItemString(i, "comment_text") + ",";
                }
            }

            //if (grdOCS0222.CurrentRowNumber >= 0)
            //    mComment = grdOCS0222.GetItemString(grdOCS0222.CurrentRowNumber, "comment_text");
		}

		#endregion

		#region [Control Event]

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();

			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "COMMENT", mComment);
			scrOpener.Command(ScreenID, commandParams);

			Close();
		}

		#endregion

		#region [grdOCS0222 Event]
        
		private void grdOCS0222_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{				
				
				curRowIndex = grdOCS0222.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				CreateReturnLayout();

				//약속코드선택정보가 있는 경우 Return Value
				IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

				CommonItemCollection commandParams  = new CommonItemCollection();
				commandParams.Add( "COMMENT", mComment);
				scrOpener.Command(ScreenID, commandParams);

				Close();				
			}
		}

		#endregion

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;

                    this.dloOCS0221.QueryLayout(true);
					break;

				default:

					break;
			}	
		
		}		
		#endregion

        #region Connect to cloud service
        /// <summary>
        /// ExecuteQueryDloOCS0221Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryDloOCS0221Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0221Q01DloOCS0221Args vOCS0221Q01DloOCS0221Args = new OCS0221Q01DloOCS0221Args();
            vOCS0221Q01DloOCS0221Args.CategoryGubun = bc["f_category_gubun"] != null ? bc["f_category_gubun"].VarValue : "";
            vOCS0221Q01DloOCS0221Args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            OCS0221Q01DloOCS0221Result result = CloudService.Instance.Submit<OCS0221Q01DloOCS0221Result, OCS0221Q01DloOCS0221Args>(vOCS0221Q01DloOCS0221Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0221Q01DloOCS0221Info item in result.DloOCS0221Info)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.Seq, 
					item.CategoryGubun, 
                    item.CategoryName,
					item.CommentLimit
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0222Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0222Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0221Q01GrdOCS0222Args vOCS0221Q01GrdOCS0222Args = new OCS0221Q01GrdOCS0222Args();
            vOCS0221Q01GrdOCS0222Args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            vOCS0221Q01GrdOCS0222Args.Seq = bc["f_seq"] != null ? bc["f_seq"].VarValue : "";
            OCS0221Q01GrdOCS0222Result result = CloudService.Instance.Submit<OCS0221Q01GrdOCS0222Result, OCS0221Q01GrdOCS0222Args>(vOCS0221Q01GrdOCS0222Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0221Q01GrdOCS0222Info item in result.GrdOCS0222Info)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.Seq, 
					item.Serial, 
					item.CommentTitle, 
					item.CommentText
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion

    }
}

