using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Phys;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY0001U00GrdOCS0132Result : AbstractContractResult
	{
		private List<PHY0001U00GrdOCS0132Info> _grdInfo = new List<PHY0001U00GrdOCS0132Info>();

		public List<PHY0001U00GrdOCS0132Info> GrdInfo
		{
			get { return this._grdInfo; }
			set { this._grdInfo = value; }
		}

		public PHY0001U00GrdOCS0132Result() { }

	}
}