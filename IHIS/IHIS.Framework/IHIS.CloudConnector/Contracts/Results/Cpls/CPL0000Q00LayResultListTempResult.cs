using IHIS.CloudConnector.Contracts.Models.Cpls;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00LayResultListTempResult : AbstractContractResult
	{
		private List<CPL0000Q00LayResultListTempListItemInfo> _layResultList = new List<CPL0000Q00LayResultListTempListItemInfo>();

		public List<CPL0000Q00LayResultListTempListItemInfo> LayResultList
		{
			get { return this._layResultList; }
			set { this._layResultList = value; }
		}

		public CPL0000Q00LayResultListTempResult() { }

	}
}