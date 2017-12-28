using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U00LayBarCodeTempResult : AbstractContractResult
	{
		private List<CPL3010U00LayBarCodeTempListItemInfo> _layBarCodeTempItem = new List<CPL3010U00LayBarCodeTempListItemInfo>();

		public List<CPL3010U00LayBarCodeTempListItemInfo> LayBarCodeTempItem
		{
			get { return this._layBarCodeTempItem; }
			set { this._layBarCodeTempItem = value; }
		}

		public CPL3010U00LayBarCodeTempResult() { }

	}
}