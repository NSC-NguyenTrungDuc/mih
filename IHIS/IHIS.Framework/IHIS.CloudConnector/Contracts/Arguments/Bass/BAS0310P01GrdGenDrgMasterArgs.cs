using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0310P01GrdGenDrgMasterArgs : IContractArgs
    {
        protected bool Equals(BAS0310P01GrdGenDrgMasterArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310P01GrdGenDrgMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public BAS0310P01GrdGenDrgMasterArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0310P01GrdGenDrgMasterRequest();
        }
    }
}