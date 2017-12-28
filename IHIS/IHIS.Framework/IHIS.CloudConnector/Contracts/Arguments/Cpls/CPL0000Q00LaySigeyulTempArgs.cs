using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySigeyulTempArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00LaySigeyulTempArgs other)
        {
            return string.Equals(_groupHangmog, other._groupHangmog) && string.Equals(_specimenCode, other._specimenCode) && string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00LaySigeyulTempArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_groupHangmog != null ? _groupHangmog.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenCode != null ? _specimenCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _groupHangmog;
		private String _specimenCode;
		private String _hangmogCode;

		public String GroupHangmog
		{
			get { return this._groupHangmog; }
			set { this._groupHangmog = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public CPL0000Q00LaySigeyulTempArgs() { }

		public CPL0000Q00LaySigeyulTempArgs(String groupHangmog, String specimenCode, String hangmogCode)
		{
			this._groupHangmog = groupHangmog;
			this._specimenCode = specimenCode;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00LaySigeyulTempRequest();
		}
	}
}