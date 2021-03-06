using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using ORCA;
using System.Collections;
using System.Reflection;
using System.Threading;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.NURO
{
    /// <summary>
    /// FormSelectPatient
    /// </summary>
    public partial class FormSelectPatient : Form
    {
        #region Fields and Properties
        private string status = "";
        private string _bunho;
        private string _hospCodeLink;
        private string _kanji_clinic_name;
        private List<string> list_patientID_1;

        #endregion

        #region Constructors

        /// <summary>
        /// FormSelectPatient
        /// </summary>
        public FormSelectPatient()
        {
            InitializeComponent();

            this.grdPatientList.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_address",
                    "f_birth",
                    "f_hosp_code_link",
                    "f_suname",
                    "f_suname2",
                    "f_page_number",
                });
            this.grdPatientList.ExecuteQuery = GetGrdPatientList;

            // Do not allow user to resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// FormSelectPatient
        /// </summary>
        public FormSelectPatient(string bunho, string hospCodeLink, string kanji_clinic_name)
        {
            InitializeComponent();
            this._kanji_clinic_name = kanji_clinic_name;
            this._bunho = bunho;
            this._hospCodeLink = hospCodeLink;

            this.grdPatientList.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_address",
                    "f_birth",
                    "f_hosp_code_link",
                    "f_suname",
                    "f_suname2",
                    "f_page_number",
                });
            this.grdPatientList.ExecuteQuery = GetGrdPatientList;

            // Do not allow user to resize form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        #endregion

        #region Events

        private void FormSelectPatient_Load(object sender, EventArgs e)
        {
            try
            {
                paBox.SetPatientID(this._bunho);
                txtBunho.Text = this._bunho;
                grdPatientList.QueryLayout(false);

                SetButtonEnable();
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            //Fix bug MED-9792
            //if (XMessageBox.Show(Resources.MSG_001 + _kanji_clinic_name + Resources.MSG_006, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            if (XMessageBox.Show(string.Format(Resources.MSG_001, this._kanji_clinic_name) + Resources.MSG_006, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            //==check to find any link before with current patient
            string listbunho = "";
            string bunho = paBox.BunHo;
            string bunho_link = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
            NUR2016CheckExitsEMRLinkArgs args = new NUR2016CheckExitsEMRLinkArgs();
            args.HospCode = ""; //get from SERVER.SESSION
            args.Bunho = bunho;
            args.HospCodeLink = this._hospCodeLink;
            args.BunhoLink = bunho_link;
            NUR2016CheckExitsEMRLinkResult res = CloudService.Instance.Submit<NUR2016CheckExitsEMRLinkResult, NUR2016CheckExitsEMRLinkArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == "0")//no exist other link EMR before
            {
                linkEMR();
            }
            else if (res.ExecutionStatus == ExecutionStatus.Success && res.Result != "0")// exist 1 or more link EMR before
            {
                //in case: if exist more than 1 linked before
                list_patientID_1 = new List<string>();
                for (int i = 0; i < res.LinkEmrPatientItem.Count; i++)
                {
                    listbunho += res.LinkEmrPatientItem[i].Bunho;
                    list_patientID_1.Add(res.LinkEmrPatientItem[i].PatientId);
                }

                if (bunho_link == listbunho) // if this bunho and bunhoLink has linked (nếu 2 bệnh nhân này đã được liên kết)
                {
                    //if user click linkbutton many time without change anything
                    if (status == grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "link_emr"))
                    {
                        if (grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "link_emr") == "Y")
                        {
                            MessageBox.Show(Resources.MSG_013, Resources.CAP_CAUTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Resources.MSG_012, Resources.CAP_CAUTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // 2 truong hop share emr or not
                        //MED-10089
                        if (grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "link_emr") == "Y")
                        {
                            if (MessageBox.Show(Resources.MSG_007, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //updateLinkEMR(true, list_patientID_1[0]);
                                deletedLinkPatient();
                                linkEMR();
                            }
                        }
                        else
                        {
                            if (MessageBox.Show(Resources.MSG_008, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //updateLinkEMR(false, list_patientID_1[0]);
                                deletedLinkPatient();
                                linkEMR();
                            }
                        }
                    }

                }
                else // user cofirm to delete old link and create a new link between bunho and bunhoLink (người dùng xác nhận xóa liên kết cũ để tạo liên kết mới)
                {
                    if (XMessageBox.Show(bunho + Resources.MSG_009 + listbunho + Resources.MSG_010 + bunho_link + Resources.MSG_011, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { //agree
                        if (deletedLinkPatient())
                        {
                            linkEMR();
                        }

                    }

                }
            }

            setStatus(grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "link_emr"));
        }
        public void setStatus(string _status)
        {
            status = _status;
        }
        //update link patient in case bunho1 = bunho2
        private void updateLinkEMR(bool status, string patient_id)
        {
            NUR2016PublishEMRLinkArgs args = new NUR2016PublishEMRLinkArgs();
            args.PatientId = patient_id;
            args.Ischeck = status;

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016PublishEMRLinkArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                return;
            }
            else
            {
                return; ;
            }


        }
        //link emr
        private void linkEMR()
        {
            try
            {
                NUR2016Q00LinkPatientArgs args = new NUR2016Q00LinkPatientArgs();
                args.LinkPatientItem = new NUR2016Q00LinkPatientInfo();
                args.LinkPatientItem.ActiveFlg = "1";
                args.LinkPatientItem.Bunho = paBox.BunHo;
                args.LinkPatientItem.BunhoLink = grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho");
                //args.LinkPatientItem.EmrLinkFlg = chkAgree.Checked ? "1" : "0";
                args.LinkPatientItem.EmrLinkFlg = (grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "link_emr") == "Y") ? "1" : "0";
                args.LinkPatientItem.HospCode = ""; // Get from SERVER.SESSION
                args.LinkPatientItem.HospCodeLink = this._hospCodeLink;
                args.LinkPatientItem.LinkType = "KCCK";
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016Q00LinkPatientArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
                {
                    if (res.Msg == "")
                    {
                        // Patient linked succeeded
                        XMessageBox.Show(string.Format(Resources.MSG_LINK_SUCCESS, this._hospCodeLink), Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //if (res.Msg == "0")
                    //{
                    //    // この患者は選択した病院に既に紐付けされました。(Patient has already linked)
                    //    XMessageBox.Show(Resources.MSG_PATIENT_ALREADY_LINKED, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    else if (res.Msg == "1")
                    {
                        // Patient linked succeeded
                        XMessageBox.Show(Resources.MSG_SAVE_OUTPUT_01, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (res.Msg == "2")
                    {
                        // Patient linked succeeded
                        XMessageBox.Show(Resources.MSG_SAVE_OUTPUT_02, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (res.Msg == "3")
                    {
                        // Patient linked succeeded
                        XMessageBox.Show(Resources.MSG_SAVE_OUTPUT_03, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (res.Msg == "4")
                    {
                        // Patient linked succeeded
                        XMessageBox.Show(Resources.MSG_SAVE_OUTPUT_04, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    grdPatientList.QueryLayout(false);
                    SetButtonEnable();
                    return;
                }
                else
                {
                    //Patient linked failed!
                    XMessageBox.Show(string.Format(Resources.MSG_LINK_FAILED, this._hospCodeLink), Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        //check delete linked patient successful
        private bool deletedLinkPatient()
        {
            NUR2016DeleteEMRLinkArgs args = new NUR2016DeleteEMRLinkArgs();


            args.PatientId = list_patientID_1[0];
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016DeleteEMRLinkArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        private void btnCreateTempID_Click(object sender, EventArgs e)
        {
            // Patient has not been selected
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                XMessageBox.Show(Resources.MSG_NOT_SELECT_PATIENT, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Fix bug MED-9792
            // Confirmation: 当病院の患者IDの情報をもとに選択した病院の仮IDを発行したうえで紐づけます。よろしいですか？.
            //if (XMessageBox.Show(Resources.MSG_002 + _kanji_clinic_name + Resources.MSG_005, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            if (XMessageBox.Show(string.Format(Resources.MSG_002, this._kanji_clinic_name) + Resources.MSG_005, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Is clinic using ORCA?
                if (ORCACheck())
                {                    
                    // Register a patient in ORCA
                    OutPatientInfo outPatient = new OutPatientInfo();

                    //https://sofiamedix.atlassian.net/browse/MED-14309
                   // this.SendPatientMod(out outPatient);

                    // Register patient failed in ORCA
                    if (outPatient == null)
                    {
                        Service.StartWriteLog();
                        Service.WriteLog("[OutPatientInfo]: NULL");
                        Service.EndWriteLog();
                        return;
                    }

                    Service.StartWriteLog();
                    Service.WriteLog("[ORCA PATIENT INFORMATION (Patient registered on ORCA)]");
                    Service.WriteLog("[BUNHO]: " + outPatient.Bunho);
                    Service.WriteLog("[ADDRESS1]: " + outPatient.Address1);
                    Service.WriteLog("[SUNAME]: " + outPatient.Suname);
                    Service.WriteLog("[SUNAME2]: " + outPatient.Suname2);
                    Service.WriteLog("[BIRTH]: " + outPatient.Birth);
                    Service.WriteLog("[SEX]: " + outPatient.Sex);
                    Service.WriteLog("[TEL]: " + outPatient.Tel);
                    Service.EndWriteLog();

                    //comment code due to https://sofiamedix.atlassian.net/browse/MED-14309

                    // Registers patient in KCCK
                    //NUR2016Q00CreateTempIDArgs args = new NUR2016Q00CreateTempIDArgs();
                    //args.TempItem = new NUR2016Q00CreateTempIDInfo();
                    //args.TempItem.Address = outPatient.Address1;
                    //args.TempItem.Bunho = outPatient.Bunho;
                    //args.TempItem.BunhoType = "3";
                    //args.TempItem.HospCode = this._hospCodeLink;
                    //args.TempItem.LinkPatientFlg = "1";
                    //args.TempItem.Suname = outPatient.Suname;
                    //args.TempItem.Suname2 = outPatient.Suname2;
                    //args.TempItem.Birth = outPatient.Birth;
                    //args.TempItem.Sex = outPatient.Sex;
                    //args.TempItem.Tel = outPatient.Tel;
                    //args.OrcaPatient = true;

                    NUR2016Q00CreateTempIDArgs args = new NUR2016Q00CreateTempIDArgs();
                    args.TempItem = new NUR2016Q00CreateTempIDInfo();
                    args.TempItem.Address = paBox.Address1;
                    args.TempItem.Bunho = paBox.BunHo;
                    args.TempItem.BunhoType = "3";
                    args.TempItem.HospCode = this._hospCodeLink;
                    args.TempItem.LinkPatientFlg = "1";
                    args.TempItem.Suname = paBox.SuName;
                    args.TempItem.Suname2 = paBox.SuName2;
                    args.TempItem.Birth = paBox.Birth;
                    args.TempItem.Sex = paBox.Sex;
                    args.TempItem.Tel = paBox.Tel;
                    args.OrcaPatient = false;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016Q00CreateTempIDArgs>(args);

                    // Hot fix
                    int retry = 0;
                    while ((res.ExecutionStatus != ExecutionStatus.Success || !res.Result) && retry < 3)
                    {
                        res = CloudService.Instance.Submit<UpdateResult, NUR2016Q00CreateTempIDArgs>(args);
                        retry++;
                        Service.WriteLog(string.Format("[RETRY TIMES]: {0} -- [RESULT]: {1}", retry.ToString(), res.Result));

                        Thread.Sleep(300);
                    }

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        // Create temp ID succeeded!
                        XMessageBox.Show(Resources.MSG_CREATE_TEMP_ID_SUCCESS, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        grdPatientList.QueryLayout(false);
                        SetButtonEnable();
                    }
                    else
                    {
                        // Create temp ID failed!
                        XMessageBox.Show(Resources.MSG_CREATE_TEMP_ID_FAILED, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Clinic does not use ORCA services
                    NUR2016Q00CreateTempIDArgs args = new NUR2016Q00CreateTempIDArgs();
                    args.TempItem = new NUR2016Q00CreateTempIDInfo();
                    args.TempItem.Address = paBox.Address1;
                    args.TempItem.Bunho = paBox.BunHo;
                    args.TempItem.BunhoType = "3";
                    args.TempItem.HospCode = this._hospCodeLink;
                    args.TempItem.LinkPatientFlg = "1";
                    args.TempItem.Suname = paBox.SuName;
                    args.TempItem.Suname2 = paBox.SuName2;
                    args.TempItem.Birth = paBox.Birth;
                    args.TempItem.Sex = paBox.Sex;
                    args.TempItem.Tel = paBox.Tel;
                    args.OrcaPatient = false;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016Q00CreateTempIDArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        // Create temp ID succeeded!
                        XMessageBox.Show(Resources.MSG_CREATE_TEMP_ID_SUCCESS, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        grdPatientList.QueryLayout(false);
                        SetButtonEnable();
                    }
                    else
                    {
                        // Create temp ID failed!
                        XMessageBox.Show(Resources.MSG_CREATE_TEMP_ID_FAILED, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Service.StartWriteLog();
                    Service.WriteLog("[KCCK PATIENT INFORMATION (Auto-generated patient in KCCK)]");
                    Service.WriteLog("[BUNHO]: " + args.TempItem.Bunho);
                    Service.WriteLog("[ADDRESS1]: " + args.TempItem.Address);
                    Service.WriteLog("[SUNAME]: " + args.TempItem.Suname);
                    Service.WriteLog("[SUNAME2]: " + args.TempItem.Suname2);
                    Service.WriteLog("[BIRTH]: " + args.TempItem.Birth);
                    Service.WriteLog("[SEX]: " + args.TempItem.Sex);
                    Service.WriteLog("[TEL]: " + args.TempItem.Tel);
                    Service.EndWriteLog();
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Close:
                    e.IsBaseCall = false;
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void txtBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            try
            {
                if (e.DataValue != "")
                {
                    string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                    this.paBox.SetPatientID(bunho);
                    this.txtBunho.Focus();
                }
                else
                {
                    this.paBox.Reset();
                }

                grdPatientList.QueryLayout(false);
                SetButtonEnable();
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPatientList.SetBindVarValue("f_bunho", paBox.BunHo);
            grdPatientList.SetBindVarValue("f_address", paBox.Address1);
            grdPatientList.SetBindVarValue("f_birth", paBox.Birth);
            grdPatientList.SetBindVarValue("f_hosp_code_link", this._hospCodeLink);
            grdPatientList.SetBindVarValue("f_suname", paBox.SuName);
            grdPatientList.SetBindVarValue("f_suname2", paBox.SuName2);
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            try
            {
                this.txtBunho.Text = this.paBox.BunHo;
                grdPatientList.QueryLayout(false);
                SetButtonEnable();
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.txtBunho.Text = "";
            this.paBox.Reset();
        }

        #endregion

        #region Methods (private)

        private void SetButtonEnable()
        {
            // Button Link
            //btnLink.Enabled = chkAgree.Enabled = (grdPatientList.RowCount > 0);
            btnLink.Enabled = (grdPatientList.RowCount > 0);
            // Button CreateTempID
            //btnCreateTempID.Enabled = (grdPatientList.RowCount == 0);
        }

        /// <summary>
        /// Send patient to ORCA
        /// </summary>
        /// <param name="xGrid"></param>
        /// <param name="outPatient">Output patient info</param>
        private GetPatientInsResult insResult;
        private void SendPatientMod(out OutPatientInfo outPatient)
        {   
            //Get information insurance
            List<object[]> listPriIns = new List<object[]>();
            List<object[]> listPubIns = new List<object[]>();
            try
            {
                GetPatientInsArgs insArgs = new GetPatientInsArgs();
                insArgs.PatientCode = paBox.BunHo;
                insArgs.HospCode = UserInfo.HospCode;
                insResult = CloudService.Instance.Submit<GetPatientInsResult, GetPatientInsArgs>(insArgs);
                if (insResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    if(insResult.PriInfo.Count >0)
                    {
                        foreach (PrivateInsInfo privateInsInfo in insResult.PriInfo)
                        {                            
                            object[] _privateInsInfo =
                                {
                                    privateInsInfo.Gubun,
                                    privateInsInfo.Johap,
                                    privateInsInfo.Piname,
                                    privateInsInfo.Gaein,
                                    privateInsInfo.GaeinNo,
                                    privateInsInfo.BonGaGubun,
                                    privateInsInfo.StartDate,
                                    privateInsInfo.EndDate,
                                    privateInsInfo.ChuiduckDate,
                                };
                            listPriIns.Add(_privateInsInfo);
                        }
                    }
                    if(insResult.PubInfo.Count > 0)
                    {
                         foreach (PublicInsInfo publicInsInfo in insResult.PubInfo)
                            {
                                object[] _publicInsInfo =
                                    {
                                        publicInsInfo.GongbiCode,
                                        publicInsInfo.BudamjaBunho,
                                        publicInsInfo.SugubjaBunho,
                                        publicInsInfo.StartDate,
                                        publicInsInfo.EndDate,
                                        
                                    };
                                listPubIns.Add(_publicInsInfo);
                            }
                    }

                }
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog(" [Error Get Inssurance: ]" + ex.Message);
                Service.EndWriteLog();                
            }
            ArrayList errCode = new ArrayList();
            try
            {
                PatientModInfo inPatient = new PatientModInfo();
                inPatient.Modkey = "2";
                inPatient.PatientID = "*";
                inPatient.WholeName = paBox.SuName;
                inPatient.WholeNameKana = paBox.SuName2;
                inPatient.Birthdate = paBox.Birth.Replace("/","-");
                inPatient.Sex = paBox.Sex == "M" ? "1" : "2";
                inPatient.Comment1 = "";
                inPatient.HomeAddressInfo = new List<HomeAddressInfo>();
                inPatient.HomeAddressInfo.Add(new HomeAddressInfo(paBox.Zip1, paBox.Address1, paBox.Address2, paBox.Tel, ""));
                inPatient.WorkPlaceInfo = new List<WorkPlaceInfo>();
                inPatient.WorkPlaceInfo.Add(new WorkPlaceInfo("", paBox.Zip1, paBox.Address1, paBox.Address2, paBox.Tel));                
                inPatient.PublicInsuranceInfo = new List<PublicInsuranceInfo>();
                if (insResult.PubInfo.Count > 0)
                {
                    for (int i = 0; i < insResult.PubInfo.Count; i++)
                    {
                        inPatient.PublicInsuranceInfo.Add(new PublicInsuranceInfo(insResult.PubInfo[i].GongbiCode, "", insResult.PubInfo[i].BudamjaBunho, insResult.PubInfo[i].SugubjaBunho, insResult.PubInfo[i].StartDate.Replace("/","-")));
                    }
                }
                else
                {
                    //inPatient.PublicInsuranceInfo.Add(new PublicInsuranceInfo("","","","",""));
                }
                                 
                inPatient.InsuranceInfo = new List<InsuranceInfo>();
                if (insResult.PriInfo.Count > 0)
                {
                    for (int i = 0; i < insResult.PriInfo.Count; i++)
                    {
                        inPatient.InsuranceInfo.Add(new InsuranceInfo(insResult.PriInfo[i].Gubun, insResult.PriInfo[i].Johap, insResult.PriInfo[i].Piname,
                            insResult.PriInfo[i].Gaein, insResult.PriInfo[i].GaeinNo, insResult.PriInfo[i].BonGaGubun, insResult.PriInfo[i].StartDate.Replace("/", "-"), inPatient.PublicInsuranceInfo));
                    }
                }
                else
                  {
                    inPatient.InsuranceInfo.Add(new InsuranceInfo("", "", "", "", "", "", "", inPatient.PublicInsuranceInfo));
                  }
                ORCAServices os = new ORCAServices(inPatient);
                os.SendPatientMod(ORCAInfo.ORCAIp, ORCAInfo.ORCAPort, ORCAInfo.ORCAUser, ORCAInfo.ORCAPsw, out errCode, out outPatient);

                if (errCode.Count > 1)
                {
                    Service.StartWriteLog();
                    Service.WriteLog("[ORCA ERROR CODE]: " + errCode[0].ToString());
                    Service.WriteLog("[ORCA ERROR MESSAGE]: " + errCode[1].ToString());
                    Service.EndWriteLog();

                    // Success
                    if (errCode[0].ToString() == "00"
                        || errCode[0].ToString() == "K0"
                        || errCode[0].ToString() == "K1"
                        || errCode[0].ToString() == "K2"
                        || errCode[0].ToString() == "K3"
                        || errCode[0].ToString() == "K4")
                    {
                        // Warning message
                        //XMessageBox.Show(errCode[1].ToString(), Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else// if (errCode[0].ToString() != "")
                    {
                        // Error!
                        //XMessageBox.Show(errCode[1].ToString(), Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        outPatient = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog("[SEND ORCA FAILED]: " + ex.Message);
                Service.WriteLog("[ORCA_IP]: " + ORCAInfo.ORCAIp);
                Service.WriteLog("[ORCA_PORT]: " + ORCAInfo.ORCAPort);
                //Service.WriteLog("[ORCA_USER]: " + ORCAInfo.ORCAUser);
                //Service.WriteLog("[ORCA_PASSWORD]: " + ORCAInfo.ORCAPsw);
                Service.EndWriteLog();
                throw ex;
            }
        }

        #endregion

        #region CloudConnector

        private IList<object[]> GetGrdPatientList(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            try
            {
                NUR2016Q00GrdPatientListArgs args = new NUR2016Q00GrdPatientListArgs();
                args.Bunho = bc["f_bunho"].VarValue;
                args.Address = bc["f_address"].VarValue;
                args.Birth = bc["f_birth"].VarValue;
                args.HospCodeLink = bc["f_hosp_code_link"].VarValue;
                args.Suname = bc["f_suname"].VarValue;
                args.Suname2 = bc["f_suname2"].VarValue;
                args.Offset = "200";
                args.PageNumber = bc["f_page_number"].VarValue;
                NUR2016Q00GrdPatientListResult res = CloudService.Instance.Submit<NUR2016Q00GrdPatientListResult, NUR2016Q00GrdPatientListArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    res.GrdPatListItem.ForEach(delegate(NUR2016Q00GrdPatientListInfo item)
                    {
                        lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.PatientName,
                        item.Address,
                        Utilities.GetDateByLangMode(item.Birth, NetInfo.Language),
                        item.Suname,
                        item.Suname2,
                        item.Sex,
                        item.Tel,
                        item.LinkEmr
                    });
                    });
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }

            return lObj;
        }

        /// <summary>
        /// Checking for a clinic is using ORCA services or not
        /// </summary>
        /// <returns></returns>
        private bool ORCACheck()
        {
            try
            {
                GetORCAEnvArgs args = new GetORCAEnvArgs();
                args.HospCode = this._hospCodeLink;
                GetORCAEnvResult res = CloudService.Instance.Submit<GetORCAEnvResult, GetORCAEnvArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success && res.IsUsingOrca)
                {
                    ORCAInfo.ORCAIp = res.OrcaInfo.OrcaIp;
                    ORCAInfo.ORCAPort = res.OrcaInfo.OrcaPort;
                    ORCAInfo.ORCAUser = res.OrcaInfo.OrcaUser;
                    ORCAInfo.ORCAPsw = res.OrcaInfo.OrcaPwd;
                }

                return res.ExecutionStatus == ExecutionStatus.Success && res.IsUsingOrca;
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }

            return false;
        }

        #endregion

        #region ORCAInfo

        private class ORCAInfo
        {
            public static string ORCAIp = "";
            public static string ORCAPort = "";
            public static string ORCAUser = "";
            public static string ORCAPsw = "";
        }

        #endregion

        private void grdPatientList_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {

        }

        private void grdPatientList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //for (int i = 0; i < grdPatientList.RowCount; i++)
            //{
            //    if (i != grdPatientList.CurrentRowNumber)
            //    {
            //        grdPatientList.SetItemValue(i, "link_emr", "N");
            //    }
            //}

        }

        //MED-10089
        private void grdPatientList_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "link_emr")
            {
                grdPatientList.ItemValueChanging -= this.grdPatientList_ItemValueChanging;
                for (int i = 0; i < grdPatientList.RowCount; i++)
                {
                    if (i != grdPatientList.CurrentRowNumber)
                    {
                        grdPatientList.SetItemValue(i, "link_emr", "N");
                    }
                }
                grdPatientList.ItemValueChanging += this.grdPatientList_ItemValueChanging;
            }
        }
    }
}