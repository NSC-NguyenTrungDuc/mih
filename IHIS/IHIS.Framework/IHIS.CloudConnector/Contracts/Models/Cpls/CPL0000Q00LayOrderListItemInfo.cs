using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    public class CPL0000Q00LayOrderListItemInfo
    {
        private String _orderDate;
        private String _gwa;
        private String _doctor;
        private String _gwaName;
        private String _doctorName;
        private String _inOutGubun;
        private String _specimenSer;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public CPL0000Q00LayOrderListItemInfo() { }

        public CPL0000Q00LayOrderListItemInfo(String orderDate, String gwa, String doctor, String gwaName, String doctorName, String inOutGubun, String specimenSer)
        {
            this._orderDate = orderDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._inOutGubun = inOutGubun;
            this._specimenSer = specimenSer;
        }

    }
}