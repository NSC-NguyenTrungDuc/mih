using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM201UGrdDicDetailResult : AbstractContractResult
	{
		private List<ADM201UGrdDicDetailItemInfo> _grdDicDetailItemInfo = new List<ADM201UGrdDicDetailItemInfo>();

		public List<ADM201UGrdDicDetailItemInfo> GrdDicDetailItemInfo
		{
			get { return this._grdDicDetailItemInfo; }
			set { this._grdDicDetailItemInfo = value; }
		}

		public ADM201UGrdDicDetailResult() { }

	}
}