using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0108U00grdOCS0108Result : AbstractContractResult
	{
		private List<OCS0108U00grdOCS0108ItemInfo> _grdOcs0108 = new List<OCS0108U00grdOCS0108ItemInfo>();

		public List<OCS0108U00grdOCS0108ItemInfo> GrdOcs0108
		{
			get { return this._grdOcs0108; }
			set { this._grdOcs0108 = value; }
		}

		public OCS0108U00grdOCS0108Result() { }

	}
}