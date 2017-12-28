using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U06EmrRecordResult : AbstractContractResult
	{
		private List<OCS2015U06EmrRecordInfo> _emrRecordList = new List<OCS2015U06EmrRecordInfo>();

		public List<OCS2015U06EmrRecordInfo> EmrRecordList
		{
			get { return this._emrRecordList; }
			set { this._emrRecordList = value; }
		}

		public OCS2015U06EmrRecordResult() { }

	}
}