using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0101U00InitResult : AbstractContractResult
	{
		private List<CPL0101U00InitListItemInfo> _initInfo = new List<CPL0101U00InitListItemInfo>();

		public List<CPL0101U00InitListItemInfo> InitInfo
		{
			get { return this._initInfo; }
			set { this._initInfo = value; }
		}

		public CPL0101U00InitResult() { }

	}
}