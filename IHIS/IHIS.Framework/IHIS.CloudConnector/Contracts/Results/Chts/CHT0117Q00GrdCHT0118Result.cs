using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0117Q00GrdCHT0118Result : AbstractContractResult
	{
		private List<CHT0117Q00GrdCHT0118Info> _grd0118Info = new List<CHT0117Q00GrdCHT0118Info>();

		public List<CHT0117Q00GrdCHT0118Info> Grd0118Info
		{
			get { return this._grd0118Info; }
			set { this._grd0118Info = value; }
		}

		public CHT0117Q00GrdCHT0118Result() { }

	}
}