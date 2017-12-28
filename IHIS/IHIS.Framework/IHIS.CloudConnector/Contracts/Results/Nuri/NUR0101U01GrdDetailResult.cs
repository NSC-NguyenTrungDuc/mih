using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR0101U01GrdDetailResult : AbstractContractResult
	{
		private List<NUR0101U01GrdDetailInfo> _grdDetailInfo = new List<NUR0101U01GrdDetailInfo>();

		public List<NUR0101U01GrdDetailInfo> GrdDetailInfo
		{
			get { return this._grdDetailInfo; }
			set { this._grdDetailInfo = value; }
		}

		public NUR0101U01GrdDetailResult() { }

	}
}