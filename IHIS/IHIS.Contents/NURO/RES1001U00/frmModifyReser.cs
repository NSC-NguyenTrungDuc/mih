using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.Framework;
using IHIS.CloudConnector;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;  


namespace IHIS.NURO
{
    public class frmModifyReser : IHIS.Framework.XForm
    {
        #region [DynService Control]
        //private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();    
        #endregion

        #region [Instance Variable]        
        //Message처리
        private string mbxMsg = "", mbxCap = "";
        private string mJinryo_pre_date = "";
        private string mJinryo_pre_time = "";
        private string mAM_PM = "";

        /* 이부분 수정해야함*/
        private int AM_START_TIME = 800;
        private int AM_END_TIME   = 1200;
        private int PM_START_TIME = 1200;
        private int PM_END_TIME   = 1700;

        private DataRow modifyRow;

        private string mHospCodeLink = "";
        private bool tabIsAll = false;
        #endregion
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
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XDatePicker dpkJinryo_pre_date;
        private IHIS.Framework.XEditGrid grdRES1001;
        //private IHIS.Framework.DataServiceMMISO dsvSave;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XComboBox cboJinryo_pre_time;
        private SingleLayout layCommon;
        private MultiLayout layTerm;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private System.ComponentModel.IContainer components = null;

        public frmModifyReser(string hospCodeLink, bool tabIsAll)
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
            this.mHospCodeLink = hospCodeLink;
            this.tabIsAll = tabIsAll;
        }

        public frmModifyReser(DataRow row, string hospCodeLink, bool tabIsAll)
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            modifyRow = row;

