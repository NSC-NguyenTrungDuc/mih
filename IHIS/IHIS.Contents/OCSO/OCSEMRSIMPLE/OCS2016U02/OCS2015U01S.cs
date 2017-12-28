using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public partial class OCS2015U01S : UserControl
    {
        private OCS2016U02 _mainScreen;
        public OCS2015U01S(OCS2016U02 mainScreen)
        {
            InitializeComponent();
            this._mainScreen = mainScreen;
            this.fbxBunho.MaxLength = EnvironInfo.BunhoLength;
        }
        private void btnOpenOutSang_Click(object sender, EventArgs e)
        {
            if (_mainScreen.MSelectedPatientInfo != null && _mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                _mainScreen.OpenScreen_OUTSANGU00(_mainScreen.IO_Gubun, _mainScreen.FbxBunho.GetDataValue(), _mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
                // 환자상병조회
                _mainScreen.LoadOutSang(_mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                , _mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                , _mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

            }

        }

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            _mainScreen.OpenScreen_OUT0101Q01();
        }
    }
}
