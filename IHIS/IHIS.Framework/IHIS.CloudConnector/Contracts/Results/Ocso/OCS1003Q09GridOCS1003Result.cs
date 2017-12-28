using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003Q09GridOCS1003Result : AbstractContractResult
	{
		private List<OcsoOCS1003Q05OrderListItemInfo> _ridOcs1003Info = new List<OcsoOCS1003Q05OrderListItemInfo>();

		public List<OcsoOCS1003Q05OrderListItemInfo> RidOcs1003Info
		{
			get { return this._ridOcs1003Info; }
			set { this._ridOcs1003Info = value; }
		}

		public OCS1003Q09GridOCS1003Result() { }

	}
}