using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00GetPrintNameResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _addr = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> Addr
		{
			get { return this._addr; }
			set { this._addr = value; }
		}

		public CPL3010U00GetPrintNameResult() { }

	}
}