using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0223U00CboSystemResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _info = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public OCS0223U00CboSystemResult() { }

	}
}