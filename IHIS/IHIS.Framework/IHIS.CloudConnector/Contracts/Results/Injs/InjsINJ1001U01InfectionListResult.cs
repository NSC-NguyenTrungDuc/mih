using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01InfectionListResult : AbstractContractResult
	{
		private List<InjsINJ1001U01InfectionListItemInfo> _infectionListItem = new List<InjsINJ1001U01InfectionListItemInfo>();

		public List<InjsINJ1001U01InfectionListItemInfo> InfectionListItem
		{
			get { return this._infectionListItem; }
			set { this._infectionListItem = value; }
		}

		public InjsINJ1001U01InfectionListResult() { }

	}
}