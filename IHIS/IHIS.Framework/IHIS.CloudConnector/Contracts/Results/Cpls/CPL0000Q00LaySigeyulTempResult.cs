using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySigeyulTempResult : AbstractContractResult
	{
		private List<CPL0000Q00LaySigeyulTempListItemInfo> _sigeyulTempItem = new List<CPL0000Q00LaySigeyulTempListItemInfo>();

		public List<CPL0000Q00LaySigeyulTempListItemInfo> SigeyulTempItem
		{
			get { return this._sigeyulTempItem; }
			set { this._sigeyulTempItem = value; }
		}

		public CPL0000Q00LaySigeyulTempResult() { }

	}
}