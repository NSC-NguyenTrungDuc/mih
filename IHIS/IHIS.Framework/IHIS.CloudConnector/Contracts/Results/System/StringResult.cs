using System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class StringResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public StringResult() { }

	}
}