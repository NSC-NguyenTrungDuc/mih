using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0115Q00GrdScPostArgs : IContractArgs
	{
        protected bool Equals(CHT0115Q00GrdScPostArgs other)
        {
            return string.Equals(_susikDetailGubun, other._susikDetailGubun) && string.Equals(_susikName, other._susikName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q00GrdScPostArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_susikDetailGubun != null ? _susikDetailGubun.GetHashCode() : 0)*397) ^ (_susikName != null ? _susikName.GetHashCode() : 0);
            }
        }

        private String _susikDetailGubun;
		private String _susikName;

		public String SusikDetailGubun
		{
			get { return this._susikDetailGubun; }
			set { this._susikDetailGubun = value; }
		}

		public String SusikName
		{
			get { return this._susikName; }
			set { this._susikName = value; }
		}

		public CHT0115Q00GrdScPostArgs() { }

		public CHT0115Q00GrdScPostArgs(String susikDetailGubun, String susikName)
		{
			this._susikDetailGubun = susikDetailGubun;
			this._susikName = susikName;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0115Q00GrdScPostRequest();
		}
	}
}