using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U06EmrTemplateTypeResult : AbstractContractResult
	{
		private List<OCS2015U06EmrTemplateTypeInfo> _emrTemplateTypeList = new List<OCS2015U06EmrTemplateTypeInfo>();

		public List<OCS2015U06EmrTemplateTypeInfo> EmrTemplateTypeList
		{
			get { return this._emrTemplateTypeList; }
			set { this._emrTemplateTypeList = value; }
		}

		public OCS2015U06EmrTemplateTypeResult() { }

	}
}