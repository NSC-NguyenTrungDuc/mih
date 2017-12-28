using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM104UFindBoxArgs : IContractArgs
    {
        protected bool Equals(ADM104UFindBoxArgs other)
        {
            return string.Equals(_controlName, other._controlName) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM104UFindBoxArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_controlName != null ? _controlName.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _controlName;
        private String _hospCode;

        public String ControlName
        {
            get { return this._controlName; }
            set { this._controlName = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM104UFindBoxArgs() { }

        public ADM104UFindBoxArgs(String controlName, String hospCode)
        {
            this._controlName = controlName;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM104UFindBoxRequest();
        }
    }
}