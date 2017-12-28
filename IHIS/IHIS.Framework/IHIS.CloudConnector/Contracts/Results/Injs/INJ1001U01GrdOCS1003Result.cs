using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01GrdOCS1003Result : AbstractContractResult
	{
		private List<INJ1001U01GrdOCS1003ItemInfo> _grdOcs1003Item = new List<INJ1001U01GrdOCS1003ItemInfo>();

		public List<INJ1001U01GrdOCS1003ItemInfo> GrdOcs1003Item
		{
			get { return this._grdOcs1003Item; }
			set { this._grdOcs1003Item = value; }
		}

		public INJ1001U01GrdOCS1003Result() { }

	}
}