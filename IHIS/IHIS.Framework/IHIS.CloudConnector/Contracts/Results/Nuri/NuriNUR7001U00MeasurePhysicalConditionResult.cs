using System;
using IHIS.CloudConnector.Contracts.Models.Nuri;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable ]
	public class NuriNUR7001U00MeasurePhysicalConditionResult : AbstractContractResult
	{
		private List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> _measurePhysicalConditionListItem = new List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo>();

		public List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> MeasurePhysicalConditionListItem
		{
			get { return this._measurePhysicalConditionListItem; }
			set { this._measurePhysicalConditionListItem = value; }
		}

		public NuriNUR7001U00MeasurePhysicalConditionResult() { }

	}
}