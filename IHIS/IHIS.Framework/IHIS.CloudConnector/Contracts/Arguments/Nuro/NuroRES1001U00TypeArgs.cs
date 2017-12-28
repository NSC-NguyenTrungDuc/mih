using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00TypeArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00TypeArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_departmentCode, other._departmentCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00TypeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0)*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
            }
        }

        private String _patientCode;
		private String _departmentCode;

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String DepartmentCode
		{
			get { return this._departmentCode; }
			set { this._departmentCode = value; }
		}

		public NuroRES1001U00TypeArgs() { }

		public NuroRES1001U00TypeArgs(String patientCode, String departmentCode)
		{
			this._patientCode = patientCode;
			this._departmentCode = departmentCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00TypeRequest();
		}
	}
}