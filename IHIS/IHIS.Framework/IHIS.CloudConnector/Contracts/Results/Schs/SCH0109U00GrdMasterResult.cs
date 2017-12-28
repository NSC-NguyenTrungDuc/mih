using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0109U00GrdMasterResult : AbstractContractResult
	{
		private List<SCH0109U00GrdMasterInfo> _grdMasterList = new List<SCH0109U00GrdMasterInfo>();

		public List<SCH0109U00GrdMasterInfo> GrdMasterList
		{
			get { return this._grdMasterList; }
			set { this._grdMasterList = value; }
		}

		public SCH0109U00GrdMasterResult() { }

	}
}