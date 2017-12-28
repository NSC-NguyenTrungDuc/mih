using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13GrdSpecimenListResult : AbstractContractResult
	{
		private List<OCS0103U13GrdSpecimenListInfo> _grdSpecItem = new List<OCS0103U13GrdSpecimenListInfo>();

		public List<OCS0103U13GrdSpecimenListInfo> GrdSpecItem
		{
			get { return this._grdSpecItem; }
			set { this._grdSpecItem = value; }
		}

		public OCS0103U13GrdSpecimenListResult() { }

	}
}