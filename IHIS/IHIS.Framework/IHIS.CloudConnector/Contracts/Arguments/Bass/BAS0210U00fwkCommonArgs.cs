using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0210U00fwkCommonArgs : IContractArgs
	{
        protected bool Equals(BAS0210U00fwkCommonArgs other)
        {
            return string.Equals(_find, other._find);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0210U00fwkCommonArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_find != null ? _find.GetHashCode() : 0);
        }

        private String _find;

		public String Find
		{
			get { return this._find; }
			set { this._find = value; }
		}

		public BAS0210U00fwkCommonArgs() { }

		public BAS0210U00fwkCommonArgs(String find)
		{
			this._find = find;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0210U00fwkCommonRequest();
		}
	}
}