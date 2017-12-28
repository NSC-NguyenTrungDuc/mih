using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00InsProviderInfo
    {
        private String _insProviderNo;
        private String _insCode;
        private String _number;
        private String _expireDate;
        private String _insInstitutionalName;
        private String _effectiveDate;
        private String _insName;
        private String _gubunName;
        private String _bonGaGubun;

        public String InsProviderNo
        {
            get { return this._insProviderNo; }
            set { this._insProviderNo = value; }
        }

        public String InsCode
        {
            get { return this._insCode; }
            set { this._insCode = value; }
        }

        public String Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        public String ExpireDate
        {
            get { return this._expireDate; }
            set { this._expireDate = value; }
        }

        public String InsInstitutionalName
        {
            get { return this._insInstitutionalName; }
            set { this._insInstitutionalName = value; }
        }

        public String EffectiveDate
        {
            get { return this._effectiveDate; }
            set { this._effectiveDate = value; }
        }

        public String InsName
        {
            get { return this._insName; }
            set { this._insName = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String BonGaGubun
        {
            get { return this._bonGaGubun; }
            set { this._bonGaGubun = value; }
        }

        public OCS2015U00InsProviderInfo() { }

        public OCS2015U00InsProviderInfo(String insProviderNo, String insCode, String number, String expireDate, String insInstitutionalName, String effectiveDate, String insName, String gubunName, String bonGaGubun)
        {
            this._insProviderNo = insProviderNo;
            this._insCode = insCode;
            this._number = number;
            this._expireDate = expireDate;
            this._insInstitutionalName = insInstitutionalName;
            this._effectiveDate = effectiveDate;
            this._insName = insName;
            this._gubunName = gubunName;
            this._bonGaGubun = bonGaGubun;
        }

    }
}