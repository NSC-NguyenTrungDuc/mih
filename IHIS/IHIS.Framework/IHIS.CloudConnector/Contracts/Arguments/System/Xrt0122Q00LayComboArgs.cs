using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class Xrt0122Q00LayComboArgs : IContractArgs
    {
        protected bool Equals(Xrt0122Q00LayComboArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Xrt0122Q00LayComboArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public Xrt0122Q00LayComboArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Xrt0122Q00LayComboRequest();
        }
    }
}