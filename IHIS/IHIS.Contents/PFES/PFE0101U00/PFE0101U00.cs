#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.PFES.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Pfes;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using IHIS.CloudConnector.Contracts.Results.Pfes;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
#endregion

namespace IHIS.PFES
{
    /// <summary>
    /// XRT0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class PFE0101U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XMstGrid grdMcode;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdDcode;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;

        private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnIfQry;
        private System.Windows.Forms.ToolTip toolTip;
        private IHIS.Framework.SingleLayout layUserName;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem4;
        private XEditGridCell xEditGridCell5;
        private System.ComponentModel.IContainer components;

        int flag = 0;

        public PFE0101U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            InitItemControls();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFE0101U00));
            this.grdMcode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.btnIfQry = new IHIS.Framework.XButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.layUserName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdMcode
            // 
            resources.ApplyResources(this.grdMcode, "grdMcode");
            this.grdMcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMcode.ColPerLine = 1;
            this.grdMcode.Cols = 1;
            this.grdMcode.ExecuteQuery = null;
            this.grdMcode.FixedRows = 1;
            this.grdMcode.HeaderHeights.Add(26);
            this.grdMcode.Name = "grdMcode";
            this.grdMcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMcode.ParamList")));
            this.grdMcode.QuerySQL = resources.GetString("grdMcode.QuerySQL");
            this.grdMcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdMcode, resources.GetString("grdMcode.ToolTip"));
            this.grdMcode.ToolTipActive = true;
            this.grdMcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
            this.grdMcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMcode_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 130;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 379;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // grdDcode
            // 
            resources.ApplyResources(this.grdDcode, "grdDcode");
            this.grdDcode.CallerID = '2';
            this.grdDcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell5});
            this.grdDcode.ColPerLine = 4;
            this.grdDcode.Cols = 4;
            this.grdDcode.ExecuteQuery = null;
            this.grdDcode.FixedRows = 1;
            this.grdDcode.HeaderHeights.Add(26);
            this.grdDcode.MasterLayout = this.grdMcode;
            this.grdDcode.Name = "grdDcode";
            this.grdDcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcode.ParamList")));
            this.grdDcode.QuerySQL = resources.GetString("grdDcode.QuerySQL");
            this.grdDcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdDcode, resources.GetString("grdDcode.ToolTip"));
            this.grdDcode.ToolTipActive = true;
            this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            this.grdDcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcode_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 93;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 60;
            this.xEditGridCell6.CellName = "code_name";
            this.xEditGridCell6.CellWidth = 243;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code_name_re";
            this.xEditGridCell7.CellWidth = 87;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_value";
            this.xEditGridCell5.CellWidth = 200;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // layDupM
            // 
            this.layDupM.ExecuteQuery = null;
            this.layDupM.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupM.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // layDupD
            // 
            this.layDupD.ExecuteQuery = null;
            this.layDupD.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layDupD.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupD.ParamList")));
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "dup_yn";
            // 
            // btnIfQry
            // 
            this.btnIfQry.AccessibleDescription = null;
            this.btnIfQry.AccessibleName = null;
            resources.ApplyResources(this.btnIfQry, "btnIfQry");
            this.btnIfQry.BackgroundImage = null;
            this.btnIfQry.Font = null;
            this.btnIfQry.Image = ((System.Drawing.Image)(resources.GetObject("btnIfQry.Image")));
            this.btnIfQry.Name = "btnIfQry";
            this.toolTip.SetToolTip(this.btnIfQry, resources.GetString("btnIfQry.ToolTip"));
            this.btnIfQry.Click += new System.EventHandler(this.btnIfQry_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // layUserName
            // 
            this.layUserName.ExecuteQuery = null;
            this.layUserName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layUserName.ParamList")));
            this.layUserName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layUserName_QueryStarting);
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "user_name";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // PFE0101U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnIfQry);
            this.Controls.Add(this.grdDcode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdMcode);
            this.Font = null;
            this.Name = "PFE0101U00";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            // TODO:  XRT0101U00.OnLoad 구현을 추가합니다.
            base.OnLoad (e);

            //this.grdMcode.SavePerformer = new XSavePerformer(this);
            //this.grdDcode.SavePerformer = this.grdMcode.SavePerformer;

            this.grdDcode.SetRelationKey("code_type","code_type");
            this.grdDcode.SetRelationTable("PFE0102");

            if( !this.grdMcode.QueryLayout(false) )
                XMessageBox.Show(Service.ErrFullMsg);

            this.toolTip.SetToolTip(this.btnIfQry,Resources.BTNiFQRY_TOOLTIP_TEXT);
        }

        private void grdMcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdMcode.LayoutTable.Rows[this.grdMcode.CurrentRowNumber].RowState;
            // 입력 버튼이 클릭 되었을 때만 체크
            if ( rowState == DataRowState.Added )
            {
                // 입력된 셀이 코드타입 컬럼이라면,
                if ( e.ColName == "code_type" )
                {
                    #region deleted by Cloud
                    //// 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
                    //this.layDupM.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //this.layDupM.SetBindVarValue("f_code_type", e.ChangeValue.ToString());

                    //this.layDupM.QueryLayout();
                    //if ( this.layDupM.GetItemValue("dup_yn").ToString() == "Y" )
                    //{
                    //    string msg = Resources.MSG001_MSG;
                    //    XMessageBox.Show( e.ChangeValue  +
                    //        msg,Resources.MSG001_CAP, MessageBoxButtons.OK );
                    //    e.Cancel = true;
                    //}
                    #endregion

                    // Cloud updated code START
                    PFE0101U00LayDupMArgs args = new PFE0101U00LayDupMArgs();
                    args.CodeType = e.ChangeValue.ToString();
                    PFE0101U00LayDupDResult res = CloudService.Instance.Submit<PFE0101U00LayDupDResult, PFE0101U00LayDupMArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (res.Result == "Y")
                        {
                            string msg = Resources.MSG001_MSG;
                            XMessageBox.Show(e.ChangeValue + msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            e.Cancel = true;
                        }
                    }
                    // Cloud updated code END
                }
            }
        }

        private void grdDcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdDcode.LayoutTable.Rows[this.grdDcode.CurrentRowNumber].RowState;

            #region deleted by Cloud
            ////입력 버튼이 클릭 되었을 때만 체크
            //if ( rowState == DataRowState.Added )
            //{
            //    // 입력된 셀이 코드 컬럼이면,
            //    if ( e.ColName == "code" )
            //    {
            //        this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //        this.layDupD.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
            //        this.layDupD.SetBindVarValue("f_code", e.ChangeValue.ToString());

            //        this.layDupD.QueryLayout();
            //        if ( this.layDupD.GetItemValue("dup_yn").ToString() == "Y" )
            //        {
            //            string msg = Resources.MSG002_MSG;
            //            XMessageBox.Show( e.ChangeValue.ToString()  +
            //                msg,Resources.MSG001_CAP, MessageBoxButtons.OK );
            //            e.Cancel = true;
            //        }
            //    }
            //}

            //if (this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber,"code_type") == "LOGIN_ID") // m_code_type
            //{
            //    if (e.ColName == "code")
            //    {
            //        if (!this.layUserName.QueryLayout())
            //        {
            //            if (TypeCheck.IsNull(this.layUserName.GetItemValue("user_name")))
            //            {
            //                string msg = Resources.MSG003_MSG;
            //                XMessageBox.Show( e.ChangeValue.ToString()  +
            //                    msg,Resources.MSG001_CAP, MessageBoxButtons.OK );
            //            }
            //        }
            //    }
            //}
            #endregion

            // Cloud udated code START
            if ((rowState == DataRowState.Added && e.ColName == "code")
                || (this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type") == "LOGIN_ID" && e.ColName == "code"))
            {
                PFE0101U00GrdDcodeColumnChangedArgs args = new PFE0101U00GrdDcodeColumnChangedArgs();
                args.Code = e.ChangeValue.ToString();
                args.CodeType = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type");
                args.ColName = e.ColName;
                args.MCodeType = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type") == "LOGIN_ID";
                args.RowState = rowState.ToString();
                PFE0101U00GrdDcodeColumnChangedResult res = CloudService.Instance.Submit<PFE0101U00GrdDcodeColumnChangedResult,
                    PFE0101U00GrdDcodeColumnChangedArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.DupYn == "Y")
                    {
                        string msg = Resources.MSG002_MSG;
                        XMessageBox.Show(e.ChangeValue.ToString() + msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }

                    if (res.UserName == "ERROR")
                    {
                        string msg = Resources.MSG003_MSG;
                        XMessageBox.Show(e.ChangeValue.ToString() + msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    }
                }
            }
            // Cloud udated code END
        }

        //검색중인지 아닌지의 여부(0->조건조회가능모드, 1->조건검색모드)
        private void btnIfQry_Click(object sender, System.EventArgs e)
        {
            //만약 초기화된 상태라면 무조건 마스터그리드에 조건조회가 타도록 설정
            if (this.grdMcode.LayoutTable.Rows.Count == 0 && this.grdDcode.LayoutTable.Rows.Count == 0)
                this.CurrMQLayout = this.grdMcode;

            //마스터인지 디테일인지의 여부
            string MorD = "";

            //조건조회버튼을 클릭시
            if ( flag%2 == 0)
            {
                //현재스크린의 아웃포커스가 마스터그리드라면,
                if (this.CurrMQLayout == this.grdMcode)
                {
                    //중복체크의 이벤트가 타지 안토록 설정
                    this.grdMcode.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
                    this.grdMcode.Reset();
                    this.grdMcode.InsertRow();
                    MorD = "M";
                }
                //현재스크린의 아웃포커스가 디테일그리드라면,
                else if (this.CurrMQLayout == this.grdDcode)
                {
                    //중복체크의 이벤트가 타지 안토록 설정
                    this.grdDcode.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
                    this.grdDcode.Reset();
                    this.grdDcode.InsertRow();
                    MorD = "D";
                }
                //버튼의 텍스트를 변경
                this.btnIfQry.Text = Resources.BTNIFQRY_1_TEXT;
            }
            //검색실행버튼을 클릭시
            else
            {
                //현재스크린의 아웃포커스가 마스터그리드라면,
                if (this.CurrMQLayout == this.grdMcode)
                {
                    this.grdMcode.SetBindVarValue("f_code_type",this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber,"code_type"));
                    this.grdMcode.QueryLayout(false);
                }
                //현재스크린의 아웃포커스가 디테일그리드라면,
                else if (this.CurrMQLayout == this.grdDcode)
                {
                    this.grdDcode.QueryLayout(false);
                }
                //버튼의 텍스트를 변경
                this.btnIfQry.Text = Resources.BTNIFQRY_2_TEXT;
            }
            //검색실행이 끝난후 다시 중복체크이벤트를 살려두어야함
            if (flag%2 == 1)
            {
                if (MorD == "M")
                    this.grdMcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMcode_GridColumnChanged);
                else if (MorD == "D")
                    this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            }    

            //버튼이 조건조회인지 검색실행인지의 여부를 결정하는 플래그
            flag++;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                //조건조회/검색실행버튼에 단축키 F1을 맵핑
                case Keys.F1:
                    //버튼을 그냥 클릭했을 때는 문제가 없으나,
                    //단축키로 버튼클릭 이벤트를 발생시킬 때에는,
                    //현재위치한 셀에 포커스가 그대로 있기 때문에 의도한 값이 
                    //조회서비스의 인밸류값으로 셋팅이 되지가 않는다.
                    //따라서 강제로 다른 셀로 포커스를 이동시켜준다.
                    if ( this.CurrMQLayout == this.grdMcode && flag%2 == 1)
                        this.grdMcode.SetFocusToItem(this.grdMcode.CurrentRowNumber,"code_type_name");
                    else if ( this.CurrMQLayout == this.grdDcode && flag%2 == 1)
                        this.grdDcode.SetFocusToItem(this.grdDcode.CurrentRowNumber,"code_name_re");
                    
                    this.btnIfQry_Click(new object(),new System.EventArgs());
                    break;
                default:
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //초기화가 된 후 포커스 마스터 그리드로..
                case FunctionType.Reset:
                    this.CurrMQLayout = this.grdMcode;
                    break;
                default:
                    break;
            }
        }

        private void layUserName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layUserName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layUserName.SetBindVarValue("f_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "code"));
        }

        private void grdMcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcode.SetBindVarValue("f_code_type", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
            this.grdDcode.SetBindVarValue("f_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "code"));
            this.grdDcode.SetBindVarValue("f_code_name", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "code_name"));
        }

        #region deleted by Cloud
