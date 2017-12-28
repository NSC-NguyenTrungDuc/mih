using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0101U04GrdDetailResult : AbstractContractResult
	{
		private List<BAS0101U04GrdDetailInfo> _grdDetailInfo = new List<BAS0101U04GrdDetailInfo>();

		public List<BAS0101U04GrdDetailInfo> GrdDetailInfo
		{
			get { return this._grdDetailInfo; }
			set { this._grdDetailInfo = value; }
		}

		public BAS0101U04GrdDetailResult() { }

	}
}