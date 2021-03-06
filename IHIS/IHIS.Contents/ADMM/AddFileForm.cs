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
	/// AddFileForm에 대한 요약 설명입니다.
	/// </summary>
	internal class AddFileForm : System.Windows.Forms.Form
	{
		const long MAX_FILE_SIZE = 10000000; //10M

		private ArrayList addedFileItems = null; //추가된 파일정보(AddedFileItem)을 관리하는 ArrayList
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XEditGrid grdList;
		private IHIS.Framework.XEditGridCell aEditGridCell1;
		private IHIS.Framework.XEditGridCell aEditGridCell2;
		private IHIS.Framework.XEditGridCell aEditGridCell3;
		private IHIS.Framework.XButton btnAdd;
		private IHIS.Framework.XButton btnDelete;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddFileForm(ArrayList addedFileItems)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//일본어 SET
			SetControlNameByLangMode();

			this.addedFileItems = addedFileItems;
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
			this.btnCancel = new IHIS.Framework.XButton();
			this.grdList = new IHIS.Framework.XEditGrid();
			this.aEditGridCell1 = new IHIS.Framework.XEditGridCell();
			this.aEditGridCell2 = new IHIS.Framework.XEditGridCell();
			this.aEditGridCell3 = new IHIS.Framework.XEditGridCell();
			this.btnAdd = new IHIS.Framework.XButton();
			this.btnDelete = new IHIS.Framework.XButton();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(362, 138);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(68, 26);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(436, 138);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(68, 26);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "취 소";
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
			this.grdList.RowHeaderVisible = true;
			this.grdList.Rows = 2;
			this.grdList.RowStateCheckOnPaint = false;
			this.grdList.Size = new System.Drawing.Size(502, 134);
			this.grdList.TabIndex = 3;
			this.grdList.ToolTipActive = true;
			this.grdList.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdList_GridButtonClick);
			// 
			// aEditGridCell1
			// 
			this.aEditGridCell1.CellName = "fileName";
			this.aEditGridCell1.CellWidth = 413;
			this.aEditGridCell1.Col = -1;
			this.aEditGridCell1.HeaderFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.aEditGridCell1.HeaderGradientEnd = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((System.Byte)(148)), ((System.Byte)(203)), ((System.Byte)(189))));
			this.aEditGridCell1.HeaderGradientStart = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(253)), ((System.Byte)(252))));
			this.aEditGridCell1.HeaderText = "파 일 명";
			this.aEditGridCell1.IsReadOnly = true;
			this.aEditGridCell1.IsVisible = false;
			this.aEditGridCell1.Row = -1;
			// 
			// aEditGridCell2
			// 
			this.aEditGridCell2.CellName = "fullName";
			this.aEditGridCell2.CellWidth = 393;
			this.aEditGridCell2.Col = 1;
			this.aEditGridCell2.HeaderText = "파 일 명";
			this.aEditGridCell2.IsReadOnly = true;
			// 
			// aEditGridCell3
			// 
			this.aEditGridCell3.ButtonText = "찾기";
			this.aEditGridCell3.CellName = "button";
			this.aEditGridCell3.CellWidth = 59;
			this.aEditGridCell3.Col = 2;
			this.aEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
			this.aEditGridCell3.HeaderText = "찾기..";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(6, 138);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Scheme = IHIS.Framework.XButtonSchemes.Green;
			this.btnAdd.Size = new System.Drawing.Size(68, 26);
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "추 가";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(80, 138);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
			this.btnDelete.Size = new System.Drawing.Size(68, 26);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "삭 제";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(150, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "[첨부파일 파일당 10M로 크기제한]";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AddFileForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(249)), ((System.Byte)(251)));
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(506, 166);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.grdList);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.DockPadding.Bottom = 30;
			this.DockPadding.Left = 2;
			this.DockPadding.Right = 2;
			this.DockPadding.Top = 2;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddFileForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "파일 첨부";
			((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//추가파일 List를 Grid에 SET
			if (this.addedFileItems.Count < 1)
				this.grdList.InsertRow();  //1건 Insert
			else //grdList에 Add
			{
				int rowNum = 0;
				foreach (AddedFileItem item in this.addedFileItems)
				{
					rowNum = grdList.InsertRow(-1);
					grdList.SetItemValue(rowNum, "fileName", item.FileName);
					grdList.SetItemValue(rowNum, "fullName", item.FullName);
				}
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//기존 리스트 Clear
			this.addedFileItems.Clear();
			string fileName = "", fullName = "", extension = "";
			//파일명이 지정된 행의 FileName, FullName Set
			//유니크한 파일명은 GUID를 얻어서 -제거한 값으로 GUID.확장자로 관리함
			foreach (DataRow dtRow in this.grdList.LayoutTable.Rows)
			{
				fileName = dtRow["fileName"].ToString().Trim();
				fullName = dtRow["fullName"].ToString().Trim();
				if (fileName != "")
				{
					FileInfo fInfo = new FileInfo(fullName);
					extension = fInfo.Extension;
					AddedFileItem item = new AddedFileItem(fileName, fullName);
					//Unique Name은 GUID로 관리함.
					item.UniqueName = Guid.NewGuid().ToString().Replace("-","") + extension;
					this.addedFileItems.Add(item);
				}
			}
			this.DialogResult = DialogResult.OK;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//총 4건만 추가 가능
			if (this.grdList.RowCount >= 4)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "총 4건만 파일첨부 가능합니다."
					: "４件までファイル添付できます。");
				XMessageBox.Show(msg);
				return;
			}
			this.grdList.InsertRow(-1);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (grdList.CurrentRowNumber < 0)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "삭제할 행을 선택하십시오"
					: "削除する行を選んでください。");
				XMessageBox.Show(msg);
				return;
			}
			this.grdList.DeleteRow();
		}

		private void grdList_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			//버튼 Click시 OpenFileDialog를 띄워 파일 찾기
			if (e.ColName == "button")
			{
				try
				{
					string fileName = "",fullName = "", initPath = "";
					//파일명이 지정되어 있으면 OpenFileDialog의 초기 Path를 설정함
					if (e.DataRow["fileName"].ToString().Trim() != "")
					{
						fullName = e.DataRow["fullName"].ToString();
						initPath = fullName.Substring(0, fullName.LastIndexOf("\\"));
					}
					OpenFileDialog dlg = new OpenFileDialog();
					if (initPath != "")
						dlg.InitialDirectory = initPath;
				
					if (dlg.ShowDialog(this) == DialogResult.OK)
					{
						//파일 Size는 5M이상이면 안됨
						FileInfo fInfo = new FileInfo(dlg.FileName);
						if (fInfo.Length >= MAX_FILE_SIZE)
						{
							string msg = (NetInfo.Language == LangMode.Ko ? "파일의 크기[" + fInfo.Length.ToString() + "]는 10M이상이면 전송제한합니다."
								: "ファイルのサイズ[" + fInfo.Length.ToString() + "]が１０ＭＢ以上の場合は転送できません。");
							XMessageBox.Show(msg);
							return;
						}
						fullName = dlg.FileName;
						fileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
						grdList.SetItemValue(e.RowNumber, "fileName", fileName);
						grdList.SetItemValue(e.RowNumber, "fullName", fullName);
					}
				}
				catch(Exception xe)
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "파일 찾기 에러[" + xe.Message + "]"
							: "ファイル参照エラー[" + xe.Message + "]");
					XMessageBox.Show(msg);
				}
			}
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "ファイル添付";  //파일첨부
				this.btnAdd.Text = "追 加";  //추가
				this.btnDelete.Text = "削 除"; //삭제
				this.btnOK.Text = "確 認";
				this.btnCancel.Text = "取 消";
				this.label1.Text = "各ファイルのサイズは１０ＭＢまで";
				this.grdList[0,1].Value = "ファイル名";
				this.grdList[0,2].Value = "";
				this.aEditGridCell3.ButtonText = "参照";  //찾기
			}
		}
	}
}
