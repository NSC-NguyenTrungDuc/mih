using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12FbxJusaFindClickResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboResult = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboResult
		{
			get { return this._cboResult; }
			set { this._cboResult = value; }
		}

		public OCS0103U12FbxJusaFindClickResult() { }

	}
}