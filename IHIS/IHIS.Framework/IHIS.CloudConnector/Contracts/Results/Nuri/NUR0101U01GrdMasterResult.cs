using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR0101U01GrdMasterResult : AbstractContractResult
	{
		private List<NUR0101U01GrdMasterInfo> _grdMasterInfo = new List<NUR0101U01GrdMasterInfo>();

		public List<NUR0101U01GrdMasterInfo> GrdMasterInfo
		{
			get { return this._grdMasterInfo; }
			set { this._grdMasterInfo = value; }
		}

		public NUR0101U01GrdMasterResult() { }

	}
}