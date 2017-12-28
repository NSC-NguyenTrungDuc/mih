using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U16GrdSlipHangmogResult : AbstractContractResult
	{
		private List<OCS0103U16GrdSlipHangmogInfo> _slipHangmogItem = new List<OCS0103U16GrdSlipHangmogInfo>();

		public List<OCS0103U16GrdSlipHangmogInfo> SlipHangmogItem
		{
			get { return this._slipHangmogItem; }
			set { this._slipHangmogItem = value; }
		}

		public OCS0103U16GrdSlipHangmogResult() { }

	}
}