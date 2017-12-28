using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0204Q00GrdOCS0205Result : AbstractContractResult
	{
		private List<Ocs0204Q00GrdOcs0205ListItemInfo> _grdocs0205Info = new List<Ocs0204Q00GrdOcs0205ListItemInfo>();

		public List<Ocs0204Q00GrdOcs0205ListItemInfo> Grdocs0205Info
		{
			get { return this._grdocs0205Info; }
			set { this._grdocs0205Info = value; }
		}

		public OCS0204Q00GrdOCS0205Result() { }

	}
}