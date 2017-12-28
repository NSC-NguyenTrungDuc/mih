using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ0101U00GrdDetailResult : AbstractContractResult
	{
		private List<INJ0101U00GrdDetailInfo> _listItem = new List<INJ0101U00GrdDetailInfo>();

		public List<INJ0101U00GrdDetailInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public INJ0101U00GrdDetailResult() { }

	}
}