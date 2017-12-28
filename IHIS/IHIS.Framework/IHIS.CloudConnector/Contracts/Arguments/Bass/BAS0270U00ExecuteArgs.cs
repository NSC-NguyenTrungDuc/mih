using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0270U00ExecuteArgs : IContractArgs
    {
        protected bool Equals(BAS0270U00ExecuteArgs other)
        {
            return Equals(_grdBAS0271Info, other._grdBAS0271Info) && Equals(_grdBAS0272Info, other._grdBAS0272Info) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0270U00ExecuteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdBAS0271Info != null ? _grdBAS0271Info.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdBAS0272Info != null ? _grdBAS0272Info.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<BAS0270U00GrdBAS0271Info> _grdBAS0271Info = new List<BAS0270U00GrdBAS0271Info>();
        private List<BAS0270U00GrdBAS0272Info> _grdBAS0272Info = new List<BAS0270U00GrdBAS0272Info>();
        private String _userId;
        private String _hospCode;

        public List<BAS0270U00GrdBAS0271Info> GrdBAS0271Info
        {
            get { return this._grdBAS0271Info; }
            set { this._grdBAS0271Info = value; }
        }

        public List<BAS0270U00GrdBAS0272Info> GrdBAS0272Info
        {
            get { return this._grdBAS0272Info; }
            set { this._grdBAS0272Info = value; }
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

        public BAS0270U00ExecuteArgs() { }

        public BAS0270U00ExecuteArgs(List<BAS0270U00GrdBAS0271Info> grdBAS0271Info, List<BAS0270U00GrdBAS0272Info> grdBAS0272Info, String userId, String hospCode)
        {
            this._grdBAS0271Info = grdBAS0271Info;
            this._grdBAS0272Info = grdBAS0272Info;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0270U00ExecuteRequest();
        }
    }
}