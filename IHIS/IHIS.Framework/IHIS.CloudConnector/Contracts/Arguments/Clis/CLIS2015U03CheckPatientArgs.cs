using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U03CheckPatientArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U03CheckPatientArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && Equals(_checkItem, other._checkItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U03CheckPatientArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_checkItem != null ? _checkItem.GetHashCode() : 0);
            }
        }

        private String _hospCode;
        private List<CLIS2015U03CheckPatientRequestInfo> _checkItem = new List<CLIS2015U03CheckPatientRequestInfo>();

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<CLIS2015U03CheckPatientRequestInfo> CheckItem
        {
            get { return this._checkItem; }
            set { this._checkItem = value; }
        }

        public CLIS2015U03CheckPatientArgs() { }

        public CLIS2015U03CheckPatientArgs(String hospCode, List<CLIS2015U03CheckPatientRequestInfo> checkItem)
        {
            this._hospCode = hospCode;
            this._checkItem = checkItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U03CheckPatientRequest();
        }
    }
}