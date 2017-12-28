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

namespace IHIS.NURI
{
    /// <summary>
    /// NUR0104U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR0104U00 : IHIS.Framework.XScreen
    {
        #region 추가사항
        private string sysid = string.Empty;
        private string screen = string.Empty;
        // 팝업화면으로 오픈이 됐을 때 해당 화면이 팝업으로
        // 오픈(flag = "Y")이 된건지 아니면 메뉴에 의해 오픈(flag = "N")이 됐는지
        // 여부를 판단한다.
        // 그리고 팝업으로 오픈 후 데이터 저장을 했을 때 
        // 화면을 오픈시킨 화면에 데이터 변경이 있다는 플래그를 던져주기위해
        // flag = "S"로 바꾼다.
        private string flag = "N";
        private string mHospCode = "";
        #endregion

        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdNUR0104;
        private IHIS.Framework.XLabel lblJukyong_date;
        private IHIS.Framework.XDatePicker dtpJukyong_date;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private MultiLayout layTeamSessionQry;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayout layComboSet;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayout layHo_dongList;
        private XFindWorker fwkHo_codeList;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private XBuseoCombo cboHoDong;
        private XLabel xLabel1;
        private XLabel xLabel2;
        private XDictComboBox cboHoSession;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public NUR0104U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }
        #endregion

        #region 소멸자
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
        #endregion