            this.mHospCodeLink = hospCodeLink;
            this.tabIsAll = tabIsAll;
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyReser));
            this.grdRES1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.dpkJinryo_pre_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.cboJinryo_pre_time = new IHIS.Framework.XComboBox();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layTerm = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdRES1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRES1001
            // 
            this.grdRES1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell25,
            this.xEditGridCell29,
            this.xEditGridCell15,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell27});
            this.grdRES1001.ColPerLine = 6;
            this.grdRES1001.Cols = 7;
            this.grdRES1001.ExecuteQuery = null;
            this.grdRES1001.FixedCols = 1;
            this.grdRES1001.FixedRows = 1;
            this.grdRES1001.HeaderHeights.Add(20);
            resources.ApplyResources(this.grdRES1001, "grdRES1001");
            this.grdRES1001.Name = "grdRES1001";
            this.grdRES1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRES1001.ParamList")));
            this.grdRES1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdRES1001.RowHeaderVisible = true;
            this.grdRES1001.Rows = 2;
            this.grdRES1001.Tag = "0900";
            this.grdRES1001.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdRES1001_PreSaveLayout);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jinryo_pre_time";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 86;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname2";
            this.xEditGridCell4.CellWidth = 131;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "chojae";
            this.xEditGridCell5.CellWidth = 57;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "reser_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 91;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pkout1001";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jinryo_pre_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "seq";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gubun";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "doctor";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "res_gubun";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "changgu";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "input_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 1;
            this.xEditGridCell13.CellName = "naewon_yn";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "newrow";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell27.ButtonImage")));
            this.xEditGridCell27.CellName = "modify";
            this.xEditGridCell27.CellWidth = 68;
            this.xEditGridCell27.Col = 5;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpkJinryo_pre_date
            // 
            resources.ApplyResources(this.dpkJinryo_pre_date, "dpkJinryo_pre_date");
            this.dpkJinryo_pre_date.Name = "dpkJinryo_pre_date";
            this.dpkJinryo_pre_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkJinryo_pre_date_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Name = "xLabel5";
            // 
            // xButtonList1
            // 
            this.xButtonList1.IsVisibleReset = false;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // cboJinryo_pre_time
            // 
            resources.ApplyResources(this.cboJinryo_pre_time, "cboJinryo_pre_time");
            this.cboJinryo_pre_time.Name = "cboJinryo_pre_time";
            this.cboJinryo_pre_time.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboJinryo_pre_time_DataValidating);
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layTerm
            // 
            this.layTerm.ExecuteQuery = null;
            this.layTerm.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layTerm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTerm.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "am_start";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "am_end";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "pm_start";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pm_end";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "avg_time";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // frmModifyReser
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cboJinryo_pre_time);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.xLabel5);
            this.Controls.Add(this.dpkJinryo_pre_date);
            this.Controls.Add(this.grdRES1001);
            this.Name = "frmModifyReser";
            this.Load += new System.EventHandler(this.frmModifyReser_Load);
            this.Controls.SetChildIndex(this.grdRES1001, 0);
            this.Controls.SetChildIndex(this.dpkJinryo_pre_date, 0);
            this.Controls.SetChildIndex(this.xLabel5, 0);
            this.Controls.SetChildIndex(this.xButtonList1, 0);
            this.Controls.SetChildIndex(this.cboJinryo_pre_time, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdRES1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTerm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        #region [Form]
        
        private void frmModifyReser_Load(object sender, System.EventArgs e)
        {
            //this.grdRES1001.SavePerformer = new XSavePerformer(this);
            PostCallHelper.PostCall(new PostMethod(PostLoad));

            this.layCommon.ParamList = CreateLayCommonParam();
            this.layCommon.ExecuteQuery = QueryLayCommon;
        }


        private void PostLoad()
        {
            SetModifyData(modifyRow);
        }

        #endregion

        #region [properties]

        public DataRow rowModify
        {
            get
            {
                return modifyRow;
            }
            set
            {
                modifyRow = value;
            }
        }
        
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {                
                case FunctionType.Process:
                    e.IsBaseCall = false;

                    mbxMsg = NetInfo.Language == LangMode.Jr ? "該当患者の再診予約を変更しますか？" : "해당 환자의 재진예약을 변경하시겠습니까?";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "再診予約変更可否" : "재진예약변경여부";
                    DialogResult dialogResult = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNoCancel);

                    if (dialogResult == DialogResult.Cancel) 
                        return;

                    #region deleted by Cloud
                    //if (this.grdRES1001.SaveLayout())
                    //{
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? "再診予約変更が完了しました。" : "저장이 완료되었습니다.";                        
                    //    this.DialogResult = DialogResult.OK;                        
                    //}
                    //else
                    //{
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? "再診予約変更に失敗しました。" : "저장이 실패하였습니다."; 
                    //    mbxMsg = mbxMsg + Service.ErrMsg;
                    //    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    //    XMessageBox.Show(mbxMsg, mbxCap);
                    //    this.DialogResult = DialogResult.Cancel;
                    //}
                    #endregion

                    // Updated by Cloud
                    RES1001U00FrmModifySaveLayoutArgs args = new RES1001U00FrmModifySaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = GetListDataForSaveLayout();
                    args.HospCodeLink = this.mHospCodeLink;
                    RES1001U00FrmModifySaveLayoutResult res = CloudService.Instance.Submit<RES1001U00FrmModifySaveLayoutResult,
                        RES1001U00FrmModifySaveLayoutArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        switch (res.ErrCode)
                        {
                            case "1":
                                XMessageBox.Show("予約時間[" + res.DoctorName + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "2":
                                XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "3":
                                XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "4":
                                XMessageBox.Show("受付番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "5":
                                XMessageBox.Show("予約時間[" + res.DoctorName + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "6":
                                XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "7":
                                XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "8":
                                XMessageBox.Show("受付番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "9":
                                XMessageBox.Show("オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。", "注意", MessageBoxIcon.Warning);
                                break;
                            case "10":
                                XMessageBox.Show("オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。", "注意", MessageBoxIcon.Warning);
                                break;
                            default:
                                break;
                        }

                        if (string.IsNullOrEmpty(res.ErrCode))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "再診予約変更が完了しました。" : "저장이 완료되었습니다.";
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "再診予約変更に失敗しました。" : "저장이 실패하였습니다.";
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }

                    break;
                case FunctionType.Close:

                    this.DialogResult = DialogResult.Cancel;
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [Combo 생성]

        private void CreateTimeCombo(string aDoctor, string aJinryo_pre_date)
        {
            IHIS.Framework.MultiLayout layCombo = new MultiLayout();

            //진료과별 의사
            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("time_name", DataType.String);
            layCombo.LayoutItems.Add("time", DataType.String);
            layCombo.InitializeLayoutTable();


            /*
            layCombo.QuerySQL = @"SELECT SUBSTR(B.TIME, 1, 2)||':'||SUBSTR(B.TIME, 3, 2) TIME_NAME, B.TIME
                                   FROM RES0102 A, RES0106 B                                   
                                  WHERE A.HOSP_CODE = :f_hosp_code
                                    AND B.HOSP_CODE = A.HOSP_CODE
                                    AND NVL(A.JINRYO_BREAK_YN, 'N') = 'N'
                                    AND A.DOCTOR    = :f_doctor  
                                    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                                    AND B.TIME_TERM = A.AVG_TIME                                                                
                                    AND B.TIME              >= DECODE(TO_CHAR(TO_DATE(:f_date, 'YYYY/MM/DD'),'D'),
                                                                  '1',  A.RES_AM_START_HHMM1,
                                                                  '2',  A.RES_AM_START_HHMM2,
                                                                  '3',  A.RES_AM_START_HHMM3,
                                                                  '4',  A.RES_AM_START_HHMM4,
                                                                  '5',  A.RES_AM_START_HHMM5,
                                                                  '6',  A.RES_AM_START_HHMM6,
                                                                  '7',  A.RES_AM_START_HHMM7 )                    
                                    AND B.TIME              <= DECODE(TO_CHAR(TO_DATE(:f_date, 'YYYY/MM/DD'),'D'),
                                                                  '1',  A.RES_AM_END_HHMM1,
                                                                  '2',  A.RES_AM_END_HHMM2,
                                                                  '3',  A.RES_AM_END_HHMM3,
                                                                  '4',  A.RES_AM_END_HHMM4,
                                                                  '5',  A.RES_AM_END_HHMM5,
                                                                  '6',  A.RES_AM_END_HHMM6,
                                                                  '7',  A.RES_AM_END_HHMM7 )  
                                                                  
                                  UNION                        
                                 SELECT SUBSTR(B.TIME, 1, 2)||':'||SUBSTR(B.TIME, 3, 2) TIME_NAME, B.TIME 
                                   FROM RES0102 A, RES0106 B                                   
                                  WHERE A.HOSP_CODE = :f_hosp_code
                                    AND B.HOSP_CODE = A.HOSP_CODE
                                    AND NVL(A.JINRYO_BREAK_YN, 'N') = 'N'
                                    AND A.DOCTOR    = :f_doctor 
                                    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                                    AND B.TIME_TERM = A.AVG_TIME                                   
                                    AND B.TIME              >= DECODE(TO_CHAR(TO_DATE(:f_date, 'YYYY/MM/DD'),'D'),
                                                                  '1',  A.RES_PM_START_HHMM1,
                                                                  '2',  A.RES_PM_START_HHMM2,
                                                                  '3',  A.RES_PM_START_HHMM3,
                                                                  '4',  A.RES_PM_START_HHMM4,
                                                                  '5',  A.RES_PM_START_HHMM5,
                                                                  '6',  A.RES_PM_START_HHMM6,
                                                                  '7',  A.RES_PM_START_HHMM7 )                  
                                    AND B.TIME              <= DECODE(TO_CHAR(TO_DATE(:f_date, 'YYYY/MM/DD'),'D'),
                                                                  '1',  A.RES_PM_END_HHMM1,
                                                                  '2',  A.RES_PM_END_HHMM2,
                                                                  '3',  A.RES_PM_END_HHMM3,
                                                                  '4',  A.RES_PM_END_HHMM4,
                                                                  '5',  A.RES_PM_END_HHMM5,
                                                                  '6',  A.RES_PM_END_HHMM6,
                                                                  '7',  A.RES_PM_END_HHMM7 )
                                 ORDER BY 2";
            
            layCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCombo.SetBindVarValue("f_doctor", aDoctor);
            layCombo.SetBindVarValue("f_date", aJinryo_pre_date);
             

            /*
            if (layCombo.QueryLayout(true) && layCombo.RowCount > 0)
            {
                cboJinryo_pre_time.SetComboItems(layCombo.LayoutTable, "time_name", "time");
                cboJinryo_pre_time.SelectedIndex = 0;
            }
             */
            

            if (dpkJinryo_pre_date.GetDataValue() == "")
            {
                dpkJinryo_pre_date.SetDataValue(EnvironInfo.GetSysDate());
            }

            DateTime date = DateTime.Parse(aJinryo_pre_date);

            int intweek = date.DayOfWeek.GetHashCode() + 1;

            //TODO: thêm mới proto RES1001U00FrmModifyReserGrdRES1001Request
            GrdRES1001RequestPrepare(aDoctor, aJinryo_pre_date, intweek);

//            layTerm.QuerySQL = " SELECT TO_DATE(NVL(RES_AM_START_HHMM" + intweek + ",'0000'),'hh24mi') AS AM_START, "
//                                    + " TO_DATE(NVL(RES_AM_END_HHMM" + intweek + ",'0000'),'hh24mi') AS AM_END  , "
//                                    + " TO_DATE(NVL(RES_PM_START_HHMM" + intweek + ",'0000'),'hh24mi') AS PM_START, "
//                                    + " TO_DATE(NVL(RES_PM_END_HHMM" + intweek + ",'0000'),'hh24mi') AS PM_END  , "
//                                    +  " AVG_TIME "
//                                    + @" FROM RES0102 
//                                         WHERE HOSP_CODE = :f_hosp_code
//                                          AND DOCTOR = :f_doctor
//                                          AND :f_date BETWEEN START_DATE AND END_DATE";


//            layTerm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            layTerm.SetBindVarValue("f_doctor", aDoctor);
//            layTerm.SetBindVarValue("f_date", aJinryo_pre_date);

            

            if (layTerm.QueryLayout(false) && layTerm.RowCount > 0)
            {
                DateTime startTime = DateTime.Parse(layTerm.GetItemValue(0, "am_start").ToString());
                DateTime endTime = DateTime.Parse(layTerm.GetItemValue(0, "am_end").ToString());

                int term = layTerm.GetItemInt(0, "avg_time");

                // 오전시간표 생성

                int rownum = 0;

                for (; startTime < endTime; startTime = startTime.AddMinutes(term))
                {
                    rownum = layCombo.InsertRow(-1);
                    layCombo.SetItemValue(rownum, "time_name", startTime.ToString("HH:mm"));
                    layCombo.SetItemValue(rownum, "time", startTime.ToString("HHmm"));

                }


                if (layCombo.RowCount > 0)
                {
                    cboJinryo_pre_time.SetComboItems(layCombo.LayoutTable, "time_name", "time");
                    cboJinryo_pre_time.SelectedIndex = 0;
                }


                // 오후시간표 생성
                startTime = DateTime.Parse(layTerm.GetItemValue(0, "pm_start").ToString());
                endTime = DateTime.Parse(layTerm.GetItemValue(0, "pm_end").ToString());

                for (; startTime < endTime; startTime = startTime.AddMinutes(term))
                {
                    rownum = layCombo.InsertRow(-1);
                    layCombo.SetItemValue(rownum, "time_name", startTime.ToString("HH:mm"));
                    layCombo.SetItemValue(rownum, "time", startTime.ToString("HHmm"));
                }


                if (layCombo.RowCount > 0)
                {
                    cboJinryo_pre_time.SetComboItems(layCombo.LayoutTable, "time_name", "time");
                    cboJinryo_pre_time.SelectedIndex = 0;
                }



            }           
            
        }

       

        #endregion

        #region [Function]

        private bool CheckCanReser(string aJinryo_pre_date, string aJinryo_pre_time, string doctor)
        {
            bool chkCan = false;

            this.layCommon.Reset();
            //TODO: thay băng NuroRES1001U00DoctorExamStatusRequest
            LayCommonRequestPrepare(aJinryo_pre_date, aJinryo_pre_time, doctor);


            //layCommon.QuerySQL = ""
            //    + " SELECT FN_OUT_CHECK_DOCTOR_JINRYO('RES', TO_DATE('" + aJinryo_pre_date + "', 'YYYY/MM/DD'), '" + aJinryo_pre_time + "', '" + doctor + "') "
            //    + "   FROM DUAL ";

            layCommon.LayoutItems.Clear();
            layCommon.LayoutItems.Add("can");
                    
            if(this.layCommon.QueryLayout())
            {
                if(!TypeCheck.IsNull(layCommon.GetItemValue("can")))
                {
                    if (layCommon.GetItemValue("can").ToString() == "0")
                        chkCan = true;
                    else if (layCommon.GetItemValue("can").ToString() == "9")
                        chkCan = false;
                    else
                        chkCan = false;
                }
            }
            else
                chkCan = false;            

            return chkCan;
        }

        

        private void SetModifyData(DataRow row)
        {
            grdRES1001.LayoutTable.ImportRow(row);
            grdRES1001.DisplayData();
            
            mJinryo_pre_date = grdRES1001.GetItemString(0, "jinryo_pre_date");
            mJinryo_pre_time = grdRES1001.GetItemString(0, "jinryo_pre_time");

            CreateTimeCombo(grdRES1001.GetItemString(0, "doctor"), mJinryo_pre_date);

            dpkJinryo_pre_date.SetDataValue(mJinryo_pre_date);
            dpkJinryo_pre_date.Focus();
            dpkJinryo_pre_date.SelectAll();

            cboJinryo_pre_time.SetDataValue(mJinryo_pre_time);
        }

        #endregion

        #region [Control Event]

        private void dpkJinryo_pre_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {            
            if(TypeCheck.IsDateTime(e.DataValue))
            {
                string doctor          = this.grdRES1001.GetItemString(0, "doctor");
                string jinryo_pre_time = cboJinryo_pre_time.SelectedText;
                
                /////////////////////////////////////////////////////////////////////////
                //날짜변경시 콤보박스 다시 설정하기
                CreateTimeCombo(doctor, e.DataValue);
                this.cboJinryo_pre_time.Text = jinryo_pre_time;

                /////////////////////////////////////////////////////////////////////////
                
                if(!CheckCanReser(e.DataValue, jinryo_pre_time, doctor))
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "日付が正確ではありません. ご確認ください." : "일자가 정확하지않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";                    
                    XMessageBox.Show(mbxMsg, mbxCap);

                    dpkJinryo_pre_date.SetDataValue(grdRES1001.GetItemString(0, "jinryo_pre_date"));
                }
                else
                    grdRES1001.SetItemValue(0, "jinryo_pre_date", e.DataValue);
                
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "日付が正確ではありません. ご確認ください." : "일자가 정확하지않습니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";                    
                XMessageBox.Show(mbxMsg, mbxCap);

                dpkJinryo_pre_date.SetDataValue(grdRES1001.GetItemString(0, "jinryo_pre_date"));
            }
        }
        
        #endregion

        #region [grdRES1001_PreSaveLayout]

        private void grdRES1001_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            string jinryo_pre_time = cboJinryo_pre_time.GetDataValue();
            string jinryo_pre_date = dpkJinryo_pre_date.GetDataValue();
            grdRES1001.SetItemValue(0, "jinryo_pre_date", jinryo_pre_date);
            grdRES1001.SetItemValue(0, "jinryo_pre_time", jinryo_pre_time);
        }
        #endregion

        private void cboJinryo_pre_time_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "") return;

            if (!TypeCheck.IsDateTime("2006/04/01 " + ((XComboBox)sender).Text))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "時間を確認してください。" : "시간을 확인하세요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
                ((XComboBox)sender).SetDataValue("");
                e.Cancel = true;
                return;
            }

            if ((int.Parse(e.DataValue) < this.AM_START_TIME || int.Parse(e.DataValue) > AM_END_TIME) &&
                (int.Parse(e.DataValue) < this.PM_START_TIME || int.Parse(e.DataValue) > PM_END_TIME))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "病院の営業時間外です。時間を確認してください。" : "시간을 확인하세요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
                ((XComboBox)sender).SetDataValue("");
                e.Cancel = true;
                return;
            }
            grdRES1001.SetItemValue(0, "jinryo_pre_time", e.DataValue);
        }

        // deleted by Cloud
        #region XSavePerformer

