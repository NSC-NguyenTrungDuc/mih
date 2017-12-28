using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetOrderReportInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _suryang;
        private String _dv;
        private String _nalsu;
        private String _bogyongName;
        private String _codeName;
        private String _dvQuantity;

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

        public String Dv
        {
            get { return this._dv; }
            set { this._dv = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String BogyongName
        {
            get { return this._bogyongName; }
            set { this._bogyongName = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String DvQuantity
        {
            get { return this._dvQuantity; }
            set { this._dvQuantity = value; }
        }

        public OCS2015U00GetOrderReportInfo() { }

        public OCS2015U00GetOrderReportInfo(String hangmogCode, String hangmogName, String suryang, String dv, String nalsu, String bogyongName, String codeName, String dvQuantity)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._dv = dv;
            this._nalsu = nalsu;
            this._bogyongName = bogyongName;
            this._codeName = codeName;
            this._dvQuantity = dvQuantity;
        }

    }
}