using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using IHIS.Framework;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Bill;
using IHIS.CloudConnector.Contracts.Models.Bill;
using IHIS.CloudConnector.Contracts.Results.Bill;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Threading;
using System.Globalization;

namespace IHIS.NURO
{
    public partial class BIL0001U00 : XScreen
    {
        #region control
        private XPanel xPanel1;
        private XLabel xLabel5;
        private XLabel xLabel4;
        private XDictComboBox cboGroup;
        #endregion
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XPanel xPanel2;
        private XPanel pnlControl;
        private XEditGrid grdMaster;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell14;
        private XButtonList btnList;
        private XTextBox txtSearch;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell11;
        private string hangmog_code = "";
        private Decimal insurancePrice = 0;
        private Decimal servicePrice = 0;
        private Decimal foreignerPrice = 0;
        private XLabel xLabel8;
        private bool save_flag;
        private int row_num = 0;

        public BIL0001U00()
        {
            this.InitializeComponent();
            InitializeCloud();

            xLabel8.Text = Resource.TXT_UNIT;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIL0001U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.cboGroup = new IHIS.Framework.XDictComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlControl = new IHIS.Framework.XPanel();
            this.grdMaster = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
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
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.txtSearch);
            this.xPanel1.Controls.Add(this.cboGroup);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleDescription = null;
            this.txtSearch.AccessibleName = null;
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.BackgroundImage = null;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtService_KeyDown);
            this.txtSearch.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxService_DataValidating);
            // 
            // cboGroup
            // 
            this.cboGroup.AccessibleDescription = null;
            this.cboGroup.AccessibleName = null;
            resources.ApplyResources(this.cboGroup, "cboGroup");
            this.cboGroup.BackgroundImage = null;
            this.cboGroup.ExecuteQuery = null;
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGroup.ParamList")));
            this.cboGroup.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "service_code";
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "service_name";
            this.xEditGridCell3.CellWidth = 124;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "service_group";
            this.xEditGridCell4.CellWidth = 113;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "service_code";
            this.xEditGridCell6.CellWidth = 92;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "service_name";
            this.xEditGridCell7.CellWidth = 112;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "service_group";
            this.xEditGridCell8.CellWidth = 112;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.BTN_QUERY, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.BTN_SAVE, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.BTN_QUIT, -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlControl
            // 
            this.pnlControl.AccessibleDescription = null;
            this.pnlControl.AccessibleName = null;
            resources.ApplyResources(this.pnlControl, "pnlControl");
            this.pnlControl.BackgroundImage = null;
            this.pnlControl.Controls.Add(this.grdMaster);
            this.pnlControl.Font = null;
            this.pnlControl.Name = "pnlControl";
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell14,
            this.xEditGridCell1,
            this.xEditGridCell5,
            this.xEditGridCell11});
            this.grdMaster.ColPerLine = 6;
            this.grdMaster.Cols = 6;
            this.grdMaster.ControlBinding = true;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(20);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdMaster_RowFocusChanging);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "object";
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "service_name";
            this.xEditGridCell10.CellWidth = 314;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "service_group";
            this.xEditGridCell14.CellWidth = 177;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "price1";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell1.CellWidth = 144;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "price2";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell5.CellWidth = 142;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "price3";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell11.CellWidth = 140;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // BIL0001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "BIL0001U00";
            this.Load += new System.EventHandler(this.BIL0001U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeCloud()
        {
            cboGroup.ExecuteQuery = GetCboGroupType;
            grdMaster.ExecuteQuery = GetGrdMaster;
            grdMaster.ParamList = new List<string>(new string[]
                {
                    "f_page_number"
                });

        }

        #region Get Combobox Group Filter
        private IList<object[]> GetCboGroupType(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            OCS0103U00CboOrderGubunArgs args = new OCS0103U00CboOrderGubunArgs(UserInfo.HospCode);
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00CboOrderGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }
            return lObj;

        }
        #endregion

        #region Get GrdMaster Data
        private IList<object[]> GetGrdMaster(BindVarCollection bvc)
        {
            save_flag = false;   
            IList<object[]> lObj = new List<object[]>();

            BIL2016U00GrdMasterArgs args = new BIL2016U00GrdMasterArgs();
            args.HangmogNameInx = txtSearch.Text;
            args.OrderGubun = cboGroup.GetDataValue();
            args.HospCode = "";
            args.CodeType = "ORDER_GUBUN_BAS";
            args.Language = "";
            args.PageNumber = bvc["f_page_number"].VarValue;
            //args.PageNumber = "1";
            args.Offset = "200";

            BIL2016U00GrdMasterResult res = CloudService.Instance.Submit<BIL2016U00GrdMasterResult, BIL2016U00GrdMasterArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.ListInfo != null)
            {
                res.ListInfo.ForEach(delegate(BIL2016U00ServiceInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.HangmogCode,
                            item.HangmogName,
                            item.CodeName,
                            item.Price1,
                            item.Price2,
                            item.Price3
                        });
                });
            }
            //if (res.ListInfo.Count == 0)
            //{
            //    Reset();
            //}
            return lObj;
        }
        #endregion

        #region Get GrdDetailService Data
        private void GetGrdDetailService()
            {
            BIL2016U00DetailServiceArgs args = new BIL2016U00DetailServiceArgs();
            args.HangmogCode = hangmog_code;

            //SetDefaultInputText();

            BIL2016U00DetailServiceResult res = CloudService.Instance.Submit<BIL2016U00DetailServiceResult, BIL2016U00DetailServiceArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Info != null)
            {
                if (res.Info.InsurancePrice == "")
                {
                    res.Info.InsurancePrice = "0";
                }
                if (res.Info.ServicePrice == "")
                {
                    res.Info.ServicePrice = "0";
                }
                if (res.Info.ForeignerPrice == "")
                {
                    res.Info.ForeignerPrice = "0";
                }
              
                insurancePrice = Decimal.Parse(res.Info.InsurancePrice);
                servicePrice = Decimal.Parse(res.Info.ServicePrice);
                foreignerPrice = Decimal.Parse(res.Info.ForeignerPrice);

                //txtInsurancePrice.Text = FormatNumber(insurancePrice.ToString(), true);
                //txtServicePrice.Text = FormatNumber(servicePrice.ToString(), true);
                //txtForeignerPrice.Text = FormatNumber(foreignerPrice.ToString(), true);
            }

           
        }

        #endregion

        //private void SetDefaultInputText()
        //{
        //    txtInsurancePrice.Text = "0";
        //    txtServicePrice.Text = "0";
        //    txtForeignerPrice.Text = "0";
        //    insurancePrice = 0;
        //    servicePrice = 0;
        //    foreignerPrice = 0;
        //}

        #region Get GridDetailFor Save
        //private BIL2016U00DetailServiceInfo GetGrdDetailForSaveLayout()
        //{
        //    BIL2016U00DetailServiceInfo objDetailService = new BIL2016U00DetailServiceInfo();
        //    objDetailService.HangmogCode = hangmog_code;
        //    objDetailService.InsurancePrice = FormatNumber(txtInsurancePrice.Text, false);
        //    objDetailService.ServicePrice = FormatNumber(txtServicePrice.Text, false);
        //    objDetailService.ForeignerPrice = FormatNumber(txtForeignerPrice.Text, false);

        //    return objDetailService;
        //}
        private List<BIL2016U00DetailServiceInfo> GetGrdDetailForSaveLayout()
        {
            List<BIL2016U00DetailServiceInfo> lst = new List<BIL2016U00DetailServiceInfo>();
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;
                BIL2016U00DetailServiceInfo info = new BIL2016U00DetailServiceInfo();
                info.HangmogCode = grdMaster.GetItemValue(i, "object").ToString();
                info.InsurancePrice = grdMaster.GetItemValue(i, "price1").ToString();
                info.ServicePrice = grdMaster.GetItemValue(i, "price2").ToString();
                info.ForeignerPrice = grdMaster.GetItemValue(i, "price3").ToString();
                info.RowState = grdMaster.GetRowState(i).ToString();
                lst.Add(info);
            }
            return lst;
        }
        #endregion

        #region ButtonList Click Event
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    grdMaster.QueryLayout(false);
                    if (grdMaster.RowCount == 0) 
                    {
                        //Reset();
                    }
                    break;
                case FunctionType.Update:
                    row_num = grdMaster.CurrentRowNumber;
                    
                    //if (!ValidateInputTextDetail()) return;

                    BIL2016U00SaveGrdMasterArgs args = new BIL2016U00SaveGrdMasterArgs();
                    args.Info = GetGrdDetailForSaveLayout();
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, BIL2016U00SaveGrdMasterArgs>(args);
                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
                    {
                        XMessageBox.Show(Resource.MSG_001, Resource.MSG_001_CAP, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XMessageBox.Show(Resource.MSG_002, Resource.MSG_002_CAP, MessageBoxIcon.Warning);
                    }
                    grdMaster.QueryLayout(false);
                    grdMaster.SetFocusToItem(row_num, 0);
                    break;

            }
        }
        #endregion

        #region txt Service Keydow
        private void txtService_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
                btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region GridMaster RowFocusChanges
        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {

            if (e.CurrentRow < 0)
            {               
                return;
            }
            else
            {
                hangmog_code = grdMaster.GetItemString(e.CurrentRow, "object");
                GetGrdDetailService();
                //txtInsurancePrice.Text = FormatNumber(insurancePrice.ToString(), true);
                //txtServicePrice.Text = FormatNumber(servicePrice.ToString(), true);
                //txtForeignerPrice.Text = FormatNumber(foreignerPrice.ToString(), true);
            }

        }
        #endregion

        private void BIL0001U00_Load(object sender, EventArgs e)
        {
            save_flag = true;
            cboGroup.SetDictDDLB();
            cboGroup.SetEditValue("%");
            grdMaster.QueryLayout(false);
            
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {

        }

        #region validateInputTextDetail

        //private bool ValidateInputTextDetail()
        //{
        //    Decimal numberInsurancePrice = 0;
        //    Decimal numberService = 0;
        //    Decimal numberForeignerPrice = 0;
        //    string insurrancePrice = "";
        //    string servicePrice = "";
        //    string foreignerPrice = "";

        //    //if (TypeCheck.IsNull(txtInsurancePrice.Text.Trim()))
        //    //{
        //    //    insurrancePrice = "0";
        //    //}
        //    //if (TypeCheck.IsNull(txtServicePrice.Text.Trim()))
        //    //{
        //    //    servicePrice = "0";
        //    //}
        //    //if (TypeCheck.IsNull(txtForeignerPrice.Text.Trim()))
        //    //{
        //    //    foreignerPrice = "0";
        //    //}

        //    insurrancePrice = Decimal.Parse(TypeCheck.IsNull(txtInsurancePrice.Text.Trim()) ? "0" : txtInsurancePrice.Text.Trim(),
        //        Thread.CurrentThread.CurrentUICulture).ToString();
        //    servicePrice = Decimal.Parse(TypeCheck.IsNull(txtServicePrice.Text.Trim()) ? "0" : txtServicePrice.Text.Trim(),
        //        Thread.CurrentThread.CurrentUICulture).ToString();
        //    foreignerPrice = Decimal.Parse(TypeCheck.IsNull(txtForeignerPrice.Text.Trim()) ? "0" : txtForeignerPrice.Text.Trim(),
        //        Thread.CurrentThread.CurrentUICulture).ToString();

        //    if (!Decimal.TryParse(insurrancePrice.Trim(), out numberInsurancePrice))
        //    {
        //        XMessageBox.Show(Resource.MSG_003, Resource.MSG_003_CAP, MessageBoxIcon.Error);
        //        txtInsurancePrice.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        if (numberInsurancePrice < 0)
        //        {
        //            XMessageBox.Show(Resource.MSG_003, Resource.MSG_003_CAP, MessageBoxIcon.Error);
        //            txtInsurancePrice.Focus();
        //            return false;
        //        }
        //    }

        //    if (!Decimal.TryParse(servicePrice.Trim(), out numberService))
        //    {
        //        XMessageBox.Show(Resource.MSG_004, Resource.MSG_004_CAP, MessageBoxIcon.Error);
        //        txtServicePrice.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        if (numberService < 0)
        //        {
        //            XMessageBox.Show(Resource.MSG_004, Resource.MSG_004_CAP, MessageBoxIcon.Error);
        //            txtServicePrice.Focus();
        //            return false;
        //        }
        //    }

        //    if (!Decimal.TryParse(foreignerPrice.Trim(), out numberForeignerPrice))
        //    {
        //        XMessageBox.Show(Resource.MSG_005, Resource.MSG_005_CAP, MessageBoxIcon.Error);
        //        txtForeignerPrice.Focus();
        //        return false;
        //    }
        //    else
        //    {
        //        if (numberForeignerPrice < 0)
        //        {
        //            XMessageBox.Show(Resource.MSG_005, Resource.MSG_005_CAP, MessageBoxIcon.Error);
        //            txtForeignerPrice.Focus();
        //            return false;
        //        }
        //    }

        //    if (numberInsurancePrice == 0 && numberService == 0 && numberForeignerPrice == 0)
        //    {
        //        XMessageBox.Show(Resource.MSG_006, Resource.MSG_006_CAP, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        private void fbxService_FindClick(object sender, CancelEventArgs e)
        {
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, null); 
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "OCS0103Q00")
            {
                if (commandParam.Contains("OCS0103"))
                {
                    txtSearch.Text = commandParam["hangmog_name"].ToString();
                }
            }

            return base.Command(command, commandParam);
        }


        private void fbxService_DataValidating(object sender, DataValidatingEventArgs e)
        {
            
        }

        private void grdMaster_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            //if (save_flag == true)
            //{
            //    if (txtInsurancePrice.Text == "")
            //    {
            //        txtInsurancePrice.Text = "0";
            //    }
            //    if (txtServicePrice.Text == "")
            //    {
            //        txtServicePrice.Text = "0";
            //    }
            //    if (txtForeignerPrice.Text == "")
            //    {
            //        txtForeignerPrice.Text = "0";
            //    }
            //    if (NetInfo.Language == LangMode.Vi)
            //    {
            //        if ((txtInsurancePrice.Text.Replace(".", String.Empty).Trim() != insurancePrice.ToString()
            //            || txtServicePrice.Text.Replace(".", String.Empty).Trim() != servicePrice.ToString()
            //            || txtForeignerPrice.Text.Replace(".", String.Empty).Trim() != foreignerPrice.ToString()))
            //        {
            //            DialogResult result = XMessageBox.Show(Resource.MSG_007, Resource.MSG_007_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //            if (result == DialogResult.Yes)
            //            {
            //                btnList.PerformClick(FunctionType.Update);
            //            }
            //        }
            //    }
            //    else {
            //        if ((txtInsurancePrice.Text.Replace(",", String.Empty).Trim() != insurancePrice.ToString()
            //                || txtServicePrice.Text.Replace(",", String.Empty).Trim() != servicePrice.ToString()
            //                || txtForeignerPrice.Text.Replace(",", String.Empty).Trim() != foreignerPrice.ToString()))
            //        {
            //            DialogResult result = XMessageBox.Show(Resource.MSG_007, Resource.MSG_007_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //            if (result == DialogResult.Yes)
            //            {
            //                btnList.PerformClick(FunctionType.Update);
            //            }
            //        }
            //    }
                
            //}
            //save_flag = true;
        }

        private void txtInsurancePrice_KeyDown(object sender, KeyEventArgs e)
        {       
        }

        //private void txtInsurancePrice_Leave(object sender, EventArgs e)
        //{
        //    txtInsurancePrice.MaxLength = 19;
        //    txtInsurancePrice.Text = FormatNumber(txtInsurancePrice.Text, true);
        //}

        //private void txtServicePrice_Leave(object sender, EventArgs e)
        //{
        //    txtServicePrice.MaxLength = 19;
        //    txtServicePrice.Text = FormatNumber(txtServicePrice.Text, true);
        //}

        //private void txtForeignerPrice_Leave(object sender, EventArgs e)
        //{
        //    txtForeignerPrice.MaxLength = 19;
        //    txtForeignerPrice.Text = FormatNumber(txtForeignerPrice.Text, true);
        //}

        //private void txtInsurancePrice_Enter(object sender, EventArgs e)
        //{
        //    txtInsurancePrice.MaxLength = 13;
        //}

        //private void txtServicePrice_Enter(object sender, EventArgs e)
        //{
        //    txtServicePrice.MaxLength = 13;
        //}

        //private void txtForeignerPrice_Enter(object sender, EventArgs e)
        //{
        //    txtForeignerPrice.MaxLength = 13;
        //}

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void Reset()
        //{
        //    txtInsurancePrice.Text = "";
        //    txtServicePrice.Text = "";
        //    txtForeignerPrice.Text = "";
        //}

        private string FormatNumber(string value, bool useSeparator)
        {
            decimal number;
            if (TypeCheck.IsNull(value)) return "0";
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;;

            if (decimal.TryParse(value, style, Thread.CurrentThread.CurrentCulture, out number))
            {
                value = useSeparator ? number.ToString("N0") : number.ToString();
            }
            else
            {
                //ctrl.Text = "";
            }

            return value;
        }
    }
}