//        private class XSavePerformer : ISavePerformer
//        {
//            private frmModifyReser parent;

//            ArrayList input;
//            ArrayList output;

//            //string proc_gubun = "";


//            public XSavePerformer(frmModifyReser parent)
//            {
//                this.parent = parent;
//            }
//            /*
//            public bool Send_IF(string pkout1001, string proc_gubun)
//            {
//                ArrayList inputList = new ArrayList();
//                ArrayList outputList = new ArrayList();

//                inputList.Add(EnvironInfo.HospCode);
//                inputList.Add(pkout1001);
//                inputList.Add(proc_gubun);
//                inputList.Add("1");
//                inputList.Add("O");
//                inputList.Add(UserInfo.UserID);

//                if (!Service.ExecuteProcedure("PR_IFS_MAKE_YOYAKU", inputList, outputList))
//                {
//                    XMessageBox.Show("IFS1002 Make error" + Service.ErrFullMsg);
//                    return false;
//                }

//                if (TypeCheck.IsNull(outputList[0]))
//                {
//                    return false;
//                }

//                else
//                {
//                    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
//                    string msgText = "";

//                    msgText = "10111" + outputList[0].ToString();

//                    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
//                    if (ret == -1)
//                    {
//                        XMessageBox.Show("Reser data Send Error：" + msgText);
//                        return false;
//                    }
//                    return true;
//                }

