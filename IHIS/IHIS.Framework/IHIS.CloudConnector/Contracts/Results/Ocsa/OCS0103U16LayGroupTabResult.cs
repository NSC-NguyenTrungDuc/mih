using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U16LayGroupTabResult : AbstractContractResult
	{
		private List<OCS0103U16LayGroupTabInfo> _groupTabItem = new List<OCS0103U16LayGroupTabInfo>();

		public List<OCS0103U16LayGroupTabInfo> GroupTabItem
		{
			get { return this._groupTabItem; }
			set { this._groupTabItem = value; }
		}

		public OCS0103U16LayGroupTabResult() { }

	}
}