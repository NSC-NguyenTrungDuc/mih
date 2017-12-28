using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OcsOrderBizLoadComboDataSourceResult : AbstractContractResult
	{
		private List<OcsOrderBizLoadComboDataSourceListItemInfo> _result = new List<OcsOrderBizLoadComboDataSourceListItemInfo>();

		public List<OcsOrderBizLoadComboDataSourceListItemInfo> Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public OcsOrderBizLoadComboDataSourceResult() { }

	}
}