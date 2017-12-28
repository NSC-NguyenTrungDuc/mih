using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    using IHIS.Framework;
    using IHIS.OCSO;

    using NReco.PdfGenerator;
    using System.IO;
    using Newtonsoft.Json;
    using EO.WebBrowser;
    using System.Threading;
    using System.Drawing.Printing;

    public partial class PrintForm : Form
    {
        private readonly string templateFile;

        private readonly string staticData;

        private readonly string dynamicDt;

        private readonly Callback callback;

        public PrintForm()
        {
            InitializeComponent();
        }

        public PrintForm(string templateFile, string staticData, string dynamicDt, Callback callback)
        {
            InitializeComponent();
            //webKitBrowser1.IsScriptingEnabled = true;
            this.templateFile = templateFile;
            this.staticData = staticData;
            this.dynamicDt = dynamicDt;
            this.callback = callback;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //webKitBrowser1.Url = new Uri(templateFile);
            //webKitBrowser1.DocumentCompleted += webKitBrowser1_DocumentCompleted;

            webView1.Url = templateFile;
            webView1.LoadCompleted += new LoadCompletedEventHandler(webView1_LoadCompleted);
        }

        //void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    //OCS4000U00.SetJsBuffer(webKitBrowser1, dynamicDt, "");
        //    //OCS4000U00.SetJsBuffer(webKitBrowser1, staticData, "-static");
        //    //webKitBrowser1.Document.InvokeScriptMethod("bindTemplateData", new object[] { });
        //}

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Close: 
                    this.Close();
                    break;
                case FunctionType.Print:
                    //webKitBrowser1.Print();
                    //callback(webKitBrowser1.DocumentText);

                    // Print directly
                    PrinterSettings printset = new PrinterSettings();
                    PageSettings settingPage = new PageSettings();
                    settingPage.PaperSize.RawKind = (int)PaperKind.A4;
                    settingPage.Margins = new Margins(0, 0, 0, 0);
                    webControl1.WebView.Print(true, printset, settingPage);

                    callback(webView1.GetHtml());
                    break;
                //case FunctionType.Insert:
                //    saveFileDialog1.ShowDialog();
                //    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //webKitBrowser1.Dispose();

            webView1.Dispose();
            webControl1.Dispose();
        }

        private void btnSetting_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            //webKitBrowser1.ShowPrintDialog();
            webView1.Print();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //string html = "" + webKitBrowser1.Document.InvokeScriptMethod("getDocumentHtml", new object[] { });
            //HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();

            //string curDir = Application.StartupPath.Replace("\\", @"/");
            //string tempFile = String.Format("{0}/OCSO/{1}.html", curDir, DateTime.Now.Ticks);
            //OCS4000U00.SaveFileHtml(tempFile, html);

            //htmlToPdf.GeneratePdfFromFile(tempFile, null, saveFileDialog1.FileName);
            //File.Delete(tempFile);

            string html = "";

            if (webView1.CanEvalScript)
            {
                html = OCS4000U00.ExecuteScript(webView1, "getDocumentHtml();").ToString();
            }

            HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();

            string curDir = Application.StartupPath.Replace("\\", @"/");
            string tempFile = String.Format("{0}/OCSO/{1}.html", curDir, DateTime.Now.Ticks);
            OCS4000U00.SaveFileHtml(tempFile, html);

            htmlToPdf.GeneratePdfFromFile(tempFile, null, saveFileDialog1.FileName);
            File.Delete(tempFile);
        }

        private void btnPrintPdf_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        #region Using EOWebBrowser control

        //
        // Replace WebkitBrowser to EOWebBrowser to implement https://sofiamedix.atlassian.net/browse/MED-15366
        //

        private void webView1_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            OCS4000U00.SetJsBuffer(webView1, dynamicDt, "");
            OCS4000U00.SetJsBuffer(webView1, staticData, "-static");

            if (webView1.CanEvalScript)
            {
                //JSFunction func = (JSFunction)webView1.EvalScript("bindTemplateData");
                //func.Invoke(webView1.GetDOMWindow(), new object[] { });
            }
            else
            {
                Thread.Sleep(3000);
            }

            OCS4000U00.ExecuteScript(webView1, "bindTemplateData();");
        }

        #endregion
    }
}
