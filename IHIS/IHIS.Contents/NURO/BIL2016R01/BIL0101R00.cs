using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using IHIS.NURO.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bill;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Bill;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bill;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.NURO
{
    public partial class BIL0101R00 : IHIS.Framework.XScreen
    {
        #region [instance variables]

        private BIL2016R01CboAllResult resultCboAll;
        private BIL2016R01GrdReportResult result;
        private bool isClickBtnExport = false;
        #endregion

        public BIL0101R00()
        {
            InitializeComponent();

            InitializeExecuteQuery();
        }

        private void InitializeExecuteQuery()
        {
            this.grdReport.ParamList = new List<string>(new string[]
                {
                    "f_from_month",
                    "f_to_month",
                    "f_from_date",
                    "f_to_date",
                    "f_assign_dept",
                    "f_assign_doctor",
                    "f_exe_dept",
                    "f_exe_doctor",
                    "f_service_id",
                    "f_person_id",
                    "f_page_number"
                });
            LoadCboDepartment();
            //Todo assign executequery for controls
            this.grdReport.ExecuteQuery = LoadDataGrdReport;
            this.cboAssignDept.ExecuteQuery = LoadDataCboAssignDept;
            cboAssignDept.SetDictDDLB();
            this.cboExeDept.ExecuteQuery = LoadDataCboExeDept;
            cboExeDept.SetDictDDLB();
            this.cboPerson.ExecuteQuery = LoadDataCboPerson;  
            cboPerson.SetDictDDLB();
            cboPerson.SetEditValue("%");
            cboExeDept.SetEditValue("%");
        }

        private void BIL2016R01_Load(object sender, EventArgs e)
        {
            //MED-11258
            if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
            {
                dtpFromDate.IsVietnameseYearType = true;
                dtpToDate.IsVietnameseYearType = true;
                mbFromMonth.IsVietnameseYearType = true;
                mbToMonth.IsVietnameseYearType = true;
            }

            this.numYear.SetDataValue(DateTime.Now.Year);
            btnList.PerformClick(FunctionType.Query);

            // Fix bug MED-11255
            DateTime currentTime = EnvironInfo.GetSysDate();

            string dateTime = currentTime.ToString("yyyyMM");
            mbFromMonth.SetDataValue(dateTime);
            mbToMonth.SetDataValue(dateTime);

            string currentDate = currentTime.ToString("yyyy/MM/dd");
            dtpFromDate.SetDataValue(currentDate);
            dtpToDate.SetDataValue(currentDate);
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            //MED-11666
            isClickBtnExport = true;
            this.grdReport.QueryLayout(true);

            // https://sofiamedix.atlassian.net/browse/MED-11301
            DataTable dt = new DataTable("PrintTable");

            for (int i = 0; i < grdReport.CellInfos.Count; i++)
            {
                dt.Columns.Add(grdReport.CellInfos[i].HeaderText);
            }

            foreach (DataRow dr in grdReport.LayoutTable.Rows)
            {
                // Skip header row
                //if (grdReport.LayoutTable.Rows.IndexOf(dr) == 0) continue;

                // Import to print table
                dt.Rows.Add(dr.ItemArray);
            }
            //MED-12329
            try
            {
                Decimal sumAmount = 0;
                Decimal sumDiscount = 0;
                Decimal sumAmountPaid = 0;
                bool parseResult = Decimal.TryParse(result.SumDiscount, out sumDiscount);
                if (parseResult)
                {
                    sumAmount = CalculateSum() - sumDiscount;
                }
                 DataRow dtr1 = dt.NewRow();
                 dtr1[1] = Resources.txt_SumSub;
                 dtr1[8] = CalculateSum().ToString(); //CalculateSumDiscount().ToString();
                 dtr1[9] = CalculateSumDiscount().ToString();
                 dtr1[10] = CalculateSumAmountPaid().ToString();
                dt.Rows.Add(dtr1);
                DataRow dtr2 = dt.NewRow();
                dtr2[1] = Resources.txt_SumDiscount1;
                dtr2[9] = sumDiscount.ToString();
                dt.Rows.Add(dtr2);
                DataRow dtr = dt.NewRow();
                dtr[1] = Resources.txt_SUM;
                //dtr[9] = sumAmount.ToString();
                dtr[9] = result.SumAmountPaid;
                dt.Rows.Add(dtr);
               
            }
            catch (Exception ex)
            {
                Logs.WriteLog("[ERROR]BIL0101R00 :" + ex.Message);
            }
            //Todo export to csv
            using (SaveFileDialog svd = new SaveFileDialog())
            {
                svd.Filter = "csv files (*.csv)|*.csv";
                svd.FileName = Resources.MSGLABEL;
                if (svd.ShowDialog() == DialogResult.OK)
                {
                    // https://sofiamedix.atlassian.net/browse/MED-11301
                    //string csvContent = Utilities.ToCSV(this.grdReport.LayoutTable);
                    string csvContent = Utilities.ToCSV(dt);
                    // Get file name.
                    string name = svd.FileName;
                    //File.WriteAllText(name, csvContent);

                    using (StreamWriter sw = new StreamWriter(new FileStream(name, FileMode.Create), Encoding.UTF8))
                    {
                        sw.WriteLine(csvContent);
                    }
                }
            }
        }

        private void rbnTime_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;
            if (button.Checked)
            {
                //enable controls
                switch (button.Name)
                {
                    case "rbnQuarter":
                        this.numQuarter.Enabled = true;
                        this.numYear.Enabled = true;

                        this.mbFromMonth.Enabled = false;
                        this.mbToMonth.Enabled = false;

                        this.dtpFromDate.Enabled = false;
                        this.dtpToDate.Enabled = false;
                        // https://sofiamedix.atlassian.net/browse/MED-16281
                        this.timePickerFrom.Enabled = false;
                        this.timePickerTo.Enabled = false;
                        break;
                    case "rbnMonth":
                        this.numQuarter.Enabled = false;
                        this.numYear.Enabled = false;

                        this.mbFromMonth.Enabled = true;
                        this.mbToMonth.Enabled = true;

                        this.dtpFromDate.Enabled = false;
                        this.dtpToDate.Enabled = false;
                        // https://sofiamedix.atlassian.net/browse/MED-16281
                        this.timePickerFrom.Enabled = false;
                        this.timePickerTo.Enabled = false;
                        break;
                    case "rbnDate":
                        this.numQuarter.Enabled = false;
                        this.numYear.Enabled = false;

                        this.mbFromMonth.Enabled = false;
                        this.mbToMonth.Enabled = false;

                        this.dtpFromDate.Enabled = true;
                        this.dtpToDate.Enabled = true;
                        // https://sofiamedix.atlassian.net/browse/MED-16281
                        this.timePickerFrom.Enabled = true;
                        this.timePickerTo.Enabled = true;
                        break;
                }
            }
        }

        private void rbnDept_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;
            if (button.Checked)
            {
                //enable controls
                switch (button.Name)
                {
                    case "rbnAssignDept":
                        this.cboAssignDept.Enabled = true;
                        this.fbxAssignDoctor.Enabled = true;

                        this.cboExeDept.Enabled = false;
                        this.fbxExeDoctor.Enabled = false;
                        break;
                    case "rbnExeDept":
                        this.cboAssignDept.Enabled = false;
                        this.fbxAssignDoctor.Enabled = false;
                        this.cboExeDept.Enabled = true;
                        this.fbxExeDoctor.Enabled = true;
                        break;
                }
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdReport.QueryLayout(false);                    
                    CalculateSum();
                    break;
            }
        }

        private Decimal CalculateSum()
        {
            Decimal sum = 0;
            for (int i = 0; i < grdReport.RowCount; i++)
            {
                Decimal number;
                //sum += Decimal.Parse(grdReport.GetItemString(i, "sum"));
                bool parseResult = Decimal.TryParse(grdReport.GetItemString(i, "sum"), out number);
                if (parseResult)
                {
                    sum += number;
                }
                else
                {
                    continue;
                }
            }
            return sum;
            //this.lblSum.Text = Resources.Msg_sum + sum.ToString("#,###");
        }
        private Decimal CalculateSumDiscount()
        {
            Decimal sum = 0;
            for (int i = 0; i < grdReport.RowCount; i++)
            {
                Decimal number;
                //sum += Decimal.Parse(grdReport.GetItemString(i, "sum"));
                bool parseResult = Decimal.TryParse(grdReport.GetItemString(i, "discount"), out number);
                if (parseResult)
                {
                    sum += number;
                }
                else
                {
                    continue;
                }
            }
            return sum;
            //this.lblSum.Text = Resources.Msg_sum + sum.ToString("#,###");
        }
        private Decimal CalculateSumAmountPaid()
        {
            Decimal sum = 0;
            for (int i = 0; i < grdReport.RowCount; i++)
            {
                Decimal number;
                //sum += Decimal.Parse(grdReport.GetItemString(i, "sum"));
                //bool parseResult = Decimal.TryParse(grdReport.GetItemString(i, "amount_paid"), out number);
                //if (parseResult)
                //{
                //    sum += number;
                //}
                //else
                //{
                //    continue;
                //}
            }
            return sum;
        }
        private void grdReport_QueryStarting(object sender, CancelEventArgs e)
        {
            if (rbnQuarter.Checked)
            {
                this.grdReport.SetBindVarValue("f_from_date", "");
                this.grdReport.SetBindVarValue("f_to_date", "");
                string fromMonth = "";
                string toMonth = "";
                switch (Int32.Parse(numQuarter.GetDataValue()))
                {
                    case 1:
                        fromMonth = numYear.GetDataValue() + "01";
                        toMonth = numYear.GetDataValue() + "03";
                        break;
                    case 2:
                        fromMonth = numYear.GetDataValue() + "04";
                        toMonth = numYear.GetDataValue() + "06";
                        break;
                    case 3:
                        fromMonth = numYear.GetDataValue() + "07";
                        toMonth = numYear.GetDataValue() + "09";
                        break;
                    case 4:
                        fromMonth = numYear.GetDataValue() + "10";
                        toMonth = numYear.GetDataValue() + "12";
                        break;
                    default:
                        fromMonth = numYear.GetDataValue() + "01";
                        toMonth = numYear.GetDataValue() + "03";
                        break;
                }
                this.grdReport.SetBindVarValue("f_from_month", fromMonth);
                this.grdReport.SetBindVarValue("f_to_month", toMonth);
            }
            else if (rbnMonth.Checked)
            {
                this.grdReport.SetBindVarValue("f_from_date", "");
                this.grdReport.SetBindVarValue("f_to_date", "");
                this.grdReport.SetBindVarValue("f_from_month", mbFromMonth.GetDataValue());
                this.grdReport.SetBindVarValue("f_to_month", mbToMonth.GetDataValue());
            }
            else if (rbnDate.Checked)
            {
                this.grdReport.SetBindVarValue("f_from_month", "");
                this.grdReport.SetBindVarValue("f_to_month", "");

                // https://sofiamedix.atlassian.net/browse/MED-16281
                //this.grdReport.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
                //this.grdReport.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
                this.grdReport.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue() + " " + timePickerFrom.Value.ToString("HH:mm:ss"));
                this.grdReport.SetBindVarValue("f_to_date", dtpToDate.GetDataValue() + " " + timePickerTo.Value.ToString("HH:mm:ss"));
            }

            if (rbnAssignDept.Checked)
            {
                this.grdReport.SetBindVarValue("f_exe_dept", "");
                this.grdReport.SetBindVarValue("f_exe_doctor", "");
                this.grdReport.SetBindVarValue("f_assign_dept", cboAssignDept.GetDataValue());
                this.grdReport.SetBindVarValue("f_assign_doctor", fbxAssignDoctor.GetDataValue());
            }
            else if (rbnExeDept.Checked)
            {
                this.grdReport.SetBindVarValue("f_assign_dept", "");
                this.grdReport.SetBindVarValue("f_assign_doctor", "");
                this.grdReport.SetBindVarValue("f_exe_dept", cboExeDept.GetDataValue());
                this.grdReport.SetBindVarValue("f_exe_doctor", fbxExeDoctor.GetDataValue());
            }

            this.grdReport.SetBindVarValue("f_service_id", txtService.GetDataValue());
            this.grdReport.SetBindVarValue("f_person_id", cboPerson.GetDataValue());
        }

        #region CloudService
        private IList<object[]> LoadDataCboPerson(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            BIL2016R01FbxPersonArgs args = new BIL2016R01FbxPersonArgs();
            ComboResult result = CloudService.Instance.Submit<ComboResult, BIL2016R01FbxPersonArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.ComboItem)
                {
                    lstData.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return lstData;
        }

        private IList<object[]> LoadDataCboExeDept(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            BIL2016R01CboExeDeptArgs args = new BIL2016R01CboExeDeptArgs();
            ComboResult result = CloudService.Instance.Submit<ComboResult, BIL2016R01CboExeDeptArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.ComboItem)
                {
                    lstData.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return lstData;
        }


        private IList<object[]> LoadDataGrdReport(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            BIL2016R01GrdReportArgs args = new BIL2016R01GrdReportArgs();
            args.FromMonth = varlist["f_from_month"].VarValue;
            args.ToMonth = varlist["f_to_month"].VarValue;
            args.FromDate = varlist["f_from_date"].VarValue;
            args.ToDate = varlist["f_to_date"].VarValue;
            args.AssignDept = varlist["f_assign_dept"].VarValue;
            args.AssignDoctor = varlist["f_assign_doctor"].VarValue;
            args.ExeDept = varlist["f_exe_dept"].VarValue;
            args.ExeDoctor = varlist["f_exe_doctor"].VarValue;
            args.ServiceId = varlist["f_service_id"].VarValue;
            args.PersonId = varlist["f_person_id"].VarValue;            
            if (isClickBtnExport)
            {
                args.PageNumber = "";
                args.Offset = "";
            }
            else
            {
                args.PageNumber = varlist["f_page_number"].VarValue;            
                args.Offset = "200";
            }
            isClickBtnExport = false;
           
            result = CloudService.Instance.Submit<BIL2016R01GrdReportResult, BIL2016R01GrdReportArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BIL2016R01GrdReportInfo info in result.GrdList)
                {
                    //MED-11258
                    string actingDate = info.ActingDate;
                    if (NetInfo.Language == IHIS.Framework.LangMode.Vi)
                    {
                        DateTime value;
                        bool parseResult = DateTime.TryParse(actingDate, out value);
                        if (parseResult)
                        {
                            actingDate = value.ToString("dd/MM/yyyy");
                        }
                    }
                    lstData.Add(new object[]
                    {
                        info.ServiceId,
                        info.ServiceName,
                        info.ExecuteDept,
                        info.ExecuteDoctor,
                        info.AssignDept,
                        info.AssignDoctor,
                        actingDate,
                        info.Quantity,
                        info.Sum,
                        info.Discount,
                        //info.AmountPaid
                    });
                }
            }
            return lstData;
        }

        private IList<object[]> LoadDataCboAssignDept(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            if (resultCboAll != null && resultCboAll.CboAssignDept != null)
            {
                foreach (ComboListItemInfo info in resultCboAll.CboAssignDept)
                {
                    lstData.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return lstData;
        }

        private void LoadCboDepartment()
        {
            resultCboAll =
                CloudService.Instance.Submit<BIL2016R01CboAllResult, BIL2016R01CboAllArgs>(new BIL2016R01CboAllArgs());
        }

        private IList<object[]> GetFwkAssignDoctor(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            OCS0203U00LoadAllMembArgs args = new OCS0203U00LoadAllMembArgs();
            args.HospCode = UserInfo.HospCode;
            args.Gwa = varlist["f_gwa"].VarValue;
            OCS0203U00LoadAllMembResult result =
                CloudService.Instance.Submit<OCS0203U00LoadAllMembResult, OCS0203U00LoadAllMembArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.CboList)
                {
                    lstData.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return lstData;
        }

        private IList<object[]> GetFwkExeDoctor(Framework.BindVarCollection varlist)
        {
            IList<object[]> lstData = new List<object[]>();
            BIL2016R01FbxExeDoctorArgs args = new BIL2016R01FbxExeDoctorArgs();
            args.Gwa = varlist["f_gwa"].VarValue;
            ComboResult result =
                CloudService.Instance.Submit<ComboResult, BIL2016R01FbxExeDoctorArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.ComboItem)
                {
                    lstData.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return lstData;
        }

        #endregion

        private void Fbx_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;
            switch (control.Name)
            {
                case "fbxAssignDoctor":
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;
                    this.fwkCommon.ParamList = new List<string>(new String[] { "f_gwa" });
                    this.fwkCommon.BindVarList.Add("f_gwa", this.cboAssignDept.GetDataValue());

                    this.fwkCommon.ExecuteQuery = GetFwkAssignDoctor;
                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.MSG_DoctorCode, FindColType.String, 100, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.MSG_DoctorName, FindColType.String, 250, 0, true, FilterType.InitYes);
                    break;
                case "fbxExeDoctor":
                    this.fwkCommon.AutoQuery = true;
                    this.fwkCommon.ServerFilter = true;
                    this.fwkCommon.ParamList = new List<string>(new String[] { "f_gwa" });
                    this.fwkCommon.BindVarList.Add("f_gwa", this.cboExeDept.GetDataValue());

                    this.fwkCommon.ExecuteQuery = GetFwkExeDoctor;
                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.MSG_DoctorCode, FindColType.String, 100, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.MSG_DoctorName, FindColType.String, 250, 0, true, FilterType.InitYes);
                    break;
            }
        }

        private void Fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }
    }
}
