using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12GrdGeneralResult : AbstractContractResult
	{
		private List<OCS0103U12GrdGeneralInfo> _info1 = new List<OCS0103U12GrdGeneralInfo>();

		public List<OCS0103U12GrdGeneralInfo> Info1
		{
			get { return this._info1; }
			set { this._info1 = value; }
		}

		public OCS0103U12GrdGeneralResult() { }

	}
}