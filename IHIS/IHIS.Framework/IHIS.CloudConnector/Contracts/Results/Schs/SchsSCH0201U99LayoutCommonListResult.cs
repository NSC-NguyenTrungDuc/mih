using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99LayoutCommonListResult : AbstractContractResult
	{
		private List<SchsSCH0201U99LayoutCommonListInfo> _commonList = new List<SchsSCH0201U99LayoutCommonListInfo>();

		public List<SchsSCH0201U99LayoutCommonListInfo> CommonList
		{
			get { return this._commonList; }
			set { this._commonList = value; }
		}

		public SchsSCH0201U99LayoutCommonListResult() { }

	}
}