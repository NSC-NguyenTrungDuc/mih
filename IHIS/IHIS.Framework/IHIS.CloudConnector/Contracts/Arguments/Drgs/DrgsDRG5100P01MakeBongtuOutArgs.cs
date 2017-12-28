using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01MakeBongtuOutArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01MakeBongtuOutArgs other)
        {
            return string.Equals(_iSysDate, other._iSysDate) && string.Equals(_iUserId, other._iUserId) && string.Equals(_iOrderDate, other._iOrderDate) && string.Equals(_iJubsuDate, other._iJubsuDate) && string.Equals(_iJubsuTime, other._iJubsuTime) && string.Equals(_iDrgBunho, other._iDrgBunho) && string.Equals(_iWonyoiOrderYn, other._iWonyoiOrderYn) && string.Equals(_iJubsuYn, other._iJubsuYn) && string.Equals(_iGyunbonYn, other._iGyunbonYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01MakeBongtuOutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_iSysDate != null ? _iSysDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iUserId != null ? _iUserId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iOrderDate != null ? _iOrderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iJubsuDate != null ? _iJubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iJubsuTime != null ? _iJubsuTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iDrgBunho != null ? _iDrgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iWonyoiOrderYn != null ? _iWonyoiOrderYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iJubsuYn != null ? _iJubsuYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iGyunbonYn != null ? _iGyunbonYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _iSysDate;
		private String _iUserId;
		private String _iOrderDate;
		private String _iJubsuDate;
		private String _iJubsuTime;
		private String _iDrgBunho;
		private String _iWonyoiOrderYn;
		private String _iJubsuYn;
		private String _iGyunbonYn;

		public String ISysDate
		{
			get { return this._iSysDate; }
			set { this._iSysDate = value; }
		}

		public String IUserId
		{
			get { return this._iUserId; }
			set { this._iUserId = value; }
		}

		public String IOrderDate
		{
			get { return this._iOrderDate; }
			set { this._iOrderDate = value; }
		}

		public String IJubsuDate
		{
			get { return this._iJubsuDate; }
			set { this._iJubsuDate = value; }
		}

		public String IJubsuTime
		{
			get { return this._iJubsuTime; }
			set { this._iJubsuTime = value; }
		}

		public String IDrgBunho
		{
			get { return this._iDrgBunho; }
			set { this._iDrgBunho = value; }
		}

		public String IWonyoiOrderYn
		{
			get { return this._iWonyoiOrderYn; }
			set { this._iWonyoiOrderYn = value; }
		}

		public String IJubsuYn
		{
			get { return this._iJubsuYn; }
			set { this._iJubsuYn = value; }
		}

		public String IGyunbonYn
		{
			get { return this._iGyunbonYn; }
			set { this._iGyunbonYn = value; }
		}

		public DrgsDRG5100P01MakeBongtuOutArgs() { }

		public DrgsDRG5100P01MakeBongtuOutArgs(String iSysDate, String iUserId, String iOrderDate, String iJubsuDate, String iJubsuTime, String iDrgBunho, String iWonyoiOrderYn, String iJubsuYn, String iGyunbonYn)
		{
			this._iSysDate = iSysDate;
			this._iUserId = iUserId;
			this._iOrderDate = iOrderDate;
			this._iJubsuDate = iJubsuDate;
			this._iJubsuTime = iJubsuTime;
			this._iDrgBunho = iDrgBunho;
			this._iWonyoiOrderYn = iWonyoiOrderYn;
			this._iJubsuYn = iJubsuYn;
			this._iGyunbonYn = iGyunbonYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01MakeBongtuOutRequest();
		}
	}
}