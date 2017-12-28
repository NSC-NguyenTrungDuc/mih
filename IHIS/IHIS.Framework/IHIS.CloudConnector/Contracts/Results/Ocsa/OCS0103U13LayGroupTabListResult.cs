using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13LayGroupTabListResult : AbstractContractResult
	{
		private List<OCS0103U13LayGroupTabListInfo> _layGroupTabItem = new List<OCS0103U13LayGroupTabListInfo>();

		public List<OCS0103U13LayGroupTabListInfo> LayGroupTabItem
		{
			get { return this._layGroupTabItem; }
			set { this._layGroupTabItem = value; }
		}

		public OCS0103U13LayGroupTabListResult() { }

	}
}