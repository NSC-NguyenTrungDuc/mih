using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class OCS4004U00 : IHIS.OCSO.OCS4000U00
    {
        public OCS4004U00()
        {
            InitializeComponent();
            FormCode = "OCS4004U00";
            FormName = "OCS4004U00";
            TemplateFile = "OCS4004U00.html";
        }
    }
}