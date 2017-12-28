using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;
using NReco.PdfGenerator;
using System.IO;
using Newtonsoft.Json;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector;
using System.Drawing.Printing;

namespace IHIS.NURO
{
    using EO.WebBrowser;
    using System.Threading;
    using EO.WebBrowser.DOM;
    using IHIS.CloudConnector.Caching;
    using IHIS.NURO.Properties;
    public partial class PrintForm : Form
    {
        private  string templateFile;

        private string staticData;

        private readonly string dynamicDt;

        private readonly DataHospital dtHospital;

        private string printTemplate;

        public PrintForm()
        {
            InitializeComponent();
        }

        public PrintForm(DataHospital dtHos)
        {
            InitializeComponent();            
            dtHospital = dtHos;
            staticData = SerializeObject(dtHos);
            GetTemplate();
            webView1.Url = templateFile;
        }
        private void GetTemplate()
        {
            BIL0102U00PrintTemplateArgs args = new BIL0102U00PrintTemplateArgs();
            BIL0102U00PrintTemplateResult result = CloudService.Instance.Submit<BIL0102U00PrintTemplateResult, BIL0102U00PrintTemplateArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
               printTemplate = result.Template;
            }
            string curDir = Application.StartupPath.Replace("\\", @"/");
            templateFile = String.Format("file:///{0}/NURO/{1}_{3}_{2}", curDir, "billing", "Bil0102U00.html", "Print");            
            SaveFileHtml(templateFile, printTemplate);
        }
        protected override void OnLoad(EventArgs e)
        {
            // License
            EO.WebBrowser.Runtime.AddLicense(
            "xq20psLcrmurs8PbsHCZpAcQ8azg8//ooWqtprHavUaBpLHLn3Xq7fgZ4K3s" +
            "9vbp4o2w78X0zqat5Qod54zA+eTx86G+xc7ou2jq7fgZ4K3s9vbpjEOzs/0U" +
            "4p7l9/bpjEN14+30EO2s3MKetZ9Zl6TNF+ic3PIEEMidtbbB3bRwqrzK4bdx" +
            "s7P9FOKe5ff29ON3hI6xy59Zs/D6DuSn6un26bto4+30EO2s3OnPuIlZl6Sx" +
            "5+Cl4/MI6YxDl6Sxy59Zl6TNDOOdl/gKG+R2mcng2cKh6fP+EKFZ7ekDHuio" +
            "5cGz3LVnp6ax2r1GgaSxy591puX9F+6wtZGby59Zl8AAHeOe6c3/Ee5Z2+UF" +
            "ELxbqLXA3bNoqbTC4aFZ6vnz8Pep4Pb2HsA=");


            base.OnLoad(e);
            //templateFile = @"C:\ihis\NURO\1.html";
            webView1.Url = templateFile;
            webView1.LoadCompleted += new LoadCompletedEventHandler(webView1_LoadCompleted);
        }

        //void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    string dynamicDt = "{\"$type111\":\"IHIS.NURO.DataHospital\"}";
        //    SetJsBuffer(webKitBrowser1, dynamicDt, "");    
        //    SetJsBuffer(webKitBrowser1, staticData, "-static");
        //    webKitBrowser1.Document.InvokeScriptMethod("bindTemplateData", new object[] { });
        //}

        public static void SetJsBuffer(WebView webView, string serializedData, string suffix)
        {
            string id = "cs-js-buffer" + suffix;

            Element elem = null;
            try
            {
                if (webView.CanEvalScript)
                {
                    elem = (Element)ExecuteScript(webView, string.Format("document.getElementById('{0}');", id));
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

                //webView.EvalScript(script, false);
                ExecuteScript(webView, script);
                string html = webView.GetHtml();
            }
        }


        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Close:
                    this.Close();
                    break;
                case FunctionType.Print:
                    PrinterSettings printerSettings = CacheService.Instance.Get<PrinterSettings>("PRINTER_SETTING_" + UserInfo.HospCode);
                    PageSettings pageSettings = CacheService.Instance.Get<PageSettings>("PAGE_SETTING_" + UserInfo.HospCode);
                    if (printerSettings == null || pageSettings == null)
                    {
                        btnSetting_ButtonClick(null, null);
                    }
                    else {
                        webControl1.WebView.Print(true, printerSettings, pageSettings);
                    }                                       
                    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            webView1.Dispose();
            webControl1.Dispose();
        }

