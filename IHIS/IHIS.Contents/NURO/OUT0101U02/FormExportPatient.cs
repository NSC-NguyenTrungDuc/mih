using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector;
using IHIS.Framework;
using System.IO;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Messaging;
using System.Threading;

namespace IHIS.NURO
{
    public partial class FormExportPatient : Form
    {
        public FormExportPatient()
        {
            InitializeComponent();
            DateTime now = EnvironInfo.GetSysDate();
            xDatePickerFrom.SetDataValue(now);
            xDatePickerTo.SetDataValue(now);
        }

        private void xButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            DialogResult dialogResult = folderDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                xTexBoxFileName.Text = folderDialog.SelectedPath;
            }
        }

        private void FormExportPatient_Load(object sender, EventArgs e)
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                xCheckBoxPatientId.Checked = true;
                xCheckBoxPatientName.Checked = true;
                xCheckBoxSex.Checked = true;
                xCheckBoxBirthday.Checked = true;
                xCheckBoxAddress.Checked = true;
                xCheckBoxPhoneNumber.Checked = true;
                xCheckBoxPatientType.Checked = true;

                // Hide some item
                xCheckBoxPatientName2.Visible = false;
                xCheckBoxPostalCode.Visible = false;
                xCheckBoxAddress2.Visible = false;
                xCheckBoxPaceMarkerYn.Visible = false;
                xCheckBoxSelfPaceMarker.Visible = false;
            }

            if (NetInfo.Language == LangMode.Jr)
            {
                xCheckBoxPatientId.Checked = true;
                xCheckBoxPatientName.Checked = true;
                xCheckBoxPatientName2.Checked = true;
                xCheckBoxSex.Checked = true;
                xCheckBoxBirthday.Checked = true;
                xCheckBoxPostalCode.Checked = true;
                xCheckBoxAddress.Checked = true;
                xCheckBoxAddress2.Checked = true;
            }
        }

        private void xButtonExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private string GetCheckBoxValue(bool isChecked)
        {
            if (isChecked) return "1";
            return "";
        }

        private OUT0101U02PatientExportArgs CreateExportParameter()
        {

            OUT0101U02PatientExportArgs args = new OUT0101U02PatientExportArgs();
            args.HeaderItem = new IHIS.CloudConnector.Contracts.Models.Nuro.OUT0101U02PatientExportInfo();

            args.HeaderItem.SystemId = "";

            args.StartDate = xDatePickerFrom.GetDataValue();
            args.EndDate = xDatePickerTo.GetDataValue();

            int compared = string.Compare(args.StartDate, args.EndDate);
            if (compared>0)
            {
                // The start date must great than the to date
                XMessageBox.Show(IHIS.NURO.Properties.Resources.MessageStartDateEndDate, IHIS.NURO.Properties.Resources.MSG_GENPASS_CAP);
                return null;
            }

            args.HeaderItem.CreatedDate = GetCheckBoxValue(xCheckBoxCreatedDate.Checked);
            args.HeaderItem.CreatedAdmin = GetCheckBoxValue(xCheckBoxCreatedAdmin.Checked);

            args.HeaderItem.UpdateDate = GetCheckBoxValue(xCheckBoxUpdateDate.Checked);
            args.HeaderItem.UpdateAdmin = GetCheckBoxValue(xCheckBoxUpdateAdmin.Checked);
            args.HeaderItem.HospitalCode = GetCheckBoxValue(xCheckBoxHospitalCode.Checked);
            args.HeaderItem.PatientCode = GetCheckBoxValue(xCheckBoxPatientId.Checked);

            args.HeaderItem.Suname = GetCheckBoxValue(xCheckBoxPatientName.Checked);
            args.HeaderItem.Suname2 = GetCheckBoxValue(xCheckBoxPatientName2.Checked);
            args.HeaderItem.Sex = GetCheckBoxValue(xCheckBoxSex.Checked);
            args.HeaderItem.Birthday = GetCheckBoxValue(xCheckBoxBirthday.Checked);

            args.HeaderItem.PostalCode = GetCheckBoxValue(xCheckBoxPostalCode.Checked);
            args.HeaderItem.Address1 = GetCheckBoxValue(xCheckBoxAddress.Checked);
            args.HeaderItem.Address2 = GetCheckBoxValue(xCheckBoxAddress2.Checked);
            args.HeaderItem.PhoneNumber = GetCheckBoxValue(xCheckBoxPhoneNumber.Checked);
            args.HeaderItem.PhoneNumber2 = GetCheckBoxValue(xCheckBoxPhoneNumber2.Checked);
            args.HeaderItem.PhoneNumber3 = GetCheckBoxValue(xCheckBoxPhoneNumber3.Checked);

            args.HeaderItem.PhoneType1 = GetCheckBoxValue(xCheckBoxPhoneType.Checked);
            args.HeaderItem.PhoneType2 = GetCheckBoxValue(xCheckBoxPhoneType2.Checked);
            args.HeaderItem.PhoneType3 = GetCheckBoxValue(xCheckBoxPhoneType3.Checked);
            args.HeaderItem.InsuranceType = GetCheckBoxValue(xCheckBoxInsuranceType.Checked);

            args.HeaderItem.InteruptedReception = GetCheckBoxValue(xCheckBoxInteruptedReception.Checked);
            args.HeaderItem.InteruptedReceptionReason = GetCheckBoxValue(xCheckBoxInteruptedReceptionReason.Checked);
            args.HeaderItem.Detete = GetCheckBoxValue(xCheckBoxDelete.Checked);
            args.HeaderItem.PatientNote = GetCheckBoxValue(xCheckBoxPatientNote.Checked);

            args.HeaderItem.EmailAddress = GetCheckBoxValue(xCheckBoxEmailAddress.Checked);
            args.HeaderItem.PaceMakerYn = GetCheckBoxValue(xCheckBoxPaceMarkerYn.Checked);
            args.HeaderItem.SelfPaceMaker = GetCheckBoxValue(xCheckBoxSelfPaceMarker.Checked);
            args.HeaderItem.Password = GetCheckBoxValue(xCheckBoxPasswork.Checked);
            args.HeaderItem.PatientType = GetCheckBoxValue(xCheckBoxPatientType.Checked);

            string sumChecked = args.HeaderItem.CreatedDate
                + args.HeaderItem.CreatedAdmin

                + args.HeaderItem.UpdateDate
                + args.HeaderItem.UpdateAdmin
                + args.HeaderItem.HospitalCode
                + args.HeaderItem.PatientCode

                + args.HeaderItem.Suname
                + args.HeaderItem.Suname2
                + args.HeaderItem.Sex
                + args.HeaderItem.Birthday

                + args.HeaderItem.PostalCode
                + args.HeaderItem.Address1
                + args.HeaderItem.Address2
                + args.HeaderItem.PhoneNumber
                + args.HeaderItem.PhoneNumber2
                + args.HeaderItem.PhoneNumber3

                + args.HeaderItem.PhoneType1
                + args.HeaderItem.PhoneType2
                + args.HeaderItem.PhoneType3
                + args.HeaderItem.InsuranceType

                + args.HeaderItem.InteruptedReception
                + args.HeaderItem.InteruptedReceptionReason
                + args.HeaderItem.Detete
                + args.HeaderItem.PatientNote

                + args.HeaderItem.EmailAddress
                + args.HeaderItem.PaceMakerYn
                + args.HeaderItem.SelfPaceMaker
                + args.HeaderItem.Password
                + args.HeaderItem.PatientType;

            if (sumChecked == "")
            {
                // You must select at least one item
                XMessageBox.Show(IHIS.NURO.Properties.Resources.MessageSelectOne, IHIS.NURO.Properties.Resources.MSG_GENPASS_CAP);
                return null;
            }

            return args;
        }

        private void ExportData()
        {

            OUT0101U02PatientExportArgs args = CreateExportParameter();
            if (args == null) return;

            // Display progress bar

            // Display the ProgressBar control.
            progBar.Visible = true;
            // Set Minimum to 1 to represent the first row being processed.
            progBar.Minimum = 0;
            // Set Maximum to the total number of rows to process.
            progBar.Maximum = 4;
            // Set the initial value of the ProgressBar.
            progBar.Value = 1;
            // Set the Step property to a value of 1 to represent each row being processed.
            progBar.Step = 1;

            // Step 1
            progBar.PerformStep();
            OUT0101U02PatientExportResult result = CloudService.Instance.Submit<OUT0101U02PatientExportResult, OUT0101U02PatientExportArgs>(args);

            // Step 2
            progBar.PerformStep();
            string folderName = xTexBoxFileName.Text;

            bool isValidPath = Directory.Exists(xTexBoxFileName.Text);
            if (!isValidPath)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                DialogResult folderResult = folder.ShowDialog();
                if (folderResult != DialogResult.OK || folder.SelectedPath == "")
                {
                    progBar.Visible = false;
                    return; 
                }
                folderName = folder.SelectedPath;
                xTexBoxFileName.Text = folderName;
            }
            string fileName = string.Format("{0}//{1}", folderName, DateTime.Now.ToString("yyyyMMddhhmmss"));
            bool saved = DataFile.SaveToCsvFile(fileName, result.Data[0]);

            // Step 3
            progBar.PerformStep();

            // Step 4
            progBar.PerformStep();
            if (saved)
            {
                XMessageBox.Show(IHIS.NURO.Properties.Resources.MessageExportSuccessfully, IHIS.NURO.Properties.Resources.MSG_GENPASS_CAP);
            }
            else {
                XMessageBox.Show(IHIS.NURO.Properties.Resources.MessageExportFail, IHIS.NURO.Properties.Resources.MSG_GENPASS_CAP);
            }

            // Hide the progres bar
            progBar.Visible = false;

        }

        private bool PerformProcessing()
        {
            bool ret = true;

            // Display the ProgressBar control.
            progBar.Visible = true;
            // Set Minimum to 1 to represent the first row being processed.
            progBar.Minimum = 1;
            // Set Maximum to the total number of rows to process.
            progBar.Maximum = 10;
            // Set the initial value of the ProgressBar.
            progBar.Value = 1;
            // Set the Step property to a value of 1 to represent each row being processed.
            progBar.Step = 1;


            for (int i = 0; i < 5; i++)
            {
                progBar.PerformStep();
                Thread.Sleep(1000);

            }

            return ret;
        }

        private void xButtonList3_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Close)
            {
                Close();
            }
        }
    }
}