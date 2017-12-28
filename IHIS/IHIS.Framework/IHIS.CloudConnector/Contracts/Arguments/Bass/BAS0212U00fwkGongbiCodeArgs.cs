using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0212U00fwkGongbiCodeArgs : IContractArgs
    {
        protected bool Equals(BAS0212U00fwkGongbiCodeArgs other)
        {
            return string.Equals(_find1, other._find1) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0212U00fwkGongbiCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_find1 != null ? _find1.GetHashCode() : 0)*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            }
        }

        private String _find1;
        private String _startDate;

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public BAS0212U00fwkGongbiCodeArgs() { }

        public BAS0212U00fwkGongbiCodeArgs(String find1, String startDate)
        {
            this._find1 = find1;
            this._startDate = startDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0212U00fwkGongbiCodeRequest();
        }
    }
}