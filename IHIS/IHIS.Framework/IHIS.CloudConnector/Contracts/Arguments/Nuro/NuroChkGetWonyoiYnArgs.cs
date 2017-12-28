using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroChkGetWonyoiYnArgs : IContractArgs
	{
        protected bool Equals(NuroChkGetWonyoiYnArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_gongbiCode1, other._gongbiCode1) && string.Equals(_gongbiCode2, other._gongbiCode2) && string.Equals(_gongbiCode3, other._gongbiCode3) && string.Equals(_gongbiCode4, other._gongbiCode4);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroChkGetWonyoiYnArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gongbiCode1 != null ? _gongbiCode1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gongbiCode2 != null ? _gongbiCode2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gongbiCode3 != null ? _gongbiCode3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gongbiCode4 != null ? _gongbiCode4.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
		private String _gongbiCode1;
		private String _gongbiCode2;
		private String _gongbiCode3;
		private String _gongbiCode4;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String GongbiCode1
		{
			get { return this._gongbiCode1; }
			set { this._gongbiCode1 = value; }
		}

		public String GongbiCode2
		{
			get { return this._gongbiCode2; }
			set { this._gongbiCode2 = value; }
		}

		public String GongbiCode3
		{
			get { return this._gongbiCode3; }
			set { this._gongbiCode3 = value; }
		}

		public String GongbiCode4
		{
			get { return this._gongbiCode4; }
			set { this._gongbiCode4 = value; }
		}

		public NuroChkGetWonyoiYnArgs() { }

		public NuroChkGetWonyoiYnArgs(String gubun, String gongbiCode1, String gongbiCode2, String gongbiCode3, String gongbiCode4)
		{
			this._gubun = gubun;
			this._gongbiCode1 = gongbiCode1;
			this._gongbiCode2 = gongbiCode2;
			this._gongbiCode3 = gongbiCode3;
			this._gongbiCode4 = gongbiCode4;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroChkGetWonyoiYnRequest();
		}
	}
}