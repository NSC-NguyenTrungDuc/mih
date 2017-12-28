using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01DsvOrderPrintArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01DsvOrderPrintArgs other)
        {
            return string.Equals(_ioGobun, other._ioGobun) && string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01DsvOrderPrintArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_ioGobun != null ? _ioGobun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _ioGobun;
		private String _jubsuDate;
		private String _drgBunho;

		public String IoGobun
		{
			get { return this._ioGobun; }
			set { this._ioGobun = value; }
		}

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

		public DrgsDRG5100P01DsvOrderPrintArgs() { }

		public DrgsDRG5100P01DsvOrderPrintArgs(String ioGobun, String jubsuDate, String drgBunho)
		{
			this._ioGobun = ioGobun;
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01DsvOrderPrintRequest();
		}
	}
}