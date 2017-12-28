using System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class StoredProcedureResult : AbstractContractResult
	{
		private Boolean _result;

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public StoredProcedureResult() { }

	}
}