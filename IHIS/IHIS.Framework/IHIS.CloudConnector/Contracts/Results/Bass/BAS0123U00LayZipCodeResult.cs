using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0123U00LayZipCodeResult : AbstractContractResult
	{
		private String _info;

		public String Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public BAS0123U00LayZipCodeResult() { }

	}
}