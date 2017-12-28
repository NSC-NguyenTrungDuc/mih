using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class XPaInfoBoxArgs : IContractArgs
    {
    protected bool Equals(XPaInfoBoxArgs other)
    {
        return string.Equals(patientCode, other.patientCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XPaInfoBoxArgs) obj);
    }

    public override int GetHashCode()
    {
        return (patientCode != null ? patientCode.GetHashCode() : 0);
    }

    private String patientCode;

        public XPaInfoBoxArgs(string patientCode)
        {
            this.patientCode = patientCode;
        }

        public String PatientCode
        {
            get { return this.patientCode; }
            set { this.patientCode = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new XPaInfoBoxRequest();
        }
    }
}