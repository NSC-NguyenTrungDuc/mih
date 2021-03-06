using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// DetailRecvListForm에 대한 요약 설명입니다.
	/// </summary>
	internal class DetailRecvListForm : System.Windows.Forms.Form
	{
		private string sendDt;
		private string senderID;
		private string sendSeq;
		[DataBindable]
		public string SendDt
		{
			get { return sendDt;}
		}
		[DataBindable]
		public string SenderID
		{
			get { return senderID;}
		}
		[DataBindable]
		public string SendSeq
		{
			get { return sendSeq;}
		}
		private MainForm parentForm = null;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XEditGrid grdList;
		private IHIS.Framework.XEditGridCell aEditGridCell1;
		private IHIS.Framework.XEditGridCell aEditGridCell2;
		private IHIS.Framework.XEditGridCell aEditGridCell3;
		private IHIS.Framework.XEditGridCell aEditGridCell4;
		private System.Windows.Forms.Label lbDesc;
		private IHIS.Framework.XEditGridCell aEditGridCell5;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DetailRecvListForm(MainForm parentForm , string sendDt, string senderID, string sendSeq)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//일본어 전환
			SetControlNameByLangMode();
			this.parentForm = parentForm;
			this.sendDt = sendDt;
			this.senderID = senderID;
			this.sendSeq = sendSeq;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailRecvListForm));
            this.btnCancel = new IHIS.Framework.XButton();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.aEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.lbDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(434, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "확 인";
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.aEditGridCell1,
            this.aEditGridCell2,
            this.aEditGridCell3,
            this.aEditGridCell4,
            this.aEditGridCell5});
            this.grdList.ColPerLine = 5;
            this.grdList.Cols = 5;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(25);
            this.grdList.Location = new System.Drawing.Point(5, 28);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.ReadOnly = true;
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(504, 290);
            this.grdList.TabIndex = 7;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // aEditGridCell1
            // 
            this.aEditGridCell1.CellName = "recv_spot_nm";
            this.aEditGridCell1.CellWidth = 94;
            this.aEditGridCell1.HeaderText = "받은곳";
            // 
            // aEditGridCell2
            // 
            this.aEditGridCell2.CellName = "recver_id";
            this.aEditGridCell2.CellWidth = 62;
            this.aEditGridCell2.Col = 1;
            this.aEditGridCell2.HeaderText = "수신자ID";
            // 
            // aEditGridCell3
            // 
            this.aEditGridCell3.CellName = "recver_nm";
            this.aEditGridCell3.CellWidth = 103;
            this.aEditGridCell3.Col = 2;
            this.aEditGridCell3.HeaderText = "수신자명";
            // 
            // aEditGridCell4
            // 
            this.aEditGridCell4.CellName = "cnfm_yn";
            this.aEditGridCell4.CellWidth = 35;
            this.aEditGridCell4.Col = 3;
            this.aEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.aEditGridCell4.HeaderText = "확인";
            // 
            // aEditGridCell5
            // 
            this.aEditGridCell5.CellName = "cnfm_time";
            this.aEditGridCell5.CellWidth = 179;
            this.aEditGridCell5.Col = 4;
            this.aEditGridCell5.HeaderText = "확인시각";
            this.aEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDesc
            // 
            this.lbDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDesc.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesc.ForeColor = System.Drawing.Color.BlueViolet;
            this.lbDesc.Location = new System.Drawing.Point(5, 5);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(504, 23);
            this.lbDesc.TabIndex = 8;
            this.lbDesc.Text = "총수신 : 4건 미확인 :3건";
            this.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetailRecvListForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 348);
            this.ControlBox = false;
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetailRecvListForm";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 30);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "송신상세내역";
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//상세수신내역 조회			
			SetDetailRecvList();
		}
		private void SetDetailRecvList()
		{
			//조회 성공시 건수 SET
            if (this.grdList.QueryLayout(false))
            {
                int noCnfmCnt = 0;
                foreach (DataRow dtRow in this.grdList.LayoutTable.Rows)
                {
                    if (dtRow["cnfm_yn"].ToString() == "N")
                    {
                        noCnfmCnt++;
                    }
                }

                this.lbDesc.Text = "総受信 :" + grdList.RowCount.ToString() + "件、未確認 :" + noCnfmCnt.ToString() + "件";
            }
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "送信詳細内訳";  //수신상세내역
				this.btnCancel.Text = "確 認";
                
				//Grid Header Text Set
				this.grdList[0,0].Value = "宛先";//받은곳
				this.grdList[0,1].Value = "受信先ID";//수신자ID
				this.grdList[0,2].Value = "受信先名";//수신자명
				this.grdList[0,3].Value = "確認";//확인
				this.grdList[0,4].Value = "確認時刻";//확인시각

			}
		}

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_send_dt", this.sendDt);
            this.grdList.SetBindVarValue("f_sender_id", this.senderID);
            this.grdList.SetBindVarValue("f_send_seq", this.sendSeq);
        }
	}
}
