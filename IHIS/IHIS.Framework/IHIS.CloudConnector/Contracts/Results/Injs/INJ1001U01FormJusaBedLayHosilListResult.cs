using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01FormJusaBedLayHosilListResult : AbstractContractResult
	{
		private List<INJ1001U01FormJusaBedLayHosilItemInfo> _layPatientItem = new List<INJ1001U01FormJusaBedLayHosilItemInfo>();

		public List<INJ1001U01FormJusaBedLayHosilItemInfo> LayPatientItem
		{
			get { return this._layPatientItem; }
			set { this._layPatientItem = value; }
		}

		public INJ1001U01FormJusaBedLayHosilListResult() { }

	}
}