using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U04LoadExaminationArgs : IContractArgs
	{
    protected bool Equals(OCS2015U04LoadExaminationArgs other)
    {
        return string.Equals(_patientCode, other._patientCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U04LoadExaminationArgs) obj);
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

		public OCS2015U04LoadExaminationArgs() { }

		public OCS2015U04LoadExaminationArgs(String patientCode)
		{
			this._patientCode = patientCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04LoadExaminationRequest();
		}
	}
}