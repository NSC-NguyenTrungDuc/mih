using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// UserSelectForm에 대한 요약 설명입니다.
	/// </summary>
	internal class UserSelectForm : System.Windows.Forms.Form
	{
		//선택된 사용자정보
		private UserItem selectedUserItem = null;
		public UserItem SelectedUserItem
		{
			get { return selectedUserItem;}
		}
		private System.Windows.Forms.ListView lvwList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserSelectForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//일본어 변환
			SetControlNameByLangMode();
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
            this.btnOK = new IHIS.Framework.XButton();
            this.lvwList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(171, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwList
            // 
            this.lvwList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.Location = new System.Drawing.Point(2, 2);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(327, 134);
            this.lvwList.TabIndex = 1;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "사용자명";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "사용자ID";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "접속시스템";
            this.columnHeader3.Width = 136;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(68, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취 소";
            // 
            // UserSelectForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(331, 166);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserSelectForm";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "메세지 사용자 선택";
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//FormMain.UserItemList에서 UserItem을 가져와 lvwList 구성
			ListViewItem lvItem = null;
			foreach (UserItem item in MainForm.UserItemList)
			{
				lvItem = new ListViewItem(new string[]{item.UserName, item.UserID, item.SystemName});
				lvItem.Tag = item;  //Tag에 UserItem 저장
				this.lvwList.Items.Add(lvItem);
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (lvwList.SelectedItems.Count < 1)
			{
				XMessageBox.Show("ユーザーを選んでください。");
				return;
			}
			//선택된 사용자 정보 SET
			this.selectedUserItem = (UserItem) lvwList.SelectedItems[0].Tag;
			this.DialogResult = DialogResult.OK;
		}

		private void lvwList_DoubleClick(object sender, System.EventArgs e)
		{
			//사용자 선택처리
			this.btnOK.PerformClick();
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "メッセージユーザー選択";  //메세지사용자선택
				this.btnCancel.Text = "取消し";  //취소
				this.btnOK.Text = "確 認";  //확인
				this.columnHeader1.Text = "ユーザー名"; //사용자명
				this.columnHeader2.Text = "ユーザーID"; //사용자ID
				this.columnHeader3.Text = "接続システム";  //접속시스템
			}
		}
	}
}
