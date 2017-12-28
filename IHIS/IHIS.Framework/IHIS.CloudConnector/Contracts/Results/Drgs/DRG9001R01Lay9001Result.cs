using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9001R01Lay9001Result : AbstractContractResult
	{
		private List<DRG9001R02Lay9001Info> _lay9001Item = new List<DRG9001R02Lay9001Info>();

		public List<DRG9001R02Lay9001Info> Lay9001Item
		{
			get { return this._lay9001Item; }
			set { this._lay9001Item = value; }
		}

		public DRG9001R01Lay9001Result() { }

	}
}