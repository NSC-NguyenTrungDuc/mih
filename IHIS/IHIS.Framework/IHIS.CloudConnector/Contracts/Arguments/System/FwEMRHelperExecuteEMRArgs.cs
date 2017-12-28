using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class FwEMRHelperExecuteEMRArgs : IContractArgs
    {
    protected bool Equals(FwEMRHelperExecuteEMRArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FwEMRHelperExecuteEMRArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
        }
    }

    private String _userId;
        private String _gwa;

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

        public FwEMRHelperExecuteEMRArgs() { }

        public FwEMRHelperExecuteEMRArgs(String userId, String gwa)
        {
            this._userId = userId;
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.FwEMRHelperExecuteEMRRequest();
        }
    }
}