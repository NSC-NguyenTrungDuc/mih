using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U14LaySlipCodeTreeResult : AbstractContractResult
	{
		private List<OCS0103U14LaySlipCodeTreeInfo> _slipCodeTreeItem = new List<OCS0103U14LaySlipCodeTreeInfo>();

		public List<OCS0103U14LaySlipCodeTreeInfo> SlipCodeTreeItem
		{
			get { return this._slipCodeTreeItem; }
			set { this._slipCodeTreeItem = value; }
		}

		public OCS0103U14LaySlipCodeTreeResult() { }

	}
}