using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class OCS4010U00 : IHIS.OCSO.OCS4000U00
    {
        public OCS4010U00()
        {
            InitializeComponent();
            FormCode = "OCS4010U00";
            FormName = "OCS4010U00";
            TemplateFile = "OCS4010U00.html";
            PrescriptionDateVisible = true;
        }
    }
}