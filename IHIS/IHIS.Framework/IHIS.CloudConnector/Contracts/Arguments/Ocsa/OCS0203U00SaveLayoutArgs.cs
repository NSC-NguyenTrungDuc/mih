using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0203U00SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(OCS0203U00SaveLayoutArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_userId, other._userId) && Equals(_infoList, other._infoList);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0203U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_infoList != null ? _infoList.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _userId;
        private List<OCS0203U00GrdOcs0203P1Info> _infoList = new List<OCS0203U00GrdOcs0203P1Info>();

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<OCS0203U00GrdOcs0203P1Info> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public OCS0203U00SaveLayoutArgs() { }

        public OCS0203U00SaveLayoutArgs(String hospCode, String userId, List<OCS0203U00GrdOcs0203P1Info> infoList)
        {
            this._hospCode = hospCode;
            this._userId = userId;
            this._infoList = infoList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0203U00SaveLayoutRequest();
        }
    }
}