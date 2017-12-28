#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
    /// OIF0001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OIF0001U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel panel1;
        private IHIS.Framework.XDatePicker dtpApplyDate;
        private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XFindBox fbxSearchGubun;
        private IHIS.Framework.XDisplayBox dbxSearchGubunName;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout layCommon;
		private IHIS.Framework.SingleLayout layDupCheck;
        private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XPanel xPanel1;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private SingleLayoutItem singleLayoutItem1;
        private XEditGrid grdOIF0001;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XFindWorker fwkCode;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OIF0001U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OIF0001U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.panel1 = new IHIS.Framework.XPanel();
            this.dbxSearchGubunName = new IHIS.Framework.XDisplayBox();
            this.fbxSearchGubun = new IHIS.Framework.XFindBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpApplyDate = new IHIS.Framework.XDatePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOIF0001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.fwkCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOIF0001)).BeginInit();
            this.SuspendLayout();
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(0, 6);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(759, 34);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.FormText = "ORCAコード照会";
            this.fwkCommon.InputSQL = resources.GetString("fwkCommon.InputSQL");
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "MAP区分";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "MAP区分名";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "코드";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 216;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "코드명";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dbxSearchGubunName);
            this.panel1.Controls.Add(this.fbxSearchGubun);
            this.panel1.Controls.Add(this.xLabel18);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Controls.Add(this.dtpApplyDate);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 31);
            this.panel1.TabIndex = 2;
            // 
            // dbxSearchGubunName
            // 
            this.dbxSearchGubunName.Location = new System.Drawing.Point(368, 6);
            this.dbxSearchGubunName.Name = "dbxSearchGubunName";
            this.dbxSearchGubunName.Size = new System.Drawing.Size(162, 21);
            this.dbxSearchGubunName.TabIndex = 27;
            // 
            // fbxSearchGubun
            // 
            this.fbxSearchGubun.FindWorker = this.fwkCommon;
            this.fbxSearchGubun.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.fbxSearchGubun.Location = new System.Drawing.Point(314, 6);
            this.fbxSearchGubun.Name = "fbxSearchGubun";
            this.fbxSearchGubun.Size = new System.Drawing.Size(56, 21);
            this.fbxSearchGubun.TabIndex = 0;
            this.fbxSearchGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxSearchGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Location = new System.Drawing.Point(230, 6);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(86, 21);
            this.xLabel18.TabIndex = 5;
            this.xLabel18.Text = "マッピング区分";
            this.xLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(8, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(86, 21);
            this.xLabel1.TabIndex = 4;
            this.xLabel1.Text = "適用日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpApplyDate.IsJapanYearType = true;
            this.dtpApplyDate.Location = new System.Drawing.Point(93, 6);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(112, 21);
            this.dtpApplyDate.TabIndex = 3;
            this.dtpApplyDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptApplyDate_DateValidating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(761, 38);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // layDupCheck
            // 
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupCheck.QuerySQL = "SELECT \'Y\'\r\n  FROM OIF0001 A\r\n WHERE A.HOSP_CODE  = :f_hosp_code\r\n   AND A.GUBUN " +
                "     = :f_gubun\r\n   AND A.START_DATE = :f_start_date";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 537);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(761, 42);
            this.xPanel1.TabIndex = 4;
            // 
            // grdOIF0001
            // 
            this.grdOIF0001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell8});
            this.grdOIF0001.ColPerLine = 7;
            this.grdOIF0001.Cols = 7;
            this.grdOIF0001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOIF0001.FixedRows = 1;
            this.grdOIF0001.HeaderHeights.Add(25);
            this.grdOIF0001.Location = new System.Drawing.Point(5, 36);
            this.grdOIF0001.Name = "grdOIF0001";
            this.grdOIF0001.QuerySQL = resources.GetString("grdOIF0001.QuerySQL");
            this.grdOIF0001.Rows = 2;
            this.grdOIF0001.Size = new System.Drawing.Size(761, 501);
            this.grdOIF0001.TabIndex = 5;
            this.grdOIF0001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOIF0001_QueryStarting);
            this.grdOIF0001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOIF0001_GridColumnChanged);
            this.grdOIF0001.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOIF0001_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gubun_code";
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderText = "マッピング区分";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.SuppressRepeating = true;
            this.xEditGridCell1.UserSQL = "SELECT CODE\r\n      ,CODE_NAME\r\n      ,MAP_TYPE\r\n  FROM OIF0102\r\n WHERE HOSP_CODE " +
                "= FN_ADM_LOAD_HOSP_CODE()\r\n   AND CODE_TYPE = \'MAP_GUBUN\'\r\n ORDER BY CODE  ";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ocs_code";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.FindWorker = this.fwkCode;
            this.xEditGridCell2.HeaderText = "OCSコード";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // fwkCode
            // 
            this.fwkCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkCode.FormText = "OCSコード参照";
            this.fwkCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCode.ServerFilter = true;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "code";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo5.HeaderText = "コード";
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 140;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo6.HeaderText = "コード名";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "orca_code";
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.FindWorker = this.fwkCommon;
            this.xEditGridCell3.HeaderText = "ORCAコード";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 105;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.HeaderText = "開始日付";
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 105;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderText = "終了日付";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code_name";
            this.xEditGridCell7.CellWidth = 120;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "ORCAコード名";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "code_type";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "コードタイプ";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ocs_name";
            this.xEditGridCell8.CellWidth = 120;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "OCSコード名";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // OIF0001U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.grdOIF0001);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "OIF0001U00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(771, 584);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OIF0001U00_Closing);
            this.Load += new System.EventHandler(this.OIF0001U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOIF0001)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen_Load

		private void OIF0001U00_Load(object sender, System.EventArgs e)
		{
            this.grdOIF0001.SavePerformer = new XSavePeformer(this);

			this.dtpApplyDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdOIF0001.QueryLayout(false);
		}

		#endregion

		#region Find Click

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = (XFindBox) sender;

			switch(control.Name)
			{
				case "fbxSearchGubun" :
					this.fwkCommon.FormText = "MAP区分照会";
                    this.fwkCommon.ColInfos[0].HeaderText = "区分コード";
                    this.fwkCommon.ColInfos[1].HeaderText = "区分名";

//                    this.fwkCommon.InputSQL = @"SELECT A.CODE
//                                                 , A.CODE_NAME
//                                              FROM OIF0102 A
//                                             WHERE A.HOSP_CODE = :f_hosp_code 
//                                               AND A.CODE_TYPE = :f_code_type
//                                             ORDER BY A.CODE";

                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN");
					break;
			}
		}
		#endregion

		private bool DupCheck(string aValue, string aDate)
		{
            //if (this.grdOIF0001.DeletedRowTable != null)
            //{
            //    foreach (DataRow dr in grdOIF0001.DeletedRowTable.Rows)
            //    {
            //        if (dr["gubun"].ToString() == aValue)
            //        {
            //            return false;
            //        }
            //    }
            //}

            //// 현재 그리드에서 찾는다.
            //for (int i=0; i<this.grdOIF0001.RowCount; i++)
            //{
            //    if (i != this.grdOIF0001.CurrentRowNumber &&
            //        this.grdOIF0001.GetItemString(i, "gubun") == aValue &&
            //        this.grdOIF0001.GetItemString(i, "start_date") == aDate)
            //    {
            //        return true;
            //    }
            //} 

            //// DB에서 체크한다.

            //this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.layDupCheck.SetBindVarValue("f_gubun", aValue);
            //this.layDupCheck.SetBindVarValue("f_start_date", this.grdOIF0001.GetItemString(this.grdOIF0001.CurrentRowNumber, "start_date"));
            //this.layDupCheck.QueryLayout();
            //if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
            //{
            //    return true;
            //}

			return false;
        }
        //private void grdOIF0001_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        //{
        //    switch (e.ColName)
        //    {
        //        case "gubun":
        //            if (this.DupCheck(e.ChangeValue.ToString(), e.DataRow["start_date"].ToString()))
        //            {
        //                string msg = (NetInfo.Language == LangMode.Ko ? "이미 등록된 유형코드 입니다." : "同一のコードが存在します。");
        //                //this.SetMsg(msg, MsgType.Error);
        //                string　mcap = NetInfo.Language == LangMode.Ko ? "주의" : "注意";
        //                XMessageBox.Show(msg, mcap);
        //                e.Cancel = true;
        //            }
        //            break;
        //    }
        //}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Reset:
					//this.grdOIF0001.SetItemValue(grdOIF0001.CurrentRowNumber, "gubun_ymd", this.dtpApplyDate.GetDataValue());
					this.dtpApplyDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					break;
			}
		}
		private void grdOIF0001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            //if (this.grdOIF0001.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
            //{
            //    this.ControlProtect(true);
            //}
            //else
            //{
            //    this.ControlProtect(false);
            //}		
		}

		private void ControlProtect (bool aIsProtect)
		{
            //this.txtGubun.Protect = aIsProtect;
		}

        private void grdOIF0001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOIF0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOIF0001.SetBindVarValue("f_gubun_code", this.fbxSearchGubun.GetDataValue());
            this.grdOIF0001.SetBindVarValue("f_start_date", this.dtpApplyDate.GetDataValue());
        }

        private void fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();

            this.layCommon.LayoutItems.Clear();

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
                                              FROM OIF0102 A
                                             WHERE A.HOSP_CODE   = :f_hosp_code 
                                               AND A.CODE_TYPE   = :f_code_type
                                               AND A.CODE        = :f_code ";
                    sli.DataName = "gubun_name";
                    sli.BindControl = this.dbxSearchGubunName;
                    this.layCommon.LayoutItems.Add(sli);

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code", fbxSearchGubun.GetDataValue());
                    this.layCommon.SetBindVarValue("f_code_type", "MAP_GUBUN");
                    this.layCommon.QueryLayout();
                    this.grdOIF0001.QueryLayout(false);
                    break;
            }
        }
       
