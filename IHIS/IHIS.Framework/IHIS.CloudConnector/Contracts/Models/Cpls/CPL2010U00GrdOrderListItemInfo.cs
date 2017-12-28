using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00GrdOrderListItemInfo
    {
        private String _orderDate;
        private String _orderTime;
        private String _gwaName;
        private String _inOutGubun;
        private String _doctorName;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _afterActYn;
        private String _bunho;
        private String _gwa;
        private String _gubun;
        private String _doctor;
        private String _reserDate;
        private String _jubsuja;
        private String _jubsujaName;
        private String _groupSer;
        private String _key;
        private String _ifDataSendYn;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String OrderTime
        {
            get { return this._orderTime; }
            set { this._orderTime = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String AfterActYn
        {
            get { return this._afterActYn; }
            set { this._afterActYn = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String Jubsuja
        {
            get { return this._jubsuja; }
            set { this._jubsuja = value; }
        }

        public String JubsujaName
        {
            get { return this._jubsujaName; }
            set { this._jubsujaName = value; }
        }

        public String GroupSer
        {
            get { return this._groupSer; }
            set { this._groupSer = value; }
        }

        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public String IfDataSendYn
        {
            get { return this._ifDataSendYn; }
            set { this._ifDataSendYn = value; }
        }

        public CPL2010U00GrdOrderListItemInfo() { }

        public CPL2010U00GrdOrderListItemInfo(String orderDate, String orderTime, String gwaName, String inOutGubun, String doctorName, String jubsuDate, String jubsuTime, String afterActYn, String bunho, String gwa, String gubun, String doctor, String reserDate, String jubsuja, String jubsujaName, String groupSer, String key, String ifDataSendYn)
        {
            this._orderDate = orderDate;
            this._orderTime = orderTime;
            this._gwaName = gwaName;
            this._inOutGubun = inOutGubun;
            this._doctorName = doctorName;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._afterActYn = afterActYn;
            this._bunho = bunho;
            this._gwa = gwa;
            this._gubun = gubun;
            this._doctor = doctor;
            this._reserDate = reserDate;
            this._jubsuja = jubsuja;
            this._jubsujaName = jubsujaName;
            this._groupSer = groupSer;
            this._key = key;
            this._ifDataSendYn = ifDataSendYn;
        }

    }
}