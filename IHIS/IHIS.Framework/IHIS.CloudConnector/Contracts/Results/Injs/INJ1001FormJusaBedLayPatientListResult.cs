using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001FormJusaBedLayPatientListResult : AbstractContractResult
	{
		private List<INJ1001FormJusaBedLayPatientItemInfo> _layPatientItem = new List<INJ1001FormJusaBedLayPatientItemInfo>();

		public List<INJ1001FormJusaBedLayPatientItemInfo> LayPatientItem
		{
			get { return this._layPatientItem; }
			set { this._layPatientItem = value; }
		}

		public INJ1001FormJusaBedLayPatientListResult() { }

	}
}