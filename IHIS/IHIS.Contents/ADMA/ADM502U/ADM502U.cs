#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM502U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM502U : IHIS.Framework.XScreen
    {
        #region Fields
        //Radio 버튼의 색깔 변경
        private Color selectedBackColor = Color.PaleTurquoise;
        private Color unSelectedBackColor = Color.FromArgb(227, 248, 181);
        #endregion

        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGrid grdList;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XRadioButton rbxGrpID;
        private IHIS.Framework.XRadioButton rbxSource;
        private IHIS.Framework.XRadioButton rbxRegiMemb;
        private IHIS.Framework.XRadioButton rbxKoreaMsg;
        private IHIS.Framework.XRadioButton rbxJapanMsg;
        private IHIS.Framework.XGroupBox gbxQryGubun;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XFindWorker fwkGrpID;
        private IHIS.Framework.XFindWorker fwkRegiMemb;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.XButton btnEmpty;
        private IHIS.Framework.XButton btnLoad;
        private System.Windows.Forms.CheckBox cbxKo;
        private IHIS.Framework.XButton xButton1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ADM502U()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdList.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdList);

        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.fwkGrpID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fwkRegiMemb = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.gbxQryGubun = new IHIS.Framework.XGroupBox();
            this.rbxJapanMsg = new IHIS.Framework.XRadioButton();
            this.rbxKoreaMsg = new IHIS.Framework.XRadioButton();
            this.rbxRegiMemb = new IHIS.Framework.XRadioButton();
            this.rbxSource = new IHIS.Framework.XRadioButton();
            this.rbxGrpID = new IHIS.Framework.XRadioButton();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.xButton1 = new IHIS.Framework.XButton();
            this.cbxKo = new System.Windows.Forms.CheckBox();
            this.btnLoad = new IHIS.Framework.XButton();
            this.btnEmpty = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.gbxQryGubun.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdList.ColPerLine = 6;
            this.grdList.ColResizable = true;
            this.grdList.Cols = 6;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(26);
            this.grdList.Location = new System.Drawing.Point(5, 35);
            this.grdList.Name = "grdList";
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(950, 510);
            this.grdList.TabIndex = 1;
            this.grdList.ToolTipActive = true;
            this.grdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdList_GridColumnChanged);
            this.grdList.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdList_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pk";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 67;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.HeaderText = "メッセージID";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AutoTabDataSelected = true;
            this.xEditGridCell2.CellLen = 3;
            this.xEditGridCell2.CellName = "grp_id";
            this.xEditGridCell2.CellWidth = 61;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.FindWorker = this.fwkGrpID;
            this.xEditGridCell2.HeaderText = "グループID";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell2.IsNotNull = true;
            // 
            // fwkGrpID
            // 
            this.fwkGrpID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkGrpID.FormText = "그룹정보";
            this.fwkGrpID.InputSQL = "SELECT GRP_ID, GRP_NM FROM ADM0100\r\nORDER BY GRP_ID";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "grp_id";
            this.findColumnInfo1.ColWidth = 95;
            this.findColumnInfo1.HeaderText = "Group ID";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "grp_nm";
            this.findColumnInfo2.ColWidth = 196;
            this.findColumnInfo2.HeaderText = "Group Name";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AutoTabDataSelected = true;
            this.xEditGridCell6.CellLen = 8;
            this.xEditGridCell6.CellName = "regi_memb";
            this.xEditGridCell6.CellWidth = 82;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.FindWorker = this.fwkRegiMemb;
            this.xEditGridCell6.HeaderText = "登録者ID";
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell6.IsNotNull = true;
            // 
            // fwkRegiMemb
            // 
            this.fwkRegiMemb.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkRegiMemb.FormText = "사용자정보";
            this.fwkRegiMemb.InputSQL = "SELECT USER_ID, USER_NM FROM ADM3200\r\nWHERE USER_END_YMD IS NULL";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "user_id";
            this.findColumnInfo3.ColWidth = 108;
            this.findColumnInfo3.HeaderText = "User ID";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_nm";
            this.findColumnInfo4.ColWidth = 235;
            this.findColumnInfo4.HeaderText = "User Name";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 250;
            this.xEditGridCell7.CellName = "msg_source";
            this.xEditGridCell7.CellWidth = 229;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.HeaderText = "Server Source";
            this.xEditGridCell7.IsNotNull = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoInsertAtEnterKey = true;
            this.xEditGridCell3.CellLen = 250;
            this.xEditGridCell3.CellName = "korea_msg";
            this.xEditGridCell3.CellWidth = 244;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.HeaderText = "韓国語";
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 250;
            this.xEditGridCell4.CellName = "japan_msg";
            this.xEditGridCell4.CellWidth = 244;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.HeaderText = "日本語";
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(460, 3);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // gbxQryGubun
            // 
            this.gbxQryGubun.Controls.Add(this.rbxJapanMsg);
            this.gbxQryGubun.Controls.Add(this.rbxKoreaMsg);
            this.gbxQryGubun.Controls.Add(this.rbxRegiMemb);
            this.gbxQryGubun.Controls.Add(this.rbxSource);
            this.gbxQryGubun.Controls.Add(this.rbxGrpID);
            this.gbxQryGubun.Location = new System.Drawing.Point(112, 0);
            this.gbxQryGubun.Name = "gbxQryGubun";
            this.gbxQryGubun.Size = new System.Drawing.Size(384, 32);
            this.gbxQryGubun.TabIndex = 6;
            this.gbxQryGubun.TabStop = false;
            // 
            // rbxJapanMsg
            // 
            this.rbxJapanMsg.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxJapanMsg.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxJapanMsg.CheckedValue = "E";
            this.rbxJapanMsg.Location = new System.Drawing.Point(306, 6);
            this.rbxJapanMsg.Name = "rbxJapanMsg";
            this.rbxJapanMsg.Size = new System.Drawing.Size(76, 24);
            this.rbxJapanMsg.TabIndex = 4;
            this.rbxJapanMsg.Tag = "E";
            this.rbxJapanMsg.Text = "日本語";
            this.rbxJapanMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxJapanMsg.UseVisualStyleBackColor = false;
            this.rbxJapanMsg.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxKoreaMsg
            // 
            this.rbxKoreaMsg.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxKoreaMsg.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxKoreaMsg.CheckedValue = "D";
            this.rbxKoreaMsg.Location = new System.Drawing.Point(230, 6);
            this.rbxKoreaMsg.Name = "rbxKoreaMsg";
            this.rbxKoreaMsg.Size = new System.Drawing.Size(76, 24);
            this.rbxKoreaMsg.TabIndex = 3;
            this.rbxKoreaMsg.Tag = "D";
            this.rbxKoreaMsg.Text = "韓国語";
            this.rbxKoreaMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxKoreaMsg.UseVisualStyleBackColor = false;
            this.rbxKoreaMsg.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxRegiMemb
            // 
            this.rbxRegiMemb.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxRegiMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxRegiMemb.CheckedValue = "C";
            this.rbxRegiMemb.Location = new System.Drawing.Point(154, 6);
            this.rbxRegiMemb.Name = "rbxRegiMemb";
            this.rbxRegiMemb.Size = new System.Drawing.Size(76, 24);
            this.rbxRegiMemb.TabIndex = 2;
            this.rbxRegiMemb.Tag = "C";
            this.rbxRegiMemb.Text = "登録者4";
            this.rbxRegiMemb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxRegiMemb.UseVisualStyleBackColor = false;
            this.rbxRegiMemb.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxSource
            // 
            this.rbxSource.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxSource.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxSource.CheckedValue = "B";
            this.rbxSource.Location = new System.Drawing.Point(78, 6);
            this.rbxSource.Name = "rbxSource";
            this.rbxSource.Size = new System.Drawing.Size(76, 24);
            this.rbxSource.TabIndex = 1;
            this.rbxSource.Tag = "B";
            this.rbxSource.Text = "Msgソース";
            this.rbxSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSource.UseVisualStyleBackColor = false;
            this.rbxSource.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxGrpID
            // 
            this.rbxGrpID.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxGrpID.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxGrpID.Checked = true;
            this.rbxGrpID.CheckedValue = "A";
            this.rbxGrpID.Location = new System.Drawing.Point(2, 6);
            this.rbxGrpID.Name = "rbxGrpID";
            this.rbxGrpID.Size = new System.Drawing.Size(76, 24);
            this.rbxGrpID.TabIndex = 0;
            this.rbxGrpID.TabStop = true;
            this.rbxGrpID.Tag = "A";
            this.rbxGrpID.Text = "グループID";
            this.rbxGrpID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxGrpID.UseVisualStyleBackColor = false;
            this.rbxGrpID.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtSearch.Location = new System.Drawing.Point(500, 8);
            this.txtSearch.MaxLength = 3;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(452, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(6, 4);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(100, 24);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "検索条件";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButton1);
            this.pnlBottom.Controls.Add(this.cbxKo);
            this.pnlBottom.Controls.Add(this.btnLoad);
            this.pnlBottom.Controls.Add(this.btnEmpty);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(5, 545);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(950, 40);
            this.pnlBottom.TabIndex = 7;
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(360, 6);
            this.xButton1.Name = "xButton1";
            this.xButton1.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xButton1.Size = new System.Drawing.Size(98, 28);
            this.xButton1.TabIndex = 5;
            this.xButton1.Text = "Load Japan Msg";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // cbxKo
            // 
            this.cbxKo.Checked = true;
            this.cbxKo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxKo.Location = new System.Drawing.Point(314, 8);
            this.cbxKo.Name = "cbxKo";
            this.cbxKo.Size = new System.Drawing.Size(64, 24);
            this.cbxKo.TabIndex = 4;
            this.cbxKo.Text = "Korean";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(210, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnLoad.Size = new System.Drawing.Size(98, 28);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Korea Msg";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(12, 6);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnEmpty.Size = new System.Drawing.Size(194, 28);
            this.btnEmpty.TabIndex = 2;
            this.btnEmpty.Text = "韓国語に未登録された内訳照会";
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // ADM502U
            // 
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gbxQryGubun);
            this.Controls.Add(this.xLabel1);
            this.Name = "ADM502U";
            this.Padding = new System.Windows.Forms.Padding(5, 35, 5, 5);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.gbxQryGubun.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region RadioButton Event
        private void OnRadioCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbo = (RadioButton)sender;
            if (rbo.Checked)
                rbo.BackColor = this.selectedBackColor;
            else
                rbo.BackColor = this.unSelectedBackColor;

            //검색조건에 따라 txtSearch의 MaxLength, ImeMode 설정 (TAG에 구분값 저장됨)
            //A.그룹ID(3,A), B.메세지소스(50,A), C.등록자(8,A), D.한국어(100,한글), E.일본어(100, Hiragana)
            switch (rbo.Tag.ToString())
            {
                case "A":
                    this.txtSearch.MaxLength = 3;
                    this.txtSearch.ImeMode = ImeMode.Alpha;
                    break;
                case "B":
                    this.txtSearch.MaxLength = 50;
                    this.txtSearch.ImeMode = ImeMode.Alpha;
                    break;
                case "C":
                    this.txtSearch.MaxLength = 8;
                    this.txtSearch.ImeMode = ImeMode.Alpha;
                    break;
                case "D":
                    this.txtSearch.MaxLength = 100;
                    this.txtSearch.ImeMode = ImeMode.Hangul;
                    break;
                case "E":
                    this.txtSearch.MaxLength = 100;
                    this.txtSearch.ImeMode = ImeMode.Hiragana;
                    break;
            }

        }
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");
            //조회버튼을 누를때 처리하기
            switch (e.Func)
            {
                case FunctionType.Query:  //조회시 검색조건 입력여부 Check
                    if (this.txtSearch.GetDataValue() == "")
                    {
                        SetMsg("검색조건을 입력하십시오", MsgType.Error);
                        this.txtSearch.Focus();
                        e.IsBaseCall = false; //조회하지 않음
                        return;
                    }
                    //Grid Reset
                    this.grdList.Reset();

                    //검색조건에 따라 Grid의 QuerySQL 다르게 설정한다.
                    if (this.rbxGrpID.Checked)  //그룹ID로 조회
                    {
                        this.grdList.QuerySQL
                            = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                            + " WHERE GRP_ID = :f_search_text"
                            + " ORDER BY ADM0003_PK ASC";
                    }
                    else if (this.rbxSource.Checked)  //msg 소스로 찾기
                    {
                        this.grdList.QuerySQL
                            = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                            + " WHERE MSG_SOURCE LIKE '%'||:f_search_text||'%'"
                            + " ORDER BY ADM0003_PK ASC";
                    }
                    else if (this.rbxRegiMemb.Checked)  //등록자로 찾기
                    {
                        this.grdList.QuerySQL
                            = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                            + " WHERE REGI_MEMB LIKE '%'||:f_search_text||'%'"
                            + " ORDER BY ADM0003_PK ASC";
                    }
                    else if (this.rbxKoreaMsg.Checked)  //한국어로 찾기
                    {
                        this.grdList.QuerySQL
                            = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                            + " WHERE KOREA_MSG LIKE '%'||:f_search_text||'%'"
                            + " ORDER BY ADM0003_PK ASC";
                    }
                    else //일본어로 찾기
                    {
                        this.grdList.QuerySQL
                            = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                            + " WHERE JAPAN_MSG LIKE '%'||:f_search_text||'%'"
                            + " ORDER BY ADM0003_PK ASC";
                    }

                    //BIND 변수 SET (f_search_text)
                    grdList.SetBindVarValue("f_search_text", this.txtSearch.GetDataValue());  //검색어
                    //QueryLayout (전체Display)
                    grdList.QueryLayout(true);
                    break;
                case FunctionType.Reset:  //Reset 처리 (리스트만 Clear함, 다른 Control을 Clear하지 않음)
                    this.grdList.Reset();
                    e.IsBaseCall = false;
                    this.txtSearch.Focus();
                    break;
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Enter Key입력시 Text가 있으면 조회 처리함
            if (e.KeyData == Keys.Enter)
                this.btnList.PerformClick(FunctionType.Query);
        }

        #region Grid의 컬럼값이 변경되었을때 layMsgList의 컬럼값도 변경처리함
        private void grdList_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            //그룹ID,등록자 ID 입력시에 Validation Check
            string cmdText = "";
            object retVal = null;
            BindVarCollection bindVars = null;
            switch (e.ColName)
            {
                case "grp_id":
                    //입력된 그룹ID로 그룹명을 조회하여 입력된 ID가 제대로 되어 있지 않으면 Cancel
                    cmdText = "SELECT GRP_NM FROM ADM0100 WHERE GRP_ID = :f_grp_id";
                    bindVars = new BindVarCollection();
                    bindVars.Add("f_grp_id", e.ChangeValue.ToString());
                    retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (retVal == null)
                    {
                        this.SetMsg("그룹ID를 잘못입력하셨습니다.", MsgType.Error);
                        e.Cancel = true;
                    }
                    break;
                case "regi_memb":
                    //입력된 등록자ID로 사용자명을 조회하여 입력된 ID가 제대로 되어 있지 않으면 Cancel
                    cmdText = "SELECT USER_NM FROM ADM3200 WHERE USER_ID = :f_user_id AND USER_END_YMD IS NULL";
                    bindVars = new BindVarCollection();
                    bindVars.Add("f_user_id", e.ChangeValue.ToString());
                    retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (retVal == null)
                    {
                        this.SetMsg("등록자ID를 잘못입력하셨습니다.", MsgType.Error);
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;

            }
        }
        #endregion

        private void btnEmpty_Click(object sender, System.EventArgs e)
        {
            //Grid Reset
            this.grdList.Reset();

            //GRID의 QuerySQL SET (일본어가 등록안된 내역 조회)
            this.grdList.QuerySQL
                = "SELECT ADM0003_PK, GRP_ID, REGI_MEMB, MSG_SOURCE, KOREA_MSG, JAPAN_MSG FROM ADM0003"
                + " WHERE JAPAN_MSG IS NULL"
                + " ORDER BY ADM0003_PK ASC";

            //전체조회
            this.grdList.QueryLayout(true);
        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            Encoding textEncoding = (this.cbxKo.Checked ? Encoding.GetEncoding("ks_c_5601-1987") : Encoding.GetEncoding("Shift_JIS"));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dlg.FileName, textEncoding))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        //PK + GRP_ID + REGI_MEMB + MSG_SOURCE + KOREA_MSG LOAD
                        string[] fDatas = line.Split('\t');
                        if (fDatas.Length == 5)
                        {
                            //맨 마지막에 Add
                            int rowNum = grdList.InsertRow(-1);
                            //Data SET
                            grdList.SetItemValue(rowNum, "pk", fDatas[0]);
                            grdList.SetItemValue(rowNum, "grp_id", fDatas[1]);
                            grdList.SetItemValue(rowNum, "regi_memb", fDatas[2]);
                            grdList.SetItemValue(rowNum, "msg_source", fDatas[3]);
                            grdList.SetItemValue(rowNum, "korea_msg", fDatas[4]);
                        }
                    }
                }
            }
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            Encoding textEncoding = (this.cbxKo.Checked ? Encoding.GetEncoding("ks_c_5601-1987") : Encoding.GetEncoding("Shift_JIS"));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dlg.FileName, textEncoding))
                {
                    string line = "";
                    int index = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //JAPAN_MSG LOAD
                        if (index < this.grdList.RowCount)
                        {
                            //Japan Msg SET
                            grdList.SetItemValue(index, "japan_msg", line);
                        }
                        index++;
                    }
                }
            }
        }

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private ADM502U parent = null;
            public XSavePerformer(ADM502U parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText
                            = "INSERT INTO ADM0003 (ADM0003_PK, GRP_ID, MSG_SOURCE, REGI_MEMB, KOREA_MSG, JAPAN_MSG) "
                            + " VALUES(:f_pk, :f_grp_id, :f_msg_source, :f_regi_memb, :f_korea_msg, :f_japan_msg)";
                        break;
                    case DataRowState.Modified:
                        cmdText
                            = "UPDATE ADM0003"
                            + "   SET GRP_ID     = :f_grp_id"
                            + "      ,MSG_SOURCE = :f_msg_source"
                            + "      ,REGI_MEMB  = :f_regi_memb"
                            + "      ,KOREA_MSG  = :f_korea_msg"
                            + "      ,JAPAN_MSG  = :f_japan_msg"
                            + " WHERE ADM0003_PK = :f_pk";
                        break;
                    case DataRowState.Deleted:
                        cmdText
                            = "DELETE ADM0003"
                            + " WHERE ADM0003_PK = :f_pk";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdList_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }

    }
}

