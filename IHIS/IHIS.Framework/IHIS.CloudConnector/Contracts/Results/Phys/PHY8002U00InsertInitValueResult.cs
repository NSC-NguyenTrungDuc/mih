using System;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY8002U00InsertInitValueResult : AbstractContractResult
	{
		private String _tChk;
		private String _retVal;

		public String TChk
		{
			get { return this._tChk; }
			set { this._tChk = value; }
		}

		public String RetVal
		{
			get { return this._retVal; }
			set { this._retVal = value; }
		}

		public PHY8002U00InsertInitValueResult() { }

	}
}