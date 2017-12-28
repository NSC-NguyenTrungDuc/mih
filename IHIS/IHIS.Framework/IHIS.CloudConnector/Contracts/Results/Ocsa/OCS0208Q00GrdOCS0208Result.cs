using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0208Q00GrdOCS0208Result : AbstractContractResult
	{
		private List<OCS0208Q00GrdOCS0208Info> _grdItemList = new List<OCS0208Q00GrdOCS0208Info>();

		public List<OCS0208Q00GrdOCS0208Info> GrdItemList
		{
			get { return this._grdItemList; }
			set { this._grdItemList = value; }
		}

		public OCS0208Q00GrdOCS0208Result() { }

	}
}