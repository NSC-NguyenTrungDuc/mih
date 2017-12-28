using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00GetNaewonKeyArgs : IContractArgs
	{
        protected bool Equals(NUT0001U00GetNaewonKeyArgs other)
        {
            return string.Equals(_pkocs, other._pkocs) && string.Equals(_ioKubun, other._ioKubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00GetNaewonKeyArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_pkocs != null ? _pkocs.GetHashCode() : 0)*397) ^ (_ioKubun != null ? _ioKubun.GetHashCode() : 0);
            }
        }

        private String _pkocs;
		private String _ioKubun;

		public String Pkocs
		{
			get { return this._pkocs; }
			set { this._pkocs = value; }
		}

		public String IoKubun
		{
			get { return this._ioKubun; }
			set { this._ioKubun = value; }
		}

		public NUT0001U00GetNaewonKeyArgs() { }

		public NUT0001U00GetNaewonKeyArgs(String pkocs, String ioKubun)
		{
			this._pkocs = pkocs;
			this._ioKubun = ioKubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00GetNaewonKeyRequest();
		}
	}
}