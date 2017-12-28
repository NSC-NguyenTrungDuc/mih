using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0221U00CommonDataResult : AbstractContractResult
	{
		private List<OcsaOCS0221U00GrdOCS0221ListInfo> _gridItem = new List<OcsaOCS0221U00GrdOCS0221ListInfo>();

		public List<OcsaOCS0221U00GrdOCS0221ListInfo> GridItem
		{
			get { return this._gridItem; }
			set { this._gridItem = value; }
		}

		public OcsaOCS0221U00CommonDataResult() { }

	}
}