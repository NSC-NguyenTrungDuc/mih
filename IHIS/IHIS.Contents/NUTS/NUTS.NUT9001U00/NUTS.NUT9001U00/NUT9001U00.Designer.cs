namespace IHIS.NUTS
{
    partial class NUT9001U00
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUT9001U00));
            this.gbxDeadLine = new IHIS.Framework.XGroupBox();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnSearch = new IHIS.Framework.XButton();
            this.btnPost = new IHIS.Framework.XButton();
            this.dpkDeadLine = new IHIS.Framework.XDatePicker();
            this.lblDeadLineDate = new IHIS.Framework.XLabel();
            this.gbxB = new IHIS.Framework.XGroupBox();
            this.btnChangedList_B = new IHIS.Framework.XButton();
            this.btnFinal_BC = new IHIS.Framework.XButton();
            this.btnFinal_B = new IHIS.Framework.XButton();
            this.btnMiddle_B = new IHIS.Framework.XButton();
            this.gbxL = new IHIS.Framework.XGroupBox();
            this.btnChangedList_L = new IHIS.Framework.XButton();
            this.btnFinal_LC = new IHIS.Framework.XButton();
            this.btnFinal_L = new IHIS.Framework.XButton();
            this.btnMiddle_L = new IHIS.Framework.XButton();
            this.gbxD = new IHIS.Framework.XGroupBox();
            this.btnChangedList_D = new IHIS.Framework.XButton();
            this.btnFinal_DC = new IHIS.Framework.XButton();
            this.btnFinal_D = new IHIS.Framework.XButton();
            this.btnMiddle_D = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.cbxSiksaChangeYN = new IHIS.Framework.XCheckBox();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.grdINP5001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.gbxDeadLine.SuspendLayout();
            this.gbxB.SuspendLayout();
            this.gbxL.SuspendLayout();
            this.gbxD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP5001)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(2, "pre.gif");
            this.ImageList.Images.SetKeyName(3, "post.gif");
            // 
            // gbxDeadLine
            // 
            this.gbxDeadLine.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.gbxDeadLine.Controls.Add(this.btnPre);
            this.gbxDeadLine.Controls.Add(this.btnSearch);
            this.gbxDeadLine.Controls.Add(this.btnPost);
            this.gbxDeadLine.Controls.Add(this.dpkDeadLine);
            this.gbxDeadLine.Controls.Add(this.lblDeadLineDate);
            this.gbxDeadLine.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.gbxDeadLine.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxDeadLine.Location = new System.Drawing.Point(91, 3);
            this.gbxDeadLine.Name = "gbxDeadLine";
            this.gbxDeadLine.Protect = true;
            this.gbxDeadLine.Size = new System.Drawing.Size(456, 62);
            this.gbxDeadLine.TabIndex = 0;
            this.gbxDeadLine.TabStop = false;
            this.gbxDeadLine.Text = "締切日付";
            // 
            // btnPre
            // 
            this.btnPre.ImageIndex = 2;
            this.btnPre.ImageList = this.ImageList;
            this.btnPre.Location = new System.Drawing.Point(126, 27);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(26, 28);
            this.btnPre.TabIndex = 114;
            this.btnPre.Tag = "-";
            this.btnPre.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(356, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "照会";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPost
            // 
            this.btnPost.ImageIndex = 3;
            this.btnPost.ImageList = this.ImageList;
            this.btnPost.Location = new System.Drawing.Point(311, 27);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(27, 28);
            this.btnPost.TabIndex = 113;
            this.btnPost.Tag = "+";
            this.btnPost.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // dpkDeadLine
            // 
            this.dpkDeadLine.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dpkDeadLine.Location = new System.Drawing.Point(158, 27);
            this.dpkDeadLine.Name = "dpkDeadLine";
            this.dpkDeadLine.Size = new System.Drawing.Size(149, 28);
            this.dpkDeadLine.TabIndex = 1;
            this.dpkDeadLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dpkDeadLine.TextChanged += new System.EventHandler(this.dpkDeadLine_TextChanged);
            // 
            // lblDeadLineDate
            // 
            this.lblDeadLineDate.Location = new System.Drawing.Point(26, 27);
            this.lblDeadLineDate.Name = "lblDeadLineDate";
            this.lblDeadLineDate.Size = new System.Drawing.Size(74, 28);
            this.lblDeadLineDate.TabIndex = 0;
            this.lblDeadLineDate.Text = "締切日付";
            this.lblDeadLineDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxB
            // 
            this.gbxB.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.gbxB.Controls.Add(this.btnChangedList_B);
            this.gbxB.Controls.Add(this.btnFinal_BC);
            this.gbxB.Controls.Add(this.btnFinal_B);
            this.gbxB.Controls.Add(this.btnMiddle_B);
            this.gbxB.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.gbxB.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxB.Location = new System.Drawing.Point(23, 11);
            this.gbxB.Name = "gbxB";
            this.gbxB.Protect = true;
            this.gbxB.Size = new System.Drawing.Size(200, 354);
            this.gbxB.TabIndex = 0;
            this.gbxB.TabStop = false;
            this.gbxB.Text = "朝食";
            // 
            // btnChangedList_B
            // 
            this.btnChangedList_B.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnChangedList_B.Location = new System.Drawing.Point(7, 283);
            this.btnChangedList_B.Name = "btnChangedList_B";
            this.btnChangedList_B.Size = new System.Drawing.Size(185, 65);
            this.btnChangedList_B.TabIndex = 1;
            this.btnChangedList_B.Tag = "1";
            this.btnChangedList_B.Text = "[朝食] 変更リスト";
            this.btnChangedList_B.Click += new System.EventHandler(this.btnChangedList_Click);
            // 
            // btnFinal_BC
            // 
            this.btnFinal_BC.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_BC.ImageIndex = 0;
            this.btnFinal_BC.Location = new System.Drawing.Point(7, 251);
            this.btnFinal_BC.Name = "btnFinal_BC";
            this.btnFinal_BC.Size = new System.Drawing.Size(185, 26);
            this.btnFinal_BC.TabIndex = 0;
            this.btnFinal_BC.Tag = "1C";
            this.btnFinal_BC.Text = "最終締切取消";
            this.btnFinal_BC.Click += new System.EventHandler(this.btnFinal_C_Click);
            // 
            // btnFinal_B
            // 
            this.btnFinal_B.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_B.ImageIndex = 0;
            this.btnFinal_B.ImageList = this.ImageList;
            this.btnFinal_B.Location = new System.Drawing.Point(7, 180);
            this.btnFinal_B.Name = "btnFinal_B";
            this.btnFinal_B.Size = new System.Drawing.Size(185, 65);
            this.btnFinal_B.TabIndex = 0;
            this.btnFinal_B.Tag = "1Y";
            this.btnFinal_B.Text = "最終締切";
            this.btnFinal_B.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMiddle_B
            // 
            this.btnMiddle_B.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMiddle_B.Location = new System.Drawing.Point(7, 32);
            this.btnMiddle_B.Name = "btnMiddle_B";
            this.btnMiddle_B.Size = new System.Drawing.Size(185, 132);
            this.btnMiddle_B.TabIndex = 0;
            this.btnMiddle_B.Tag = "1S";
            this.btnMiddle_B.Text = "締切";
            this.btnMiddle_B.Click += new System.EventHandler(this.btn_Click);
            // 
            // gbxL
            // 
            this.gbxL.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.gbxL.Controls.Add(this.btnChangedList_L);
            this.gbxL.Controls.Add(this.btnFinal_LC);
            this.gbxL.Controls.Add(this.btnFinal_L);
            this.gbxL.Controls.Add(this.btnMiddle_L);
            this.gbxL.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.gbxL.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxL.Location = new System.Drawing.Point(237, 11);
            this.gbxL.Name = "gbxL";
            this.gbxL.Protect = true;
            this.gbxL.Size = new System.Drawing.Size(200, 354);
            this.gbxL.TabIndex = 0;
            this.gbxL.TabStop = false;
            this.gbxL.Text = "昼食";
            // 
            // btnChangedList_L
            // 
            this.btnChangedList_L.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnChangedList_L.Location = new System.Drawing.Point(7, 283);
            this.btnChangedList_L.Name = "btnChangedList_L";
            this.btnChangedList_L.Size = new System.Drawing.Size(185, 65);
            this.btnChangedList_L.TabIndex = 1;
            this.btnChangedList_L.Tag = "2";
            this.btnChangedList_L.Text = "[昼食] 変更リスト";
            this.btnChangedList_L.Click += new System.EventHandler(this.btnChangedList_Click);
            // 
            // btnFinal_LC
            // 
            this.btnFinal_LC.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_LC.ImageIndex = 0;
            this.btnFinal_LC.Location = new System.Drawing.Point(7, 251);
            this.btnFinal_LC.Name = "btnFinal_LC";
            this.btnFinal_LC.Size = new System.Drawing.Size(182, 26);
            this.btnFinal_LC.TabIndex = 0;
            this.btnFinal_LC.Tag = "2C";
            this.btnFinal_LC.Text = "最終締切取消";
            this.btnFinal_LC.Click += new System.EventHandler(this.btnFinal_C_Click);
            // 
            // btnFinal_L
            // 
            this.btnFinal_L.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_L.ImageIndex = 0;
            this.btnFinal_L.ImageList = this.ImageList;
            this.btnFinal_L.Location = new System.Drawing.Point(7, 180);
            this.btnFinal_L.Name = "btnFinal_L";
            this.btnFinal_L.Size = new System.Drawing.Size(182, 65);
            this.btnFinal_L.TabIndex = 0;
            this.btnFinal_L.Tag = "2Y";
            this.btnFinal_L.Text = "最終締切";
            this.btnFinal_L.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMiddle_L
            // 
            this.btnMiddle_L.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMiddle_L.Location = new System.Drawing.Point(7, 32);
            this.btnMiddle_L.Name = "btnMiddle_L";
            this.btnMiddle_L.Size = new System.Drawing.Size(185, 132);
            this.btnMiddle_L.TabIndex = 0;
            this.btnMiddle_L.Tag = "2S";
            this.btnMiddle_L.Text = "締切";
            this.btnMiddle_L.Click += new System.EventHandler(this.btn_Click);
            // 
            // gbxD
            // 
            this.gbxD.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.gbxD.Controls.Add(this.btnChangedList_D);
            this.gbxD.Controls.Add(this.btnFinal_DC);
            this.gbxD.Controls.Add(this.btnFinal_D);
            this.gbxD.Controls.Add(this.btnMiddle_D);
            this.gbxD.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gbxD.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.gbxD.Location = new System.Drawing.Point(450, 11);
            this.gbxD.Name = "gbxD";
            this.gbxD.Protect = true;
            this.gbxD.Size = new System.Drawing.Size(200, 354);
            this.gbxD.TabIndex = 0;
            this.gbxD.TabStop = false;
            this.gbxD.Text = "夕食";
            // 
            // btnChangedList_D
            // 
            this.btnChangedList_D.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnChangedList_D.Location = new System.Drawing.Point(7, 283);
            this.btnChangedList_D.Name = "btnChangedList_D";
            this.btnChangedList_D.Size = new System.Drawing.Size(185, 65);
            this.btnChangedList_D.TabIndex = 1;
            this.btnChangedList_D.Tag = "3";
            this.btnChangedList_D.Text = "[夕食] 変更リスト";
            this.btnChangedList_D.Click += new System.EventHandler(this.btnChangedList_Click);
            // 
            // btnFinal_DC
            // 
            this.btnFinal_DC.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_DC.ImageIndex = 0;
            this.btnFinal_DC.Location = new System.Drawing.Point(7, 251);
            this.btnFinal_DC.Name = "btnFinal_DC";
            this.btnFinal_DC.Size = new System.Drawing.Size(185, 26);
            this.btnFinal_DC.TabIndex = 0;
            this.btnFinal_DC.Tag = "3C";
            this.btnFinal_DC.Text = "最終締切取消";
            this.btnFinal_DC.Click += new System.EventHandler(this.btnFinal_C_Click);
            // 
            // btnFinal_D
            // 
            this.btnFinal_D.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFinal_D.ImageIndex = 0;
            this.btnFinal_D.ImageList = this.ImageList;
            this.btnFinal_D.Location = new System.Drawing.Point(7, 180);
            this.btnFinal_D.Name = "btnFinal_D";
            this.btnFinal_D.Size = new System.Drawing.Size(185, 65);
            this.btnFinal_D.TabIndex = 0;
            this.btnFinal_D.Tag = "3Y";
            this.btnFinal_D.Text = "最終締切";
            this.btnFinal_D.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMiddle_D
            // 
            this.btnMiddle_D.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMiddle_D.Location = new System.Drawing.Point(7, 32);
            this.btnMiddle_D.Name = "btnMiddle_D";
            this.btnMiddle_D.Size = new System.Drawing.Size(185, 132);
            this.btnMiddle_D.TabIndex = 0;
            this.btnMiddle_D.Tag = "3S";
            this.btnMiddle_D.Text = "締切";
            this.btnMiddle_D.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "照会", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.Location = new System.Drawing.Point(508, 3);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cbxSiksaChangeYN);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Location = new System.Drawing.Point(0, 442);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(673, 39);
            this.pnlBottom.TabIndex = 2;
            // 
            // cbxSiksaChangeYN
            // 
            this.cbxSiksaChangeYN.AutoSize = true;
            this.cbxSiksaChangeYN.Location = new System.Drawing.Point(10, 12);
            this.cbxSiksaChangeYN.Name = "cbxSiksaChangeYN";
            this.cbxSiksaChangeYN.Size = new System.Drawing.Size(166, 17);
            this.cbxSiksaChangeYN.TabIndex = 1;
            this.cbxSiksaChangeYN.Text = "最終締切後食事変更可能";
            this.cbxSiksaChangeYN.UseVisualStyleBackColor = false;
            this.cbxSiksaChangeYN.CheckedChanged += new System.EventHandler(this.cbxSiksaChangeYN_CheckedChanged);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlStatus);
            this.pnlCenter.Controls.Add(this.grdINP5001);
            this.pnlCenter.Controls.Add(this.gbxB);
            this.pnlCenter.Controls.Add(this.gbxL);
            this.pnlCenter.Controls.Add(this.gbxD);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 71);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(673, 411);
            this.pnlCenter.TabIndex = 3;
            // 
            // grdINP5001
            // 
            this.grdINP5001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdINP5001.ColPerLine = 8;
            this.grdINP5001.Cols = 8;
            this.grdINP5001.FixedRows = 1;
            this.grdINP5001.HeaderHeights.Add(21);
            this.grdINP5001.Location = new System.Drawing.Point(3, 414);
            this.grdINP5001.Name = "grdINP5001";
            this.grdINP5001.QuerySQL = resources.GetString("grdINP5001.QuerySQL");
            this.grdINP5001.Rows = 2;
            this.grdINP5001.Size = new System.Drawing.Size(666, 70);
            this.grdINP5001.TabIndex = 1;
            this.grdINP5001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdINP5001_QueryEnd);
            this.grdINP5001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP5001_QueryStarting);
            this.grdINP5001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP5001_RowFocusChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "magam_date";
            this.xEditGridCell6.HeaderText = "締切日付";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "charge_yn";
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderText = "CRON";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "nut_jo_magam_yn";
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.HeaderText = "朝食";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "nut_ju_magam_yn";
            this.xEditGridCell13.Col = 4;
            this.xEditGridCell13.HeaderText = "昼食";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "nut_seok_magam_yn";
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.HeaderText = "夕食";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "b_seq";
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderText = "朝食締切回数";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "l_seq";
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.HeaderText = "昼食締切回数";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "d_seq";
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.HeaderText = "夕食締切回数";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.gbxDeadLine);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(673, 71);
            this.pnlTop.TabIndex = 4;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlStatus.BackgroundImage")));
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Location = new System.Drawing.Point(12, 143);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(649, 62);
            this.pnlStatus.TabIndex = 103;
            this.pnlStatus.Visible = false;
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(403, 16);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(228, 29);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(10, 16);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(374, 29);
            this.pgbProgress.TabIndex = 0;
            // 
            // NUT9001U00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUT9001U00";
            this.Size = new System.Drawing.Size(673, 482);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUT9001U00_ScreenOpen);
            this.gbxDeadLine.ResumeLayout(false);
            this.gbxDeadLine.PerformLayout();
            this.gbxB.ResumeLayout(false);
            this.gbxL.ResumeLayout(false);
            this.gbxD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP5001)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XGroupBox gbxDeadLine;
        private IHIS.Framework.XGroupBox gbxB;
        private IHIS.Framework.XGroupBox gbxL;
        private IHIS.Framework.XGroupBox gbxD;
        private IHIS.Framework.XDatePicker dpkDeadLine;
        private IHIS.Framework.XLabel lblDeadLineDate;
        private IHIS.Framework.XButton btnMiddle_B;
        private IHIS.Framework.XButton btnMiddle_L;
        private IHIS.Framework.XButton btnMiddle_D;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlCenter;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XEditGrid grdINP5001;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XButton btnChangedList_B;
        private IHIS.Framework.XButton btnChangedList_L;
        private IHIS.Framework.XButton btnChangedList_D;
        private IHIS.Framework.XButton btnFinal_B;
        private IHIS.Framework.XButton btnFinal_L;
        private IHIS.Framework.XButton btnFinal_D;
        private IHIS.Framework.XButton btnSearch;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XButton btnFinal_BC;
        private IHIS.Framework.XButton btnFinal_LC;
        private IHIS.Framework.XButton btnFinal_DC;
        private IHIS.Framework.XButton btnPre;
        private IHIS.Framework.XButton btnPost;
        private IHIS.Framework.XCheckBox cbxSiksaChangeYN;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lbStatus;
        private IHIS.Framework.XProgressBar pgbProgress;
    }
}
