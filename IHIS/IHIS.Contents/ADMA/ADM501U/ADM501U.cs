#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM501U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class ADM501U : IHIS.Framework.XScreen
    {
        #region Fields
        //Radio 버튼의 색깔 변경
        private Color selectedBackColor = Color.PaleTurquoise;
        private Color unSelectedBackColor = Color.FromArgb(227, 248, 181);
        private Encoding koEncoding = Encoding.GetEncoding("ks_c_5601-1987");
        private Encoding jaEncoding = Encoding.GetEncoding("Shift_JIS");
        #endregion

        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGrid grdList;
        private IHIS.Framework.XRadioButton rboKorea;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XGroupBox gbxLangGubun;
        private IHIS.Framework.XRadioButton rbxJapan;
        private IHIS.Framework.XRadioButton rbxSpeak;
        private IHIS.Framework.XGroupBox gbxMsgGubun;
        private IHIS.Framework.XRadioButton rbxMessage;
        private IHIS.Framework.XRadioButton rbxField;
        private IHIS.Framework.XTextBox txtSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private IHIS.Framework.XButton btnGetList;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnExport;
        private IHIS.Framework.XButton btnLoad;
        private System.Windows.Forms.CheckBox cbxKo;
        private IHIS.Framework.XButton xButton1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ADM501U()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            this.grdList.ParamList = CreateGrdListParamList();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM501U));
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.gbxMsgGubun = new IHIS.Framework.XGroupBox();
            this.rbxMessage = new IHIS.Framework.XRadioButton();
            this.rbxField = new IHIS.Framework.XRadioButton();
            this.gbxLangGubun = new IHIS.Framework.XGroupBox();
            this.rbxSpeak = new IHIS.Framework.XRadioButton();
            this.rbxJapan = new IHIS.Framework.XRadioButton();
            this.rboKorea = new IHIS.Framework.XRadioButton();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.xButton1 = new IHIS.Framework.XButton();
            this.cbxKo = new System.Windows.Forms.CheckBox();
            this.btnLoad = new IHIS.Framework.XButton();
            this.btnExport = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnGetList = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.gbxMsgGubun.SuspendLayout();
            this.gbxLangGubun.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // grdList
            // 
            this.grdList.ApplyAutoInsertion = true;
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdList.ColPerLine = 4;
            this.grdList.ColResizable = true;
            this.grdList.Cols = 5;
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(26);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellName = "pk";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "msg_gubun";
            this.xEditGridCell2.CellWidth = 101;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.DictColumn = "MSG_GUBUN";
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.InitValue = "F";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoInsertAtEnterKey = true;
            this.xEditGridCell3.CellLen = 250;
            this.xEditGridCell3.CellName = "korea_msg";
            this.xEditGridCell3.CellWidth = 241;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 250;
            this.xEditGridCell4.CellName = "japan_msg";
            this.xEditGridCell4.CellWidth = 251;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AutoInsertAtEnterKey = true;
            this.xEditGridCell5.CellLen = 250;
            this.xEditGridCell5.CellName = "speak_msg";
            this.xEditGridCell5.CellWidth = 305;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // gbxMsgGubun
            // 
            this.gbxMsgGubun.Controls.Add(this.rbxMessage);
            this.gbxMsgGubun.Controls.Add(this.rbxField);
            resources.ApplyResources(this.gbxMsgGubun, "gbxMsgGubun");
            this.gbxMsgGubun.Name = "gbxMsgGubun";
            this.gbxMsgGubun.TabStop = false;
            // 
            // rbxMessage
            // 
            resources.ApplyResources(this.rbxMessage, "rbxMessage");
            this.rbxMessage.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxMessage.CheckedValue = "M";
            this.rbxMessage.Name = "rbxMessage";
            this.rbxMessage.UseVisualStyleBackColor = false;
            this.rbxMessage.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxField
            // 
            resources.ApplyResources(this.rbxField, "rbxField");
            this.rbxField.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PaleTurquoise);
            this.rbxField.Checked = true;
            this.rbxField.CheckedValue = "F";
            this.rbxField.Name = "rbxField";
            this.rbxField.TabStop = true;
            this.rbxField.UseVisualStyleBackColor = false;
            this.rbxField.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // gbxLangGubun
            // 
            this.gbxLangGubun.Controls.Add(this.rbxSpeak);
            this.gbxLangGubun.Controls.Add(this.rbxJapan);
            this.gbxLangGubun.Controls.Add(this.rboKorea);
            resources.ApplyResources(this.gbxLangGubun, "gbxLangGubun");
            this.gbxLangGubun.Name = "gbxLangGubun";
            this.gbxLangGubun.TabStop = false;
            // 
            // rbxSpeak
            // 
            resources.ApplyResources(this.rbxSpeak, "rbxSpeak");
            this.rbxSpeak.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxSpeak.CheckedValue = "S";
            this.rbxSpeak.Name = "rbxSpeak";
            this.rbxSpeak.UseVisualStyleBackColor = false;
            this.rbxSpeak.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rbxJapan
            // 
            resources.ApplyResources(this.rbxJapan, "rbxJapan");
            this.rbxJapan.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181))))));
            this.rbxJapan.CheckedValue = "J";
            this.rbxJapan.Name = "rbxJapan";
            this.rbxJapan.UseVisualStyleBackColor = false;
            this.rbxJapan.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // rboKorea
            // 
            resources.ApplyResources(this.rboKorea, "rboKorea");
            this.rboKorea.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.PaleTurquoise);
            this.rboKorea.Checked = true;
            this.rboKorea.CheckedValue = "K";
            this.rboKorea.Name = "rboKorea";
            this.rboKorea.TabStop = true;
            this.rboKorea.UseVisualStyleBackColor = false;
            this.rboKorea.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButton1);
            this.pnlBottom.Controls.Add(this.cbxKo);
            this.pnlBottom.Controls.Add(this.btnLoad);
            this.pnlBottom.Controls.Add(this.btnExport);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.btnGetList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // xButton1
            // 
            resources.ApplyResources(this.xButton1, "xButton1");
            this.xButton1.Name = "xButton1";
            this.xButton1.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // cbxKo
            // 
            resources.ApplyResources(this.cbxKo, "cbxKo");
            this.cbxKo.Name = "cbxKo";
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnGetList
            // 
            resources.ApplyResources(this.btnGetList, "btnGetList");
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // ADM501U
            // 
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gbxMsgGubun);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.gbxLangGubun);
            this.Name = "ADM501U";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.gbxMsgGubun.ResumeLayout(false);
            this.gbxLangGubun.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
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
                    if (this.rboKorea.Checked) //한국어로 조회
                    {
                        /*this.grdList.QuerySQL
                            = "SELECT ADM0002_PK, MSG_GUBUN, KOREA_MSG, JAPAN_MSG, SPEAK_MSG FROM ADM0002"
                            + " WHERE MSG_GUBUN = :f_msg_gubun"
                            + "   AND KOREA_MSG LIKE '%'||:f_search_msg||'%'"
                            + " ORDER BY ADM0002_PK ASC";*/
                        this.grdList.ExecuteQuery = LoadKoreaList;

                    }
                    else if (this.rbxJapan.Checked) //일본어로 조회
                    {
                        /*this.grdList.QuerySQL
                            = "SELECT ADM0002_PK, MSG_GUBUN, KOREA_MSG, JAPAN_MSG, SPEAK_MSG FROM ADM0002"
                            + " WHERE MSG_GUBUN = :f_msg_gubun"
                            + "   AND JAPAN_MSG LIKE '%'||:f_search_msg||'%'"
                            + " ORDER BY ADM0002_PK ASC";*/
                        this.grdList.ExecuteQuery = LoadJapanList;
                    }
                    else  //일본어 읽기로 조회
                    {
                        /*this.grdList.QuerySQL
                            = "SELECT ADM0002_PK, MSG_GUBUN, KOREA_MSG, JAPAN_MSG, SPEAK_MSG FROM ADM0002"
                            + " WHERE MSG_GUBUN = :f_msg_gubun"
                            + "   AND SPEAK_MSG LIKE '%'||:f_search_msg||'%'"
                            + " ORDER BY ADM0002_PK ASC";*/
                        this.grdList.ExecuteQuery = LoadSpeakList;
                    }

                    //BIND 변수 SET (f_msg_gubun, f_search_msg)
                    grdList.SetBindVarValue("f_msg_gubun", this.gbxMsgGubun.GetDataValue());  //M.Msg, F.Field
                    grdList.SetBindVarValue("f_search_msg", this.txtSearch.GetDataValue());  //검색어
                    //QueryLayout (전체Display)
                    grdList.QueryLayout(true);
                    break;
                case FunctionType.Reset:  //Reset 처리 (리스트만 Clear함, 다른 Control을 Clear하지 않음)
                    this.grdList.Reset();
                    e.IsBaseCall = false;
                    this.txtSearch.Focus();
                    break;
                case FunctionType.Insert:  //Insert시에 MSG_GUBUN값 SET
                    int rowNumber = this.grdList.InsertRow();
                    //기본 MSG_GUBUN SET
                    string gubun = (this.rbxField.Checked ? "F" : "M");
                    this.grdList.SetItemValue(rowNumber, "msg_gubun", gubun);
                    e.IsBaseCall = false;
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    ADM501USaveLayoutArgs args = new ADM501USaveLayoutArgs();
                    args.UserInfo = "";
                    args.ListItemInfo = GetGrdListForSaveLayout();
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADM501USaveLayoutArgs>(args);
                    break;
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Enter Key입력시 Text가 있으면 조회 처리함
            if (e.KeyData == Keys.Enter)
                this.btnList.PerformClick(FunctionType.Query);
        }

        //한국어만 등록된 내역 조회
        private void btnGetList_Click(object sender, System.EventArgs e)
        {
            //Grid Reset
            this.grdList.Reset();

            //GRID의 QuerySQL SET (일본어가 등록안된 내역 조회)
            /*this.grdList.QuerySQL
                = "SELECT ADM0002_PK, MSG_GUBUN, KOREA_MSG, JAPAN_MSG, SPEAK_MSG FROM ADM0002"
                + " WHERE MSG_GUBUN = :f_msg_gubun"
                + "   AND JAPAN_MSG IS NULL"
                + " ORDER BY ADM0002_PK ASC";*/
            grdList.ExecuteQuery = LoadJapanEmptyList;

            //BIND 변수 SET
            grdList.SetBindVarValue("f_msg_gubun", this.gbxMsgGubun.GetDataValue());

            //전체조회
            this.grdList.QueryLayout(true);
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            //grdList Export
            if (grdList.RowCount > 0)
                grdList.Export();
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
                        //MSG_GUBUN + KOREA_MSG
                        string[] fDatas = line.Split('\t');
                        if (fDatas.Length >= 2)
                        {
                            //맨 마지막에 Add
                            int rowNum = grdList.InsertRow(-1);
                            //Data SET
                            grdList.SetItemValue(rowNum, "msg_gubun", fDatas[0]);
                            grdList.SetItemValue(rowNum, "korea_msg", fDatas[1]);
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
            private ADM501U parent = null;
            public XSavePerformer(ADM501U parent)
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
                            = "INSERT INTO ADM0002 (ADM0002_PK, MSG_GUBUN, KOREA_MSG, JAPAN_MSG, SPEAK_MSG) "
                            + " VALUES(ADM0002_SEQ.NEXTVAL, :f_msg_gubun, :f_korea_msg, :f_japan_msg, :f_speak_msg)";
                        break;
                    case DataRowState.Modified:
                        cmdText
                            = "UPDATE ADM0002"
                            + "   SET MSG_GUBUN  = :f_msg_gubun"
                            + "      ,KOREA_MSG  = :f_korea_msg"
                            + "      ,JAPAN_MSG  = :f_japan_msg"
                            + "      ,SPEAK_MSG  = :f_speak_msg"
                            + " WHERE ADM0002_PK = :f_pk";
                        break;
                    case DataRowState.Deleted:
                        cmdText
                            = "DELETE ADM0002"
                            + " WHERE ADM0002_PK = :f_pk";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region cloud services
        private List<string> CreateGrdListParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_msg_gubun");
            paramList.Add("f_search_msg");
            return paramList;
        }

        private List<object[]> LoadKoreaList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM501UKoreaListArgs args = new ADM501UKoreaListArgs();
            args.MsgGubun = bc["f_msg_gubun"] != null ? bc["f_msg_gubun"].VarValue : "";
            args.SearchMsg = bc["f_search_msg"] != null ? bc["f_search_msg"].VarValue : "";
            ADM501UListResult result = CloudService.Instance.Submit<ADM501UListResult, ADM501UKoreaListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM501UListItemInfo item in result.ListItemInfo)
                {
                    object[] objects = 
				    { 
					    item.Adm0002Pk, 
					    item.MsgGubun, 
					    item.KoreaMsg, 
					    item.JapanMsg, 
					    item.SpeakMsg
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadJapanList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM501UJapanListArgs args = new ADM501UJapanListArgs();
            args.MsgGubun = bc["f_msg_gubun"] != null ? bc["f_msg_gubun"].VarValue : "";
            args.SearchMsg = bc["f_search_msg"] != null ? bc["f_search_msg"].VarValue : "";
            ADM501UListResult result = CloudService.Instance.Submit<ADM501UListResult, ADM501UJapanListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM501UListItemInfo item in result.ListItemInfo)
                {
                    object[] objects = 
				    { 
					    item.Adm0002Pk, 
					    item.MsgGubun, 
					    item.KoreaMsg, 
					    item.JapanMsg, 
					    item.SpeakMsg
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadSpeakList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM501USpeakListArgs args = new ADM501USpeakListArgs();
            args.MsgGubun = bc["f_msg_gubun"] != null ? bc["f_msg_gubun"].VarValue : "";
            args.SearchMsg = bc["f_search_msg"] != null ? bc["f_search_msg"].VarValue : "";
            ADM501UListResult result = CloudService.Instance.Submit<ADM501UListResult, ADM501USpeakListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM501UListItemInfo item in result.ListItemInfo)
                {
                    object[] objects = 
				    { 
					    item.Adm0002Pk, 
					    item.MsgGubun, 
					    item.KoreaMsg, 
					    item.JapanMsg, 
					    item.SpeakMsg
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadJapanEmptyList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM501UJapanEmptyListArgs args = new ADM501UJapanEmptyListArgs();
            args.MsgGubun = bc["f_msg_gubun"] != null ? bc["f_msg_gubun"].VarValue : "";
            ADM501UListResult result = CloudService.Instance.Submit<ADM501UListResult, ADM501UJapanEmptyListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM501UListItemInfo item in result.ListItemInfo)
                {
                    object[] objects = 
				    { 
					    item.Adm0002Pk, 
					    item.MsgGubun, 
					    item.KoreaMsg, 
					    item.JapanMsg, 
					    item.SpeakMsg
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<ADM501UListItemInfo> GetGrdListForSaveLayout()
        {
            List<ADM501UListItemInfo> lstResult = new List<ADM501UListItemInfo>();

            for (int i = 0; i < grdList.RowCount; i++)
            {
                if (grdList.GetRowState(i) == DataRowState.Unchanged) continue;
                ADM501UListItemInfo item = new ADM501UListItemInfo();
                item.Adm0002Pk = grdList.GetItemString(i, "pk");
                item.MsgGubun = grdList.GetItemString(i, "msg_gubun");
                item.KoreaMsg = grdList.GetItemString(i, "korea_msg");
                item.JapanMsg = grdList.GetItemString(i, "japan_msg");
                item.SpeakMsg = grdList.GetItemString(i, "speak_msg");

                item.DataRowState = grdList.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdList.DeletedRowTable && null != grdList.DeletedRowTable.Rows)
            {
                foreach (DataRow dr in grdList.DeletedRowTable.Rows)
                {
                    ADM501UListItemInfo item = new ADM501UListItemInfo();
                    item.Adm0002Pk = Convert.ToString(dr["pk"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }
        #endregion
    }
}