//            }
//            */
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_gubun = null;
//                object doctor_name = null;
//                object t_chk = null;
//                object t_jubsu_no = null;

//                if (UserInfo.UserGubun == UserType.Doctor)
//                    item.BindVarList.Add("q_user_id", UserInfo.DoctorID);
//                else
//                    item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                //TODO: thay bằng NuroRES1001U00TypeRequest
//                /* 보험 종별 */
//                cmdText = @"SELECT Z.GUBUN
//                              FROM ( SELECT A.GUBUN
//                                       FROM OUT1001 A
//                                      WHERE A.HOSP_CODE   = :f_hosp_code
//                                        AND A.BUNHO       = :f_bunho
//                                        AND A.GWA         = :f_gwa
//                                        AND A.NAEWON_DATE = ( SELECT MAX(B.NAEWON_DATE)
//                                                                FROM OUT1001 B
//                                                               WHERE B.HOSP_CODE = A.HOSP_CODE
//                                                                 AND B.BUNHO     = A.BUNHO
//                                                                 AND B.GWA       = A.GWA ) ) Z
//                             WHERE ROWNUM = 1";

//                t_gubun = Service.ExecuteScalar(cmdText, item.BindVarList);

//                if (!TypeCheck.IsNull(t_gubun))
//                    item.BindVarList["f_gubun"].VarValue = t_gubun.ToString();
//                else
//                    item.BindVarList["f_gubun"].VarValue = "G1";

