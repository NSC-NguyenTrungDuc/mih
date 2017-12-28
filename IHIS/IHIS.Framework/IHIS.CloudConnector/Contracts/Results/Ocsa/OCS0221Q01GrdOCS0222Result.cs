using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0221Q01GrdOCS0222Result : AbstractContractResult
	{
		private List<OCS0221Q01GrdOCS0222Info> _grdOCS0222Info = new List<OCS0221Q01GrdOCS0222Info>();

		public List<OCS0221Q01GrdOCS0222Info> GrdOCS0222Info
		{
			get { return this._grdOCS0222Info; }
			set { this._grdOCS0222Info = value; }
		}

		public OCS0221Q01GrdOCS0222Result() { }

	}
}