using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS3003Q10GrdSangResult : AbstractContractResult
	{
		private List<OCS3003Q10GrdSangListItemInfo> _listResult = new List<OCS3003Q10GrdSangListItemInfo>();

		public List<OCS3003Q10GrdSangListItemInfo> ListResult
		{
			get { return this._listResult; }
			set { this._listResult = value; }
		}

		public OCS3003Q10GrdSangResult() { }

	}
}