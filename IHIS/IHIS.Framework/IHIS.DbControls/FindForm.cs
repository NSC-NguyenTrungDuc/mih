using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
    /// <summary>
    /// FindForm에 대한 요약 설명입니다.
    /// </summary>
    internal class FindForm : System.Windows.Forms.Form
    {
        #region Fields
        const string GRID_TABLE_NAME = "FindTable";
        const string CODE_COL = "Code";
        const string CODENAME_COL = "CodeName";
        const string FIND_BIND_VAR1 = "f_find1";
        const string FIND_BIND_VAR2 = "f_find2";
        const string FIND_BIND_VAR3 = "f_find3";
        private const int gridMinSize = 250;    // Grid Minimum Size
        private DataTable gridTable = null;
        private XDataGridTableStyle tblStyle = new XDataGridTableStyle();
        private bool qryExecuted = false;
        private XFindWorker findWorker = null;
        private bool customLayout = true;
        private object[] data = null;
        private Control cont = null;
        private ArrayList filterColumnList = new ArrayList(); //FindLayout에서 Filter컬럼으로 지정된 컬럼명 관리
        private OracleDataReader dataReader = null;
        #endregion

        private IHIS.Framework.XFindGrid findGrid;
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.XTextBox txtSearch;
        private System.ComponentModel.Container components = null;
        private IHIS.Framework.XButton btnSearch;
        private IHIS.Framework.XButton btnConfirm;
        private IHIS.Framework.XLabel lbCond;
        private IHIS.Framework.XButton btnCancel;

        #region Properties
        // 선택한 자료 (return값)
        public object[] SelectedData
        {
            get { return data; }
        }

        // 선택한 자료수
        public int DataCount
        {
            get { return data.Length; }
        }
        #endregion

        #region 생성자
        public FindForm(XFindWorker findWorker, Control cont)
        {
            InitializeComponent();

            SetControlTextByLangMode();

            this.findWorker = findWorker;
            this.cont = cont;
            if (this.findWorker == null) return;

            //FormText 설정
            if (this.findWorker.FormText != "")
                this.Text = this.findWorker.FormText;
            else
                this.Text = XMsg.GetField("F001"); //코드조회

            //최초 조회조건 Text SET
            //Control의 Text가 있으면 Text로 설정 없으면 findController의 SearchText로 설정
            //2005.07.11 FindWorker의 IsSetControlText이면 설정
            if (this.findWorker.IsSetControlText && (cont.Text != ""))
                this.txtSearch.Text = cont.Text;

            //2005.10.20 검색조건 TextBox의 CharacterCasing 적용
            this.txtSearch.CharacterCasing = findWorker.SearchTextCasing;

            //DataGrid, findWorker의 MOutputLayout 초기화
            InitializeOutputLayout();

            int totalWidth = 36;
            //지정한 컬럼정보의 Width에 맞추어 Size 조정
            foreach (DataGridColumnStyle colStyle in this.findGrid.TableStyles[0].GridColumnStyles)
                totalWidth += colStyle.Width;

            //최소Size보다 작으면 최소Size로
            if (totalWidth < gridMinSize)
                totalWidth = gridMinSize;

            // https://sofiamedix.atlassian.net/browse/MED-12171
            //this.ClientSize = new System.Drawing.Size(totalWidth + this.DockPadding.Left + this.DockPadding.Right, this.ClientSize.Height);
            this.ClientSize = new Size(370, 440);

            // 위치조정(Find창을 Call한 Control의 하단에
            if (cont != null)
            {
                /*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
                 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
                 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
                 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
                 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
                 */
                Rectangle rc = Screen.PrimaryScreen.WorkingArea;
                // 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
                Point pos = cont.PointToScreen(new Point(0, cont.Height));
                // 2006.03.28 모니터 3개이상도 고려하여 반영
                if (SystemInformation.MonitorCount > 1)
                {
                    //pos.X가 Second Monitor 이상에 있으면 rc 변경
                    if (pos.X > rc.Width)
                    {
                        //두번째 Monitor 부터 위치 파악
                        for (int i = 1 ; i < SystemInformation.MonitorCount; i++)
                        {
                            Rectangle sRect = Screen.AllScreens[i].WorkingArea;
                            //cont가 위치하는 Monitor 확인
                            if ((pos.X >= sRect.Left) && (pos.X <= sRect.Right))
                            {
                                rc = new Rectangle(rc.X, rc.Y, sRect.Right, sRect.Y + sRect.Height);
                                break;
                            }
                        }
                    }
                }

                if (this.Width > rc.Width - pos.X)
                {
                    pos.X = Math.Max(rc.Width - this.Width, 0);
                }
                if (this.Height > rc.Height - pos.Y)
                {
                    if (this.Height > pos.Y - cont.Height)
                        pos.Y = Math.Max(rc.Height - this.Height, 0);
                    else
                        pos.Y -= (this.Height + cont.Height);
                }
                this.Location = pos;
            }

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font =
                this.lbCond.Font =
                this.txtSearch.Font =
                this.findGrid.Font =
                this.btnSearch.Font =
                this.btnConfirm.Font =
                this.btnCancel.Font = Service.COMMON_FONT;
            }
        }
        #endregion
        
        #region Dispose
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
                //DataReader Close
                if (this.dataReader != null)
                {
                    if (!this.dataReader.IsClosed)
                        this.dataReader.Close();
                }
            }
            base.Dispose( disposing );
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(System.EventArgs e)
        {
            //Find컬럼 정보에서 Filter컬럼으로 지정된 컬럼을 Filter List에 SET
            //String형이고, Filter컬럼으로 지정된 컬럼만 Add, 
            if (this.customLayout)
            {
                foreach (FindColumnInfo info in this.findWorker.ColInfos)
                {
                    if ((info.ColType == FindColType.String) && (info.FilterType != FilterType.No))
                        this.filterColumnList.Add(info.ColName);
                }
            }
            else  //FindLayout 설정되지 않음
            {
                //기본 Code, CodeName Layout이면 모두 FilterColumn으로 설정
                this.filterColumnList.Add(CODE_COL);
                this.filterColumnList.Add(CODENAME_COL);
            }

            //SQL SET, BindVarList Set
            this.findGrid.QueryDataDelegate = this.findWorker.ExecuteQuery;
            this.findGrid.ParamList = this.findWorker.ParamList;
            foreach (BindVar bVar in findWorker.BindVarList)
                this.findGrid.SetBindVarValue(bVar.VarName, bVar.VarValue);

            if (findWorker.AutoQuery)
            {
                //데이타가 한건도 없으면 DataServiceCall false return한다.
                //따라서, 에러 판단하지 않고 경우에는 Error로 보여주지 않고 Data가 없는 Grid를 보여준다.
                this.QueryData();

                //첫번째 선택
                if (findGrid.DisplayRowCount > 0)
                    findGrid.Select(0);
                //조회처리됨 Flag Set
                qryExecuted = true;
            }
            // txtSearch ActiveControl로 SET
            this.ActiveControl = txtSearch;
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCond = new IHIS.Framework.XLabel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.btnSearch = new IHIS.Framework.XButton();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.findGrid = new IHIS.Framework.XFindGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCond);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(50, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(344, 32);
            this.panel1.TabIndex = 5;
            // 
            // lbCond
            // 
            this.lbCond.Location = new System.Drawing.Point(4, 4);
            this.lbCond.Name = "lbCond";
            this.lbCond.Size = new System.Drawing.Size(60, 21);
            this.lbCond.TabIndex = 1;
            this.lbCond.Text = "조 건";
            this.lbCond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtSearch.Location = new System.Drawing.Point(65, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(57, 377);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 27);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "검 색(F2)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(149, 377);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(115, 27);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "확인(Enter)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "취소(Esc)";
            // 
            // findGrid
            // 
            this.findGrid.CaptionVisible = false;
            this.findGrid.DataSource = null;
            this.findGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findGrid.Location = new System.Drawing.Point(5, 32);
            this.findGrid.Name = "findGrid";
            this.findGrid.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("findGrid.ParamList")));
            this.findGrid.QueryDataDelegate = null;
            this.findGrid.ReadOnly = true;
            this.findGrid.Size = new System.Drawing.Size(344, 339);
            this.findGrid.TabIndex = 1;
            this.findGrid.DoubleClick += new System.EventHandler(this.findGrid_DoubleClick);
            // 
            // FindForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 406);
            this.ControlBox = false;
            this.Controls.Add(this.findGrid);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 35);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "코드조회";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void SelectItem()
        {
            if (findGrid.DisplayRowCount == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            int row = this.findGrid.CurrentRowIndex;
            if (row >= 0)
            {
                DataRow dtRow = this.gridTable.DefaultView[row].Row;
                data = dtRow.ItemArray;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 검색
        /// </summary>
        /// <findWorker name="sender"></findWorker>
        /// <findWorker name="e"></findWorker>
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            //서버 검색이면 서버에 조건을 넘겨서 조회
            if (this.findWorker == null) return;

            if (this.findWorker.ServerFilter)
            {
                //데이타가 한건도 없으면 DataServiceCall false return한다.
                //따라서, 에러 판단하지 않고 경우에는 Error로 보여주지 않고 Data가 없는 Grid를 보여준다.
                this.QueryData();

                if (findGrid.DisplayRowCount > 0)
                    findGrid.Select(0);
                qryExecuted = true;
            }
            else
            {
                // 조회가 실행되지 않았으면 조회처리후 조회완료시 까지 조회
                if (!qryExecuted)
                {
                    //데이타가 한건도 없으면 DataServiceCall false return한다.
                    //따라서, 에러 판단하지 않고 경우에는 Error로 보여주지 않고 Data가 없는 Grid를 보여준다.
                    this.QueryData();

                    qryExecuted = true;
                }
                //<미확정> 연속조회를 지원할지 안할지 결정(일단 연속조회 처리안하기)

                //조회된 건이 없으면 Return
                //if (findGrid.DisplayRowCount < 1) return;

                //txtSearch에 Text가 있으면 입력한 값으로 Filter string을 구성하여 찾기
                //없으면 Filter Clear
                // DataGrid Filtering
                string    filter = "";
                int        idx = 0;
                string    searchText = "%";
                if (txtSearch.Text.Trim() != "")
                    searchText = txtSearch.Text.Trim();
                
                //검색조건이 없을때는 *(All)로 처리함
                if (searchText == "")
                    searchText = "*";

                // 필터 컬럼으로 지정된 컬럼으로 Filter 구성
                foreach (string colName in this.filterColumnList)
                {
                    if (idx > 0) filter += " OR ";
                    filter += colName + @" LIKE '" + searchText.Replace("%","*") + @"*' ";
                    idx++;

                }
                this.gridTable.DefaultView.RowFilter = filter;

                //Filter후 Row가 있으면 첫번째 Select
                if (gridTable.DefaultView.Count > 0)
                {
                    findGrid.UnSelect(findGrid.CurrentRowIndex);
                    findGrid.CurrentRowIndex = 0;
                    findGrid.Select(0);
                }
            }

            //Grid에 Focus
            this.findGrid.Focus();
        }

        /// <summary>
        /// 확인
        /// </summary>
        /// <findWorker name="sender"></findWorker>
        /// <findWorker name="e"></findWorker>
        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            SelectItem();
        }

        /// <summary>
        /// 검색 Box에서 Arrow Key를 Grid로 전달
        /// 2005.11.02 Up, Down, PageUp, PageDown시에 txtSearch에 Focus 주지 않고, Grid에 Focus
        /// </summary>
        /// <findWorker name="sender"></findWorker>
        /// <findWorker name="e"></findWorker>
        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up :
                    User32.SendMessage(findGrid.Handle, (int)Win32.Msgs.WM_KEYDOWN, (uint)Win32.VirtualKeys.VK_UP, 0);
                    //txtSearch.Focus();
                    if (!findGrid.Focused)
                        findGrid.Focus();
                    break;
                case Keys.Down :
                    User32.SendMessage(findGrid.Handle, (int)Win32.Msgs.WM_KEYDOWN, (uint)Win32.VirtualKeys.VK_DOWN, 0);
                    //txtSearch.Focus();
                    if (!findGrid.Focused)
                        findGrid.Focus();
                    break;
                case Keys.PageUp :
                    User32.SendMessage(findGrid.Handle, (int)Win32.Msgs.WM_KEYDOWN, (uint)Win32.VirtualKeys.VK_PRIOR, 0);
                    //txtSearch.Focus();
                    if (!findGrid.Focused)
                        findGrid.Focus();
                    break;
                case Keys.PageDown :
                    User32.SendMessage(findGrid.Handle, (int)Win32.Msgs.WM_KEYDOWN, (uint)Win32.VirtualKeys.VK_NEXT, 0);
                    //txtSearch.Focus();
                    if (!findGrid.Focused)
                        findGrid.Focus();
                    break;
                case Keys.Enter:  // 조회
                    this.btnSearch.PerformClick();
                    break;

            }
        }
        private void findGrid_DoubleClick(object sender, System.EventArgs e)
        {
            SelectItem();
        }

        private void FindForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F2) && !e.Shift && !e.Alt && !e.Control)
            {
                this.btnSearch.PerformClick();
                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Enter) && (this.ActiveControl != this.txtSearch))
            {
                this.btnConfirm.PerformClick();
                e.Handled = true;
            }
        }
        private void txtSearch_Enter(object sender, System.EventArgs e)
        {
            //ImeMode Default 한글
            if (this.findWorker != null)
                this.txtSearch.ImeMode = this.findWorker.SearchImeMode;
            else
                this.txtSearch.ImeMode = ImeMode.Hangul;
        }

        #region InitializeGrid
        private void InitializeOutputLayout()
        {
            this.gridTable = new DataTable(GRID_TABLE_NAME);
            DataColumn dtCol = null;
            XDataGridStringTextBoxColumn strColStyle = null;
            XDataGridDateTimeTextBoxColumn dtColStyle = null;
            XDataGridNumericTextBoxColumn numColStyle = null;

            //컬럼정보가 없으면 기본 컬럼정보(code, codeName으로 설정)
            if (this.findWorker.ColInfos.Count < 1)
            {
                this.customLayout = false; //사용자정의 Layout사용하지 않고, 기본 Layout 사용
                dtCol = new DataColumn(CODE_COL, typeof(string));
                this.gridTable.Columns.Add(dtCol);
                //컬럼스타일 생성
                strColStyle = new XDataGridStringTextBoxColumn();
                strColStyle.MappingName = CODE_COL;
                strColStyle.HeaderText = XMsg.GetField("F002"); //코드
                strColStyle.Width = 150;
                this.tblStyle.GridColumnStyles.Add(strColStyle);
                dtCol = new DataColumn(CODENAME_COL, typeof(string));
                this.gridTable.Columns.Add(dtCol);
                //컬럼스타일 생성
                strColStyle = new XDataGridStringTextBoxColumn();
                strColStyle.MappingName = CODENAME_COL;
                strColStyle.HeaderText = XMsg.GetField("F003"); //코드명
                strColStyle.Width = 300;
                this.tblStyle.GridColumnStyles.Add(strColStyle);
            }
            else
            {

                foreach (FindColumnInfo info in this.findWorker.ColInfos)
                {
                    if (info.ColType == FindColType.String)
                    {
                        // 컬럼 생성 Add
                        dtCol = new DataColumn(info.ColName, typeof(string));
                        this.gridTable.Columns.Add(dtCol);
                        //컬럼스타일 생성
                        strColStyle = new XDataGridStringTextBoxColumn();
                        strColStyle.MappingName = info.ColName;
                        strColStyle.HeaderText = info.HeaderText;
                        strColStyle.Mask = info.Mask;
                        strColStyle.ColumnAlign = info.ColAlign;
                        if (info.IsVisible)
                            strColStyle.Width = info.ColWidth;
                        else
                            strColStyle.Width = 0;
                        this.tblStyle.GridColumnStyles.Add(strColStyle);
                        
                    }
                    else if ((info.ColType == FindColType.Date) ||(info.ColType == FindColType.DateTime))
                    {
                        // 컬럼 생성 Add (YYYYMMDD, YYYYMMDDHHMISS형의 String으로 처리)
                        dtCol = new DataColumn(info.ColName, typeof(string));
                        this.gridTable.Columns.Add(dtCol);
                        //컬럼스타일 생성
                        dtColStyle = new XDataGridDateTimeTextBoxColumn();
                        dtColStyle.MappingName = info.ColName;
                        dtColStyle.HeaderText = info.HeaderText;
                        dtColStyle.IsDateTime = false;
                        //DateTime여부 SET
                        if (info.ColType == FindColType.DateTime)
                            dtColStyle.IsDateTime = true;
                        dtColStyle.Mask = info.Mask;
                        dtColStyle.ColumnAlign = info.ColAlign;
                        if (info.IsVisible)
                            dtColStyle.Width = info.ColWidth;
                        else
                            dtColStyle.Width = 0;
                        this.tblStyle.GridColumnStyles.Add(dtColStyle);

                    }
                    else  //Number
                    {
                        //컬럼생성
                        dtCol = new DataColumn(info.ColName, typeof(double));
                        this.gridTable.Columns.Add(dtCol);
                        //컬럼스타일 생성
                        numColStyle = new XDataGridNumericTextBoxColumn();
                        numColStyle.MappingName = info.ColName;
                        numColStyle.HeaderText = info.HeaderText;
                        numColStyle.ColumnAlign = info.ColAlign;
                        numColStyle.DecimalDigits = info.DecimalDigits;
                        if (info.IsVisible)
                            numColStyle.Width = info.ColWidth;
                        else
                            numColStyle.Width = 0;
                        this.tblStyle.GridColumnStyles.Add(numColStyle);
                    }
                }
            }
            
            this.tblStyle.MappingName = this.gridTable.TableName;
            this.tblStyle.AllowSorting = false;
            this.tblStyle.RowHeaderWidth = 15;
            //Grid에 DataSource 연결, 테이블스타일 지정 (DataSource는 속도를 위하여 조회후 SET)
            //this.findGrid.DataSource = gridTable;
            //AllowNew Property는 실행시 ArrowKey로 새행을 넣을 수 있는가의 여부
            //InsertRow Method를 통해서만 Insert가능하게 false로 설정
            this.gridTable.DefaultView.AllowNew = false;

            //TableStyles 지정
            this.findGrid.TableStyles.Clear();
            this.findGrid.TableStyles.Add(this.tblStyle);
            //컬럼초기화
            this.findGrid.InitializeColumns();
            //데이타 Source 연결
            this.findGrid.DataSource = this.gridTable;
            
        }
        #endregion

        #region QueryData
        private void QueryData()
        {

            /* ServerFilter일때 BindVarList에 f_find 변수 설정하여 검색조건의 text를 Value로 설정
             * Filter컬럼중 현재 사용자가 선택된 컬럼에만 Data설정
             * DynService이면 BindVarList에 f_find 변수 설정하여 검색조건의 text를 Value로 설정
             * */
            if (this.findWorker.ServerFilter)
            {
                //기존 BindVarList에 서버 Filter면 
                //InputSQL에 :f_find1, ;f_find2, :f_find3가 있으면 Find Bind Var 설정
                //총 3개까지 ServerFiltering의 Find변수로 가능하게 변경함
                //2006.07.11 Bind변수의 판단은 DB종류에 따른 BindSymbol로 판단
                if (findWorker.ParamList.IndexOf(FIND_BIND_VAR1) >= 0)
                    findWorker.BindVarList.Add(FIND_BIND_VAR1, this.txtSearch.Text);
                if (findWorker.ParamList.IndexOf(FIND_BIND_VAR2) >= 0)
                    findWorker.BindVarList.Add(FIND_BIND_VAR2, this.txtSearch.Text);
                if (findWorker.ParamList.IndexOf(FIND_BIND_VAR3) >= 0)
                    findWorker.BindVarList.Add(FIND_BIND_VAR3, this.txtSearch.Text);

                //findGrid에 BindVar Set
                foreach (BindVar bVar in this.findWorker.BindVarList)
                    findGrid.SetBindVarValue(bVar.VarName, bVar.VarValue);
            }
            //findGrid 조회

            // 2015.06.11 Edited by AnhNV
            if (findWorker.ParamList.Contains("f_page_number"))
            {
                findGrid.QueryData(false);
            }
            else
            {
                findGrid.QueryData(true);
            }
        }
        #endregion

        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            this.btnCancel.Text = XMsg.GetField("F004"); //취소(Esc)
            this.btnConfirm.Text = XMsg.GetField("F005"); //확인(Enter)
            this.btnSearch.Text = XMsg.GetField("F006"); //검 색(F2)
            this.lbCond.Text = XMsg.GetField("F007"); //조 건
            this.txtSearch.ImeMode = (NetInfo.Language == LangMode.Ko ? ImeMode.Hangul : ImeMode.Hiragana);
        }

    }
}
