using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0310U00layGroupGubunCheckArgs : IContractArgs
	{
        protected bool Equals(BAS0310U00layGroupGubunCheckArgs other)
        {
            return string.Equals(_sgCode, other._sgCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00layGroupGubunCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_sgCode != null ? _sgCode.GetHashCode() : 0);
        }

        private String _sgCode;

		public String SgCode
		{
			get { return this._sgCode; }
			set { this._sgCode = value; }
		}

		public BAS0310U00layGroupGubunCheckArgs() { }

		public BAS0310U00layGroupGubunCheckArgs(String sgCode)
		{
			this._sgCode = sgCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0310U00layGroupGubunCheckRequest();
		}
	}
}