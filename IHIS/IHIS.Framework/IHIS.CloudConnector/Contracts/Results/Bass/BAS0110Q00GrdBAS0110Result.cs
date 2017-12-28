using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0110Q00GrdBAS0110Result : AbstractContractResult
	{
		private List<BAS0110Q00GrdBAS0110ItemInfo> _grdBas0110ItemInfo = new List<BAS0110Q00GrdBAS0110ItemInfo>();

		public List<BAS0110Q00GrdBAS0110ItemInfo> GrdBas0110ItemInfo
		{
			get { return this._grdBas0110ItemInfo; }
			set { this._grdBas0110ItemInfo = value; }
		}

		public BAS0110Q00GrdBAS0110Result() { }

	}
}