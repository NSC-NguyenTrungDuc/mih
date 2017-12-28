using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01ScheduleResult : AbstractContractResult
	{
		private List<InjsINJ1001U01ScheduleItemInfo> _scheduleItem = new List<InjsINJ1001U01ScheduleItemInfo>();

		public List<InjsINJ1001U01ScheduleItemInfo> ScheduleItem
		{
			get { return this._scheduleItem; }
			set { this._scheduleItem = value; }
		}

		public InjsINJ1001U01ScheduleResult() { }

	}
}