using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class BookingInfo
    {
        private string _bunho = "";
        private string _wholeName = "";
        private string _wholeNameKana = "";
        private string _naewonDate = "";
        private string _naewonTime = "";
        private string _appointmentId = "";
        private string _gwa = "";
        private string _doctor = "";
        private string _medicalInfo = "";
        private string _appointmentInfo = "";
        private string _appointmentNote = "";

        public string Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public string WholeName
        {
            get { return this._wholeName; }
            set { this._wholeName = value; }
        }

        public string WholeNameKana
        {
            get { return this._wholeNameKana; }
            set { this._wholeNameKana = value; }
        }

        public string NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public string NaewonTime
        {
            get { return this._naewonTime; }
            set { this._naewonTime = value; }
        }

        public string AppointmentId
        {
            get { return _appointmentId; }
            set { this._appointmentId = value; }
        }

        public string Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public string Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public string MedicalInfo
        {
            get { return this._medicalInfo; }
            set { this._medicalInfo = value; }
        }

        public string AppointmentInfo
        {
            get { return this._appointmentInfo; }
            set { this._appointmentInfo = value; }
        }

        public string AppointmentNote
        {
            get { return this._appointmentNote; }
            set { this._appointmentNote = value; }
        }

        public BookingInfo()
        { }

        public BookingInfo
            (
                string bunho,
                string wholeName,
                string wholeNameKana,
                string naewonDate,
                string naewonTime,
                string appointmentId,
                string gwa,
                string doctor,
                string medicalInfo,
                string appointmentInfo,
                string appointmentNote
            )
        {
            this._bunho = bunho;
            this._wholeName = wholeName;
            this._wholeNameKana = wholeNameKana;
            this._naewonDate = naewonDate;
            this._naewonTime = naewonTime;
            this._appointmentId = appointmentId;
            this._gwa = gwa;
            this._doctor = doctor;
            this._medicalInfo = medicalInfo;
            this._appointmentInfo = appointmentInfo;
            this._appointmentNote = appointmentNote;
        }
    }
}
