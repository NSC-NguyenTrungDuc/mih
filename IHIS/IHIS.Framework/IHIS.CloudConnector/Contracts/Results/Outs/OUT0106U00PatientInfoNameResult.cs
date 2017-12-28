using System;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
	public class OUT0106U00PatientInfoNameResult : AbstractContractResult
	{
		private String _patientInfoName;

		public String PatientInfoName
		{
			get { return this._patientInfoName; }
			set { this._patientInfoName = value; }
		}

		public OUT0106U00PatientInfoNameResult() { }

	}
}