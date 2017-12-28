using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM103SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(ADM103SaveLayoutArgs other)
        {
            return string.Equals(_sysId, other._sysId) && Equals(_itemInfo, other._itemInfo) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM103SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_itemInfo != null ? _itemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _sysId;
        private List<ADM103UgrdUserGrpInfo> _itemInfo = new List<ADM103UgrdUserGrpInfo>();
        private String _hospCode;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public List<ADM103UgrdUserGrpInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM103SaveLayoutArgs() { }

        public ADM103SaveLayoutArgs(String sysId, List<ADM103UgrdUserGrpInfo> itemInfo, String hospCode)
        {
            this._sysId = sysId;
            this._itemInfo = itemInfo;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM103SaveLayoutRequest();
        }
    }
}