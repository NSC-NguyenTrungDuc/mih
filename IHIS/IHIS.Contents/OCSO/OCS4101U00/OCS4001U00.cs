using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class OCS4001U00 : IHIS.OCSO.OCS4000U00
    {
        public OCS4001U00()
        {
            InitializeComponent();
            FormCode = "OCS4001U00";
            FormName = "OCS4001U00";
            TemplateFile = "OCS4001U00.html";
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Height = rc.Height - 150;
        }
    }
}