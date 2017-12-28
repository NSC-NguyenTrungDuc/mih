using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0140U00GrdMasterArgs : IContractArgs
	{
        protected bool Equals(DRG0140U00GrdMasterArgs other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0140U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_code != null ? _code.GetHashCode() : 0);
        }

        private String _code;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public DRG0140U00GrdMasterArgs() { }

		public DRG0140U00GrdMasterArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0140U00GrdMasterRequest();
		}
	}
}