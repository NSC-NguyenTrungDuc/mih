using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13PrOcsApplyNdayOrderResult : AbstractContractResult
	{
		private Boolean _result;
		private String _outDataString;

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public String OutDataString
		{
			get { return this._outDataString; }
			set { this._outDataString = value; }
		}

		public OCS0103U13PrOcsApplyNdayOrderResult() { }

	}
}