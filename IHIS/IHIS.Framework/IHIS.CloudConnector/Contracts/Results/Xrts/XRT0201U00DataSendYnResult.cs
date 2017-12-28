using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00DataSendYnResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public XRT0201U00DataSendYnResult() { }

	}
}