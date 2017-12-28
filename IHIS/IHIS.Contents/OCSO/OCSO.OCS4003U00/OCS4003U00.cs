using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class OCS4003U00 : IHIS.OCSO.OCS4000U00
    {
        public OCS4003U00()
        {
            PrescriptionDateVisible = true;

            InitializeComponent();
            FormCode = "OCS4003U00";
            FormName = "OCS4003U00";
            TemplateFile = "OCS4003U00.html";

        }
    }
}