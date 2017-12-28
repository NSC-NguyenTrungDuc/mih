using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroRES0102U00CboGwaResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboItemInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboItemInfo
		{
			get { return this._cboItemInfo; }
			set { this._cboItemInfo = value; }
		}

		public NuroRES0102U00CboGwaResult() { }

	}
}