using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Phys;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY8002U00GrdQueryResult : AbstractContractResult
	{
		private List<PHY8002U00GrdQueryInfo> _grdInfo = new List<PHY8002U00GrdQueryInfo>();

		public List<PHY8002U00GrdQueryInfo> GrdInfo
		{
			get { return this._grdInfo; }
			set { this._grdInfo = value; }
		}

		public PHY8002U00GrdQueryResult() { }

	}
}