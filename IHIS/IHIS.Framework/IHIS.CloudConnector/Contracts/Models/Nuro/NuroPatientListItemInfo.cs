using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NuroPatientListItemInfo
    {
        private String _departmentCode;
        private String _departmentName;
        private String _patientCode;
        private String _patientName;
        private String _patientName2;
        private String _comingDate;
        private String _doctorCode;
        private String _doctorName;
        private String _comingType;
        private String _receptionCode;
        private String _birth;
        private String _ageSex;
        private String _outResKey;
        private String _receptionTime;
        private String _orderEndYn;
        private String _holdYn;
        private String _resultYn;
        private String _reserYn;
        private String _ipwonYn;
        private String _sunabYn;
        private String _comingStatus;
        private String _receptionType;
        private String _receptionTypeName;
        private String _remark;
        private String _arriveTime;
        private String _type;
        private String _lastComingDate;
        private String _ocsComment;
        private String _chojae;
        private String _groupKey;
        private String _patientType;
        private String _careStatus;
        private String _percentage;
        private String _examStatus;
        private String _trialYn;
        private String _sysId;

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String DepartmentName
        {
            get { return this._departmentName; }
            set { this._departmentName = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String PatientName
        {
            get { return this._patientName; }
            set { this._patientName = value; }
        }

        public String PatientName2
        {
            get { return this._patientName2; }
            set { this._patientName2 = value; }
        }

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String ComingType
        {
            get { return this._comingType; }
            set { this._comingType = value; }
        }

        public String ReceptionCode
        {
            get { return this._receptionCode; }
            set { this._receptionCode = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String AgeSex
        {
            get { return this._ageSex; }
            set { this._ageSex = value; }
        }

        public String OutResKey
        {
            get { return this._outResKey; }
            set { this._outResKey = value; }
        }

        public String ReceptionTime
        {
            get { return this._receptionTime; }
            set { this._receptionTime = value; }
        }

        public String OrderEndYn
        {
            get { return this._orderEndYn; }
            set { this._orderEndYn = value; }
        }

        public String HoldYn
        {
            get { return this._holdYn; }
            set { this._holdYn = value; }
        }

        public String ResultYn
        {
            get { return this._resultYn; }
            set { this._resultYn = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String IpwonYn
        {
            get { return this._ipwonYn; }
            set { this._ipwonYn = value; }
        }

        public String SunabYn
        {
            get { return this._sunabYn; }
            set { this._sunabYn = value; }
        }

        public String ComingStatus
        {
            get { return this._comingStatus; }
            set { this._comingStatus = value; }
        }

        public String ReceptionType
        {
            get { return this._receptionType; }
            set { this._receptionType = value; }
        }

        public String ReceptionTypeName
        {
            get { return this._receptionTypeName; }
            set { this._receptionTypeName = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String LastComingDate
        {
            get { return this._lastComingDate; }
            set { this._lastComingDate = value; }
        }

        public String OcsComment
        {
            get { return this._ocsComment; }
            set { this._ocsComment = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String GroupKey
        {
            get { return this._groupKey; }
            set { this._groupKey = value; }
        }

        public String PatientType
        {
            get { return this._patientType; }
            set { this._patientType = value; }
        }

        public String CareStatus
        {
            get { return this._careStatus; }
            set { this._careStatus = value; }
        }

        public String Percentage
        {
            get { return this._percentage; }
            set { this._percentage = value; }
        }

        public String ExamStatus
        {
            get { return this._examStatus; }
            set { this._examStatus = value; }
        }

        public String TrialYn
        {
            get { return this._trialYn; }
            set { this._trialYn = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public NuroPatientListItemInfo() { }

        public NuroPatientListItemInfo(String departmentCode, String departmentName, String patientCode, String patientName, String patientName2, String comingDate, String doctorCode, String doctorName, String comingType, String receptionCode, String birth, String ageSex, String outResKey, String receptionTime, String orderEndYn, String holdYn, String resultYn, String reserYn, String ipwonYn, String sunabYn, String comingStatus, String receptionType, String receptionTypeName, String remark, String arriveTime, String type, String lastComingDate, String ocsComment, String chojae, String groupKey, String patientType, String careStatus, String percentage, String examStatus, String trialYn, String sysId)
        {
            this._departmentCode = departmentCode;
            this._departmentName = departmentName;
            this._patientCode = patientCode;
            this._patientName = patientName;
            this._patientName2 = patientName2;
            this._comingDate = comingDate;
            this._doctorCode = doctorCode;
            this._doctorName = doctorName;
            this._comingType = comingType;
            this._receptionCode = receptionCode;
            this._birth = birth;
            this._ageSex = ageSex;
            this._outResKey = outResKey;
            this._receptionTime = receptionTime;
            this._orderEndYn = orderEndYn;
            this._holdYn = holdYn;
            this._resultYn = resultYn;
            this._reserYn = reserYn;
            this._ipwonYn = ipwonYn;
            this._sunabYn = sunabYn;
            this._comingStatus = comingStatus;
            this._receptionType = receptionType;
            this._receptionTypeName = receptionTypeName;
            this._remark = remark;
            this._arriveTime = arriveTime;
            this._type = type;
            this._lastComingDate = lastComingDate;
            this._ocsComment = ocsComment;
            this._chojae = chojae;
            this._groupKey = groupKey;
            this._patientType = patientType;
            this._careStatus = careStatus;
            this._percentage = percentage;
            this._examStatus = examStatus;
            this._trialYn = trialYn;
            this._sysId = sysId;
        }

    }
}