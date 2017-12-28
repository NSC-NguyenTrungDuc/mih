using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00LayJungboResult : AbstractContractResult
	{
		private List<CPL0000Q00LayJungboListItemInfo> _jungboItem = new List<CPL0000Q00LayJungboListItemInfo>();

		public List<CPL0000Q00LayJungboListItemInfo> JungboItem
		{
			get { return this._jungboItem; }
			set { this._jungboItem = value; }
		}

		public CPL0000Q00LayJungboResult() { }

	}
}