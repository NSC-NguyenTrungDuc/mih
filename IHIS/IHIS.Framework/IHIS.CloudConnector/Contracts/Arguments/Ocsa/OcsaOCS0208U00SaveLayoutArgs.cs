using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OcsaOCS0208U00SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OcsaOCS0208U00SaveLayoutArgs other)
    {
        return Equals(_grdSaveItem, other._grdSaveItem) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0208U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdSaveItem != null ? _grdSaveItem.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OcsaOCS0208U00GrdOCS0208U00ListInfo> _grdSaveItem = new List<OcsaOCS0208U00GrdOCS0208U00ListInfo>();
        private String _userId;
        private String _hospCode;

        public List<OcsaOCS0208U00GrdOCS0208U00ListInfo> GrdSaveItem
        {
            get { return this._grdSaveItem; }
            set { this._grdSaveItem = value; }
        }

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

        public OcsaOCS0208U00SaveLayoutArgs() { }

        public OcsaOCS0208U00SaveLayoutArgs(List<OcsaOCS0208U00GrdOCS0208U00ListInfo> grdSaveItem, String userId, String hospCode)
        {
            this._grdSaveItem = grdSaveItem;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OcsaOCS0208U00SaveLayoutRequest();
        }
    }
}