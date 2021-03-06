using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using IHIS.CLIS.CLIS2015U04.Properties;
using IHIS.CLIS.Properties;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Clis;
using IHIS.CloudConnector.Contracts.Results.Clis;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Clis;


namespace IHIS.CLIS
{
    public partial class CLIS2015U04 : IHIS.Framework.XScreen
    {
        #region AutoGenCode     
        
        private XPanel xPanel1;
        private XPanel xPanel2;
        private XPanel xPanel3;
        private XPanel xPanel4;
        private XMstGrid grdProtocol;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XMstGrid grdPatientList;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XMstGrid grdPatientStatus;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private SingleLayout layPaInfo;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XButtonList xButtonList1;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIS2015U04));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdProtocol = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPatientList = new IHIS.Framework.XMstGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdPatientStatus = new IHIS.Framework.XMstGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.layPaInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientStatus)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.grdProtocol);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdProtocol
            // 
            resources.ApplyResources(this.grdProtocol, "grdProtocol");
            this.grdProtocol.ApplyPaintEventToAllColumn = true;
            this.grdProtocol.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdProtocol.ColPerLine = 4;
            this.grdProtocol.Cols = 5;
            this.grdProtocol.ControlBinding = true;
            this.grdProtocol.ExecuteQuery = null;
            this.grdProtocol.FixedCols = 1;
            this.grdProtocol.FixedRows = 1;
            this.grdProtocol.HeaderHeights.Add(21);
            this.grdProtocol.Name = "grdProtocol";
            this.grdProtocol.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdProtocol.ParamList")));
            this.grdProtocol.RowHeaderVisible = true;
            this.grdProtocol.Rows = 2;
            this.grdProtocol.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdProtocol.ToolTipActive = true;
            this.grdProtocol.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdProtocol_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "protocol_id";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "protocolcode";
            this.xEditGridCell2.CellWidth = 107;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "Protocolname";
            this.xEditGridCell3.CellWidth = 108;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "Startdate";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "Enddate";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 92;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdPatientList);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdPatientList
            // 
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.ApplyPaintEventToAllColumn = true;
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell11});
            this.grdPatientList.ColPerLine = 2;
            this.grdPatientList.Cols = 3;
            this.grdPatientList.ControlBinding = true;
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedCols = 1;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(20);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.RowHeaderVisible = true;
            this.grdPatientList.Rows = 2;
            this.grdPatientList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdPatientList_GridFindClick);
            this.grdPatientList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPatientList_RowFocusChanged);
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "Patientcode";
            this.xEditGridCell6.CellWidth = 85;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "Patientname";
            this.xEditGridCell7.CellWidth = 94;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "Patient_id";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdPatientStatus);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdPatientStatus
            // 
            resources.ApplyResources(this.grdPatientStatus, "grdPatientStatus");
            this.grdPatientStatus.ApplyPaintEventToAllColumn = true;
            this.grdPatientStatus.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell12,
            this.xEditGridCell10,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell9,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdPatientStatus.ColPerLine = 3;
            this.grdPatientStatus.Cols = 4;
            this.grdPatientStatus.ControlBinding = true;
            this.grdPatientStatus.ExecuteQuery = null;
            this.grdPatientStatus.FixedCols = 1;
            this.grdPatientStatus.FixedRows = 1;
            this.grdPatientStatus.HeaderHeights.Add(21);
            this.grdPatientStatus.Name = "grdPatientStatus";
            this.grdPatientStatus.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientStatus.ParamList")));
            this.grdPatientStatus.RowHeaderVisible = true;
            this.grdPatientStatus.Rows = 2;
            this.grdPatientStatus.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPatientStatus.ToolTipActive = true;
            this.grdPatientStatus.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientStatus_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "Updatedate";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 81;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "codename";
            this.xEditGridCell12.CellWidth = 117;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "Note";
            this.xEditGridCell10.CellWidth = 39;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sort_no";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "sort_id";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "updated";
            this.xEditGridCell9.CellWidth = 106;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "patientstatusid";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "code";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "protocolpatientid";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.xButtonList1);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // layPaInfo
            // 
            this.layPaInfo.ExecuteQuery = null;
            this.layPaInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17});
            this.layPaInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPaInfo.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "SuName";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "SuName2";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "Sex";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "YearAge";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "MonthAge";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "Gubun";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "GubunName";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "Birth";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "Tel";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "Tel1";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "TelHP";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "Email";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "Zip1";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "Zip2";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "Address1";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "Address2";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "InHospital";
            // 
            // CLIS2015U04
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "CLIS2015U04";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CLIS2015U04_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientStatus)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public CLIS2015U04()
        {
            InitializeComponent();
            //set Param List
            grdPatientList.ParamList = new List<string>(new string[] {"f_clis_protocol_id"});
            grdPatientStatus.ParamList = new List<string>(new String[] {"f_protocol_patient_id"});
            //executeGrid
            grdProtocol.ExecuteQuery = LoadProtocol;
            grdPatientList.ExecuteQuery = LoadPatientList;
            grdPatientStatus.ExecuteQuery = LoadPatienStatus;
        }

        /// <summary>
        /// Clean resource
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        #region CloudServices
        
        private List<object[]> LoadPatientList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U04GetPatientListItemArgs args = new CLIS2015U04GetPatientListItemArgs();
            args.ClisProtocolId = bc["f_clis_protocol_id"] != null ? bc["f_clis_protocol_id"].VarValue : "";
            CLIS2015U04GetPatientListItemResult result = CloudService.Instance.Submit<CLIS2015U04GetPatientListItemResult, CLIS2015U04GetPatientListItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U04GetPatientListItemInfo info in result.Num)
                {
                    object[] objects =
                    {
                        info.Bunho,
                        info.Suname,
                        info.ProtocolPatientId,
                        info.Suname2
                    };
                    res.Add(objects);
                }   
            }
            return res;
            
        }
        private List<object[]> LoadPatienStatus(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U04GetPatientStatusListItemArgs args = new CLIS2015U04GetPatientStatusListItemArgs();
            args.ProtocolPatientId = bc["f_protocol_patient_id"] != null ? bc["f_protocol_patient_id"].VarValue : "";
            if (string.IsNullOrEmpty(args.ProtocolPatientId))
            {
                return res;
            }
            CLIS2015U04GetPatientStatusListItemResult result = CloudService.Instance.Submit<CLIS2015U04GetPatientStatusListItemResult, CLIS2015U04GetPatientStatusListItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U04GetPatientStatusListItemInfo info in result.Num)
                {
                    object[] objects =
                    {
                        info.UpdateDate,
                        info.CodeName,
                        info.Description,
                        info.SortNo,
                        info.SysId,
                        info.Updated,
                        info.PatientStatusId,
                        info.Code,
                        info.ProtocolPatientId
                    };
                    res.Add(objects);
                }
            }
            return res;
        }
        private List<object[]> LoadProtocol(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U04GetProtocolItemArgs args = new CLIS2015U04GetProtocolItemArgs();
            CLIS2015U04GetProtocolItemResult result = CloudService.Instance.Submit<CLIS2015U04GetProtocolItemResult, CLIS2015U04GetProtocolItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U04GetProtocolItemInfo info in result.Num)
                {
                    object[] objects =
                    {
                        info.ClisProtocolId,
                        info.ProtocolCode,
                        info.ProtocolName,
                        info.StartDate,
                        info.EndDate
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveGrdPatientStatus()
        {
            List<CLIS2015U04GetPatientStatusListItemInfo> inputList = GetListFromPatientSatusList();
            if (inputList.Count == 0)
                return true;
            CLIS2015U04UpdateStatusPatientItemArgs args = new CLIS2015U04UpdateStatusPatientItemArgs(inputList);            
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CLIS2015U04UpdateStatusPatientItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return true;
            }
            {
                return false; 
            }            
        }

        private List<CLIS2015U04GetPatientStatusListItemInfo> GetListFromPatientSatusList()
        {
            List<CLIS2015U04GetPatientStatusListItemInfo> dataList = new List<CLIS2015U04GetPatientStatusListItemInfo>();
            for (int i = 0; i < grdPatientStatus.RowCount; i ++)
            {
                if (grdPatientStatus.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                CLIS2015U04GetPatientStatusListItemInfo info = new CLIS2015U04GetPatientStatusListItemInfo();
                info.UpdateDate = grdPatientStatus.GetItemString(i, "Updatedate");
                info.CodeName = grdPatientStatus.GetItemString(i, "codename");
                info.Description = grdPatientStatus.GetItemString(i, "Note");
                info.PatientStatusId = grdPatientStatus.GetItemString(i, "patientstatusid");
                info.SortNo = grdPatientStatus.GetItemString(i, "sort_no");
                info.SysId = grdPatientStatus.GetItemString(i, "sort_id");
                info.Code = grdPatientStatus.GetItemString(i, "code");
                info.ProtocolPatientId = grdPatientStatus.GetItemString(i, "protocolpatientid");
                info.RowState = grdPatientStatus.GetRowState(i).ToString();
                dataList.Add(info);
            }
            return dataList;
        }

        #endregion
        
        #region ButtonClick
        
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                if (SaveGrdPatientStatus())
                {
                    XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.MSG_SAVE_SUCCESS_CAP, MessageBoxIcon.Information);
                }
                else
                {
                    XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.MSG_SAVE_ERROR_CAP, MessageBoxIcon.Error);
                }
                grdPatientStatus.QueryLayout(true);
                break;
            }
        }
        #endregion

        #region EventHandler

        private void CLIS2015U04_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            grdProtocol.QueryLayout(true);

            if (e.OpenParam != null && e.OpenParam.Contains("f_protocol_id"))
            {
                string protocolId = e.OpenParam["f_protocol_id"].ToString();

                //grdProtocol.SetFocusToItem(
                for (int i = 0; i < grdProtocol.RowCount; i++)
                {
                    if (grdProtocol.GetItemString(i, "protocol_id") == protocolId)
                    {
                        grdProtocol.SetFocusToItem(i, 0);
                        break;
                    }
                }
            }
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPatientList.SetBindVarValue("f_clis_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));
        }

        private void grdPatientStatus_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPatientStatus.SetBindVarValue("f_protocol_patient_id", grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "Patient_id"));
        }

        private void grdProtocol_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdPatientList.QueryLayout(true);
            grdPatientStatus.QueryLayout(true);
        }

        private void grdPatientList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdPatientStatus.QueryLayout(true);
        }

        private void grdPatientList_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            layPaInfo.ExecuteQuery = LayPaInfoGetPatientInfo;
            layPaInfo.QueryLayout();
            Patient paInfo = new Patient();
            paInfo.BunHo = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "Patientcode");
            paInfo.SuName	 = layPaInfo.GetItemValue("SuName").ToString();
            paInfo.SuName2	 = layPaInfo.GetItemValue("SuName2").ToString();
            paInfo.Sex	 = layPaInfo.GetItemValue("Sex").ToString();
            paInfo.YearAge	 = layPaInfo.GetItemValue("YearAge").ToString();
            paInfo.MonthAge	 = layPaInfo.GetItemValue("MonthAge").ToString();
            paInfo.Gubun	 = layPaInfo.GetItemValue("Gubun").ToString();
            paInfo.GubunName	= layPaInfo.GetItemValue("GubunName").ToString();
            paInfo.Birth	 = layPaInfo.GetItemValue("Birth").ToString();
            paInfo.Tel	 = layPaInfo.GetItemValue("Tel").ToString();
            paInfo.Tel1	 = layPaInfo.GetItemValue("Tel1").ToString();
            paInfo.TelHP		= layPaInfo.GetItemValue("TelHP").ToString();
            paInfo.Email		= layPaInfo.GetItemValue("Email").ToString();
            paInfo.Zip1			= layPaInfo.GetItemValue("Zip1").ToString();
            paInfo.Zip2			= layPaInfo.GetItemValue("Zip2").ToString();
            paInfo.Address1		= layPaInfo.GetItemValue("Address1").ToString();
            paInfo.Address2		= layPaInfo.GetItemValue("Address2").ToString();
            paInfo.InHospital   = ( layPaInfo.GetItemValue("InHospital").ToString() == "Y" ? true : false);

            
            DetailPaInfoForm dlg = new DetailPaInfoForm(paInfo, null);
            dlg.ShowDialog(EnvironInfo.MdiForm);
            dlg.Dispose();
            
        }
        
        private IList<object[]> LayPaInfoGetPatientInfo(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            XPaInfoBoxArgs paInfoBoxArgs = new XPaInfoBoxArgs(grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "Patientcode"));
            XPaInfoBoxResult result = CloudService.Instance.Submit<XPaInfoBoxResult, XPaInfoBoxArgs>(paInfoBoxArgs);
            if (result != null)
            {
                IList<XPaInfoBoxInfo> listPaInfoBoxInfo = result.PatientInfoItem;
                if (listPaInfoBoxInfo != null && listPaInfoBoxInfo.Count > 0)
                {
                    foreach (XPaInfoBoxInfo paInfoBoxInfo in listPaInfoBoxInfo)
                    {
                        object[] objPatientInfo =
                        {
                            paInfoBoxInfo.PatientName,
                            paInfoBoxInfo.PatientName2,
                            paInfoBoxInfo.Sex,
                            paInfoBoxInfo.YearAge,
                            paInfoBoxInfo.MonthAge,
                            paInfoBoxInfo.MonthAge,
                            paInfoBoxInfo.DepartmentCode,
                            paInfoBoxInfo.Birth,
                            paInfoBoxInfo.Tel,
                            paInfoBoxInfo.Tel1,
                            paInfoBoxInfo.TelHp,
                            paInfoBoxInfo.DepartmentName,
                            paInfoBoxInfo.Email,
                            paInfoBoxInfo.ZipCode1,
                            paInfoBoxInfo.ZipCode2,
                            paInfoBoxInfo.Address1,
                            paInfoBoxInfo.Address2
                        };
                        lstResult.Add(objPatientInfo);
                    }
                }
            }
            return lstResult;
        }

        private IList<object[]> GetPatienInfo(BindVarCollection bindVarCollection)
        {
            IList<object[]> listResult = new List<object[]>();
            try
            {
                GetPatientByCodeArgs getPatientByCodeArgs = new GetPatientByCodeArgs(bindVarCollection["f_bunho"].VarValue, UserInfo.HospCode);
                GetPatientByCodeResult patientByCodeResult =
                    CloudService.Instance.Submit<GetPatientByCodeResult, GetPatientByCodeArgs>(getPatientByCodeArgs);
                if (patientByCodeResult != null)
                {
                    IList<PatientInfo> lsPatientInfos = patientByCodeResult.LstPatientInfos;
                    if (lsPatientInfos != null)
                    {
                        foreach (PatientInfo patientInfo in lsPatientInfos)
                        {
                            object[] _patientInfo =
                            {
                                patientInfo.PatientName1,
                                patientInfo.PatientName2,
                                patientInfo.Sex,
                                patientInfo.YearAge,
                                patientInfo.MonthAge,
                                patientInfo.Type,
                                patientInfo.CodeNm,
                                patientInfo.Birth,
                                patientInfo.Tel,
                                patientInfo.Tel1,
                                patientInfo.TelHp,
                                patientInfo.Email,
                                patientInfo.ZipCode1,
                                patientInfo.ZipCode2,
                                patientInfo.Address1,
                                patientInfo.Address2
                            };
                            listResult.Add(_patientInfo);
                        }
                    }
                }
                return listResult;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception", e.Message);
            }
            return listResult;
        }
           
        #endregion

        #region Patient (환자정보 관리 Class)

        public class Patient
        {
            #region Fields
            string bunHo = "";		//환자번호
            string suName = "";		//환자명(한자명)
            string suName2 = "";     //가나명
            string sex = "";		//성별(M/W)
            string yearAge = "";		//나이(년)
            string monthAge = "";		//나이(개월수)
            string gubun = "";		//환자유형
            string gubunName = "";	//환자유형명
            string birth = "";		//생년월일
            string tel = "";		//전화번호
            string tel1 = "";		//전화번호1
            string telHP = "";		//핸드폰번호
            string email = "";		//E-mail
            string zip1 = "";		//우편번호1
            string zip2 = "";		//우편번호2
            string address1 = "";	//주소1(대주소)
            string address2 = "";	//주소2(상세주소)
            bool inHospital = false; //입원중여부 (2007/01/17추가)
            #endregion

            #region Properties
            public string BunHo
            {
                get { return bunHo; }
                set { bunHo = value; }
            }
            public string SuName
            {
                get { return suName; }
                set { suName = value; }
            }
            public string SuName2
            {
                get { return suName2; }
                set { suName2 = value; }
            }

            public string Sex
            {
                get { return sex; }
                set { sex = value; }
            }

            public string YearAge
            {
                get { return yearAge; }
                set { yearAge = value; }
            }

            public string MonthAge
            {
                get { return monthAge; }
                set { monthAge = value; }
            }

            public string Gubun
            {
                get { return gubun; }
                set { gubun = value; }
            }

            public string GubunName
            {
                get { return gubunName; }
                set { gubunName = value; }
            }
            public string Birth
            {
                get { return birth; }
                set { birth = value; }
            }

            public string Tel
            {
                get { return tel; }
                set { tel = value; }
            }
            public string Tel1
            {
                get { return tel1; }
                set { tel1 = value; }
            }
            public string TelHP
            {
                get { return telHP; }
                set { telHP = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }

            public string Zip1
            {
                get { return zip1; }
                set { zip1 = value; }
            }

            public string Zip2
            {
                get { return zip2; }
                set { zip2 = value; }
            }

            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }

            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            public bool InHospital
            {
                get { return inHospital; }
                set { inHospital = value; }
            }
            #endregion

            #region 생성자
            public Patient()
            {
            }
            #endregion

            #region Reset
            public void Reset()
            {
                bunHo = "";		//환자번호
                suName = "";	//환자명
                suName2 = "";	//환자명
                sex = "";		//성별(M/W)
                yearAge = "";		//나이
                monthAge = "";		//나이
                gubun = "";		//환자유형
                gubunName = "";	//환자유형명
                birth = "";		//생년월일
                tel = "";		//전화번호
                tel1 = "";		//전화번호1
                telHP = "";		//HP전화번호
                email = "";		//E-mail
                zip1 = "";		//우편번호1
                zip2 = "";		//우편번호2
                address1 = "";	//주소1(대주소)
                address2 = "";	//주소2(상세주소)
                inHospital = false;
            }
            #endregion
        }
        #endregion
    }
}
