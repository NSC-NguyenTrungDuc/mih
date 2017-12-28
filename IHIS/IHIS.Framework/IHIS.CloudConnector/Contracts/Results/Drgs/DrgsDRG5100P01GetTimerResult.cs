using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01GetTimerResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public DrgsDRG5100P01GetTimerResult() { }

	}
}