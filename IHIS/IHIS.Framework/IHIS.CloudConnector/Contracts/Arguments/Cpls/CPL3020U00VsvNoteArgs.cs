using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00VsvNoteArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00VsvNoteArgs other)
        {
            return string.Equals(_jundalGubun, other._jundalGubun) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00VsvNoteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_jundalGubun != null ? _jundalGubun.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
            }
        }

        private String _jundalGubun;
		private String _code;

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public CPL3020U00VsvNoteArgs() { }

		public CPL3020U00VsvNoteArgs(String jundalGubun, String code)
		{
			this._jundalGubun = jundalGubun;
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00VsvNoteRequest();
		}
	}
}