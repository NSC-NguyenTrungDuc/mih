using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.OCSO.Properties;
namespace IHIS.OCSO
{
    public partial class PatientProfileSetting : Form
    {
        EMRCacheManager _emrCacheManager;
        private OCS2015U00 _mainScreen;
        public PatientProfileSetting(OCS2015U00 mainScreen)
        {
            InitializeComponent();
            InitSettingData();
            this._mainScreen = mainScreen;
        }

        private void InitSettingData()
        {
            this._emrCacheManager = new EMRCacheManager();
            UpdateSettingData();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string data = GetSettingData();
            string patientSetingKey = this._emrCacheManager.PatientSetingKey + this._emrCacheManager.UserName;
            this._emrCacheManager.Update(patientSetingKey, data);
            _mainScreen.UpDatePatientSetting(data);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetSettingData()
        {
            string lbNameStr = string.Empty;
            foreach (Control ctrl in this.pnlPatientInfoSetting.Controls)
            {
                if (ctrl is CheckBox && ((CheckBox)ctrl).Checked)
                    lbNameStr += ((CheckBox)ctrl).Name.ToString() + ",";
            }
            return (lbNameStr.Length > 0) ? lbNameStr.Substring(0, lbNameStr.Length - 1) : string.Empty;
        }

        private void UpdateSettingData()
        {
            string patientSetingKey = this._emrCacheManager.PatientSetingKey + this._emrCacheManager.UserName;
            string data = this._emrCacheManager.Get(patientSetingKey);
            if (!string.IsNullOrEmpty(data))
            {
                string[] dataArr = data.Split(new char[] { ',' });
                if (dataArr.Length <= 0) return;
                for (int i = 0; i < dataArr.Length; i++)
                {
                    foreach (Control ctrl in this.pnlPatientInfoSetting.Controls)
                    {
                        if (ctrl is CheckBox && ((CheckBox)ctrl).Name.ToString().Trim() == dataArr[i])
                            ((CheckBox)ctrl).Checked = true;
                    }
                }
            }
            else
            {
                if (this._emrCacheManager.IsFirstSetup())
                {
                    foreach (Control ctrl in this.pnlPatientInfoSetting.Controls)
                    {
                        if (ctrl is CheckBox)
                            ((CheckBox)ctrl).Checked = true;
                    }
                }
            }
        }
    }
}
