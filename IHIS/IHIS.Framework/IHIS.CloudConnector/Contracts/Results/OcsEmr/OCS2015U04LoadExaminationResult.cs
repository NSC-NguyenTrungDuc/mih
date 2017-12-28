using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U04LoadExaminationResult : AbstractContractResult
	{
		private List<OCS2015U04LoadExaminationInfo> _emrLoadExaminationList = new List<OCS2015U04LoadExaminationInfo>();

		public List<OCS2015U04LoadExaminationInfo> EmrLoadExaminationList
		{
			get { return this._emrLoadExaminationList; }
			set { this._emrLoadExaminationList = value; }
		}

		public OCS2015U04LoadExaminationResult() { }

	}
}