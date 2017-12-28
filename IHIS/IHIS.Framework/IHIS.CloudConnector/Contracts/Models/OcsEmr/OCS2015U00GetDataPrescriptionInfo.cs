using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetDataPrescriptionInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _suryang;
        private String _dv;
        private String _nalsu;
        private String _bogyongName;
        private String _codeName;
        private String _dvQuantity;
        private String _wonyoiOrderYn;
        private String _orderDanui;
        private String _serialV;
        private String _donbok;
        private String _groupSer;
        private String _dvTime;

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

        public String WonyoiOrderYn
        {
            get { return this._wonyoiOrderYn; }
            set { this._wonyoiOrderYn = value; }
        }

        public String OrderDanui
        {
            get { return this._orderDanui; }
            set { this._orderDanui = value; }
        }

        public String SerialV
        {
            get { return this._serialV; }
            set { this._serialV = value; }
        }

        public String Donbok
        {
            get { return this._donbok; }
            set { this._donbok = value; }
        }

        public String GroupSer
        {
            get { return this._groupSer; }
            set { this._groupSer = value; }
        }

        public String DvTime
        {
            get { return this._dvTime; }
            set { this._dvTime = value; }
        }

        public OCS2015U00GetDataPrescriptionInfo() { }

        public OCS2015U00GetDataPrescriptionInfo(String hangmogCode, String hangmogName, String suryang, String dv, String nalsu, String bogyongName, String codeName, String dvQuantity, String wonyoiOrderYn, String orderDanui, String serialV, String donbok, String groupSer, String dvTime)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._dv = dv;
            this._nalsu = nalsu;
            this._bogyongName = bogyongName;
            this._codeName = codeName;
            this._dvQuantity = dvQuantity;
            this._wonyoiOrderYn = wonyoiOrderYn;
            this._orderDanui = orderDanui;
            this._serialV = serialV;
            this._donbok = donbok;
            this._groupSer = groupSer;
            this._dvTime = dvTime;
        }

    }
}