//        private void grdOIF0001_GridFindSelected(object sender, GridFindSelectedEventArgs e)
//        {
//            if (e.ColName == "johap_gubun")
//            {
////                this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
////                                                  FROM BAS0102 A 
////                                                 WHERE A.CODE_TYPE = 'JOHAP_GUBUN' 
////                                                   AND A.CODE = :f_code";
////                this.layCommon.LayoutItems.Add("code_name");
////                this.layCommon.SetBindVarValue("f_code", e.ReturnValues[0].ToString());
////                this.layCommon.QueryLayout();
//                this.grdOIF0001.SetItemValue(e.RowNumber, "johap_gubun_name", e.ReturnValues[1].ToString());
//            }
//        }

        string mMsg = "";
        string mCap = "";
        string mCheck = "";
        bool boolSave = true;
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.boolSave = true;

            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    int rowNum = this.grdOIF0001.InsertRow();

                    this.grdOIF0001.SetItemValue(rowNum, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    this.grdOIF0001.SetItemValue(rowNum, "end_date", "9998/12/31");
                    if (this.grdOIF0001.CurrentRowNumber > 0)
                    {
                        int cntNumber = this.grdOIF0001.CurrentRowNumber - 1;
                        this.grdOIF0001.SetItemValue(rowNum, "gubun_code", this.grdOIF0001.GetItemString(cntNumber, "gubun_code"));
                        this.grdOIF0001.SetItemValue(rowNum, "code_type", this.grdOIF0001.GetItemString(cntNumber, "code_type"));
                    }

                    //if (this.fbxSearchGubun.GetDataValue() != "")
                    //{
                    //    this.grdOIF0001.SetItemValue(rowNum, "gubun_code", this.fbxSearchGubun.GetDataValue());
                    //}
                    //else
                    //{
                    //    if (this.grdOIF0001.CurrentRowNumber > 0)
                    //    {
                    //        int cntNumber = this.grdOIF0001.CurrentRowNumber - 1;
                    //        this.grdOIF0001.SetItemValue(rowNum, "gubun_code", this.grdOIF0001.GetItemString(cntNumber, "gubun_code"));
                    //        this.grdOIF0001.SetItemValue(rowNum, "code_type", this.grdOIF0001.GetItemString(cntNumber, "code_type"));
                    //    }
                    //}
                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    if (this.grdOIF0001.SaveLayout())
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : "保存が完了しました。";

                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.grdOIF0001.QueryLayout(false);
                    }
                    else
                    {
                        this.boolSave = false;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";
                        if (Service.ErrFullMsg == "")
                        {
                            string mesg = NetInfo.Language == LangMode.Ko ? "를 입력하여주십시요." : "を入力してください。";
                            this.mMsg = this.mCheck + mesg;

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

//        private void grdOIF0001_GridFindClick(object sender, GridFindClickEventArgs e)
//        {
//            if (e.ColName == "johap_gubun")
//            {
//                this.fwkCommon.FormText = "";
//                this.fwkCommon.InputSQL = @"SELECT A.CODE
//                                                 , A.CODE_NAME
//                                              FROM OIF0001 A
//                                             WHERE A.HOSP_CODE = :f_hosp_code 
//                                               AND A.CODE_TYPE = :f_code_type
//                                               AND(A.CODE      LIKE :f_find1 || '%'
//                                                OR A.CODE_NAME LIKE :f_find1 || '%' )
//                                             ORDER BY A.CODE";

//                this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                this.fwkCommon.SetBindVarValue("f_code_type", "JOHAP_GUBUN");
//            }

//        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private OIF0001U00 parent = null;

            public XSavePeformer(OIF0001U00 parent)
            {
                this.parent = parent;
            }
            #region 입력값 체크
            private int Validateion_Check(BindVarCollection BindVarList)
            {
                int value = 0;
                string messg = "";
                if (BindVarList["f_gubun_code"].VarValue == "")
                {
                    messg += NetInfo.Language == LangMode.Ko ? "구분코드" : "区分コード";
                    value = 1;
                }
                if (BindVarList["f_ocs_code"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "OCS코드" : "OCSコード";
                    value = 1;
                }
                if (BindVarList["f_orca_code"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "ORCA코드" : "ORCAコード";
                    value = 1;
                }
                if (BindVarList["f_start_date"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "개시일자" : "開始日付";
                    value = 1;
                }
                if (BindVarList["f_end_date"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "종료일자" : "終了日付";
                    value = 1;
                }
                parent.mCheck = messg;
                return value;
            }
            #endregion
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object t_dup_check = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (Validateion_Check(item.BindVarList) != 0)
                                {
                                    return false;
                                }
                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM OIF0001
                                                             WHERE HOSP_CODE   = :f_hosp_code
                                                               AND MAP_GUBUN   = :f_gubun_code
                                                               AND OCS_CODE    = :f_ocs_code
                                                               AND START_DATE  = :f_start_date) ";

                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_dup_check))
                                {
                                    if (t_dup_check.ToString() == "Y")
                                    {
                                        XMessageBox.Show("MAP区分コード:「" + item.BindVarList["f_gubun_code"].VarValue + "」" +
                                                         "適用日付:「" + item.BindVarList["f_start_date"].VarValue + "」\r\n" +
                                                         "は既に登録されています。", "注意", MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @" UPDATE OIF0001
                                                SET UPD_DATE    = SYSDATE
                                                  , UPD_ID      = :f_user_id
                                                  , END_DATE = TO_DATE(:f_start_date) - 1
                                              WHERE HOSP_CODE   = :f_hosp_code 
                                                AND MAP_GUBUN   = :f_gubun_code
                                                AND OCS_CODE    = :f_ocs_code
                                                AND START_DATE  <= :f_start_date ";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO OIF0001
                                                 ( SYS_DATE          , SYS_ID              , UPD_DATE       , UPD_ID        
                                                 , HOSP_CODE         , MAP_GUBUN           , OCS_CODE       , START_DATE                              
                                                 , END_DATE          , ORCA_CODE )
                                            VALUES
                                                 ( SYSDATE           , :f_user_id          , SYSDATE        , :f_user_id     
                                                 , :f_hosp_code      , :f_gubun_code       , :f_ocs_code    , :f_start_date     
                                                 , :f_end_date       , :f_orca_code )";
                                break;

                            case DataRowState.Modified:
                                if (Validateion_Check(item.BindVarList) != 0)
                                {
                                    return false;
                                }
                                cmdText = @"UPDATE OIF0001
                                               SET UPD_ID       = :f_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , ORCA_CODE    = :f_orca_code
                                                 , END_DATE     = :f_end_date
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND MAP_GUBUN    = :f_gubun_code
                                               AND OCS_CODE     = :f_ocs_code
                                               AND START_DATE   = :f_start_date ";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM OIF0001
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND MAP_GUBUN    = :f_gubun_code
                                               AND OCS_CODE     = :f_ocs_code
                                               AND START_DATE   = :f_start_date ";

                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void dptApplyDate_DateValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                this.grdOIF0001.QueryLayout(false);
            }
        }
        private void grdOIF0001_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (e.ColName == "orca_code")
            {
                //MAP TYPE 코드취득
                string map_type = GetCode_DateValidating(this.grdOIF0001.GetItemString(e.RowNumber, "gubun_code"));
                this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkCommon.SetBindVarValue("f_code_type", map_type);
                this.fwkCommon.FormText = "ORCAコード照会";
                this.fwkCommon.ColInfos[0].HeaderText = "コード";
                this.fwkCommon.ColInfos[1].HeaderText = "コード名";
            }
            else 
            {
                string InputSQL = "";

                switch (this.grdOIF0001.GetItemString(e.RowNumber, "gubun_code"))
                {
                    case "00":
                        InputSQL = @" SELECT A.YOYANG_GIHO, A.YOYANG_NAME
                                        FROM BAS0001 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.YOYANG_GIHO )
                                        ORDER BY A.YOYANG_GIHO ";
                        break;
                    case "01":
                        InputSQL = @" SELECT A.GWA, A.GWA_NAME 
                                        FROM BAS0260 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND A.BUSEO_GUBUN = '1' 
                                         AND (   A.GWA      LIKE :f_find1 || '%'
                                              OR A.GWA_NAME LIKE :f_find1 || '%') 
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.GWA )
                                        ORDER BY A.GWA ";
                        break;
                    case "05":
                    case "09":
                    case "10":
                    case "11":
                    case "13":
                    case "14":
                    case "15":
                    case "16":
                        InputSQL = @" SELECT A.CODE, A.CODE_NAME, A.CODE_TYPE
                                        FROM BAS0102 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND A.CODE_TYPE = :f_code_type
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.CODE )
                                       ORDER BY A.CODE ";
                        break;
                    case "06":
                        InputSQL = @" SELECT A.GWA, A.GWA_NAME 
                                        FROM BAS0260 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND A.BUSEO_GUBUN = '2' 
                                         AND (   A.GWA      LIKE :f_find1 || '%'
                                              OR A.GWA_NAME LIKE :f_find1 || '%') 
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.GWA )
                                       ORDER BY A.GWA ";
                        break;
                    case "07":
                        InputSQL = @" SELECT A.HO_CODE, A.HO_CODE_NAME
                                        FROM BAS0250 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND  (  A.HO_CODE      LIKE :f_find1 || '%'
                                              OR A.HO_CODE_NAME LIKE :f_find1 || '%') 
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.HO_CODE )
                                       ORDER BY A.HO_CODE ";
                        break;
                    case "08":
                        InputSQL = @" SELECT A.HO_GRADE, A.HO_GRADE_NAME 
                                       FROM BAS0251 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND (   A.HO_GRADE      LIKE :f_find1 || '%'
                                              OR A.HO_GRADE_NAME LIKE :f_find1 || '%') 
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31') 
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.HO_GRADE )
                                       ORDER BY A.HO_GRADE ";
                        break;
                    case "18":
                        InputSQL = @" SELECT A.BUWI_CODE, A.BUWI_NAME 
                                        FROM XRT0122 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND (   A.BUWI_CODE  LIKE '' || '%'
                                              OR A.BUWI_NAME  LIKE '' || '%')
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.BUWI_CODE )
                                       ORDER BY A.BUWI_CODE";
                        break;
                    case "19":
                        InputSQL = @" SELECT A.SUB_BUWI, A.SUB_BUWI_NAME 
                                        FROM CHT0118 A
                                       WHERE (   A.SUB_BUWI      LIKE '' || '%'
                                              OR A.SUB_BUWI_NAME LIKE '' || '%')
                                         AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31') 
                                         AND A.HOSP_CODE         = :f_hosp_code
                                         AND NOT EXISTS ( SELECT 'X'
                                                            FROM OIF0001 Z 
                                                           WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                             AND Z.MAP_GUBUN = :f_gubun_code
                                                             AND Z.OCS_CODE  = A.SUB_BUWI ) 
                                       ORDER BY A.SUB_BUWI ";
                        break;
                }
                this.fwkCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkCode.SetBindVarValue("f_start_date", this.dtpApplyDate.GetDataValue());
                if (e.RowNumber > 0)
                {
                    int cntNumber = e.RowNumber - 1;
                    this.fwkCode.SetBindVarValue("f_code_type", this.grdOIF0001.GetItemString(cntNumber, "code_type"));
                    this.fwkCode.SetBindVarValue("f_gubun_code", this.grdOIF0001.GetItemString(cntNumber, "gubun_code"));
                }
                this.fwkCode.InputSQL = InputSQL;                                
            }
        }

        private string GetCode_DateValidating(string code)
        {
            string map_type = "";
            SingleLayout layCommon = new SingleLayout();

            layCommon.QuerySQL = @" SELECT A.MAP_TYPE 
                                    FROM OIF0102 A
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.CODE      = :f_code
                                     AND A.CODE_TYPE = :f_map_type ";
            layCommon.LayoutItems.Add("map_type");
            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCommon.SetBindVarValue("f_code", code);
            layCommon.SetBindVarValue("f_map_type", "MAP_GUBUN");

            if (layCommon.QueryLayout())
            {
                map_type = layCommon.GetItemValue("map_type").ToString();
            }
            return map_type;
        }

        private void grdOIF0001_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ChangeValue.ToString() == "")
            {
                this.grdOIF0001.SetItemValue(e.RowNumber, "code_name","");
            }
            switch(e.ColName)
            {
                case "orca_code":
                    //MAP TYPE 코드취득
                    string map_type = GetCode_DateValidating(this.grdOIF0001.GetItemString(e.RowNumber, "gubun_code"));

                    SingleLayout layCommon = new SingleLayout();
                    layCommon.QuerySQL = @"SELECT  A.CODE_NAME
                                              FROM OIF0102 A
                                             WHERE A.HOSP_CODE = :f_hosp_code 
                                               AND A.CODE_TYPE = :f_map_type
                                               AND A.CODE      = :f_code ";

                    layCommon.LayoutItems.Add("code_name");
                    layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layCommon.SetBindVarValue("f_code", this.grdOIF0001.GetItemString(e.RowNumber, "orca_code"));
                    layCommon.SetBindVarValue("f_map_type", map_type);
                    if (layCommon.QueryLayout())
                    {
                        this.grdOIF0001.SetItemValue(e.RowNumber, "code_name", layCommon.GetItemValue("code_name").ToString());
                    }
                    else
                    {
                        this.grdOIF0001.SetItemValue(e.RowNumber, "code_name", "");
                        this.grdOIF0001.SetItemValue(e.RowNumber, "orca_code", "");
                    }
                    break;
                case "ocs_code":
                    SingleLayout ocsCommon = new SingleLayout();
                    ocsCommon.QuerySQL = @"SELECT  FN_OIF_LOAD_OCS_CODE_NAME(:f_gubun_code, :f_code_type, :f_ocs_code, :f_start_date ) OCS_NAME
                                              FROM DUAL ";
                    ocsCommon.LayoutItems.Add("ocs_name");
                    ocsCommon.SetBindVarValue("f_gubun_code", this.grdOIF0001.GetItemString(e.RowNumber, "gubun_code"));
                    ocsCommon.SetBindVarValue("f_code_type", this.grdOIF0001.GetItemString(e.RowNumber, "code_type"));
                    ocsCommon.SetBindVarValue("f_ocs_code", this.grdOIF0001.GetItemString(e.RowNumber, "ocs_code"));
                    ocsCommon.SetBindVarValue("f_start_date", this.grdOIF0001.GetItemString(e.RowNumber, "start_date"));
                   
                    if (ocsCommon.QueryLayout())
                    {
                        if (ocsCommon.GetItemValue("ocs_name").ToString() != "")
                        {
                            this.grdOIF0001.SetItemValue(e.RowNumber, "ocs_name", ocsCommon.GetItemValue("ocs_name").ToString());
                        }
                        else
                        {
                            //string mMsg = NetInfo.Language == LangMode.Ko ? "OCS코드:「 " + this.grdOIF0001.GetItemString(e.RowNumber, "ocs_code") 
                            //                                                + " 」는 등록되어있지않은코드입니다"
                            //                                              : "OCSコード:「 " + this.grdOIF0001.GetItemString(e.RowNumber, "ocs_code") 
                            //                                                + " 」は 登録されてないコードです。";
                            //string mcap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                            //XMessageBox.Show(mMsg, mcap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.grdOIF0001.SetItemValue(e.RowNumber, "ocs_name", "");
                            this.grdOIF0001.SetItemValue(e.RowNumber, "ocs_code", "");
                        }
                    }
                    else
                    {
                        this.grdOIF0001.SetItemValue(e.RowNumber, "ocs_name", "");
                        this.grdOIF0001.SetItemValue(e.RowNumber, "ocs_code", "");
                    }

                    break;
            }
        }

        private void OIF0001U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }
    }
}

