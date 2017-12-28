using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM201UGrdDicMasterResult : AbstractContractResult
	{
		private List<ADM201UGrdDicMasterItemInfo> _grdDicMasterItemInfo = new List<ADM201UGrdDicMasterItemInfo>();

		public List<ADM201UGrdDicMasterItemInfo> GrdDicMasterItemInfo
		{
			get { return this._grdDicMasterItemInfo; }
			set { this._grdDicMasterItemInfo = value; }
		}

		public ADM201UGrdDicMasterResult() { }

	}
}