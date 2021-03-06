using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EmrDocker;
using EmrDocker.Glossary;
using EmrDocker.Models;
using EmrDocker.Types;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;
//using IHIS.OCSO.Meta;
using IHIS.NURO.Report;
using MedicalInterfaceTest;
using Newtonsoft.Json;
using IHIS.OCSO;
using Utilities = IHIS.OCSO.Utilities;

//using Utilities = IHIS.OCSO.Utilities;
namespace IHIS.NURO
{
    //using EmrDocker.Meta;
    //using EmrDocker.Models;
    //using EmrDocker;
    //using ERMUserControl;
    using System.IO;
    //using EmrDocker.Glossary;
    using DevExpress.XtraRichEdit.API.Native.Implementation;
    using GhostscriptSharp;
    using IHIS.CloudConnector.Utility;

    public partial class NUR2015U01 : IHIS.Framework.XScreen
    {
        private string mHospCode;
        private string mBunho;
        private string mUserId;
        private string mNaewonDate;
        private string mNaewonKey;
        private string mImageName;
        private string mDoctor;
        private UcGrid ucGrid;
        //private Dictionary<string, UserData> metaDictionary = new Dictionary<string, UserData>();
        //private List<TagInfo> orderList = new List<TagInfo>();
        List<EmrRecordInfo> existingRecord = new List<EmrRecordInfo>();
        private string emrContent = "";
        private int masterId = 0;
        //private string mFilePath = Application.StartupPath + "\\" + "Intro" + "Images" + "\\" + "Intro"; // save file image
        private string mFilePath = "";
        private bool isPatientValid = false;
        DataTable tbl_PatientIntroduceLetter;
        PatientModelInfo mPatientModelInfo;
        HospitalModelInfo mHospitalModelInfo;
        private bool isEditImage = false;
        private int countImageLoadSucess = 0;
        public NUR2015U01()
        {
            if (OpenParam["f_image_name"] != null)
            {
                this.mImageName = OpenParam["f_image_name"].ToString();
            }
            InitializeComponent();

            //MED-12110
            ApplyMultiResolution();

            //Load first picture
            ShowViewPictureBox(false, false, false, false, false);
        }

        private void ApplyMultiResolution()
        {
            int width = SystemInformation.VirtualScreen.Width;
            int height = SystemInformation.VirtualScreen.Height;

            if (width == 1366 && height == 768)
            {
                this.picEdit1.Size = new Size(120, 34);
                this.picEdit2.Size = new Size(120, 34);
                this.picEdit3.Size = new Size(120, 34);
                this.picEdit4.Size = new Size(120, 34);
                this.picEdit5.Size = new Size(120, 34);
                xPictureBox1.Location = new Point(184, 43);
                xPictureBox2.Location = new Point(306, 43);
                xPictureBox3.Location = new Point(427, 43);
                xPictureBox4.Location = new Point(557, 43);
                xPictureBox5.Location = new Point(672, 43);
                panel1.Location = new Point(0, 36);
                panel1.Height = 578;
                pnlContainer.BorderStyle = BorderStyle.None;
                xPanel9.BorderStyle = BorderStyle.None;
                this.Height = 618;
            }
        }

