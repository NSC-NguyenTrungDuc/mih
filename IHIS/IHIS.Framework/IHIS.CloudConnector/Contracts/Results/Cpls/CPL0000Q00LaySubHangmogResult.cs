using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySubHangmogResult : AbstractContractResult
	{
		private List<CPL0000Q00LaySubHangmogListItemInfo> _subHangmogItem = new List<CPL0000Q00LaySubHangmogListItemInfo>();

		public List<CPL0000Q00LaySubHangmogListItemInfo> SubHangmogItem
		{
			get { return this._subHangmogItem; }
			set { this._subHangmogItem = value; }
		}

		public CPL0000Q00LaySubHangmogResult() { }

	}
}