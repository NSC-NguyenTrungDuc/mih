using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210GridColumnChangedArgs : IContractArgs
	{
        protected bool Equals(BAS0210U00grdBAS0210GridColumnChangedArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_colName, other._colName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0210U00grdBAS0210GridColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
            }
        }

        private String _code;
		private String _colName;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String ColName
		{
			get { return this._colName; }
			set { this._colName = value; }
		}

		public BAS0210U00grdBAS0210GridColumnChangedArgs() { }

		public BAS0210U00grdBAS0210GridColumnChangedArgs(String code, String colName)
		{
			this._code = code;
			this._colName = colName;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0210U00grdBAS0210GridColumnChangedRequest();
		}
	}
}