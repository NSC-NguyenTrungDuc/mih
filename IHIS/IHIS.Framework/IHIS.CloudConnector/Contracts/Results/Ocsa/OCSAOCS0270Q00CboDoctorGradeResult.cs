using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCSAOCS0270Q00CboDoctorGradeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _comboListItems = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ComboListItems
		{
			get { return this._comboListItems; }
			set { this._comboListItems = value; }
		}

		public OCSAOCS0270Q00CboDoctorGradeResult() { }

	}
}