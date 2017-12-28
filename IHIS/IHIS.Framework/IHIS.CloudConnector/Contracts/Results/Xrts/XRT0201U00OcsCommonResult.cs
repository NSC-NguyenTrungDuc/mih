using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00OcsCommonResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _userNameItemInfo = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> UserNameItemInfo
		{
			get { return this._userNameItemInfo; }
			set { this._userNameItemInfo = value; }
		}

		public XRT0201U00OcsCommonResult() { }

	}
}