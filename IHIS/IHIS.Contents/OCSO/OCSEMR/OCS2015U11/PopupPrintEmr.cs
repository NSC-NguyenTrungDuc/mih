using System.Collections.Generic;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EmrDocker.Glossary;
using EmrDocker.Models;
using EO.WebBrowser;
using EO.WebBrowser.DOM;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.Framework;
using IHIS.OCSO;
using Newtonsoft.Json;
using Utilities = IHIS.OCSO.Utilities;

namespace EmrDocker
{
    public partial class PopupPrintEmr : Form
    {
        #region Properties
        string obj = "{\"Fname\":\"Thế Anh\",\"Lname\":\"Lại\",\"quote\":\"Enter your favorite quote!\",\"education\":\"Jr.High\"}";
        private const string FormatType = "HTML";
        private const string TplType = "EMR";
        private string _bunho;
        private string _pkOut;
        private string _hospCode = UserInfo.HospCode;
        private ScreenEnum _screenEnum = ScreenEnum.Other;
        private string _strHtmlTemplate = "";
        private string _strDataBinding = "";
        private string _currentUrl = Application.StartupPath + "/print_emr.html";
        private List<EmrRecordInfo> _lstEmrRecordInfos = new List<EmrRecordInfo>();
        private Dictionary<string, string> _dicDoctorInfo = new Dictionary<string, string>();
        private Dictionary<string, string> _dicDosageInfo = new Dictionary<string, string>();
        private OCS2015U00GetDataPrintEmrMedicalResult _currentDataPrintResult;
        private OCS2015U00GetPatientInfoResult _patientResult;
        private List<OcsoOCS1003P01GridOutSangInfo> LstOcsoOCS1003P01GridOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();
        private List<TagPrintInfo> _listTagPrintInfos = new List<TagPrintInfo>();
        private List<OrderPrintInfo> _listOrderPrintInfos = new List<OrderPrintInfo>();
        private bool _isFirstOpen = true;
        private bool _isVi = false;
        private DateTime _sysDate = EnvironInfo.GetSysDate();

        #endregion

        #region Contructor

        public PopupPrintEmr(List<EmrRecordInfo> pLstEmrRecordInfo, string bunho, ScreenEnum screenEnum, List<OcsoOCS1003P01GridOutSangInfo> pLstOcsoOcs1003P01GridOutSangInfo, string pPkOut)
        {
            BindingToOpenScreen(bunho, screenEnum, pLstOcsoOcs1003P01GridOutSangInfo);
            _lstEmrRecordInfos = pLstEmrRecordInfo;
            LstOcsoOCS1003P01GridOutSangInfo = pLstOcsoOcs1003P01GridOutSangInfo;
            _pkOut = pPkOut;
            _screenEnum = screenEnum;
            if (screenEnum == ScreenEnum.UcEditor) SetEnableTopPanelControl(false);

            this.Text = string.Format(Resources.FrmPopupPrintEmr_Name, _patientResult != null && _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientName1 : "", _patientResult != null && _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientCode : "");
        }

        private void CheckLangForPrint()
        {
            cbxPatientInfo.Checked = _isVi;
            cbxOrderInfo.Checked = _isVi;
            cbxDiseasePrinting.Checked = _isVi;
        }

        public PopupPrintEmr(bool pIsVi, List<EmrRecordInfo> pLstEmrRecordInfo, string bunho, ScreenEnum screenEnum, List<OcsoOCS1003P01GridOutSangInfo> pLstOcsoOcs1003P01GridOutSangInfo, string pPkOut)
        {
            _isVi = pIsVi;
            BindingToOpenScreen(bunho, screenEnum, pLstOcsoOcs1003P01GridOutSangInfo);
            _lstEmrRecordInfos = pLstEmrRecordInfo;
            _pkOut = pPkOut;
            if (screenEnum == ScreenEnum.UcEditor) SetEnableTopPanelControl(false);

            this.Text = string.Format(Resources.FrmPopupPrintEmr_Name, _patientResult != null && _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientName1 : "", _patientResult != null && _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientCode : "");
        }

        private void BindingToOpenScreen(string bunho, ScreenEnum screenEnum, List<OcsoOCS1003P01GridOutSangInfo> pLstOcsoOcs1003P01GridOutSangInfo)
        {
            _isFirstOpen = true;
            InitializeComponent();
            AddLicenceForEO();

            CheckLangForPrint();
            _bunho = bunho;
            _screenEnum = screenEnum;
            LstOcsoOCS1003P01GridOutSangInfo = pLstOcsoOcs1003P01GridOutSangInfo;
            dpkStartDate.Text = dpkEndDate.Text = _sysDate.ToString("yyyy/MM/dd");
            //get html template
            _strHtmlTemplate = GetHtmlTemplate();
            //get patientInfo
            GetPatientInfo();
            cbxOrderInfo.Checked = true;

            string curDir = Application.StartupPath;
            /*string currentUrl = String.Format("file:///{0}/Print_EMR.html", curDir);*/
            //string currentUrl = "file:///C:/ihis/print_emr.html";
            
            EOBrowser.SaveFileHtml(_currentUrl, _strHtmlTemplate);
            webView1.Url = _currentUrl;                        

        }

