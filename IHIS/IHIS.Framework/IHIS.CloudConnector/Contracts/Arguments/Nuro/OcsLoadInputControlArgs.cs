using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OcsLoadInputControlArgs : IContractArgs
	{
        protected bool Equals(OcsLoadInputControlArgs other)
        {
            return string.Equals(_inputControl, other._inputControl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OcsLoadInputControlArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_inputControl != null ? _inputControl.GetHashCode() : 0);
        }

        private String _inputControl;

		public String InputControl
		{
			get { return this._inputControl; }
			set { this._inputControl = value; }
		}

		public OcsLoadInputControlArgs() { }

		public OcsLoadInputControlArgs(String inputControl)
		{
			this._inputControl = inputControl;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsLoadInputControlRequest();
		}
	}
}