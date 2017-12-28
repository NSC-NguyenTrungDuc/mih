using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U15LaySlipCodeTreeResult : AbstractContractResult
	{
		private List<OCS0103U15LaySlipCodeTreeInfo> _listItem = new List<OCS0103U15LaySlipCodeTreeInfo>();

		public List<OCS0103U15LaySlipCodeTreeInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public OCS0103U15LaySlipCodeTreeResult() { }

	}
}