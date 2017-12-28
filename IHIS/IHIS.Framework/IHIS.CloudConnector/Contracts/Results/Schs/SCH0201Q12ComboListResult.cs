using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q12ComboListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboGumsa = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboGwa = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboGumsa
		{
			get { return this._cboGumsa; }
			set { this._cboGumsa = value; }
		}

		public List<ComboListItemInfo> CboGwa
		{
			get { return this._cboGwa; }
			set { this._cboGwa = value; }
		}

		public SCH0201Q12ComboListResult() { }

	}
}