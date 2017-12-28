using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM501UKoreaListArgs : IContractArgs
	{
        protected bool Equals(ADM501UKoreaListArgs other)
        {
            return string.Equals(_msgGubun, other._msgGubun) && string.Equals(_searchMsg, other._searchMsg);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM501UKoreaListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_msgGubun != null ? _msgGubun.GetHashCode() : 0)*397) ^ (_searchMsg != null ? _searchMsg.GetHashCode() : 0);
            }
        }

        private String _msgGubun;
		private String _searchMsg;

		public String MsgGubun
		{
			get { return this._msgGubun; }
			set { this._msgGubun = value; }
		}

		public String SearchMsg
		{
			get { return this._searchMsg; }
			set { this._searchMsg = value; }
		}

		public ADM501UKoreaListArgs() { }

		public ADM501UKoreaListArgs(String msgGubun, String searchMsg)
		{
			this._msgGubun = msgGubun;
			this._searchMsg = searchMsg;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM501UKoreaListRequest();
		}
	}
}