using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;
using System.Data;

namespace IHIS.SCHS
{
	/// <summary>
	/// FINDReserList에 대한 요약 설명입니다.
	/// </summary>
	public class FINDReserList : IHIS.Framework.XForm
	{
		private string ar_bunho, ar_jundal_part, ar_order_date, ar_reser_date;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdReserList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XDatePicker dtpReserDate;
		private IHIS.Framework.XComboBox cmbHH;
		private IHIS.Framework.XComboBox cmbMM;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XComboItem xComboItem6;
		private IHIS.Framework.XComboItem xComboItem7;
		private IHIS.Framework.XComboItem xComboItem8;
		private IHIS.Framework.XComboItem xComboItem9;
		private IHIS.Framework.XComboItem xComboItem10;
		private IHIS.Framework.XComboItem xComboItem11;
		private IHIS.Framework.XComboItem xComboItem12;
		private IHIS.Framework.XComboItem xComboItem13;
		private IHIS.Framework.XComboItem xComboItem14;
		private IHIS.Framework.XComboItem xComboItem15;
		private IHIS.Framework.XComboItem xComboItem16;
		private IHIS.Framework.XComboItem xComboItem17;
		private IHIS.Framework.XComboItem xComboItem18;
		private IHIS.Framework.XComboItem xComboItem19;
		private IHIS.Framework.XComboItem xComboItem20;
		private IHIS.Framework.XComboItem xComboItem21;
		private IHIS.Framework.XComboItem xComboItem22;
		private IHIS.Framework.XComboItem xComboItem23;
		private IHIS.Framework.XComboItem xComboItem25;
		private IHIS.Framework.XComboItem xComboItem26;
		private IHIS.Framework.XComboItem xComboItem27;
		private IHIS.Framework.XComboItem xComboItem28;
		private IHIS.Framework.XComboItem xComboItem29;
		private IHIS.Framework.XComboItem xComboItem30;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XComboItem xComboItem31;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XComboItem xComboItem24;
		private IHIS.Framework.XComboItem xComboItem32;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FINDReserList(string bunho, string reser_date, string order_date, string jundal_part)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

			ar_bunho = bunho;
			ar_reser_date = reser_date;
			ar_order_date = order_date;
			ar_jundal_part = jundal_part;
		}

		#region
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.grdReserList.SavePerformer = new XSavePerformer(this);

			dtpReserDate.SetDataValue(DateTime.Now);
			cmbHH.SetDataValue("00");
			cmbMM.SetDataValue("00");

            this.grdReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdReserList.SetBindVarValue("f_bunho", ar_bunho);
            this.grdReserList.SetBindVarValue("f_jundal_part", ar_jundal_part);
            this.grdReserList.SetBindVarValue("f_order_date", ar_order_date);
            this.grdReserList.SetBindVarValue("f_reser_date", ar_reser_date);

