using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00FindBoxArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00FindBoxArgs other)
        {
            return string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00FindBoxArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_find1 != null ? _find1.GetHashCode() : 0);
        }

        private String _find1;

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public IFS0001U00FindBoxArgs() { }

        public IFS0001U00FindBoxArgs(String find1)
        {
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00FindBoxRequest();
        }
    }
}