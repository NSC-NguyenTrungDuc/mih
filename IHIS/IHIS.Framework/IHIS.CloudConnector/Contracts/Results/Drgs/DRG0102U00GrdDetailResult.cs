using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0102U00GrdDetailResult : AbstractContractResult
	{
		private List<DRG0102U00GrdDetailInfo> _listInfo = new List<DRG0102U00GrdDetailInfo>();

		public List<DRG0102U00GrdDetailInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public DRG0102U00GrdDetailResult() { }

	}
}