using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class Ocs0131U01Grd0132Result : AbstractContractResult
	{
		private List<Ocs0131U01Grd0132ListItemInfo> _grd0132Info = new List<Ocs0131U01Grd0132ListItemInfo>();

		public List<Ocs0131U01Grd0132ListItemInfo> Grd0132Info
		{
			get { return this._grd0132Info; }
			set { this._grd0132Info = value; }
		}

		public Ocs0131U01Grd0132Result() { }

	}
}