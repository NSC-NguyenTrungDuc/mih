using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00GrdPartArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00GrdPartArgs other)
        {
            return string.Equals(_partJubsuDate, other._partJubsuDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00GrdPartArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_partJubsuDate != null ? _partJubsuDate.GetHashCode() : 0);
        }

        private String _partJubsuDate;

		public String PartJubsuDate
		{
			get { return this._partJubsuDate; }
			set { this._partJubsuDate = value; }
		}

		public CPL3010U00GrdPartArgs() { }

		public CPL3010U00GrdPartArgs(String partJubsuDate)
		{
			this._partJubsuDate = partJubsuDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00GrdPartRequest();
		}
	}
}