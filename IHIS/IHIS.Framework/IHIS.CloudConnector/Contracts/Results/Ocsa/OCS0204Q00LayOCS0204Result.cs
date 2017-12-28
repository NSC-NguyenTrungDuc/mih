using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0204Q00LayOCS0204Result : AbstractContractResult
	{
		private List<Ocs0204Q00GrdOcs0204ListItemInfo> _layOCS0204Info = new List<Ocs0204Q00GrdOcs0204ListItemInfo>();

		public List<Ocs0204Q00GrdOcs0204ListItemInfo> LayOCS0204Info
		{
			get { return this._layOCS0204Info; }
			set { this._layOCS0204Info = value; }
		}

		public OCS0204Q00LayOCS0204Result() { }

	}
}