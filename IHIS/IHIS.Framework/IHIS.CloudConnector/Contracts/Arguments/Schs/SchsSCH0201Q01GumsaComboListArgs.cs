using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    [Serializable]
	public class SchsSCH0201Q01GumsaComboListArgs : IContractArgs
	{
        protected bool Equals(SchsSCH0201Q01GumsaComboListArgs other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SchsSCH0201Q01GumsaComboListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
        }

        private String _hangmogCode;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public SchsSCH0201Q01GumsaComboListArgs() { }

		public SchsSCH0201Q01GumsaComboListArgs(String hangmogCode)
		{
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q01GumsaComboListRequest();
		}
	}
}