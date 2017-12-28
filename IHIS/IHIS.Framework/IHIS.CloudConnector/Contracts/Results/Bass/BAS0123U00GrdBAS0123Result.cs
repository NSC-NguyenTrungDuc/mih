using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0123U00GrdBAS0123Result : AbstractContractResult
	{
		private List<BAS0123U00GrdBAS0123Info> _info = new List<BAS0123U00GrdBAS0123Info>();

		public List<BAS0123U00GrdBAS0123Info> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public BAS0123U00GrdBAS0123Result() { }

	}
}