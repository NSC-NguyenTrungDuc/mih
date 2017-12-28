using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
	public class OCS2015U06OrderTypeComboResult : AbstractContractResult
	{
		private List<OCS2015U06OrderTypeComboInfo> _orderTypes = new List<OCS2015U06OrderTypeComboInfo>();

		public List<OCS2015U06OrderTypeComboInfo> OrderTypes
		{
			get { return this._orderTypes; }
			set { this._orderTypes = value; }
		}

		public OCS2015U06OrderTypeComboResult() { }

	}
}