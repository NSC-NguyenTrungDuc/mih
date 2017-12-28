using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class MultiResultViewGrdSigeyul2Args : IContractArgs
	{
        protected bool Equals(MultiResultViewGrdSigeyul2Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_groupHangmog, other._groupHangmog);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MultiResultViewGrdSigeyul2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_groupHangmog != null ? _groupHangmog.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _groupHangmog;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String GroupHangmog
		{
			get { return this._groupHangmog; }
			set { this._groupHangmog = value; }
		}

		public MultiResultViewGrdSigeyul2Args() { }

		public MultiResultViewGrdSigeyul2Args(String bunho, String groupHangmog)
		{
			this._bunho = bunho;
			this._groupHangmog = groupHangmog;
		}

		public IExtensible GetRequestInstance()
		{
			return new MultiResultViewGrdSigeyul2Request();
		}
	}
}