using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuts
{
    [Serializable]
	public class NUT0001U00LoadDoctorGwaArgs : IContractArgs
	{
        protected bool Equals(NUT0001U00LoadDoctorGwaArgs other)
        {
            return string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_pkocskey, other._pkocskey);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUT0001U00LoadDoctorGwaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_inOutGubun != null ? _inOutGubun.GetHashCode() : 0)*397) ^ (_pkocskey != null ? _pkocskey.GetHashCode() : 0);
            }
        }

        private String _inOutGubun;
		private String _pkocskey;

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public NUT0001U00LoadDoctorGwaArgs() { }

		public NUT0001U00LoadDoctorGwaArgs(String inOutGubun, String pkocskey)
		{
			this._inOutGubun = inOutGubun;
			this._pkocskey = pkocskey;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUT0001U00LoadDoctorGwaRequest();
		}
	}
}