        private void NUR2015U01_Load(object sender, EventArgs e)
        {
            if (this.OpenParam != null)
            {
                if (OpenParam["f_bunho"] != null)
                {
                    this.mBunho = OpenParam["f_bunho"].ToString();
                }
                if (OpenParam["f_hosp_code"] != null)
                {
                    this.mHospCode = OpenParam["f_hosp_code"].ToString();
                }
                else
                {
                    this.mHospCode = UserInfo.HospCode;
                }
                this.mFilePath = Application.StartupPath + "\\" + "Data" + "\\" + this.mHospCode;

                if (OpenParam["f_user_id"] != null)
                {
                    this.mUserId = OpenParam["f_user_id"].ToString();
                }
                if (OpenParam["f_naewon_date"] != null)
                {
                    this.mNaewonDate = OpenParam["f_naewon_date"].ToString();
                }
                if (OpenParam["f_naewon_key"] != null)
                {
                    this.mNaewonKey = OpenParam["f_naewon_key"].ToString();
                }
                if (OpenParam["doctor"] != null)
                {
                    this.mDoctor = OpenParam["doctor"].ToString();
                }
                if (OpenParam["mOpener"] != null)
                {
                    //Fix bug MED-10275
                    //if (OpenParam["mOpener"].ToString() != "NUR2001U04")
                    if(OpenParam["mOpener"].ToString() != "NUR2001U04" && OpenParam["mOpener"].ToString() != "NUR2016U03")
                    {
                        this.btnList.SetEnabled(FunctionType.Reset, false);
                        this.btnList.SetEnabled(FunctionType.Update, false);
                        this.btnBrowse.Enabled = false;
                    }
                }
            }
            mPatientModelInfo = new PatientModelInfo();
            mPatientModelInfo.PatientId = this.mBunho;
            mPatientModelInfo.PatientBirthday = OpenParam["birth"] == null
                ? string.Empty
                : OpenParam["birth"].ToString();
            mPatientModelInfo.PatientGender = OpenParam["age_sex"] == null
                ? string.Empty
                : OpenParam["age_sex"].ToString();

            this.xPaBox.SetPatientID(this.mBunho, this.mHospCode);
            // 2015.09.24 AnhNV fixes https://nextop-asia.atlassian.net/browse/MED-4323
            //DataProvider.Instance.TagDisplayModeSetup(barTagOptions);

            //DataProvider.Instance.ReloadLatestTags();
            //ucGrid = new UcGrid();
            //ucGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.pnlContainer.Controls.Add(ucGrid);
            //ucGrid.LoadGrid(string.Empty, mPatientModelInfo, this.mNaewonKey, string.Empty, false, false, null);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    countImageLoadSucess = 0;
                    e.IsBaseCall = false;
                    if (!isPatientValid) return;

                    OCS2015U06EmrRecordArgs getEmrRecordArgs = new OCS2015U06EmrRecordArgs();
                    getEmrRecordArgs.Bunho = xPaBox.BunHo;
                   // getEmrRecordArgs.HospCode = UserInfo.HospCode;
                    getEmrRecordArgs.HospCode = this.mHospCode;
                    OCS2015U06EmrRecordResult emrRecordResult =
                        CloudService.Instance.Submit<OCS2015U06EmrRecordResult, OCS2015U06EmrRecordArgs>(getEmrRecordArgs);
                    if (emrRecordResult.ExecutionStatus == ExecutionStatus.Success && emrRecordResult.EmrRecordList != null)
                    {
                        if (emrRecordResult.EmrRecordList.Count > 0)
                        {
                            this.emrContent = emrRecordResult.EmrRecordList[0].Content;
                        }
                        else
                        {
                            this.emrContent = "";
                            //existingRecord.Clear();
                        }
                    }

                    if (emrContent != "")
                    {
                        //Tuple<List<EmrRecordInfo>, PatientModelInfo> lstInfo = MmlParser.Instance.ToModel(this.emrContent);
                        Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo> lstInfo = MmlParserIntruduceLetter.Instance.ToModel(this.emrContent);
                        this.existingRecord = lstInfo.V1;
                        mPatientModelInfo = lstInfo.V2;
                        mHospitalModelInfo = lstInfo.V3;
                        //AppendPatientToExistingRecord();
                    }
                    this.grdOrder.ExecuteQuery = LoadDataGrdOrder;
                    this.grdOrder.QueryLayout(true);
                    //MED-12219
                    CheckEmptyRecord();
                    break;
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    if (grdOrder.RowCount == 0) break;
                    #region Clear Image Controls

                    //MED-11003
                    //ClearImageControls();
                    //int currentIndex = GetIndexByNaewonKey(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"));
                    //if (currentIndex > -1)
                    //{
                    //    for (int i = 0; i < existingRecord[currentIndex].TagInfos.Count; i++)
                    //    {
                    //        if (existingRecord[currentIndex].TagInfos[i].TagCode == "L22")
                    //        {
                    //            existingRecord[currentIndex].TagInfos.RemoveAt(i);
                    //            break;
                    //        }
                    //    }
                    //}

                   

                    //txtFromAddress.Text = "";
                    //txtFromDrRequest.Text = "";
                    //txtFromFax.Text = "";
                    //txtFromHospName.Text = "";
                    //txtFromTel.Text = "";
                    //txtPresentIllness.Text = "";
                    //txtPastHistory.Text = "";
                    //txtTestResults.Text = "";
                    //txtClinicalCourse.Text = "";
                    //txtMedication.Text = "";
                    //txtRemarks.Text = "";
                    //txtPurpose.Text = "";
                    //txtFamilyHistory.Text = "";

                    //TextBox_DataValidating(txtFromAddress, null);
                    //TextBox_DataValidating(txtFromDrRequest, null);
                    //TextBox_DataValidating(txtFromFax, null);
                    //TextBox_DataValidating(txtFromHospName, null);
                    //TextBox_DataValidating(txtFromTel, null);
                    //TextBox_DataValidating(txtPresentIllness, null);
                    //TextBox_DataValidating(txtPastHistory, null);
                    //TextBox_DataValidating(txtTestResults, null);
                    //TextBox_DataValidating(txtClinicalCourse, null);
                    //TextBox_DataValidating(txtMedication, null);
                    //TextBox_DataValidating(txtRemarks, null);
                    //TextBox_DataValidating(txtPurpose, null);
                    //TextBox_DataValidating(txtFamilyHistory, null);
                     #endregion
                    ResetControl();

                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = false;
                    
                    if (!isPatientValid) return;
                    //MED-10300
                    if (!checkNothingInput())
                    {
                        XMessageBox.Show(Resources.Caption17, Resources.Cap_Error, MessageBoxIcon.Error);
                        return;
                    }

                    //update image tag first
                    SaveImages();

                    mPatientModelInfo.PatientName = xPaBox.SuName;
                    mPatientModelInfo.PatientAddress = xPaBox.Address1;
                    mPatientModelInfo.PatientBirthday = xPaBox.Birth;
                    mPatientModelInfo.PatientGender = xPaBox.Sex;
                    mPatientModelInfo.PatientTelephone = xPaBox.Tel;
                    mPatientModelInfo.PatientEmail = txtPaEmail.Text;

                    //mHospitalModelInfo = new HospitalModelInfo();
                    //mHospitalModelInfo.DoctorRequest = txtFromDrRequest.Text;
                    //mHospitalModelInfo.HospAddress = txtFromAddress.Text;
                    //mHospitalModelInfo.HospFax = txtFromFax.Text;
                    //mHospitalModelInfo.HospName = txtFromHospName.Text;
                    //mHospitalModelInfo.HospTel = txtFromTel.Text;

                    NUR2015U01EmrRecordUpdateArgs arg = new NUR2015U01EmrRecordUpdateArgs();
                    arg.Bunho = mBunho;
                    arg.Content = MmlParserIntruduceLetter.Instance.ToMmL(this.existingRecord, mPatientModelInfo, emrContent);
                    arg.Metadata = string.Empty;
                    arg.SysId = mUserId;
                    arg.RecordLog = "Create new";
                    UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, NUR2015U01EmrRecordUpdateArgs>(arg);
                    if (updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                    {
                        XMessageBox.Show(Resources.MSG_SAVE_SUCCESS);
                        //this.Close();
                        btnList.PerformClick(FunctionType.Query);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.Caption17, Resources.Cap_Error, MessageBoxIcon.Error);
                    }

                    break;
                case FunctionType.Insert:
                    // https://sofiamedix.atlassian.net/browse/MED-11937
                    e.IsBaseCall = false;
                    OpenFormSelectExam();
                    //MED-12219
                    CheckEmptyRecord();
                    break;

            }
        }

        private void ClearImageControls()
        {
            fileName1 = "";
            safeFileName1 = "";
            picEdit1.Image = null;
            picEdit1.Visible = false;
            xPictureBox1.Visible = false;

            fileName2 = "";
            safeFileName2 = "";
            picEdit2.Image = null;
            picEdit2.Visible = false;
            xPictureBox2.Visible = false;

            fileName3 = "";
            safeFileName3 = "";
            picEdit3.Image = null;
            picEdit3.Visible = false;
            xPictureBox3.Visible = false;

            fileName4 = "";
            safeFileName4 = "";
            picEdit4.Image = null;
            picEdit4.Visible = false;
            xPictureBox4.Visible = false;

            fileName5 = "";
            safeFileName5 = "";
            picEdit5.Image = null;
            picEdit5.Visible = false;
            xPictureBox5.Visible = false;
        }

