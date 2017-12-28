using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0113U00LaySlipInfoResult : AbstractContractResult
	{
		private List<OCS0113U00LaySlipListItemInfo> _listLaySlipInfo = new List<OCS0113U00LaySlipListItemInfo>();

		public List<OCS0113U00LaySlipListItemInfo> ListLaySlipInfo
		{
			get { return this._listLaySlipInfo; }
			set { this._listLaySlipInfo = value; }
		}

		public OCS0113U00LaySlipInfoResult() { }

	}
}