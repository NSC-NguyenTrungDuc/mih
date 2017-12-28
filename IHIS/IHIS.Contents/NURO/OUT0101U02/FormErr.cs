using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IHIS.NURO
{
    public partial class FormErr : Form
    {
        private string _err = string.Empty;

        public FormErr()
        {
            InitializeComponent();
        }

        public FormErr(string err)
        {
            InitializeComponent();

            this._err = err;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportErr_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(fbd.SelectedPath, "error.txt");
                    File.WriteAllText(path, this._err, Encoding.UTF8);
                }
            }

            this.Close();
        }
    }
}