//                switch (item.RowState)
//                {
//                    case DataRowState.Added:
//                        //TODO: thay thế bằng NuroRES1001U00DoctorNameRequest
//                        /* 예약중복여부 */
//                        cmdText = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE) DOCTOR_NAME
//                                      FROM OUT1001 A
//                                     WHERE A.HOSP_CODE   = :f_hosp_code
//                                       AND A.RESER_YN    = 'Y'
//                                       AND A.BUNHO       = :f_bunho
//                                       AND A.GWA         = :f_gwa
//                                       AND A.NAEWON_DATE = :f_jinryo_pre_date
//                                       AND A.JUBSU_TIME  = :f_jinryo_pre_time
//                                       AND ROWNUM        = 1 ";

//                        doctor_name = Service.ExecuteScalar(cmdText, item.BindVarList);
                        

//                        if (!TypeCheck.IsNull(doctor_name))
//                        {
//                            XMessageBox.Show("予約時間[" + doctor_name.ToString() + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                            return false;
//                        }

//                        /* 예약가능여부를 check한다. */
//                        cmdText = @"SELECT FN_RES_CHECK_RESER_POSSIBLE(:f_doctor, :f_jinryo_pre_date, :f_jinryo_pre_time, :f_input_gubun) FROM DUAL";

//                        t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_chk))
//                        {
//                            if (t_chk.ToString().Equals("1"))
//                            {
//                                XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                                return false;
//                            }
//                            else if (t_chk.ToString().Equals("2"))
//                            {
//                                XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                                return false;
//                            }
//                        }
//                        //TODO: thay bằng NuroRES1001U00ReceptionNumberRequest
//                        cmdText = @"SELECT NVL(MAX(A.JUBSU_NO), 0) + 1 JUBSU_NO
//                                               FROM OUT1001 A
//                                              WHERE A.HOSP_CODE       = :f_hosp_code
//                                                AND A.BUNHO           = :f_bunho
//                                                AND A.NAEWON_DATE     = :f_jinryo_pre_date";

//                        t_jubsu_no = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (TypeCheck.IsNull(t_jubsu_no))
//                        {
//                            XMessageBox.Show("受付番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
//                            return false;
//                        }

//                        item.BindVarList.Add("t_jubsu_no", t_jubsu_no.ToString());

//                        /* 예약key 생성 */
//                        input = new ArrayList();
//                        output = new ArrayList();

//                        input.Add(item.BindVarList["f_jinryo_pre_date"].VarValue);
//                        input.Add(item.BindVarList["f_bunho"].VarValue);
//                        input.Add(item.BindVarList["f_gwa"].VarValue);
//                        input.Add(t_jubsu_no.ToString());
//                        //input.Add(item.BindVarList["f_hosp_code"].VarValue);
//                        //input.Add(item.BindVarList["f_seq"].VarValue);
//                        //input.Add(item.BindVarList["f_pkres1001"].VarValue);
//                        //input.Add(t_chk.ToString());

//                        //if (!Service.ExecuteProcedure("PR_OUT_MAKE_PKOUT1001", input, output))
//                        //{
//                        //    XMessageBox.Show("予約番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
//                        //    return false;
//                        //}

//                        //item.BindVarList.Add("t_seq", output[0].ToString());
//                        //item.BindVarList.Add("t_pkres1001", output[1].ToString());

////                        cmdText = @"SELECT MAX(NVL(V.SEQ,0))        SEQ
////                                         FROM ( SELECT MAX(NVL(A.JUBSU_NO,0)) SEQ
////                                                  FROM OUT1001 A
////                                                 WHERE A.HOSP_CODE   = :f_hosp_code
////                                                   AND A.BUNHO       = :f_bunho
////                                                   AND A.NAEWON_DATE = :f_naewon_date
////                                                   AND A.GWA         = :f_gwa
////                                                UNION
////                                                SELECT MAX(NVL(B.JUBSU_NO,0)) SEQ
////                                                  FROM OUT1011 B
////                                                 WHERE B.HOSP_CODE   = :f_hosp_code
////                                                   AND B.BUNHO       = :f_bunho
////                                                   AND B.NAEWON_DATE = :f_naewon_date
////                                                   AND B.GWA         = :f_gwa )";

////                        object seq = Service.ExecuteScalar(cmdText, item.BindVarList);

////                        if (!TypeCheck.IsNull(seq))
////                        {
////                            item.BindVarList.Add("t_seq", seq.ToString());
////                        }


//                        cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM DUAL";

//                        object t_res1001_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_res1001_seq))
//                        {
//                            item.BindVarList.Add("t_pkres1001", t_res1001_seq.ToString());
//                        }
                        

//                        //proc_gubun = "I";
//                        //TODO: thay bằng NuroRES1001U00ReservationOut1001InsertRequest
//                        cmdText = @"INSERT INTO OUT1001
//                                             ( SYS_DATE            , SYS_ID             , UPD_DATE       , UPD_ID         ,
//                                               HOSP_CODE           , PKOUT1001          , RESER_YN       ,
//                                               NAEWON_DATE         , BUNHO              , GWA            , 
//                                               GUBUN               , DOCTOR             , RES_CHANGGU    ,
//                                               JUBSU_TIME          , CHOJAE             , RES_GUBUN      , NAEWON_TYPE     ,
//                                               JUBSU_NO            , RES_INPUT_GUBUN    , NAEWON_YN      , JUBSU_GUBUN     )
//                                        VALUES
//                                             ( SYSDATE             , :q_user_id         , SYSDATE        , :q_user_id   , 
//                                               :f_hosp_code        , :f_pkout1001       , 'Y'
//                                               :f_jinryo_pre_date  , :f_bunho           , :f_gwa         , 
//                                               NVL(:f_gubun, 'G1') , :f_doctor          , :f_changgu   ,
//                                               :f_jinryo_pre_time  , :f_chojae          , :f_res_gubun   , '0'          ,
//                                               :t_jubsu_no         , :f_input_gubun     , 'N'            , '01'          )";
//                        break;

