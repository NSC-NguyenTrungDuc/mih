using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12GridColumnProtectModifyResult : AbstractContractResult
	{
		private String _cnt;

		public String Cnt
		{
			get { return this._cnt; }
			set { this._cnt = value; }
		}

		public OCS0103U12GridColumnProtectModifyResult() { }

	}
}