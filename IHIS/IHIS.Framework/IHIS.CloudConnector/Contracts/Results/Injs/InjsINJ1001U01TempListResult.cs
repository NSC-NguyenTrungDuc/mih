using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01TempListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01TempListItemInfo> _tempListItem = new List<InjsINJ1001U01TempListItemInfo>();

		public List<InjsINJ1001U01TempListItemInfo> TempListItem
		{
			get { return this._tempListItem; }
			set { this._tempListItem = value; }
		}

		public InjsINJ1001U01TempListResult() { }

	}
}