        private void btnSetting_ButtonClick(object sender, ButtonClickEventArgs e)
        {            
            PrintDialog printdialog = new PrintDialog(); 
            if (printdialog.ShowDialog() == DialogResult.OK)
            {
                if (printdialog.PrinterSettings.DefaultPageSettings.PaperSize.RawKind == 0) {
                    printdialog.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 119;
                }
                printdialog.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                CacheService.Instance.Set("PRINTER_SETTING_" + UserInfo.HospCode, printdialog.PrinterSettings, TimeSpan.MaxValue);
                CacheService.Instance.Set("PAGE_SETTING_" + UserInfo.HospCode, printdialog.PrinterSettings.DefaultPageSettings, TimeSpan.MaxValue);
                webControl1.WebView.Print(true, printdialog.PrinterSettings, printdialog.PrinterSettings.DefaultPageSettings);
            }           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string html = "";

            if (webView1.CanEvalScript)
            {
                html = ExecuteScript(webView1, "getDocumentHtml();").ToString();
            }

            HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();

            string curDir = Application.StartupPath.Replace("\\", @"/");
            string tempFile = String.Format("{0}/NURO/{1}.html", curDir, DateTime.Now.Ticks);
            SaveFileHtml(tempFile, html);
            htmlToPdf.Margins.Left = 0;
            htmlToPdf.Margins.Right = 0;
            htmlToPdf.Margins.Top = 0;
            htmlToPdf.Margins.Bottom = 0;
            htmlToPdf.Zoom = 1.275f;
            htmlToPdf.CustomWkHtmlArgs = "  --print-media-type --dpi 72";
            try
            {
                htmlToPdf.GeneratePdfFromFile(tempFile, null, saveFileDialog1.FileName);
                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.ToString());
            }
        }

        private void btnPrintPdf_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            saveFileDialog1.FileName = !String.IsNullOrEmpty(dtHospital.Invoice_no) ? dtHospital.Patient_code + "_" + dtHospital.Invoice_no : dtHospital.Patient_code;
            saveFileDialog1.Filter = "Pdf Files|*.pdf";
            saveFileDialog1.ShowDialog();
        }
        internal static void SaveFileHtml(string path, string data)
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

        private string SerializeObject(object data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.SerializeObject(data, settings);

        }

        #region Using EOWebBrowser control

        //
        // Replace WebkitBrowser to EOWebBrowser to implement https://sofiamedix.atlassian.net/browse/MED-15366
        //

        private void webView1_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            string dynamicDt = "{\"$type111\":\"IHIS.NURO.DataHospital\"}";
            SetJsBuffer(webView1, dynamicDt, "");
            SetJsBuffer(webView1, staticData, "-static");
            //SetJsBuffer(webView1, Resources.test519, "-static");

            if (webView1.CanEvalScript)
            {
                //JSFunction func = (JSFunction)webView1.EvalScript("bindTemplateData");
                //func.Invoke(webView1.GetDOMWindow(), new object[] { });
            }
            else
            {
                Thread.Sleep(3000);
            }

           ExecuteScript(webView1, "bindTemplateData();");
        }
        public static object ExecuteScript(WebView webView, string script)
        {
            object retObj = new object();

            ScriptCall sc = webView.QueueScriptCall(script);
            sc.WaitOne();

            if (sc.IsDone())
            {
                retObj = sc.Result;
            }

            return retObj;
        }
        #endregion
    }
}
