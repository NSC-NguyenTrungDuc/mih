using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0108U00laySlipResult : AbstractContractResult
	{
		private List<OCS0108U00laySlipItemInfo> _laySlip = new List<OCS0108U00laySlipItemInfo>();

		public List<OCS0108U00laySlipItemInfo> LaySlip
		{
			get { return this._laySlip; }
			set { this._laySlip = value; }
		}

		public OCS0108U00laySlipResult() { }

	}
}