            this.grdReserList.QueryLayout(false);
		}

		#endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FINDReserList));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdReserList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xComboItem24 = new IHIS.Framework.XComboItem();
            this.xComboItem32 = new IHIS.Framework.XComboItem();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cmbMM = new IHIS.Framework.XComboBox();
            this.xComboItem25 = new IHIS.Framework.XComboItem();
            this.xComboItem26 = new IHIS.Framework.XComboItem();
            this.xComboItem27 = new IHIS.Framework.XComboItem();
            this.xComboItem28 = new IHIS.Framework.XComboItem();
            this.xComboItem29 = new IHIS.Framework.XComboItem();
            this.xComboItem30 = new IHIS.Framework.XComboItem();
            this.cmbHH = new IHIS.Framework.XComboBox();
            this.xComboItem31 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xComboItem19 = new IHIS.Framework.XComboItem();
            this.xComboItem20 = new IHIS.Framework.XComboItem();
            this.xComboItem21 = new IHIS.Framework.XComboItem();
            this.xComboItem22 = new IHIS.Framework.XComboItem();
            this.xComboItem23 = new IHIS.Framework.XComboItem();
            this.dtpReserDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdReserList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(970, 490);
            this.xPanel1.TabIndex = 1;
            // 
            // grdReserList
            // 
            this.grdReserList.ApplyPaintEventToAllColumn = true;
            this.grdReserList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell21,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell22,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell23});
            this.grdReserList.ColPerLine = 9;
            this.grdReserList.Cols = 10;
            this.grdReserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReserList.FixedCols = 1;
            this.grdReserList.FixedRows = 1;
            this.grdReserList.HeaderHeights.Add(29);
            this.grdReserList.Location = new System.Drawing.Point(2, 2);
            this.grdReserList.Name = "grdReserList";
            this.grdReserList.QuerySQL = resources.GetString("grdReserList.QuerySQL");
            this.grdReserList.RowHeaderVisible = true;
            this.grdReserList.Rows = 2;
            this.grdReserList.Size = new System.Drawing.Size(964, 484);
            this.grdReserList.TabIndex = 0;
            this.grdReserList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdReserList_ItemValueChanging);
            this.grdReserList.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdReserList_PreSaveLayout);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pksch0201";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pksch0201";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "in_out_gubun";
            this.xEditGridCell2.CellWidth = 20;
            this.xEditGridCell2.Col = 7;
            this.xEditGridCell2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem24,
            this.xComboItem32});
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell2.HeaderText = "外\r\n入";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xComboItem24
            // 
            this.xComboItem24.DisplayItem = "外";
            this.xComboItem24.ValueItem = "O";
            // 
            // xComboItem32
            // 
            this.xComboItem32.DisplayItem = "入";
            this.xComboItem32.ValueItem = "I";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkocs";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "fkocs";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "bunho";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "患者番号";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "gwa";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "gwa";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gumsaja";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "gumsaja";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "hangmog_code";
            this.xEditGridCell6.CellWidth = 71;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.HeaderText = "検査コード";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jundal_table";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "jundal_table";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jundal_part";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "jundal_part";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.HeaderText = "予約日付";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "reser_time";
            this.xEditGridCell10.CellWidth = 37;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.HeaderText = "時間";
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "input_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "入力日付";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "input_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "input_id";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "suname";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "患者氏名";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.SuppressRepeating = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "reser_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "reser_yn";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "cancel_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "cancel_yn";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "acting_date";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "hope_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.CellWidth = 85;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "希望日";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "comments";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "comments";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "hangmog_name";
            this.xEditGridCell19.CellWidth = 245;
            this.xEditGridCell19.Col = 5;
            this.xEditGridCell19.HeaderText = "検査名";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jundal_part_name";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "jundal_part_name";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "order_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = 6;
            this.xEditGridCell22.HeaderText = "オーダ日付";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "doctor_name";
            this.xEditGridCell24.CellWidth = 95;
            this.xEditGridCell24.Col = 8;
            this.xEditGridCell24.HeaderText = "診療医";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "seq";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_remark";
            this.xEditGridCell26.CellWidth = 280;
            this.xEditGridCell26.Col = 9;
            this.xEditGridCell26.HeaderText = "コメント";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "chk";
            this.xEditGridCell23.CellWidth = 20;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.HeaderText = "選\r\n択";
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.cmbMM);
            this.xPanel2.Controls.Add(this.cmbHH);
            this.xPanel2.Controls.Add(this.dtpReserDate);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 495);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.xPanel2.Size = new System.Drawing.Size(970, 36);
            this.xPanel2.TabIndex = 2;
            // 
            // xLabel3
            // 
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.Location = new System.Drawing.Point(290, 7);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(20, 21);
            this.xLabel3.TabIndex = 7;
            this.xLabel3.Text = "分";
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.Location = new System.Drawing.Point(224, 7);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(20, 21);
            this.xLabel2.TabIndex = 6;
            this.xLabel2.Text = "時";
            // 
            // cmbMM
            // 
            this.cmbMM.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem25,
            this.xComboItem26,
            this.xComboItem27,
            this.xComboItem28,
            this.xComboItem29,
            this.xComboItem30});
            this.cmbMM.Location = new System.Drawing.Point(246, 7);
            this.cmbMM.Name = "cmbMM";
            this.cmbMM.Size = new System.Drawing.Size(42, 21);
            this.cmbMM.TabIndex = 5;
            // 
            // xComboItem25
            // 
            this.xComboItem25.DisplayItem = "00";
            this.xComboItem25.ValueItem = "00";
            // 
            // xComboItem26
            // 
            this.xComboItem26.DisplayItem = "10";
            this.xComboItem26.ValueItem = "10";
            // 
            // xComboItem27
            // 
            this.xComboItem27.DisplayItem = "20";
            this.xComboItem27.ValueItem = "20";
            // 
            // xComboItem28
            // 
            this.xComboItem28.DisplayItem = "30";
            this.xComboItem28.ValueItem = "30";
            // 
            // xComboItem29
            // 
            this.xComboItem29.DisplayItem = "40";
            this.xComboItem29.ValueItem = "40";
            // 
            // xComboItem30
            // 
            this.xComboItem30.DisplayItem = "50";
            this.xComboItem30.ValueItem = "50";
            // 
            // cmbHH
            // 
            this.cmbHH.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem31,
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8,
            this.xComboItem9,
            this.xComboItem10,
            this.xComboItem11,
            this.xComboItem12,
            this.xComboItem13,
            this.xComboItem14,
            this.xComboItem15,
            this.xComboItem16,
            this.xComboItem17,
            this.xComboItem18,
            this.xComboItem19,
            this.xComboItem20,
            this.xComboItem21,
            this.xComboItem22,
            this.xComboItem23});
            this.cmbHH.Location = new System.Drawing.Point(180, 7);
            this.cmbHH.Name = "cmbHH";
            this.cmbHH.Size = new System.Drawing.Size(42, 21);
            this.cmbHH.TabIndex = 4;
            // 
            // xComboItem31
            // 
            this.xComboItem31.DisplayItem = "00";
            this.xComboItem31.ValueItem = "00";
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "01";
            this.xComboItem1.ValueItem = "01";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "02";
            this.xComboItem2.ValueItem = "02";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "03";
            this.xComboItem3.ValueItem = "03";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "04";
            this.xComboItem4.ValueItem = "04";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "05";
            this.xComboItem5.ValueItem = "05";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "06";
            this.xComboItem6.ValueItem = "06";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "07";
            this.xComboItem7.ValueItem = "07";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "08";
            this.xComboItem8.ValueItem = "08";
            // 
            // xComboItem9
            // 
            this.xComboItem9.DisplayItem = "09";
            this.xComboItem9.ValueItem = "09";
            // 
            // xComboItem10
            // 
            this.xComboItem10.DisplayItem = "10";
            this.xComboItem10.ValueItem = "10";
            // 
            // xComboItem11
            // 
            this.xComboItem11.DisplayItem = "11";
            this.xComboItem11.ValueItem = "11";
            // 
            // xComboItem12
            // 
            this.xComboItem12.DisplayItem = "12";
            this.xComboItem12.ValueItem = "12";
            // 
            // xComboItem13
            // 
            this.xComboItem13.DisplayItem = "13";
            this.xComboItem13.ValueItem = "13";
            // 
            // xComboItem14
            // 
            this.xComboItem14.DisplayItem = "14";
            this.xComboItem14.ValueItem = "14";
            // 
            // xComboItem15
            // 
            this.xComboItem15.DisplayItem = "15";
            this.xComboItem15.ValueItem = "15";
            // 
            // xComboItem16
            // 
            this.xComboItem16.DisplayItem = "16";
            this.xComboItem16.ValueItem = "16";
            // 
            // xComboItem17
            // 
            this.xComboItem17.DisplayItem = "17";
            this.xComboItem17.ValueItem = "17";
            // 
            // xComboItem18
            // 
            this.xComboItem18.DisplayItem = "18";
            this.xComboItem18.ValueItem = "18";
            // 
            // xComboItem19
            // 
            this.xComboItem19.DisplayItem = "19";
            this.xComboItem19.ValueItem = "19";
            // 
            // xComboItem20
            // 
            this.xComboItem20.DisplayItem = "20";
            this.xComboItem20.ValueItem = "20";
            // 
            // xComboItem21
            // 
            this.xComboItem21.DisplayItem = "21";
            this.xComboItem21.ValueItem = "21";
            // 
            // xComboItem22
            // 
            this.xComboItem22.DisplayItem = "22";
            this.xComboItem22.ValueItem = "22";
            // 
            // xComboItem23
            // 
            this.xComboItem23.DisplayItem = "23";
            this.xComboItem23.ValueItem = "23";
            // 
            // dtpReserDate
            // 
            this.dtpReserDate.Location = new System.Drawing.Point(76, 8);
            this.dtpReserDate.Name = "dtpReserDate";
            this.dtpReserDate.Size = new System.Drawing.Size(102, 20);
            this.dtpReserDate.TabIndex = 3;
            this.dtpReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.Location = new System.Drawing.Point(8, 7);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(64, 21);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "指定日付";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(722, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // FINDReserList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(980, 558);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "FINDReserList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "予約詳細内訳";
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReserList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch( e.Func )
			{
				case IHIS.Framework.FunctionType.Update:
					e.IsBaseCall = false;
                    if (this.grdReserList.SaveLayout())
                    {
                        XMessageBox.Show("保存が完了しました。", "保存", MessageBoxIcon.Information);
                    }
                    else
                    {
                        XMessageBox.Show("保存に失敗しました。", "保存失敗", MessageBoxIcon.Error);
                    }
					break;

                case FunctionType.Query:
                    this.grdReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.grdReserList.SetBindVarValue("f_bunho", ar_bunho);
                    this.grdReserList.SetBindVarValue("f_jundal_part", ar_jundal_part);
                    this.grdReserList.SetBindVarValue("f_order_date", ar_order_date);
                    this.grdReserList.SetBindVarValue("f_reser_date", ar_reser_date);

                    this.grdReserList.QueryLayout(false);

                    break;
				default:
					break;
			}
		}

		private void grdReserList_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
		{
			if (e.ChangeValue.ToString() == "Y")
			{
				grdReserList.SetItemValue(e.RowNumber, "reser_date", dtpReserDate.GetDataValue());
				string reser_time = "";

				reser_time = cmbHH.Text + cmbMM.Text;

				grdReserList.SetItemValue(e.RowNumber, "reser_time", reser_time);
			}
			else
			{
				grdReserList.SetItemValue(e.RowNumber, "reser_date", null);
				grdReserList.SetItemValue(e.RowNumber, "reser_time", null);
			}

		}

        private void grdReserList_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            for (int i = 0; i < grdReserList.RowCount; i++)
            {
                if (grdReserList.GetItemString(i, "reser_date") != "")
                {
                    // 오다 일자보다 적으면 선택 안되게 10.02.02
                    if (double.Parse(grdReserList.GetItemString(i, "reser_date").Replace("-", "").Replace("/", "")) < double.Parse(grdReserList.GetItemString(i, "order_date").Replace("/", "").Replace("-", "")))
                    {
                        XMessageBox.Show("オーダ日付より以前の日付は選択できません。");
                        grdReserList.SetItemValue(i, "reser_date", "");
                    }
                }

                if (grdReserList.GetItemString(i, "reser_date") != "")
                {
                    // 오늘 일자보다 적으면 선택 안되게 10.02.02
                    if (double.Parse(grdReserList.GetItemString(i, "reser_date").Replace("-", "").Replace("/", "")) < double.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").Replace("/", "").Replace("-", "")))
                    {
                        XMessageBox.Show("以前の日付は選択できません。");
                        grdReserList.SetItemValue(i, "reser_date", "");
                    }
                }
            }

        }

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            FINDReserList parent;

            public XSavePerformer(FINDReserList parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch(item.RowState)
                {
                    case DataRowState.Modified:
                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();

                        inputList.Add(item.BindVarList["f_pksch0201"].VarValue);
                        inputList.Add(item.BindVarList["f_hangmog_code"].VarValue);
                        inputList.Add("");
                        inputList.Add(item.BindVarList["f_reser_date"].VarValue);
                        inputList.Add(item.BindVarList["f_reser_time"].VarValue);
                        inputList.Add(item.BindVarList["q_user_id"].VarValue);
                        inputList.Add(item.BindVarList["f_comments"].VarValue);
                        inputList.Add(item.BindVarList["f_suname"].VarValue);
                        inputList.Add("0");

                        if (!Service.ExecuteProcedure("PR_SCH_SCH0201_INSERT", inputList, outputList))
                        {
                            return false;
                        }
                    break;
                }
                return true;                    
            }
        }
        #endregion

    }
}
