using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311Q00LayDownListQueryEndArgs : IContractArgs
    {
    protected bool Equals(OCS0311Q00LayDownListQueryEndArgs other)
    {
        return Equals(_layDownReqItem, other._layDownReqItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311Q00LayDownListQueryEndArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_layDownReqItem != null ? _layDownReqItem.GetHashCode() : 0);
    }

    private List<OCS0311Q00LayDownListQueryEndReqInfo> _layDownReqItem = new List<OCS0311Q00LayDownListQueryEndReqInfo>();

        public List<OCS0311Q00LayDownListQueryEndReqInfo> LayDownReqItem
        {
            get { return this._layDownReqItem; }
            set { this._layDownReqItem = value; }
        }

        public OCS0311Q00LayDownListQueryEndArgs() { }

        public OCS0311Q00LayDownListQueryEndArgs(List<OCS0311Q00LayDownListQueryEndReqInfo> layDownReqItem)
        {
            this._layDownReqItem = layDownReqItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311Q00LayDownListQueryEndRequest();
        }
    }
}