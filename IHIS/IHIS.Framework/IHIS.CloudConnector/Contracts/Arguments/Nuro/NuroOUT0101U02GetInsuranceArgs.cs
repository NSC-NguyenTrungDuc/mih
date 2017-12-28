using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetInsuranceArgs : IContractArgs
	{
        protected bool Equals(NuroOUT0101U02GetInsuranceArgs other)
        {
            return string.Equals(_lawNo, other._lawNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetInsuranceArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_lawNo != null ? _lawNo.GetHashCode() : 0);
        }

        private String _lawNo;

		public String LawNo
		{
			get { return this._lawNo; }
			set { this._lawNo = value; }
		}

		public NuroOUT0101U02GetInsuranceArgs() { }

		public NuroOUT0101U02GetInsuranceArgs(String lawNo)
		{
			this._lawNo = lawNo;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT0101U02GetInsuranceRequest();
		}
	}
}