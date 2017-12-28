using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorNameResult : AbstractContractResult
	{
		private String _doctorName;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public NuroRES1001U00DoctorNameResult() { }

	}
}