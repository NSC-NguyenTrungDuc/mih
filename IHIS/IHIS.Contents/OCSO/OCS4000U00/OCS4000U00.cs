using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results;
using System.IO;

namespace IHIS.OCSO
{  
    using Newtonsoft.Json;
    using EO.WebBrowser;
    using EO.WebBrowser.DOM;
    using System.Drawing;
    using IHIS.OCS4000U00.Properties;
    using System.Threading;

    public delegate void Callback(string printed);

    public partial class OCS4000U00 : IHIS.Framework.XScreen
    {
        private string _formCode = "OCS4000U01";
        protected string FormCode
        {
            get { return _formCode; }
            set { _formCode = value; }
        }

        private string _formName = "OCS4000U01";
        protected string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }

        private string _templateFile = "OCS4001U00.html";
        protected string TemplateFile
        {
            get { return _templateFile; }
            set { _templateFile = value; }
        }

        private bool _prescriptionDateVisible = false;
        protected bool PrescriptionDateVisible
        {
            get { return _prescriptionDateVisible; }
            set { _prescriptionDateVisible = value; }
        }
        private string _userData;

        private OCS4001U00Result _patientData;
        private List<string> _diseases = new List<string>();

        private string dynamicData = "{}";

        private string defaultTemplate = "";

        private string defaultPrintTemplate = "";

        private string defaultValue = "{}";

        private OCS4001U00HospitalInfo hospitalInfo;

        public OCS4000U00()
        {
            EO.WebBrowser.Runtime.AddLicense(
                "xq20psLcrmurs8PbsHCZpAcQ8azg8//ooWqtprHavUaBpLHLn3Xq7fgZ4K3s" +
                "9vbp4o2w78X0zqat5Qod54zA+eTx86G+xc7ou2jq7fgZ4K3s9vbpjEOzs/0U" +
                "4p7l9/bpjEN14+30EO2s3MKetZ9Zl6TNF+ic3PIEEMidtbbB3bRwqrzK4bdx" +
                "s7P9FOKe5ff29ON3hI6xy59Zs/D6DuSn6un26bto4+30EO2s3OnPuIlZl6Sx" +
                "5+Cl4/MI6YxDl6Sxy59Zl6TNDOOdl/gKG+R2mcng2cKh6fP+EKFZ7ekDHuio" +
                "5cGz3LVnp6ax2r1GgaSxy591puX9F+6wtZGby59Zl8AAHeOe6c3/Ee5Z2+UF" +
                "ELxbqLXA3bNoqbTC4aFZ6vnz8Pep4Pb2HsA=");
            InitializeComponent();
            xEditGrid1.ExecuteQuery = GetPatientDetailList;
            //webKitBrowser1.IsScriptingEnabled = true;
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(webView1_LoadCompleted);
            this.webView1.JSExtInvoke += new JSExtInvokeHandler(webView1_JSExtInvoke);
            EO.WebBrowser.Runtime.RemoteDebugPort = 1234;
            EO.Base.Runtime.Exception += new EO.Base.ExceptionEventHandler(Runtime_Exception);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Height = rc.Height - 150;
        }

        private void OCS4000U00_Load(object sender, EventArgs e)
        {
            xDatePickerPrescriptionDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            OCS4001U00Args args = new OCS4001U00Args();
            args.BunhoCode = "";
            args.HospCode = UserInfo.HospCode;
            args.TemplateId = _formCode;
            args.OrderDate = "";
            args.PrescriptionDate = "";
            
            OCS4001U00Result res = CloudService.Instance.Submit<OCS4001U00Result, OCS4001U00Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                defaultTemplate = res.InputContent;
                defaultPrintTemplate = res.PrintContent;
                ShowTemplateForm(res.InputContent);
                if (res.Hospitals != null) hospitalInfo = res.Hospitals[0];
            }

