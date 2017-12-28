using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OcsEmrPatientReceptionHistoryListArgs : IContractArgs
	{
    protected bool Equals(OcsEmrPatientReceptionHistoryListArgs other)
    {
        return string.Equals(_patientCode, other._patientCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsEmrPatientReceptionHistoryListArgs) obj);
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

		public OcsEmrPatientReceptionHistoryListArgs() { }

		public OcsEmrPatientReceptionHistoryListArgs(String patientCode)
		{
			this._patientCode = patientCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsEmrPatientReceptionHistoryListRequest();
		}
	}
}