        public void Upload(string filePath)
        {
            //TODO need override this test code
            string localPath = Utilities.ConvertToLocalPath(filePath, this.mHospCode, mPatientModelInfo.PatientId);
            // MED-10181
            //string uploadAddress = ConfigurationManager.AppSettings["UploadBaseUri"]; //http://10.1.20.2:8010/upload
            string uploadAddress = Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

            string uploadToken = ConfigurationManager.AppSettings["UploadToken"]; //"1234"
            Uri address = new Uri(uploadAddress);
            Utilities.UploadFile(address, localPath, uploadToken, this.mHospCode, mPatientModelInfo.PatientId);
        }

        private void SaveImages()
        {
            int currentRecordRow = GetIndexByNaewonKey(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"));
            if (currentRecordRow == -1)
            {
                ModifyExistingRecord(FunctionType.Insert, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "department"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "exam_date"));
                currentRecordRow = GetIndexByNaewonKey(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"));
            }

            int existedAttachments =countImageLoadSucess;
            //foreach(TagInfo tag in this.existingRecord[currentRecordRow].TagInfos)
            //{
            //    if (tag.TagCode == "L22") existedAttachments++;
            //}
            if (safeFileName1 != "" && existedAttachments < 1)
            {
                AppendImageTagInfo(currentRecordRow, safeFileName1);
            }

            if (safeFileName2 != "" && existedAttachments < 2)
            {
                AppendImageTagInfo(currentRecordRow, safeFileName2);

            }

            if (safeFileName3 != "" && existedAttachments < 3)
            {
                AppendImageTagInfo(currentRecordRow, safeFileName3);
            }

            if (safeFileName4 != "" && existedAttachments < 4)
            {
                AppendImageTagInfo(currentRecordRow, safeFileName4);
            }

            if (safeFileName5 != "" && existedAttachments < 5)
            {
                AppendImageTagInfo(currentRecordRow, safeFileName5);
            }

        }

        private void AppendImageTagInfo(int currentRecord, string safeFileName)
        {
            //Create taginfo for inputing to existingRecords
            TagInfo tagInfo = new TagInfo();
            tagInfo.TagCode = "L22";
            string fileType = safeFileName.Remove(0, safeFileName.Trim().Length - 3);
            tagInfo.Type = fileType.ToLower() == "pdf" ? TypeEnum.Pdf : TypeEnum.Image;
            tagInfo.DirLocation = safeFileName;

            this.existingRecord[currentRecord].TagInfos.Add(tagInfo);
            Upload(tagInfo.DirLocation);
        }

        private void ModifyExistingRecord(FunctionType functionType, string departmentCode, string naewonKey, string naewonDate)
        {
            switch (functionType)
            {
                case FunctionType.Insert:
                    EmrRecordInfo newRecordInfo = new EmrRecordInfo();
                    List<TagInfo> listTagInfos = new List<TagInfo>();


                    listTagInfos.Add(GenerateTagInfo("L7", TypeEnum.Tag, lblPatientName.Text));
                    listTagInfos.Add(GenerateTagInfo("L8", TypeEnum.Tag, txtPaAddress.Text));
                    listTagInfos.Add(GenerateTagInfo("L9", TypeEnum.Tag, txtPaDob.Text));
                    listTagInfos.Add(GenerateTagInfo("L10", TypeEnum.Tag, txtPaGender.Text));
                    listTagInfos.Add(GenerateTagInfo("L11", TypeEnum.Tag, txtPaTel.Text));
                    listTagInfos.Add(GenerateTagInfo("L12", TypeEnum.Tag, txtPaEmail.Text));
                    listTagInfos.Add(GenerateTagInfo("L13", TypeEnum.Tag, naewonKey));
                    listTagInfos.Add(GenerateTagInfo("L6", TypeEnum.Tag, naewonDate));
                    listTagInfos.Add(GenerateTagInfo("L23", TypeEnum.Tag, departmentCode));

                    //insert empty tags
                    listTagInfos.Add(GenerateTagInfo("L1", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L2", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L5", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L3", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L4", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L14", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L15", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L16", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L17", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L18", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L19", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L20", TypeEnum.Tag, ""));
                    listTagInfos.Add(GenerateTagInfo("L21", TypeEnum.Tag, ""));

                    newRecordInfo.TagInfos.AddRange(listTagInfos);
                    this.existingRecord.Add(newRecordInfo);
                    break;


            }
        }

        private TagInfo GenerateTagInfo(string tagCode, TypeEnum tagType, string content)
        {
            TagInfo tagInfo = new TagInfo();
            tagInfo.TagCode = tagCode;
            tagInfo.Type = tagType;
            tagInfo.Content = content;

            return tagInfo;
        }

        private IList<object[]> LoadDataGrdOrder(BindVarCollection varlist)
        {
            //IList<object[]> lstData = new List<object[]>();
            //NUR2015U01GrdOrderArgs args = new NUR2015U01GrdOrderArgs();
            //args.Bunho = this.xPaBox.BunHo;
            //args.HospCode = this.mHospCode;

            //NUR2015U01GrdOrderResult result =
            //    CloudService.Instance.Submit<NUR2015U01GrdOrderResult, NUR2015U01GrdOrderArgs>(args);
            //if (result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    foreach (NUR2015U01GrdOrderInfo info in result.GrdOrderList)
            //    {
            //        lstData.Add(new object[]
            //        {
            //            info.ExamDate,
            //            info.GwaName,
            //            info.NaewonKey
            //        });
            //    }
            //}
            //return lstData;           
            // https://sofiamedix.atlassian.net/browse/MED-11937
            IList<object[]> lObj = new List<object[]>();

            foreach (EmrRecordInfo emrRecordInfo in existingRecord)
            {
                NUR2015U01GrdOrderInfo info = new NUR2015U01GrdOrderInfo();
                foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                {
                    string content = tagInfo.Content == null ? string.Empty : tagInfo.Content.ToString();
                    switch (tagInfo.TagCode)
                    {
                        case "L6":
                            info.ExamDate = content;
                            break;
                        case "L13":
                            info.NaewonKey = content;
                            break;
                        case "L23":
                            info.GwaName = content;
                            break;
                        default:
                            break;
                    }
                }
                lObj.Add(new object[]
                        {
                            info.ExamDate,
                            info.GwaName,
                            info.NaewonKey
                        });
            }

            return lObj;
        }

        private void xPaBox_PatientSelected(object sender, EventArgs e)
        {
            //NUR2015U01ReservationPatientArgs args = new NUR2015U01ReservationPatientArgs(xPaBox.BunHo);
            //NUR2015U01ReservationPatientResult result =
            //    CloudService.Instance.Submit<NUR2015U01ReservationPatientResult, NUR2015U01ReservationPatientArgs>(args);
            //if (result.ExecutionStatus != ExecutionStatus.Success || result.ReservationId == "")
            //{
            //    XMessageBox.Show(Resources.MSG_VALIDATE_PATIENT,
            //        Resources.WARN, MessageBoxIcon.Error);
            //    this.xPaBox.Focus();
            //    this.isPatientValid = false;
            //    return;
            //}
            //this.mNaewonKey = result.ReservationId;
            this.isPatientValid = true;
            this.lblPatientName.Text = this.xPaBox.SuName;
            this.txtPaAddress.Text = this.xPaBox.Address1;
            this.txtPaDob.Text = this.xPaBox.Birth;
            this.txtPaGender.Text = GetSex(this.xPaBox.Sex);
            this.txtPaTel.Text = this.xPaBox.Tel;
            this.txtPaEmail.Text = this.xPaBox.Email;
            this.mBunho = xPaBox.BunHo;

            this.btnList.PerformClick(FunctionType.Query);
        }

        #region Gen Picture Box
        private string fileName1 = "";
        private string fileName2 = "";
        private string fileName3 = "";
        private string fileName4 = "";
        private string fileName5 = "";
        private string safeFileName1 = "";
        private string safeFileName2 = "";
        private string safeFileName3 = "";
        private string safeFileName4 = "";
        private string safeFileName5 = "";

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (picEdit1.Visible && picEdit2.Visible && picEdit3.Visible && picEdit4.Visible && picEdit5.Visible) return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                string max_size = string.Empty;
                if (!Utilities.CheckPdfUploadFile(dialog.FileName, out max_size))
                {
                    XMessageBox.Show(string.Format(Resources.EMR_PDF_MAX_SIZE, max_size), Resources.WARN);
                    return;
                }

                this.isEditImage = true;
                int maxLenght = dialog.FileName.ToString().Trim().Length;
                string fileType = dialog.FileName.ToString().Remove(0, maxLenght - 3);
                if (dialog.SafeFileName != null)
                    InsertImage(dialog.FileName, fileType, dialog.SafeFileName, true,true);
            }
        }

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            #region Clear Image Controls

            ClearImageControls();

            //MED-12222
            countImageLoadSucess = 0;

            #endregion


            int currentRow = grdOrder.CurrentRowNumber;
            this.lblPatientName.Text = this.xPaBox.SuName;
            this.txtPaAddress.Text = this.xPaBox.Address1;
            this.txtPaDob.Text = this.xPaBox.Birth;
            this.txtPaGender.Text = GetSex(this.xPaBox.Sex);
            this.txtPaTel.Text = this.xPaBox.Tel;
            this.txtPaEmail.Text = this.xPaBox.Email;
            this.lblNo.Text = this.grdOrder.GetItemString(currentRow, "naewon_key");
            this.dtpReceiveDate.Text = this.grdOrder.GetItemString(currentRow, "exam_date");
            this.mNaewonKey = lblNo.Text;

            int currentRecordRow = GetIndexByNaewonKey(grdOrder.GetItemString(currentRow, "naewon_key"));
            if (currentRecordRow > -1)
            {
                EmrRecordInfo emrRecordInfo = existingRecord[currentRecordRow];
                foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                {
                    string content = tagInfo.Content == null ? string.Empty : tagInfo.Content.ToString();
                    switch (tagInfo.TagCode)
                    {
                        case "L1":
                            txtFromHospName.Text = content;
                            break;
                        case "L2":
                            txtFromAddress.Text = content;
                            break;
                        case "L3":
                            txtFromFax.Text = content;
                            break;
                        case "L4":
                            txtFromDrRequest.Text = content;
                            break;
                        case "L5":
                            txtFromTel.Text = content;
                            break;
                        case "L6":
                            dtpReceiveDate.SetDataValue( content);
                            break;
                        case "L7":
                            lblPatientName.Text = content;
                            break;
                        case "L8":
                            txtPaAddress.Text = content;
                            break;
                           
                        case "L9":
                            txtPaDob.Text = content;
                            break;
                        case "L10":
                            txtPaGender.Text = GetSex(content);
                            break;
                        case "L11":
                            txtPaTel.Text = content;
                            break;
                        case "L12":
                            txtPaEmail.Text = content;
                            break;
                        case "L13":
                            lblNo.Text = content;
                            break;
                        case "L14":
                            txtPresentIllness.Text = content;
                            break;
                        case "L15":
                            txtPurpose.Text = content;
                            break;
                        case "L16":
                            txtPastHistory.Text = content;
                            break;
                        case "L17":
                            txtFamilyHistory.Text = content;
                            break;
                        case "L18":
                            txtTestResults.Text = content;
                            break;
                        case "L19":
                            txtClinicalCourse.Text = content;
                            break;
                        case "L20":
                            txtMedication.Text = content;
                            break;
                        case "L21":
                            txtRemarks.Text = content;
                            break;
                        case "L22":
                            if (tagInfo.Type == TypeEnum.Image)
                            {
                                //get content
                                string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", this.mHospCode, mBunho);
                                if (!File.Exists(filePathLocal))
                                {
                                    Utilities.DownloadFile(filePathLocal, this.mHospCode, mBunho);
                                }
                                InsertImage(filePathLocal, "jpeg", Utilities.GetFileName(filePathLocal), true,false);
                                DisableDeleteButton();

                            }
                            else
                            {
                                string filePathLocalPdf = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", this.mHospCode, mBunho);
                                if (!File.Exists(filePathLocalPdf))
                                {
                                    Utilities.DownloadFile(filePathLocalPdf, this.mHospCode, mBunho);

                                    //string thumbnailFilePath = !string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Replace(".pdf", ".jpeg") : "";
                                    //string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(thumbnailFilePath) ? thumbnailFilePath.Trim() : "", UserInfo.HospCode, mBunho);
                                    //if (!File.Exists(filePathLocal)) Utilities.DownloadFile(filePathLocal, UserInfo.HospCode, mBunho);                                    
                                }
                                InsertImage(filePathLocalPdf, "pdf", Utilities.GetFileName(filePathLocalPdf), true,false);
                                DisableDeleteButton();
                            }
                            break;
                        case "L23":
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                txtFromAddress.Text = "";
                txtFromDrRequest.Text = "";
                txtFromFax.Text = "";
                txtFromHospName.Text = "";
                txtFromTel.Text = "";
                txtPresentIllness.Text = "";
                txtPastHistory.Text = "";
                txtTestResults.Text = "";
                txtClinicalCourse.Text = "";
                txtMedication.Text = "";
                txtRemarks.Text = "";
                txtPurpose.Text = "";
                txtFamilyHistory.Text = "";
            }
        }

        private void DisableDeleteButton()
        {
            this.xPictureBox1.Visible = false;
            this.xPictureBox2.Visible = false;
            this.xPictureBox3.Visible = false;
            this.xPictureBox4.Visible = false;
            this.xPictureBox5.Visible = false;
        }

        private void TextBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            int currentRecordRow = GetIndexByNaewonKey(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"));
            if (currentRecordRow == -1)
            {
                ModifyExistingRecord(FunctionType.Insert, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "department"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "exam_date"));
                currentRecordRow = GetIndexByNaewonKey(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "naewon_key"));
            }
            XTextBox txtValue = sender as XTextBox;
            switch (txtValue.Name)
            {
                case "txtFromHospName":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L1", txtFromHospName.Text);
                    }
                    break;
                case "txtFromAddress":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L2", txtFromAddress.Text);
                    }
                    break;
                case "txtFromTel":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L5", txtFromTel.Text);
                    }
                    break;
                case "txtFromFax":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L3", txtFromFax.Text);
                    }
                    break;
                case "txtFromDrRequest":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L4", txtFromDrRequest.Text);
                    }
                    break;
                case "txtPresentIllness":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L14", txtPresentIllness.Text);
                    }
                    break;
                case "txtPurpose":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L15", txtPurpose.Text);
                    }
                    break;
                case "txtPastHistory":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L16", txtPastHistory.Text);
                    }
                    break;
                case "txtFamilyHistory":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L17", txtFamilyHistory.Text);
                    }
                    break;
                case "txtTestResults":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L18", txtTestResults.Text);
                    }
                    break;
                case "txtClinicalCourse":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L19", txtClinicalCourse.Text);
                    }
                    break;
                case "txtMedication":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L20", txtMedication.Text);
                    }
                    break;
                case "txtRemarks":
                    if (currentRecordRow > -1)
                    {
                        BindTextToExistingRecord(currentRecordRow, "L21", txtRemarks.Text);
                    }
                    break;
            }
        }

        private void BindTextToExistingRecord(int currentRecord, string tagCode, string content)
        {
            for (int i = 0; i < this.existingRecord[currentRecord].TagInfos.Count; i++)
            {
                if (this.existingRecord[currentRecord].TagInfos[i].TagCode == tagCode)
                {
                    this.existingRecord[currentRecord].TagInfos[i].Content = content;
                    break;
                }
            }
        }

        private int GetIndexByNaewonKey(string naewonKey)
        {
            for (int i = 0; i < existingRecord.Count; i++)
            {
                foreach (TagInfo tagInfo in existingRecord[i].TagInfos)
                {
                    if (tagInfo.TagCode == "L13" && tagInfo.Content.ToString() == naewonKey)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private void ShowViewPictureBox(bool isShowPic1, bool isShowPic2, bool isShowPic3, bool isShowPic4, bool isShowPic5)
        {
            picEdit1.Visible = isShowPic1;
            picEdit2.Visible = isShowPic2;
            picEdit3.Visible = isShowPic3;
            picEdit4.Visible = isShowPic4;
            picEdit5.Visible = isShowPic5;

            xPictureBox1.Visible = isShowPic1;
            xPictureBox2.Visible = isShowPic2;
            xPictureBox3.Visible = isShowPic3;
            xPictureBox4.Visible = isShowPic4;
            xPictureBox5.Visible = isShowPic5;
        }
        private void InsertImage(string imagePath, string fileType, string safeFileName, bool showControl,bool isUserSelect)
        {
            string filePath = "";

            if (fileType.ToLower() == "pdf")
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(mFilePath + "\\" + this.xPaBox.BunHo + "\\");
                    if (!fileInfo.Exists)
                        if (fileInfo.Directory != null) Directory.CreateDirectory(fileInfo.Directory.FullName);

                    // https://sofiamedix.atlassian.net/browse/MED-15585
                    //string randomFile = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + ".pdf";
                    string randomFile = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + ".png";
                    string inputPath = Path.GetFullPath(imagePath);
                    string outputPath = this.mFilePath + "\\" + this.xPaBox.BunHo + "\\" + randomFile;
                    //GhostscriptWrapper.GeneratePageThumb(Path.GetFullPath(imagePath), this.mFilePath + "\\" + this.xPaBox.BunHo + "\\" + randomFile,
                    //    1, 24, 24);
                    GhostscriptWrapper.GeneratePageThumbs(inputPath, outputPath, 1, 3, 24, 24);

                    // picEdit1.Image = Image.FromFile(this.mFilePath + "\\" + randomFile);
                    // save image pdf
                    //SaveStreamToFile(this.mFilePath + "\\" + this.xPaBox.BunHo + "\\" + randomFile, File.ReadAllBytes(this.mFilePath + "\\" + this.xPaBox.BunHo + "\\" + randomFile), "pdf", imagePath, randomFile,isUserSelect);
                    SaveStreamToFile(imagePath, File.ReadAllBytes(imagePath), "pdf", imagePath, randomFile, isUserSelect);
                }
                catch// (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, Resources.WARN, MessageBoxIcon.Error);
                }

            }
            else
            {
                //filePath = GetAbsoluteDataPath(NextSequence(bunho, GetFileName(imagePath), Path.GetExtension(imagePath)), bunho).Trim();
                try
                {
                    FileInfo fileInfo = new FileInfo(mFilePath + "\\" + this.xPaBox.BunHo + "\\");
                    if (!fileInfo.Exists)
                        if (fileInfo.Directory != null) Directory.CreateDirectory(fileInfo.Directory.FullName);
                    //Save image
                    byte[] image= File.ReadAllBytes(imagePath);
                    SaveStreamToFile(imagePath, image, fileType, "nonPDF", safeFileName,isUserSelect);
                }
                catch 
                { 
                }
            }
         
        }
        private void SaveStreamToFile(string fileFullPath, byte[] data, string fileType, string fileNamePDF, string safeFileName,bool isUserSelect)
        {
            if (data.Length == 0) return;
            // Create a FileStream object to write a stream to a file
            //using (FileStream fileStream = File.Create(fileFullPath, data.Length))
            //{
            //    // Use FileStream object to write to the specified file
            //    fileStream.Write(data, 0, data.Length);

            //    BindingImage(fileStream, fileFullPath, fileType, fileNamePDF, Uri.EscapeDataString(safeFileName));
            //}
            if(!isUserSelect)
            {
                countImageLoadSucess++;
            }
            BindingImage(fileFullPath, fileType, fileNamePDF, Uri.EscapeDataString(safeFileName));
        }

        private void BindingImage(string fileName, string fileType, string fileNamePDF, string safeFileName)
        {
            if (!picEdit1.Visible)
            {
                if (fileType.ToLower() == "pdf")
                {
                    picEdit1.ResetData();
                    fileName1 = fileNamePDF;
                }
                else
                {
                    fileName1 = fileName;

                }

                if (fileType.ToLower() != "pdf")
                {
                    if (fileName1 != mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName) File.Copy(fileName1, mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName, true);
                }

                safeFileName1 = mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName;
                using (FileStream fileStream = new FileStream(safeFileName1, FileMode.Open, FileAccess.Read))
                {

                    picEdit1.Visible = true;
                    xPictureBox1.Visible = true;
                    // https://sofiamedix.atlassian.net/browse/MED-15585
                    //picEdit1.Image = new Bitmap(fileStream);
                    picEdit1.Image = Image.FromStream(fileStream);
                    picEdit1.SizeMode = PictureBoxSizeMode.StretchImage;
                    fileStream.Close(); // Dispose when use type Bitmap 
                }
            }
            else if (!picEdit2.Visible)
            {
                if (fileType.ToLower() == "pdf")
                {
                    picEdit2.ResetData();
                    fileName2 = fileNamePDF;
                }
                else
                {
                    fileName2 = fileName;
                }

                if (fileType.ToLower() != "pdf")
                {
                    if (fileName2 != mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName) File.Copy(fileName2, mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName, true);
                }

                safeFileName2 = mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName;
                using (FileStream fileStream = new FileStream(safeFileName2, FileMode.Open, FileAccess.Read))
                {
                    picEdit2.Visible = true;
                    xPictureBox2.Visible = true;
                    //picEdit2.Image = new Bitmap(fileStream);
                    picEdit2.Image = Image.FromStream(fileStream);
                    picEdit2.SizeMode = PictureBoxSizeMode.StretchImage;
                    fileStream.Close(); // Dispose when use type Bitmap 
                }
            }
            else if (!picEdit3.Visible)
            {
                if (fileType.ToLower() == "pdf")
                {
                    picEdit3.ResetData();
                    fileName3 = fileNamePDF;
                }
                else
                {
                    fileName3 = fileName;
                }

                if (fileType.ToLower() != "pdf")
                {
                    if (fileName3 != mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName) File.Copy(fileName3, mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName, true);
                }

                safeFileName3 = mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName;
                using (FileStream fileStream = new FileStream(safeFileName3, FileMode.Open, FileAccess.Read))
                {
                    picEdit3.Visible = true;
                    xPictureBox3.Visible = true;
                    //picEdit3.Image = new Bitmap(fileStream);
                    picEdit3.Image = Image.FromStream(fileStream);
                    picEdit3.SizeMode = PictureBoxSizeMode.StretchImage;
                    fileStream.Close(); // Dispose when use type Bitmap 
                }
            }
            else if (!picEdit4.Visible)
            {
                if (fileType.ToLower() == "pdf")
                {
                    picEdit4.ResetData();
                    fileName4 = fileNamePDF;
                }
                else
                {
                    fileName4 = fileName;
                }

                if (fileType.ToLower() != "pdf")
                {
                    if (fileName4 != mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName) File.Copy(fileName4, mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName, true);
                }

                safeFileName4 = mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName;
                using (FileStream fileStream = new FileStream(safeFileName4, FileMode.Open, FileAccess.Read))
                {
                    picEdit4.Visible = true;
                    xPictureBox4.Visible = true;
                    //picEdit4.Image = new Bitmap(fileStream);
                    picEdit4.Image = Image.FromStream(fileStream);
                    picEdit4.SizeMode = PictureBoxSizeMode.StretchImage;
                    fileStream.Close(); // Dispose when use type Bitmap 
                }
            }
            else if (!picEdit5.Visible)
            {
                if (fileType.ToLower() == "pdf")
                {
                    picEdit5.ResetData();
                    fileName5 = fileNamePDF;
                }
                else
                {
                    fileName5 = fileName;
                }

                if (fileType.ToLower() != "pdf")
                {
                    if (fileName5 != mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName) File.Copy(fileName5, mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName, true);
                }

                safeFileName5 = mFilePath + "\\" + this.xPaBox.BunHo + "\\" + safeFileName;
                using (FileStream fileStream = new FileStream(safeFileName5, FileMode.Open, FileAccess.Read))
                {
                    picEdit5.Visible = true;
                    xPictureBox5.Visible = true;
                    //picEdit5.Image = new Bitmap(fileStream);
                    picEdit5.Image = Image.FromStream(fileStream);
                    picEdit5.SizeMode = PictureBoxSizeMode.StretchImage;
                    fileStream.Close(); // Dispose when use type Bitmap
                }
            }
        }

        private void pic1_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(safeFileName1);
        }

        private void pic2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(safeFileName2);
        }

        private void pic3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(safeFileName3);
        }

        private void pic4_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(safeFileName4);
        }
        private void xPictureBox1_Click(object sender, EventArgs e)
        {
            File.Delete(safeFileName1);
            fileName1 = "";
            safeFileName1 = "";
            picEdit1.Image = null;
            picEdit1.Visible = false;
            xPictureBox1.Visible = false;
        }

        private void xPictureBox2_Click(object sender, EventArgs e)
        {
            File.Delete( safeFileName2);
            safeFileName2 = "";
            fileName2 = "";
            picEdit2.Image = null;
            picEdit2.Visible = false;
            xPictureBox2.Visible = false;
        }

        private void xPictureBox3_Click(object sender, EventArgs e)
        {
            File.Delete(safeFileName3);
            safeFileName3 = "";
            fileName3 = "";
            picEdit3.Image = null;
            picEdit3.Visible = false;
            xPictureBox3.Visible = false;
        }

        private void xPictureBox4_Click(object sender, EventArgs e)
        {
            File.Delete(safeFileName4);
            safeFileName4 = "";
            fileName4 = "";
            picEdit4.Image = null;
            picEdit4.Visible = false;
            xPictureBox4.Visible = false;
        }

        private void picEdit5_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(safeFileName5);
        }
        private void xPictureBox5_Click(object sender, EventArgs e)
        {
            File.Delete(safeFileName5);
            safeFileName5 = "";
            fileName5 = "";
            picEdit5.Image = null;
            picEdit5.Visible = false;
            xPictureBox5.Visible = false;
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            try
            {
                GetDataInfo();
                DataSet ds = new DataSet();
                using (ReportPatientIntroduceLetter rpt = new ReportPatientIntroduceLetter())
                {
                    ds.Tables.Add(tbl_PatientIntroduceLetter);
                    rpt.DataSource = ds;
                    rpt.DataMember = "tblPatientIntroduceLetter";
                    rpt.Print();
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.Cap_Error, MessageBoxIcon.Error);
            }
        }

        private void GetDataInfo()
        {
            tbl_PatientIntroduceLetter = new DataTable("tblPatientIntroduceLetter");
            tbl_PatientIntroduceLetter.Columns.Add("reservation_code");
            tbl_PatientIntroduceLetter.Columns.Add("received_letter_date");
            tbl_PatientIntroduceLetter.Columns.Add("patient_name");
            tbl_PatientIntroduceLetter.Columns.Add("patient_address");
            tbl_PatientIntroduceLetter.Columns.Add("patien_birthday");
            tbl_PatientIntroduceLetter.Columns.Add("patient_gender");
            tbl_PatientIntroduceLetter.Columns.Add("patient_tel");
            tbl_PatientIntroduceLetter.Columns.Add("patient_email");
            tbl_PatientIntroduceLetter.Columns.Add("from_hospital_name");
            tbl_PatientIntroduceLetter.Columns.Add("from_hospital_address");
            tbl_PatientIntroduceLetter.Columns.Add("from_hospital_tel");
            tbl_PatientIntroduceLetter.Columns.Add("from_hospital_fax");
            tbl_PatientIntroduceLetter.Columns.Add("from_doctor_name");
            tbl_PatientIntroduceLetter.Columns.Add("present_illness_comment");
            tbl_PatientIntroduceLetter.Columns.Add("purpose_comment");
            tbl_PatientIntroduceLetter.Columns.Add("past_history_comment");
            tbl_PatientIntroduceLetter.Columns.Add("family_history_comment");
            tbl_PatientIntroduceLetter.Columns.Add("test_results_comment");
            tbl_PatientIntroduceLetter.Columns.Add("clinical_course_comment");
            tbl_PatientIntroduceLetter.Columns.Add("medication_comment");
            tbl_PatientIntroduceLetter.Columns.Add("remarks_comment");
            string reservationCode = lblNo.Text;
            string receivedLetterDate = this.dtpReceiveDate.Text;
            string patientName = this.xPaBox.SuName;
            string patientAddress = this.txtPaAddress.Text;
            string patienBirthday = this.txtPaDob.Text;
            string patientGender = this.txtPaGender.Text;
            string patientTel = this.txtPaTel.Text;
            string patientEmail = this.txtPaEmail.Text;
            string fromHospitalName = this.txtFromHospName.Text;
            string fromHospitalAddress = this.txtFromAddress.Text;
            string fromHospitalTel = this.txtFromTel.Text;
            string fromHospitalFax = this.txtFromFax.Text;
            string fromDoctorName = this.txtFromDrRequest.Text;
            string presentIllnessComment = this.txtPresentIllness.Text;
            string purposeComment = this.txtPurpose.Text;
            string pastHistoryComment = this.txtPastHistory.Text;
            string familyHistoryComment = this.txtFamilyHistory.Text;
            string testResultsComment = this.txtTestResults.Text;
            string clinicalCourseComment = this.txtClinicalCourse.Text;
            string medicationComment = this.txtMedication.Text;
            string remarksComment = this.txtRemarks.Text;
            tbl_PatientIntroduceLetter.Rows.Add(reservationCode, receivedLetterDate, patientName, patientAddress, patienBirthday, patientGender, patientTel, patientEmail,
                fromHospitalName, fromHospitalAddress, fromHospitalTel,
                                                fromHospitalFax, fromDoctorName, presentIllnessComment, purposeComment, pastHistoryComment, familyHistoryComment, testResultsComment,
                                                clinicalCourseComment, medicationComment, remarksComment);

        }

        private bool checkNothingInput()
        {
            bool checkEmpty =false;
            if (!String.IsNullOrEmpty(txtFromAddress.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtFromDrRequest.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtFromFax.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtFromHospName.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtFromTel.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtPresentIllness.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtPastHistory.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtTestResults.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtClinicalCourse.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtMedication.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtRemarks.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtPurpose.Text)) { checkEmpty = true; }
            if (!String.IsNullOrEmpty(txtFamilyHistory.Text)) { checkEmpty = true; }
            return checkEmpty;
        }

        //Fix bug MED-10283
        private string GetSex(string sexCode)
        {
            if (sexCode == "M")
                return (NetInfo.Language == LangMode.Ko ? "남" : Resources.XPatientBox_TEXT1);
            else
                return (NetInfo.Language == LangMode.Ko ? "여" : Resources.XPatientBox_TEXT2);
        }

        #region delete by Cloud version 1.3.2

        //        private void CloseBtn_Click(object sender, EventArgs e)
        //        {
        //            this.Close();
        //        }
        //
        //        private void InsertPDFBarBTn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //        {
        //            OpenFileDialog dialog = new OpenFileDialog();
        //            dialog.Filter = "Pdf Files|*.pdf";
        //            dialog.FilterIndex = 1;
        //            dialog.RestoreDirectory = true;
        //
        //            if (dialog.ShowDialog() == DialogResult.OK)
        //            {
        //                string ext = Path.GetExtension(dialog.FileName);
        //                if (ext.ToLower() == ".pdf")
        //                {
        //                    string max_size = string.Empty;
        //                    if (!Utilities.CheckPdfUploadFile(dialog.FileName, out max_size))
        //                    {
        //                        XMessageBox.Show(string.Format(Resources.EMR_PDF_MAX_SIZE, max_size), Resources.WARN);
        //                        return;
        //                    }
        //                    string originalFilePath = dialog.FileName;
        //                    string pdfLink = Utilities.GetAbsoluteDataPath(Utilities.NextSequence(mBunho, Path.GetFileName(originalFilePath), "pdf"), mBunho);
        //                    File.Copy(originalFilePath, pdfLink);
        //
        //                    string pdfHash = Utilities.CalculateFileChecksum(pdfLink);
        //                    string thumbnailFilePath;
        //
        //                    FileDocumentImageSource image = Utilities.GetPdfThumbnail(pdfLink, out thumbnailFilePath);
        //                    string thumbnailHash = Utilities.CalculateImageChecksum(image.Stream);
        //                    if (!metaDictionary.ContainsKey(thumbnailHash))
        //                        metaDictionary.Add(thumbnailHash, new PdfMeta(pdfHash, pdfLink, new ImageMeta(thumbnailHash, thumbnailFilePath, 0.25f, 0.25f)));
        //                    ucGrid.InsertImage(thumbnailFilePath, TypeEnum.Pdf, pdfLink, true);
        //                }
        //            }
        //        }
        //
        //        private void insertImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //        {
        //            OpenFileDialog dialog = new OpenFileDialog();
        //            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
        //            dialog.FilterIndex = 1;
        //            dialog.RestoreDirectory = true;
        //            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CLIP";
        //            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
        //                this.ucGrid.InsertImage(dialog.FileName, TypeEnum.Image, dialog.FileName, true);
        //        }
        //        private void insertComment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //        {
        //            this.ucGrid.AddComment();
        //        }
        //
        //        private void cboTagOptions_SelectedIndexChanged(object sender, EventArgs e)
        //        {
        //            int objSelected;
        //            ComboBoxEdit cbe = (ComboBoxEdit)sender;
        //            Int32.TryParse(Convert.ToString(cbe.SelectedIndex), out objSelected);
        //            ucGrid.ModeByTag(objSelected);
        //        }

        #endregion

        //MED-12219
        private void CheckEmptyRecord()
        {
            if (grdOrder.RowCount == 0)
            {               
                this.pnlContainer.Enabled = false;
                txtFromAddress.Text = "";
                txtFromDrRequest.Text = "";
                txtFromFax.Text = "";
                txtFromHospName.Text = "";
                txtFromTel.Text = "";
                txtPresentIllness.Text = "";
                txtPastHistory.Text = "";
                txtTestResults.Text = "";
                txtClinicalCourse.Text = "";
                txtMedication.Text = "";
                txtRemarks.Text = "";
                txtPurpose.Text = "";
                txtFamilyHistory.Text = "";
                ClearImageControls();
            }
            else
            {
                this.pnlContainer.Enabled = true;
            }
        }

        private void ResetControl()
        {
            txtFromAddress.Text = "";
            txtFromDrRequest.Text = "";
            txtFromFax.Text = "";
            txtFromHospName.Text = "";
            txtFromTel.Text = "";
            txtPresentIllness.Text = "";
            txtPastHistory.Text = "";
            txtTestResults.Text = "";
            txtClinicalCourse.Text = "";
            txtMedication.Text = "";
            txtRemarks.Text = "";
            txtPurpose.Text = "";
            txtFamilyHistory.Text = "";

            TextBox_DataValidating(txtFromAddress, null);
            TextBox_DataValidating(txtFromDrRequest, null);
            TextBox_DataValidating(txtFromFax, null);
            TextBox_DataValidating(txtFromHospName, null);
            TextBox_DataValidating(txtFromTel, null);
            TextBox_DataValidating(txtPresentIllness, null);
            TextBox_DataValidating(txtPastHistory, null);
            TextBox_DataValidating(txtTestResults, null);
            TextBox_DataValidating(txtClinicalCourse, null);
            TextBox_DataValidating(txtMedication, null);
            TextBox_DataValidating(txtRemarks, null);
            TextBox_DataValidating(txtPurpose, null);
            TextBox_DataValidating(txtFamilyHistory, null);
        }

        #region https://sofiamedix.atlassian.net/browse/MED-11937

        private void OpenFormSelectExam()
        {
            FormSelectExam frm = new FormSelectExam(this.mHospCode, xPaBox.BunHo);
            frm.ShowDialog(this);

            if (frm.DialogResult == DialogResult.OK)
            {
                //check whether if this naewonkey has already existed 
                if (!CheckDuplicateNaewonKey(frm.ExamInfoValue.NaewonKey))
                {
                    // Insert new row to exam grid
                    this.InsertNewRow(frm.ExamInfoValue);
                    
                }
                else
                {
                    //Show msg this date has already had introduce letter
                }
            }
        }

        private bool CheckDuplicateNaewonKey(string key)
        {
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (key == grdOrder.GetItemString(i, "naewon_key"))
                {
                    return true;
                }
            }
            return false;
        }

        private void InsertNewRow(FormSelectExam.ExamInfo examInfo)
        {
            DataTable tblTemp = grdOrder.CloneToLayout().LayoutTable;
            tblTemp.Clear();
            tblTemp.Rows.Add(examInfo.NaewonDate, examInfo.GwaName, examInfo.NaewonKey);
            foreach (DataRow dr in tblTemp.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(dr);
            }
            this.grdOrder.DisplayData();
            
            //int newRow = this.grdOrder.InsertRow();
            //this.grdOrder.SetItemValue(newRow, "exam_date", examInfo.NaewonDate);
            //this.grdOrder.SetItemValue(newRow, "department", examInfo.GwaName);
            //this.grdOrder.SetItemValue(newRow, "naewon_key", examInfo.NaewonKey);
        }

        #endregion
    }
}