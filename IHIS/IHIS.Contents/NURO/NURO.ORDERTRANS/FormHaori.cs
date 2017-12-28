using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.NURO
{
    public partial class FormHaori : Form
    {
        private string _url = "";

        public FormHaori()
        {
            this.AddLicense();

            InitializeComponent();
            this._url = "http://10.1.40.107:4567/receipt/patients/new";
        }

        public FormHaori(string url)
        {
            this.AddLicense();

            InitializeComponent();
            this._url = url;
        }

        private void AddLicense()
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
        }

        private void FormHaori_Load(object sender, EventArgs e)
        {
            this.webView1.Url = this._url;
        }
    }
}