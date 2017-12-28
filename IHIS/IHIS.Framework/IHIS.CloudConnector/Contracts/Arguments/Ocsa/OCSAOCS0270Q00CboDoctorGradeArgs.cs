using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCSAOCS0270Q00CboDoctorGradeArgs : IContractArgs
    {
    protected bool Equals(OCSAOCS0270Q00CboDoctorGradeArgs other)
    {
        return string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAOCS0270Q00CboDoctorGradeArgs) obj);
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

        public OCSAOCS0270Q00CboDoctorGradeArgs() { }

        public OCSAOCS0270Q00CboDoctorGradeArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSAOCS0270Q00CboDoctorGradeRequest();
        }
    }
}