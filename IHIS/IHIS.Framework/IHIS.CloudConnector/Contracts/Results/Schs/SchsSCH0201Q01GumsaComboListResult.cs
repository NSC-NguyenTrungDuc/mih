using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q01GumsaComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _gumsaComboItem = new List<ComboListItemInfo>();
		private String _selectedValue;

		public List<ComboListItemInfo> GumsaComboItem
		{
			get { return this._gumsaComboItem; }
			set { this._gumsaComboItem = value; }
		}

		public String SelectedValue
		{
			get { return this._selectedValue; }
			set { this._selectedValue = value; }
		}

		public SchsSCH0201Q01GumsaComboListResult() { }

	}
}