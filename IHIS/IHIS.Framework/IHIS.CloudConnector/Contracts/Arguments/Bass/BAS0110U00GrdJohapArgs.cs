using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0110U00GrdJohapArgs : IContractArgs
    {
        protected bool Equals(BAS0110U00GrdJohapArgs other)
        {
            return string.Equals(_johapGubun, other._johapGubun) && string.Equals(_johap, other._johap) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110U00GrdJohapArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_johapGubun != null ? _johapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_johap != null ? _johap.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _johapGubun;
        private String _johap;
        private String _startDate;

        public String JohapGubun
        {
            get { return this._johapGubun; }
            set { this._johapGubun = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public BAS0110U00GrdJohapArgs() { }

        public BAS0110U00GrdJohapArgs(String johapGubun, String johap, String startDate)
        {
            this._johapGubun = johapGubun;
            this._johap = johap;
            this._startDate = startDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0110U00GrdJohapRequest();
        }
    }
}