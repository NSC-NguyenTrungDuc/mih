using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1017U00GetComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _xEditGridCell1List = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _xEditGridCell5List = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _xEditGridCell6List = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _layComboSetList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> XEditGridCell1List
		{
			get { return this._xEditGridCell1List; }
			set { this._xEditGridCell1List = value; }
		}

		public List<ComboListItemInfo> XEditGridCell5List
		{
			get { return this._xEditGridCell5List; }
			set { this._xEditGridCell5List = value; }
		}

		public List<ComboListItemInfo> XEditGridCell6List
		{
			get { return this._xEditGridCell6List; }
			set { this._xEditGridCell6List = value; }
		}

		public List<ComboListItemInfo> LayComboSetList
		{
			get { return this._layComboSetList; }
			set { this._layComboSetList = value; }
		}

		public NUR1017U00GetComboListResult() { }

	}
}