//        #region XSavePerformer

//        private class XSavePerformer : ISavePerformer
//        {
//            PFE0101U00 parent;

//            public XSavePerformer(PFE0101U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);

//                switch (callerID)
//                { 
//                    case '1':

//                        switch (item.RowState)
//                        { 
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO PFE0101 
//                                                 ( SYS_DATE,                SYS_ID,                  
//                                                   UPD_DATE,                UPD_ID,             HOSP_CODE,
//                                                   CODE_TYPE,               CODE_TYPE_NAME                 ) 
//                                            VALUES 
//                                                 ( SYSDATE,               :q_user_id,               
//                                                   SYSDATE,               :q_user_id,           :f_hosp_code,
//                                                   :f_code_type,          :f_code_type_name                 )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE PFE0101
//                                               SET UPD_ID          = :q_user_id
//                                                 , UPD_DATE        = SYSDATE
//                                                 , CODE_TYPE_NAME  = :f_code_type_name
//                                             WHERE HOSP_CODE       = :f_hosp_code 
//                                               AND CODE_TYPE       = :f_code_type";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE PFE0102
//                                             WHERE HOSP_CODE       = :f_hosp_code 
//                                               AND CODE_TYPE       = :f_code_type";

//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                cmdText = @"DELETE PFE0101
//                                             WHERE HOSP_CODE       = :f_hosp_code 
//                                               AND CODE_TYPE       = :f_code_type";


