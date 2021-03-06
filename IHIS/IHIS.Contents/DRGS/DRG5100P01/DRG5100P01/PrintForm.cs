using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.DRGS
{
	/// <summary>
	/// PrintForm에 대한 요약 설명입니다.
	/// </summary>
	public class PrintForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XDataWindow dw2;
		private System.Windows.Forms.TabPage tabPage3;
		private IHIS.Framework.XEditGrid grdINV0102;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XButtonList xButtonList2;
		private IHIS.Framework.XDictComboBox cbxCode;

		private DataTable mDt = null;
		public PrintForm(DataTable dt)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			mDt = dt.Copy();
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
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cbxCode = new IHIS.Framework.XDictComboBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dw1 = new IHIS.Framework.XDataWindow();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dw2 = new IHIS.Framework.XDataWindow();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.xButtonList2 = new IHIS.Framework.XButtonList();
            this.grdINV0102 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV0102)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.cbxCode);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(5, 339);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(438, 38);
            this.xPanel2.TabIndex = 1;
            // 
            // cbxCode
            // 
            this.cbxCode.Location = new System.Drawing.Point(10, 7);
            this.cbxCode.MaxDropDownItems = 30;
            this.cbxCode.Name = "cbxCode";
            this.cbxCode.Size = new System.Drawing.Size(211, 21);
            this.cbxCode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxCode.TabIndex = 1;
            this.cbxCode.UserSQL = "SELECT CODE , CODE_NAME FROM INV0102 WHERE CODE_TYPE = \'37\' AND CODE2 = \'A\' ORDER" +
                " BY CODE";
            this.cbxCode.Visible = false;
            this.cbxCode.DDLBSetting += new System.EventHandler(this.cbxCode_DDLBSetting);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "見本通り", -1, "OliveGreen"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, "Silver"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "Green")});
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(142, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(296, 38);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(10, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 392);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dw1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(520, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "元本";
            // 
            // dw1
            // 
            this.dw1.DataWindowObject = "d_label";
            this.dw1.LibraryList = "..\\DRGS\\drgs.drg5100p01.pbd";
            this.dw1.Location = new System.Drawing.Point(10, 9);
            this.dw1.Name = "dw1";
            this.dw1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw1.Size = new System.Drawing.Size(499, 346);
            this.dw1.TabIndex = 0;
            this.dw1.Text = "xDataWindow1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dw2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(520, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "修正";
            // 
            // dw2
            // 
            this.dw2.DataWindowObject = "d_label_new";
            this.dw2.LibraryList = "..\\DRGS\\drgs.drg5100p01.pbd";
            this.dw2.Location = new System.Drawing.Point(10, 9);
            this.dw2.Name = "dw2";
            this.dw2.Size = new System.Drawing.Size(499, 346);
            this.dw2.TabIndex = 0;
            this.dw2.Text = "xDataWindow1";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Honeydew;
            this.tabPage3.Controls.Add(this.xButtonList2);
            this.tabPage3.Controls.Add(this.grdINV0102);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(520, 366);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "定形文管理";
            // 
            // xButtonList2
            // 
            this.xButtonList2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList2.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, "Silver"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, "Green"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList2.IsVisiblePreview = false;
            this.xButtonList2.IsVisibleReset = false;
            this.xButtonList2.Location = new System.Drawing.Point(115, 327);
            this.xButtonList2.Name = "xButtonList2";
            this.xButtonList2.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList2.Size = new System.Drawing.Size(390, 39);
            this.xButtonList2.TabIndex = 6;
            this.xButtonList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdINV0102
            // 
            this.grdINV0102.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdINV0102.ColPerLine = 2;
            this.grdINV0102.Cols = 3;
            this.grdINV0102.FixedCols = 1;
            this.grdINV0102.FixedRows = 1;
            this.grdINV0102.HeaderHeights.Add(21);
            this.grdINV0102.Location = new System.Drawing.Point(10, 0);
            this.grdINV0102.Name = "grdINV0102";
            this.grdINV0102.QuerySQL = "SELECT CODE_TYPE\r\n     , CODE\r\n     , CODE_NAME\r\n     , CODE2\r\n     , CODE3\r\n    " +
                " , SORT_KEY\r\n  FROM INV0102\r\n WHERE CODE_TYPE        = :f_code_type\r\n   AND CODE" +
                "2            = \'A\'\r\n ORDER BY CODE";
            this.grdINV0102.RowHeaderVisible = true;
            this.grdINV0102.Rows = 2;
            this.grdINV0102.Size = new System.Drawing.Size(499, 327);
            this.grdINV0102.TabIndex = 5;
            this.grdINV0102.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV0102_QueryStarting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "CODE_TYPE";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "CODE";
            this.xEditGridCell10.CellWidth = 36;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.HeaderText = "コード";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 100;
            this.xEditGridCell11.CellName = "CODE_NAME";
            this.xEditGridCell11.CellWidth = 341;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.HeaderText = "コード名";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "CODE2";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // PrintForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(448, 382);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.xPanel2);
            this.Name = "PrintForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ラベル出力";
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV0102)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			dw1.DataWindowObject = "d_label";
			dw1.FillData(mDt);
		}

		[Browsable(false), DataBindable]
		public string CodeType
		{
			get {return "37";}
			
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			string bogyong = "";

			switch(e.Func)
			{
				case FunctionType.Query:
					if (!grdINV0102.QueryLayout(false))
					{
						XMessageBox.Show(Service.ErrFullMsg, "Error");
					}
					break;
				case FunctionType.Update:
					if(tabControl1.SelectedTab.Name == "tabPage2")
					{
						dw2.AcceptText();
						bogyong = dw2.GetItemString(1,"jaeryo_name");
						bogyong = bogyong + "\n" + cbxCode.Text  ;

						dw2.SetItemString(1,"jaeryo_name", bogyong);
						dw2.AcceptText();
					}
					else if(tabControl1.SelectedTab.Name == "tabPage3")
					{
                        if (!grdINV0102.QueryLayout(false))
						{
							XMessageBox.Show(Service.ErrFullMsg, "Error");
						}
					}
					e.IsBaseCall = false;
					break;
				case FunctionType.Insert:
					grdINV0102.InsertRow();
					e.IsBaseCall = false;
					break;
				case FunctionType.Delete:
					grdINV0102.DeleteRow();
					e.IsBaseCall = false;
					break;
				case FunctionType.Print:
					PrintHelper.SetDefaultPrinter("SATO");
					e.IsBaseCall = false;
					try
					{
						if (tabControl1.SelectedTab.Name == "tabPage1")
						{
							dw1.Print();
						}
						else
						{
							dw2.AcceptText();
							dw2.Print();
						}
					}
					catch
					{}
					break;
				case FunctionType.Close:
					Close();
					break;
			}
		}


		private string GetItemString(int row, string col)
		{
			string rtn =" ";
			if (!dw1.IsItemNull(row, col))
				rtn = dw1.GetItemString(row, col);

			return rtn;
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbxCode.Visible = false;
			if(tabControl1.SelectedTab.Name == "tabPage2")
			{
				cbxCode.Visible = true;
                cbxCode_DDLBSetting(sender, new EventArgs());

				cbxCode.AcceptData();
				cbxCode.RefreshComboItems();

				dw1.AcceptText();
				int row = dw1.LastRowOnPage;;
				string bogyong = string.Empty;

				dw2.Reset();
				dw2.InsertRow(0);
				dw2.SetItemString(1,"order_date"	,GetItemString(row, "order_date"));
				dw2.SetItemString(1,"serial_v"		,GetItemString(row, "serial_v"));
				dw2.SetItemString(1,"bunryu1"		,GetItemString(row, "bunryu1"));
				dw2.SetItemString(1,"gwa_name"		,GetItemString(row, "gwa_name"));
				dw2.SetItemString(1,"bunho"			,GetItemString(row, "bunho"));
				dw2.SetItemString(1,"suname"		,GetItemString(row, "suname"));
				dw2.SetItemString(1,"bogyong_name"	,GetItemString(row, "bogyong_name"));
				dw2.SetItemString(1,"nalsu"			,GetItemString(row, "nalsu"));


				if(GetItemString(row, "bunryu1") == "1")
				{
					for(int i=1; i< dw1.RowCount+1; i++)
					{
						if( GetItemString(i, "serial_v") == GetItemString(row, "serial_v")) 
						{
							bogyong = bogyong + GetItemString(i, "kyukyeok").PadRight(14) + GetItemString(i, "kind") + " 種 1回" +
								GetItemString(i, "drg_grp")  +" " + GetItemString(i, "kyukyeok1") + "ずつ";
							bogyong = bogyong + "\r\n" ;
						}
					}
				}
				else
				{
					for(int i=1; i< dw1.RowCount+1; i++)
					{
						if( GetItemString(i, "serial_v") == GetItemString(row, "serial_v")) 
						{
							bogyong = bogyong + TypeCheck.NVL(GetItemString(i, "jaeryo_name")," ").ToString();
							bogyong = bogyong + "\r\n" ;
						}
					}
				}

				dw2.SetItemString(1,"jaeryo_name"	,bogyong);
				dw2.SetItemString(1,"gyunbon_yn"	,GetItemString(row, "gyunbon_yn"));

				if(!dw1.IsItemNull(row,"caution_name"))
					dw2.SetItemString(1,"caution_name"	,TypeCheck.NVL(GetItemString(row, "caution_name")," ").ToString());
				dw2.AcceptText();
			}
			else if(tabControl1.SelectedTab.Name == "tabPage3")
			{
				if (!grdINV0102.QueryLayout(false))
				{
					XMessageBox.Show(Service.ErrFullMsg, "Error");
				}
			}
		}

		private void grdINV0102_PreGetValue(object sender, IHIS.Framework.MultiRecordEventArgs e)
		{
			grdINV0102.SetItemValue(e.RowNumber, "CODE_TYPE", CodeType);
		}

        private void grdINV0102_QueryStarting(object sender, CancelEventArgs e)
        {
            grdINV0102.SetBindVarValue("f_code_type", CodeType);
        }

        private void cbxCode_DDLBSetting(object sender, EventArgs e)
        {

        }
	}
}
