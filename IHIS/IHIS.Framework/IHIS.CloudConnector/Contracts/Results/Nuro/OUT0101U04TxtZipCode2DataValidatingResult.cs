using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT0101U04TxtZipCode2DataValidatingResult : AbstractContractResult
	{
		private String _retVal;

		public String RetVal
		{
			get { return this._retVal; }
			set { this._retVal = value; }
		}

		public OUT0101U04TxtZipCode2DataValidatingResult() { }

	}
}