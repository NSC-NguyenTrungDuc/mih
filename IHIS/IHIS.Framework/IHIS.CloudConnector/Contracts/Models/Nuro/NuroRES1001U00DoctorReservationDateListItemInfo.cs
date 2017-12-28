using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroRES1001U00DoctorReservationDateListItemInfo
    {
        private String _doctorCode;
        private String _date;
        private String _resDate;
        private String _resFlag;
        private String _resInwon;
        private String _resOutwon;

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public String ResDate
        {
            get { return this._resDate; }
            set { this._resDate = value; }
        }

        public String ResFlag
        {
            get { return this._resFlag; }
            set { this._resFlag = value; }
        }

        public String ResInwon
        {
            get { return this._resInwon; }
            set { this._resInwon = value; }
        }

        public String ResOutwon
        {
            get { return this._resOutwon; }
            set { this._resOutwon = value; }
        }

        public NuroRES1001U00DoctorReservationDateListItemInfo() { }

        public NuroRES1001U00DoctorReservationDateListItemInfo(String doctorCode, String date, String resDate, String resFlag, String resInwon, String resOutwon)
        {
            this._doctorCode = doctorCode;
            this._date = date;
            this._resDate = resDate;
            this._resFlag = resFlag;
            this._resInwon = resInwon;
            this._resOutwon = resOutwon;
        }

    }
}