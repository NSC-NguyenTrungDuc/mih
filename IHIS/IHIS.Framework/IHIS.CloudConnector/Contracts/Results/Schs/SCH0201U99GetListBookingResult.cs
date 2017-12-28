using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U99GetListBookingResult : AbstractContractResult
    {
        private String _yoyangNameLink;
        private String _suname;
        private String _birth;
        private String _age;
        private String _bunho;
        private String _yoyangName;
        private String _gwaName;
        private String _doctorName;
        private String _bunhoLink;
        private String _addressLink;
        private String _telLink;
        private List<SCH0201U99BookingInfo> _bookingList = new List<SCH0201U99BookingInfo>();

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

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
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

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String AddressLink
        {
            get { return this._addressLink; }
            set { this._addressLink = value; }
        }

        public String TelLink
        {
            get { return this._telLink; }
            set { this._telLink = value; }
        }

        public List<SCH0201U99BookingInfo> BookingList
        {
            get { return this._bookingList; }
            set { this._bookingList = value; }
        }

        public SCH0201U99GetListBookingResult() { }

    }
}