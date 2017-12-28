using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class NuroPatientListArgs : IContractArgs
    {
        private String _hospitalCode;
        private String _comingDate;
        private String _departmentCode;
        private String _doctorCode;
        private String _patientCode;
        private String _receptionType;
        private String _examStatus;
        private String _comingStatus;
        private String _currentSystemId;
        private String _toDate;

        public String HospitalCode
        {
            get { return this._hospitalCode; }
            set { this._hospitalCode = value; }
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

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String ReceptionType
        {
            get { return this._receptionType; }
            set { this._receptionType = value; }
        }

        public String ExamStatus
        {
            get { return this._examStatus; }
            set { this._examStatus = value; }
        }

        public String ComingStatus
        {
            get { return this._comingStatus; }
            set { this._comingStatus = value; }
        }

        public String CurrentSystemId
        {
            get { return this._currentSystemId; }
            set { this._currentSystemId = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public NuroPatientListArgs() { }

        public NuroPatientListArgs(String hospitalCode, String comingDate, String departmentCode, String doctorCode, String patientCode, String receptionType, String examStatus, String comingStatus, String currentSystemId, String toDate)
        {
            this._hospitalCode = hospitalCode;
            this._comingDate = comingDate;
            this._departmentCode = departmentCode;
            this._doctorCode = doctorCode;
            this._patientCode = patientCode;
            this._receptionType = receptionType;
            this._examStatus = examStatus;
            this._comingStatus = comingStatus;
            this._currentSystemId = currentSystemId;
            this._toDate = toDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroPatientListRequest();
        }
    }
}