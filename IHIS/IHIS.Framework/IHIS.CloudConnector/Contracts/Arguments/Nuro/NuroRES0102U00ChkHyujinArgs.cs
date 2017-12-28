using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES0102U00ChkHyujinArgs : IContractArgs
    {
        protected bool Equals(NuroRES0102U00ChkHyujinArgs other)
        {
            return string.Equals(_startDate, other._startDate) && string.Equals(_endDate, other._endDate) && string.Equals(_doctor, other._doctor) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES0102U00ChkHyujinArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endDate != null ? _endDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _startDate;
        private String _endDate;
        private String _doctor;
        private String _hospCode;

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public NuroRES0102U00ChkHyujinArgs() { }

        public NuroRES0102U00ChkHyujinArgs(String startDate, String endDate, String doctor, String hospCode)
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._doctor = doctor;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES0102U00ChkHyujinRequest();
        }
    }
}