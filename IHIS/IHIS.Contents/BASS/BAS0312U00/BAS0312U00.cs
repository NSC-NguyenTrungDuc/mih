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
	/// BAS0312U00에 대한 요약 설명입니다.
	/// </summary>
    [ToolboxItem(false)]
    public class BAS0312U00 : IHIS.Framework.XScreen
    {
        #region 사용자 변수
        string msgCode = string.Empty;
        string msg_ymd = string.Empty;
        string msgCodeName = string.Empty;
        string mbxMsg = string.Empty;
        string mbxCap = string.Empty;

        #endregion
        private XEditGrid grdList;
        private XEditGrid grdGrpSG;
        private XEditGridCell xEditGridCell1;
        private XButtonList xButtonList1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private MultiLayout laySub_Code;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayout layGroup;
        private XEditGridCell xEditGridCell13;
        private SingleLayout layComm;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private XButton btnCopy;
        private XPanel xPanel1;
        private XPanel xPanel3;
        private XLabel xLabel1;
        private XDisplayBox dbxCode_Name;
        private XLabel xLabel2;
        private XDisplayBox dbxCode;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public BAS0312U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0312U00));
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.grdGrpSG = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.laySub_Code = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layGroup = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.layComm = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.btnCopy = new IHIS.Framework.XButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxCode_Name = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxCode = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrpSG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySub_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroup)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell13});
            this.grdList.ColPerLine = 1;
            this.grdList.Cols = 1;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(27);
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = " SELECT DISTINCT\r\n        A.SG_YMD\r\n       ,A.SG_CODE\r\n  FROM BAS0312 A\r\n WHERE A" +
                ".HOSP_CODE  = :f_hosp_code\r\n   AND A.SG_CODE    = :f_sg_code\r\n ORDER BY SG_YMD";
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(107, 461);
            this.grdList.TabIndex = 1;
            this.grdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdList_GridColumnChanged);
            this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "sg_ymd";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 105;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderText = "適用日付";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sg_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "수가코드";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // grdGrpSG
            // 
            this.grdGrpSG.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11});
            this.grdGrpSG.ColPerLine = 5;
            this.grdGrpSG.Cols = 5;
            this.grdGrpSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGrpSG.FixedRows = 1;
            this.grdGrpSG.HeaderHeights.Add(27);
            this.grdGrpSG.Location = new System.Drawing.Point(107, 0);
            this.grdGrpSG.Name = "grdGrpSG";
            this.grdGrpSG.Rows = 2;
            this.grdGrpSG.Size = new System.Drawing.Size(557, 461);
            this.grdGrpSG.TabIndex = 2;
            this.grdGrpSG.ToolTipActive = true;
            this.grdGrpSG.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdGrpSG_GridColumnChanged);
            this.grdGrpSG.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdGrpSG_GridFindClick);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "sg_ymd";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 105;
            this.xEditGridCell2.HeaderText = "適用日付";
            this.xEditGridCell2.IsJapanYearType = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "seq";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 30;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderText = "SEQ";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sub_sg_code";
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell4.HeaderText = "副点数コード";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "sg_name";
            this.xEditGridCell5.CellWidth = 250;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.HeaderText = "副点数名";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "from_month";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 50;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "FROM";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "to_month";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell7.CellWidth = 45;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "TO";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "suryang";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell8.CellWidth = 55;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.HeaderText = "数量";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "car_suryang";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell9.CellWidth = 55;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "自賠\r\n数量";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "sg_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "수가코드";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "old_seq";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "old_seq";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "old_seq";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "old_seq";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Location = new System.Drawing.Point(181, 496);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(487, 34);
            this.xButtonList1.TabIndex = 1;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // laySub_Code
            // 
            this.laySub_Code.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sub_sg_code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sg_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "from_month";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "to_month";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "suryang";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "car_suryang";
            // 
            // layGroup
            // 
            this.layGroup.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16});
            this.layGroup.QuerySQL = resources.GetString("layGroup.QuerySQL");
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "sg_ymd";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "seq";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "sub_sg_code";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "sg_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "from_month";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "to_month";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "suryang";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "car_suryang";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "sg_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "old_seq";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // layComm
            // 
            this.layComm.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "sg_code";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "sg_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "sg_ymd";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(9, 503);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "コピー";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dbxCode_Name);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dbxCode);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(664, 30);
            this.xPanel1.TabIndex = 4;
            // 
            // dbxCode_Name
            // 
            this.dbxCode_Name.Location = new System.Drawing.Point(309, 3);
            this.dbxCode_Name.Name = "dbxCode_Name";
            this.dbxCode_Name.Size = new System.Drawing.Size(343, 21);
            this.dbxCode_Name.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(219, 3);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(90, 21);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "点数名（漢字）";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxCode
            // 
            this.dbxCode.Location = new System.Drawing.Point(97, 3);
            this.dbxCode.Name = "dbxCode";
            this.dbxCode.Size = new System.Drawing.Size(111, 21);
            this.dbxCode.TabIndex = 1;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(7, 3);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(90, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "点数コード";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdGrpSG);
            this.xPanel3.Controls.Add(this.grdList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(5, 35);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(664, 461);
            this.xPanel3.TabIndex = 6;
            // 
            // BAS0312U00
            // 
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0312U00";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 40);
            this.Size = new System.Drawing.Size(674, 536);
            this.Load += new System.EventHandler(this.BAS0312U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrpSG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySub_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroup)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Form Load
        private void BAS0312U00_Load(object sender, System.EventArgs e)
        {
            this.grdGrpSG.SavePerformer = new XSavePeformer(this);
            if (this.OpenParam != null)
            {
                msgCode = this.OpenParam["sg_code"].ToString();
                msgCodeName = this.OpenParam["sg_code_name"].ToString();
                this.dbxCode.SetDataValue(msgCode);
                this.dbxCode_Name.SetDataValue(msgCodeName);
                //적용일자일랍참조
                grdList_Query();
            }		
        }
        //적용일자일랍참조
        private void grdList_Query()
        {
            this.dbxCode.SetDataValue(msgCode);
            this.dbxCode_Name.SetDataValue(msgCodeName);
            //병원코드
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //점수코드
            this.grdList.SetBindVarValue("f_sg_code", msgCode);
            //점수코드참조
            this.grdList.QueryLayout(false);
        }
        bool flgchrck = true;

        private void grdList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (flgchrck == false)
            {
                flgchrck = true;
                return;
            }
            if (check_grid(this.grdGrpSG) == false)
            {
                string mMsg = (NetInfo.Language == LangMode.Ko ? "갱신중인 데이터는 삭제됩니다. 저장하시겠습니까?"
                               : "更新中のデータは削除されます。保存しますか？");
                string mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                if (MessageBox.Show(mMsg, mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (check_grdGrpSG() == true)
                    {
                        GroupSuga_Save();
                    }
                    else
                    {
                        flgchrck = false;
                        grdList.SetFocusToItem(e.PreviousRow, "sg_ymd");
                    }
                    return;
                }
                else
                {
                    grdList.DeleteRow(e.PreviousRow);
                }
            }
            //부점수코드일람참조
            GroupSuga_Query();
        }

        #region xButtonList1_ButtonClick
        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdList_Query();
                    GroupSuga_Query();
                    break;
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    GroupSuga_Insert();
                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    GroupSuga_Delete();
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    GroupSuga_Save();
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region 입력
        private void GroupSuga_Insert()
        {
            int cnt = 0;

            if (check_grid(this.CurrMQLayout) == true)
            {
                if (this.CurrMQLayout == grdList)
                {
                    cnt = this.grdList.InsertRow(grdList.CurrentRowNumber);
                    this.grdList.SetFocusToItem(cnt, "sg_ymd", true);
                    this.grdList.SetEditorValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                    //this.grdList.AcceptData();
                }
                else
                {
                    cnt = this.grdGrpSG.InsertRow(grdGrpSG.CurrentRowNumber);
                    this.grdGrpSG.SetItemValue(cnt, "sg_ymd", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "sg_ymd"));
                    this.grdGrpSG.SetItemValue(cnt, "sg_code", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "sg_code"));
                    this.grdGrpSG.SetItemValue(cnt, "from_month", 0);
                    this.grdGrpSG.SetItemValue(cnt, "to_month", 99999);
                    this.grdGrpSG.SetItemValue(cnt, "suryang", "1");
                    this.grdGrpSG.SetItemValue(cnt, "car_suryang", "1");
                    //this.grdGrpSG.AcceptData();
                }
            }
        }
        #endregion
        #region 삭제
        private void GroupSuga_Delete()
        {
            if (this.CurrMQLayout == grdList)
            {
                if (grdList.RowCount <= 0) return;
                if (grdList.CurrentRowNumber < 0) return;
                if (grdGrpSG.RowCount > 0)
                {
                    string mMsg = NetInfo.Language == LangMode.Jr ?  "副点数コードがあります。": "부점수코드가 존재합니다.";
                    string mCap = NetInfo.Language == LangMode.Jr ?  "確認" : "확인";
                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                grdList.DeleteRow(grdList.CurrentRowNumber);
                grdList_Query();
            }
            else
            {
                if (grdGrpSG.RowCount <= 0) return;
                if (grdGrpSG.CurrentRowNumber < 0) return;
                grdGrpSG.DeleteRow(grdGrpSG.CurrentRowNumber);
            }
        }
        #endregion

        private void GroupSuga_Query()
        {
            grdGrpSG.Reset();
            if (this.grdList.RowCount <= 0) return;

            this.layGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGroup.SetBindVarValue("f_sg_code", msgCode);
            this.layGroup.SetBindVarValue("f_sg_ymd", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "sg_ymd"));

            if (!layGroup.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }
            DataRow dtRow = null;

            foreach (DataRow dr in layGroup.LayoutTable.Rows)
            {
                dtRow = grdGrpSG.LayoutTable.NewRow();
                dtRow["sg_ymd"] = dr["sg_ymd"].ToString();
                dtRow["seq"] = dr["seq"].ToString();
                dtRow["sg_name"] = dr["sg_name"].ToString();
                dtRow["sub_sg_code"] = dr["sub_sg_code"].ToString();
                dtRow["from_month"] = dr["from_month"].ToString();
                dtRow["to_month"] = dr["to_month"].ToString();
                dtRow["suryang"] = dr["suryang"].ToString();
                dtRow["car_suryang"] = dr["car_suryang"].ToString();
                dtRow["sg_code"] = dr["sg_code"].ToString();
                dtRow["old_seq"] = dr["old_seq"].ToString();
                grdGrpSG.LayoutTable.Rows.Add(dtRow);
            }
            grdGrpSG.ResetUpdate();
            grdGrpSG.DisplayData();
        }
        #region 저장
        private void GroupSuga_Save()
        {
            string mMsg = "";
            string mCap = "";

            if (check_grdGrpSG() == false)
                return;

            if (this.grdGrpSG.SaveLayout())
            {
                mMsg = NetInfo.Language == LangMode.Jr ?  "保存が完了しました。": "저장이 완료되었습니다.";
                mCap = NetInfo.Language == LangMode.Jr ?  "保存完了" : "저장완료";
                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장에 실패 하였습니다.";
                mMsg += "\r\n" + Service.ErrFullMsg;
                mCap = NetInfo.Language == LangMode.Jr ? "保存失敗" : "저장실패";

                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GroupSuga_Query();
            grdList_Query();
        }
        #endregion
        private void grdGrpSG_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            this.layComm.Reset();
            mbxMsg = "";
            mbxCap = "";
            switch(e.ColName)
            {
                case "sub_sg_code":
                    if (TypeCheck.IsNull(e.ChangeValue.ToString()) == true)
                    {
                        e.Cancel = false;
                        return;
                    }
                    if (QueryLaySubCode(e.ChangeValue.ToString(), e.DataRow["sg_ymd"].ToString(), e.RowNumber) == false)
                    {
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                        return;
                    }
                    this.grdGrpSG.SetItemValue(this.grdGrpSG.CurrentRowNumber, "sg_name", layComm.GetItemValue("sg_name").ToString());
                    break;
            }

        }
        //부점수코드 체크 
        private bool QueryLaySubCode(string aSGCode, string mSgYmd, int aRowNum)
        {
            object t_check = null;
            string cmdText = "";

            BindVarCollection bc = new BindVarCollection();

            cmdText = @"SELECT DISTINCT 'Y'
                                  FROM BAS0312 A
                                     , BAS0310 B
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND B.HOSP_CODE = A.HOSP_CODE 
                                   AND A.SG_CODE    = B.SG_CODE
                                   AND B.GROUP_GUBUN = 'Y'
                                   AND A.SG_CODE     = :f_sub_sg_code
                                   AND A.SG_YMD = (SELECT MAX(SG_YMD)
                                                     FROM BAS0312 Z 
                                                    WHERE Z.HOSP_CODE = A.HOSP_CODE 
                                                      AND Z.SG_CODE = A.SG_CODE
                                                      AND Z.SUB_SG_CODE = A.SUB_SG_CODE
                                                      AND Z.FROM_MONTH  = A.FROM_MONTH
                                                      AND Z.SEQ         = A.SEQ
                                                      AND Z.SG_YMD       <= :f_sg_ymd )
                                   AND ROWNUM = 1";
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_sub_sg_code", aSGCode);
            bc.Add("f_sg_ymd", mSgYmd);
            t_check = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(t_check))
            {
                /* 그룹내용이 있으면 그룹내용을 가져온다 */
                if (t_check.ToString() == "Y")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "グループコードは入力できません。確認してください。"
                        : "그룹코드는 입력할수 없습니다. 확인바랍니다.";
                    return false;
                }
            
            }
            cmdText = @"SELECT 'Y'
                          FROM BAS0312 A
                        WHERE A.HOSP_CODE    = :f_hosp_code
                           AND A.SG_CODE     = :f_sg_code
                           AND A.SUB_SG_CODE = :f_sub_sg_code
                           AND A.SG_YMD      = :f_sg_ymd ";
            bc.Add("f_sg_code", msgCode);
            t_check = Service.ExecuteScalar(cmdText, bc);
            if (!TypeCheck.IsNull(t_check))
            {
                /* 부점수코드가 있는경우 */
                if (t_check.ToString() == "Y")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "すでに登録されています。確認してください。"
                        : "이미등록되어있는 부코드입니다.확인바랍니다.";
                    return false;
                }
            }
            /* 그룹코드가 없으면 명칭만 가져온다*/
            cmdText = @"SELECT DISTINCT
                               A.SG_CODE
                             , A.SG_NAME
                             , A.SG_YMD
                             , '0'        FROM_MONTH
                             , '999'      TO_MONTH
                             , '1'        SURYANG
                             , '1'        CAR_SURYANG
                          FROM BAS0310 A
                         WHERE A.HOSP_CODE   = :f_hosp_code
                           AND A.SG_CODE     = :f_sub_sg_code
                           AND A.SG_YMD      = (SELECT MAX(Z.SG_YMD)
                                                  FROM BAS0310 Z 
                                                WHERE A.SG_CODE = Z.SG_CODE  
                                                AND TO_DATE(:f_sg_ymd, 'YYYY/MM/DD') 
                                                BETWEEN Z.SG_YMD AND NVl(Z.BULYONG_YMD, '9998/12/31'))";
            this.layComm.QuerySQL = cmdText;
            this.layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComm.SetBindVarValue("f_sub_sg_code", aSGCode);
            this.layComm.SetBindVarValue("f_sg_ymd", grdGrpSG.GetItemString(aRowNum, "sg_ymd").ToString());

            if (!this.layComm.QueryLayout())
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "副点数コードが正確ではありません。確認してください。"
                    : "부점수코드가 정확하지않습니다. 확인바랍니다.";
                return false;
            }
            return true;
        }

        #region Col Find
        private void grdGrpSG_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            //wkComm.Reset();
            switch (e.ColName)
            {
                case "sub_sg_code":
                    CommonItemCollection param = new CommonItemCollection();
                    param.Add("sg_ymd", grdGrpSG.GetItemString(e.RowNumber, "sg_ymd"));
                    param.Add("search_word", grdGrpSG.GetItemString(e.RowNumber, "sub_sg_code"));
                    XScreen.OpenScreenWithParam(this, "BASS", "BAS0311Q01", ScreenOpenStyle.ResponseFixed, param);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Command
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "BAS0311Q01":
                    this.ApplyPointToGrid(this.grdGrpSG, (MultiLayout)(commandParam["BAS0311"]));
                    break;
            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region 점수코드 적용 (command에서 호출)
        private void ApplyPointToGrid(XEditGrid aDestGrid, MultiLayout aLayout)
        {
            for (int i = 0; i < aLayout.RowCount; i++)
            {
                aDestGrid.SetItemValue(aDestGrid.CurrentRowNumber, "sub_sg_code", aLayout.GetItemString(i, "sg_code"));
                if (!aDestGrid.AcceptData())
                {
                    return;
                }
                if (QueryLaySubCode(aDestGrid.GetItemValue(aDestGrid.CurrentRowNumber, "sub_sg_code").ToString(), 
                                    aDestGrid.GetItemValue(aDestGrid.CurrentRowNumber, "sg_ymd").ToString(), aDestGrid.CurrentRowNumber) == false)
                {
                    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    return;
                }
                aDestGrid.SetItemValue(aDestGrid.CurrentRowNumber, "sg_name", aLayout.GetItemString(i, "sg_name"));
            }
        }
        #endregion

        private void grdList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            bool isFind = false;
            if (e.ChangeValue.ToString() != "")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    if (i != e.RowNumber)
                    {
                        if (e.ChangeValue.ToString() == grid.GetItemString(i, "sg_ymd"))
                        {
                            isFind = true;
                            break;
                        }
                    }
                }
                if (isFind) 
                {
                    string mMsg = NetInfo.Language == LangMode.Jr ? "すでに登録されています。確認お願いします。" :
                                  "이미등록되어있습니다. 확인바랍니다.";
                    string mCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                    MessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        #region 복사 버튼 클릭
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (check_grid(this.grdList) == false)
            {
                return;
            }
            MultiLayout tempLayout = this.grdGrpSG.CloneToLayout();
            
            foreach (DataRow dr in this.grdGrpSG.LayoutTable.Rows)
            {
                tempLayout.LayoutTable.ImportRow(dr);
            }
            int rowno = grdList.InsertRow();

            this.grdList.SetFocusToItem(rowno, "sg_ymd", true);
            this.grdList.SetEditorValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            
            if (this.grdList.AcceptData() == false)
                return;
            
            foreach(DataRow dr in tempLayout.LayoutTable.Rows)
            {
                int newRow;
                newRow = this.grdGrpSG.InsertRow();
                foreach(DataColumn cl in this.grdGrpSG.LayoutTable.Columns)
                {
                    if (cl.ColumnName == "sg_ymd")
                    {
                        this.grdGrpSG.SetItemValue(newRow, cl.ColumnName, grdList.GetItemString(rowno, "sg_ymd"));
                    }
                    else
                    {
                        this.grdGrpSG.SetItemValue(newRow, cl.ColumnName, dr[cl.ColumnName].ToString());
                    }
                }
            }
            mbxMsg = NetInfo.Language == LangMode.Jr ? "前の資料を新たな資料にコピーしました。修正してから保存してください。"
                : "전 자료를 새로운 자료로 복사하였습니다. 수정후 저장하십시오";
            mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
            XMessageBox.Show(mbxMsg, mbxCap);
        }
        #endregion

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0312U00 parent = null;

            public XSavePeformer(BAS0312U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                switch (callerId)
                {
                    case '1':
                        item.BindVarList.Add("q_user_id", UserInfo.UserID);
                        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.BindVarList.Add("f_sg_code", this.parent.msgCode);
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (item.BindVarList["f_sub_sg_code"].VarValue == "")
                                {
                                    XMessageBox.Show("点数コードを入力してください｡", "注意", MessageBoxIcon.Error);
                                    return false;
                                }
                                cmdText = @"SELECT DISTINCT NVL(MAX(A.SEQ), 0)+1 SEQ
                                              FROM BAS0312 A
                                             WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND A.SG_CODE     = :f_sg_code
                                               AND A.SG_YMD      = :f_sg_ymd";
                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                item.BindVarList.Add("f_seq", t_chk.ToString());

                                cmdText = @"INSERT INTO BAS0312
                                                ( SYS_DATE,         SYS_ID,         UPD_DATE,       UPD_ID,         
                                                  HOSP_CODE,        SG_CODE,        SG_YMD,         SUB_GUBUN,      
                                                  SUB_SG_CODE,      SURYANG,        CAR_SURYANG,    FROM_MONTH,     
                                                  TO_MONTH,       SEQ)
                                           VALUES
                                                ( SYSDATE,          :q_user_id,     SYSDATE,        :q_user_id,     
                                                  :f_hosp_code,     :f_sg_code,     :f_sg_ymd,      :f_sub_gubun,            
                                                  :f_sub_sg_code,   :f_suryang,     :f_car_suryang, :f_from_month, 
                                                  :f_to_month,    :f_seq)";
                                item.BindVarList.Add("f_sub_gubun", "A");
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE BAS0312
                                              SET UPD_ID                  = :q_user_id
                                                , UPD_DATE                = SYSDATE
                                                , SG_YMD                  = :f_sg_ymd
                                                , SURYANG                 = :f_suryang
                                                , CAR_SURYANG             = :f_car_suryang
                                                , FROM_MONTH              = :f_from_month
                                                , TO_MONTH                = :f_to_month 
                                                , SEQ                     = :f_seq
                                            WHERE HOSP_CODE               = :f_hosp_code
                                              AND SG_CODE                 = :f_sg_code
                                              AND SG_YMD                  = :f_sg_ymd
                                              AND SUB_SG_CODE             = :f_sub_sg_code
                                              AND FROM_MONTH              = :f_from_month
                                              AND SEQ                     = :f_old_seq ";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM BAS0312
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND SG_CODE      = :f_sg_code
                                               AND SG_YMD       = :f_sg_ymd
                                               AND SUB_SG_CODE  = :f_sub_sg_code
                                               AND FROM_MONTH   = :f_from_month
                                               AND SEQ          = :f_old_seq ";

                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region grid 체크
        private bool check_grid(IMultiQueryLayout Layout)
        {
            if (Layout == grdList)
            {
                for (int i = 0; i < grdList.RowCount; i++)
                {
                    if (grdList.GetRowState(i) == DataRowState.Added)
                    {
                        return false;
                    }
                }
            } 
            else 
            {
                for (int i = 0; i < grdGrpSG.RowCount; i++)
                {
                    if (grdGrpSG.GetRowState(i) == DataRowState.Added)
                    {
                        if (this.CurrMQLayout == grdList)
                        {
                            if (grdGrpSG.GetItemString(i, "sub_sg_code") != "")
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (grdGrpSG.GetItemString(i, "sub_sg_code") == "")
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion


        private bool check_grdGrpSG()
        {
            for (int i = 0; i < grdGrpSG.RowCount; i++)
            {
                if (grdGrpSG.GetRowState(i) == DataRowState.Added || grdGrpSG.GetRowState(i) == DataRowState.Modified)
                {
                    if (TypeCheck.IsNull(grdGrpSG.GetItemValue(i, "sub_sg_code").ToString()) == true)
                    {
                        string mMsg = (NetInfo.Language == LangMode.Ko ? "부점수코드을 입력하십시오"
                            : "副点数コードを入力してください");
                        string mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";
                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            //}
            return true;
        }
    }

}

