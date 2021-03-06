using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//
using IHIS.Framework;

namespace IHIS
{
	/// <summary>
	/// MsgSystemForm에 대한 요약 설명입니다.
	/// </summary>
	internal class MsgSystemForm : System.Windows.Forms.Form
	{
		private DataTable msgSystemTable = null;
		private ArrayList runSystemList = null;
		private string selectedSystemID = ""; //선택된 시스템 ID
		internal DataRow SelectedRow
		{
			get 
			{ 
				foreach (DataRow dtRow in msgSystemTable.Rows)
				{
					if (dtRow["SystemID"].ToString() == selectedSystemID)
						return dtRow;
				}
				return null;
			}
		}
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.ListView lvList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private IHIS.XPButton btnOK;
		private IHIS.XPButton btnCancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region 생성자
		public MsgSystemForm(Control cont, DataTable systemTable, ArrayList runSystemList)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.msgSystemTable = systemTable;
			this.runSystemList = runSystemList;

			//위치조정
			// 위치조정(Find창을 Call한 Control의 하단에
			if (cont != null)
			{
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y - cont.Height)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= (this.Height + cont.Height);
				}
				this.Location = pos;
			}

			//일본,한글 모드에 따른 Control Text Set
			SetControlTextByLangMode();

		}
		#endregion

		#region Dispose
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.lvList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lbDesc = new System.Windows.Forms.Label();
            this.btnOK = new IHIS.XPButton();
            this.btnCancel = new IHIS.XPButton();
            this.SuspendLayout();
            // 
            // lvList
            // 
            this.lvList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvList.FullRowSelect = true;
            this.lvList.GridLines = true;
            this.lvList.Location = new System.Drawing.Point(8, 8);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(180, 160);
            this.lvList.TabIndex = 0;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "시스템명";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "사용중";
            this.columnHeader2.Width = 67;
            // 
            // lbDesc
            // 
            this.lbDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbDesc.Location = new System.Drawing.Point(194, 24);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(200, 144);
            this.lbDesc.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(221, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "확  인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(312, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Schemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(76, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취 소";
            // 
            // MsgSystemForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 201);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.lvList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MsgSystemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//시스템ListView 구성
			//메세지시스템중에서 AMSG(전체 공통 MSG System)은 List에서 제외함
			string systemName = "", systemID = "", isUse = "", desc;
			ListViewItem lvItem = null;
			foreach (DataRow dtRow in this.msgSystemTable.Rows)
			{
				systemID = dtRow["SystemID"].ToString();
				if (systemID != "ADMM")
				{
					systemName = dtRow["SystemName"].ToString();
					desc = dtRow["Description"].ToString();
					if (this.runSystemList.Contains(systemID))
						isUse = XMsg.GetField("F015"); // 사용중
					else
						isUse = XMsg.GetField("F016"); // 미사용
					//순서는 SystemName, IsUse, SystemID, Desc
					lvItem = new ListViewItem(new string[]{systemName, isUse, systemID, desc});
					//Tag에 시스템ID 저장
					lvItem.Tag = systemID;
					this.lvList.Items.Add(lvItem);
				}
			}
			if (this.lvList.Items.Count > 0)  //첫번째 Select
				this.lvList.Items[0].Selected = true;
		}

		#endregion

		private void lvList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//선택 Index가 바뀔때 Desc Set
			if (this.lvList.SelectedItems.Count > 0)
				this.lbDesc.Text = this.lvList.SelectedItems[0].SubItems[3].Text;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string title = XMsg.GetMsg("M030"); // 등록확인" : "登録確認");
			string msg = "";
			//선택여부 확인, 기사용중인지 여부 확인
			if (this.lvList.SelectedItems.Count < 1)
			{
				msg = XMsg.GetMsg("M031"); // 등록할 메세지시스템을 선택하십시오."
				XMessageBox.Show(msg, title);
				return;
			}
			if (this.lvList.SelectedItems[0].SubItems[1].Text == XMsg.GetField("F015"))
			{
				msg = XMsg.GetMsg("M032"); // 이미 사용중인 메세지시스템입니다."
				XMessageBox.Show(msg, title);
				return;
			}
			//다시한번 Confirm확인
			string sysName = this.lvList.SelectedItems[0].Text;
			msg = "[" + sysName + "]" + XMsg.GetMsg("M033"); // 시스템을 등록하시겠습니까?"
			if (XMessageBox.Show(msg,title, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				//선택된 시스템ID SET
				this.selectedSystemID = this.lvList.SelectedItems[0].Tag.ToString();
				this.DialogResult = DialogResult.OK;
			}

		}

		private void SetControlTextByLangMode()
		{
			this.btnCancel.Text = XMsg.GetField("F017"); // 취 소" : "取消し");
			this.btnOK.Text = XMsg.GetField("F018"); // 확 인" : "確 認");
			this.columnHeader1.Text = XMsg.GetField("F019"); // 시스템명" : "システム名");
			this.columnHeader2.Text = XMsg.GetField("F015"); // 사용중" : "使用中");
		}
	}
}
