using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0208U00CommonDataResult : AbstractContractResult
	{
		private List<OcsaOCS0208U00GrdOCS0208U00ListInfo> _listItem = new List<OcsaOCS0208U00GrdOCS0208U00ListInfo>();

		public List<OcsaOCS0208U00GrdOCS0208U00ListInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public OcsaOCS0208U00CommonDataResult() { }

	}
}