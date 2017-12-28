using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00CbxActorResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cbxActorItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CbxActorItem
		{
			get { return this._cbxActorItem; }
			set { this._cbxActorItem = value; }
		}

		public DRG0201U00CbxActorResult() { }

	}
}