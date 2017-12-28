using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99DateScheduleListResult : AbstractContractResult
	{
        private List<SchsSCH0201U99DateScheduleItemInfo> _dateScheduleItem = new List<SchsSCH0201U99DateScheduleItemInfo>();

        public List<SchsSCH0201U99DateScheduleItemInfo> DateScheduleItem
		{
			get { return this._dateScheduleItem; }
			set { this._dateScheduleItem = value; }
		}

		public SchsSCH0201U99DateScheduleListResult() { }

	}
}