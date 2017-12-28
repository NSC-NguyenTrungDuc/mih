using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0101U00CheckHangMogCopyArgs : IContractArgs
	{
        protected bool Equals(CPL0101U00CheckHangMogCopyArgs other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_specimenCode, other._specimenCode) && string.Equals(_newEmergency, other._newEmergency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00CheckHangMogCopyArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenCode != null ? _specimenCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_newEmergency != null ? _newEmergency.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hangmogCode;
		private String _specimenCode;
		private String _newEmergency;

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

		public String NewEmergency
		{
			get { return this._newEmergency; }
			set { this._newEmergency = value; }
		}

		public CPL0101U00CheckHangMogCopyArgs() { }

		public CPL0101U00CheckHangMogCopyArgs(String hangmogCode, String specimenCode, String newEmergency)
		{
			this._hangmogCode = hangmogCode;
			this._specimenCode = specimenCode;
			this._newEmergency = newEmergency;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0101U00CheckHangMogCopyRequest();
		}
	}
}