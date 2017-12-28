using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00GrdJukyongDateResult : AbstractContractResult
	{
		private List<SCH3001U00GrdJukyongDateInfo> _grdJukyongDateList = new List<SCH3001U00GrdJukyongDateInfo>();

		public List<SCH3001U00GrdJukyongDateInfo> GrdJukyongDateList
		{
			get { return this._grdJukyongDateList; }
			set { this._grdJukyongDateList = value; }
		}

		public SCH3001U00GrdJukyongDateResult() { }

	}
}