using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001R00PrintBookingResult : AbstractContractResult
    {
        private String _yoyangNameLink;
        private String _suname;
        private String _birth;
        private String _age;
        private String _yoyangName;
        private String _bunho;
        private String _bunhoLink;
        private String _gwaName;
        private String _doctorName;
        private String _naewonDate;
        private String _jubsuTime;
        private String _address;
        private String _tel;

        public String YoyangNameLink
        {
            get { return this._yoyangNameLink; }
            set { this._yoyangNameLink = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
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

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public RES1001R00PrintBookingResult() { }

    }
}