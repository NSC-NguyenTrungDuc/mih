using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01GrdMasterGroupedResult : AbstractContractResult
	{
		private List<InjsINJ1001U01MasterListItemInfo> _masterListItem = new List<InjsINJ1001U01MasterListItemInfo>();
		private List<InjsINJ1001U01ChkbStateItemInfo2> _chkbStateListItem = new List<InjsINJ1001U01ChkbStateItemInfo2>();

		public List<InjsINJ1001U01MasterListItemInfo> MasterListItem
		{
			get { return this._masterListItem; }
			set { this._masterListItem = value; }
		}

		public List<InjsINJ1001U01ChkbStateItemInfo2> ChkbStateListItem
		{
			get { return this._chkbStateListItem; }
			set { this._chkbStateListItem = value; }
		}

		public INJ1001U01GrdMasterGroupedResult() { }

	}
}