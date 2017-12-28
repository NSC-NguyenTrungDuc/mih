using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1016U00GetComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _xEditGridCell7List = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _layComboSetList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> XEditGridCell7List
		{
			get { return this._xEditGridCell7List; }
			set { this._xEditGridCell7List = value; }
		}

		public List<ComboListItemInfo> LayComboSetList
		{
			get { return this._layComboSetList; }
			set { this._layComboSetList = value; }
		}

		public NUR1016U00GetComboListResult() { }

	}
}