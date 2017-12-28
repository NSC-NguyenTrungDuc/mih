using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRes0102u00InitCboListItemResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _gwaItem = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _avgTime = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> GwaItem
		{
			get { return this._gwaItem; }
			set { this._gwaItem = value; }
		}

		public List<ComboListItemInfo> AvgTime
		{
			get { return this._avgTime; }
			set { this._avgTime = value; }
		}

		public NuroRes0102u00InitCboListItemResult() { }

	}
}