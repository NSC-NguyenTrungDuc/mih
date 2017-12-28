using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00GetSigeyulDataSelect2Args : IContractArgs
	{
        protected bool Equals(CPL0000Q00GetSigeyulDataSelect2Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_jubsuTime, other._jubsuTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00GetSigeyulDataSelect2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _hangmogCode;
		private String _jubsuDate;
		private String _jubsuTime;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public CPL0000Q00GetSigeyulDataSelect2Args() { }

		public CPL0000Q00GetSigeyulDataSelect2Args(String bunho, String hangmogCode, String jubsuDate, String jubsuTime)
		{
			this._bunho = bunho;
			this._hangmogCode = hangmogCode;
			this._jubsuDate = jubsuDate;
			this._jubsuTime = jubsuTime;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00GetSigeyulDataSelect2Request();
		}
	}
}