        #region 디자인 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0104U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboHoSession = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            this.dtpJukyong_date = new IHIS.Framework.XDatePicker();
            this.lblJukyong_date = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNUR0104 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.fwkHo_codeList = new IHIS.Framework.XFindWorker();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.layTeamSessionQry = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.layHo_dongList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTeamSessionQry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHo_dongList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.cboHoSession);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.cboHoDong);
            this.pnlTop.Controls.Add(this.dtpJukyong_date);
            this.pnlTop.Controls.Add(this.lblJukyong_date);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(362, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // cboHoSession
            // 
            this.cboHoSession.Location = new System.Drawing.Point(261, 4);
            this.cboHoSession.Name = "cboHoSession";
            this.cboHoSession.Size = new System.Drawing.Size(94, 21);
            this.cboHoSession.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoSession.TabIndex = 8;
            this.cboHoSession.UserSQL = "SELECT CODE, CODE_NAME \r\n  FROM NUR0102 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_COD" +
                "E()\r\n   AND CODE_TYPE = \'HO_SESSION\'    \r\n ORDER BY SORT_KEY   ";
            this.cboHoSession.SelectionChangeCommitted += new System.EventHandler(this.cboHoSession_SelectionChangeCommitted);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(195, 4);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(66, 21);
            this.xLabel2.TabIndex = 7;
            this.xLabel2.Text = "勤務";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(4, 4);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(66, 21);
            this.xLabel1.TabIndex = 5;
            this.xLabel1.Text = "病棟";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHoDong.Location = new System.Drawing.Point(70, 4);
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(121, 21);
            this.cboHoDong.TabIndex = 4;
            this.cboHoDong.SelectionChangeCommitted += new System.EventHandler(this.cboHoDong_SelectionChangeCommitted);
            // 
            // dtpJukyong_date
            // 
            this.dtpJukyong_date.IsJapanYearType = true;
            this.dtpJukyong_date.Location = new System.Drawing.Point(461, 4);
            this.dtpJukyong_date.Name = "dtpJukyong_date";
            this.dtpJukyong_date.Size = new System.Drawing.Size(112, 20);
            this.dtpJukyong_date.TabIndex = 3;
            this.dtpJukyong_date.Visible = false;
            // 
            // lblJukyong_date
            // 
            this.lblJukyong_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblJukyong_date.EdgeRounding = false;
            this.lblJukyong_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblJukyong_date.Location = new System.Drawing.Point(394, 4);
            this.lblJukyong_date.Name = "lblJukyong_date";
            this.lblJukyong_date.Size = new System.Drawing.Size(66, 20);
            this.lblJukyong_date.TabIndex = 2;
            this.lblJukyong_date.Text = "適用日付";
            this.lblJukyong_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJukyong_date.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 565);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(362, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(35, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(325, 33);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdNUR0104);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Location = new System.Drawing.Point(0, 31);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(362, 534);
            this.pnlFill.TabIndex = 3;
            // 
            // grdNUR0104
            // 
            this.grdNUR0104.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdNUR0104.ColPerLine = 4;
            this.grdNUR0104.Cols = 5;
            this.grdNUR0104.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0104.FixedCols = 1;
            this.grdNUR0104.FixedRows = 1;
            this.grdNUR0104.FocusColumnName = "ho_dong";
            this.grdNUR0104.HeaderHeights.Add(21);
            this.grdNUR0104.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0104.Name = "grdNUR0104";
            this.grdNUR0104.QuerySQL = resources.GetString("grdNUR0104.QuerySQL");
            this.grdNUR0104.RowHeaderVisible = true;
            this.grdNUR0104.Rows = 2;
            this.grdNUR0104.Size = new System.Drawing.Size(360, 532);
            this.grdNUR0104.TabIndex = 0;
            this.grdNUR0104.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0104_GridColumnChanged);
            this.grdNUR0104.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0104_SaveEnd);
            this.grdNUR0104.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNUR0104_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_dong";
            this.xEditGridCell1.CellWidth = 112;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderText = "病棟";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.MaxDropDownItems = 50;
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.UserSQL = resources.GetString("xEditGridCell1.UserSQL");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 4;
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.CellWidth = 70;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.FindWorker = this.fwkHo_codeList;
            this.xEditGridCell2.HeaderText = "病室";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkHo_codeList
            // 
            this.fwkHo_codeList.FormText = "病室";
            this.fwkHo_codeList.InputSQL = resources.GetString("fwkHo_codeList.InputSQL");
            this.fwkHo_codeList.IsSetControlText = true;
            this.fwkHo_codeList.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkHo_codeList.ServerFilter = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "jukyong_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 107;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "適用日付";
            this.xEditGridCell3.IsJapanYearType = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ho_session";
            this.xEditGridCell4.CellWidth = 52;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.HeaderText = "勤務";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.MaxDropDownItems = 50;
            this.xEditGridCell4.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.UserSQL = "SELECT CODE, CODE_NAME \r\n  FROM NUR0102 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_COD" +
                "E()\r\n   AND CODE_TYPE = \'HO_SESSION\'    \r\n ORDER BY SORT_KEY   ";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_team";
            this.xEditGridCell5.CellWidth = 74;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "チーム";
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell5.MaxDropDownItems = 50;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ho_session1";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "SESSION";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layTeamSessionQry
            // 
            this.layTeamSessionQry.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layTeamSessionQry.QuerySQL = resources.GetString("layTeamSessionQry.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "o_team_info";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "o_team_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "o_team_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "o_ho_session_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "o_ho_session_name";
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            this.layComboSet.QuerySQL = "SELECT CODE          CODE,\r\n       CODE_NAME     CODE_NAME,\r\n       SORT_KEY\r\n  F" +
                "ROM NUR0102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = :f_code_type\r\n " +
                "ORDER BY 3, 1";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "code_name";
            // 
            // layHo_dongList
            // 
            this.layHo_dongList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.layHo_dongList.QuerySQL = resources.GetString("layHo_dongList.QuerySQL");
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ho_dong";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "ho_dong_name";
            // 
            // NUR0104U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR0104U00";
            this.Size = new System.Drawing.Size(362, 600);
            this.Load += new System.EventHandler(this.NUR0104U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR0104U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTeamSessionQry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHo_dongList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion


        #region [APL 초기설정 코드]

        #region 화면 로드 이벤트
        private void NUR0104U00_Load(object sender, System.EventArgs e)
        {
            mHospCode = EnvironInfo.HospCode;
            // 적용일자 디폴트 현재일자 설정
            this.dtpJukyong_date.SetEditValue(EnvironInfo.GetSysDate());
            this.dtpJukyong_date.AcceptData();
           
            // 병동 설정
            //this.HodongSetting();
            
            //사용자 구분이 Nurse(간호사)이고, 
            if (UserInfo.UserGubun == UserType.Nurse)
            {
                if (UserInfo.HoDong != "")
                    this.cboHoDong.SetEditValue(UserInfo.HoDong);
                else
                    this.cboHoDong.SetEditValue("1");

            }

            // 콤보박스 설정 
            this.GetCodeName("TEAM");
            this.GetCodeName("HO_SESSION");
            //this.SetHo_dongList();

            this.CurrMSLayout = this.grdNUR0104;
            this.CurrMQLayout = this.grdNUR0104;

            this.grdNUR0104.SavePerformer = new XSavePerformer(this);
            this.SaveLayoutList.Add(this.grdNUR0104);

            this.Nur0104Query();
        }
        #endregion

        #region 화면 오픈 이벤트
        private void NUR0104U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // 팝업화면으로 오픈이 됐을 경우
            if (this.OpenParam != null)
            {
                this.sysid = OpenParam["sysid"].ToString();
                this.screen = OpenParam["screen"].ToString();
                this.flag = this.OpenParam["flag"].ToString();
            }
        }
        #endregion

        #endregion

        #region [메세지 처리 코드]

        /// <summary>
        /// 각종 메세지를 팝업으로 표시한다.
        /// </summary>
        /// <param name="separation">구분</param>
        private void ShowMessage(string separation)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "team_session":
                    msg = "左側でチーム、セッションを選択してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "validation_chk":
                    msg = "既に入力されている情報です。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ho_dong":
                    msg = "病棟を入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ho_code":
                    msg = "病室を入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ho_session":
                    msg = "病棟別セッションを入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ho_team":
                    msg = "病棟別チームを入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "jukyong_date":
                    msg = "適用日付を入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;
                 
                case "ho_codechk":
                    msg = "病室情報が正確ではありません。ご確認ください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "save_true":
                    msg = "保存しました。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "dup_data":
                    msg = "保存に失敗しました。\r\n[既に存在しているデータです。]";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "no_data":
                    msg = "保存に失敗しました。\r\n[該当データがありません。]";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "save_false":
                    msg = String.Format("保存に失敗しました。ご確認ください。\r\n[{0}]", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                case "service_error":
                    msg = String.Format("処理中にエラーが発生しました。\n\n[{0}]", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [입력/저장/닫기/초기화 처리 코드]

        #region 입력/저장/닫기 버튼 처리
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.Nur0104Query();
                    break;

                //case FunctionType.Insert:
                //    if (!this.AcceptData())
                //    {
                //        e.IsBaseCall = false;
                //        e.IsSuccess = false;
                //    }

                //    //if (this.tvwHo_dong.SelectedNode.GetNodeCount(true) != 0)
                //    //{
                //    //    e.IsBaseCall = false;
                //    //    e.IsSuccess = false;
                //    //    this.ShowMessage("team_session");
                //    //    break;
                //    //}
                //    break;

                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    for (int i = 0; i < this.grdNUR0104.RowCount; i++)
                    {
                        DataRowState rowState = this.grdNUR0104.LayoutTable.Rows[i].RowState;

                        if (rowState == DataRowState.Added || rowState == DataRowState.Modified)
                        {
                            if (this.grdNUR0104.GetItemValue(i, "ho_dong").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.ShowMessage("ho_dong");
                                this.grdNUR0104.SetFocusToItem(i, "ho_dong");
                                break;
                            }

                            if (this.grdNUR0104.GetItemValue(i, "ho_code").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.ShowMessage("ho_code");
                                this.grdNUR0104.SetFocusToItem(i, "ho_code");
                                break;
                            }

                            if (this.grdNUR0104.GetItemValue(i, "ho_session").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.ShowMessage("ho_session");
                                this.grdNUR0104.SetFocusToItem(i, "ho_session");
                                break;
                            }

                            if (this.grdNUR0104.GetItemValue(i, "ho_team").ToString() == "")
                            {
                                e.IsBaseCall = false;
                                this.ShowMessage("ho_team");
                                this.grdNUR0104.SetFocusToItem(i, "ho_team");
                                break;
                            }

                            //if (this.grdNUR0104.GetItemValue(i, "jukyong_date").ToString() == "")
                            //{
                            //    e.IsBaseCall = false;
                            //    this.ShowMessage("jukyong_date");
                            //    this.grdNUR0104.SetFocusToItem(i, "jukyong_date");
                            //    break;
                            //}
                        }
                    }
                    break;

                case FunctionType.Close:
                    if (this.flag == "S")
                    {
                        IHIS.Framework.IXScreen aScreen;
                        aScreen = XScreen.FindScreen(sysid, screen);

                        if (aScreen == null)
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("NUR0104U00", "0104");

                            XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                        else
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("NUR0104U00", "0104");
                            this.Close();
                            aScreen.Command("NUR0104U00", openParams);
                        }
                    }
                    break;

                case FunctionType.Reset:

                    break;

                default:
                    break;
            }
        }
        #endregion

        #region 입력/초기화 버튼 클릭 후 처리
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {

                //case FunctionType.Insert:
                //    if (e.IsSuccess == true)
                //    {
                //        if (tvwHo_dong.SelectedNode.GetNodeCount(true) == 0)
                //        {
                //            string[] tag = (string[])tvwHo_dong.SelectedNode.Tag;

                //            if (this.dtpJukyong_date.GetDataValue().ToString() != "")
                //            {
                //                this.grdNUR0104.SetItemValue(this.grdNUR0104.CurrentRowNumber, "jukyong_date", this.dtpJukyong_date.GetDataValue());
                //                this.grdNUR0104.SetItemValue(this.grdNUR0104.CurrentRowNumber, "ho_session", tag[1].ToString());
                //                this.grdNUR0104.SetItemValue(this.grdNUR0104.CurrentRowNumber, "ho_team", tag[0].ToString());
                //                this.grdNUR0104.SetItemValue(this.grdNUR0104.CurrentRowNumber, "ho_session1", tag[1].ToString());
                //            }
                //        }
                //    }
                //    break;

                case FunctionType.Reset:
                    this.dtpJukyong_date.SetEditValue(EnvironInfo.GetSysDate());
                    //사용자 구분이 Nurse(간호사)이고, 
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        if (UserInfo.HoDong != "")
                            this.cboHoDong.SetEditValue(UserInfo.HoDong);
                        else
                            this.cboHoDong.SetEditValue("1");

                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region [팀/ 세션리스트 데이타 취득 및 설정 코드]

        /// <summary>
        /// 팀, 세션리스트 데이타 취득 후 트리뷰에 설정한다.
        /// </summary>
        public void HodongSetting()
        {
            //this.tvwHo_dong.Nodes.Clear();
            //this.layTeamSessionQry.SetBindVarValue("f_hosp_code", this.mHospCode);
            //if (this.layTeamSessionQry.QueryLayout(false))
            //{
            //    if (this.layTeamSessionQry.RowCount > 0)
            //    {
            //        string team_info = string.Empty;
            //        string team_code = string.Empty;

            //        TreeNode tn = null;
            //        TreeNode ctn = null;
            //        TreeNode stn = null;

            //        foreach (DataRow dr in this.layTeamSessionQry.LayoutTable.Rows)
            //        {
            //            if (dr["o_team_info"].ToString() != team_info)
            //            {
            //                tn = new TreeNode(dr["o_team_info"].ToString(), 0, 0);
            //                tn.Tag = dr["o_team_info"].ToString();
            //                this.tvwHo_dong.Nodes.Add(tn);


            //                if (dr["o_team_code"].ToString() != team_code)
            //                {
            //                    ctn = new TreeNode(dr["o_team_name"].ToString());
            //                    ctn.Tag = dr["o_team_code"].ToString();
            //                    tn.Nodes.Add(ctn);

            //                    stn = new TreeNode(dr["o_ho_session_name"].ToString());
            //                    stn.Tag = new string[] { dr["o_team_code"].ToString(), dr["o_ho_session_code"].ToString() };
            //                    ctn.Nodes.Add(stn);
            //                }
            //                else
            //                {
            //                    stn = new TreeNode(dr["o_ho_session_name"].ToString());
            //                    stn.Tag = new string[] { dr["o_team_code"].ToString(), dr["o_ho_session_code"].ToString() };
            //                    ctn.Nodes.Add(stn);

            //                }
            //            }
            //            else
            //            {
            //                if (dr["o_team_code"].ToString() != team_code)
            //                {
            //                    ctn = new TreeNode(dr["o_team_name"].ToString());
            //                    ctn.Tag = dr["o_team_code"].ToString();
            //                    tn.Nodes.Add(ctn);

            //                    stn = new TreeNode(dr["o_ho_session_name"].ToString());
            //                    stn.Tag = new string[] { dr["o_team_code"].ToString(), dr["o_ho_session_code"].ToString() };
            //                    ctn.Nodes.Add(stn);
            //                }
            //                else
            //                {
            //                    stn = new TreeNode(dr["o_ho_session_name"].ToString());
            //                    stn.Tag = new string[] { dr["o_team_code"].ToString(), dr["o_ho_session_code"].ToString() };
            //                    ctn.Nodes.Add(stn);
            //                }
            //            }
            //            team_info = dr["o_team_info"].ToString();
            //            team_code = dr["o_team_code"].ToString();
            //        }
            //        tn.ExpandAll();
            //    }
            //}
            //else
            //{
            //    ShowMessage("service_error");
            //    return;
            //}
        }
        #endregion

        #region [그리드 컨트롤 컬럼 설정 코드]

        #region 병동 콤보박스 설정
        /// <summary>
        /// 병동 콤보박스를 설정한다.
        /// </summary>
        private void SetHo_dongList()
        {
            //this.layHo_dongList.SetBindVarValue("f_hosp_code", this.mHospCode);
            //if (this.layHo_dongList.QueryLayout(false))
            //{
            //    if (this.layHo_dongList.LayoutTable.Rows.Count > 0)
            //    {
            //        this.grdNUR0104.SetComboItems("ho_dong", this.layHo_dongList.LayoutTable, "ho_dong_name", "ho_dong");
            //    }
            //}
            //else
            //{
            //    ShowMessage("service_error");
            //    return;
            //}
        }
        #endregion

        #region 팀/세션 콤보박스 설정
        /// <summary>
        /// 그리드 팀/세션 콤보박스를 설정한다.
        /// </summary>
        /// <param name="aCodeType">
        /// 콤보 구분
        /// </param>
        public void GetCodeName(string aCodeType)
        {
            this.layComboSet.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layComboSet.SetBindVarValue("f_code_type", aCodeType);

            if (layComboSet.QueryLayout(false))
            {
                switch (aCodeType)
                {
                    case "TEAM":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.grdNUR0104.SetComboItems("ho_team", this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;
                        
                    case "HO_SESSION":
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            this.grdNUR0104.SetComboItems("ho_session", this.layComboSet.LayoutTable, "code_name", "code");
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                ShowMessage("service_error");
                return;
            }
        }
        #endregion

        #region 병실 파인드워커 설정
        private void grdNUR0104_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            this.fwkHo_codeList.ColInfos.Clear();
            this.fwkHo_codeList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.fwkHo_codeList.SetBindVarValue("f_ho_dong", this.grdNUR0104.GetItemValue(e.RowNumber, "ho_dong").ToString());
            this.fwkHo_codeList.ColInfos.Add("ho_code", "病室", FindColType.String, 150, 0, true, FilterType.InitYes);
        }
        #endregion

        #endregion

        #region [팀/세션에 따른 그리드 설정 코드]

        #region 팀/세션에 따른 그리드 설정
        /// <summary>
        /// 팀/세션 트리뷰 노드에  해당하는 데이타를 그리드에 설정한다.
        /// </summary>
        private void Nur0104Query()
        {
            //this.grdNUR0104.Reset();

            //if (tvwHo_dong.SelectedNode.GetNodeCount(true) == 0)
            //{
            //    string[] tag = (string[])tvwHo_dong.SelectedNode.Tag;

            this.grdNUR0104.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR0104.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
            this.grdNUR0104.SetBindVarValue("f_session", this.cboHoSession.GetDataValue());
            //this.grdNUR0104.SetBindVarValue("f_ho_team", tag[0].ToString());
            this.grdNUR0104.SetBindVarValue("f_jukyong_date", this.dtpJukyong_date.GetDataValue());

            if (this.grdNUR0104.QueryLayout(false))
            {
            }
            else
            {
                ShowMessage("service_error");
                return;
            }

            //}
        }
        #endregion

        #region 팀/세션 트리뷰 선택
        private void tvwHo_dong_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.Nur0104Query();
        }
        #endregion

        #endregion

        #region [병실코드 유효성 검사 및 세션 설정 코드]

        private void grdNUR0104_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (e.ColName.Equals("ho_code"))
            {
                string cmdText = string.Empty;
                object retVal = null;
                BindVarCollection bindVals = new BindVarCollection();

                cmdText = @"SELECT A.HO_CODE HO_CODE
                              FROM BAS0250 A
                             WHERE A.HOSP_CODE = :f_hosp_code
                               AND A.HO_DONG = :f_ho_dong
                               AND A.HO_CODE = UPPER(:f_ho_code)
                               AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE ";

                bindVals.Add("f_hosp_code", this.mHospCode);
                bindVals.Add("f_ho_dong", this.grdNUR0104.GetItemValue(this.grdNUR0104.CurrentRowNumber, "ho_dong").ToString());
                bindVals.Add("f_ho_code", this.grdNUR0104.GetItemValue(this.grdNUR0104.CurrentRowNumber, "ho_code").ToString());

                retVal = Service.ExecuteScalar(cmdText, bindVals);

                if (Service.ErrCode == 0)
                {
                    if (retVal == null)
                    {
                        this.ShowMessage("ho_codechk");
                        e.Cancel = true;
                        return;
                    }
                }    
            }
            else if (e.ColName.Equals("ho_session") && grdNUR0104.LayoutTable.Rows[e.RowNumber].RowState == DataRowState.Added)
            {
                this.grdNUR0104.SetItemValue(e.RowNumber, "ho_session1", grdNUR0104.GetItemValue(e.RowNumber, "ho_session").ToString());
            }
        }

        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        // 지정 에러메세지 인지 확인하는 플레그
        private bool appointmentError = false;

        /// <summary>
        /// 그리드의 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grdNUR0104_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                this.Nur0104Query();
                this.ShowMessage("save_true");
                if (this.flag == "Y")
                {
                    this.flag = "S";
                }
            }
            else
            {
                if (!appointmentError)
                {
                    this.ShowMessage("save_false");    
                }
                appointmentError = false;
            }
            return;
        }
        #endregion


        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR0104U00 parent = null;

            public XSavePerformer(NUR0104U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = string.Empty;
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                cmdText = @"SELECT 'Y' 
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM NUR0104
                                            WHERE HOSP_CODE    = :f_hosp_code 
                                              AND HO_DONG      = :f_ho_dong
                                              AND HO_CODE      = :f_ho_code
                                              AND JUKYONG_DATE = TO_DATE(:f_jukyong_date, 'YYYY/MM/DD')
                                              AND HO_SESSION   = :f_ho_session1)";

                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                if (Service.ErrCode == 0)
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        if (retVal != null && retVal.ToString().Equals("Y"))
                        {
                            parent.appointmentError = true;
                            parent.ShowMessage("dup_data");
                            return false;
                        }
                    }
                    else if (item.RowState == DataRowState.Modified || item.RowState == DataRowState.Deleted)
                    {
                        if (retVal == null)
                        {
                            parent.appointmentError = true;
                            parent.ShowMessage("no_data");
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO NUR0104 (SYS_DATE,          SYS_ID,           UPD_DATE,     UPD_ID,     HOSP_CODE,
                                                         HO_DONG,           HO_CODE,          JUKYONG_DATE,
                                                         HO_SESSION,        HO_TEAM)
                                                VALUES  (SYSDATE,           :q_user_id,       SYSDATE,     :q_user_id, :f_hosp_code,
                                                         :f_ho_dong,        :f_ho_code,       :f_jukyong_date,
                                                         :f_ho_session,     :f_ho_team)";
                        break;

                    case DataRowState.Modified:
                        // 오늘이후로 입력이 된 정보를 전체 삭제하고 다시 입력
                        cmdText = @"DELETE NUR0104
                                     WHERE HOSP_CODE    = :f_hosp_code 
                                       AND HO_DONG      = :f_ho_dong
                                       AND HO_CODE      = :f_ho_code
                                       AND HO_SESSION   = :f_ho_session1
                                       AND JUKYONG_DATE >= TO_DATE(:f_jukyong_date, 'YYYY/MM/DD')";

                        retVal = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                        if (Service.ErrCode != 0 || Convert.ToBoolean(retVal) == false)
                        {
                            return false;
                        }

                        cmdText = @"INSERT INTO NUR0104 (SYS_DATE,          SYS_ID,             UPD_DATE,      UPD_ID,     HOSP_CODE,
                                                         HO_DONG,           HO_CODE,            JUKYONG_DATE,
                                                         HO_SESSION,        HO_TEAM)
                                                VALUES  (SYSDATE,           :q_user_id,         SYSDATE,     :q_user_id,  :f_hosp_code,
                                                         :f_ho_dong,        :f_ho_code,         :f_jukyong_date,
                                                         :f_ho_session,     :f_ho_team)";

                        break;

                    case DataRowState.Deleted:
                        cmdText = @"DELETE NUR0104
                                     WHERE HOSP_CODE    = :f_hosp_code 
                                       AND HO_DONG      = :f_ho_dong
                                       AND HO_CODE      = :f_ho_code
                                       AND HO_SESSION   = :f_ho_session1
                                       AND JUKYONG_DATE = TO_DATE(:f_jukyong_date, 'YYYY/MM/DD')";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void cboHoDong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Nur0104Query();
        }

        private void cboHoSession_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Nur0104Query();
        }

    }
}

