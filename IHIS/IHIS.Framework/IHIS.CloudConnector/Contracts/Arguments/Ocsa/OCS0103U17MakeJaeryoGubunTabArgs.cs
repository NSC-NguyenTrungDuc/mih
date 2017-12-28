using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U17MakeJaeryoGubunTabArgs : IContractArgs
	{
        protected bool Equals(OCS0103U17MakeJaeryoGubunTabArgs other)
        {
            return string.Equals(_inputTab, other._inputTab);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS0103U17MakeJaeryoGubunTabArgs) obj);
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

		public OCS0103U17MakeJaeryoGubunTabArgs() { }

		public OCS0103U17MakeJaeryoGubunTabArgs(String inputTab)
		{
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U17MakeJaeryoGubunTabRequest();
		}
	}
}