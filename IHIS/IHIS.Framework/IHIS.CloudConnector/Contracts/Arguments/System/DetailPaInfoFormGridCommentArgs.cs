using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class DetailPaInfoFormGridCommentArgs : IContractArgs
    {
    protected bool Equals(DetailPaInfoFormGridCommentArgs other)
    {
        return string.Equals(_patientCode, other._patientCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DetailPaInfoFormGridCommentArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_patientCode != null ? _patientCode.GetHashCode() : 0);
    }

    private String _patientCode;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public DetailPaInfoFormGridCommentArgs() { }

        public DetailPaInfoFormGridCommentArgs(String patientCode)
        {
            this._patientCode = patientCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new DetailPaInfoFormGridCommentRequest();
        }
    }

}
