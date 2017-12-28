using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U04EmrRecordLoadBookmarkContentResult : AbstractContractResult
	{
		private List<OCS2015U04EmrRecordLoadBookmarkContentInfo> _emrBookmarkContentList = new List<OCS2015U04EmrRecordLoadBookmarkContentInfo>();

		public List<OCS2015U04EmrRecordLoadBookmarkContentInfo> EmrBookmarkContentList
		{
			get { return this._emrBookmarkContentList; }
			set { this._emrBookmarkContentList = value; }
		}

		public OCS2015U04EmrRecordLoadBookmarkContentResult() { }

	}
}