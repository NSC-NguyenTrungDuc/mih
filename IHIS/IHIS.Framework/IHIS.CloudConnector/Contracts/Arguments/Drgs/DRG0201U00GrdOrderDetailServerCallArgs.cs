using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderDetailServerCallArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00GrdOrderDetailServerCallArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_bunho, other._bunho) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00GrdOrderDetailServerCallArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jubsuDate;
		private String _bunho;
		private String _drgBunho;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public DRG0201U00GrdOrderDetailServerCallArgs() { }

		public DRG0201U00GrdOrderDetailServerCallArgs(String jubsuDate, String bunho, String drgBunho)
		{
			this._jubsuDate = jubsuDate;
			this._bunho = bunho;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00GrdOrderDetailServerCallRequest();
		}
	}
}