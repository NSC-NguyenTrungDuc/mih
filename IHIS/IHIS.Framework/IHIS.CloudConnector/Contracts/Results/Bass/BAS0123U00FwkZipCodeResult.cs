using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0123U00FwkZipCodeResult : AbstractContractResult
	{
		private List<BAS0123U00FwkZipCodeInfo> _info = new List<BAS0123U00FwkZipCodeInfo>();

		public List<BAS0123U00FwkZipCodeInfo> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public BAS0123U00FwkZipCodeResult() { }

	}
}