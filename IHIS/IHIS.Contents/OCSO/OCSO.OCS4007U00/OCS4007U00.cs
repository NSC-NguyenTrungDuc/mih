using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class OCS4007U00 : IHIS.OCSO.OCS4000U00
    {
        public OCS4007U00()
        {
            InitializeComponent();
            FormCode = "OCS4007U00";
            FormName = "OCS4007U00";
            TemplateFile = "OCS4007U00.html";
        }
    }
}