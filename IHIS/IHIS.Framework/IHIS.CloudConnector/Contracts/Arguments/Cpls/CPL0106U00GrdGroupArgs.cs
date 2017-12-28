using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0106U00GrdGroupArgs : IContractArgs
    {
        protected bool Equals(CPL0106U00GrdGroupArgs other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_gumsaName, other._gumsaName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0106U00GrdGroupArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hangmogCode != null ? _hangmogCode.GetHashCode() : 0)*397) ^ (_gumsaName != null ? _gumsaName.GetHashCode() : 0);
            }
        }

        private String _hangmogCode;
        private String _gumsaName;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public CPL0106U00GrdGroupArgs() { }

        public CPL0106U00GrdGroupArgs(String hangmogCode, String gumsaName)
        {
            this._hangmogCode = hangmogCode;
            this._gumsaName = gumsaName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0106U00GrdGroupRequest();
        }
    }
}