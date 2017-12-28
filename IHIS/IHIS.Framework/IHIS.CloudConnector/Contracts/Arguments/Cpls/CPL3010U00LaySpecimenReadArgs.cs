using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00LaySpecimenReadArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00LaySpecimenReadArgs other)
        {
            return string.Equals(_specimenSer, other._specimenSer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00LaySpecimenReadArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
        }

        private String _specimenSer;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public CPL3010U00LaySpecimenReadArgs() { }

		public CPL3010U00LaySpecimenReadArgs(String specimenSer)
		{
			this._specimenSer = specimenSer;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00LaySpecimenReadRequest();
		}
	}
}