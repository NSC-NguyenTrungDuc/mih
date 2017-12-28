using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00LayBarCodeTemp2Result : AbstractContractResult
	{
		private List<CPL3010U00LayBarCodeTemp2ListItemInfo> _layBarCodeTemp2 = new List<CPL3010U00LayBarCodeTemp2ListItemInfo>();

		public List<CPL3010U00LayBarCodeTemp2ListItemInfo> LayBarCodeTemp2
		{
			get { return this._layBarCodeTemp2; }
			set { this._layBarCodeTemp2 = value; }
		}

		public CPL3010U00LayBarCodeTemp2Result() { }

	}
}