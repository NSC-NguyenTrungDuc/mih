using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99LayoutTimeListResult : AbstractContractResult
	{
		private List<SchsSCH0201U99LayoutTimeListInfo> _lTimeList = new List<SchsSCH0201U99LayoutTimeListInfo>();

		public List<SchsSCH0201U99LayoutTimeListInfo> LTimeList
		{
			get { return this._lTimeList; }
			set { this._lTimeList = value; }
		}

		public SchsSCH0201U99LayoutTimeListResult() { }

	}
}