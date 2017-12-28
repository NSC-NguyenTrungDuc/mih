using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM401UGrdSysResult : AbstractContractResult
	{
		private List<ADM401UGrdSysItemInfo> _grdSysItemInfo = new List<ADM401UGrdSysItemInfo>();

		public List<ADM401UGrdSysItemInfo> GrdSysItemInfo
		{
			get { return this._grdSysItemInfo; }
			set { this._grdSysItemInfo = value; }
		}

		public ADM401UGrdSysResult() { }

	}
}