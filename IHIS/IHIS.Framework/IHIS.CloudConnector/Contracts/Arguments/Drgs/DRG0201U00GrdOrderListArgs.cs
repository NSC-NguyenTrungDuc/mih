using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00GrdOrderListArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00GrdOrderListArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00GrdOrderListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_jubsuDate != null ? _jubsuDate.GetHashCode() : 0)*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
            }
        }

        private String _jubsuDate;
		private String _drgBunho;

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

		public DRG0201U00GrdOrderListArgs() { }

		public DRG0201U00GrdOrderListArgs(String jubsuDate, String drgBunho)
		{
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00GrdOrderListRequest();
		}
	}
}