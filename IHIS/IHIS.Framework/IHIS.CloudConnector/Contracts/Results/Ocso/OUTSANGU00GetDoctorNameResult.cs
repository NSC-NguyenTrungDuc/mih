using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OUTSANGU00GetDoctorNameResult : AbstractContractResult
	{
		private String _doctorName;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public OUTSANGU00GetDoctorNameResult() { }

	}
}