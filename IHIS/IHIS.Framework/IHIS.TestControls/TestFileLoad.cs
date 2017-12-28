using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.TestControls
{
    public partial class TestFileLoad : Form
    {
        private String CONST_CRLF = "\r\n";

        public TestFileLoad()
        {
            InitializeComponent();
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

    }
}