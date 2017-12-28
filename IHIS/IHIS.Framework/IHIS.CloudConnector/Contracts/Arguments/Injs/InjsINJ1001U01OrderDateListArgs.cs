using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01OrderDateListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01OrderDateListArgs other)
        {
            return string.Equals(_pkinj1002, other._pkinj1002);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01OrderDateListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_pkinj1002 != null ? _pkinj1002.GetHashCode() : 0);
        }

        private String _pkinj1002;

		public String Pkinj1002
		{
			get { return this._pkinj1002; }
			set { this._pkinj1002 = value; }
		}

		public InjsINJ1001U01OrderDateListArgs() { }

		public InjsINJ1001U01OrderDateListArgs(String pkinj1002)
		{
			this._pkinj1002 = pkinj1002;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01OrderDateListRequest();
		}
	}
}