using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0001U00MakeFindWorkerArgs : IContractArgs
    {
    protected bool Equals(XRT0001U00MakeFindWorkerArgs other)
    {
        return string.Equals(_ctrName, other._ctrName) && string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0001U00MakeFindWorkerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_ctrName != null ? _ctrName.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
        }
    }

    private String _ctrName;
        private String _find1;

        public String CtrName
        {
            get { return this._ctrName; }
            set { this._ctrName = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public XRT0001U00MakeFindWorkerArgs() { }

        public XRT0001U00MakeFindWorkerArgs(String ctrName, String find1)
        {
            this._ctrName = ctrName;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0001U00MakeFindWorkerRequest();
        }
    }
}