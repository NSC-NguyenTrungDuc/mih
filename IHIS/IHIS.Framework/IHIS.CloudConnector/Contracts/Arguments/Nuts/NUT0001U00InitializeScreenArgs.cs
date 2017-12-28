using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00InitializeScreenArgs : IContractArgs
	{
        protected bool Equals(NUT0001U00InitializeScreenArgs other)
        {
            return string.Equals(_doctorGwaName, other._doctorGwaName) && string.Equals(_gwaCode, other._gwaCode) && string.Equals(_pkocskey, other._pkocskey) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00InitializeScreenArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctorGwaName != null ? _doctorGwaName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwaCode != null ? _gwaCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkocskey != null ? _pkocskey.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctorGwaName;
		private String _gwaCode;
		private String _pkocskey;
		private String _inOutGubun;
		private String _hangmogCode;

		public String DoctorGwaName
		{
			get { return this._doctorGwaName; }
			set { this._doctorGwaName = value; }
		}

		public String GwaCode
		{
			get { return this._gwaCode; }
			set { this._gwaCode = value; }
		}

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public NUT0001U00InitializeScreenArgs() { }

		public NUT0001U00InitializeScreenArgs(String doctorGwaName, String gwaCode, String pkocskey, String inOutGubun, String hangmogCode)
		{
			this._doctorGwaName = doctorGwaName;
			this._gwaCode = gwaCode;
			this._pkocskey = pkocskey;
			this._inOutGubun = inOutGubun;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00InitializeScreenRequest();
		}
	}
}