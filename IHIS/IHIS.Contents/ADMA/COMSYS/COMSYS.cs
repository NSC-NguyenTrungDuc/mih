using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using COMSYS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.ADMA
{
	/// <summary>
	/// RegSystemForm에 대한 요약 설명입니다.
	/// </summary>
	internal class COMSYS : IHIS.Framework.XScreen
	{
		[DataBindable]
		public string UserID
		{
			get { return this.userGroup;}
		}
		private string userGroup = "";  //전달받은 사용자 그룹
		private bool isDraggingSysList = false;  //시스템리스트의 시스템을 사용시스템으로 Drag하는지여부, False이면 사용시스템->시스템
		private System.Windows.Forms.ListView lvSysList;
		private System.Windows.Forms.Panel pnlBottom;
		private IHIS.Framework.XButton btnRegAll;
		private IHIS.Framework.XButton btnUnRegAll;
		private IHIS.Framework.XButton btnSave;
		private IHIS.Framework.XButton btnClose;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.ListView lvRegList;
		private IHIS.Framework.MultiLayout laySysList;
        //private IHIS.Framework.MultiLayout dsvGetSysList;
        //private IHIS.Framework.MultiLayout dsvGetLoginSysList;
		//private IHIS.Framework.DataServiceMISO dsvSetLoginSysList;
        private IHIS.Framework.MultiLayout layLoginSysList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private String hosp_code = "";

        public COMSYS(string userGroup, string hospCode)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
            //this.userGroup = userGroup;
            

			//설명 SET
//			this.lbDesc.Text = "※ 등록시에는 좌측리스트에서 시스템을 선택후 우측리스트로 끌어놓기합니다.\n"
//				+ "※ 해제시에는 우측리스트에서 시스템을 선택후 좌측으로 끌어놓기합니다.";
			//this.lbDesc.Text = "\n※ 登録解除方法 ※\n"
			//	+ "    登録時には左のリストでシステムを選んだ後で右のリストに引いて置きます。\n"
			//	+ "    解除時には右のリストでシステムを選んだ後で左のリストに引いて置きます。";
            this.lbDesc.Text = Resources.TEXT1;

            // Connect to cloud
            laySysList.ExecuteQuery = ExecuteQueryADM103LaySysListGrp;
            layLoginSysList.ParamList = new List<string>(new String[] {"f_user_id"});
		    layLoginSysList.ExecuteQuery = ExecuteQueryADM103LayLoginSysItem;
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMSYS));
            this.lvSysList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lbDesc = new System.Windows.Forms.Label();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnUnRegAll = new IHIS.Framework.XButton();
            this.btnRegAll = new IHIS.Framework.XButton();
            this.lvRegList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.laySysList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layLoginSysList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySysList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoginSysList)).BeginInit();
            this.SuspendLayout();
            // 
            // lvSysList
            // 
            this.lvSysList.AllowDrop = true;
            this.lvSysList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            resources.ApplyResources(this.lvSysList, "lvSysList");
            this.lvSysList.Name = "lvSysList";
            this.lvSysList.UseCompatibleStateImageBehavior = false;
            this.lvSysList.View = System.Windows.Forms.View.Details;
            this.lvSysList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSysList_DragDrop);
            this.lvSysList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvSysList_MouseMove);
            this.lvSysList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSysList_MouseDown);
            this.lvSysList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSysList_DragEnter);
            this.lvSysList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lvSysList_GiveFeedback);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lbDesc);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnUnRegAll);
            this.pnlBottom.Controls.Add(this.btnRegAll);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // lbDesc
            // 
            resources.ApplyResources(this.lbDesc, "lbDesc");
            this.lbDesc.Name = "lbDesc";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUnRegAll
            // 
            resources.ApplyResources(this.btnUnRegAll, "btnUnRegAll");
            this.btnUnRegAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnRegAll.Image")));
            this.btnUnRegAll.Name = "btnUnRegAll";
            this.btnUnRegAll.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnUnRegAll.Click += new System.EventHandler(this.btnUnRegAll_Click);
            // 
            // btnRegAll
            // 
            resources.ApplyResources(this.btnRegAll, "btnRegAll");
            this.btnRegAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRegAll.Image")));
            this.btnRegAll.Name = "btnRegAll";
            this.btnRegAll.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnRegAll.Click += new System.EventHandler(this.btnRegAll_Click);
            // 
            // lvRegList
            // 
            this.lvRegList.AllowDrop = true;
            this.lvRegList.BackColor = System.Drawing.Color.Khaki;
            this.lvRegList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            resources.ApplyResources(this.lvRegList, "lvRegList");
            this.lvRegList.Name = "lvRegList";
            this.lvRegList.UseCompatibleStateImageBehavior = false;
            this.lvRegList.View = System.Windows.Forms.View.Details;
            this.lvRegList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvRegList_DragDrop);
            this.lvRegList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvRegList_MouseMove);
            this.lvRegList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvRegList_MouseDown);
            this.lvRegList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvRegList_DragEnter);
            this.lvRegList.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lvRegList_GiveFeedback);
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // laySysList
            // 
            this.laySysList.ExecuteQuery = null;
            this.laySysList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.laySysList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySysList.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sys_id";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sys_nm";
            // 
            // layLoginSysList
            // 
            this.layLoginSysList.ExecuteQuery = null;
            this.layLoginSysList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layLoginSysList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLoginSysList.ParamList")));
            this.layLoginSysList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layLoginSysList_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sys_id";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "sys_nm";
            // 
            // RegSystemForm
            // 
            resources.ApplyResources(this, "$this");
            //this.CancelButton = this.btnClose;
            this.Controls.Add(this.lvRegList);
            this.Controls.Add(this.lvSysList);
            this.Controls.Add(this.pnlBottom);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "COMSYS";
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.lvSysList, 0);
            this.Controls.SetChildIndex(this.lvRegList, 0);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySysList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoginSysList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            //tungtx
		    if (this.OpenParam != null)
		    {
		        try
		        {
                    if (OpenParam.Contains("user_group"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["user_group"].ToString()))
                            this.userGroup = OpenParam["user_group"].ToString();
                    }

                    if (OpenParam.Contains("hosp_code"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["hosp_code"].ToString()))
                            this.hosp_code = OpenParam["hosp_code"].ToString();
                    }
		        }
		        catch (Exception ex)
		        {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
		        }
		    }

			//시스템리스트조회하여 lvSysList구성, 등록된 시스템 조회하여 lvRegList 구성
			//Item은 DragItem을 생성하여 Set
			ListViewItem lvItem = null;
            if (this.laySysList.QueryLayout(false))
			{
				foreach (DataRow dtRow in this.laySysList.LayoutTable.Rows)
				{
					lvItem = new ListViewItem(dtRow["sys_id"].ToString() + "." + dtRow["sys_nm"].ToString());
					lvItem.Tag = dtRow["sys_id"].ToString(); //Tag에 SystemID 저장
					this.lvSysList.Items.Add(lvItem);
				}
			}
            if (this.layLoginSysList.QueryLayout(false))
            {
                foreach (DataRow dtRow in this.layLoginSysList.LayoutTable.Rows)
                {
                    lvItem = new ListViewItem(dtRow["sys_id"].ToString() + "." + dtRow["sys_nm"].ToString());
                    lvItem.Tag = dtRow["sys_id"].ToString(); //Tag에 SystemID 저장
                    this.lvRegList.Items.Add(lvItem);
                }
            }

		}
		#endregion

		#region DragDrop 관련
		private bool	m_bCanDrag = false;
		private int		m_iDragX = 0;
		private int		m_iDragY = 0;
		private void lvSysList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//시스템리스트를 Drag하였으면 return(사용시스템리스트를 Drag시만 반영함)
			if (this.isDraggingSysList) return;

			ListView.SelectedListViewItemCollection selectedItems = e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)) as ListView.SelectedListViewItemCollection;
			
			//lvRegList에서 해당 Item Remove
			ListViewItem lvItem = null;
			for (int i = selectedItems.Count - 1 ; i >= 0 ; i--)
			{
				lvItem = selectedItems[i];
				lvRegList.Items.Remove(lvItem);
			}
		}

		private void lvSysList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}
		private void lvSysList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = DragHelper.DragCursor;
		}

		private void lvRegList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//사용시스템리스트를 Drag하였으면 return(시스템리스트를 Drag시만 반영함)
			if (!this.isDraggingSysList) return;

			ListView.SelectedListViewItemCollection selectedItems = e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)) as ListView.SelectedListViewItemCollection;
			bool isSame = false;
			foreach (ListViewItem lvItem in selectedItems)
			{
				isSame = false;
				//lvRegList에 해당 Item Add (동일한 SystemID Check)
				foreach (ListViewItem item in this.lvRegList.Items)
				{
					if (item.Text == lvItem.Text)
					{
						isSame = true;
						break;
					}
				}
				if (!isSame)  // 없으면 Add
				{
					ListViewItem lvwItem = new ListViewItem(lvItem.Text);
					lvwItem.Tag = lvItem.Tag; //Tag에 SYS_ID 저장
					this.lvRegList.Items.Add(lvwItem);
				}

			}
		}

		private void lvRegList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListView.SelectedListViewItemCollection)))
				e.Effect = DragDropEffects.Move;
		}

		private void lvRegList_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = DragHelper.DragCursor;
		}
		private void lvSysList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_bCanDrag = true;
				m_iDragX = e.X;
				m_iDragY = e.Y;
			}
		}

		private void lvRegList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_bCanDrag = true;
				m_iDragX = e.X;
				m_iDragY = e.Y;
			}
		}
		private void lvRegList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (m_bCanDrag && (Math.Abs(e.X - m_iDragX) > 3 || Math.Abs(e.Y - m_iDragY) > 3))
			{
				m_bCanDrag = false;
				// 여러개 DragDrop 가능
				if (lvRegList.SelectedItems.Count > 0)
				{
					isDraggingSysList = false; //Flag Set(FALSE)
					string text = "";
					foreach (ListViewItem item in lvRegList.SelectedItems)
					{
						text += item.Text + "\n";
					}
					text = text.Substring(0, text.Length -1); //마지막 NL 제거
					DragHelper.CreateDragCursor(lvRegList, text, lvRegList.Font);
					lvRegList.DoDragDrop(lvRegList.SelectedItems, DragDropEffects.Move);
				}
			}
		}

		private void lvSysList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (m_bCanDrag && (Math.Abs(e.X - m_iDragX) > 3 || Math.Abs(e.Y - m_iDragY) > 3))
			{
				m_bCanDrag = false;
				// 여러개 DragDrop 가능
				if (lvSysList.SelectedItems.Count > 0)
				{
					isDraggingSysList = true; //Flag Set
					string text = "";
					foreach (ListViewItem item in lvSysList.SelectedItems)
					{
						text += item.Text + "\n";
					}
					text = text.Substring(0, text.Length -1); //마지막 NL 제거
					DragHelper.CreateDragCursor(lvSysList, text, lvSysList.Font);
					lvSysList.DoDragDrop(lvSysList.SelectedItems, DragDropEffects.Move);
				}
			}
		}
		#endregion

		#region Button Event
		private void btnRegAll_Click(object sender, System.EventArgs e)
		{
			// 전체 등록처리
			this.lvRegList.Items.Clear();
			ListViewItem lvItem = null;
			foreach (ListViewItem item in this.lvSysList.Items)
			{
				lvItem = new ListViewItem(item.Text);
				lvItem.Tag = item.Tag;  //Tag에 저장된 Sys_ID Set
				this.lvRegList.Items.Add(lvItem);
			}
		}

		private void btnUnRegAll_Click(object sender, System.EventArgs e)
		{
			//전체 해제처리(Clear)
			this.lvRegList.Items.Clear();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            string QuerySQL = "";
            string mCap = "";
            string mMsg = "";

            BindVarCollection item = new BindVarCollection();

            // Connect to cloud

		    if (RegSystemFormSaveData())
		    {
                mMsg = Resources.MSG_2;
		        mCap = Resources.MSG_Caption_2;
		        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
		    }
		    else
		    {
		        mMsg = Resources.MSG_3;
                mCap = Resources.MSG_Caption_3;
                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
            // TODO: Comment connect to cloud
            /*Service.BeginTransaction();

            QuerySQL = @" DELETE FROM ADM3500
                           WHERE HOSP_CODE = :f_hosp_code
                             AND USER_ID   = :f_user_id";

            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_user_id", this.userGroup);
            if (Service.ExecuteNonQuery(QuerySQL, item) == false)
            {
                mCap = Resources.MSG_Caption_4;
                XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Service.RollbackTransaction();
                return;
            }

            QuerySQL = @" INSERT INTO ADM3500 
                                 (HOSP_CODE,   USER_ID,    SYS_ID,   WORK_TIME)
                          VALUES 
                                 (:f_hosp_code, :f_user_id, :f_sys_id, SYSDATE)";

            foreach (ListViewItem lvItem in this.lvRegList.Items)
            {
                item.Clear();
                item.Add("f_hosp_code", EnvironInfo.HospCode);
                item.Add("f_user_id", this.userGroup);
                item.Add("f_sys_id", lvItem.Tag.ToString());

                if (Service.ExecuteNonQuery(QuerySQL, item) == false)
                {
                    mCap = NetInfo.Language == LangMode.Ko ? "등록실패" : "登録失敗";
                    XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Service.RollbackTransaction();
                    return;
                }
            }
            mMsg = Resources.MSG_3;
            mCap = Resources.MSG_Caption_2;
            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Service.CommitTransaction();*/

			//저장처리
			//layLoginSysList에 데이타 SET (처음행은 항상 ALLS로 처리함,전체삭제시 처리하기 위함)
            //this.layLoginSysList.Reset();
            //int rowNum = this.layLoginSysList.InsertRow();
            //this.layLoginSysList.SetItemValue(rowNum, "user_id", this.userGroup);
            //this.layLoginSysList.SetItemValue(rowNum, "sys_id", "ALLS");

            //foreach (ListViewItem item in this.lvRegList.Items)
            //{
            //    rowNum = this.layLoginSysList.InsertRow();
            //    this.layLoginSysList.SetItemValue(rowNum, "user_id", this.userGroup);
            //    this.layLoginSysList.SetItemValue(rowNum, "sys_id", item.Tag.ToString());  //Tag에 저장된 SysID Set
            //}
			
            ////저장 Service Call
            //this.DataServiceCall(this.dsvSetLoginSysList);
		}
		#endregion

        private void layLoginSysList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layLoginSysList.SetBindVarValue("f_user_id", this.userGroup);
        }

        #region Connect to cloud

        /// <summary>
        /// RegSystemFormSaveData
        /// </summary>
        /// <returns></returns>
	    private bool RegSystemFormSaveData()
	    {
	        ADM103RegSystemFormSaveLayoutArgs args = new ADM103RegSystemFormSaveLayoutArgs();
	        args.UserId = this.userGroup;
            args.HospCode = this.hosp_code;
            List<DataStringListItemInfo> listSysId = new List<DataStringListItemInfo>();
	        foreach (ListViewItem lvItem in this.lvRegList.Items)
	        {
                DataStringListItemInfo dataStringListItemInfo = new DataStringListItemInfo();
	            dataStringListItemInfo.DataValue = lvItem.Tag.ToString();
                listSysId.Add(dataStringListItemInfo);
	        }
	        args.SysId = listSysId;
	        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM103RegSystemFormSaveLayoutArgs>(args);
	        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
	            updateResult.Result == false)
	        {
	            return false;
	        }
	        return true;
	    }

        /// <summary>
        /// ExecuteQueryADM103LaySysListGrp
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> ExecuteQueryADM103LaySysListGrp(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        ADM103LaySysListGrpArgs args = new ADM103LaySysListGrpArgs();
            args.HospCode = this.hosp_code;
	        ADM103LaySysListGrpResult result =
	            CloudService.Instance.Submit<ADM103LaySysListGrpResult, ADM103LaySysListGrpArgs>(args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ADM103LaySysListGrpInfo item in result.GrpItem)
	            {
	                object[] objects =
	                {
	                    item.SysId,
	                    item.SysNm
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// ExecuteQueryADM103LayLoginSysItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryADM103LayLoginSysItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103LayLoginSysListArgs args = new ADM103LayLoginSysListArgs();
            args.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            args.HospCode = this.hosp_code;
            ADM103LayLoginSysListResult result = CloudService.Instance.Submit<ADM103LayLoginSysListResult, ADM103LayLoginSysListArgs>(args);
            if (result != null)
            {
                foreach (ADM103LayLoginSysListInfo item in result.ItemInfo)
                {
                    object[] objects = 
				{ 
					item.SysId, 
					item.SysNm
				};
                    res.Add(objects);
                }
            }
            return res;
        } 

	    #endregion
    }
}