        private void AddLicenceForEO()
        {
            EO.WebBrowser.Runtime.AddLicense(
                "xq20psLcrmurs8PbsHCZpAcQ8azg8//ooWqtprHavUaBpLHLn3Xq7fgZ4K3s" +
                "9vbp4o2w78X0zqat5Qod54zA+eTx86G+xc7ou2jq7fgZ4K3s9vbpjEOzs/0U" +
                "4p7l9/bpjEN14+30EO2s3MKetZ9Zl6TNF+ic3PIEEMidtbbB3bRwqrzK4bdx" +
                "s7P9FOKe5ff29ON3hI6xy59Zs/D6DuSn6un26bto4+30EO2s3OnPuIlZl6Sx" +
                "5+Cl4/MI6YxDl6Sxy59Zl6TNDOOdl/gKG+R2mcng2cKh6fP+EKFZ7ekDHuio" +
                "5cGz3LVnp6ax2r1GgaSxy591puX9F+6wtZGby59Zl8AAHeOe6c3/Ee5Z2+UF" +
                "ELxbqLXA3bNoqbTC4aFZ6vnz8Pep4Pb2HsA=");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BindData();
            _isFirstOpen = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        private void BindData()
        {
            try
            {
                /*string curDir = Application.StartupPath;
                string currentUrl = String.Format("file:///{0}/Print_EMR.html", curDir);*/
                /*string currentUrl = "file:///C:/ihis/print_emr.html";*/
                
                webView1.Url = _currentUrl;

                GetOtherData(_bunho, "10323");

                if (_isVi)
                {
                    #region Data for Vi
                    VnEmrPrintData vnEmrPrintData = new VnEmrPrintData();
                    List<VnEmrPrintPageInfo> lstEmrPrintPageInfos = new List<VnEmrPrintPageInfo>();
                    foreach (EmrRecordInfo emrRecordInfo in _lstEmrRecordInfos)
                    {
                        if (_screenEnum == ScreenEnum.UcEditor && emrRecordInfo.PkOut != _pkOut) continue;
                        DateTime startDate = Convert.ToDateTime(dpkStartDate.Text);
                        DateTime endDate = Convert.ToDateTime(dpkEndDate.Text);
                        DateTime dtEmrRecord = Convert.ToDateTime(emrRecordInfo.DateTime);
                        int iStartDate = DateTime.Compare(dtEmrRecord, startDate);
                        int iEndDate = DateTime.Compare(dtEmrRecord, endDate);
                        if ((iStartDate < 0 || iEndDate > 0) && !cbxPrintAll.Checked) continue;

                        VnEmrPrintPageInfo emrPrintPageInfo = new VnEmrPrintPageInfo();

                        emrPrintPageInfo.PkOut = emrRecordInfo.PkOut;
                        emrPrintPageInfo.TemplateId = emrRecordInfo.TemplateId;
                        emrPrintPageInfo.CurrentDate = _sysDate.Day.ToString();
                        emrPrintPageInfo.CurrentMonth = _sysDate.Month.ToString();
                        emrPrintPageInfo.CurrentYear = _sysDate.Year.ToString();
                        emrPrintPageInfo.DoctorName = UserInfo.UserName;

                        #region Get Hospital info
                        VnHospPrintInfo hospPrintInfo = new VnHospPrintInfo();
                        hospPrintInfo.HospName = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalName : "";
                        hospPrintInfo.HospAddress = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalAddress : "";
                        hospPrintInfo.HospPhone = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalTel : "";
                        hospPrintInfo.HospFax = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalFax : "";
                        hospPrintInfo.HospLogo = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalLogo : "";
                        hospPrintInfo.HospWebsite = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalWebsite : "";
                        emrPrintPageInfo.HospPrintInfo = hospPrintInfo;
                        #endregion

                        #region Get Patient info
                        VnPatientPrintInfo patientPrintInfo = new VnPatientPrintInfo();
                        patientPrintInfo.PatientCode = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientCode : "";
                        patientPrintInfo.PatientName = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientName1.ToUpper() : "";
                        patientPrintInfo.PatientDob = _patientResult.ManagePatInfo.Count > 0 ? FormatToStrVnDateTime(_patientResult.ManagePatInfo[0].Birth) : "";
                        patientPrintInfo.PatientSex = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Sex : "";
                        patientPrintInfo.PatientAddress = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Address1 + _patientResult.ManagePatInfo[0].Address2 : "";
                        patientPrintInfo.PatientPhone = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Tel : "";
                        patientPrintInfo.ReceiptDate = FormatToStrVnDateTime(emrRecordInfo.DateTime);
                        if (_patientResult.ManagePatInfo.Count > 0)
                        {
                            //MED-16056
                            /*string dtSub = (DateTime.Now.Year + 1 - Convert.ToDateTime(_patientResult.ManagePatInfo[0].Birth).Year).ToString();*/
                            string dtSub = (DateTime.Now.Year/* + 1 */- Convert.ToDateTime(_patientResult.ManagePatInfo[0].Birth).Year).ToString();
                            patientPrintInfo.PatientAge = dtSub;
                        }
                        emrPrintPageInfo.PatientPrintInfo = patientPrintInfo;

                        #endregion

                        #region Get list Disease
                        List<VnDiseasePrintInfo> lstDiseasePrintInfos = new List<VnDiseasePrintInfo>();
                        foreach (OcsoOCS1003P01GridOutSangInfo ocsoOcs1003P01GridOutSangInfo in LstOcsoOCS1003P01GridOutSangInfo)
                        {
                            VnDiseasePrintInfo diseasePrintInfo = new VnDiseasePrintInfo();
                            diseasePrintInfo.DiseaseCode = ocsoOcs1003P01GridOutSangInfo.SangCode;
                            diseasePrintInfo.DiseaseName = ocsoOcs1003P01GridOutSangInfo.SangName;

                            lstDiseasePrintInfos.Add(diseasePrintInfo);
                        }
                        emrPrintPageInfo.DiseasePrintInfos = lstDiseasePrintInfos;
                        #endregion

                        #region Get Tag/Image from MML

                        List<VnTagPrintInfo> lstTagPrintInfos = new List<VnTagPrintInfo>();
                        List<VnImagePrintInfo> lstImagePrintInfos = new List<VnImagePrintInfo>();
                        foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                        {
                            if (tagInfo == null || tagInfo.Type == TypeEnum.Pdf) continue;
                            if (tagInfo.Type == TypeEnum.Image)
                            {
                                VnImagePrintInfo imagePrintInfo = new VnImagePrintInfo();

                                string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", _hospCode, _bunho);
                                if (!File.Exists(filePathLocal))
                                {
                                    Utilities.DownloadFile(filePathLocal, UserInfo.HospCode, _bunho);
                                }
                                //InsertImage(filePathLocal, "jpeg", Utilities.GetFileName(filePathLocal), true, false);
                                imagePrintInfo.TagCode = tagInfo.TagCode;
                                imagePrintInfo.TagName = tagInfo.TagName;
                                imagePrintInfo.ImageLink = "file:///" + filePathLocal;
                                lstImagePrintInfos.Add(imagePrintInfo);
                            }
                            else
                            {
                                VnTagPrintInfo tagPrintInfo = new VnTagPrintInfo();
                                tagPrintInfo.TagCode = "  " + tagInfo.TagCode;
                                OCS2015U06Businesses.TagInfo dicA = null;
                                if (!string.IsNullOrEmpty(tagInfo.TagCode))
                                {
                                    dicA = DataProvider.Instance.TagDetail.ContainsKey(tagInfo.TagCode.Trim()) ? DataProvider.Instance.TagDetail[tagInfo.TagCode.Trim()] : null;
                                }

                                if (dicA != null)
                                {
                                    tagInfo.TagCode = dicA.TagCode;
                                }

                                tagPrintInfo.TagName = tagInfo.TagName;
                                tagPrintInfo.TagContent = tagInfo.Content != null ? tagInfo.Content.ToString() : "";
                                lstTagPrintInfos.Add(tagPrintInfo);
                            }

                        }
                        emrPrintPageInfo.TagPrintInfos = lstTagPrintInfos;
                        emrPrintPageInfo.ImagePrintInfos = lstImagePrintInfos;

                        #endregion

                        #region Get List Order info

                        List<VnDrugPrintInfo> lstDrugPrintInfos = new List<VnDrugPrintInfo>();
                        int count = 0;
                        List<OCS2015U00GetOrderReportInfo> lstOrderInfo = GetOrderByPkOut(_bunho, emrRecordInfo.PkOut);
                        foreach (OCS2015U00GetOrderReportInfo orderInfo in lstOrderInfo)
                        {
                            VnDrugPrintInfo drugPrintInfo = new VnDrugPrintInfo();
                            drugPrintInfo.Stt = (++count).ToString();
                            drugPrintInfo.DrugName = orderInfo.HangmogName;
                            drugPrintInfo.DrugUnit = orderInfo.CodeName; //Don vi
                            Double quantity = 0;
                            bool isNumber = Double.TryParse(orderInfo.DvQuantity, out quantity);
                            drugPrintInfo.Quantity = String.Format("{0:#,##0.##}", quantity);
                            drugPrintInfo.Method = orderInfo.BogyongName; //Huong dan su dung

                            lstDrugPrintInfos.Add(drugPrintInfo);
                        }

                        emrPrintPageInfo.DrugPrintInfos = lstDrugPrintInfos;
                        #endregion

                        emrPrintPageInfo.IsPatientInfo = cbxPatientInfo.Checked;
                        emrPrintPageInfo.IsOrderInfo = cbxOrderInfo.Checked;
                        emrPrintPageInfo.IsDiseasePrinting = cbxDiseasePrinting.Checked;

                        lstEmrPrintPageInfos.Add(emrPrintPageInfo);
                    }

                    vnEmrPrintData.EmrPrintPageInfos = lstEmrPrintPageInfos;

                    if (vnEmrPrintData != null)
                    {
                        JsonSerializerSettings setting = new JsonSerializerSettings();
                        setting.TypeNameHandling = TypeNameHandling.Objects;
                        _strDataBinding = JsonConvert.SerializeObject(vnEmrPrintData, setting);
                    }
                    #endregion
                }
                else
                {
                    #region Data for Jp

                    #region Get Obj

                    EmrPrintData emrPrintData = new EmrPrintData();
                    emrPrintData.PatientCode = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientCode : "";
                    emrPrintData.NameKanji = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientName1 : "";
                    emrPrintData.NameKana = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].PatientName2 : "";
                    emrPrintData.Gender = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Sex : "";
                    emrPrintData.Birthday = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Birth : "";
                    if (_patientResult.ManagePatInfo.Count > 0)
                    {
                        //MED-16056
                        /*string dtSub = (DateTime.Now.Year + 1 - Convert.ToDateTime(_patientResult.ManagePatInfo[0].Birth).Year).ToString();*/
                        string dtSub = (DateTime.Now.Year/* + 1 */- Convert.ToDateTime(_patientResult.ManagePatInfo[0].Birth).Year).ToString();
                        emrPrintData.Age = dtSub;
                    }
                    emrPrintData.PatientTel = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Tel : "";
                    emrPrintData.PatientAddress = _patientResult.ManagePatInfo.Count > 0 ? _patientResult.ManagePatInfo[0].Address1 + _patientResult.ManagePatInfo[0].Address2 : "";
                    emrPrintData.PageNumber = "1"; //todo
                    emrPrintData.Department = UserInfo.BuseoName; //todo
                    emrPrintData.DoctorNameFromMml = UserInfo.UserName;
                    emrPrintData.DoctorNameUserName = UserInfo.UserName;
                    emrPrintData.InsuranceClassification = _currentDataPrintResult != null ? _currentDataPrintResult.InsuranceClassification : "";

                    List<EmrPrintInfo> lstEmrPrintInfos = new List<EmrPrintInfo>();

                    #region Get from MML
                    List<DateTime> dateTimeList = new List<DateTime>();                    

                    foreach (EmrRecordInfo emrRecordInfo in _lstEmrRecordInfos)
                    {
                        if (_screenEnum == ScreenEnum.UcEditor && emrRecordInfo.PkOut != _pkOut) continue;
                        DateTime startDate = Convert.ToDateTime(dpkStartDate.Text);
                        DateTime endDate = Convert.ToDateTime(dpkEndDate.Text);
                        DateTime dtEmrRecord = Convert.ToDateTime(emrRecordInfo.DateTime);
                        int iStartDate = DateTime.Compare(dtEmrRecord, startDate);
                        int iEndDate = DateTime.Compare(dtEmrRecord, endDate);
                        if ((iStartDate < 0 || iEndDate > 0) && !cbxPrintAll.Checked) continue;

                        EmrPrintInfo emrPrintInfo = new EmrPrintInfo();
                        emrPrintInfo.ExaminationDate = emrRecordInfo.DateTime;

                        dateTimeList.Add(dtEmrRecord);
                        int _firstExaminationDate = _lstEmrRecordInfos.Count;  
                        if (_firstExaminationDate > 0)
                        {                            
                            emrPrintData.FirstExaminationDate = emrRecordInfo.DateTime;                           
                            for (int i = 0; i <dateTimeList.Count; i++ )
                            {
                                DateTime dt1 = dateTimeList[0];
                                DateTime dt2 = dateTimeList[i];
                                int endDateTime = DateTime.Compare(dt1, dt2);
                                if (endDateTime <= 0)
                                {
                                    emrPrintData.LastExaminationDate = dt2.ToShortDateString();
                                }
                            }
                            
                        }
                        List<TagPrintInfo> lstTagPrintInfos = new List<TagPrintInfo>();
                        foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                        {
                            if (tagInfo == null) continue;
                            TagPrintInfo tagPrintInfo = new TagPrintInfo();
                            tagPrintInfo.TagCode = tagInfo.TagCode;
                            tagPrintInfo.TagName = tagInfo.TagName;
                            tagPrintInfo.IsImage = tagInfo.Type == TypeEnum.Image || tagInfo.Type == TypeEnum.Pdf;


                            if (tagInfo.Type == TypeEnum.Image)
                            {
                                string filePathLocal = Utilities.ConvertToLocalPath(!string.IsNullOrEmpty(tagInfo.DirLocation) ? tagInfo.DirLocation.Trim() : "", _hospCode, _bunho);
                                if (!File.Exists(filePathLocal))
                                {
                                    Utilities.DownloadFile(filePathLocal, UserInfo.HospCode, _bunho);
                                }
                                //InsertImage(filePathLocal, "jpeg", Utilities.GetFileName(filePathLocal), true, false);

                                tagPrintInfo.ImageLink = "file:///" + filePathLocal;
                            }
                            else
                            {
                                tagPrintInfo.TagContent = tagInfo.Content != null ? tagInfo.Content.ToString() : "";
                            }

                            lstTagPrintInfos.Add(tagPrintInfo);
                        }
                        emrPrintInfo.TagPrintInfos = lstTagPrintInfos;

                        //MED-15743
                        string tempGroupSer = null;
                        List<OrderPrintInfo> lstOrderPrintInfos = new List<OrderPrintInfo>();
                        
                        for (int i = 0; i <= emrRecordInfo.OrderInfos.Count; i++)
                        {
                            if (emrRecordInfo.OrderInfos.Count <= 0) continue;
                            OrderPrintInfo orderPrintInfo = new OrderPrintInfo();
                            
                            // End of one data block?
                            if ((i == emrRecordInfo.OrderInfos.Count || (tempGroupSer != null && tempGroupSer != emrRecordInfo.OrderInfos[i].GroupSer)))
                            {
                                OrderPrintInfo lastBlockItem = new OrderPrintInfo();                                
                                lastBlockItem.Dosage = emrRecordInfo.OrderInfos[i - 1].BogyongName;
                                lastBlockItem.JusaName = emrRecordInfo.OrderInfos[i - 1].JusaName;// "Injection Day"
                                lastBlockItem.IsDosage = emrRecordInfo.OrderInfos[i - 1].BogyongName != null ? true : false;
                                lastBlockItem.IsInjectionGuide = emrRecordInfo.OrderInfos[i - 1].JusaName != null
                                    ? true
                                    : false;                                                                  
                                lastBlockItem.NumberOfDay = emrRecordInfo.OrderInfos[i - 1].Nalsu;
                                lastBlockItem.IsBlank = true;
                                lstOrderPrintInfos.Add(lastBlockItem);
                                //End of data
                                if (i == emrRecordInfo.OrderInfos.Count)
                                {
                                    break;
                                }
                            }
                            if (tempGroupSer != emrRecordInfo.OrderInfos[i].GroupSer)
                            {
                                orderPrintInfo.OrderClassification = emrRecordInfo.OrderInfos[i].InputGubunName;                                
                            }
                            else
                            {
                                orderPrintInfo.OrderClassification = null;
                            }                             
                            orderPrintInfo.DoctorName = emrRecordInfo.OrderInfos[i].Doctor;
                            orderPrintInfo.OrderName = emrRecordInfo.OrderInfos[i].HangmogName;
                            orderPrintInfo.OrderContent = emrRecordInfo.OrderInfos[i].Content;

                            //MED-15743
                            orderPrintInfo.DvTime = emrRecordInfo.OrderInfos[i].DvTime;
                            if (emrRecordInfo.OrderInfos[i].MixSet == "1")
                            {
                                orderPrintInfo.MixSet = "M";
                                orderPrintInfo.IsMixSet = true;
                            }
                            else orderPrintInfo.IsMixSet = false;

                            orderPrintInfo.UnequalDosage = emrRecordInfo.OrderInfos[i].UnequalDosage;
                            orderPrintInfo.HopeDate = emrRecordInfo.OrderInfos[i].HopeDate;
                            orderPrintInfo.Comment = emrRecordInfo.OrderInfos[i].Comment;
                            orderPrintInfo.NumberOfDay = emrRecordInfo.OrderInfos[i].Nalsu;
                            orderPrintInfo.IsHopeDate = emrRecordInfo.OrderInfos[i].HopeDate != null ? true : false;
                            orderPrintInfo.IsComment = emrRecordInfo.OrderInfos[i].Comment != null ? true : false;
                            orderPrintInfo.IsUnequalDosage = emrRecordInfo.OrderInfos[i].UnequalDosage != null ? true : false;
                            if (emrRecordInfo.OrderInfos[i].InputTab == "01")
                            {
                                orderPrintInfo.Dosage = emrRecordInfo.OrderInfos[i].BogyongName; // "Dosage"
                            }
                            if (emrRecordInfo.OrderInfos[i].InputTab == "03")
                            {
                                orderPrintInfo.JusaName = emrRecordInfo.OrderInfos[i].JusaName;// "Injection Day"
                            }
                            lstOrderPrintInfos.Add(orderPrintInfo);
                            tempGroupSer = emrRecordInfo.OrderInfos[i].GroupSer;
                        }
                        emrPrintInfo.OrderPrintInfos = lstOrderPrintInfos;

                        lstEmrPrintInfos.Add(emrPrintInfo);
                    }

                    #endregion

                    emrPrintData.EmrPrintInfos = lstEmrPrintInfos;

                    List<DiseasePrintInfo> lstDiseasePrintInfos = new List<DiseasePrintInfo>();
                    foreach (OcsoOCS1003P01GridOutSangInfo ocsoOcs1003P01GridOutSangInfo in LstOcsoOCS1003P01GridOutSangInfo)
                    {
                        DiseasePrintInfo diseasePrintInfo = new DiseasePrintInfo();
                        diseasePrintInfo.Disease = ocsoOcs1003P01GridOutSangInfo.SangName;
                        diseasePrintInfo.StartDate = ocsoOcs1003P01GridOutSangInfo.SangStartDate;
                        diseasePrintInfo.EndDate = ocsoOcs1003P01GridOutSangInfo.SangEndDate;
                        diseasePrintInfo.Reason = !string.IsNullOrEmpty(ocsoOcs1003P01GridOutSangInfo.CodeName) ? ocsoOcs1003P01GridOutSangInfo.CodeName : "";

                        //Default
                        emrPrintData.Disease = ocsoOcs1003P01GridOutSangInfo.SangName;

                        lstDiseasePrintInfos.Add(diseasePrintInfo);
                    }
                    emrPrintData.DiseasePrintInfos = lstDiseasePrintInfos;


                    emrPrintData.HospitalName = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalName : "";
                    emrPrintData.HospitalAddress = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalAddress : "";
                    emrPrintData.HospitalTel = _currentDataPrintResult != null ? _currentDataPrintResult.HospitalTel : "";

                    emrPrintData.InsPersonNo = _currentDataPrintResult != null && _currentDataPrintResult.InsPersionInfoFirst.Count > 0 ? _currentDataPrintResult.InsPersionInfoFirst[0].InsPersonNo : "";
                    emrPrintData.RecipientNo = _currentDataPrintResult != null && _currentDataPrintResult.InsPersionInfoFirst.Count > 0 ? _currentDataPrintResult.InsPersionInfoFirst[0].RecipientNo : "";

                    emrPrintData.InsPersonNo2 = _currentDataPrintResult != null && _currentDataPrintResult.InsPersionInfoSecond.Count > 0 ? _currentDataPrintResult.InsPersionInfoSecond[0].InsPersonNo : "";
                    emrPrintData.RecipientNo2 = _currentDataPrintResult != null && _currentDataPrintResult.InsPersionInfoSecond.Count > 0 ? _currentDataPrintResult.InsPersionInfoSecond[0].RecipientNo : "";

                    emrPrintData.InsProviderNo = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].InsProviderNo : "";
                    emrPrintData.ExpireDate = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].ExpireDate : "";
                    emrPrintData.EffectiveDate = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].EffectiveDate : "";
                    emrPrintData.InsInstitutionalName = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].InsInstitutionalName : "";
                    emrPrintData.InsCode = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].InsCode : "";
                    emrPrintData.InsName = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].InsName : "";
                    emrPrintData.Number = _currentDataPrintResult != null && _currentDataPrintResult.InsProviderInfo.Count > 0 ? _currentDataPrintResult.InsProviderInfo[0].Number : "";

                    emrPrintData.IsPatientInfo = cbxPatientInfo.Checked;
                    emrPrintData.IsOrderInfo = cbxOrderInfo.Checked;
                    emrPrintData.IsDiseasePrinting = cbxDiseasePrinting.Checked;

                    #endregion

                    if (emrPrintData != null)
                    {
                        JsonSerializerSettings setting = new JsonSerializerSettings();
                        setting.TypeNameHandling = TypeNameHandling.Objects;
                        _strDataBinding = JsonConvert.SerializeObject(emrPrintData, setting);
                    }
                    #endregion
                }

                /*SetJsBuffer(webKitBrowser1, obj);*/
                //SetJsBuffer(webKitBrowser1, _strDataBinding);
                //SetJsBuffer(webView1,_strDataBinding,"");
                //webKitBrowser1.Document.InvokeScriptMethod("bindData", new object[] { });

                //            object[] arr = { "some parameter" };
                //            webKitBrowser1.Document.InvokeScriptMethod("bindData", new object[] { "ABC" });
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of method: BindData(): " + ex.StackTrace);
            }
        }

        #endregion

        #region Event
        private void xButtonList2_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                /*webKitBrowser1.ShowPageSetupDialog();*/
                webView1.Print();
            }
            catch
            {
                XMessageBox.Show("Error");
            }
        }

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    GetOtherData(_bunho, "10323");
                    BindData();
                    break;
                case FunctionType.Print:
                    Print();
                    break;
                case FunctionType.Close:
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        private void PopupPrintEmr_Load(object sender, EventArgs e)
        {
            ReportMedicalRecord report = new ReportMedicalRecord();
            //Set the printing system
            report.CreateDocument();
        }

        private void cbxPrintAll_CheckedChanged(object sender, EventArgs e)
        {
            dpkStartDate.Enabled = !cbxPrintAll.Checked;
            dpkEndDate.Enabled = !cbxPrintAll.Checked;
            GetOtherData(_bunho, "10323");            
            BindData();
            
        }

        private void dpkStartDate_TextChanged(object sender, EventArgs e)
        {
            
            if (!_isFirstOpen) BindData();
        }

        private void dpkEndDate_TextChanged(object sender, EventArgs e)
        {
            if (!_isFirstOpen) BindData();
        }

        private void cbxPatientInfo_CheckedChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void cbxOrderInfo_CheckedChanged(object sender, EventArgs e)
        {           
            BindData();
        }

        private void cbxDiseasePrinting_CheckedChanged(object sender, EventArgs e)
        {
            BindData();
        }

        #endregion

        #region Method

        private List<OCS2015U00GetOrderReportInfo> GetOrderByPkOut(string bunho, string pkOut)
        {
            List<OCS2015U00GetOrderReportInfo> lstOcs2015U00GetOrderReportInfos = new List<OCS2015U00GetOrderReportInfo>();
            OCS2015U00GetOrderByPkoutArgs args = new OCS2015U00GetOrderByPkoutArgs();
            args.Bunho = bunho;
            args.Pkout = pkOut;
            OCS2015U00GetOrderByPkoutResult result = CloudService.Instance.Submit<OCS2015U00GetOrderByPkoutResult, OCS2015U00GetOrderByPkoutArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                lstOcs2015U00GetOrderReportInfos = result.OrderReportInfo;
            }

            return lstOcs2015U00GetOrderReportInfos;
        }

        private string GetHtmlTemplate()
        {
            string strHtml = "";
            OCS2015U00GetHtmlContentArgs args = new OCS2015U00GetHtmlContentArgs();
            args.FormatType = FormatType;
            args.TplType = TplType;
            OCS2015U00GetHtmlContentResult result = CloudService.Instance.Submit<OCS2015U00GetHtmlContentResult, OCS2015U00GetHtmlContentArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                strHtml = result.PrintContent;
            }
            return strHtml;
        }

        private void GetPatientInfo()
        {
            if (!String.IsNullOrEmpty(_bunho))
            {
                try
                {
                    if (_patientResult == null)
                    {
                        OCS2015U00GetPatientInfoArgs args = new OCS2015U00GetPatientInfoArgs();
                        args.Bunho = _bunho;
                        _patientResult = CloudService.Instance.Submit<OCS2015U00GetPatientInfoResult, OCS2015U00GetPatientInfoArgs>(args);
                    }
                }
                catch
                {
                    XMessageBox.Show("Get patient info failed!");
                }
            }
        }

        private void GetOtherData(string bunho, string doctor)
        {
            try
            {
                string startDate = dpkStartDate.Text;
                string endDate = dpkEndDate.Text;

                OCS2015U00GetDataPrintEmrMedicalArgs args = new OCS2015U00GetDataPrintEmrMedicalArgs();
                args.Bunho = bunho;
                args.Doctor = doctor; //don't use
                args.FirstExaminationDate = cbxPrintAll.Checked ? "" : startDate;
                args.LastExaminationDate = cbxPrintAll.Checked ? "" : endDate;

                OCS2015U00GetDataPrintEmrMedicalResult result = CloudService.Instance.Submit<OCS2015U00GetDataPrintEmrMedicalResult, OCS2015U00GetDataPrintEmrMedicalArgs>(args);
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    _dicDoctorInfo.Clear();
                    foreach (OCS2015U00GetDataDoctorInfo doctorInfo in result.DoctorInfo)
                    {
                        if (_dicDoctorInfo.ContainsKey(doctorInfo.DoctorCode))
                        {
                            _dicDoctorInfo[doctorInfo.DoctorCode] = doctorInfo.DoctorName;
                        }
                        else
                        {
                            _dicDoctorInfo.Add(doctorInfo.DoctorCode, doctorInfo.DoctorName);
                        }
                    }

                    foreach (OCS2015U00GetDataDosageInfo dosageInfo in result.DosageInfo)
                    {
                        if (!string.IsNullOrEmpty(dosageInfo.Fkout1001))
                        {
                            string[] pkOut1001Arr = dosageInfo.Fkout1001.Split(new char[] { '.' });
                            string key = pkOut1001Arr[0] + "-" + dosageInfo.InputtabAndGroupser;
                            if (_dicDosageInfo.ContainsKey(key))
                            {
                                _dicDosageInfo[key] = dosageInfo.BogyongName;
                            }
                            else
                            {
                                _dicDosageInfo.Add(key, dosageInfo.BogyongName);
                            }

                        }

                    }

                    _currentDataPrintResult = result;
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of method: GetOtherData(): " + ex.StackTrace);
            }
        }

        private void BindingToWebControl()
        {
            try
            {
                _strDataBinding = _strDataBinding.Replace(@"\", @"\\");
                SetJsBuffer(webView1, _strDataBinding, "");
                EOBrowser.ExecuteScript(webView1, "bindData();");
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of method: BindingToWebControl(): " + ex.StackTrace);
            }
        }

        public static void SetJsBuffer(WebView webView, string serializedData, string suffix)
        {
            string id = "cs-js-buffer" + suffix;

            Element elem = null;
            try
            {
                if (webView.CanEvalScript)
                {
                    elem = (Element)EOBrowser.ExecuteScript(webView, string.Format("document.getElementById('{0}');", id));
                }
            }
            catch (Exception) { }

            if (elem == null)
            {
                string script = @"  var iDiv = document.createElement('div');";
                script += @"  iDiv.id = '" + id + "';";
                script += @"  iDiv.innerText = '" + serializedData + "';";
                script += @"  iDiv.setAttribute('style', 'display: none;');";
                script += @"  document.getElementsByTagName('body')[0].appendChild(iDiv);";

                if (webView.CanEvalScript)
                {
                    //webView.EvalScript(script, false);
                    //string html = webView.GetHtml();
                }
                else
                {
                    Thread.Sleep(2000);
                }

                //webView.EvalScript(script, false);
                EOBrowser.ExecuteScript(webView, script);
                string html = webView.GetHtml();
            }
        }

        private void Print()
        {
            webView1.Print();
        }

        private void SetEnableTopPanelControl(bool isEnable)
        {
            /*pnlButton.Enabled = isEnable;*/
            dpkStartDate.Enabled = isEnable;
            dpkEndDate.Enabled = isEnable;
            cbxPrintAll.Enabled = isEnable;
        }

        private string FormatToStrVnDateTime(string dateTime)
        {
            string dtVn = "";
            DateTime dtOriginal = new DateTime();
            bool isOk = DateTime.TryParse(dateTime, out dtOriginal);
            dtVn = dtOriginal.ToString("d");
            return dtVn;
        }
        
        #endregion

        private void webView1_LoadCompleted(object sender, EO.WebBrowser.LoadCompletedEventArgs e)
        {
            BindingToWebControl();
        }
    }

    public static class EOBrowser
    {
        /// <summary>
        /// Serialize an object to JSON string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SerializeObject(object data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.SerializeObject(data, settings);
        }

        /// <summary>
        /// Executes a JS code on current active webview
        /// </summary>
        /// <param name="webView"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public static object ExecuteScript(WebView webView, string script)
        {
            object retObj = new object();

            ScriptCall sc = webView.QueueScriptCall(script);
            sc.WaitOne();

            if (sc.IsDone())
            {
                retObj = sc.Result;
            }

            if (sc.Exception != null && sc.Exception.Message != string.Empty)
            {
                Service.WriteLog("Execute JS error. Message: " + sc.Exception.Message);
            }

            return retObj;
        }

        /// <summary>
        /// Create and save a html file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void SaveFileHtml(string path, string data)
        {
            path = path.Replace("file:///", "").Replace(@"/", @"\");
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(path);
            }

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(data);
                }
            }
        }
    }
}


