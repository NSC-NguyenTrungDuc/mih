using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySubHangmogArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00LaySubHangmogArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00LaySubHangmogArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _hangmogCode;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public CPL0000Q00LaySubHangmogArgs() { }

		public CPL0000Q00LaySubHangmogArgs(String bunho, String hangmogCode)
		{
			this._bunho = bunho;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00LaySubHangmogRequest();
		}
	}
}