using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM501UJapanEmptyListArgs : IContractArgs
	{
        protected bool Equals(ADM501UJapanEmptyListArgs other)
        {
            return string.Equals(_msgGubun, other._msgGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM501UJapanEmptyListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_msgGubun != null ? _msgGubun.GetHashCode() : 0);
        }

        private String _msgGubun;

		public String MsgGubun
		{
			get { return this._msgGubun; }
			set { this._msgGubun = value; }
		}

		public ADM501UJapanEmptyListArgs() { }

		public ADM501UJapanEmptyListArgs(String msgGubun)
		{
			this._msgGubun = msgGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM501UJapanEmptyListRequest();
		}
	}
}