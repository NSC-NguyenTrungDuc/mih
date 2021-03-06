using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EO.WebBrowser.DOM;
using EO.WebBrowser;
using System.Threading;
using IHIS.Framework;
using System.IO;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using Newtonsoft.Json;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Drawing.Printing;
using NReco.PdfGenerator;
using IHIS.DRGS.Properties;
using System.Diagnostics;

namespace IHIS.DRGS
{
    public partial class FormDrugPrescription : Form
    {
        #region Constants

        /// <summary>
        /// Indicates the type of hospital. For Japanese hospitals only.
        /// </summary>
        public enum HospitalType
        {
            /// <summary>
            /// In-hospital checkbox is checked
            /// </summary>
            InHospital,

            /// <summary>
            /// Out-hospital checkbox is checked
            /// </summary>
            OutHospital,

            /// <summary>
            /// Both in/out hospital checkbox are checked
            /// </summary>
            All,

            /// <summary>
            /// Both in/out hospital checkbox are not checked
            /// </summary>
            None
        }

        private char[] TRIM_CHARS = new char[] { '生' };

        #endregion

        #region Fields & Properties

        private string _jsData = "{}";
        private string _templateUrl = "";
        private string _presInData;
        private string _presOutData;
        private XScreen _parentScreen;
        private DateTime _sysDate = EnvironInfo.GetSysDate();

        /* Precsiption*/
        private string pdf_name = "";
        private string Bunho = "";
        private string PkOut = "";
        private string pkOut_DRG5100P01 = "";
        private string bunHo_DRG5100P01 = "";
        private string NaewonDate = "";
        private const string FormatType = "HTML";
        private const string TplType = "EMR";
        private const string TplTypePrecription = "PRESCRIPTION";
        private OCS2015U00GetDataPrescriptionResult _patientPrescriptionResult;
        private string jSonData = "{}";
        private string jSonDataInHopital = "{}";
        private string jSonDataOutHopital = "{}";
        private List<OcsoOCS1003P01GridOutSangInfo> _lstOcsoOCS1003P01GridOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();
        //private DrugPrescriptionVi drugPrescriptionData = new DrugPrescriptionVi();
        //private DrugPrescriptionIn drugPrescriptionIn = new DrugPrescriptionIn();
        //private DrugPrescriptionOut drugPrescriptionOut = new DrugPrescriptionOut();
        //private DrugPrescriptionBase drugPrescriptionBase = new DrugPrescriptionBase();        
        bool isInHospital = false;
        bool isOutHospital = false;
        bool isFirstPrescrption = true;
        private HospitalType _hospType;
        /* Precsiption*/

        [Browsable(false)]
        public string TemplateUrl
        {
            get { return _templateUrl; }
            set { _templateUrl = value; }
        }

        [Browsable(false)]
        public HospitalType HospType
        {
            get
            {
                return (cbxInHospital.Checked && cbxOutHospital.Checked) ? HospitalType.All : (cbxOutHospital.Checked ? HospitalType.OutHospital : (cbxInHospital.Checked ? HospitalType.InHospital : HospitalType.None));
            }
            set { _hospType = value; }
        }

        /// <summary>
        /// JSON string
        /// </summary>
        [Browsable(false)]
        public string PresInData
        {
            get { return _presInData; }
            set { _presInData = value; }
        }

        /// <summary>
        /// JSON string
        /// </summary>
        [Browsable(false)]
        public string PresOutData
        {
            get { return _presOutData; }
            set { _presOutData = value; }
        }

        [Browsable(false)]
        public XScreen ParentScreen
        {
            get { return _parentScreen; }
            set { _parentScreen = value; }
        }

        #endregion

        #region Constructors

        public FormDrugPrescription()
        {
            InitializeComponent();
        }

        // For DRG5100P01
        public FormDrugPrescription(string templateUrl, string jsData, HospitalType hospType, XScreen parentScreen, string _patientCode, string _pkOut)
        {
            InitializeComponent();

            // Fires after the browser finished loading.
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(webView1_LoadCompleted);

            // Handle the exceptions
            EO.Base.Runtime.Exception += new EO.Base.ExceptionEventHandler(Runtime_Exception);

            // To debug on Chrome, go to http://localhost:1234/
            EO.WebBrowser.Runtime.RemoteDebugPort = 1234;

            this._jsData = jsData;
            this._templateUrl = templateUrl;
            this.pkOut_DRG5100P01 = _pkOut;
            this.bunHo_DRG5100P01 = _patientCode;
            //this._templateUrl = @"C:/ihis/DRGS/DRG5100P01_JP1.html";
            this._hospType = hospType;
            this._parentScreen = parentScreen;

            // Enable/disable checkbox in-out hospital
            if (hospType == HospitalType.InHospital)
            {
                this.cbxInHospital.Checked = true;
                this.cbxOutHospital.Checked = false;
            }
            else
            {
                this.cbxInHospital.Checked = false;
                this.cbxOutHospital.Checked = true;
            }

            this.cbxInHospital.Enabled = false;
            this.cbxOutHospital.Enabled = false;

            //https://sofiamedix.atlassian.net/browse/MED-15577
            pdf_name = bunHo_DRG5100P01 + "_" + pkOut_DRG5100P01;
        }

