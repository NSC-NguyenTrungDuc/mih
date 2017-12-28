using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    public class CPL0000Q00GrdOrderListInfo
    {
        private String _orderDate;
        private String _inOutGubun;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _specimenSer;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
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

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public CPL0000Q00GrdOrderListInfo() { }

        public CPL0000Q00GrdOrderListInfo(String orderDate, String inOutGubun, String gwa, String gwaName, String doctor, String doctorName, String specimenSer)
        {
            this._orderDate = orderDate;
            this._inOutGubun = inOutGubun;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._specimenSer = specimenSer;
        }

    }
}