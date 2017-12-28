using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00FwkNoteGubunArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00FwkNoteGubunArgs other)
        {
            return string.Equals(_jundalGubun, other._jundalGubun) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00FwkNoteGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_jundalGubun != null ? _jundalGubun.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _jundalGubun;
		private String _find1;

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public CPL3020U00FwkNoteGubunArgs() { }

		public CPL3020U00FwkNoteGubunArgs(String jundalGubun, String find1)
		{
			this._jundalGubun = jundalGubun;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00FwkNoteGubunRequest();
		}
	}
}