using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG9040U01GrdJUSAOrderListArgs : IContractArgs
	{
        protected bool Equals(DRG9040U01GrdJUSAOrderListArgs other)
        {
            return string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_magamBunryu, other._magamBunryu);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG9040U01GrdJUSAOrderListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_magamBunryu != null ? _magamBunryu.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jubsuDate;
		private String _drgBunho;
		private String _magamBunryu;

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

		public String MagamBunryu
		{
			get { return this._magamBunryu; }
			set { this._magamBunryu = value; }
		}

		public DRG9040U01GrdJUSAOrderListArgs() { }

		public DRG9040U01GrdJUSAOrderListArgs(String jubsuDate, String drgBunho, String magamBunryu)
		{
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
			this._magamBunryu = magamBunryu;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG9040U01GrdJUSAOrderListRequest();
		}
	}
}