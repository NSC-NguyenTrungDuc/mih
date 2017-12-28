using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00ReservationOut0123InsertArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00ReservationOut0123InsertArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_patientCode, other._patientCode) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_examPreTime, other._examPreTime) && string.Equals(_reserComment, other._reserComment) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_reserType, other._reserType) && string.Equals(_hospCodeLink, other._hospCodeLink);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReservationOut0123InsertArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserComment != null ? _reserComment.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserType != null ? _reserType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _patientCode;
        private String _departmentCode;
        private String _doctorCode;
        private String _examPreDate;
        private String _examPreTime;
        private String _reserComment;
        private String _pkout1001;
        private String _reserType;
        private String _hospCodeLink;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
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

        public String ExamPreDate
        {
            get { return this._examPreDate; }
            set { this._examPreDate = value; }
        }

        public String ExamPreTime
        {
            get { return this._examPreTime; }
            set { this._examPreTime = value; }
        }

        public String ReserComment
        {
            get { return this._reserComment; }
            set { this._reserComment = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ReserType
        {
            get { return this._reserType; }
            set { this._reserType = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public NuroRES1001U00ReservationOut0123InsertArgs() { }

        public NuroRES1001U00ReservationOut0123InsertArgs(String userId, String patientCode, String departmentCode, String doctorCode, String examPreDate, String examPreTime, String reserComment, String pkout1001, String reserType, String hospCodeLink)
        {
            this._userId = userId;
            this._patientCode = patientCode;
            this._departmentCode = departmentCode;
            this._doctorCode = doctorCode;
            this._examPreDate = examPreDate;
            this._examPreTime = examPreTime;
            this._reserComment = reserComment;
            this._pkout1001 = pkout1001;
            this._reserType = reserType;
            this._hospCodeLink = hospCodeLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00ReservationOut0123InsertRequest();
        }
    }
}