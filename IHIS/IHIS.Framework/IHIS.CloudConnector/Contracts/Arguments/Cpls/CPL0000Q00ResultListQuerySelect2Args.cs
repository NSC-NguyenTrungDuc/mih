using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00ResultListQuerySelect2Args : IContractArgs
	{
        protected bool Equals(CPL0000Q00ResultListQuerySelect2Args other)
        {
            return string.Equals(_specimenSer, other._specimenSer) && string.Equals(_kyunCode, other._kyunCode) && string.Equals(_serial, other._serial);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00ResultListQuerySelect2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_kyunCode != null ? _kyunCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_serial != null ? _serial.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenSer;
		private String _kyunCode;
		private String _serial;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String KyunCode
		{
			get { return this._kyunCode; }
			set { this._kyunCode = value; }
		}

		public String Serial
		{
			get { return this._serial; }
			set { this._serial = value; }
		}

		public CPL0000Q00ResultListQuerySelect2Args() { }

		public CPL0000Q00ResultListQuerySelect2Args(String specimenSer, String kyunCode, String serial)
		{
			this._specimenSer = specimenSer;
			this._kyunCode = kyunCode;
			this._serial = serial;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00ResultListQuerySelect2Request();
		}
	}
}