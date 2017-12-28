using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM103UGetFwkHospitalArgs : IContractArgs
    {
        protected bool Equals(ADM103UGetFwkHospitalArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM103UGetFwkHospitalArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ADM103UGetFwkHospitalArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM103UGetFwkHospitalRequest();
        }
    }
}