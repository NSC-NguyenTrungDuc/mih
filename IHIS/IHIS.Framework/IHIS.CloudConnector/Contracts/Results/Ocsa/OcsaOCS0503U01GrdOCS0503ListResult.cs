using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0503U01GrdOCS0503ListResult : AbstractContractResult
	{
		private List<OcsaOCS0503U01GrdOCS0503ListInfo> _gridListItem = new List<OcsaOCS0503U01GrdOCS0503ListInfo>();

		public List<OcsaOCS0503U01GrdOCS0503ListInfo> GridListItem
		{
			get { return this._gridListItem; }
			set { this._gridListItem = value; }
		}

		public OcsaOCS0503U01GrdOCS0503ListResult() { }

	}
}