using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10GrdGeneralResult : AbstractContractResult
	{
		private List<OCS0103U10GrdGeneralInfo> _grdGenItem = new List<OCS0103U10GrdGeneralInfo>();

		public List<OCS0103U10GrdGeneralInfo> GrdGenItem
		{
			get { return this._grdGenItem; }
			set { this._grdGenItem = value; }
		}

		public OCS0103U10GrdGeneralResult() { }

	}
}