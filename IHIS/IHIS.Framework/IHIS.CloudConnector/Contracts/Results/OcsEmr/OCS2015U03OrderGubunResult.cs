using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U03OrderGubunResult : AbstractContractResult
	{
		private List<OCS2015U03OrderGubunInfo> _orderGubunList = new List<OCS2015U03OrderGubunInfo>();

		public List<OCS2015U03OrderGubunInfo> OrderGubunList
		{
			get { return this._orderGubunList; }
			set { this._orderGubunList = value; }
		}

		public OCS2015U03OrderGubunResult() { }

	}
}