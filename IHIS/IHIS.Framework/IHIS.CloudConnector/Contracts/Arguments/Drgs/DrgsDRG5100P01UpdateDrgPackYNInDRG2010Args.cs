using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args other)
        {
            return string.Equals(_drgPackYn, other._drgPackYn) && string.Equals(_fkocs1003, other._fkocs1003);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_drgPackYn != null ? _drgPackYn.GetHashCode() : 0)*397) ^ (_fkocs1003 != null ? _fkocs1003.GetHashCode() : 0);
            }
        }

        private String _drgPackYn;
		private String _fkocs1003;

		public String DrgPackYn
		{
			get { return this._drgPackYn; }
			set { this._drgPackYn = value; }
		}

		public String Fkocs1003
		{
			get { return this._fkocs1003; }
			set { this._fkocs1003 = value; }
		}

		public DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args() { }

		public DrgsDRG5100P01UpdateDrgPackYNInDRG2010Args(String drgPackYn, String fkocs1003)
		{
			this._drgPackYn = drgPackYn;
			this._fkocs1003 = fkocs1003;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request();
		}
	}
}