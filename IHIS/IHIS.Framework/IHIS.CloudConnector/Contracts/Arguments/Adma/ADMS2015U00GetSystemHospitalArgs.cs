using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U00GetSystemHospitalArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U00GetSystemHospitalArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_groupId, other._groupId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U00GetSystemHospitalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_groupId != null ? _groupId.GetHashCode() : 0);
            }
        }

        private String _hospCode;
		private String _groupId;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String GroupId
		{
			get { return this._groupId; }
			set { this._groupId = value; }
		}

		public ADMS2015U00GetSystemHospitalArgs() { }

		public ADMS2015U00GetSystemHospitalArgs(String hospCode, String groupId)
		{
			this._hospCode = hospCode;
			this._groupId = groupId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U00GetSystemHospitalRequest();
		}
	}
}