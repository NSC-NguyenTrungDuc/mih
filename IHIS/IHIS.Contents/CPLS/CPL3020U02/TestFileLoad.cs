using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CPLS.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.CPLS
{
    public partial class TestFileLoad : XForm
    {
        private String CONST_CRLF = "\r\n";
        // 
        private string _jangbiCode = "";

        public TestFileLoad()
        {
            InitializeComponent();

            // https://sofiamedix.atlassian.net/browse/MED-12765
            this.Text = Resources.TXT_TITLE;
        }

        public TestFileLoad(string jangbiCode)
        {
            InitializeComponent();

            // https://sofiamedix.atlassian.net/browse/MED-12765
            this.Text = Resources.TXT_TITLE;
            this._jangbiCode = jangbiCode;
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            String filePath = "";
            String fileName = "";

            GetSourceFilePath(ref filePath, ref fileName);

            ReadFile(filePath, fileName);
        }

        private bool GetSourceFilePath(ref string aFilePath, ref string aFileName)
        {
            this.openFileDialogUSB.Reset();

            aFilePath = "";
            aFileName = "";

            DialogResult dlgResult = this.openFileDialogUSB.ShowDialog();

            if (dlgResult != DialogResult.OK) return false;
            if (this.openFileDialogUSB.FileName.Length <= 0) return false;

            String[] filePathInfo = this.openFileDialogUSB.FileName.Split('\\');

            for (int i = 0; i < filePathInfo.Length; i++)
            {
                if (i == filePathInfo.Length - 1)
                {
                    aFileName = filePathInfo[i];
                }
                else
                {
                    aFilePath += filePathInfo[i] + @"\";
                }
            }

            return true;
        }

        private bool ReadFile(string aFilePath, string aFileName)
        {
            if (aFilePath == "" || aFileName == "")
                return true;

            StreamReader sr = new StreamReader(aFilePath + aFileName, Encoding.GetEncoding("Shift-JIS"));
            String line = "";
            //String defaultText = "データをロードしています。";
            //String[] data;
            //DataRow dtRow;
            int cnt = 0;
            //int errCnt = 0;
            //ArrayList errRow = new ArrayList();
            //String progressText = "";

            this.FileText.Text = "";

            //display_date();

            //this.FileTextGrid.Cols = 1;

            try
            {
                CplSanRituPtInfo cplSanRituPtInfo = null;
                Boolean blStart = false;
                String strStartTag = "";
                String strText = "";

                while ((line = sr.ReadLine()) != null)
                {
                    cnt++;

                    this.FileText.Text += line + CONST_CRLF;
                    //
                    strStartTag = line.Substring(0, 2);

                    if (blStart & strStartTag.Equals("O1"))
                    {
                        cplSanRituPtInfo = new CplSanRituPtInfo();

                        cplSanRituPtInfo.Parse("TestFileLoad", strText);

                        cplSanRituPtInfo.SetData("TestFileLoad");

                        blStart = false;
                        strText = "";
                    }
                    //
                    strText += line.PadLeft(128);
                    //
                    if (strStartTag.Equals("O1"))
                    {
                        blStart = true;
                    }
                }

                cplSanRituPtInfo = new CplSanRituPtInfo();

                cplSanRituPtInfo.Parse("TestFileLoad", strText);

                cplSanRituPtInfo.SetData("TestFileLoad");
            }
            finally
            {
                sr.Dispose();
            }

            return true;
       }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Process:
                    e.IsBaseCall = false;

                    // https://sofiamedix.atlassian.net/browse/MED-16234
                    string companyCode;
                    string contents = this.GetFileContent(out companyCode);
                    if (companyCode == "164" || companyCode == "99") // 04: ACT, 99: Read file error
                    {
                        this.FileText.Text = contents;
                        return;
                    }

                    String filePath = "";
                    String fileName = "";

                    GetSourceFilePath(ref filePath, ref fileName);

                    ReadFile(filePath, fileName);

                    break;
            }
        }

        #region 

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-16234
        /// </summary>
        /// <returns></returns>
        private string GetFileContent(out string companyCode)
        {
            companyCode = "";
            string contents = "";
            byte[] data = new byte[] { };

            CPL3020U02ImportFileResult res = CloudService.Instance.Submit<CPL3020U02ImportFileResult, CPL3020U02ImportFileArgs>(new CPL3020U02ImportFileArgs(this._jangbiCode));
            companyCode = res.Message;
            Service.WriteLog("File content: " + contents);
            Service.WriteLog("Company code: " + companyCode);

            if (res.ExecutionStatus == ExecutionStatus.Success && (res.Message != "99"))
            {
                if (res.Data != null)
                {
                    data = res.Data;
                }
            }
            else
            {
                // Read file error
                XMessageBox.Show(Resources.MSG_READ_FILE_ERROR, Resources.XMessageBox5_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            if (NetInfo.Language == LangMode.Jr)
            {
                // Shift-jis
                contents = Encoding.GetEncoding(932).GetString(data);
            }
            else
            {
                // UTF-8
                contents = Encoding.UTF8.GetString(data);
            }

            return contents;
        }

        #endregion
    }
}