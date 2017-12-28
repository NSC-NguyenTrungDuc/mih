using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0109U00GrdDetailResult : AbstractContractResult
	{
		private List<SCH0109U00GrdDetailInfo> _grdDetailList = new List<SCH0109U00GrdDetailInfo>();

		public List<SCH0109U00GrdDetailInfo> GrdDetailList
		{
			get { return this._grdDetailList; }
			set { this._grdDetailList = value; }
		}

		public SCH0109U00GrdDetailResult() { }

	}
}