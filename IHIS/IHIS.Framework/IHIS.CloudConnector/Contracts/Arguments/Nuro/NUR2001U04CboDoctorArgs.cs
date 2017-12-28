using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NUR2001U04CboDoctorArgs : IContractArgs
	{
        protected bool Equals(NUR2001U04CboDoctorArgs other)
        {
            return string.Equals(_gwa, other._gwa);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2001U04CboDoctorArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_gwa != null ? _gwa.GetHashCode() : 0);
        }

        private String _gwa;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public NUR2001U04CboDoctorArgs() { }

		public NUR2001U04CboDoctorArgs(String gwa)
		{
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR2001U04CboDoctorRequest();
		}
	}
}