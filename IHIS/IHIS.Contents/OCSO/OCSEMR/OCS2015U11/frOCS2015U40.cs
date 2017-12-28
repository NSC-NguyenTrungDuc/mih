using EmrDocker;
using EmrDocker.Models;
using System;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class frOCS2015U40 : Form
    {
        private OCS2015U40 OCS2015U40;
        public frOCS2015U40(UcView ucView, string pkout1001)
        {
            InitializeComponent();
            this.OCS2015U40 = new IHIS.OCSO.OCS2015U40(ucView, pkout1001);
            this.OCS2015U40.Location = new System.Drawing.Point(0, 0);
            this.OCS2015U40.Name = "OCS2015U40";
            this.Controls.Add(this.OCS2015U40);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
