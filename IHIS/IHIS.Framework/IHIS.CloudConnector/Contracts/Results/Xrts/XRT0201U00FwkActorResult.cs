using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00FwkActorResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _userItemInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> UserItemInfo
		{
			get { return this._userItemInfo; }
			set { this._userItemInfo = value; }
		}

		public XRT0201U00FwkActorResult() { }

	}
}