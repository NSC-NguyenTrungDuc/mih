using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00GwaResult : AbstractContractResult
	{
		private String _columnCodeName;
		private List<ComboListItemInfo> _comboList = new List<ComboListItemInfo>();

		public String ColumnCodeName
		{
			get { return this._columnCodeName; }
			set { this._columnCodeName = value; }
		}

		public List<ComboListItemInfo> ComboList
		{
			get { return this._comboList; }
			set { this._comboList = value; }
		}

		public OcsaOCS0204U00GwaResult() { }

	}
}