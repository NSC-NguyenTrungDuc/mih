using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
	public class OCS2015U09GetTemplateComboBoxResult : AbstractContractResult
	{
		private List<OCS2015U09GetTemplateComboBoxInfo> _templateList = new List<OCS2015U09GetTemplateComboBoxInfo>();

		public List<OCS2015U09GetTemplateComboBoxInfo> TemplateList
		{
			get { return this._templateList; }
			set { this._templateList = value; }
		}

		public OCS2015U09GetTemplateComboBoxResult() { }

	}
}