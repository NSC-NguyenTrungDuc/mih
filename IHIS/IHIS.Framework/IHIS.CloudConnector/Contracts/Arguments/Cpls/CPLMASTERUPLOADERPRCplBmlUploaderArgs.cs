using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPLMASTERUPLOADERPRCplBmlUploaderArgs : IContractArgs
    {
        protected bool Equals(CPLMASTERUPLOADERPRCplBmlUploaderArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode) && Equals(_uplItem, other._uplItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPLMASTERUPLOADERPRCplBmlUploaderArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_uplItem != null ? _uplItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _hospCode;
        private List<CPLMASTERUPLOADERPRCplBmlUploaderInfo> _uplItem = new List<CPLMASTERUPLOADERPRCplBmlUploaderInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<CPLMASTERUPLOADERPRCplBmlUploaderInfo> UplItem
        {
            get { return this._uplItem; }
            set { this._uplItem = value; }
        }

        public CPLMASTERUPLOADERPRCplBmlUploaderArgs() { }

        public CPLMASTERUPLOADERPRCplBmlUploaderArgs(String userId, String hospCode, List<CPLMASTERUPLOADERPRCplBmlUploaderInfo> uplItem)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._uplItem = uplItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPLMASTERUPLOADERPRCplBmlUploaderRequest();
        }
    }
}