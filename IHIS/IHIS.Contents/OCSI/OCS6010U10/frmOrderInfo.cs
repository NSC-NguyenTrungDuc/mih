using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class frmOrderInfo : System.Windows.Forms.Form
    {
        public frmOrderInfo()
        {
            InitializeComponent();
        }


        #region [Instance Variable]
        //Message처리
        private Hashtable htOrderInfo;
        private string aText;

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
        #endregion


        #region [properties]

        public Hashtable HTORDERINFO
        {
            //get
            //{
            //    return htOrderInfo;
            //}
            set
            {
                htOrderInfo = value;
            }
        }

        public string DBX_TEXT
        {
            set
            {
                aText = value;
            }
        }

        #endregion

        private void frmOrderInfo_Load(object sender, EventArgs e)
        {
            dbxMain.SetDataValue(aText);

            //if (frmOrderInfo.MousePosition.IsEmpty) this.Opacity = 1;
            //else this.Opacity = 0.50;
        }

        private void frmOrderInfo_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 0.95;
        }

        private void frmOrderInfo_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.70;
        }
    }
}