//                                break;
//                        }

//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO PFE0102 
//                                                 ( SYS_DATE,                SYS_ID,                  
//                                                   UPD_DATE,                UPD_ID,             HOSP_CODE,
//                                                   CODE_TYPE,               CODE,            
//                                                   CODE_NAME,               CODE_NAME_RE,       CODE_VALUE     ) 
//                                            VALUES 
//                                                 ( SYSDATE,                 :q_user_id,               
//                                                   SYSDATE,                 :q_user_id,           :f_hosp_code,
//                                                   :f_code_type,            :f_code,         
//                                                   :f_code_name,            :f_code_name_re,      :f_code_value) ";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                    return false;

//                                /* 재료 세트 등록시 공통 등록 오더 항목 코드 만들어 주어야함 */
//                                if (item.BindVarList["f_code_type"].VarValue == "SET_PART")
//                                {
//                                    cmdText = @"INSERT INTO PFE0113 
//                                                     ( SYS_DATE,                SYS_ID,                  
//                                                       UPD_DATE,                UPD_ID,             HOSP_CODE,
//                                                       SET_PART,                HANGMOG_CODE              )
//                                                VALUES 
//                                                     ( SYSDATE,                 :q_user_id,               
//                                                       SYSDATE,                 :q_user_id,           :f_hosp_code,
//                                                       :f_code,                 'PART_ALL')   ";
//                                }
//                                else
//                                {
//                                    return true;
//                                }

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE PFE0102
//                                               SET UPD_ID            = :q_user_id
//                                                 , UPD_DATE          = SYSDATE
//                                                 , CODE_NAME         = :f_code_name
//                                                 , CODE_NAME_RE      = :f_code_name_re
//                                                 , CODE_VALUE        = :f_code_value
//                                             WHERE HOSP_CODE         = :f_hosp_code 
//                                               AND CODE_TYPE         = :f_code_type
//                                               AND CODE              = :f_code";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE PFE0102
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                    return false;

