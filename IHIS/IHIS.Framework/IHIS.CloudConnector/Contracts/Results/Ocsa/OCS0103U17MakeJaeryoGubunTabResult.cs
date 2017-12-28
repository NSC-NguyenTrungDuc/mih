using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U17MakeJaeryoGubunTabResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboList
		{
			get { return this._comboList; }
			set { this._comboList = value; }
		}

		public OCS0103U17MakeJaeryoGubunTabResult() { }

	}
}