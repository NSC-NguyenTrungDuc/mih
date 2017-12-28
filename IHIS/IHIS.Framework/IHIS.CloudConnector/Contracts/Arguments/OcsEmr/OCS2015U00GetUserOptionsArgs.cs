using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U00GetUserOptionsArgs : IContractArgs
    {
    protected bool Equals(OCS2015U00GetUserOptionsArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_gwa, other._gwa) && string.Equals(_ioGubun, other._ioGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00GetUserOptionsArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
        private String _gwa;
        private String _ioGubun;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public OCS2015U00GetUserOptionsArgs() { }

        public OCS2015U00GetUserOptionsArgs(String userId, String gwa, String ioGubun)
        {
            this._userId = userId;
            this._gwa = gwa;
            this._ioGubun = ioGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00GetUserOptionsRequest();
        }
    }
}