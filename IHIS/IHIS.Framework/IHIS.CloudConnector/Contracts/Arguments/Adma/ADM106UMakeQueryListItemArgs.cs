using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM106UMakeQueryListItemArgs : IContractArgs
    {
        protected bool Equals(ADM106UMakeQueryListItemArgs other)
        {
            return string.Equals(_sysId, other._sysId) && string.Equals(_upperMenu, other._upperMenu);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM106UMakeQueryListItemArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_sysId != null ? _sysId.GetHashCode() : 0)*397) ^ (_upperMenu != null ? _upperMenu.GetHashCode() : 0);
            }
        }

        private String _sysId;
        private String _upperMenu;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpperMenu
        {
            get { return this._upperMenu; }
            set { this._upperMenu = value; }
        }

        public ADM106UMakeQueryListItemArgs() { }

        public ADM106UMakeQueryListItemArgs(String sysId, String upperMenu)
        {
            this._sysId = sysId;
            this._upperMenu = upperMenu;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM106UMakeQueryListItemRequest();
        }
    }
}