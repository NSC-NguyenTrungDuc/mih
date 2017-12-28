using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroMakeDeptComboArgs : IContractArgs
    {
        protected bool Equals(NuroMakeDeptComboArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroMakeDeptComboArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public NuroMakeDeptComboArgs()
        {
            
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroMakeDeptComboRequest();
        }
    }
}
