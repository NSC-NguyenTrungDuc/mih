#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0301Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0301Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.SingleLayout layCommon = new SingleLayout();

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XFindBox fbxHangmog_code;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGrid grdHangmogInfo;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XDisplayBox dpxHangmog_name;
		private IHIS.Framework.XRadioButton rbtSet;
		private IHIS.Framework.XRadioButton rbtOftenUsed;
		private IHIS.Framework.XRadioButton rbtBulyong;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XButton btnConvertHangmog;
        private XToolTip xToolTip;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0301Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0301Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbtBulyong = new IHIS.Framework.XRadioButton();
            this.rbtOftenUsed = new IHIS.Framework.XRadioButton();
            this.rbtSet = new IHIS.Framework.XRadioButton();
            this.dpxHangmog_name = new IHIS.Framework.XDisplayBox();
            this.fbxHangmog_code = new IHIS.Framework.XFindBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnConvertHangmog = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdHangmogInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xToolTip = new IHIS.Framework.XToolTip();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.rbtBulyong);
            this.xPanel1.Controls.Add(this.rbtOftenUsed);
            this.xPanel1.Controls.Add(this.rbtSet);
            this.xPanel1.Controls.Add(this.dpxHangmog_name);
            this.xPanel1.Controls.Add(this.fbxHangmog_code);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(978, 62);
            this.xPanel1.TabIndex = 0;
            // 
            // rbtBulyong
            // 
            this.rbtBulyong.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtBulyong.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtBulyong.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtBulyong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtBulyong.ImageIndex = 0;
            this.rbtBulyong.ImageList = this.ImageList;
            this.rbtBulyong.Location = new System.Drawing.Point(224, 32);
            this.rbtBulyong.Name = "rbtBulyong";
            this.rbtBulyong.Size = new System.Drawing.Size(134, 26);
            this.rbtBulyong.TabIndex = 17;
            this.rbtBulyong.Tag = "2";
            this.rbtBulyong.Text = "      不用オーダ情報";
            this.rbtBulyong.UseVisualStyleBackColor = false;
            this.rbtBulyong.Click += new System.EventHandler(this.rbtSet_Click);
            // 
            // rbtOftenUsed
            // 
            this.rbtOftenUsed.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOftenUsed.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOftenUsed.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOftenUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOftenUsed.ImageIndex = 0;
            this.rbtOftenUsed.ImageList = this.ImageList;
            this.rbtOftenUsed.Location = new System.Drawing.Point(114, 32);
            this.rbtOftenUsed.Name = "rbtOftenUsed";
            this.rbtOftenUsed.Size = new System.Drawing.Size(110, 26);
            this.rbtOftenUsed.TabIndex = 16;
            this.rbtOftenUsed.Tag = "2";
            this.rbtOftenUsed.Text = "      常用オーダ";
            this.rbtOftenUsed.UseVisualStyleBackColor = false;
            this.rbtOftenUsed.Click += new System.EventHandler(this.rbtSet_Click);
            // 
            // rbtSet
            // 
            this.rbtSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtSet.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtSet.Checked = true;
            this.rbtSet.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtSet.ImageIndex = 1;
            this.rbtSet.ImageList = this.ImageList;
            this.rbtSet.Location = new System.Drawing.Point(4, 32);
            this.rbtSet.Name = "rbtSet";
            this.rbtSet.Size = new System.Drawing.Size(110, 26);
            this.rbtSet.TabIndex = 15;
            this.rbtSet.TabStop = true;
            this.rbtSet.Tag = "1";
            this.rbtSet.Text = "      セットオーダ";
            this.rbtSet.UseVisualStyleBackColor = false;
            this.rbtSet.Click += new System.EventHandler(this.rbtSet_Click);
            // 
            // dpxHangmog_name
            // 
            this.dpxHangmog_name.Location = new System.Drawing.Point(196, 6);
            this.dpxHangmog_name.Name = "dpxHangmog_name";
            this.dpxHangmog_name.Size = new System.Drawing.Size(358, 20);
            this.dpxHangmog_name.TabIndex = 14;
            // 
            // fbxHangmog_code
            // 
            this.fbxHangmog_code.AutoTabDataSelected = true;
            this.fbxHangmog_code.Location = new System.Drawing.Point(96, 6);
            this.fbxHangmog_code.Name = "fbxHangmog_code";
            this.fbxHangmog_code.Size = new System.Drawing.Size(100, 20);
            this.fbxHangmog_code.TabIndex = 0;
            this.fbxHangmog_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHangmog_code_DataValidating);
            this.fbxHangmog_code.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHangmog_code_FindClick);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(6, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 12;
            this.xLabel1.Text = "項目コード";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnConvertHangmog);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(978, 40);
            this.xPanel2.TabIndex = 12;
            // 
            // btnConvertHangmog
            // 
            this.btnConvertHangmog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertHangmog.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertHangmog.Image")));
            this.btnConvertHangmog.Location = new System.Drawing.Point(14, 6);
            this.btnConvertHangmog.Name = "btnConvertHangmog";
            this.btnConvertHangmog.Size = new System.Drawing.Size(140, 26);
            this.btnConvertHangmog.TabIndex = 1;
            this.btnConvertHangmog.Text = "オーダコード変更";
            this.btnConvertHangmog.Click += new System.EventHandler(this.btnConvertHangmog_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(732, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(244, 38);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdHangmogInfo
            // 
            this.grdHangmogInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdHangmogInfo.ColPerLine = 7;
            this.grdHangmogInfo.Cols = 8;
            this.grdHangmogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHangmogInfo.FixedCols = 1;
            this.grdHangmogInfo.FixedRows = 1;
            this.grdHangmogInfo.HeaderHeights.Add(29);
            this.grdHangmogInfo.Location = new System.Drawing.Point(0, 62);
            this.grdHangmogInfo.Name = "grdHangmogInfo";
            this.grdHangmogInfo.QuerySQL = resources.GetString("grdHangmogInfo.QuerySQL");
            this.grdHangmogInfo.ReadOnly = true;
            this.grdHangmogInfo.RowHeaderVisible = true;
            this.grdHangmogInfo.Rows = 2;
            this.grdHangmogInfo.Size = new System.Drawing.Size(978, 488);
            this.grdHangmogInfo.TabIndex = 13;
            this.grdHangmogInfo.ToolTipActive = true;
            this.grdHangmogInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdHangmogInfo_QueryEnd);
            this.grdHangmogInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmogInfo_QueryStarting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gubun";
            this.xEditGridCell9.CellWidth = 50;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.HeaderText = "区分";
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "セット";
            this.xComboItem1.ValueItem = "0";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "常用";
            this.xComboItem2.ValueItem = "1";
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "memb";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "memb";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "memb_name";
            this.xEditGridCell2.CellWidth = 109;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "使用者";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "yaksok_gubun";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "yaksok_gubun";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "yaksok_gubun_name";
            this.xEditGridCell4.CellWidth = 150;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderText = "セット区分";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "yaksok_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "yaksok_code";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "yaksok_name";
            this.xEditGridCell6.CellWidth = 172;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.HeaderText = "セットコード名";
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "hangmog_code";
            this.xEditGridCell7.CellWidth = 96;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.HeaderText = "オーダコード";
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "hangmog_name";
            this.xEditGridCell8.CellWidth = 275;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.HeaderText = "オーダコード名";
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bulyong_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell10.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell10.HeaderText = "不用日付";
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xToolTip
            // 
            this.xToolTip.AutoPopDelay = 8000;
            // 
            // OCS0301Q01
            // 
            this.Controls.Add(this.grdHangmogInfo);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0301Q01";
            this.Size = new System.Drawing.Size(978, 590);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogInfo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region [ Common Variables ]
        string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region [Screen Event]
        public override object Command(string command, CommonItemCollection commandParam)
		{	
			switch (command)
			{				
				case "OCS0103Q00": //항목검색
					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
						fbxHangmog_code.SetEditValue(((MultiLayout)commandParam["OCS0103"]).GetItemString(0, "hangmog_code"));
						this.AcceptData();
					}
					break;
			}		
			return base.Command (command, commandParam);
		}

		protected override void OnLoad(EventArgs e)
		{
			grdHangmogInfo.AutoSizeColumn(7, 0);
			this.grdHangmogInfo.SetBindVarValue("f_qry_gubun","0");
		}
		#endregion

		#region [Control Event]
		/// <summary>
		/// 항목코드 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fbxHangmog_code_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			
			CommonItemCollection openParams  = new CommonItemCollection();
			//값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
			openParams.Add("hangmog_code", fbxHangmog_code.Text.Trim());
			// Multi 선택여부 (default : MultiSelect )
			openParams.Add("multiSelection", false);
			//항목조회화면 Open
			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, openParams);

		}

		private void fbxHangmog_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string hangmog_name = GetCodeName("hangmog_code", e.DataValue);
			dpxHangmog_name.SetDataValue(hangmog_name);

			LoadHangmogInfo();
		}
	
		private void rbtSet_Click(object sender, System.EventArgs e)
		{
			if(rbtSet.Checked)
			{
				rbtSet.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSet.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtSet.ImageIndex = 1;
				
				rbtOftenUsed.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOftenUsed.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtOftenUsed.ImageIndex = 0;

				rbtBulyong.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtBulyong.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtBulyong.ImageIndex = 0;
				
				this.grdHangmogInfo.SetBindVarValue("f_qry_gubun","0");

				grdHangmogInfo.AutoSizeColumn(3, 154);
				grdHangmogInfo.AutoSizeColumn(4, 172);
				grdHangmogInfo.AutoSizeColumn(7, 0);

				if(TypeCheck.IsNull(this.fbxHangmog_code.Text.Trim()))
				{
					grdHangmogInfo.Reset();
				}
				else
				{
					if(this.grdHangmogInfo.QueryLayout(false))
					{
						for(int i = 0; i < this.grdHangmogInfo.RowCount; i++)
						{
							if(grdHangmogInfo.GetItemString(i, "memb") == "ADMIN")
								grdHangmogInfo.SetItemValue(i,"memb_name", "病院セット");
						}

						grdHangmogInfo.ResetUpdate();
					}
				}
			}
			else if(rbtOftenUsed.Checked)
			{
				rbtOftenUsed.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtOftenUsed.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtOftenUsed.ImageIndex = 1;
				
				rbtSet.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtSet.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtSet.ImageIndex = 0;

				rbtBulyong.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtBulyong.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtBulyong.ImageIndex = 0;

				grdHangmogInfo.AutoSizeColumn(3, 0);
				grdHangmogInfo.AutoSizeColumn(4, 0);
				grdHangmogInfo.AutoSizeColumn(7, 0);

				this.grdHangmogInfo.SetBindVarValue("f_qry_gubun","1");

				if(TypeCheck.IsNull(this.fbxHangmog_code.Text.Trim()))
				{
					grdHangmogInfo.Reset();
				}
				else
				{
					if(this.grdHangmogInfo.QueryLayout(false))
					{
						for(int i = 0; i < this.grdHangmogInfo.RowCount; i++)
						{
							if(grdHangmogInfo.GetItemString(i, "memb") == "ADMIN")
								grdHangmogInfo.SetItemValue(i,"memb_name", "病院セット");
						}
						grdHangmogInfo.ResetUpdate();
					}
				}
			}	
			else
			{
				rbtBulyong.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtBulyong.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtBulyong.ImageIndex = 1;
				
				rbtSet.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtSet.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtSet.ImageIndex = 0;

				rbtOftenUsed.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOftenUsed.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtOftenUsed.ImageIndex = 0;
				
				this.grdHangmogInfo.SetBindVarValue("f_qry_gubun","2");

				grdHangmogInfo.AutoSizeColumn(3, 154);
				grdHangmogInfo.AutoSizeColumn(4, 172);
				grdHangmogInfo.AutoSizeColumn(7, 80);

				if(this.grdHangmogInfo.QueryLayout(false))
				{
					for(int i = 0; i < this.grdHangmogInfo.RowCount; i++)
					{
						if(grdHangmogInfo.GetItemString(i, "memb") == "ADMIN")
							grdHangmogInfo.SetItemValue(i,"memb_name", "病院セット");
					}
					grdHangmogInfo.ResetUpdate();
				}
			}				
		}
		#endregion

		#region [Load Code Name]        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{
				case "hangmog_code":
					layCommon.Reset();
					layCommon.QuerySQL = " SELECT HANGMOG_NAME "
						               + "   FROM OCS0103 "
						               + "  WHERE HANGMOG_CODE = '" + code + "'"
                                       + "    AND HOSP_CODE    = '" + mHospCode + "'";

					layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("hangmog_name");

					if(layCommon.QueryLayout())
					{
						codeName = layCommon.GetItemValue("hangmog_name").ToString();
					}
					break;
				default:
					break;
			}
			return codeName;
		}
		#endregion

		#region [Function]
		private void LoadHangmogInfo()
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				if(this.grdHangmogInfo.QueryLayout(false))
				{
					for(int i = 0; i < this.grdHangmogInfo.RowCount; i++)
					{
						if(grdHangmogInfo.GetItemString(i, "memb") == "ADMIN")
							grdHangmogInfo.SetItemValue(i,"memb_name", "病院セット");
					}
					grdHangmogInfo.ResetUpdate();
				}
			}
			finally
			{					
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
		#endregion

		#region [ButtonList]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadHangmogInfo();
					break;
				case FunctionType.Print:
					grdHangmogInfo.PageSettings.Margins.Top  = 10;
					grdHangmogInfo.PageSettings.Margins.Left = 10;					
					grdHangmogInfo.PageSettings.Landscape = true;
					grdHangmogInfo.Print();
					break;
				default:
					break;
			}			
		}
		#endregion

		#region [항목코드변경]		
		private void btnConvertHangmog_Click(object sender, System.EventArgs e)
		{
			frmConvertHangmog frm = new frmConvertHangmog();
			if(!TypeCheck.IsNull(dpxHangmog_name.GetDataValue().Trim()))
				frm.HANGMOG_CODE = fbxHangmog_code.GetDataValue().Trim();
			
			frm.ShowDialog();
		}
		#endregion

		#region [Query Event]
		private void grdHangmogInfo_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			grdHangmogInfo.SetBindVarValue("f_hangmog_code", fbxHangmog_code.GetDataValue());
            grdHangmogInfo.SetBindVarValue("f_hosp_code",    mHospCode);
		}

		private void grdHangmogInfo_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			for(int i = 0; i < this.grdHangmogInfo.RowCount; i++)
			{
				if(grdHangmogInfo.GetItemString(i, "memb") == "ADMIN")
					grdHangmogInfo.SetItemValue(i,"memb_name", "病院セット");
			}

			grdHangmogInfo.ResetUpdate();
		}
		#endregion
	}
}

