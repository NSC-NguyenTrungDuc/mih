using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0108U00grdOCS0103Result : AbstractContractResult
	{
		private List<OCS0108U00grdOCS0103ItemInfo> _grdOcs0103 = new List<OCS0108U00grdOCS0103ItemInfo>();

		public List<OCS0108U00grdOCS0103ItemInfo> GrdOcs0103
		{
			get { return this._grdOcs0103; }
			set { this._grdOcs0103 = value; }
		}

		public OCS0108U00grdOCS0103Result() { }

	}
}