//                                /* 재료 세트 삭제시 공통 등록 오더 항목 코드도 삭제함 */

//                                if (item.BindVarList["f_code_type"].VarValue == "SET_PART")
//                                {
//                                    cmdText = @"DELETE PFE0113
//                                             WHERE HOSP_CODE    = :f_hosp_code 
//                                               AND SET_PART     = :f_code
//                                               AND HANGMOG_CODE = 'PART_ALL'";
//                                }
//                                else
//                                {
//                                    return true;
//                                }
//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }

//        #endregion
        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdMcode.QueryLayout(false);
                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    #region deleted by Cloud
                    //try
                    //{
                    //    Service.BeginTransaction();

                    //    //if(!this.grdMcode.SaveLayout())
                    //    //    throw new Exception();

                    //    if (!this.grdDcode.SaveLayout())
                    //        throw new Exception();

                    //    Service.CommitTransaction();
                    //    XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP);
                    //}
                    //catch
                    //{
                    //    Service.RollbackTransaction();
                    //    XMessageBox.Show(Service.ErrFullMsg, Resources.MSG005_CAP, MessageBoxIcon.Error);
                    //}
                    #endregion

                    // Cloud updated code START
                    PFE0101U00SaveLayoutArgs args = new PFE0101U00SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = GetListDataForSaveLayout();
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, PFE0101U00SaveLayoutArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP); // Success
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP); // Fail
                    }
                    // Cloud updated code END

                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.CurrMQLayout == this.grdDcode)
                    {
                        if (this.grdMcode.RowCount > 0)
                        {
                            int rowNum = this.grdDcode.InsertRow(-1);
                            this.grdDcode.SetFocusToItem(rowNum, "code");
                        }
                    }
                    break;

                case FunctionType.Delete:
                    if (this.CurrMQLayout != this.grdDcode)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;
            }
        }

        #region Cloud connector code

        #region InitItemControls
        /// <summary>
        /// InitItemControls
        /// </summary>
        private void InitItemControls()
        {
            //MED-12089
            if (NetInfo.Language != LangMode.Jr)
            {
                this.btnIfQry.Width = 164;
                this.btnIfQry.Location = new Point(300, 558);
            }

            // grdMCode
            this.grdMcode.ParamList = new List<string>(new string[] { "f_code_type" });
            this.grdMcode.ExecuteQuery = GetGrdMCode;

            // grdDcode
            this.grdDcode.ParamList = new List<string>(new string[] { "f_code_type", "f_code", "f_code_name" });
            this.grdDcode.ExecuteQuery = GetGrdDCode;
        }
        #endregion

        #region GetGrdMCode
        /// <summary>
        /// GetGrdMCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdMCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PFE0101U00GrdMCodeArgs args = new PFE0101U00GrdMCodeArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            PFE0101U00GrdMCodeResult res = CloudService.Instance.Submit<PFE0101U00GrdMCodeResult, PFE0101U00GrdMCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PFE0101U00GrdMCodeInfo item in res.McodeItem)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.CodeTypeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdDCode
        /// <summary>
        /// GetGrdDCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            PFE0101U00GrdDCodeArgs args = new PFE0101U00GrdDCodeArgs();
            args.Code           = bvc["f_code"].VarValue;
            args.CodeName       = bvc["f_code_name"].VarValue;
            args.CodeType       = bvc["f_code_type"].VarValue;
            PFE0101U00GrdDCodeResult res = CloudService.Instance.Submit<PFE0101U00GrdDCodeResult, PFE0101U00GrdDCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (PFE0101U00GrdDCodeInfo item in res.DcodeItem)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.Code,
                        item.CodeName,
                        item.CodeNameRe,
                        item.CodeValue,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<PFE0101U00SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<PFE0101U00SaveLayoutInfo> lstData = new List<PFE0101U00SaveLayoutInfo>();
            string codeType = grdMcode.GetItemString(grdMcode.CurrentRowNumber, "code_type");

            // For update
            for (int i = 0; i < grdDcode.RowCount; i++)
            {
                if (grdDcode.GetRowState(i) == DataRowState.Unchanged) continue;

                PFE0101U00SaveLayoutInfo item = new PFE0101U00SaveLayoutInfo();
                item.Code           = grdDcode.GetItemString(i, "code");
                item.CodeName       = grdDcode.GetItemString(i, "code_name");
                item.CodeNameRe     = grdDcode.GetItemString(i, "code_name_re");
                item.CodeType       = codeType;
                item.CodeValue      = grdDcode.GetItemString(i, "code_value");
                item.RowState       = grdDcode.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdDcode.DeletedRowTable)
            {
                foreach (DataRow dr in grdDcode.DeletedRowTable.Rows)
                {
                    PFE0101U00SaveLayoutInfo item = new PFE0101U00SaveLayoutInfo();
                    item.Code       = Convert.ToString(dr["code"]);
                    item.CodeType   = codeType;
                    item.RowState   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion
    }
}

