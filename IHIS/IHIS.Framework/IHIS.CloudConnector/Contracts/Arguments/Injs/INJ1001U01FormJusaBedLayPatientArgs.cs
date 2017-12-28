using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01FormJusaBedLayPatientArgs : IContractArgs
	{
        protected bool Equals(INJ1001U01FormJusaBedLayPatientArgs other)
        {
            return string.Equals(_codeName, other._codeName) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01FormJusaBedLayPatientArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeName != null ? _codeName.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _codeName;
		private String _hospCode;

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public INJ1001U01FormJusaBedLayPatientArgs() { }

		public INJ1001U01FormJusaBedLayPatientArgs(String codeName, String hospCode)
		{
			this._codeName = codeName;
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01FormJusaBedLayPatientRequest();
		}
	}
}