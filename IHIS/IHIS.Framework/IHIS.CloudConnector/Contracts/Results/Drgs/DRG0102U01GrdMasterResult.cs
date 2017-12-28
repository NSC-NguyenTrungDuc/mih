using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0102U01GrdMasterResult : AbstractContractResult
	{
		private List<DRG0102U01GrdMasterItemInfo> _grdMasterItemInfo = new List<DRG0102U01GrdMasterItemInfo>();

		public List<DRG0102U01GrdMasterItemInfo> GrdMasterItemInfo
		{
			get { return this._grdMasterItemInfo; }
			set { this._grdMasterItemInfo = value; }
		}

		public DRG0102U01GrdMasterResult() { }

	}
}