using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0131U00GrdOCS0131Result : AbstractContractResult
	{
		private List<OCS0131U00GrdOCS0131Info> _grdOcs0131Info = new List<OCS0131U00GrdOCS0131Info>();

		public List<OCS0131U00GrdOCS0131Info> GrdOcs0131Info
		{
			get { return this._grdOcs0131Info; }
			set { this._grdOcs0131Info = value; }
		}

		public OCS0131U00GrdOCS0131Result() { }

	}
}