        public FormDrugPrescription(string templateUrl, string _naewonDate, string _pkOut, XScreen parentScreen, List<OcsoOCS1003P01GridOutSangInfo> lstOcsoOcs1003P01GridOutSangInfo, OCS2015U00GetDataPrescriptionResult patientPrescriptionResult)
        {
            InitializeComponent();
            //string template = "file:///C:/ihis/OCSO/Hospital_Prescription_JA1.html";
            //this._templateUrl = "file:///C:/ihis/OCSO/Hospital_Prescription_JA1.html";  
          
            this._templateUrl = templateUrl;              
            this.ParentScreen = parentScreen;
           // if (_patientPrescriptionResult == null) return;
            _lstOcsoOCS1003P01GridOutSangInfo = lstOcsoOcs1003P01GridOutSangInfo;
            _patientPrescriptionResult = patientPrescriptionResult;
            NaewonDate = _naewonDate;
            PkOut = _pkOut;
            CheckHideCheckBoxIOHospital();
            BindData();            
            // Fires after the browser finished loading.
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(webView1_LoadCompleted);

            // Handle the exceptions
            EO.Base.Runtime.Exception += new EO.Base.ExceptionEventHandler(Runtime_Exception);

            // To debug on Chrome, go to http://localhost:1234/
            EO.WebBrowser.Runtime.RemoteDebugPort = 1234;

            //https://sofiamedix.atlassian.net/browse/MED-15577
            if (patientPrescriptionResult.PatientInfo.Count > 0)
            {
                pdf_name = patientPrescriptionResult.PatientInfo[0].PatientCode + "_" + _pkOut;
            }
        }

        #endregion

        #region Events

