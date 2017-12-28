using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetBirthDayArgs : IContractArgs
	{
        protected bool Equals(NuroOUT0101U02GetBirthDayArgs other)
        {
            return string.Equals(_sysDate, other._sysDate) && string.Equals(_birth, other._birth);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetBirthDayArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_sysDate != null ? _sysDate.GetHashCode() : 0)*397) ^ (_birth != null ? _birth.GetHashCode() : 0);
            }
        }

        private String _sysDate;
		private String _birth;

		public String SysDate
		{
			get { return this._sysDate; }
			set { this._sysDate = value; }
		}

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public NuroOUT0101U02GetBirthDayArgs() { }

		public NuroOUT0101U02GetBirthDayArgs(String sysDate, String birth)
		{
			this._sysDate = sysDate;
			this._birth = birth;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT0101U02GetBirthDayRequest();
		}
	}
}