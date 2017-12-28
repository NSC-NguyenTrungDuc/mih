using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00DsvUrineArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00DsvUrineArgs other)
        {
            return string.Equals(_specimenSer, other._specimenSer) && string.Equals(_fkocs, other._fkocs) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_gubun, other._gubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00DsvUrineArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkocs != null ? _fkocs.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenSer;
		private String _fkocs;
		private String _inOutGubun;
		private String _gubun;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public CPL3010U00DsvUrineArgs() { }

		public CPL3010U00DsvUrineArgs(String specimenSer, String fkocs, String inOutGubun, String gubun)
		{
			this._specimenSer = specimenSer;
			this._fkocs = fkocs;
			this._inOutGubun = inOutGubun;
			this._gubun = gubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00DsvUrineRequest();
		}
	}
}