            labelPrescriptionDate.Visible = _prescriptionDateVisible;
            xDatePickerPrescriptionDate.Visible = _prescriptionDateVisible;
        }

        private string SerializeObject(object data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.SerializeObject(data, settings);
        }

        private void patientBox1_PatientSelected(object sender, EventArgs e)
        {           
            xEditGrid1.QueryLayout(true);
        }

        private IList<object[]> GetPatientDetailList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS4001U00Args args = new OCS4001U00Args();
            args.BunhoCode = patientBox1.BunHo;
            args.HospCode = UserInfo.HospCode;
            args.TemplateId = _formCode;
            args.OrderDate = "";
            args.PrescriptionDate = "";
            OCS4001U00Result _patientData = CloudService.Instance.Submit<OCS4001U00Result, OCS4001U00Args>(args);
            defaultValue = "{}";
            if (_patientData.ExecutionStatus == ExecutionStatus.Success)
            {
                for (int i = 0; i < _patientData.Items.Count; i++)
                {
                    OCS4001U00ListItemInfo item = _patientData.Items[i];
                    lObj.Add(new object[] { item.Id, item.CreateDate, item.InputValue, item.InputContent, item.PrintContent, item.PrescriptionDate });
                    if (i == 0)
                    {
                        defaultValue = item.InputValue;
                    }
                }
            }                            
            _diseases.Clear();
            dynamicData = "{}";
            if (_patientData.SangNameList != null) { 
                foreach(OCS4001U00SangNameInfo  item in _patientData.SangNameList){
                    _diseases.Add(item.SangName);   
                }
            }

            // Don't need. This will fire on grid_RowFocusChanged event automatically
            //if (_patientData.ExecutionStatus == ExecutionStatus.Success
            //    && (_patientData.Items == null || _patientData.Items.Count == 0))
            //{
            //    ShowTemplateForm(defaultTemplate);
            //}

            return lObj;
        }

        private void ShowTemplateForm(string templateData)
        {
            string curDir = Application.StartupPath.Replace("\\", @"/");
            string currentUrl = String.Format("file:///{0}/OCSO/{1}_{2}", curDir, patientBox1.BunHo,_templateFile);
            SaveFileHtml(currentUrl, templateData);
            //this.webKitBrowser1.Url = new Uri(currentUrl);
            //this.webKitBrowser1.DocumentCompleted += webKitBrowser1_DocumentCompleted;

            // File is saved?
            while (this.IsFileLocked(new FileInfo(new Uri(currentUrl).LocalPath))) { }
            // File was saved and ready to use
            this.webView1.Url = currentUrl;
        }

        //void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    FillTemplateData(dynamicData);
        //}

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

        private void xEditGridPatient_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            Cursor preCur = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _userData = "";
                //backup old data
                if (e.PreviousRow >= 0)
                {
                    //xEditGrid1.SetItemValue(e.PreviousRow, "input_value", "" + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { }));  
                    xEditGrid1.SetItemValue(e.PreviousRow, "input_value", "" + this.GetFormData());
                }

                //apply new data
                dynamicData = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_value");

                string currentData = xEditGrid1.GetItemString(e.CurrentRow, "create_date");

                if (string.IsNullOrEmpty(currentData))
                {
                    xEditGrid1.SetItemValue(e.CurrentRow, "create_date", DateTime.Now.ToString("yyyy/MM/dd"));
                    xEditGrid1.SetItemValue(e.CurrentRow, "input_content", defaultTemplate);
                    xEditGrid1.SetItemValue(e.CurrentRow, "input_value", defaultValue);
                    xEditGrid1.SetItemValue(xEditGrid1.CurrentRowNumber, "prescription_date", DateTime.Now.ToString("yyyy/MM/dd"));
                }

                xDatePickerPrescriptionDate.Text = xEditGrid1.GetItemString(e.CurrentRow, "prescription_date");

                //apply new data
                dynamicData = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_value");

                string template = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_content");
                ShowTemplateForm(string.IsNullOrEmpty(template) ? defaultTemplate : template);

                xEditGrid1.Focus();
            }
            finally
            {
                Cursor.Current = preCur;
            }
        }

        private void SaveData()
        {
            OCS4001U00SaveArgs args = new OCS4001U00SaveArgs();
            args.Items = new List<OCS4001U00SaveInfo>();

             //xEditGrid1.SetItemValue(xEditGrid1.CurrentRowNumber, "input_value", "" + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { }));
            xEditGrid1.SetItemValue(xEditGrid1.CurrentRowNumber, "input_value", "" + this.GetFormData());

            for (int i = 0; i < xEditGrid1.RowCount; i++)
            {
                if(xEditGrid1.GetRowState(i) == DataRowState.Unchanged) continue;
                
                OCS4001U00SaveInfo saveInfo = new OCS4001U00SaveInfo();
                saveInfo.Id = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "id");
                saveInfo.FormatType = "HTML";
                saveInfo.TplCode = _formCode;
                saveInfo.FormCode = _formCode;
                saveInfo.FormName = _formName;
                saveInfo.InputContent = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_content"); ;// Done
                if (i == xEditGrid1.CurrentRowNumber)
                {
                    //saveInfo.InputValue = ""
                    //                      + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { });
                    saveInfo.InputValue = this.GetFormData();
                }
                else
                {
                    saveInfo.InputValue = xEditGrid1.GetItemString(i, "input_value");
                }
                //saveInfo.InputValue = System.Web.Server.HtmlEncode("" + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { }));
                saveInfo.PrintContent = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "print_content");// Done
                saveInfo.Bunho = patientBox1.BunHo;// Done
                saveInfo.HospCode = UserInfo.HospCode;// Done
                saveInfo.CreateDate = null; //Server has data
                saveInfo.PrintDatetime = null;//Done
                if (_prescriptionDateVisible)
                {
                    saveInfo.PrescriptionDate = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "prescription_date");    
                }

                saveInfo.SysId = null; //Server has data
                saveInfo.SysDate = null; //Server has data 
                saveInfo.UpdId = null;//Server has data 
                saveInfo.UpdDate = null;// Done
                saveInfo.ActiveFlg = "1";// Done
                saveInfo.RowState = xEditGrid1.GetRowState(i).ToString();
                args.Items.Add(saveInfo);
            }

            if (xEditGrid1.DeletedRowTable != null)
            {
                for (int i = 0; i < xEditGrid1.DeletedRowTable.Rows.Count; i++)
                {
                    OCS4001U00SaveInfo saveInfo1 = new OCS4001U00SaveInfo();
                    saveInfo1.Id = xEditGrid1.DeletedRowTable.Rows[i]["id"] + "";
                    saveInfo1.RowState = DataRowState.Deleted.ToString();
                    args.Items.Add(saveInfo1);
                }
            }
            if (args.Items.Count > 0)
            {
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS4001U00SaveArgs>(args);
                if (res != null && res.ExecutionStatus == ExecutionStatus.Success)
                {
                    XMessageBox.Show(Resources.MSG_SaveSuccess, Resources.CAP_Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xEditGrid1.QueryLayout(true);
                }
                else
                {
                    //TODO show message fail
                    XMessageBox.Show(Resources.MSG_Faile, Resources.CAP_Information, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SavePrintData(string printData) 
        {
            DateTime currentDate = EnvironInfo.GetSysDate();

            OCS4001U00SaveArgs args = new OCS4001U00SaveArgs();
            args.Items = new List<OCS4001U00SaveInfo>();
            OCS4001U00SaveInfo saveInfo = new OCS4001U00SaveInfo();

            saveInfo.Id = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "id");
            saveInfo.TplCode = _formCode;
            saveInfo.FormatType = "HTML";
            saveInfo.FormCode = _formCode;
            saveInfo.FormName = _formName;
            //saveInfo.InputContent = webKitBrowser1.DocumentText;// Done
            //saveInfo.InputValue = "" + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { });// Done
            saveInfo.InputContent = webView1.GetHtml();
            saveInfo.InputValue = "" + this.GetFormData();
            saveInfo.PrintContent = printData;
            saveInfo.Bunho = patientBox1.BunHo;// Done
            saveInfo.HospCode = UserInfo.HospCode;// Done
            saveInfo.CreateDate = currentDate.ToString();
            saveInfo.PrintDatetime = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            if (_prescriptionDateVisible)
            {
                saveInfo.PrescriptionDate = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "prescription_date");    
            }
            
            saveInfo.SysId = null;//Server has data
            saveInfo.SysDate = null;//Server has data 
            saveInfo.UpdId = null;// Done
            saveInfo.UpdDate = null;// Done
            saveInfo.ActiveFlg = "1";// Done

            saveInfo.RowState = DataRowState.Modified.ToString();
            args.Items.Add(saveInfo);
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS4001U00SaveArgs>(args);
        }

        private void FillTemplateData(string jsonData)
        {
            string printDate = "";
            string staticData = SerializeObject(new PatientData(patientBox1, _diseases, hospitalInfo, UserInfo.UserID, UserInfo.UserName, printDate));
            if (string.IsNullOrEmpty(jsonData))
            {
                jsonData = "{}";
            }

            if (string.IsNullOrEmpty(staticData)) staticData = "{}";

            //SetJsBuffer(webKitBrowser1, jsonData, "");
            //SetJsBuffer(webKitBrowser1, staticData, "-static");
            //SetJsBuffer(webKitBrowser1, _userData, "-user");
            //webKitBrowser1.Document.InvokeScriptMethod("bindTemplateData", new object[] { });

            SetJsBuffer(webView1, jsonData, "");
            SetJsBuffer(webView1, staticData, "-static");
            if (string.IsNullOrEmpty(_userData)) _userData = "{\"make-date1\":\"\"}";
            SetJsBuffer(webView1, _userData, "-user");

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

                //JSFunction func = (JSFunction)webView1.EvalScript("bindTemplateData", false);
                //func.Invoke(webView1.GetDOMWindow(), new object[] { });
                ExecuteScript(webView1, "bindTemplateData();");
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }
        }

        //public static void SetJsBuffer(WebKitBrowser webKitBrowser, string serializedData, string suffix)
        //{
        //    string id = "cs-js-buffer" + suffix;

        //    Element elem = null;
        //    try
        //    {
        //        elem = webKitBrowser.Document.GetElementById(id);
        //    }
        //    catch (Exception) { }

        //    if (elem == null)
        //    {
        //        elem = webKitBrowser.Document.CreateElement("div");
        //        elem.SetAttribute("id", id);
        //        elem.SetAttribute("style", "display:none");
        //        webKitBrowser.Document.GetElementsByTagName("body")[0].AppendChild(elem);
        //    }

        //    elem.TextContent = serializedData;
        //}

        private void OCS4001U00_Closing(object sender, CancelEventArgs e)
        {
            //webKitBrowser1.Dispose();
        }

        private void btnList_ButtonClick_1(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    SaveData();
                    break;
                case FunctionType.Print:
                    string printTemplate = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "print_content");
                    printTemplate = string.IsNullOrEmpty(printTemplate) ? defaultPrintTemplate : printTemplate;

                    string curDir = Application.StartupPath.Replace("\\", @"/");
                    string templateFile = String.Format("file:///{0}/OCSO/{1}_{3}_{2}", curDir, patientBox1.BunHo, _templateFile, "Print");
                    SaveFileHtml(templateFile, printTemplate);
                    Thread.Sleep(1000);

                    //string dynamicDt = "" + webKitBrowser1.Document.InvokeScriptMethod("getFormData", new object[] { });
                    string dynamicDt = "" + this.GetFormData();
                    string staticData = SerializeObject(new PatientData(patientBox1, _diseases, hospitalInfo, UserInfo.UserID, UserInfo.UserName, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")));
                    PrintForm frmPrint = new PrintForm(templateFile, staticData, dynamicDt, SavePrintData);
                    frmPrint.ShowDialog();
                    break;
            }
        }

        private void xDatePickerPrescriptionDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            UsePrescriptionDate();
        }

        private void UsePrescriptionDate()
        {

            xEditGrid1.SetItemValue(xEditGrid1.CurrentRowNumber, "prescription_date", xDatePickerPrescriptionDate.GetDataValue());
            OCS4001U00Args args = new OCS4001U00Args();
            args.BunhoCode = patientBox1.BunHo;
            args.HospCode = UserInfo.HospCode;
            args.TemplateId = _formCode;
            args.OrderDate = xDatePickerPrescriptionDate.GetDataValue();
            args.PrescriptionDate = xDatePickerPrescriptionDate.GetDataValue();
            OCS4001U00Result respone = CloudService.Instance.Submit<OCS4001U00Result, OCS4001U00Args>(args);

            string prescriptionText = "";
            string delimited = "";
            _userData = "";
            foreach (OCS4001U00PrescriptionInfo prescription in respone.Prescriptions)
            {
                prescriptionText += delimited + prescription.HangmongName + "-" + prescription.BogyongName;
                delimited = "   ";
            }

            _userData = "{\"current-situation\":\"" + prescriptionText + "\"}";

            UpdateTemplateData();
        }

        private void UpdateTemplateData()
        {
            //apply new data
            dynamicData = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_value");

            string currentData = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "create_date");
            if (string.IsNullOrEmpty(currentData)) return;
            
            string template = xEditGrid1.GetItemString(xEditGrid1.CurrentRowNumber, "input_content");
            if (string.IsNullOrEmpty(template)) return;

            ShowTemplateForm(template);
        }

        #region Using EOWebBrowser control

        //
        // Replace WebkitBrowser to EOWebBrowser to implement https://sofiamedix.atlassian.net/browse/MED-15366
        //

        private string GetFormData()
        {
            string result = string.Empty;

            try
            {
                if (webView1.CanEvalScript)
                {
                    //ScriptCall sc = webView1.QueueScriptCall("getFormData();");
                    //sc.WaitOne();

                    //if (sc.IsDone())
                    //{
                    //    result = sc.Result.ToString();
                    //}

                    result = ExecuteScript(webView1, "getFormData();").ToString();
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }

            return result;
        }

        void webView1_JSExtInvoke(object sender, JSExtInvokeArgs e)
        {

        }

        void webView1_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Task.IsDone())
            {
                //FillTemplateData(dynamicData);
            }
            else
            {
                // Wait for 2 seconds
                e.Task.WaitOne(2000);
            }

            FillTemplateData(dynamicData);
            webView1.StopLoad();
        }

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
                string script = @"  var iDiv = document.createElement('div');";
                script +=       @"  iDiv.id = '" + id + "';";
                script +=       @"  iDiv.innerHTML = '" + serializedData + "';";
                script +=       @"  iDiv.setAttribute('style', 'display: none;');";
                script +=       @"  document.getElementsByTagName('body')[0].appendChild(iDiv);";

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

        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void Runtime_Exception(object sender, EO.Base.ExceptionEventArgs e)
        {
            Service.WriteLog("EO Runtime error. Message: " + e.ErrorException.Message);
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