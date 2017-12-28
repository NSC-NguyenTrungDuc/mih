using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12InitComboBoxResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboSearchConditionList = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboInputGubun = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboSearchConditionList
		{
			get { return this._cboSearchConditionList; }
			set { this._cboSearchConditionList = value; }
		}

		public List<ComboListItemInfo> CboInputGubun
		{
			get { return this._cboInputGubun; }
			set { this._cboInputGubun = value; }
		}

		public OCS0103U12InitComboBoxResult() { }

	}
}