using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroRES1001U00ReseredDataListItemInfo
    {
        private String _receptionTime;
        private String _patientCode;
        private String _patientName1;
        private String _patientName2;
        private String _examStatus;
        private String _updDate;
        private String _pkout1001;
        private String _comingDate;
        private String _departmentCode;
        private String _receptionNo;
        private String _type;
        private String _doctorCode;
        private String _resType;
        private String _resUserName;
        private String _resInputType;
        private String _comingStatus;
        private String _newRow;
        private String _examState;
        private String _examIraiState;
        private String _resUser;
        private String _ipwonStatus;
        private String _reserComments;
        private String _reserType;
        private String _clinicName;

        public String ReceptionTime
        {
            get { return this._receptionTime; }
            set { this._receptionTime = value; }
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

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
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

        public String ResUserName
        {
            get { return this._resUserName; }
            set { this._resUserName = value; }
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

        public String ExamIraiState
        {
            get { return this._examIraiState; }
            set { this._examIraiState = value; }
        }

        public String ResUser
        {
            get { return this._resUser; }
            set { this._resUser = value; }
        }

        public String IpwonStatus
        {
            get { return this._ipwonStatus; }
            set { this._ipwonStatus = value; }
        }

        public String ReserComments
        {
            get { return this._reserComments; }
            set { this._reserComments = value; }
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

        public NuroRES1001U00ReseredDataListItemInfo() { }

        public NuroRES1001U00ReseredDataListItemInfo(String receptionTime, String patientCode, String patientName1, String patientName2, String examStatus, String updDate, String pkout1001, String comingDate, String departmentCode, String receptionNo, String type, String doctorCode, String resType, String resUserName, String resInputType, String comingStatus, String newRow, String examState, String examIraiState, String resUser, String ipwonStatus, String reserComments, String reserType, String clinicName)
        {
            this._receptionTime = receptionTime;
            this._patientCode = patientCode;
            this._patientName1 = patientName1;
            this._patientName2 = patientName2;
            this._examStatus = examStatus;
            this._updDate = updDate;
            this._pkout1001 = pkout1001;
            this._comingDate = comingDate;
            this._departmentCode = departmentCode;
            this._receptionNo = receptionNo;
            this._type = type;
            this._doctorCode = doctorCode;
            this._resType = resType;
            this._resUserName = resUserName;
            this._resInputType = resInputType;
            this._comingStatus = comingStatus;
            this._newRow = newRow;
            this._examState = examState;
            this._examIraiState = examIraiState;
            this._resUser = resUser;
            this._ipwonStatus = ipwonStatus;
            this._reserComments = reserComments;
            this._reserType = reserType;
            this._clinicName = clinicName;
        }

    }
}