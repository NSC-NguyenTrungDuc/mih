using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0118U00GrdSaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS0118U00GrdSaveLayoutArgs other)
    {
        return Equals(_grdSaveLayoutInfo, other._grdSaveLayoutInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0118U00GrdSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_grdSaveLayoutInfo != null ? _grdSaveLayoutInfo.GetHashCode() : 0);
    }

    private List<OCS0118U00GrdSaveLayoutInfo> _grdSaveLayoutInfo = new List<OCS0118U00GrdSaveLayoutInfo>();

        public List<OCS0118U00GrdSaveLayoutInfo> GrdSaveLayoutInfo
        {
            get { return this._grdSaveLayoutInfo; }
            set { this._grdSaveLayoutInfo = value; }
        }

        public OCS0118U00GrdSaveLayoutArgs() { }

        public OCS0118U00GrdSaveLayoutArgs(List<OCS0118U00GrdSaveLayoutInfo> grdSaveLayoutInfo)
        {
            this._grdSaveLayoutInfo = grdSaveLayoutInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0118U00GrdSaveLayoutRequest();
        }
    }
}