using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework;
using IHIS.NURO.Properties;

namespace IHIS.NURO
{
    public partial class ShowPWD : XForm
    {
        DataTable tbl_PatientInfo;
        string bunho = "";
        public ShowPWD( string bunhoShow)
        {
            InitializeComponent();
            bunho = bunhoShow;          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenPWD_Click(object sender, EventArgs e)
        {
            OUT0101U02ChangePWDArgs args = new OUT0101U02ChangePWDArgs();
            args.Bunho = bunho;
            args.Pwd = Utility.RandomString(8);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, OUT0101U02ChangePWDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && result.Result != false)
            {
                XMessageBox.Show(Resources.MSG_GENPASS, Resources.MSG_GENPASS_CAP, MessageBoxIcon.Information);
            }
            else
            {
                XMessageBox.Show(Resources.MSG_GENPASS_FAIL, Resources.MSG_GENPASS_CAP, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnShowPWD_Click(object sender, EventArgs e)
        {
            
            PrintOrder();
            this.Close();
            
        }
        private void PrintOrder()
        {
            this.GetDataTables();
            DataSet ds = new DataSet();
            XtraRpPrintPatient rpt = new XtraRpPrintPatient();
            ds.Tables.Add(tbl_PatientInfo);
            rpt.DataSource = ds;
            rpt.DataMember = "tblPatientInfo";
            //rpt.ShowPreviewDialog();
            rpt.Print();

        }

          private void GetDataTables()
        {
            tbl_PatientInfo = new DataTable("tblPatientInfo");
            tbl_PatientInfo.Columns.Add("patient_name");
            tbl_PatientInfo.Columns.Add("hosp_code");
            tbl_PatientInfo.Columns.Add("bunho");
            tbl_PatientInfo.Columns.Add("pwd");
            tbl_PatientInfo.Columns.Add("hosp_name");
            tbl_PatientInfo.Columns.Add("hosp_phone");
            tbl_PatientInfo.Columns.Add("hosp_address");
            string hospCode = UserInfo.HospCode.ToString() ;
            string patientName = string.Empty;            
            string pwd =string.Empty;
            string hospName = UserInfo.HospName.ToString();
            string hospPhone = string.Empty;
            string hospAddress = string.Empty;

            OUT0101U02GetHospitalInfoArgs args = new OUT0101U02GetHospitalInfoArgs();
            args.HospCode = UserInfo.HospCode.ToString();
            args.Bunho = bunho;
            OUT0101U02GetHospitalInfoResult result = CloudService.Instance
                .Submit<OUT0101U02GetHospitalInfoResult, OUT0101U02GetHospitalInfoArgs>(args);
            if (result != null)
            {
                //List<OUT0101U02HospitalItemInfo> ListItem = new List<OUT0101U02HospitalItemInfo>();
                //ListItem.Add(result.HospList);
                if (result.HospList.Count > 0)
                {
                    patientName = result.HospList[0].PatientName.ToString();
                    hospPhone = result.HospList[0].Tel.ToString();
                    hospAddress = result.HospList[0].Address.ToString();
                    pwd = result.HospList[0].Password.ToString();
                }
            }
            tbl_PatientInfo.Rows.Add(patientName, hospCode, bunho, pwd, hospName, hospPhone, hospAddress);
        }

       
       
    }
}