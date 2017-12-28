using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OcsLoadInputControlResult : AbstractContractResult
	{
		private List<OcsLoadInputControlListItemInfo> _controlList = new List<OcsLoadInputControlListItemInfo>();

		public List<OcsLoadInputControlListItemInfo> ControlList
		{
			get { return this._controlList; }
			set { this._controlList = value; }
		}

		public OcsLoadInputControlResult() { }

	}
}