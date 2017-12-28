using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U16SlipCodeTreeResult : AbstractContractResult
	{
		private List<OCS0103U16SlipCodeTreeInfo> _slipCodeTreeItem = new List<OCS0103U16SlipCodeTreeInfo>();

		public List<OCS0103U16SlipCodeTreeInfo> SlipCodeTreeItem
		{
			get { return this._slipCodeTreeItem; }
			set { this._slipCodeTreeItem = value; }
		}

		public OCS0103U16SlipCodeTreeResult() { }

	}
}