using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00DoctorExamStatusResult : AbstractContractResult
	{
		private String _doctorExamStatus;

		public String DoctorExamStatus
		{
			get { return this._doctorExamStatus; }
			set { this._doctorExamStatus = value; }
		}

		public NuroRES1001U00DoctorExamStatusResult() { }

	}
}