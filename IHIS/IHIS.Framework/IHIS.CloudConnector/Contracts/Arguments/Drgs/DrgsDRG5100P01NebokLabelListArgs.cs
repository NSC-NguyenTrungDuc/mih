using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01NebokLabelListArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01NebokLabelListArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01NebokLabelListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jubsuDate;
		private String _drgBunho;
		private String _bunho;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DrgsDRG5100P01NebokLabelListArgs() { }

		public DrgsDRG5100P01NebokLabelListArgs(String jubsuDate, String drgBunho, String bunho)
		{
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01NebokLabelListRequest();
		}
	}
}