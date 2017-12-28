using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboUserGroupArgs : IContractArgs
    {
        protected bool Equals(ComboUserGroupArgs other)
        {
            return _getAll.Equals(other._getAll) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboUserGroupArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_getAll.GetHashCode()*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private Boolean _getAll;
        private String _hospCode;

        public Boolean GetAll
        {
            get { return this._getAll; }
            set { this._getAll = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ComboUserGroupArgs() { }

        public ComboUserGroupArgs(Boolean getAll, String hospCode)
        {
            this._getAll = getAll;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboUserGroupRequest();
        }
    }
}