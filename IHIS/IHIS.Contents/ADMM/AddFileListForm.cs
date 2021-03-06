using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// AddFileListForm에 대한 요약 설명입니다.
	/// </summary>
	internal class AddFileListForm : System.Windows.Forms.Form
	{
		private MainForm parentForm = null;
		private string sendDt = ""; //전송일자
		private string senderID = ""; //전송자사번
		private string sendSeq = "";
       

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
		private IHIS.Framework.XEditGrid grdList;
		private IHIS.Framework.XEditGridCell aEditGridCell1;
		private IHIS.Framework.XEditGridCell aEditGridCell2;
		private IHIS.Framework.XEditGridCell aEditGridCell3;
        private IHIS.Framework.XButton btnClose;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddFileListForm(MainForm parentForm, string sendDt, string senderID, string sendSeq)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//일본어 변경
			SetControlNameByLangMode();

			this.parentForm = parentForm;
			//첨부파일 찾는 Unique Key (AMSGFILE table에 찾는 Key값)
			this.sendDt = sendDt;  //전송일자
			this.senderID = senderID;  //전송자ID
			this.sendSeq = sendSeq;  //전송순번
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFileListForm));
            this.btnClose = new IHIS.Framework.XButton();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.aEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.aEditGridCell3 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(242, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(68, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫 기";
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.aEditGridCell1,
            this.aEditGridCell2,
            this.aEditGridCell3});
            this.grdList.ColPerLine = 2;
            this.grdList.Cols = 3;
            this.grdList.DefaultHeight = 26;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(25);
            this.grdList.Location = new System.Drawing.Point(2, 2);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.RowStateCheckOnPaint = false;
            this.grdList.Size = new System.Drawing.Size(308, 134);
            this.grdList.TabIndex = 3;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            this.grdList.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdList_GridButtonClick);
            // 
            // aEditGridCell1
            // 
            this.aEditGridCell1.CellName = "file_nm";
            this.aEditGridCell1.CellWidth = 196;
            this.aEditGridCell1.Col = 1;
            this.aEditGridCell1.HeaderText = "파 일 명";
            this.aEditGridCell1.IsReadOnly = true;
            // 
            // aEditGridCell2
            // 
            this.aEditGridCell2.CellName = "uni_file_nm";
            this.aEditGridCell2.CellWidth = 272;
            this.aEditGridCell2.Col = -1;
            this.aEditGridCell2.HeaderFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.aEditGridCell2.HeaderGradientEnd = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(203)))), ((int)(((byte)(189))))));
            this.aEditGridCell2.HeaderGradientStart = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(252))))));
            this.aEditGridCell2.HeaderText = "유니크명";
            this.aEditGridCell2.IsReadOnly = true;
            this.aEditGridCell2.IsVisible = false;
            this.aEditGridCell2.Row = -1;
            // 
            // aEditGridCell3
            // 
            this.aEditGridCell3.ButtonText = "받기";
            this.aEditGridCell3.CellName = "button";
            this.aEditGridCell3.CellWidth = 63;
            this.aEditGridCell3.Col = 2;
            this.aEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.aEditGridCell3.HeaderText = "다운로드";
            // 
            // AddFileListForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(312, 166);
            this.ControlBox = false;
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddFileListForm";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 30);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "첨부된 파일 리스트";
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//첨부파일 리스트 조회
            if (!this.grdList.QueryLayout(false)) //첨부파일 조회 실패시 MSG
            {
                string msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 리스트 조회 에러[" + Service.ErrFullMsg + "]"
                    : "添付ファイルリストの照会エラー[" + Service.ErrFullMsg + "]");
                XMessageBox.Show(msg);
            }
		}
		private void grdList_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			//버튼 Click시 SaveFileDialog를 띄워 파일명 폴더 선택하게 하여 다운로드 처리함
			if (e.ColName == "button")
			{
				//현재 Dir
				string origCurDir = Directory.GetCurrentDirectory();
				string msg = "";
				string caption = (NetInfo.Language == LangMode.Ko ? "파일다운로드" : "ファイルダウンロード");
				try
				{
					string fileName = "", uniqueName = "", filePath = "";
					fileName = e.DataRow["file_nm"].ToString();
					uniqueName = e.DataRow["uni_file_nm"].ToString();
					SaveFileDialog dlg = new SaveFileDialog();
					dlg.FileName = fileName;
					if (dlg.ShowDialog(this) == DialogResult.OK)
					{
						//첨부파일 서버정보가 없으면 Return
						if (parentForm.FileServerIP == "")
						{
							msg = (NetInfo.Language == LangMode.Ko ? "첨부파일을 다운로드할 서버의 정보가 없습니다.\n\n" +
									"전산실에 문의하시기 바랍니다."
								: "添付ファイルのダウンロード対象のサーバーの情報がありません。\n\n" +
								  "電算室にお問い合わせください。");

							XMessageBox.Show(msg, caption);
							return;
						}
						fileName = dlg.FileName;
						filePath = fileName.Substring(0, fileName.LastIndexOf("\\"));
						//파일명은 Path 제외
						fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
						//현재 Dir을 FilePath로 설정
						Directory.SetCurrentDirectory(filePath);
						//MainForm에서 관리하는 첨부파일 서버 정보로 FTP 생성
						XFTPWorker ftpWorker = new XFTPWorker(parentForm.FileServerUserID, parentForm.FileServerPwsd, parentForm.FileServerIP);
						if (!ftpWorker.Connected)
						{
							msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 관리서버에 접속하지 못했습니다.\n\n" +
								"첨부 파일을 다운로드할 수 없습니다."
								: "添付ファイルの管理サーバーに接続できません。\n\n" + 
								"添付ファイルのダウンロードが出来ませんでした。");
							XMessageBox.Show(msg, caption);
							return;
						}
						//일자별로 File을 관리함으로 전송일자(yyyyMMdd) 서버 Dir로 이동
						if (!ftpWorker.ChangeDir(DateTime.Parse(this.sendDt).ToString("yyyyMMdd")))
						{
							msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 관리서버의 디렉토리를 변경하지 못했습니다.\n\n" +
								"첨부 파일을 다운로드할 수 없습니다."
								: "添付ファイル管理サーバーのディレクトリーを変更できませんでした。\n\n" + 
								"添付ファイルのダウンロードが出来ませんでした。");
							XMessageBox.Show(msg, caption);
							return;
						}

						//Unique이름으로 저장된 서버파일을 지정한 Client FileName으로 다운로드
						ftpWorker.SendLargeFileToClient(uniqueName, fileName);
					}
				}
				catch(Exception xe)
				{
					msg = (NetInfo.Language == LangMode.Ko ? "파일 다운로드 에러[" + xe.Message + "]"
						: "ファイルダウンロードエラー[" + xe.Message + "]");
					XMessageBox.Show(msg ,caption);
				}
				finally
				{
					//현재 Dir 복구
					Directory.SetCurrentDirectory(origCurDir);
				}
			}
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "添付ファイルリスト";  //첨부파일리스트
				this.btnClose.Text = "閉じる";
				this.grdList[0,1].Value = "ファイル名";
				this.grdList[0,2].Value = "ダウンロード";  //다운로드
				this.aEditGridCell3.ButtonText = "受信";   //받기
			}
		}

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_send_dt", sendDt);
            this.grdList.SetBindVarValue("f_sender_id", senderID);
            this.grdList.SetBindVarValue("f_send_seq", sendSeq);

        }
	}
}
