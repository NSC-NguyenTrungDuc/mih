using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04LayNUR7001Args : IContractArgs
    {
    protected bool Equals(PHY2001U04LayNUR7001Args other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_measureDate, other._measureDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04LayNUR7001Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_measureDate != null ? _measureDate.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _measureDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String MeasureDate
        {
            get { return this._measureDate; }
            set { this._measureDate = value; }
        }

        public PHY2001U04LayNUR7001Args() { }

        public PHY2001U04LayNUR7001Args(String bunho, String measureDate)
        {
            this._bunho = bunho;
            this._measureDate = measureDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04LayNUR7001Request();
        }
    }
}