namespace IHIS.OCSO
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Nodes;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Arguments.System;
    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results.System;
    using IHIS.Framework;
    using System.Collections;
    using IHIS.OCSO.Properties;

    public partial class OCS2015U03 : UserControl
    {
        public OCS2015U03()
        {
            InitializeComponent();
            emptyIco = imageList1.Images[10];
            TvHisExam.VertScrollVisibility = ScrollVisibility.Auto;
        }

        OcsEmrPatientReceptionHistoryListResult receptHisResult;
        public OcsEmrPatientReceptionHistoryListResult ReceptHisResult
        {
            get { return receptHisResult; }
            //set { receptHisResult = value; }
        }

        private DataTable dt;
        private DataTable emrClinicRefer;
        private DataTable _dtIntruduceLetter;
        private Image emptyIco;
        private string _gwa = "";
        private string _bunho = "";
        private DataTable dtDepartments;
        private bool isFirstLoadDepartment = true;
        /// <summary>
        /// Query examination history as treeview for the specific patient
        /// </summary>
        /// <param name="bunho">Patient code</param>
        /// <param name="hosp_code">Hospital code</param>
        /// <param name="gwa">Current department code</param>
        public void SetDataForTvExamHist(string bunho, string hosp_code, string gwa, bool genEmrRefer)
        {
            tvHisExam.Nodes.Clear();
            _bunho = bunho;
            dt = new DataTable();
            dt.Columns.Add("Gwa", typeof(string));
            dt.Columns.Add("GwaName", typeof(string));
            dt.Columns.Add("NaewonDate", typeof(string));
            dt.Columns.Add("PkOut1001", typeof(string));
            dt.Columns.Add("TimeStamp", typeof(string));
            for (int i = 1; i <= 11; i++)
            {
                dt.Columns.Add("Icon" + i, typeof(Image));
            }
            dt.Columns.Add("Bunho", typeof(string));
            // 2015.08.06 AnhNV Added START
            EMRSetDataForTvExamHistArgs args = new EMRSetDataForTvExamHistArgs();
            args.Bunho = bunho;
            args.HospCode = hosp_code;
            EMRSetDataForTvExamHistResult res = CloudService.Instance.Submit<EMRSetDataForTvExamHistResult, EMRSetDataForTvExamHistArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.PatientListItem.Count > 0 && res.EmrHistoryListItem.Count > 0)
                {
                    
                    string examDate = string.Empty;
                    foreach (OcsEmrPatientReceptionHistoryListItemInfo item in res.EmrHistoryListItem)
                    {
                        examDate = item.ExamDate;
                        DataRow dr = dt.NewRow();
                        dr["Gwa"] = item.DepartmentCode;
                        dr["GwaName"] = item.DepartmentName;
                        dr["NaewonDate"] = examDate.Substring(0, 10).Trim().Replace("-", "/");
                        dr["PkOut1001"] = item.Pkout1001;
                        dr["TimeStamp"] = ConvertToUnixTime(item.ExamDate).ToString();
                        dr["Bunho"] = item.PatientCode;
                        int i = 1;
                        foreach (OCS2015U03OrderGubunInfo ocs2015U03OrderGubunInfo in item.OrderGubun)
                        {
                            dr["Icon" + i] = GetImageByType(ocs2015U03OrderGubunInfo.OrderGubun);
                            i++;
                        }

                        for (int j = i; j <= 11; j++)
                        {
                            dr["Icon" + j] = emptyIco;
                        }
                        dt.Rows.Add(dr);
                    }
                    isFirstLoadDepartment = true;
                }
                if (genEmrRefer)
                {
                    GetEmrClinicRefer(bunho);
                }
                GenerateExamTreeview(gwa);
            }

        }


        public void GetEmrClinicRefer(string bunho)
        {
            emrClinicRefer = new DataTable();
            emrClinicRefer.Columns.Add("HopsCode", typeof(string));
            emrClinicRefer.Columns.Add("HopsName", typeof(string));
            emrClinicRefer.Columns.Add("Gwa", typeof(string));
            emrClinicRefer.Columns.Add("GwaName", typeof(string));
            emrClinicRefer.Columns.Add("NaewonDate", typeof(string));
            emrClinicRefer.Columns.Add("PkOut1001", typeof(string));
            emrClinicRefer.Columns.Add("TimeStamp", typeof(string));
            for (int i = 1; i <= 11; i++)
            {
                emrClinicRefer.Columns.Add("Icon" + i, typeof(Image));
            }
            emrClinicRefer.Columns.Add("Bunho", typeof(string));
            OcsEmrHistoryClinicReferArgs args = new OcsEmrHistoryClinicReferArgs();
            args.Bunho = bunho;
            OcsEmrHistoryClinicReferResult res = CloudService.Instance.Submit<OcsEmrHistoryClinicReferResult, OcsEmrHistoryClinicReferArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.Lst.Count > 0)
                {
                
                    string examDate = string.Empty;
                    foreach (OcsEmrHistoryClinicReferItemInfo record in res.Lst)
                    {
                        foreach (OcsEmrPatientReceptionHistoryListItemInfo item in record.Lst)
                        {
                            examDate = item.ExamDate;
                            DataRow dr = emrClinicRefer.NewRow();
                            dr["HopsCode"] = record.HopsCode;
                            //Sub-task MED-8549 record.HopsName
                            dr["HopsName"] = String.Format(Resources.EMRREFER_HOSP_NAME, record.HopsName);                           
                            dr["Gwa"] = item.DepartmentCode;
                            dr["GwaName"] = item.DepartmentName;
                            dr["NaewonDate"] = examDate.Substring(0, 10).Trim().Replace("-", "/");
                            dr["PkOut1001"] = item.Pkout1001;
                            dr["TimeStamp"] = ConvertToUnixTime(item.ExamDate).ToString();
                            dr["Bunho"] = item.PatientCode;
                            int i = 1;
                            foreach (OCS2015U03OrderGubunInfo ocs2015U03OrderGubunInfo in item.OrderGubun)
                            {
                                dr["Icon" + i] = GetImageByType(ocs2015U03OrderGubunInfo.OrderGubun);
                                i++;
                            }

                            for (int j = i; j <= 11; j++)
                            {
                                dr["Icon" + j] = emptyIco;
                            }
                            emrClinicRefer.Rows.Add(dr);
                        }
                    }
                 }
            }
        }

        public TreeList TvHisExam
        {
            get
            {
                return tvHisExam;
            }
        }

        private Image GetImageByType(string orderGubun)
        {
            if (string.IsNullOrEmpty(orderGubun)) return emptyIco;
            switch (orderGubun.ToUpper())
            {
                case "01":
                    return imageList1.Images[3];
                case "03":
                    return imageList1.Images[4];
                case "04":
                    return imageList1.Images[2];
                case "10":
                    return imageList1.Images[13];
                case "05":
                    return imageList1.Images[6];
                case "06":
                    return imageList1.Images[11];
                case "07":
                    return imageList1.Images[9];
                case "08":
                    return imageList1.Images[14];
                case "09":
                    return imageList1.Images[5];
                case "11":
                    return imageList1.Images[12];
                default:
                    return emptyIco;
            }
        }

        private void GenerateExamTreeview(string gwa)
        {
            _gwa = gwa;
            tvHisExam.BeginUnboundLoad();
            tvHisExam.Nodes.Clear();
            List<TreeListNode> depts = new List<TreeListNode>();
            List<TreeListNode> clinics = new List<TreeListNode>();
            if (dt != null && dt.Rows.Count > 0)
            {
                // Departments
                DataView dv = new DataView(dt);
                DataTable dtDept = dv.ToTable(true, "Gwa", "GwaName");
                dtDept.DefaultView.Sort = "Gwa" + " " + "ASC";
                dtDept = dtDept.DefaultView.ToTable();
                //DataRow[] drRange = dtDept.Select("Gwa ='" + gwa + "'");
                //DataRow drSelectedPatientDept = drRange.Length > 0 ? drRange[0] : null;
                //if (drSelectedPatientDept != null)
                //{
                    //DataRow newRow = dtDept.NewRow();
                    //newRow.ItemArray = drSelectedPatientDept.ItemArray; // clone datarow
                    //dtDept.Rows.Remove(drSelectedPatientDept);
                    //dtDept.Rows.InsertAt(newRow, 0); // set current department to first position
                    if (isFirstLoadDepartment)
                    {
                        dtDepartments = dtDept.Clone();
                        foreach (DataRow dataRow in dtDept.Rows)
                        {
                            dtDepartments.ImportRow(dataRow);
                        }
                        isFirstLoadDepartment = false;
                    }

                    foreach (DataRow drDept in dtDepartments.Rows)
                    {
                        foreach (DataRow dr in dtDept.Rows)
                        {
                            if (drDept["Gwa"].Equals(dr["Gwa"]))
                            {
                                TreeListNode node = tvHisExam.AppendNode(new object[] { dr["Gwa"], dr["GwaName"], dr["GwaName"], null, null, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, null, null, null, null }, null);
                                node.HasChildren = true;
                                node.ImageIndex = 1;
                                depts.Add(node);
                            }
                        }
                    }
                //}

                // Examination dates
                foreach (TreeListNode dept1 in depts)
                {
                    DataTable dtDates = dv.ToTable(true);
                    foreach (DataRow dr in dtDates.Select("Gwa = '" + dept1.GetValue("Gwa") + "'"))
                    {
                        tvHisExam.AppendNode(dr.ItemArray, dept1);
                    }
                }
            }

            if (emrClinicRefer != null && emrClinicRefer.Rows.Count > 0)
            {
                DataView dv = new DataView(emrClinicRefer);
                DataTable dtClinic = dv.ToTable(true, "HopsCode", "HopsName", "Bunho");
                dtClinic.DefaultView.Sort = "HopsCode" + " " + "ASC";
                dtClinic = dtClinic.DefaultView.ToTable();

                
                foreach (DataRow drClinic in dtClinic.Rows)
                {
                    DataTable clinicRefer = emrClinicRefer.Clone();
                    foreach (DataRow dr in emrClinicRefer.Select("HopsCode = '" + drClinic["HopsCode"] + "'"))
                    {
                        clinicRefer.ImportRow(dr);
                    }

                    TreeListNode node = tvHisExam.AppendNode(new object[] { drClinic["HopsCode"], drClinic["HopsName"], drClinic["HopsName"], null, null, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, drClinic["HopsCode"], drClinic["HopsName"], drClinic["Bunho"], null }, null);
                    node.HasChildren = true;
                    node.ImageIndex = 1;
                    //GenerateExamTreeviewClinicRefer(clinicRefer, node, drClinic["HopsCode"].ToString(), drClinic["HopsName"].ToString(), drClinic["Bunho"].ToString());
                }
            }

            //todo: check exist intruduceLetter
            //if(exist IntruduceLetter)
                BindingIntruduceLetterToTreeView();

            tvHisExam.ExpandAll();
            tvHisExam.EndUnboundLoad();
        }

        private void BindingIntruduceLetterToTreeView()
        {
            _dtIntruduceLetter = new DataTable();
            _dtIntruduceLetter.Columns.Add("Bunho", typeof(string));
            _dtIntruduceLetter.Columns.Add("Name", typeof(string));
            _dtIntruduceLetter.Columns.Add("IsIntrudueLetter", typeof(bool));
            _dtIntruduceLetter.Rows.Add(_bunho, Resources.OCS2015U03_IntruduceLetter, true);

            foreach (DataRow drIntruduce in _dtIntruduceLetter.Rows)
            {
                TreeListNode node = tvHisExam.AppendNode(new object[] { drIntruduce["Bunho"], drIntruduce["Bunho"], drIntruduce["Name"], null, null, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, null, null, _bunho, drIntruduce["Name"] }, null);
                node.HasChildren = true;
                node.ImageIndex = 1;
            }
        }

        private void GenerateExamTreeviewClinicRefer(DataTable data, TreeListNode clinicNode, string hospCode, string hospName,string bunho)
        {
            List<TreeListNode> depts = new List<TreeListNode>();
            if (data != null && data.Rows.Count > 0)
            {
                // Departments
                DataView dv = new DataView(data);
                DataTable dtDept = dv.ToTable(true, "Gwa", "GwaName");
                dtDept.DefaultView.Sort = "Gwa" + " " + "ASC";
                dtDept = dtDept.DefaultView.ToTable();
                DataTable dtDeptClinicRefer;
                dtDeptClinicRefer = dtDept.Clone();
                foreach (DataRow dataRow in dtDept.Rows)
                {
                    dtDeptClinicRefer.ImportRow(dataRow);
                }

                foreach (DataRow drDept in dtDeptClinicRefer.Rows)
                {
                    foreach (DataRow dr in dtDept.Rows)
                    {
                        if (drDept["Gwa"].Equals(dr["Gwa"]))
                        {
                            TreeListNode node = tvHisExam.AppendNode(new object[] { dr["Gwa"], dr["GwaName"], dr["GwaName"], null, null, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, emptyIco, hospCode, hospName, bunho }, clinicNode);
                            node.HasChildren = true;
                            node.ImageIndex = 1;
                            depts.Add(node);
                        }
                    }
                }

                // Examination dates
                foreach (TreeListNode dept1 in depts)
                {
                    DataTable dtDates = dv.ToTable(true, "Gwa", "GwaName", "NaewonDate", "PkOut1001", "TimeStamp", "Icon1", "Icon2", "Icon3", "Icon4", "Icon5", "Icon6", "Icon7", "Icon8", "Icon9", "Icon10", "Icon11", "HopsCode", "HopsName","Bunho");
                    foreach (DataRow dr in dtDates.Select("Gwa = '" + dept1.GetValue("Gwa") + "'"))
                    {
                        tvHisExam.AppendNode(dr.ItemArray, dept1);
                    }
                }
            }
        }

        private void ctxHisExamMenu_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void Reset()
        {
            tvHisExam.Nodes.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dt != null && dt.Columns.Contains("TimeStamp") && _gwa != "")
            {
                if (true)
                {
                    if (_sortAsc)
                    {
                        dt.DefaultView.Sort = "TimeStamp" + " " + "ASC";
                        dt = dt.DefaultView.ToTable();
                        _sortAsc = !_sortAsc;
                    }
                    else
                    {
                        dt.DefaultView.Sort = "TimeStamp" + " " + "DESC";
                        dt = dt.DefaultView.ToTable();
                        _sortAsc = !_sortAsc;
                    }
                    GenerateExamTreeview(_gwa);
                }
            }
        }

        private bool _sortAsc = true;

        private void tvHisExam_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            e.NodeImageIndex = e.Node.Expanded ? 0 : 1;
            
        }
        public long ConvertToUnixTime(string naewonDate)
        {
            DateTime datetime = DateTime.Parse(naewonDate);
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(datetime - sTime).TotalSeconds;
        }
    }
}
