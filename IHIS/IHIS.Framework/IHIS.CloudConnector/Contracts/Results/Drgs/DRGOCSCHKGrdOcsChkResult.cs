using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRGOCSCHKGrdOcsChkResult : AbstractContractResult
	{
		private List<DRGOCSCHKGrdOcsChkInfo> _listItem = new List<DRGOCSCHKGrdOcsChkInfo>();

		public List<DRGOCSCHKGrdOcsChkInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public DRGOCSCHKGrdOcsChkResult() { }

	}
}