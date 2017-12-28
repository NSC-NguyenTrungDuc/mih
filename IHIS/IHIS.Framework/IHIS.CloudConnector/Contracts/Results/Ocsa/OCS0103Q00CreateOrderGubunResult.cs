using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103Q00CreateOrderGubunResult : AbstractContractResult
	{
		private List<OCS0103Q00CreateOrderGubunInfo> _orderGubunInfo = new List<OCS0103Q00CreateOrderGubunInfo>();

		public List<OCS0103Q00CreateOrderGubunInfo> OrderGubunInfo
		{
			get { return this._orderGubunInfo; }
			set { this._orderGubunInfo = value; }
		}

		public OCS0103Q00CreateOrderGubunResult() { }

	}
}