//                    case DataRowState.Modified:
//                        //TODO: thay bằng NuroRES1001U00DoctorNameRequest
//                        /* 예약중복여부 */
//                        cmdText = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE) DOCTOR_NAME
//                                      FROM OUT1001 A
//                                     WHERE A.HOSP_CODE   = :f_hosp_code
//                                       AND A.RESER_YN    = 'Y'
//                                       AND A.BUNHO       = :f_bunho
//                                       AND A.GWA         = :f_gwa
//                                       AND A.NAEWON_DATE = :f_jinryo_pre_date
//                                       AND A.JUBSU_TIME  = :f_jinryo_pre_time
//                                       AND ROWNUM        = 1 ";

//                        doctor_name = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(doctor_name))
//                        {
//                            XMessageBox.Show("予約時間[" + doctor_name.ToString() + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                            return false;
//                        }
//                        //TODO: NuroRES1001U00CheckingReservationRequest
//                        /* 예약가능여부를 check한다. */
//                        cmdText = @"SELECT FN_RES_CHECK_RESER_POSSIBLE(:f_doctor, :f_jinryo_pre_date, :f_jinryo_pre_time, :f_input_gubun) FROM DUAL";

//                        t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_chk))
//                        {
//                            if (t_chk.ToString().Equals("1"))
//                            {
//                                XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                                return false;
//                            }
//                            else if (t_chk.ToString().Equals("2"))
//                            {
//                                XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。", "注意", MessageBoxIcon.Warning);
//                                return false;
//                            }
//                        }
//                        //TODO: NuroRES1001U00ReceptionNumberRequest
//                        cmdText = @"SELECT NVL(MAX(A.JUBSU_NO), 0) + 1 JUBSU_NO
//                                               FROM OUT1001 A
//                                              WHERE A.HOSP_CODE   = :f_hosp_code
//                                                AND A.BUNHO       = :f_bunho
//                                                AND A.NAEWON_DATE = :f_jinryo_pre_date";

//                        t_jubsu_no = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (TypeCheck.IsNull(t_jubsu_no))
//                        {
//                            XMessageBox.Show("受付番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
//                            return false;
//                        }

//                        item.BindVarList.Add("t_jubsu_no", t_jubsu_no.ToString());

//                        /* 예약key 생성 */
//                        input = new ArrayList();
//                        output = new ArrayList();

//                        input.Add(item.BindVarList["f_jinryo_pre_date"].VarValue);
//                        input.Add(item.BindVarList["f_bunho"].VarValue);
//                        input.Add(item.BindVarList["f_gwa"].VarValue);
//                        input.Add(t_jubsu_no.ToString());
//                        //input.Add(item.BindVarList["f_seq"].VarValue);
//                        //input.Add(item.BindVarList["f_pkres1001"].VarValue);
//                        //input.Add(t_chk.ToString());

//                        //if (!Service.ExecuteProcedure("PR_OUT_MAKE_PKOUT1001", input, output))
//                        //{
//                        //    XMessageBox.Show("予約番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
//                        //    return false;
//                        //}

//                        //item.BindVarList.Add("t_seq", output[0].ToString());
//                        //item.BindVarList.Add("t_pkres1001", output[1].ToString());

////                        cmdText = @"SELECT MAX(NVL(V.SEQ,0))        SEQ
////                                         FROM ( SELECT MAX(NVL(A.JUBSU_NO,0)) SEQ
////                                                  FROM OUT1001 A
////                                                 WHERE A.HOSP_CODE   = :f_hosp_code
////                                                   AND A.BUNHO       = :f_bunho
////                                                   AND A.NAEWON_DATE = :f_naewon_date
////                                                   AND A.GWA         = :f_gwa
////                                                UNION
////                                                SELECT MAX(NVL(B.JUBSU_NO,0)) SEQ
////                                                  FROM OUT1011 B
////                                                 WHERE B.HOSP_CODE   = :f_hosp_code
////                                                   AND B.BUNHO       = :f_bunho
////                                                   AND B.NAEWON_DATE = :f_naewon_date
////                                                   AND B.GWA         = :f_gwa ) ";

////                        seq = Service.ExecuteScalar(cmdText, item.BindVarList);

////                        if (!TypeCheck.IsNull(seq))
////                        {
////                            item.BindVarList.Add("t_seq", seq.ToString());
////                        }

//                        //TODO: NuroOUT1001U01GetOut1001SeqRequest
//                        cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM DUAL";

//                        t_res1001_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_res1001_seq))
//                        {
//                            item.BindVarList.Add("t_pkres1001", t_res1001_seq.ToString());
//                        }


