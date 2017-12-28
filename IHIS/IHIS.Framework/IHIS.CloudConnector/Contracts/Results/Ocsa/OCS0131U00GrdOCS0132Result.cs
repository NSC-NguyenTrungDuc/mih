using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0131U00GrdOCS0132Result : AbstractContractResult
	{
		private List<OCS0131U00GrdOCS0132Info> _grdOcs0132Info = new List<OCS0131U00GrdOCS0132Info>();

		public List<OCS0131U00GrdOCS0132Info> GrdOcs0132Info
		{
			get { return this._grdOcs0132Info; }
			set { this._grdOcs0132Info = value; }
		}

		public OCS0131U00GrdOCS0132Result() { }

	}
}