using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U06EmrTemplateResult : AbstractContractResult
	{
		private List<OCS2015U06EmrTemplateInfo> _emrTemplateList = new List<OCS2015U06EmrTemplateInfo>();

		public List<OCS2015U06EmrTemplateInfo> EmrTemplateList
		{
			get { return this._emrTemplateList; }
			set { this._emrTemplateList = value; }
		}

		public OCS2015U06EmrTemplateResult() { }

	}
}