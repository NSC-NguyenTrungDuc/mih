using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
    public partial class BedLockForm : XForm
    {
        public BedLockForm()
        {
            InitializeComponent();
            this.dbxTitle.SetDataValue("未登録患者のための病床ロック画面です");
            this.dtpIpwonDate.SetDataValue(EnvironInfo.GetSysDate());
        }

        private string mBedLockText = "";
        public string BedLockText
        {
            get
            {
                return mBedLockText;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.mBedLockText = "";
            this.Close();

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (rbxReser.Checked == true)
            {
                if (this.txtSuname.GetDataValue() == "")
                {
                    this.txtSuname.Focus();
                    return;
                }

                if (this.dtpIpwonDate.GetDataValue() == "")
                {
                    this.dtpIpwonDate.Focus();
                    return;
                }

                this.mBedLockText = "【病床ロック情報】\r\n"
                                  + "患者名：" + this.txtSuname.GetDataValue() + "\r\n"
                                  + "入院予定日：" + this.dtpIpwonDate.GetDataValue() + "\r\n"
                                  + "備　考：" + txtBigo.GetDataValue();
            }
            else
            {
                this.mBedLockText = "【病床ロック情報】\r\n"
                                  + "理　由：未使用 \r\n"
                                  + "備　考：" + txtBigo.GetDataValue();
            }
            this.Close();

        }

        private void rbxReser_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxReser.Checked == true)
            {
                this.lblSuname.Enabled = true;
                this.lblIpwonDate.Enabled = true;
                this.txtSuname.Enabled = true;
                this.dtpIpwonDate.Enabled = true;
            }
            else
            {
                this.lblSuname.Enabled = false;
                this.lblIpwonDate.Enabled = false;
                this.txtSuname.Enabled = false;
                this.dtpIpwonDate.Enabled = false;
            }
        }
    }
}