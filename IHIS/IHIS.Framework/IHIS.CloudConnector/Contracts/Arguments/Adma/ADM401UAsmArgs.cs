using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM401UAsmArgs : IContractArgs
	{
        protected bool Equals(ADM401UAsmArgs other)
        {
            return string.Equals(_asmName, other._asmName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM401UAsmArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_asmName != null ? _asmName.GetHashCode() : 0);
        }

        private String _asmName;

		public String AsmName
		{
			get { return this._asmName; }
			set { this._asmName = value; }
		}

		public ADM401UAsmArgs() { }

		public ADM401UAsmArgs(String asmName)
		{
			this._asmName = asmName;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM401UAsmRequest();
		}
	}
}