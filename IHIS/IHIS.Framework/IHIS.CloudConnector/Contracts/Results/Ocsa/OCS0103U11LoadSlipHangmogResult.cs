using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U11LoadSlipHangmogResult : AbstractContractResult
	{
		private List<OCS0103U11LoadSlipHangmogInfo> _slipHangmogInfo = new List<OCS0103U11LoadSlipHangmogInfo>();

		public List<OCS0103U11LoadSlipHangmogInfo> SlipHangmogInfo
		{
			get { return this._slipHangmogInfo; }
			set { this._slipHangmogInfo = value; }
		}

		public OCS0103U11LoadSlipHangmogResult() { }

	}
}