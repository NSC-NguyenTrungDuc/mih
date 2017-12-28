using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1002U01LoadComboBoxResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboList
		{
			get { return this._cboList; }
			set { this._cboList = value; }
		}

		public INJ1002U01LoadComboBoxResult() { }

	}
}