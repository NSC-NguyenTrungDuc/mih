using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GrdPaCntArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GrdPaCntArgs other)
    {
        return string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GrdPaCntArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
    }

    private String _naewonDate;

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public PHY2001U04GrdPaCntArgs() { }

        public PHY2001U04GrdPaCntArgs(String naewonDate)
        {
            this._naewonDate = naewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GrdPaCntRequest();
        }
    }
}