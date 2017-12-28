using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01LabelNewListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01LabelNewListItemInfo> _labelNewListItem = new List<InjsINJ1001U01LabelNewListItemInfo>();

		public List<InjsINJ1001U01LabelNewListItemInfo> LabelNewListItem
		{
			get { return this._labelNewListItem; }
			set { this._labelNewListItem = value; }
		}

		public InjsINJ1001U01LabelNewListResult() { }

	}
}