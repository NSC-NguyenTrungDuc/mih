using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Orca
{[Serializable]
    public class ORCATransferOrdersArgs : IContractArgs
    {
    protected bool Equals(ORCATransferOrdersArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode) && string.Equals(_pkout1001, other._pkout1001) && Equals(_sgCodeItem, other._sgCodeItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ORCATransferOrdersArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sgCodeItem != null ? _sgCodeItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
        private String _hospCode;
        private String _pkout1001;
        private List<ORCATransferOrdersLstSgCodeInfo> _sgCodeItem = new List<ORCATransferOrdersLstSgCodeInfo>();

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public List<ORCATransferOrdersLstSgCodeInfo> SgCodeItem
        {
            get { return this._sgCodeItem; }
            set { this._sgCodeItem = value; }
        }

        public ORCATransferOrdersArgs() { }

        public ORCATransferOrdersArgs(String bunho, String hospCode, String pkout1001, List<ORCATransferOrdersLstSgCodeInfo> sgCodeItem)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._pkout1001 = pkout1001;
            this._sgCodeItem = sgCodeItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORCATransferOrdersRequest();
        }
    }
}