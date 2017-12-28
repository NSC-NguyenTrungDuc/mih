using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00GrdResultArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00GrdResultArgs other)
        {
            return string.Equals(_specimenSer, other._specimenSer) && string.Equals(_labNo, other._labNo) && string.Equals(_jundalGubun, other._jundalGubun) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00GrdResultArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_labNo != null ? _labNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenSer;
		private String _labNo;
		private String _jundalGubun;
		private String _codeType;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String LabNo
		{
			get { return this._labNo; }
			set { this._labNo = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public CPL3020U00GrdResultArgs() { }

		public CPL3020U00GrdResultArgs(String specimenSer, String labNo, String jundalGubun, String codeType)
		{
			this._specimenSer = specimenSer;
			this._labNo = labNo;
			this._jundalGubun = jundalGubun;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00GrdResultRequest();
		}
	}
}