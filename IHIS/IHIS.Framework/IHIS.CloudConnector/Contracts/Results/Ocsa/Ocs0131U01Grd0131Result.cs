using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class Ocs0131U01Grd0131Result : AbstractContractResult
	{
		private List<Ocs0131U01Grd0131ListItemInfo> _grd0131Info = new List<Ocs0131U01Grd0131ListItemInfo>();

		public List<Ocs0131U01Grd0131ListItemInfo> Grd0131Info
		{
			get { return this._grd0131Info; }
			set { this._grd0131Info = value; }
		}

		public Ocs0131U01Grd0131Result() { }

	}
}