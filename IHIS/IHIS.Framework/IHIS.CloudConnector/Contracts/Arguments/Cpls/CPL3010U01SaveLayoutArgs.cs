using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(CPL3010U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_saveLayoutLst, other._saveLayoutLst);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_saveLayoutLst != null ? _saveLayoutLst.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<CPL3010U01SaveLayoutInfo> _saveLayoutLst = new List<CPL3010U01SaveLayoutInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL3010U01SaveLayoutInfo> SaveLayoutLst
        {
            get { return this._saveLayoutLst; }
            set { this._saveLayoutLst = value; }
        }

        public CPL3010U01SaveLayoutArgs() { }

        public CPL3010U01SaveLayoutArgs(String userId, List<CPL3010U01SaveLayoutInfo> saveLayoutLst)
        {
            this._userId = userId;
            this._saveLayoutLst = saveLayoutLst;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01SaveLayoutRequest();
        }
    }
}