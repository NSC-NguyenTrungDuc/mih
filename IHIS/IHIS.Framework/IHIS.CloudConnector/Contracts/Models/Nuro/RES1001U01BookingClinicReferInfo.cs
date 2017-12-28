using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class RES1001U01BookingClinicReferInfo
    {
        private String _patientId;
        private String _patientName;
        private String _birthday;
        private String _sex;
        private String _bookingClinicId;
        private String _bookingClinicName;
        private String _tel;
        private String _bookingDate;
        private String _bookingTime;
        private String _linkPatientFlg;
        private String _outHospCode;
        private String _linkEmrInformation;

        public String PatientId
        {
            get { return this._patientId; }
            set { this._patientId = value; }
        }

        public String PatientName
        {
            get { return this._patientName; }
            set { this._patientName = value; }
        }

        public String Birthday
        {
            get { return this._birthday; }
            set { this._birthday = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String BookingClinicId
        {
            get { return this._bookingClinicId; }
            set { this._bookingClinicId = value; }
        }

        public String BookingClinicName
        {
            get { return this._bookingClinicName; }
            set { this._bookingClinicName = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String BookingDate
        {
            get { return this._bookingDate; }
            set { this._bookingDate = value; }
        }

        public String BookingTime
        {
            get { return this._bookingTime; }
            set { this._bookingTime = value; }
        }

        public String LinkPatientFlg
        {
            get { return this._linkPatientFlg; }
            set { this._linkPatientFlg = value; }
        }

        public String OutHospCode
        {
            get { return this._outHospCode; }
            set { this._outHospCode = value; }
        }

        public String LinkEmrInformation
        {
            get { return this._linkEmrInformation; }
            set { this._linkEmrInformation = value; }
        }

        public RES1001U01BookingClinicReferInfo() { }

        public RES1001U01BookingClinicReferInfo(String patientId, String patientName, String birthday, String sex, String bookingClinicId, String bookingClinicName, String tel, String bookingDate, String bookingTime, String linkPatientFlg, String outHospCode, String linkEmrInformation)
        {
            this._patientId = patientId;
            this._patientName = patientName;
            this._birthday = birthday;
            this._sex = sex;
            this._bookingClinicId = bookingClinicId;
            this._bookingClinicName = bookingClinicName;
            this._tel = tel;
            this._bookingDate = bookingDate;
            this._bookingTime = bookingTime;
            this._linkPatientFlg = linkPatientFlg;
            this._outHospCode = outHospCode;
            this._linkEmrInformation = linkEmrInformation;
        }

    }
}