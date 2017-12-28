using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01DetailListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01DetailListItemInfo> _detailListItem = new List<InjsINJ1001U01DetailListItemInfo>();

		public List<InjsINJ1001U01DetailListItemInfo> DetailListItem
		{
			get { return this._detailListItem; }
			set { this._detailListItem = value; }
		}

		public InjsINJ1001U01DetailListResult() { }

	}
}