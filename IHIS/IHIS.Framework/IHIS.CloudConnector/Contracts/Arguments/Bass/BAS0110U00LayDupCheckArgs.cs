using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0110U00LayDupCheckArgs : IContractArgs
    {
        protected bool Equals(BAS0110U00LayDupCheckArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_startDate, other._startDate) && string.Equals(_johap, other._johap);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110U00LayDupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_johap != null ? _johap.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
        private String _startDate;
        private String _johap;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public BAS0110U00LayDupCheckArgs() { }

        public BAS0110U00LayDupCheckArgs(String gubun, String startDate, String johap)
        {
            this._gubun = gubun;
            this._startDate = startDate;
            this._johap = johap;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0110U00LayDupCheckRequest();
        }
    }
}