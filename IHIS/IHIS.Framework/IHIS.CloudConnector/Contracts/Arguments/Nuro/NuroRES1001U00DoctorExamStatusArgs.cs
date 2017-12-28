using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00DoctorExamStatusArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00DoctorExamStatusArgs other)
        {
            return string.Equals(_type, other._type) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_examPreTime, other._examPreTime) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00DoctorExamStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreTime != null ? _examPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _type;
        private String _examPreDate;
        private String _examPreTime;
        private String _doctorCode;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
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

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public Boolean TabIsAll
        {
            get { return this._tabIsAll; }
            set { this._tabIsAll = value; }
        }

        public NuroRES1001U00DoctorExamStatusArgs() { }

        public NuroRES1001U00DoctorExamStatusArgs(String type, String examPreDate, String examPreTime, String doctorCode, String hospCodeLink, Boolean tabIsAll)
        {
            this._type = type;
            this._examPreDate = examPreDate;
            this._examPreTime = examPreTime;
            this._doctorCode = doctorCode;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00DoctorExamStatusRequest();
        }
    }
}