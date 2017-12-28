using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U14GrdSlipHangmogResult : AbstractContractResult
	{
		private List<OCS0103U14GrdSlipHangmogInfo> _slipHangmogItem = new List<OCS0103U14GrdSlipHangmogInfo>();

		public List<OCS0103U14GrdSlipHangmogInfo> SlipHangmogItem
		{
			get { return this._slipHangmogItem; }
			set { this._slipHangmogItem = value; }
		}

		public OCS0103U14GrdSlipHangmogResult() { }

	}
}