        private void cbxInHospital_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.ParentScreen.Name)
            {
                case "OCS2015U00":
                case "OCS2016U02":
                    BindData();
                    break;
                case "DRG5100P01":
                    webView1.Url = this._templateUrl;
                    break;
                default:
                    break;
            }
        }

        private void FormDrugPrescription_Load(object sender, EventArgs e)
        {
            webView1.Url = this._templateUrl;

            // https://sofiamedix.atlassian.net/browse/MED-15570
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "Pdf Files (*.pdf)|*.pdf";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            this.btnPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnPrintSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // License
            EO.WebBrowser.Runtime.AddLicense(
            "xq20psLcrmurs8PbsHCZpAcQ8azg8//ooWqtprHavUaBpLHLn3Xq7fgZ4K3s" +
            "9vbp4o2w78X0zqat5Qod54zA+eTx86G+xc7ou2jq7fgZ4K3s9vbpjEOzs/0U" +
            "4p7l9/bpjEN14+30EO2s3MKetZ9Zl6TNF+ic3PIEEMidtbbB3bRwqrzK4bdx" +
            "s7P9FOKe5ff29ON3hI6xy59Zs/D6DuSn6un26bto4+30EO2s3OnPuIlZl6Sx" +
            "5+Cl4/MI6YxDl6Sxy59Zl6TNDOOdl/gKG+R2mcng2cKh6fP+EKFZ7ekDHuio" +
            "5cGz3LVnp6ax2r1GgaSxy591puX9F+6wtZGby59Zl8AAHeOe6c3/Ee5Z2+UF" +
            "ELxbqLXA3bNoqbTC4aFZ6vnz8Pep4Pb2HsA=");
        }

        private void btnPrintSetting_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog = new PrintDialog();
            if (printdialog.ShowDialog() == DialogResult.OK)
            {
                PrinterSettings printset = new PrinterSettings();
                PageSettings settingPage = new PageSettings();
                settingPage = printdialog.PrinterSettings.DefaultPageSettings;
                settingPage.Margins = new Margins(0, 0, 0, 0);
                webControl1.WebView.Print(true, printset, settingPage);
            } 
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = pdf_name;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //string html = Helpers.ExecuteScript(webView1, "getDocumentHtml();").ToString();
            string html = webView1.GetHtml();
            string curDir = Application.StartupPath.Replace("\\", @"/");
            string tempFile = "";

            if (this.ParentScreen.Name == "OCS2015U00" || this.ParentScreen.Name == "OCS2016U02")
            {
                tempFile = String.Format("{0}/OCSO/{1}.html", curDir, DateTime.Now.Ticks);
            }
            else if (this.ParentScreen.Name == "DRG5100P01")
            {
                tempFile = String.Format("{0}/DRGS/{1}.html", curDir, DateTime.Now.Ticks);
            }

            HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();
            htmlToPdf.Margins.Left = 0;
            htmlToPdf.Margins.Right = 0;
            htmlToPdf.Margins.Top = 0;
            htmlToPdf.Margins.Bottom = 0;
            htmlToPdf.Zoom = 1.275f;
            htmlToPdf.CustomWkHtmlArgs = "  --print-media-type --dpi 72";
            Helpers.SaveFileHtml(tempFile, html);

            htmlToPdf.GeneratePdfFromFile(tempFile, null, saveFileDialog1.FileName);
            File.Delete(tempFile);
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Print:
                 /*   if (NetInfo.Language == LangMode.Vi)
                    {
                        PrinterSettings printset = new PrinterSettings();
                        PageSettings settingPage = new PageSettings();
                        settingPage.PaperSize = new PaperSize("A5 (148 x 210 mm)", 827, 584);
                        settingPage.PaperSize.RawKind = (int)PaperKind.A5;
                        settingPage.Margins = new Margins(0, 0, 0, 0);
                        settingPage.Landscape = true;
                        webControl1.WebView.Print(true, printset, settingPage);
                        break;
                    }
                    else
                    {
                        PrinterSettings printset = new PrinterSettings();
                        PageSettings settingPage = new PageSettings();
                        settingPage.PaperSize.RawKind = (int)PaperKind.A4;
                        settingPage.Margins = new Margins(0, 0, 0, 0);
                        //settingPage.Landscape = true;
                        webControl1.WebView.Print(true, printset, settingPage);
                        break;
                    } */  
                        PrinterSettings printset = new PrinterSettings();
                        PageSettings settingPage = new PageSettings();
                        settingPage.PaperSize = new PaperSize("A5 (148 x 210 mm)", 827, 584);
                        settingPage.PaperSize.RawKind = (int)PaperKind.A5;
                        settingPage.Margins = new Margins(0, 0, 0, 0);
                        settingPage.Landscape = true;
                        webControl1.WebView.Print(true, printset, settingPage);
                        break;
                case FunctionType.Close:
                    this.Close();
                    break;
            }
        }

        private void Runtime_Exception(object sender, EO.Base.ExceptionEventArgs e)
        {
            if (e.ErrorException != null)
            {
                Service.WriteLog(e.ErrorException.Message);
                Service.WriteLog(e.ErrorException.StackTrace);
            }
        }

        private void webView1_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            string jSonDefault = "{}";
            switch (this.ParentScreen.Name)
            {
                case "OCS2015U00":
                case "OCS2016U02":
                    if (NetInfo.Language != LangMode.Jr)
                    {
                        this.FillTemplateData(jSonData, "bindDrugInHospitalTemplateData();", "in");                        
                    }
                    else
                    {
                        if (this.HospType == HospitalType.All)
                        {
                            // Bind in-hospital data
                            this.FillTemplateData(jSonDataInHopital, "bindDrugInHospitalTemplateData();", "in");

                            // Insert a page break
                            Helpers.ExecuteScript(this.webView1, "insertPageBreak();");

                            // Bind out-hospital data
                            this.FillTemplateData(jSonDataOutHopital, "bindDrugOutHospitalTemplateData();", "out");
                            return;
                        }
                        if (this.HospType == HospitalType.InHospital)
                        {
                            this.FillTemplateData(jSonDataInHopital, "bindDrugInHospitalTemplateData();", "in");
                            // Bind in-data
                            return;
                        }
                        if (this.HospType == HospitalType.OutHospital)
                        {
                            //this.FillTemplateData(jSonDataInHopital, "bindDrugInHospitalTemplateData();");
                            this.FillTemplateData(jSonDataOutHopital, "bindDrugOutHospitalTemplateData();", "out");
                            // Bind out-data
                            return;
                        }
                        if (this.HospType == HospitalType.None)
                        {
                            this.FillTemplateData(jSonDefault, "bindDrugInHospitalTemplateData();", "in");
                        }

                    }
                    break;
                case "DRG5100P01":
                    if (NetInfo.Language == LangMode.Jr)
                    {
                        if (cbxInHospital.Checked)
                        {
                            // In-hospital
                            this.FillTemplateData(this._jsData, "bindDrugInHospitalTemplateData();", "in");
                        }
                        else
                        {
                            // Out-hospital
                            this.FillTemplateData(this._jsData, "bindDrugOutHospitalTemplateData();", "out");
                        }
                    }
                    else
                    {
                        this.FillTemplateData(this._jsData, "bindDrugInHospitalTemplateData();", "in");
                    }
                    break;
            }
        }

        #endregion

        #region Methods(public)


        #endregion

        #region Methods(private)

        private bool FindWonyoiOrderYnIn(OCS2015U00GetDataPrescriptionInfo item)
        {
            return item.WonyoiOrderYn == "N" && cbxInHospital.Checked;
        }

        private bool FindWonyoiOrderYnOut(OCS2015U00GetDataPrescriptionInfo item)
        {
            return item.WonyoiOrderYn == "Y" && cbxOutHospital.Checked;
        }

        private void GetDataCommonPresciptionJapan(DrugPrescriptionBase drgPrescriptionBase)
        {

            #region Get Data Insurance 1
            int insPersionInfoFist = _patientPrescriptionResult.InsPersionInfoFirst.Count;
            int insProviderInfo = _patientPrescriptionResult.InsProviderInfo.Count;
            int insPersionInfoSecond = _patientPrescriptionResult.InsPersionInfoSecond.Count;
            drgPrescriptionBase.BudamjaBunho11 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 0) : "";
            drgPrescriptionBase.BudamjaBunho12 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 1) : "";
            drgPrescriptionBase.BudamjaBunho13 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 2) : "";
            drgPrescriptionBase.BudamjaBunho14 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 3) : "";
            drgPrescriptionBase.BudamjaBunho15 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 4) : "";
            drgPrescriptionBase.BudamjaBunho16 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 5) : "";
            drgPrescriptionBase.BudamjaBunho17 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 6) : "";
            drgPrescriptionBase.BudamjaBunho18 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].InsPersonNo, 7) : "";

            drgPrescriptionBase.SugubjaBunho11 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 0) : "";
            drgPrescriptionBase.SugubjaBunho12 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 1) : "";
            drgPrescriptionBase.SugubjaBunho13 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 2) : "";
            drgPrescriptionBase.SugubjaBunho14 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 3) : "";
            drgPrescriptionBase.SugubjaBunho15 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 4) : "";
            drgPrescriptionBase.SugubjaBunho16 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 5) : "";
            drgPrescriptionBase.SugubjaBunho17 = insPersionInfoFist > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoFirst[0].RecipientNo, 6) : "";

            drgPrescriptionBase.Johap1 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 0) : "";
            drgPrescriptionBase.Johap2 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 1) : "";
            drgPrescriptionBase.Johap3 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 2) : "";
            drgPrescriptionBase.Johap4 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 3) : "";
            drgPrescriptionBase.Johap5 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 4) : "";
            drgPrescriptionBase.Johap6 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 5) : "";
            drgPrescriptionBase.Johap7 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 6) : "";
            drgPrescriptionBase.Johap8 = insProviderInfo > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsProviderInfo[0].InsProviderNo, 7) : "";

            drgPrescriptionBase.Gaein = _patientPrescriptionResult.InsProviderInfo.Count > 0 ? _patientPrescriptionResult.InsProviderInfo[0].InsCode : "";
            drgPrescriptionBase.GaeinNo = _patientPrescriptionResult.InsProviderInfo.Count > 0 ? _patientPrescriptionResult.InsProviderInfo[0].Number : "";
            drgPrescriptionBase.JeadanName = _patientPrescriptionResult.InsProviderInfo.Count > 0 ? _patientPrescriptionResult.InsProviderInfo[0].Number : ""; // Hosp Name
            #endregion

            #region Get patient info
            drgPrescriptionBase.NameKana = _patientPrescriptionResult.PatientInfo.Count > 0 ? _patientPrescriptionResult.PatientInfo[0].PatientName2 : "";
            drgPrescriptionBase.NameKanji = _patientPrescriptionResult.PatientInfo.Count > 0 ? _patientPrescriptionResult.PatientInfo[0].PatientName1 + " 様" : "";
            try
            {
                drgPrescriptionBase.Birth = _patientPrescriptionResult.PatientInfo.Count > 0 ? Utilities.GetDateByLangMode(_patientPrescriptionResult.PatientInfo[0].Birth, LangMode.Jr) : "";
            }
            catch { }
            if (_patientPrescriptionResult.PatientInfo.Count > 0)
            {
                if (_patientPrescriptionResult.PatientInfo[0].Sex == Resources.Sex_male)
                {
                    drgPrescriptionBase.Sex = "M";
                }
                else drgPrescriptionBase.Sex = "F";
            }
            // Oval
            drgPrescriptionBase.BoninGubunOval = _patientPrescriptionResult.InsProviderInfo.Count > 0 ? _patientPrescriptionResult.InsProviderInfo[0].BonGaGubun : "";          
            drgPrescriptionBase.JeadanName = _patientPrescriptionResult.JaedanName != string.Empty ? _patientPrescriptionResult.JaedanName : "";
            drgPrescriptionBase.YoyangName = _patientPrescriptionResult.HospName != string.Empty ? _patientPrescriptionResult.HospName : "";
            drgPrescriptionBase.Address = _patientPrescriptionResult.HospAddress != string.Empty ? _patientPrescriptionResult.HospAddress : "";
            drgPrescriptionBase.Address1 = _patientPrescriptionResult.HospAddress1 != string.Empty ? _patientPrescriptionResult.HospAddress1 : "";                        
            drgPrescriptionBase.DoctorName = UserInfo.UserName;
            drgPrescriptionBase.Tel = _patientPrescriptionResult.Tell != string.Empty ? _patientPrescriptionResult.Tell : "";
            #endregion

            #region Get Infomation Insurance 2
            drgPrescriptionBase.BudamjaBunho21 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 0) : "";
            drgPrescriptionBase.BudamjaBunho22 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 1) : "";
            drgPrescriptionBase.BudamjaBunho23 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 2) : "";
            drgPrescriptionBase.BudamjaBunho24 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 3) : "";
            drgPrescriptionBase.BudamjaBunho25 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 4) : "";
            drgPrescriptionBase.BudamjaBunho26 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 5) : "";
            drgPrescriptionBase.BudamjaBunho27 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 6) : "";
            drgPrescriptionBase.BudamjaBunho28 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].InsPersonNo, 7) : "";


            drgPrescriptionBase.SugubjaBunho21 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 0) : "";
            drgPrescriptionBase.SugubjaBunho22 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 1) : "";
            drgPrescriptionBase.SugubjaBunho23 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 2) : "";
            drgPrescriptionBase.SugubjaBunho24 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 3) : "";
            drgPrescriptionBase.SugubjaBunho25 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 4) : "";
            drgPrescriptionBase.SugubjaBunho25 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 4) : "";
            drgPrescriptionBase.SugubjaBunho26 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 5) : "";
            drgPrescriptionBase.SugubjaBunho27 = insPersionInfoSecond > 0 ? GetLetterInStrByIdx(_patientPrescriptionResult.InsPersionInfoSecond[0].RecipientNo, 6) : "";

            #endregion
        }

        /// <summary>
        /// Splits a string without delimiter. And return a specify letter.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetLetterInStrByIdx(string str, int index)
        {
            string letter = string.Empty;

            if (TypeCheck.IsNull(str))
            {
                return letter;
            }

            char[] letters = str.ToCharArray();

            try
            {
                letter = letters[index].ToString();
            }
            catch
            {
                letter = string.Empty;
            }
            finally { }

            return letter;
        }

        private string FormatToStrVnDateTime(string dateTime)
        {
            string dtVn = "";
            DateTime dtOriginal = new DateTime();
            bool isOk = DateTime.TryParse(dateTime, out dtOriginal);
            dtVn = dtOriginal.ToString("d");
            return dtVn;
        }

        private string SplitYear(string date)
        {
            string pattern = "/";
            Regex myRegex = new Regex(pattern);
            string[] result = myRegex.Split(date);
            return result[2].ToString();
        }

        private void BindData()
        {
            DrugPrescriptionVi drugPrescriptionData = new DrugPrescriptionVi();
            DrugPrescriptionIn drugPrescriptionIn = new DrugPrescriptionIn();
            DrugPrescriptionOut drugPrescriptionOut = new DrugPrescriptionOut();
            DrugPrescriptionBase drugPrescriptionBase = new DrugPrescriptionBase();

            webView1.Url = _templateUrl;
            //webView1.Url = "file:///C:/ihis/OCSO/Hospital_Prescription_JA1.html";  


            #region Prescription for Vi and En
            // for vi.
            if (NetInfo.Language != LangMode.Jr)
            {
                //DrugPrescriptionVi drugPrescriptionData = new DrugPrescriptionVi();

                #region Get Patient Infomation
               
                drugPrescriptionData.HospName = UserInfo.HospName;
                drugPrescriptionData.PrescriptionNo = PkOut;
                drugPrescriptionData.PatientName = _patientPrescriptionResult.PatientInfo[0].PatientName1;
                try
                {
                    drugPrescriptionData.BirthYear = _patientPrescriptionResult.PatientInfo.Count > 0 ? SplitYear(FormatToStrVnDateTime(_patientPrescriptionResult.PatientInfo[0].Birth)) : "";
                }
                catch { }

                if (_patientPrescriptionResult.PatientInfo.Count > 0)
                {
                    drugPrescriptionData.Gender = _patientPrescriptionResult.PatientInfo[0].Sex;
                }

                drugPrescriptionData.DoctorName = UserInfo.UserName;
                drugPrescriptionData.PatientAddress = _patientPrescriptionResult.PatientInfo.Count > 0 ? _patientPrescriptionResult.PatientInfo[0].Address1 +
                    _patientPrescriptionResult.PatientInfo[0].Address2 : "";
                #endregion

                #region Get list Disease

                string mainDisease = "";
                string extraDisease = "";
                foreach (OcsoOCS1003P01GridOutSangInfo item in _lstOcsoOCS1003P01GridOutSangInfo)
                {
                    if (item.JuSangYn == "Y")
                    {
                        mainDisease = !string.IsNullOrEmpty(mainDisease) ? mainDisease + "," + item.SangName : item.SangName;
                    }
                    else
                    {
                        extraDisease = !string.IsNullOrEmpty(extraDisease) ? extraDisease + "," + item.SangName : item.SangName;
                    }
                }

                drugPrescriptionData.MainDisease = mainDisease;
                drugPrescriptionData.ExtraDiseas = extraDisease;

                #endregion

                #region  GetInsurance

                drugPrescriptionData.Johap = _patientPrescriptionResult.InsProviderInfo.Count > 0
                    ? _patientPrescriptionResult.InsProviderInfo[0].InsProviderNo
                    : "";
                #endregion

                #region  Get Infomation Preciption
                List<DrugPrescriptionViDetail> lstdrugInfo = new List<DrugPrescriptionViDetail>();
                int i = 0;
                foreach (OCS2015U00GetDataPrescriptionInfo item in _patientPrescriptionResult.DataPrescription)
                {
                    DrugPrescriptionViDetail drugInfo = new DrugPrescriptionViDetail();
                    if (item.WonyoiOrderYn == "N" && cbxInHospital.Checked)
                    {
                        i++;
                        drugInfo.DrugNo = i.ToString();
                        drugInfo.OrderDanui = item.CodeName;
                        drugInfo.JaeryoName = item.HangmogName;
                        drugInfo.BogyongName = item.BogyongName;
                        drugInfo.Quantity = item.DvQuantity;
                        lstdrugInfo.Add(drugInfo);
                    }
                    if (item.WonyoiOrderYn == "Y" && cbxOutHospital.Checked)
                    {
                        i++;
                        drugInfo.DrugNo = i.ToString();
                        drugInfo.OrderDanui = item.CodeName;
                        drugInfo.JaeryoName = item.HangmogName;
                        drugInfo.BogyongName = item.BogyongName;
                        drugInfo.Quantity = item.DvQuantity;
                        lstdrugInfo.Add(drugInfo);
                    }
                }
                drugPrescriptionData.PresDetail = lstdrugInfo;
                #endregion

                drugPrescriptionData.CurrentDate = _sysDate.Day.ToString();
                drugPrescriptionData.CurrentMonth = _sysDate.Month.ToString();
                drugPrescriptionData.CurrentYear = _sysDate.Year.ToString();
                if (drugPrescriptionData != null)
                {
                    jSonData = Helpers.SerializeObject(drugPrescriptionData);
                }
            }
            #endregion

            #region Prescription for Jr
            else if (NetInfo.Language == LangMode.Jr)
            {
                List<OCS2015U00GetDataPrescriptionInfo> dataPrescriptionOut = _patientPrescriptionResult.DataPrescription.FindAll(FindWonyoiOrderYnOut);
                List<OCS2015U00GetDataPrescriptionInfo> dataPrescriptionIn = _patientPrescriptionResult.DataPrescription.FindAll(FindWonyoiOrderYnIn);
                DateTime dt = Convert.ToDateTime(NaewonDate);
                DateTime dtGigamDate = dt.AddDays(3);

                #region Get Data Drug Info in Hosital
                if (cbxInHospital.Checked && isFirstPrescrption)
                {
                    drugPrescriptionIn.PageNumber = "1";
                    drugPrescriptionIn.PageTotal = "1";
                    drugPrescriptionIn.GwaName = UserInfo.BuseoName;
                    drugPrescriptionIn.PatientCode = _patientPrescriptionResult.PatientInfo.Count > 0 ? _patientPrescriptionResult.PatientInfo[0].PatientCode : "";
                    drugPrescriptionIn.GubunName = _patientPrescriptionResult.InsProviderInfo.Count > 0 ?_patientPrescriptionResult.InsProviderInfo[0].GubunName : "";
                    drugPrescriptionIn.DrugBunho = "";
                    drugPrescriptionIn.DoctorCode = UserInfo.DoctorID;
                    drugPrescriptionIn.SunwonGubunOval = "";
                    drugPrescriptionIn.ExaminationDate = Utilities.GetDateByLangMode(NaewonDate, LangMode.Jr).TrimEnd(TRIM_CHARS);
                    drugPrescriptionIn.GigamDate = Utilities.GetDateByLangMode(dtGigamDate.ToString(), LangMode.Jr).TrimEnd(TRIM_CHARS);
                    drugPrescriptionIn.CautionName = _patientPrescriptionResult.WnSerialItem.Count > 0 ? _patientPrescriptionResult.WnSerialItem[0].CautionName : "";
                    drugPrescriptionIn.MayakAddress1 = "";
                    drugPrescriptionIn.MayakDoctor = "";
                    drugPrescriptionIn.MayakAddress2 = "";
                   
                    GetDataCommonPresciptionJapan(drugPrescriptionIn);

                    #region Check last drug & get data Drug In

                    List<DrugPrescriptionDetail> presDetail = new List<DrugPrescriptionDetail>();

                    string tempSerialV = null;
                    string tempFkocs = null;
                    int totalRowIn = 0;
                    int countIn = 1;
                    int rowIdx = 0;
                    string tempGroupSer = null;
                    bool isCheckEndBlock = false;
                    if (cbxInHospital.Checked && isFirstPrescrption)
                    {
                        for (int i = 0; i <= dataPrescriptionIn.Count; i++)
                        {
                            DrugPrescriptionDetail infoDetail = new DrugPrescriptionDetail();

                            // End of one data block?
                            //if (/*(tempSerialV != null && tempSerialV != rows[i]["serial_v"].ToString()) ||*/i == dataPrescriptionIn.Count - 1)
                            if (i == dataPrescriptionIn.Count || (tempGroupSer != null && tempGroupSer != dataPrescriptionIn[i].GroupSer))
                            {
                                // Data from previous row
                                DrugPrescriptionDetail lastBlockItem = new DrugPrescriptionDetail();
                                lastBlockItem.DataBlockEnd = "Y";
                                lastBlockItem.BogyongName = dataPrescriptionIn[i - 1].BogyongName;
                                lastBlockItem.Nalsu = dataPrescriptionIn[i - 1].Nalsu;
                                lastBlockItem.DonbokYn = dataPrescriptionIn[i - 1].Donbok;
                                presDetail.Add(lastBlockItem);

                                // End of all data
                                if (i == dataPrescriptionIn.Count)
                                {
                                    break;
                                }
                            }

                            //infoDetail.SerialV = dataPrescriptionIn[i].SerialV;
                            infoDetail.BogyongName = dataPrescriptionIn[i].BogyongName;
                            infoDetail.Nalsu = dataPrescriptionIn[i].Nalsu;
                            if (tempGroupSer != dataPrescriptionIn[i].GroupSer)
                            {
                                infoDetail.SerialV = "Rp." + countIn + dataPrescriptionIn[i].SerialV;
                                countIn++;
                            }
                            else
                            {
                                infoDetail.SerialV = null;
                            }        
                            infoDetail.JaeryoName = dataPrescriptionIn[i].HangmogName;
                            infoDetail.OrderSuryang = dataPrescriptionIn[i].Suryang;
                            infoDetail.DvTime = dataPrescriptionIn[i].DvTime;
                            infoDetail.Dv = dataPrescriptionIn[i].Dv;
                            infoDetail.OrderDanui = dataPrescriptionIn[i].CodeName;
                            infoDetail.DonbokYn = dataPrescriptionIn.Count > 0 ? dataPrescriptionIn[i].Donbok : "";
                            infoDetail.DataGubun = "A";

                            presDetail.Add(infoDetail);                           
                            tempGroupSer = dataPrescriptionIn[i].GroupSer;
                        }

                        // Insert page break
                        DrugPrescriptionDetail pbItem = new DrugPrescriptionDetail();
                        pbItem.DetailEnd = "Y";
                        presDetail.Add(pbItem);

                        drugPrescriptionIn.PresDetail = presDetail;
                    }

                    #endregion

                    if (drugPrescriptionIn != null)
                    {
                        jSonDataInHopital = Helpers.SerializeObject(drugPrescriptionIn);
                        isFirstPrescrption = false;
                    }
                }
                #endregion

                #region Drug Prescription Out Hosptial

                if (cbxOutHospital.Checked && dataPrescriptionOut.Count > 0)
                {
                  
                    GetDataCommonPresciptionJapan(drugPrescriptionOut);
                    drugPrescriptionOut.ExaminationDate = Utilities.GetDateByLangMode(NaewonDate, LangMode.Jr).TrimEnd(TRIM_CHARS);
                    drugPrescriptionOut.GigamDate = Utilities.GetDateByLangMode(dtGigamDate.ToString(), LangMode.Jr).TrimEnd(TRIM_CHARS);
                    drugPrescriptionOut.Tel = _patientPrescriptionResult.Tell!= null ? _patientPrescriptionResult.Tell : "";
                    #region Check last drug & get data Drug Out

                    List<DrugPrescriptionDetail> presDetail = new List<DrugPrescriptionDetail>();

                    string tempSerialV = null;
                    string tempFkocs = null;
                    int totalRowIn = 0;
                    int rowIdx = 0;
                    string groupSer = "";
                    int countOut = 1;
                    string tempGroupSer = null;
                    if (cbxOutHospital.Checked)
                    {
                        for (int i = 0; i <= dataPrescriptionOut.Count; i++)
                        {
                            DrugPrescriptionDetail infoDetail = new DrugPrescriptionDetail();

                            // End of one data block?
                            //if (/*(tempSerialV != null && tempSerialV != rows[i]["serial_v"].ToString()) ||*/i == dataPrescriptionOut.Count - 1)
                            if (i == dataPrescriptionOut.Count || (tempGroupSer != null && tempGroupSer != dataPrescriptionOut[i].GroupSer))
                            {
                                // Data from previous row
                                DrugPrescriptionDetail lastBlockItem = new DrugPrescriptionDetail();
                                lastBlockItem.DataBlockEnd = "Y";
                                lastBlockItem.BogyongName = dataPrescriptionOut[i - 1].BogyongName;
                                lastBlockItem.Nalsu = dataPrescriptionOut[i - 1].Nalsu;
                                lastBlockItem.DonbokYn = dataPrescriptionOut[i - 1].Donbok;
                                presDetail.Add(lastBlockItem);

                                // End of all data
                                if (i == dataPrescriptionOut.Count)
                                {
                                    break;
                                }
                            }

                            //infoDetail.SerialV = dataPrescriptionOut[i].SerialV;
                            infoDetail.BogyongName = dataPrescriptionOut[i].BogyongName;
                            infoDetail.Nalsu = dataPrescriptionOut[i].Nalsu;
                            if (tempGroupSer != dataPrescriptionOut[i].GroupSer)
                            {
                                infoDetail.SerialV = "Rp." + countOut + dataPrescriptionOut[i].SerialV;
                                countOut++;
                            }
                            else
                            {
                                infoDetail.SerialV = null;
                            }
                            infoDetail.JaeryoName = dataPrescriptionOut[i].HangmogName;
                            infoDetail.DvTime = dataPrescriptionOut[i].DvTime;
                            infoDetail.Dv = dataPrescriptionOut[i].Dv;
                            infoDetail.OrderSuryang = dataPrescriptionOut[i].Suryang;
                            infoDetail.OrderDanui = dataPrescriptionOut[i].CodeName;
                            infoDetail.DonbokYn = dataPrescriptionOut.Count > 0 ? dataPrescriptionOut[i].Donbok : "";
                            infoDetail.DataGubun = "A";

                            presDetail.Add(infoDetail);
                            tempGroupSer = dataPrescriptionOut[i].GroupSer;
                        }

                    #endregion

                        //Check Hide CheckBox In Hospital

                        //isInHospital = dataPrescriptionIn.Count > 0 ? true : false;
                        //isOutHospital = dataPrescriptionOut.Count > 0 ? true : false;

                        // Insert page break
                        DrugPrescriptionDetail pbItem = new DrugPrescriptionDetail();
                        pbItem.DetailEnd = "Y";
                        presDetail.Add(pbItem);

                        drugPrescriptionOut.PresDetail = presDetail;
                        if (drugPrescriptionOut != null)
                        {
                            jSonDataOutHopital = Helpers.SerializeObject(drugPrescriptionOut);
                        }
                    }
                }

                #endregion
            }

            #endregion
        }

        private void FillTemplateData(string jsonData, string jsFunc)
        {
            this.FillTemplateData(jsonData, jsFunc, "");
        }

        private void FillTemplateData(string jsonData, string jsFunc, string idSuffix)
        {
            SetJsBuffer(webView1, jsonData, idSuffix);

            try
            {
                // Binding data
                if (webView1.CanEvalScript)
                {
                    //JSFunction func = (JSFunction)webView1.EvalScript("bindTemplateData", false);
                    //func.Invoke(webView1.GetDOMWindow(), new object[] { });
                }
                else
                {
                    Thread.Sleep(2000);
                }

                Helpers.ExecuteScript(webView1, jsFunc);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }
        }

        private void ShowTemplateForm(string templateData)
        {
            // Save file to local directory
            Helpers.SaveFileHtml(this._templateUrl, templateData);

            // File is saved?
            while (Utilities.IsFileLocked(new FileInfo(new Uri(this._templateUrl).LocalPath))) { }
            // File was saved and ready to use
            this.webView1.Url = this._templateUrl;
        }

        private void SetJsBuffer(WebView webView, string serializedData, string suffix)
        {
            string id = "";
            if (TypeCheck.IsNull(suffix))
            {
                id = "cs-js-buffer";
            }
            else
            {
                id = "cs-js-buffer" + "-" + suffix;
            }

            Element elem = null;
            try
            {
                if (webView.CanEvalScript)
                {
                    elem = (Element)Helpers.ExecuteScript(webView, string.Format("document.getElementById('{0}');", id));
                }
            }
            catch (Exception) { }

            if (elem == null)
            {
                serializedData = serializedData.Replace("\\", "\\\\");

                string script = @"  var iDiv = document.createElement('div');";
                script += @"  iDiv.id = '" + id + "';";
                script += @"  iDiv.innerHTML = '" + serializedData + "';";
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

                //webView.EvalScript(script, true);
                Helpers.ExecuteScript(webView, script);
                string html = webView.GetHtml(); // uncomment to debug.
                Service.WriteLog(html);
            }
        }

        private bool CheckOrderYnOut(OCS2015U00GetDataPrescriptionInfo item)
        {
            return item.WonyoiOrderYn == "Y" && _patientPrescriptionResult.DataPrescription.Count > 0;
        }
        private bool CheckOrderYnIn(OCS2015U00GetDataPrescriptionInfo item)
        {
            return item.WonyoiOrderYn == "N" && _patientPrescriptionResult.DataPrescription.Count > 0;
        }

        private void CheckHideCheckBoxIOHospital()
        {
            List<OCS2015U00GetDataPrescriptionInfo> dataPrescriptionOut = _patientPrescriptionResult.DataPrescription.FindAll(CheckOrderYnOut);
            List<OCS2015U00GetDataPrescriptionInfo> dataPrescriptionIn = _patientPrescriptionResult.DataPrescription.FindAll(CheckOrderYnIn);

            isInHospital = dataPrescriptionIn.Count > 0 ? true : false;
            isOutHospital = dataPrescriptionOut.Count > 0 ? true : false;

            //cbxInHospital.CheckedChanged -= cbxInHospital_CheckedChanged;
            //cbxOutHospital.CheckedChanged -= cbxInHospital_CheckedChanged;

            if (isInHospital && isOutHospital)
            {
                cbxInHospital.Enabled = true;
                cbxInHospital.Checked = true;
                cbxOutHospital.Enabled = true;
                cbxOutHospital.Checked = true;
            }
            else if (isInHospital && !isOutHospital)
            {
                cbxInHospital.Enabled = true;
                cbxInHospital.Checked = true;
                cbxOutHospital.Enabled = false;
                cbxOutHospital.Checked = false;
            }
            else if (!isInHospital && isOutHospital)
            {
                cbxInHospital.Enabled = false;
                cbxOutHospital.Enabled = true;
                cbxInHospital.Checked = false;
                cbxOutHospital.Checked = true;
            }
            else
            {
                cbxInHospital.Enabled = false;
                cbxOutHospital.Enabled = false;
                cbxInHospital.Checked = false;
                cbxOutHospital.Checked = false;
            }

        }

        #endregion
    }
}