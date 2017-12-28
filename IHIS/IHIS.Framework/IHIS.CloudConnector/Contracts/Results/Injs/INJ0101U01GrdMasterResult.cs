using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ0101U01GrdMasterResult : AbstractContractResult
	{
		private List<INJ0101U01GrdMasterItemInfo> _grdMasterItemInfo = new List<INJ0101U01GrdMasterItemInfo>();

		public List<INJ0101U01GrdMasterItemInfo> GrdMasterItemInfo
		{
			get { return this._grdMasterItemInfo; }
			set { this._grdMasterItemInfo = value; }
		}

		public INJ0101U01GrdMasterResult() { }

	}
}