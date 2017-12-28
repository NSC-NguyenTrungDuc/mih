using IHIS.CloudConnector.Contracts.Models.Cpls;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0000Q00DeleteAndSelectResult : AbstractContractResult
	{
		private Boolean _deleteResult;
		private List<CPL0000Q00SelectOUT0101ListItemInfo> _selectResult = new List<CPL0000Q00SelectOUT0101ListItemInfo>();

		public Boolean DeleteResult
		{
			get { return this._deleteResult; }
			set { this._deleteResult = value; }
		}

		public List<CPL0000Q00SelectOUT0101ListItemInfo> SelectResult
		{
			get { return this._selectResult; }
			set { this._selectResult = value; }
		}

		public CPL0000Q00DeleteAndSelectResult() { }
	}
}