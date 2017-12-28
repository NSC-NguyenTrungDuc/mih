using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SchsSCH0201U99GrdOrderListInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _jundalTable;
        private String _jundalPart;
        private String _jundalPartName;
        private String _pksch0201;
        private String _bunho;
        private String _suname;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _orderDate;
        private String _emergency;
        private String _reserDate;
        private String _reserTime;
        private String _orderRemark;
        private String _reserYn;
        private String _pkout1001;
        private String _groupSer;
        private String _outHospCode;

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

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String JundalPartName
        {
            get { return this._jundalPartName; }
            set { this._jundalPartName = value; }
        }

        public String Pksch0201
        {
            get { return this._pksch0201; }
            set { this._pksch0201 = value; }
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

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String OrderRemark
        {
            get { return this._orderRemark; }
            set { this._orderRemark = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String GroupSer
        {
            get { return this._groupSer; }
            set { this._groupSer = value; }
        }

        public String OutHospCode
        {
            get { return this._outHospCode; }
            set { this._outHospCode = value; }
        }

        public SchsSCH0201U99GrdOrderListInfo() { }

        public SchsSCH0201U99GrdOrderListInfo(String hangmogCode, String hangmogName, String jundalTable, String jundalPart, String jundalPartName, String pksch0201, String bunho, String suname, String gwa, String gwaName, String doctor, String doctorName, String orderDate, String emergency, String reserDate, String reserTime, String orderRemark, String reserYn, String pkout1001, String groupSer, String outHospCode)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._jundalPartName = jundalPartName;
            this._pksch0201 = pksch0201;
            this._bunho = bunho;
            this._suname = suname;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._orderDate = orderDate;
            this._emergency = emergency;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._orderRemark = orderRemark;
            this._reserYn = reserYn;
            this._pkout1001 = pkout1001;
            this._groupSer = groupSer;
            this._outHospCode = outHospCode;
        }

    }
}