using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboOrdDanuiArgs : IContractArgs
    {
        protected bool Equals(ComboOrdDanuiArgs other)
        {
            return _isAll.Equals(other._isAll) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboOrdDanuiArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_isAll.GetHashCode()*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private Boolean _isAll;
        private String _hospCode;

        public Boolean IsAll
        {
            get { return this._isAll; }
            set { this._isAll = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ComboOrdDanuiArgs() { }

        public ComboOrdDanuiArgs(Boolean isAll, String hospCode)
        {
            this._isAll = isAll;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboOrdDanuiRequest();
        }
    }
}