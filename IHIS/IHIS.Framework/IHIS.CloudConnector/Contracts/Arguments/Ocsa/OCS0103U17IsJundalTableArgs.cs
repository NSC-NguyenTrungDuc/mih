using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U17IsJundalTableArgs : IContractArgs
	{
        protected bool Equals(OCS0103U17IsJundalTableArgs other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_jundalTable, other._jundalTable);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS0103U17IsJundalTableArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hangmogCode;
		private String _ioGubun;
		private String _jundalTable;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public OCS0103U17IsJundalTableArgs() { }

		public OCS0103U17IsJundalTableArgs(String hangmogCode, String ioGubun, String jundalTable)
		{
			this._hangmogCode = hangmogCode;
			this._ioGubun = ioGubun;
			this._jundalTable = jundalTable;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U17IsJundalTableRequest();
		}
	}
}