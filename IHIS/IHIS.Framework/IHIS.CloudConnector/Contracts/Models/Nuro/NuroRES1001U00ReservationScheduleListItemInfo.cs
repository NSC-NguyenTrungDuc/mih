using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroRES1001U00ReservationScheduleListItemInfo
    {
        private String _examPreTime;
        private String _patientCode;
        private String _patientName1;
        private String _patientName2;
        private String _examStatus;
        private String _reserDate;
        private String _pkout1001;
        private String _examPreDate;
        private String _departmentCode;
        private String _receptionNo;
        private String _type;
        private String _doctorCode;
        private String _resType;
        private String _resChanggu;
        private String _resInputType;
        private String _comingStatus;
        private String _newRow;
        private String _examState;

        public String ExamPreTime
        {
            get { return this._examPreTime; }
            set { this._examPreTime = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String PatientName1
        {
            get { return this._patientName1; }
            set { this._patientName1 = value; }
        }

        public String PatientName2
        {
            get { return this._patientName2; }
            set { this._patientName2 = value; }
        }

        public String ExamStatus
        {
            get { return this._examStatus; }
            set { this._examStatus = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ExamPreDate
        {
            get { return this._examPreDate; }
            set { this._examPreDate = value; }
        }

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String ReceptionNo
        {
            get { return this._receptionNo; }
            set { this._receptionNo = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String ResType
        {
            get { return this._resType; }
            set { this._resType = value; }
        }

        public String ResChanggu
        {
            get { return this._resChanggu; }
            set { this._resChanggu = value; }
        }

        public String ResInputType
        {
            get { return this._resInputType; }
            set { this._resInputType = value; }
        }

        public String ComingStatus
        {
            get { return this._comingStatus; }
            set { this._comingStatus = value; }
        }

        public String NewRow
        {
            get { return this._newRow; }
            set { this._newRow = value; }
        }

        public String ExamState
        {
            get { return this._examState; }
            set { this._examState = value; }
        }

        public NuroRES1001U00ReservationScheduleListItemInfo() { }

        public NuroRES1001U00ReservationScheduleListItemInfo(String examPreTime, String patientCode, String patientName1, String patientName2, String examStatus, String reserDate, String pkout1001, String examPreDate, String departmentCode, String receptionNo, String type, String doctorCode, String resType, String resChanggu, String resInputType, String comingStatus, String newRow, String examState)
        {
            this._examPreTime = examPreTime;
            this._patientCode = patientCode;
            this._patientName1 = patientName1;
            this._patientName2 = patientName2;
            this._examStatus = examStatus;
            this._reserDate = reserDate;
            this._pkout1001 = pkout1001;
            this._examPreDate = examPreDate;
            this._departmentCode = departmentCode;
            this._receptionNo = receptionNo;
            this._type = type;
            this._doctorCode = doctorCode;
            this._resType = resType;
            this._resChanggu = resChanggu;
            this._resInputType = resInputType;
            this._comingStatus = comingStatus;
            this._newRow = newRow;
            this._examState = examState;
        }

    }
}