using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01MasterListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01MasterListItemInfo> _masterListItem = new List<InjsINJ1001U01MasterListItemInfo>();

		public List<InjsINJ1001U01MasterListItemInfo> MasterListItem
		{
			get { return this._masterListItem; }
			set { this._masterListItem = value; }
		}

		public InjsINJ1001U01MasterListResult() { }

	}
}