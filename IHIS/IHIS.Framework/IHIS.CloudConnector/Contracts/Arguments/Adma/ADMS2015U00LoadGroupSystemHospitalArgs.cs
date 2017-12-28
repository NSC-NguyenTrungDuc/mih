using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U00LoadGroupSystemHospitalArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U00LoadGroupSystemHospitalArgs other)
        {
            return string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U00LoadGroupSystemHospitalArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }

        private String _hospCode;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public ADMS2015U00LoadGroupSystemHospitalArgs() { }

		public ADMS2015U00LoadGroupSystemHospitalArgs(String hospCode)
		{
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U00LoadGroupSystemHospitalRequest();
		}
	}
}