using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
	public class OUT0106U00PatientInfoNameArgs : IContractArgs
	{
    protected bool Equals(OUT0106U00PatientInfoNameArgs other)
    {
        return string.Equals(_patientInfo, other._patientInfo) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT0106U00PatientInfoNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_patientInfo != null ? _patientInfo.GetHashCode() : 0)*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
        }
    }

    private String _patientInfo;
		private String _naewonDate;

		public String PatientInfo
		{
			get { return this._patientInfo; }
			set { this._patientInfo = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public OUT0106U00PatientInfoNameArgs() { }

		public OUT0106U00PatientInfoNameArgs(String patientInfo, String naewonDate)
		{
			this._patientInfo = patientInfo;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUT0106U00PatientInfoNameRequest();
		}
	}
}