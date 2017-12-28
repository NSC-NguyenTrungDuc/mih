using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0803U00GetFindWorkerArgs : IContractArgs
    {
    protected bool Equals(OCS0803U00GetFindWorkerArgs other)
    {
        return string.Equals(_findMode, other._findMode) && string.Equals(_patStatus, other._patStatus);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0803U00GetFindWorkerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_findMode != null ? _findMode.GetHashCode() : 0)*397) ^ (_patStatus != null ? _patStatus.GetHashCode() : 0);
        }
    }

    private String _findMode;
        private String _patStatus;

        public String FindMode
        {
            get { return this._findMode; }
            set { this._findMode = value; }
        }

        public String PatStatus
        {
            get { return this._patStatus; }
            set { this._patStatus = value; }
        }

        public OCS0803U00GetFindWorkerArgs() { }

        public OCS0803U00GetFindWorkerArgs(String findMode, String patStatus)
        {
            this._findMode = findMode;
            this._patStatus = patStatus;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0803U00GetFindWorkerRequest();
        }
    }
}