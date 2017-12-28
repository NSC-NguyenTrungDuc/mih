using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0301U00CboDoctorGwaArgs : IContractArgs
    {
    protected bool Equals(OCS0301U00CboDoctorGwaArgs other)
    {
        return Equals(_gwaInfo, other._gwaInfo) && Equals(_userInfo, other._userInfo) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301U00CboDoctorGwaArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gwaInfo != null ? _gwaInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userInfo != null ? _userInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private LoadColumnCodeNameInfo _gwaInfo;
        private LoadColumnCodeNameInfo _userInfo;
        private String _userId;
        private String _hospCode;

        public LoadColumnCodeNameInfo GwaInfo
        {
            get { return this._gwaInfo; }
            set { this._gwaInfo = value; }
        }

        public LoadColumnCodeNameInfo UserInfo
        {
            get { return this._userInfo; }
            set { this._userInfo = value; }
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

        public OCS0301U00CboDoctorGwaArgs() { }

        public OCS0301U00CboDoctorGwaArgs(LoadColumnCodeNameInfo gwaInfo, LoadColumnCodeNameInfo userInfo, String userId, String hospCode)
        {
            this._gwaInfo = gwaInfo;
            this._userInfo = userInfo;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0301U00CboDoctorGwaRequest();
        }
    }
}