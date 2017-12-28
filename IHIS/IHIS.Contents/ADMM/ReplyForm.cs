using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Data;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// ReplyForm에 대한 요약 설명입니다.
	/// </summary>
	internal class ReplyForm : System.Windows.Forms.Form
	{
		private MainForm parentForm = null;
		private string recverID = "";
		private string recverName = "";
		private System.Windows.Forms.TextBox txtMesg;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnSend;
		private System.Windows.Forms.Label lbRecv;
		private System.Windows.Forms.TextBox txtTitle;
        // <<2014.01.03>> LKH START : 답신 후 해당 메세지는 확인 처리한다.
        private String msgSendDT = "";
        private String msgSenderID = "";
        private String msgSendSeq = "";
        private String msgRecvSpot = "";
        private String msgRecverID = "";
        // <<2014.01.03>> LKH END   : 답신 후 해당 메세지는 확인 처리한다.

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        //public ReplyForm(MainForm parentForm, string recverID, string recverName, Control cont)
        public ReplyForm(MainForm parentForm, DataRow aRow, string recverID, string recverName, Control cont)
        {
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//일본어 전환
			SetControlNameByLangMode();
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
            this.parentForm = parentForm;
			this.recverID = recverID;
			this.recverName = recverName;
            this.lbRecv.Text = (NetInfo.Language == LangMode.Ko ? "수신자 : " + recverName + " [" + recverID + "]"
				: "受信先 : " + recverName + " [" + recverID + "]");

            // <<2014.01.03>> LKH START : 답신 후 해당 메세지는 확인 처리한다.
            this.msgSendDT = aRow["send_dt"].ToString();
            this.msgSenderID = aRow["sender_id"].ToString();
            this.msgSendSeq = aRow["send_seq"].ToString();
            this.msgRecvSpot = aRow["recv_spot"].ToString();
            this.msgRecverID = aRow["recver_id"].ToString();
            // <<2014.01.03>> LKH END   : 답신 후 해당 메세지는 확인 처리한다.
            
            // 위치조정(Find창을 Call한 Control의 하단에
			if (cont != null)
			{
				/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
				 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
				 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
				 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
				 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
				 */
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (SystemInformation.MonitorCount > 1)
				{
					//pos.X가 Second Monitor에 있으면 rc 변경
					if (pos.X > rc.Width)
					{
						Rectangle sRect = Screen.AllScreens[1].WorkingArea;
						rc = new Rectangle(rc.X, rc.Y, rc.Width + sRect.Width, sRect.Y + sRect.Height);
					}
				}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplyForm));
            this.txtMesg = new System.Windows.Forms.TextBox();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnSend = new IHIS.Framework.XButton();
            this.lbRecv = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMesg
            // 
            this.txtMesg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMesg.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMesg.Location = new System.Drawing.Point(0, 40);
            this.txtMesg.MaxLength = 1000;
            this.txtMesg.Multiline = true;
            this.txtMesg.Name = "txtMesg";
            this.txtMesg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMesg.Size = new System.Drawing.Size(244, 112);
            this.txtMesg.TabIndex = 1;
            this.txtMesg.Text = "내용";
            this.txtMesg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(176, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(64, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "닫 기";
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(2, 154);
            this.btnSend.Name = "btnSend";
            this.btnSend.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnSend.Size = new System.Drawing.Size(100, 24);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "답글 보내기";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbRecv
            // 
            this.lbRecv.BackColor = System.Drawing.Color.Cornsilk;
            this.lbRecv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbRecv.ForeColor = System.Drawing.Color.Purple;
            this.lbRecv.Location = new System.Drawing.Point(0, 0);
            this.lbRecv.Name = "lbRecv";
            this.lbRecv.Size = new System.Drawing.Size(244, 20);
            this.lbRecv.TabIndex = 4;
            this.lbRecv.Text = "송신자 : 이승필 (ICM0001)";
            this.lbRecv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTitle.Location = new System.Drawing.Point(0, 20);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(244, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "제목";
            this.txtTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            // 
            // ReplyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(244, 178);
            this.Controls.Add(this.txtMesg);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lbRecv);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplyForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 26);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "답 장 하 기";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			string title = (NetInfo.Language == LangMode.Ko ? "전송확인" : "転送確認");
			//제목,내용 입력여부 확인
			if (this.txtTitle.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "제목을 입력하십시오"
					:"タイトルが入力されていません。");
				XMessageBox.Show(msg, title);
				this.txtTitle.Focus();
				return;
			}
			if (this.txtMesg.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "내용을 입력하십시오"
					:"内容が入力されていません。");
				XMessageBox.Show(msg, title);
				this.txtMesg.Focus();
				return;
			}
			//Encoding 기준으로 2000byte초과하면 안됨
			int txtLen = Encoding.GetEncoding("Shift-JIS").GetByteCount(txtMesg.Text.Trim());
			if (txtLen >= 2000)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "메세지의 길이가 너무 길어 저장할 수 없습니다."
                    : "メッセージが長すぎるので保存できません。");
				XMessageBox.Show(msg, title);
				txtMesg.Focus();
				return;
			}
			//Input은 SENDER_ID + RECVER_ID + MSG_TITLE + MSG_CONTENTS
            if (this.SendReplyMessage(MainForm.CurrUserID, this.recverID, this.txtTitle.Text, this.txtMesg.Text) == true)
            {
                //전송후 닫기
                this.DialogResult = DialogResult.OK;
            }
		}

		private void txtTitle_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//Enter Key Tab
			if (e.KeyChar == (char)13)
				SendKeys.Send("{TAB}");
		}

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tBox = sender as TextBox;

            tBox.Focus();
            tBox.SelectAll();
        }

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "返 信";  //답신송신
				this.btnClose.Text = "閉じる";  //닫기
				this.btnSend.Text = "送  信";  //답신송신
				this.txtTitle.Text = "題目を入力してください。";
                this.txtMesg.Text = "内容を入力してください。(1000字まで)";
			}
		}

        private bool SendReplyMessage(string aSenderID, string aRecieverID, string aMsgTitle, string aMsgContents)
        {
            string senderName = "";
            string senderBuseo = "";
            string seq = "";
            object temp = null;
            string cmd = "";

            Service.BeginTransaction();
            try
            {
                // 송신자의 부서코드 송신자명 Get
                cmd = @"SELECT A.USER_NM
                             , A.DEPT_CODE
                          FROM ADM3200            A
                         WHERE A.HOSP_CODE        = '" + EnvironInfo.HospCode.ToString() + @"'
                           AND A.USER_ID          = '" + aSenderID + @"' 
                       ";

                DataTable dt = Service.ExecuteDataTable(cmd);

                if (dt == null || dt.Rows.Count <= 0) return false;

                senderName = (TypeCheck.IsNull(dt.Rows[0]["user_nm"]) == false ? dt.Rows[0]["user_nm"].ToString() : "");
                senderBuseo = (TypeCheck.IsNull(dt.Rows[0]["dept_code"]) == false ? dt.Rows[0]["dept_code"].ToString() : "");

                // 송신순번 Set
                cmd = @"SELECT MAX(A.SEND_SEQ) + 1
                          FROM ADM0700        A
                         WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode.ToString() + @"'
                           AND A.SEND_DT      = TRUNC(SYSDATE) 
                           AND A.SENDER_ID    = '" + aSenderID + @"'
                       ";

                temp = Service.ExecuteScalar(cmd);

                if (temp == null || temp.ToString() == "")
                {
                    seq = "1";
                }
                else
                {
                    seq = temp.ToString();
                }

                // 메시지 송신내역 생성, SEND_ALL_CNFM_YN = N, FILT_ATCH_YN = N    
                cmd = @"INSERT INTO ADM0700 (
                                              HOSP_CODE
                                            , SEND_DT             , SENDER_ID         , SEND_SEQ      , SEND_SPOT
                                            , MSG_TITLE           , MSG_CONTENTS      , VALID_YN      , SEND_ALL_CNFM_YN
                                            , RECV_ALL_CNFM_YN    , FILE_ATCH_YN      , CR_MEMB       , CR_TIME
                                            , CR_TRM
                                   ) VALUES (
                                              :f_hosp_code
                                            , TRUNC(SYSDATE)      , :f_sender_id      , :f_send_seq   , :f_send_spot
                                            , :f_msg_title        , :f_msg_contents   , 'Y'           ,'N'
                                            , 'N'                 , 'N'               , :f_user_id    , SYSDATE
                                            , :f_user_trm
                                   )
                       ";

                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_sender_id", aSenderID);
                bindVar.Add("f_send_seq", seq);
                bindVar.Add("f_send_spot", senderBuseo);
                bindVar.Add("f_msg_title", aMsgTitle);
                bindVar.Add("f_msg_contents", aMsgContents);
                bindVar.Add("f_user_id", MainForm.CurrUserID);
                bindVar.Add("f_user_trm", "");

                if (Service.ExecuteNonQuery(cmd, bindVar) == false)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show("送信に失敗しました。[" + Service.ErrFullMsg + "]", "送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // /* 메세지 수신내역 생성 , RECV_SPOT,RECVER_ID = 수신자 ID, 수신조직여부는 N.개인 */
                cmd = @"INSERT INTO ADM0710 (
                                              HOSP_CODE
                                            , SEND_DT           , SENDER_ID          , SEND_SEQ              , RECV_SPOT          , RECVER_ID         
                                            , RECV_SPOT_YN      , CNFM_YN            , RECV_ALL_CNFM_YN      , FILE_ATCH_YN       , VALID_YN              
                                            , CR_MEMB           , CR_TIME            , CR_TRM
                                   ) VALUES (
                                              :f_hosp_code
                                            , TRUNC(SYSDATE)    , :f_sender_id       , :f_send_seq        , :f_recver_id          , :f_recver_id
                                            , 'N'               , 'N'                , 'N'                , 'N'                   , 'Y'
                                            , :f_user_id        , SYSDATE            , :f_user_trm
                                   )
                       ";
                BindVarCollection bindVar2 = new BindVarCollection();
                bindVar2.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar2.Add("f_sender_id", aSenderID);
                bindVar2.Add("f_send_seq", seq);
                bindVar2.Add("f_recver_id", aRecieverID);
                bindVar2.Add("f_user_id", MainForm.CurrUserID);
                bindVar2.Add("f_user_trm", "");

                if (Service.ExecuteNonQuery(cmd, bindVar2) == false)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show("送信に失敗しました。[" + Service.ErrFullMsg + "]", "送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch ( Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("送信に失敗しました。[" + ex.Message + "]", "送信失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Service.RollbackTransaction();
            }

            Service.CommitTransaction();

            // <<2014.01.03>> LKH START : 답신 후 해당 메세지는 확인 처리한다.
            Service.BeginTransaction();
            
            try
            {
                cmd = @"UPDATE ADM0710 A
                           SET A.CNFM_YN        = 'Y'
                             , A.UP_MEMB        = :f_recver_id
                             , A.UP_TIME        = SYSDATE
                             --, A.UP_TRM         = NULL
                         WHERE A.HOSP_CODE      = :f_hosp_code
                           AND A.SEND_DT        = TO_DATE(:f_send_dt, 'YYYY/MM/DD')
                           AND A.SENDER_ID      = :f_sender_id
                           AND A.SEND_SEQ       = TO_NUMBER(:f_send_seq)
                           AND A.RECV_SPOT      = :f_recv_spot
                           AND A.RECVER_ID      = :f_recver_id
                       ";
                BindVarCollection bindVar3 = new BindVarCollection();
                bindVar3.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar3.Add("f_send_dt", msgSendDT);
                bindVar3.Add("f_sender_id", msgSenderID);
                bindVar3.Add("f_send_seq", msgSendSeq);
                bindVar3.Add("f_recv_spot", msgRecvSpot);
                bindVar3.Add("f_recver_id", msgRecverID);

                if (Service.ExecuteNonQuery(cmd, bindVar3) == false)
                {
                    Service.RollbackTransaction();
                }
            }
            catch(Exception ex)
            {
            }

            Service.CommitTransaction();
            // <<2014.01.03>> LKH END   : 답신 후 해당 메세지는 확인 처리한다.
            
            // 현재 로그인한 사람에게 메세지 송신 by udp
            IHIS.Framework.UdpHelper.SendMsgToID(aSenderID, aRecieverID, aMsgTitle, aMsgContents);
            return true;
        }

	}
}
