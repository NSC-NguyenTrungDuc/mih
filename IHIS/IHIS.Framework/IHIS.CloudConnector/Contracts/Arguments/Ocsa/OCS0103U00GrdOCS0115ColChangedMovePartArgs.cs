using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GrdOCS0115ColChangedMovePartArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GrdOCS0115ColChangedMovePartArgs other)
    {
        return string.Equals(_gwa, other._gwa) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GrdOCS0115ColChangedMovePartArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _gwa;
        private String _hospCode;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00GrdOCS0115ColChangedMovePartArgs() { }

        public OCS0103U00GrdOCS0115ColChangedMovePartArgs(String gwa, String hospCode)
        {
            this._gwa = gwa;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GrdOCS0115ColChangedMovePartRequest();
        }
    }
}