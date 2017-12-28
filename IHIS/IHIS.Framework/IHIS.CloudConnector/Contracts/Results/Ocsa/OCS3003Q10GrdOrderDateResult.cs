using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS3003Q10GrdOrderDateResult : AbstractContractResult
	{
		private List<OCS3003Q10GrdOrderDateListItemInfo> _listInfo = new List<OCS3003Q10GrdOrderDateListItemInfo>();

		public List<OCS3003Q10GrdOrderDateListItemInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public OCS3003Q10GrdOrderDateResult() { }

	}
}