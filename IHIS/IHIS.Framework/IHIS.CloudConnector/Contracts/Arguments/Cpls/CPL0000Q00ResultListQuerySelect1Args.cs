using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00ResultListQuerySelect1Args : IContractArgs
	{
        protected bool Equals(CPL0000Q00ResultListQuerySelect1Args other)
        {
            return string.Equals(_specimenSer, other._specimenSer) && string.Equals(_srlCode, other._srlCode) && string.Equals(_jundalGubun, other._jundalGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00ResultListQuerySelect1Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_srlCode != null ? _srlCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenSer;
		private String _srlCode;
		private String _jundalGubun;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String SrlCode
		{
			get { return this._srlCode; }
			set { this._srlCode = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public CPL0000Q00ResultListQuerySelect1Args() { }

		public CPL0000Q00ResultListQuerySelect1Args(String specimenSer, String srlCode, String jundalGubun)
		{
			this._specimenSer = specimenSer;
			this._srlCode = srlCode;
			this._jundalGubun = jundalGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00ResultListQuerySelect1Request();
		}
	}
}