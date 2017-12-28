using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0212U00GrdItemArgs : IContractArgs
    {
        protected bool Equals(BAS0212U00GrdItemArgs other)
        {
            return string.Equals(_gongbiCode, other._gongbiCode) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0212U00GrdItemArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gongbiCode != null ? _gongbiCode.GetHashCode() : 0)*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            }
        }

        private String _gongbiCode;
        private String _startDate;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public BAS0212U00GrdItemArgs() { }

        public BAS0212U00GrdItemArgs(String gongbiCode, String startDate)
        {
            this._gongbiCode = gongbiCode;
            this._startDate = startDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0212U00GrdItemRequest();
        }
    }
}