using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U06EmrTagResult : AbstractContractResult
	{
		private List<OCS2015U06EmrTagInfo> _emrTagList = new List<OCS2015U06EmrTagInfo>();

		public List<OCS2015U06EmrTagInfo> EmrTagList
		{
			get { return this._emrTagList; }
			set { this._emrTagList = value; }
		}

		public OCS2015U06EmrTagResult() { }

	}
}