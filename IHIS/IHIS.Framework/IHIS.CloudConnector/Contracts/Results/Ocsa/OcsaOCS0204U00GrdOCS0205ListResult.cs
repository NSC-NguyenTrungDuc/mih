using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00GrdOCS0205ListResult : AbstractContractResult
	{
		private List<OcsaOCS0204U00GrdOCS0205ListInfo> _grd0205Item = new List<OcsaOCS0204U00GrdOCS0205ListInfo>();

		public List<OcsaOCS0204U00GrdOCS0205ListInfo> Grd0205Item
		{
			get { return this._grd0205Item; }
			set { this._grd0205Item = value; }
		}

		public OcsaOCS0204U00GrdOCS0205ListResult() { }

	}
}