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
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.Framework;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0117Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0117Q00 : IHIS.Framework.XScreen
	{
		private string mbxMsg = "", mbxCap = "";
		
		private string mOrder_gubun = "";
        
		//수술부위
		private const int  MAXBUWI_NAME_LENGTH = 460;
		
		private bool mQueryMode = false;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XGrid grdScPre_modifier;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XButton btnSusik_name;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XTextBox txtBuwi_name;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGrid grdCHT0118;
		private System.Windows.Forms.TreeView tvwCHT0117;
        private MultiLayout dloCHT0117;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0117Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

		    dloCHT0117.ExecuteQuery = ExecuteQueryDloCHT0117Info;

            grdCHT0118.ParamList = new List<string>(new String[] { "f_gubun", "f_buwi", "f_buwi_name" });
		    grdCHT0118.ExecuteQuery = ExecuteQueryGrdCHT0118Info;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0117Q00));
            this.tvwCHT0117 = new System.Windows.Forms.TreeView();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnSusik_name = new IHIS.Framework.XButton();
            this.txtBuwi_name = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.grdCHT0118 = new IHIS.Framework.XGrid();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdScPre_modifier = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.dloCHT0117 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0118)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScPre_modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloCHT0117)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // tvwCHT0117
            // 
            this.tvwCHT0117.AccessibleDescription = null;
            this.tvwCHT0117.AccessibleName = null;
            resources.ApplyResources(this.tvwCHT0117, "tvwCHT0117");
            this.tvwCHT0117.BackColor = System.Drawing.SystemColors.Window;
            this.tvwCHT0117.BackgroundImage = null;
            this.tvwCHT0117.Font = null;
            this.tvwCHT0117.HideSelection = false;
            this.tvwCHT0117.ImageList = this.ImageList;
            this.tvwCHT0117.Name = "tvwCHT0117";
            this.tvwCHT0117.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCHT0117_AfterSelect);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnSusik_name);
            this.xPanel1.Controls.Add(this.txtBuwi_name);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnSusik_name
            // 
            this.btnSusik_name.AccessibleDescription = null;
            this.btnSusik_name.AccessibleName = null;
            resources.ApplyResources(this.btnSusik_name, "btnSusik_name");
            this.btnSusik_name.BackgroundImage = null;
            this.btnSusik_name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSusik_name.Name = "btnSusik_name";
            this.btnSusik_name.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSusik_name.Click += new System.EventHandler(this.btnSusik_name_Click);
            // 
            // txtBuwi_name
            // 
            this.txtBuwi_name.AccessibleDescription = null;
            this.txtBuwi_name.AccessibleName = null;
            resources.ApplyResources(this.txtBuwi_name, "txtBuwi_name");
            this.txtBuwi_name.BackgroundImage = null;
            this.txtBuwi_name.Name = "txtBuwi_name";
            this.txtBuwi_name.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBuwi_name_DataValidating);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnClose);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // grdCHT0118
            // 
            resources.ApplyResources(this.grdCHT0118, "grdCHT0118");
            this.grdCHT0118.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell10,
            this.xGridCell5,
            this.xGridCell6});
            this.grdCHT0118.ColPerLine = 1;
            this.grdCHT0118.Cols = 1;
            this.grdCHT0118.ExecuteQuery = null;
            this.grdCHT0118.FixedRows = 1;
            this.grdCHT0118.HeaderHeights.Add(21);
            this.grdCHT0118.Name = "grdCHT0118";
            this.grdCHT0118.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0118.ParamList")));
            this.grdCHT0118.QuerySQL = resources.GetString("grdCHT0118.QuerySQL");
            this.grdCHT0118.Rows = 2;
            this.grdCHT0118.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdCHT0118_MouseDown);
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "buwi";
            this.xGridCell10.Col = -1;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            this.xGridCell10.IsVisible = false;
            this.xGridCell10.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "sub_buwi";
            this.xGridCell5.Col = -1;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            this.xGridCell5.IsVisible = false;
            this.xGridCell5.Row = -1;
            // 
            // xGridCell6
            // 
            this.xGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell6.CellName = "sub_buwi_name";
            this.xGridCell6.CellWidth = 194;
            this.xGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdCHT0118);
            this.xPanel3.Controls.Add(this.xPanel1);
            this.xPanel3.Controls.Add(this.tvwCHT0117);
            this.xPanel3.Controls.Add(this.grdScPre_modifier);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdScPre_modifier
            // 
            resources.ApplyResources(this.grdScPre_modifier, "grdScPre_modifier");
            this.grdScPre_modifier.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4});
            this.grdScPre_modifier.ColPerLine = 1;
            this.grdScPre_modifier.Cols = 1;
            this.grdScPre_modifier.ExecuteQuery = null;
            this.grdScPre_modifier.FixedRows = 1;
            this.grdScPre_modifier.HeaderHeights.Add(21);
            this.grdScPre_modifier.Name = "grdScPre_modifier";
            this.grdScPre_modifier.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdScPre_modifier.ParamList")));
            this.grdScPre_modifier.Rows = 2;
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "susik_code";
            this.xGridCell1.Col = -1;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.CellName = "susik_name";
            this.xGridCell2.CellWidth = 175;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "susik_name_gana";
            this.xGridCell3.Col = -1;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "susik_detail_gubun";
            this.xGridCell4.Col = -1;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // dloCHT0117
            // 
            this.dloCHT0117.ExecuteQuery = null;
            this.dloCHT0117.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.dloCHT0117.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloCHT0117.ParamList")));
            this.dloCHT0117.QuerySQL = resources.GetString("dloCHT0117.QuerySQL");
            this.dloCHT0117.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloCHT0117_QueryStarting);
            this.dloCHT0117.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dloCHT0117_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "start_date";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "end_date";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "buwi";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "buwi_name";
            // 
            // CHT0117Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "CHT0117Q00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0118)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScPre_modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloCHT0117)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{				
			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("order_gubun"))
					{
						if(OpenParam["order_gubun"].ToString().Trim() != "")
							mOrder_gubun = OpenParam["order_gubun"].ToString();
					}
				}
				catch
				{
				}
			}

            //if(mOrder_gubun == "G")
            //{
            //    tvwCHT0117.SetBounds(tvwCHT0117.Location.X, tvwCHT0117.Location.Y, 0, tvwCHT0117.Size.Height);
            //    tvwCHT0117.Visible = false;
            //    grdCHT0118.AutoSizeColumn(0, MAXBUWI_NAME_LENGTH);
            //    LoadCHT0118(false);
            //}
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
            if (tvwCHT0117.Visible) this.dloCHT0117.QueryLayout(true);
		}
		#endregion

		#region [TreeView 부위구분]

		private void ShowCHT0117()
		{
			tvwCHT0117.Nodes.Clear();
			if(dloCHT0117.RowCount < 1) return;
            
			TreeNode node;

			foreach(DataRow row in dloCHT0117.LayoutTable.Rows)
			{
				node = new TreeNode( row["buwi_name"].ToString() );
				node.Tag = row["buwi"].ToString();
				tvwCHT0117.Nodes.Add(node);
			}

			if(dloCHT0117.RowCount > 0) tvwCHT0117.SelectedNode = tvwCHT0117.Nodes[0];
		}

		private void tvwCHT0117_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			LoadCHT0118(false);			
		}

		#endregion
        
		#region [Control Event]
		
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}
		
		private void btnSusik_name_Click(object sender, System.EventArgs e)
		{
			LoadCHT0118(true);			
		}

		private void txtBuwi_name_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadCHT0118(true);		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void grdCHT0118_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdCHT0118.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
				CreateReturnLayout();
			}
		}	
	
		#endregion

		#region [Return Layout 생성]
        
		private void CreateReturnLayout()
		{
			this.AcceptData();
			
			if( grdCHT0118.CurrentRowNumber < 0 )
			{				
				mbxMsg = NetInfo.Language == LangMode.Jr ? "部位が選択されませんでした。ご確認ください。" : "부위가 선택되지 않았습니다. 확인하세요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;				
			}
			
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "buwi_code", grdCHT0118.GetItemString(grdCHT0118.CurrentRowNumber, "sub_buwi"));
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
			
		}
		
		#endregion		
		
		#region [Function]
		/// <summary>
		/// 부위코드를 조회한다.
		/// </summary>
		/// <param name="search"></param>
		private void LoadCHT0118(bool search)
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				string gubun = "0";

				string buwi = "%";
				string buwi_name = "%";

				if(search)
				{
					buwi_name = txtBuwi_name.GetDataValue().Trim();
				}
				else
				{
					if(tvwCHT0117.SelectedNode != null) buwi = tvwCHT0117.SelectedNode.Tag.ToString();
				}
                
                this.grdCHT0118.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
				this.grdCHT0118.SetBindVarValue("f_gubun"    , gubun    );
                this.grdCHT0118.SetBindVarValue("f_buwi", buwi);
                this.grdCHT0118.SetBindVarValue("f_buwi_name", buwi_name);
                this.grdCHT0118.QueryLayout(false);
                
				//Button List Click시 전 조회조건으로 조회하기 위해서
				mQueryMode = search;				
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}			
		}
        
		#endregion

        private void dloCHT0117_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dloCHT0117.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void dloCHT0117_QueryEnd(object sender, QueryEndEventArgs e)
        {
            ShowCHT0117();
        }

        #region Connect to cloud

        /// <summary>
        /// ExecuteQueryDloCHT0117Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryDloCHT0117Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117Q00DloCHT0117Args vCHT0117Q00DloCHT0117Args = new CHT0117Q00DloCHT0117Args();
            CHT0117Q00DloCHT0117Result result = CloudService.Instance.Submit<CHT0117Q00DloCHT0117Result, CHT0117Q00DloCHT0117Args>(vCHT0117Q00DloCHT0117Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CHT0117Q00DloCHT0117Info item in result.Cht0117Info)
                {
                    object[] objects = 
				{ 
					item.StartDate, 
					item.EndDate, 
					item.Buwi, 
					item.BuwiName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdCHT0118Info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdCHT0118Info(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117Q00GrdCHT0118Args vCHT0117Q00GrdCHT0118Args = new CHT0117Q00GrdCHT0118Args();
            vCHT0117Q00GrdCHT0118Args.Gubun = bc["f_gubun"] != null ? bc["f_gubun"].VarValue : "";
            vCHT0117Q00GrdCHT0118Args.Buwi = bc["f_buwi"] != null ? bc["f_buwi"].VarValue : "";
            vCHT0117Q00GrdCHT0118Args.BuwiName = bc["f_buwi_name"] != null ? bc["f_buwi_name"].VarValue : "";
            CHT0117Q00GrdCHT0118Result result = CloudService.Instance.Submit<CHT0117Q00GrdCHT0118Result, CHT0117Q00GrdCHT0118Args>(vCHT0117Q00GrdCHT0118Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CHT0117Q00GrdCHT0118Info item in result.Grd0118Info)
                {
                    object[] objects = 
				{ 
					item.Buwi, 
					item.SubBuwi, 
					item.SubBuwiName, 
					item.ContKey
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion 
    }
}

