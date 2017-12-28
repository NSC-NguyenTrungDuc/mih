using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0113Q00GrdCHT0113Result : AbstractContractResult
	{
		private List<CHT0113Q00GrdCHT0113Info> _grdCHT0113Info = new List<CHT0113Q00GrdCHT0113Info>();

		public List<CHT0113Q00GrdCHT0113Info> GrdCHT0113Info
		{
			get { return this._grdCHT0113Info; }
			set { this._grdCHT0113Info = value; }
		}

		public CHT0113Q00GrdCHT0113Result() { }

	}
}