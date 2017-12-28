using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0201Q12FwkDoctorListArgs : IContractArgs
    {
    protected bool Equals(SCH0201Q12FwkDoctorListArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201Q12FwkDoctorListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
        }
    }

    private String _gwa;
        private String _find1;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public SCH0201Q12FwkDoctorListArgs() { }

        public SCH0201Q12FwkDoctorListArgs(String gwa, String find1)
        {
            this._gwa = gwa;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0201Q12FwkDoctorListRequest();
        }
    }
}