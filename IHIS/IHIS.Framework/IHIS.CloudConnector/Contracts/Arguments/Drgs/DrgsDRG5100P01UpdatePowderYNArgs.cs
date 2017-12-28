using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01UpdatePowderYNArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01UpdatePowderYNArgs other)
        {
            return string.Equals(_powderYn, other._powderYn) && string.Equals(_fkocs1003, other._fkocs1003);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01UpdatePowderYNArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_powderYn != null ? _powderYn.GetHashCode() : 0)*397) ^ (_fkocs1003 != null ? _fkocs1003.GetHashCode() : 0);
            }
        }

        private String _powderYn;
		private String _fkocs1003;

		public String PowderYn
		{
			get { return this._powderYn; }
			set { this._powderYn = value; }
		}

		public String Fkocs1003
		{
			get { return this._fkocs1003; }
			set { this._fkocs1003 = value; }
		}

		public DrgsDRG5100P01UpdatePowderYNArgs() { }

		public DrgsDRG5100P01UpdatePowderYNArgs(String powderYn, String fkocs1003)
		{
			this._powderYn = powderYn;
			this._fkocs1003 = fkocs1003;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01UpdatePowderYNRequest();
		}
	}
}