//                        if (item.BindVarList["f_newrow"].VarValue.Equals("Y"))
//                        {
//                            //proc_gubun = "I";
//                            //TODO: NuroRES1001U00ReservationOut1001InsertRequest
//                            cmdText = @"INSERT INTO OUT1001
//                                             ( SYS_DATE            , SYS_ID             , UPD_DATE       , UPD_ID         ,
//                                               HOSP_CODE           , PKOUT1001          , RESER_YN       ,
//                                               NAEWON_DATE         , BUNHO              , GWA            , 
//                                               GUBUN               , DOCTOR             , RES_CHANGGU    ,
//                                               JUBSU_TIME          , CHOJAE             , RES_GUBUN      , NAEWON_TYPE    ,
//                                               JUBSU_NO            , RES_INPUT_GUBUN    , NAEWON_YN      , JUBSU_GUBUN        )
//                                        VALUES
//                                             ( SYSDATE             , :q_user_id         , SYSDATE        , :q_user_id   , 
//                                               :f_hosp_code        , :t_pkres1001       , 'Y'            ,  
//                                               :f_jinryo_pre_date  , :f_bunho           , :f_gwa         , 
//                                               NVL(:f_gubun, 'G1') , :f_doctor          , :f_changgu     ,
//                                               :f_jinryo_pre_time  , :f_chojae          , :f_res_gubun   , '0'          ,
//                                               :t_jubsu_no         , :f_input_gubun     , 'N'            , '01'          )";
//                        }
//                        else
//                        {

//                            /* 처방존재여부 */
//                            t_chk = null;
//                            //TODO: NuroRES1001U00CheckingHangmogCodeRequest
//                            cmdText = @"SELECT DECODE(SIGN(COUNT(HANGMOG_CODE)), 1, 'Y', 'N')
//                                          FROM OCS1003
//                                         WHERE HOSP_CODE   = :f_hosp_code
//                                           AND BUNHO       = :f_bunho
//                                           --AND NAEWON_DATE = :f_jinryo_pre_date
//                                           AND ORDER_DATE  = :f_jinryo_pre_date
//                                           AND GWA         = :f_gwa
//                                           AND DOCTOR      = :f_doctor
//                                           AND NAEWON_TYPE = '0'";

//                            t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                            if (!TypeCheck.IsNull(t_chk))
//                            {
//                                if (!t_chk.ToString().Equals("N"))
//                                {
//                                    XMessageBox.Show("オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。", "注意", MessageBoxIcon.Warning);
//                                    return false;
//                                }
//                            }

//                            //proc_gubun = "U";
//                            //TODO: sửa NuroRES1001U00ReservationOut1001UpdateRequest, thêm input PKOUT1001
//                            cmdText = @"UPDATE OUT1001
//                                           SET UPD_ID          = :q_user_id        ,
//                                               UPD_DATE        = SYSDATE           ,
//                                               PKOUT1001       = :t_pkres1001      ,
//                                               --SEQ             = :f_seq            ,
//                                               NAEWON_DATE     = :f_jinryo_pre_date,
//                                               JUBSU_TIME      = :f_jinryo_pre_time,
//                                               JUBSU_NO        = :t_jubsu_no
//                                         WHERE HOSP_CODE       = :f_hosp_code
//                                           AND PKOUT1001       = :f_pkres1001";
//                        }
//                        break;

//                    case DataRowState.Deleted:

//                        /* 처방존재여부 */
//                        t_chk = null;
//                        //TODO: NuroRES1001U00CheckingHangmogCodeRequest
//                        cmdText = @"SELECT DECODE(SIGN(COUNT(HANGMOG_CODE)), 1, 'Y', 'N')
//                                          FROM OCS1003
//                                         WHERE HOSP_CODE   = :f_hosp_code
//                                           AND BUNHO       = :f_bunho
//                                           --AND NAEWON_DATE = :f_jinryo_pre_date
//                                           AND ORDER_DATE  = :f_jinryo_pre_date
//                                           AND GWA         = :f_gwa
//                                           AND DOCTOR      = :f_doctor
//                                           AND NAEWON_TYPE = '0'";

//                        t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                        if (!TypeCheck.IsNull(t_chk))
//                        {
//                            if (!t_chk.ToString().Equals("N"))
//                            {
//                                XMessageBox.Show("オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。", "注意", MessageBoxIcon.Warning);
//                                return false;
//                            }
//                        }
//                        //TODO:NuroRES1001U00ReservationOut1001DeleteRequest
//                        cmdText = @"DELETE FROM OUT1001
//                                     WHERE HOSP_CODE   = :f_hosp_code
//                                       AND PKOUT1001   = :f_pkres1001";

