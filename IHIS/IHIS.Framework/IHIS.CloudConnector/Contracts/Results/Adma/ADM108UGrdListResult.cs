using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM108UGrdListResult : AbstractContractResult
	{
		private List<ADM108UGrdListItemInfo> _grdListItemInfo = new List<ADM108UGrdListItemInfo>();

		public List<ADM108UGrdListItemInfo> GrdListItemInfo
		{
			get { return this._grdListItemInfo; }
			set { this._grdListItemInfo = value; }
		}

		public ADM108UGrdListResult() { }

	}
}