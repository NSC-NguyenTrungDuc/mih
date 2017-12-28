using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04GrdInpInfo
    {
        private String _orderDate;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _doctorName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _ptFlag;
        private String _otFlag;
        private String _stFlag;
        private String _buFlag;
        private String _ocsFlag;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

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

        public String PtFlag
        {
            get { return this._ptFlag; }
            set { this._ptFlag = value; }
        }

        public String OtFlag
        {
            get { return this._otFlag; }
            set { this._otFlag = value; }
        }

        public String StFlag
        {
            get { return this._stFlag; }
            set { this._stFlag = value; }
        }

        public String BuFlag
        {
            get { return this._buFlag; }
            set { this._buFlag = value; }
        }

        public String OcsFlag
        {
            get { return this._ocsFlag; }
            set { this._ocsFlag = value; }
        }

        public PHY2001U04GrdInpInfo() { }

        public PHY2001U04GrdInpInfo(String orderDate, String bunho, String suname, String suname2, String doctorName, String hangmogCode, String hangmogName, String ptFlag, String otFlag, String stFlag, String buFlag, String ocsFlag)
        {
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._doctorName = doctorName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._ptFlag = ptFlag;
            this._otFlag = otFlag;
            this._stFlag = stFlag;
            this._buFlag = buFlag;
            this._ocsFlag = ocsFlag;
        }

    }
}