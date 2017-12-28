using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99ReserTimeChkResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _chkCheck = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> ChkCheck
		{
			get { return this._chkCheck; }
			set { this._chkCheck = value; }
		}

		public SchsSCH0201U99ReserTimeChkResult() { }

	}
}