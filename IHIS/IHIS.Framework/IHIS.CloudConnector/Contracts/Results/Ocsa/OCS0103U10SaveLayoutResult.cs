using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10SaveLayoutResult : AbstractContractResult
	{
		private Boolean _success;
		private String _result;

		public Boolean Success
		{
			get { return this._success; }
			set { this._success = value; }
		}

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public OCS0103U10SaveLayoutResult() { }

	}
}