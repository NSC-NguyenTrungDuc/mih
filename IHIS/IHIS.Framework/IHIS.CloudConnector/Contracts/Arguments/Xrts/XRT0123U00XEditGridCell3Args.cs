using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{
    [Serializable]
    public class XRT0123U00XEditGridCell3Args : IContractArgs
    {
        protected bool Equals(XRT0123U00XEditGridCell3Args other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((XRT0123U00XEditGridCell3Args) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public XRT0123U00XEditGridCell3Args() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0123U00XEditGridCell3Request();
        }
    }
}