using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    public class FormSelectHospCodeResult : AbstractContractResult
    {
        private String _hospCode;
        private String _hospName;
        private String _vpnYn;
        private String _certExpired;
        private String _language;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String VpnYn
        {
            get { return this._vpnYn; }
            set { this._vpnYn = value; }
        }

        public String CertExpired
        {
            get { return this._certExpired; }
            set { this._certExpired = value; }
        }

        public String Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public FormSelectHospCodeResult() { }

    }
}