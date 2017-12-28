using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroRES1001U00DoctorReserListItemInfo
    {
        private String _comingDate;
        private String _examPreTime;
        private String _departmentName;
        private String _doctorName;
        private String _pkout1001;
        private String _comingStatus;
        private String _patientCode;
        private String _departmentCode;
        private String _doctorCode;
        private String _examIraiStatus;
        private String _iraiDate;
        private String _resUser;
        private String _reserComment;
        private String _reserType;
        private String _clinicName;

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
        }

        public String ExamPreTime
        {
            get { return this._examPreTime; }
            set { this._examPreTime = value; }
        }

        public String DepartmentName
        {
            get { return this._departmentName; }
            set { this._departmentName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ComingStatus
        {
            get { return this._comingStatus; }
            set { this._comingStatus = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String ExamIraiStatus
        {
            get { return this._examIraiStatus; }
            set { this._examIraiStatus = value; }
        }

        public String IraiDate
        {
            get { return this._iraiDate; }
            set { this._iraiDate = value; }
        }

        public String ResUser
        {
            get { return this._resUser; }
            set { this._resUser = value; }
        }

        public String ReserComment
        {
            get { return this._reserComment; }
            set { this._reserComment = value; }
        }

        public String ReserType
        {
            get { return this._reserType; }
            set { this._reserType = value; }
        }

        public String ClinicName
        {
            get { return this._clinicName; }
            set { this._clinicName = value; }
        }

        public NuroRES1001U00DoctorReserListItemInfo() { }

        public NuroRES1001U00DoctorReserListItemInfo(String comingDate, String examPreTime, String departmentName, String doctorName, String pkout1001, String comingStatus, String patientCode, String departmentCode, String doctorCode, String examIraiStatus, String iraiDate, String resUser, String reserComment, String reserType, String clinicName)
        {
            this._comingDate = comingDate;
            this._examPreTime = examPreTime;
            this._departmentName = departmentName;
            this._doctorName = doctorName;
            this._pkout1001 = pkout1001;
            this._comingStatus = comingStatus;
            this._patientCode = patientCode;
            this._departmentCode = departmentCode;
            this._doctorCode = doctorCode;
            this._examIraiStatus = examIraiStatus;
            this._iraiDate = iraiDate;
            this._resUser = resUser;
            this._reserComment = reserComment;
            this._reserType = reserType;
            this._clinicName = clinicName;
        }

    }
}