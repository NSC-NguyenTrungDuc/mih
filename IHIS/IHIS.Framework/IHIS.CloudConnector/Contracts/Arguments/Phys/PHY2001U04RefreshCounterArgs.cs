using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04RefreshCounterArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04RefreshCounterArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04RefreshCounterArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
        }
    }

    private String _gwa;
        private String _naewonDate;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public PHY2001U04RefreshCounterArgs() { }

        public PHY2001U04RefreshCounterArgs(String gwa, String naewonDate)
        {
            this._gwa = gwa;
            this._naewonDate = naewonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04RefreshCounterRequest();
        }
    }
}