//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion 

        #region Dzung TA sua theo luong moi
        /// <summary>
        /// Prepare parameters for RES1001U00FrmModifyReserGrdRES1001Args call.
        /// </summary>
        /// <param name="aDoctor"></param>
        /// <param name="aJinryo_pre_date"></param>
        /// <param name="intweek"></param>
        private void GrdRES1001RequestPrepare(string aDoctor, string aJinryo_pre_date, int intweek)
        {
            layTerm.ParamList = CreateGrdRES1001Param();
            layTerm.ExecuteQuery = QueryGrdRES1001;
            layTerm.SetBindVarValue("intweek", intweek.ToString());
            layTerm.SetBindVarValue("f_date", aJinryo_pre_date);
            layTerm.SetBindVarValue("f_doctor", aDoctor);
        }

        private IList<object[]> QueryGrdRES1001(BindVarCollection varList)
        {
            RES1001U00FrmModifyReserGrdRES1001Args frmModifyReserGrdRES1001Args = new RES1001U00FrmModifyReserGrdRES1001Args();
            frmModifyReserGrdRES1001Args.DayOfWeek = varList["intweek"].VarValue;
            frmModifyReserGrdRES1001Args.Date = varList["f_date"].VarValue;
            frmModifyReserGrdRES1001Args.Doctor = varList["f_doctor"].VarValue;
            frmModifyReserGrdRES1001Args.HospCodeLink = this.mHospCodeLink;
            frmModifyReserGrdRES1001Args.TabIsAll = this.tabIsAll;
            RES1001U00FrmModifyReserGrdRES1001Result frmModifyReserGrdRES1001Res = CloudService.Instance.Submit<RES1001U00FrmModifyReserGrdRES1001Result, RES1001U00FrmModifyReserGrdRES1001Args>(frmModifyReserGrdRES1001Args);

            List<object[]> res = new List<object[]>();
            if (frmModifyReserGrdRES1001Res != null)
            {
                foreach (RES1001U00FrmModifyReserGrdRES1001Info item in frmModifyReserGrdRES1001Res.GrdRes1001Info)
                {
                    object[] cboItem =
                            {
                                item.AmEnd,
                                item.AmStart,
                                item.AvgTime,
                                item.PmEnd,
                                item.PmStart
                            };
                    res.Add(cboItem);
                }
            }

            return res;
        }

        private List<string> CreateGrdRES1001Param()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_doctor");
            paramList.Add("f_date");
            paramList.Add("intweek");
            return paramList;
        }

        /// <summary>
        /// Prepare parameters for NuroRES1001U00DoctorExamStatusArgs
        /// </summary>
        /// <param name="aJinryo_pre_date"></param>
        /// <param name="aJinryo_pre_time"></param>
        /// <param name="doctor"></param>
        private void LayCommonRequestPrepare(string aJinryo_pre_date, string aJinryo_pre_time, string doctor)
        {
            layCommon.ParamList = CreateLayCommonParam();
            layCommon.ExecuteQuery = QueryLayCommon;
            layCommon.SetBindVarValue("doctor", doctor);
            layCommon.SetBindVarValue("aJinryo_pre_date", aJinryo_pre_date);
            layCommon.SetBindVarValue("aJinryo_pre_time", aJinryo_pre_time);
        }

        private IList<object[]> QueryLayCommon(BindVarCollection varList)
        {
            NuroRES1001U00DoctorExamStatusArgs nuroRes1001U00DoctorExamStatusArgs = new NuroRES1001U00DoctorExamStatusArgs();
            nuroRes1001U00DoctorExamStatusArgs.DoctorCode = varList["doctor"].VarValue;
            nuroRes1001U00DoctorExamStatusArgs.ExamPreDate = varList["aJinryo_pre_date"].VarValue;
            nuroRes1001U00DoctorExamStatusArgs.ExamPreTime = varList["aJinryo_pre_time"].VarValue;
            nuroRes1001U00DoctorExamStatusArgs.Type = "RES";
            nuroRes1001U00DoctorExamStatusArgs.HospCodeLink = this.mHospCodeLink;
            nuroRes1001U00DoctorExamStatusArgs.TabIsAll = this.tabIsAll;

            NuroRES1001U00DoctorExamStatusResult nuroRES1001U00DoctorExamStatusResult = CloudService.Instance.Submit<NuroRES1001U00DoctorExamStatusResult, NuroRES1001U00DoctorExamStatusArgs>(nuroRes1001U00DoctorExamStatusArgs);

            List<object[]> res = new List<object[]>();
            if (nuroRES1001U00DoctorExamStatusResult != null)
            {
                object[] cboItem =
                {
                    nuroRES1001U00DoctorExamStatusResult.DoctorExamStatus
                };
                res.Add(cboItem);
            }

            return res;
        }

        private List<string> CreateLayCommonParam()
        {
            List<string> paramList = new List<string>();
            paramList.Add("doctor");
            paramList.Add("aJinryo_pre_date");
            paramList.Add("aJinryo_pre_time");
            return paramList;
        }
        #endregion

        #region Cloud updated

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<RES1001U00FrmModifySaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<RES1001U00FrmModifySaveLayoutInfo> lstData = new List<RES1001U00FrmModifySaveLayoutInfo>();

            for (int i = 0; i < grdRES1001.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdRES1001.GetRowState(i) == DataRowState.Unchanged) continue;

                RES1001U00FrmModifySaveLayoutInfo item = new RES1001U00FrmModifySaveLayoutInfo();

                item.Bunho                      = grdRES1001.GetItemString(i, "bunho");
                item.Changgu                    = grdRES1001.GetItemString(i, "changgu");
                item.Chojae                     = grdRES1001.GetItemString(i, "chojae");
                item.Doctor                     = grdRES1001.GetItemString(i, "doctor");
                item.Gubun                      = grdRES1001.GetItemString(i, "gubun");
                item.Gwa                        = grdRES1001.GetItemString(i, "gwa");
                item.InputGubun                 = grdRES1001.GetItemString(i, "input_gubun");
                item.JinryoPreDate              = grdRES1001.GetItemString(i, "jinryo_pre_date");
                item.JinryoPreTime              = grdRES1001.GetItemString(i, "jinryo_pre_time");
                //item.JubsuNo                  = grdRES1001.GetItemString(i, "jubsu_no");
                item.Newrow                     = grdRES1001.GetItemString(i, "newrow");
                item.Pkout1001                  = grdRES1001.GetItemString(i, "pkout1001");
                item.Pkres1001                  = grdRES1001.GetItemString(i, "pkres1001");
                item.ResGubun                   = grdRES1001.GetItemString(i, "res_gubun");
                item.RowState                   = grdRES1001.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdRES1001.DeletedRowTable)
            {
                for (int i = 0; i < grdRES1001.DeletedRowTable.Rows.Count; i++)
                {
                    RES1001U00FrmModifySaveLayoutInfo item = new RES1001U00FrmModifySaveLayoutInfo();

                    item.Bunho                      = grdRES1001.DeletedRowTable.Rows[i]["bunho"].ToString();
                    item.Doctor                     = grdRES1001.DeletedRowTable.Rows[i]["doctor"].ToString();
                    item.Gwa                        = grdRES1001.DeletedRowTable.Rows[i]["gwa"].ToString();
                    item.JinryoPreDate              = grdRES1001.DeletedRowTable.Rows[i]["jinryo_pre_date"].ToString();
                    item.Pkres1001                  = grdRES1001.DeletedRowTable.Rows[i]["pkres1001"].ToString();
                    item.RowState                   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion
    }
}

