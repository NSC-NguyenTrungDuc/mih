using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderTbxBarCodeArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00GrdOrderTbxBarCodeArgs other)
        {
            return string.Equals(_orerDate, other._orerDate) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00GrdOrderTbxBarCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_orerDate != null ? _orerDate.GetHashCode() : 0)*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
            }
        }

        private String _orerDate;
		private String _drgBunho;

		public String OrerDate
		{
			get { return this._orerDate; }
			set { this._orerDate = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public DRG0201U00GrdOrderTbxBarCodeArgs() { }

		public DRG0201U00GrdOrderTbxBarCodeArgs(String orerDate, String drgBunho)
		{
			this._orerDate = orerDate;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00GrdOrderTbxBarCodeRequest();
		}
	}
}