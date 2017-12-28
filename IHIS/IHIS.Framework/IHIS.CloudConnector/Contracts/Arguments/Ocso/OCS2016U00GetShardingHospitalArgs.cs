using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS2016U00GetShardingHospitalArgs : IContractArgs
    {
    protected bool Equals(OCS2016U00GetShardingHospitalArgs other)
    {
        return string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2016U00GetShardingHospitalArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hospCode != null ? _hospCode.GetHashCode() : 0);
    }

    private String _hospCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS2016U00GetShardingHospitalArgs() { }

        public OCS2016U00GetShardingHospitalArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2016U00GetShardingHospitalRequest();
        }
    }
}