using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT1001P01GrdOUT1001Result : AbstractContractResult
	{
		private List<OUT1001P01GrdOUT1001ListItemInfo> _grdOUT1001List = new List<OUT1001P01GrdOUT1001ListItemInfo>();

		public List<OUT1001P01GrdOUT1001ListItemInfo> GrdOUT1001List
		{
			get { return this._grdOUT1001List; }
			set { this._grdOUT1001List = value; }
		}

		public OUT1001P01GrdOUT1001Result() { }

	}
}