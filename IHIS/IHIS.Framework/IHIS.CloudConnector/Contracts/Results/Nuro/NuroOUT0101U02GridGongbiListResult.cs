using IHIS.CloudConnector.Contracts.Models.Nuro;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GridGongbiListResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GridGongbiListInfo> _gridGongbiListItem = new List<NuroOUT0101U02GridGongbiListInfo>();

		public List<NuroOUT0101U02GridGongbiListInfo> GridGongbiListItem
		{
			get { return this._gridGongbiListItem; }
			set { this._gridGongbiListItem = value; }
		}

		public NuroOUT0101U02GridGongbiListResult() { }

	}
}