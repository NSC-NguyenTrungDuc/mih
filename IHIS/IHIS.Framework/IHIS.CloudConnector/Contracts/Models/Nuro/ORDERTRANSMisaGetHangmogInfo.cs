using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSMisaGetHangmogInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _suryang;
        private String _nalsu;
        private String _dv;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String Dv
        {
            get { return this._dv; }
            set { this._dv = value; }
        }

        public ORDERTRANSMisaGetHangmogInfo() { }

        public ORDERTRANSMisaGetHangmogInfo(String hangmogCode, String hangmogName, String suryang, String nalsu, String dv)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._nalsu = nalsu;
            this._dv = dv;
        }

    }
}