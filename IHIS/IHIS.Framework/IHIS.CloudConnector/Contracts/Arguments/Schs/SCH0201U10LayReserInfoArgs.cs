using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201U10LayReserInfoArgs : IContractArgs
    {
    protected bool Equals(SCH0201U10LayReserInfoArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_reserDate, other._reserDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201U10LayReserInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _reserDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public SCH0201U10LayReserInfoArgs() { }

        public SCH0201U10LayReserInfoArgs(String bunho, String reserDate)
        {
            this._bunho = bunho;
            this._reserDate = reserDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201U10LayReserInfoRequest();
        }
    }
}