using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroChkGetBunhoBySujinResult : AbstractContractResult
	{
		private NuroChkGetBunhoBySujinInfo _itemInfo;

		public NuroChkGetBunhoBySujinInfo ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public NuroChkGetBunhoBySujinResult() { }

	}
}