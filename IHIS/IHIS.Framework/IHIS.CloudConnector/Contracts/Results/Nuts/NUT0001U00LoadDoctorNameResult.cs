using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuts
{
    [Serializable]
	public class NUT0001U00LoadDoctorNameResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public NUT0001U00LoadDoctorNameResult() { }

	}
}