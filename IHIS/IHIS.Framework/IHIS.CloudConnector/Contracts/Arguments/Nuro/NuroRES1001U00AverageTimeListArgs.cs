using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00AverageTimeListArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00AverageTimeListArgs other)
        {
            return string.Equals(_doctorCode, other._doctorCode) && string.Equals(_examPreDate, other._examPreDate) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00AverageTimeListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _doctorCode;
        private String _examPreDate;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

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

        public NuroRES1001U00AverageTimeListArgs() { }

        public NuroRES1001U00AverageTimeListArgs(String doctorCode, String examPreDate, String hospCodeLink, Boolean tabIsAll)
        {
            this._doctorCode = doctorCode;
            this._examPreDate = examPreDate;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00AverageTimeListRequest();
        }
    }
}