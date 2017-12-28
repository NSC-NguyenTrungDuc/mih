using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OcsLoadInputAndVisibleControlArgs : IContractArgs
    {
        private String _inputControl;
        private String _inputTab;

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        protected bool Equals(OcsLoadInputAndVisibleControlArgs other)
        {
            return string.Equals(_inputControl, other._inputControl) && string.Equals(_inputTab, other._inputTab);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OcsLoadInputAndVisibleControlArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_inputControl != null ? _inputControl.GetHashCode() : 0)*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public OcsLoadInputAndVisibleControlArgs() { }

        public OcsLoadInputAndVisibleControlArgs(String inputControl, String inputTab)
        {
            this._inputControl = inputControl;
            this._inputTab = inputTab;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OcsLoadInputAndVisibleControlRequest();
        }
    }
}