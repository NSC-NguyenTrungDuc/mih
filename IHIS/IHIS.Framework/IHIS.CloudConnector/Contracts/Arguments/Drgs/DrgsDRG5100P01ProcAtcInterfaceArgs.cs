using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01ProcAtcInterfaceArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01ProcAtcInterfaceArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_dataDubun, other._dataDubun) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_sendYn, other._sendYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01ProcAtcInterfaceArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_dataDubun != null ? _dataDubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jubsuDate;
		private String _drgBunho;
		private String _dataDubun;
		private String _ioGubun;
		private String _bunho;
		private String _fkout1001;
		private String _sendYn;

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

		public String DataDubun
		{
			get { return this._dataDubun; }
			set { this._dataDubun = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Fkout1001
		{
			get { return this._fkout1001; }
			set { this._fkout1001 = value; }
		}

		public String SendYn
		{
			get { return this._sendYn; }
			set { this._sendYn = value; }
		}

		public DrgsDRG5100P01ProcAtcInterfaceArgs() { }

		public DrgsDRG5100P01ProcAtcInterfaceArgs(String jubsuDate, String drgBunho, String dataDubun, String ioGubun, String bunho, String fkout1001, String sendYn)
		{
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
			this._dataDubun = dataDubun;
			this._ioGubun = ioGubun;
			this._bunho = bunho;
			this._fkout1001 = fkout1001;
			this._sendYn = sendYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01ProcAtcInterfaceRequest();
		}
	}
}