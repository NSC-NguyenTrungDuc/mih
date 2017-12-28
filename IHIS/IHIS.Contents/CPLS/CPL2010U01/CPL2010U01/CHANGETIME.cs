using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CPLS
{
	/// <summary>
	/// CHANGETIME에 대한 요약 설명입니다.
	/// </summary>
	public class CHANGETIME : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XMstGrid grdSpecimen;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
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
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XButton btnChangeTime;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XButton xButton1;
        private XButton btnSave;
        private ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public CHANGETIME()
		{
			InitializeComponent();
		}

		public CHANGETIME(string aOrderDate, string aBunho, string aGwa, string aDoctor)
		{
            InitializeComponent();

            this.grdSpecimen.SavePerformer = new XSavePerformer(this);

            this.grdSpecimen.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdSpecimen.SetBindVarValue("f_order_date",aOrderDate);
            this.grdSpecimen.SetBindVarValue("f_bunho", aBunho);
            this.grdSpecimen.SetBindVarValue("f_gwa", aGwa);
            //this.grdSpecimen.SetBindVarValue("f_gubun", aGubun);
            this.grdSpecimen.SetBindVarValue("f_doctor", aDoctor);
            //this.grdSpecimen.SetBindVarValue("f_in_out_gubun", aInOutGubun);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHANGETIME));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnSave = new IHIS.Framework.XButton();
            this.xButton1 = new IHIS.Framework.XButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeTime = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdSpecimen = new IHIS.Framework.XMstGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnSave);
            this.xPanel1.Controls.Add(this.xButton1);
            this.xPanel1.Controls.Add(this.btnChangeTime);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.Image = global::IHIS.CPLS.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // xButton1
            // 
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.xButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton1.Image = ((System.Drawing.Image)(resources.GetObject("xButton1.Image")));
            this.xButton1.ImageIndex = 1;
            this.xButton1.ImageList = this.imageList1;
            this.xButton1.Name = "xButton1";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // btnChangeTime
            // 
            resources.ApplyResources(this.btnChangeTime, "btnChangeTime");
            this.btnChangeTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeTime.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTime.Image")));
            this.btnChangeTime.ImageIndex = 2;
            this.btnChangeTime.ImageList = this.imageList1;
            this.btnChangeTime.Name = "btnChangeTime";
            this.btnChangeTime.Click += new System.EventHandler(this.btnChangeTime_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            // 
            // grdSpecimen
            // 
            this.grdSpecimen.ApplyPaintEventToAllColumn = true;
            this.grdSpecimen.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
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
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdSpecimen.ColPerLine = 10;
            this.grdSpecimen.ColResizable = true;
            this.grdSpecimen.Cols = 11;
            this.grdSpecimen.ControlBinding = true;
            resources.ApplyResources(this.grdSpecimen, "grdSpecimen");
            this.grdSpecimen.FixedCols = 1;
            this.grdSpecimen.FixedRows = 1;
            this.grdSpecimen.HeaderHeights.Add(35);
            this.grdSpecimen.Name = "grdSpecimen";
            this.grdSpecimen.QuerySQL = resources.GetString("grdSpecimen.QuerySQL");
            this.grdSpecimen.RowHeaderVisible = true;
            this.grdSpecimen.Rows = 2;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "pkcpl2010";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sunab_yn";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = -1;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jubsu_flag";
            this.xEditGridCell8.CellWidth = 30;
            this.xEditGridCell8.Col = -1;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "slip_name";
            this.xEditGridCell9.CellWidth = 142;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "hangmog_code";
            this.xEditGridCell10.CellWidth = 70;
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gumsa_name";
            this.xEditGridCell11.CellWidth = 218;
            this.xEditGridCell11.Col = 6;
            this.xEditGridCell11.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "specimen_code";
            this.xEditGridCell12.CellWidth = 35;
            this.xEditGridCell12.Col = 8;
            this.xEditGridCell12.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "specimen_name";
            this.xEditGridCell13.CellWidth = 125;
            this.xEditGridCell13.Col = 9;
            this.xEditGridCell13.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "emergency";
            this.xEditGridCell14.CellWidth = 35;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "tube_name";
            this.xEditGridCell15.CellWidth = 73;
            this.xEditGridCell15.Col = -1;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "specimen_ser";
            this.xEditGridCell16.CellWidth = 81;
            this.xEditGridCell16.Col = -1;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "comment_ju_code";
            this.xEditGridCell26.CellWidth = 101;
            this.xEditGridCell26.Col = 10;
            this.xEditGridCell26.DisplayMemoText = true;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "fkocs1003";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "group_gubun";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "part_jubsu_flag";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "gum_jubsu_flag";
            this.xEditGridCell30.CellWidth = 58;
            this.xEditGridCell30.Col = -1;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "dummy";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "modify_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "modify_yn_1";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jundal_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "jubsuja";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "order_date";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell38.CellWidth = 109;
            this.xEditGridCell38.Col = 2;
            this.xEditGridCell38.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdCol = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "bunho";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.IsUpdCol = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "jubsu_date";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "jubsu_time";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "order_time";
            this.xEditGridCell1.CellWidth = 59;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.Mask = "##:##";
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "change_yn";
            this.xEditGridCell2.CellWidth = 35;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // CHANGETIME
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.grdSpecimen);
            this.Controls.Add(this.xPanel1);
            this.Name = "CHANGETIME";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdSpecimen, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdSpecimen.QueryLayout(false);
		}

		#region field
		private string mLowOrderTime = "";
		#endregion

		#region 시간변경 클릭
		private void btnChangeTime_Click(object sender, System.EventArgs e)
		{
            this.mLowOrderTime = this.LowOrderTime();

            //SetMsg("");
            //if (this.grdSpecimen.SaveLayout())
            //{
            //    SetMsg("保存しました。");
            //    this.grdSpecimen.QueryLayout(false);
            //}
            //else
            //    SetMsg("保存に失敗しました。");

		}
		#endregion

		#region 선택된것중 오더 가장 빠른 오더 시간 찾기
		private string LowOrderTime()
		{
			string lowTime = "9999";
			for( int i = 0 ; i < this.grdSpecimen.RowCount; i++ )
			{
				if ( this.grdSpecimen.GetItemString(i,"change_yn") == "Y" )
				{
					if ( this.grdSpecimen.GetItemString(i,"order_time").Length > 0 )
					{
						if ( int.Parse(lowTime) > int.Parse(this.grdSpecimen.GetItemString(i,"order_time")) )
							lowTime = this.grdSpecimen.GetItemString(i,"order_time");
					}
				}
			}

            //오더시간 셋팅
            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                if (this.grdSpecimen.GetItemString(i, "change_yn") == "Y")
                {
                    this.grdSpecimen.SetItemValue(i, "order_time", lowTime);
                }
            }

			return lowTime;
		}
		#endregion

        #region 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            SetMsg("");
            if (this.grdSpecimen.SaveLayout())
            {
                SetMsg("保存しました。");
                this.grdSpecimen.QueryLayout(false);
            }
            else
                SetMsg("保存に失敗しました。");
        }
        #endregion

		private void xButton1_Click(object sender, System.EventArgs e)
		{
			for ( int i=0; i<this.grdSpecimen.RowCount; i++ )
				this.grdSpecimen.SetItemValue(i,"change_yn","Y");
		}

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            CHANGETIME parent;

            public XSavePerformer(CHANGETIME parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case System.Data.DataRowState.Added:

                        break;
                    case System.Data.DataRowState.Modified:

                        cmdText = @"UPDATE CPL2010
                                       SET UPD_ID          = :q_user_id
                                         , UPD_DATE        = SYSDATE
                                         , ORDER_TIME      = :f_order_time 
                                     WHERE HOSP_CODE       = :f_hosp_code
                                       AND PKCPL2010       = :f_pkcpl2010";
                        if (item.BindVarList["f_change_yn"].VarValue == "Y")
                        {
                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;

                    case System.Data.DataRowState.Deleted:

                        break;
                }

                return true;
            }
        }
        #endregion 

	}
}
