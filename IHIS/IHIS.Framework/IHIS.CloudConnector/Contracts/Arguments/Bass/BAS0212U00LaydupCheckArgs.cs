using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0212U00LaydupCheckArgs : IContractArgs
    {
        protected bool Equals(BAS0212U00LaydupCheckArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0212U00LaydupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            }
        }

        private String _code;
        private String _startDate;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public BAS0212U00LaydupCheckArgs() { }

        public BAS0212U00LaydupCheckArgs(String code, String startDate)
        {
            this._code = code;
            this._startDate = startDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0212U00LaydupCheckRequest();
        }
    }
}