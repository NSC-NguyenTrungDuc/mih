using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// UserChangeForm에 대한 요약 설명입니다.
	/// </summary>
	internal class UserChangeForm : System.Windows.Forms.Form
	{
		//선택된 사용자정보
		private UserItem selectedUserItem = null;
		private bool isAddedUser = false; //추가된 사용자 인지여부, 리스트에서 선택시는 false, 새 사용자 입력시는 true
		public UserItem SelectedUserItem
		{
			get { return selectedUserItem;}
		}
		public bool IsAddedUser
		{
			get { return isAddedUser;}
		}
		private System.Windows.Forms.ListView lvwList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		private System.Windows.Forms.Label lbTitle;
		private IHIS.Framework.XTextBox txtPswd;
		private IHIS.Framework.XTextBox txtUserID;
		private System.Windows.Forms.Label lbPswd;
		private System.Windows.Forms.Label lbUserID;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserChangeForm()
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtPswd = new IHIS.Framework.XTextBox();
            this.txtUserID = new IHIS.Framework.XTextBox();
            this.lbPswd = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(164, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 26);
            this.btnOK.TabIndex = 2;
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
            this.lvwList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.Location = new System.Drawing.Point(2, 48);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(320, 100);
            this.lvwList.TabIndex = 4;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "사용자명";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "사용자ID";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "접속시스템";
            this.columnHeader3.Width = 122;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(68, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취 소";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lbTitle.Location = new System.Drawing.Point(4, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(294, 39);
            this.lbTitle.TabIndex = 5;
            this.lbTitle.Text = "※ 기존 사용자를 선택(더블클릭) 하거나 새 사용자를 입력후 확인을 누릅니다.";
            // 
            // txtPswd
            // 
            this.txtPswd.Location = new System.Drawing.Point(246, 152);
            this.txtPswd.MaxLength = 4;
            this.txtPswd.Name = "txtPswd";
            this.txtPswd.PasswordChar = '*';
            this.txtPswd.Size = new System.Drawing.Size(68, 20);
            this.txtPswd.TabIndex = 1;
            this.txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPswd_KeyPress);
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUserID.Location = new System.Drawing.Point(94, 152);
            this.txtUserID.MaxLength = 8;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(70, 20);
            this.txtUserID.TabIndex = 0;
            // 
            // lbPswd
            // 
            this.lbPswd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPswd.Location = new System.Drawing.Point(168, 152);
            this.lbPswd.Name = "lbPswd";
            this.lbPswd.Size = new System.Drawing.Size(78, 21);
            this.lbPswd.TabIndex = 7;
            this.lbPswd.Text = "비밀번호";
            this.lbPswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUserID
            // 
            this.lbUserID.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbUserID.Location = new System.Drawing.Point(20, 152);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(72, 21);
            this.lbUserID.TabIndex = 6;
            this.lbUserID.Text = "사용자ID";
            this.lbUserID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserChangeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 202);
            this.ControlBox = false;
            this.Controls.Add(this.txtPswd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lbPswd);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserChangeForm";
            this.Padding = new System.Windows.Forms.Padding(2, 48, 2, 30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "사용자 변경";
            this.ResumeLayout(false);
            this.PerformLayout();

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
			string msg = "";
			//사용자ID, 비밀번호 입력여부 확인
			if (txtUserID.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "사용자ID가 입력되지 않았습니다."
					: "ユーザーＩＤを入力してください。");
				XMessageBox.Show(msg);
				txtUserID.Focus();
				return;
			}
			if (txtPswd.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "비밀번호가 입력되지 않았습니다."
					: "パスワードを入力してください。");
				XMessageBox.Show(msg);
				txtPswd.Focus();
				return;
			}
			//이미 리스트에 있는 사용자이면 리스트 선택 유도
			foreach (UserItem item in MainForm.UserItemList)
			{
				if (item.UserID == txtUserID.Text.Trim())
				{
					msg = (NetInfo.Language == LangMode.Ko ? "사용자 리스트에서 선택하십시오."
						: "ユーザーリストから選んでください。");
					XMessageBox.Show(msg);
					return;
				}
			}

			//UserLogin 실패시 Return
			string errMsg = "";
			if (!UserInfoUtil.CheckUser("ADMM", txtUserID.Text.Trim(), txtPswd.Text.Trim(), out errMsg))
			{
				XMessageBox.Show(errMsg);
				return;
			}

			//선택된 사용자 정보 SET
			this.selectedUserItem = new UserItem(this.txtUserID.Text.Trim(), UserInfo.UserName, "","");
			this.isAddedUser = true;
			this.DialogResult = DialogResult.OK;
		}

		private void lvwList_DoubleClick(object sender, System.EventArgs e)
		{
			//선택된 사용자 정보 SET
			this.selectedUserItem = (UserItem) lvwList.SelectedItems[0].Tag;
			//동일한 사용자 여부 Check
			if (MainForm.CurrUserID == selectedUserItem.UserID)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "동일한 사용자 입니다.\n" + "다른 사용자를 선택하십시오."
					: "同じユーザーです。\n" + "他のユーザーを選んでください。");																									
				XMessageBox.Show(msg);
				return;
			}
		
			this.DialogResult = DialogResult.OK;
		}

		private void SetControlNameByLangMode()
		{
			this.lbTitle.Text = (NetInfo.Language == LangMode.Ko ? "※ 기존 사용자를 선택(더블클릭) 하거나\n" + "    새 사용자를 입력후 확인버튼을 누릅니다."
                : " ※ ユーザーの中から選択(ダブルクリック)するか\n" + 
                  "     新しいユーザーID・パスワードを入力して\n" + 
                  "     確認ボタンを押してください。");
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "メッセージユーザー変更";  //메세지사용자선택
				this.btnCancel.Text = "取消し";  //취소
				this.btnOK.Text = "確 認";  //확인
				this.columnHeader1.Text = "ユーザー名"; //사용자명
				this.columnHeader2.Text = "ユーザーID"; //사용자ID
				this.columnHeader3.Text = "接続システム";  //접속시스템
				this.lbUserID.Text = "ユーザーID";  //사용자ID
				this.lbPswd.Text = "パスワード";  //비밀번호
			}
		}

		private void txtPswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//EnterKey입력시 비밀번호가 입력되었으면 확인 Click 처리
			if ((e.KeyChar == (char)13) && (this.txtPswd.Text != ""))
				this.btnOK.PerformClick();
		}
	}
}
