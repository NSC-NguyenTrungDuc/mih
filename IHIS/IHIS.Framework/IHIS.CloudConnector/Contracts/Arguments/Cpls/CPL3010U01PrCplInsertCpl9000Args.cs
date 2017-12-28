using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01PrCplInsertCpl9000Args : IContractArgs
    {
        protected bool Equals(CPL3010U01PrCplInsertCpl9000Args other)
        {
            return string.Equals(_userId, other._userId) && Equals(_prCplLst, other._prCplLst);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01PrCplInsertCpl9000Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_prCplLst != null ? _prCplLst.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<CPL3010U01PrCplInsertCpl9000Info> _prCplLst = new List<CPL3010U01PrCplInsertCpl9000Info>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL3010U01PrCplInsertCpl9000Info> PrCplLst
        {
            get { return this._prCplLst; }
            set { this._prCplLst = value; }
        }

        public CPL3010U01PrCplInsertCpl9000Args() { }

        public CPL3010U01PrCplInsertCpl9000Args(String userId, List<CPL3010U01PrCplInsertCpl9000Info> prCplLst)
        {
            this._userId = userId;
            this._prCplLst = prCplLst;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01PrCplInsertCpl9000Request();
        }
    }
}