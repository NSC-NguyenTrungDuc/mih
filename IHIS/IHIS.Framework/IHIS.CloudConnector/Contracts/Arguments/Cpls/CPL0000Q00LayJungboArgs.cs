using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00LayJungboArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00LayJungboArgs other)
        {
            return string.Equals(_specimenSer, other._specimenSer) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_specimenCode, other._specimenCode) && string.Equals(_emergency, other._emergency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00LayJungboArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenCode != null ? _specimenCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_emergency != null ? _emergency.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenSer;
		private String _hangmogCode;
		private String _specimenCode;
		private String _emergency;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
		}

		public CPL0000Q00LayJungboArgs() { }

		public CPL0000Q00LayJungboArgs(String specimenSer, String hangmogCode, String specimenCode, String emergency)
		{
			this._specimenSer = specimenSer;
			this._hangmogCode = hangmogCode;
			this._specimenCode = specimenCode;
			this._emergency = emergency;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00LayJungboRequest();
		}
	}
}