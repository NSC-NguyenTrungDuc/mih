using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OcsLoadVisibleControlArgs : IContractArgs
	{
        protected bool Equals(OcsLoadVisibleControlArgs other)
        {
            return string.Equals(_inputTab, other._inputTab);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OcsLoadVisibleControlArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_inputTab != null ? _inputTab.GetHashCode() : 0);
        }

        private String _inputTab;

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public OcsLoadVisibleControlArgs() { }

		public OcsLoadVisibleControlArgs(String inputTab)
		{
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsLoadVisibleControlRequest();
		}
	}
}