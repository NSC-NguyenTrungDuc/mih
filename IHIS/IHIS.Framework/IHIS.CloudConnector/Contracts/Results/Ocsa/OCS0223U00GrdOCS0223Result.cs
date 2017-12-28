using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0223U00GrdOCS0223Result : AbstractContractResult
	{
		private List<OCS0223U00GrdOCS0223Info> _info = new List<OCS0223U00GrdOCS0223Info>();

		public List<OCS0223U00GrdOCS0223Info> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public OCS0223U00GrdOCS0223Result() { }

	}
}