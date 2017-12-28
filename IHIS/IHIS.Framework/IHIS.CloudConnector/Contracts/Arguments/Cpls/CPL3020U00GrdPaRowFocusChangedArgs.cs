using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00GrdPaRowFocusChangedArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00GrdPaRowFocusChangedArgs other)
        {
            return string.Equals(_specimentSer, other._specimentSer) && string.Equals(_specimenSer, other._specimenSer) && string.Equals(_jundalGubun, other._jundalGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00GrdPaRowFocusChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimentSer != null ? _specimentSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimentSer;
		private String _specimenSer;
		private String _jundalGubun;

		public String SpecimentSer
		{
			get { return this._specimentSer; }
			set { this._specimentSer = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public CPL3020U00GrdPaRowFocusChangedArgs() { }

		public CPL3020U00GrdPaRowFocusChangedArgs(String specimentSer, String specimenSer, String jundalGubun)
		{
			this._specimentSer = specimentSer;
			this._specimenSer = specimenSer;
			this._jundalGubun = jundalGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00GrdPaRowFocusChangedRequest();
		}
	}
}