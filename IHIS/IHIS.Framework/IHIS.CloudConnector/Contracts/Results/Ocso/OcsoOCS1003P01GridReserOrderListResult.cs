using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01GridReserOrderListResult : AbstractContractResult
	{
		private List<OcsoOCS1003P01GridReserOrderListInfo> _gridReserOrderList = new List<OcsoOCS1003P01GridReserOrderListInfo>();

		public List<OcsoOCS1003P01GridReserOrderListInfo> GridReserOrderList
		{
			get { return this._gridReserOrderList; }
			set { this._gridReserOrderList = value; }
		}

		public OcsoOCS1003P01GridReserOrderListResult() { }

	}
}