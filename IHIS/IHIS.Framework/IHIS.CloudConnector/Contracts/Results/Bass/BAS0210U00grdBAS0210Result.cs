using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210Result : AbstractContractResult
	{
		private List<BAS0210U00grdBAS0210ItemInfo> _grdBas0210 = new List<BAS0210U00grdBAS0210ItemInfo>();

		public List<BAS0210U00grdBAS0210ItemInfo> GrdBas0210
		{
			get { return this._grdBas0210; }
			set { this._grdBas0210 = value; }
		}

		public BAS0210U00grdBAS0210Result() { }

	}
}