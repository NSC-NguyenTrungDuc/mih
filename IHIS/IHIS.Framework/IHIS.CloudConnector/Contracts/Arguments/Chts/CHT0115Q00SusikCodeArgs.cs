using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0115Q00SusikCodeArgs : IContractArgs
	{
        protected bool Equals(CHT0115Q00SusikCodeArgs other)
        {
            return string.Equals(_susikCode, other._susikCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q00SusikCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_susikCode != null ? _susikCode.GetHashCode() : 0);
        }

        private String _susikCode;

		public String SusikCode
		{
			get { return this._susikCode; }
			set { this._susikCode = value; }
		}

		public CHT0115Q00SusikCodeArgs() { }

		public CHT0115Q00SusikCodeArgs(String susikCode)
		{
			this._susikCode = susikCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0115Q00SusikCodeRequest();
		}
	}
}