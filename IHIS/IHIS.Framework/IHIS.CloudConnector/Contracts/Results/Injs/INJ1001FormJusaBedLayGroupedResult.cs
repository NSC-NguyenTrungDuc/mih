using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001FormJusaBedLayGroupedResult : AbstractContractResult
	{
		private List<INJ1001FormJusaBedLayPatientItemInfo> _layPatientItem = new List<INJ1001FormJusaBedLayPatientItemInfo>();
		private List<INJ1001U01FormJusaBedLayHosilItemInfo> _bedLayHosilItem = new List<INJ1001U01FormJusaBedLayHosilItemInfo>();
		private List<String> _codeName = new List<String>();

		public List<INJ1001FormJusaBedLayPatientItemInfo> LayPatientItem
		{
			get { return this._layPatientItem; }
			set { this._layPatientItem = value; }
		}

		public List<INJ1001U01FormJusaBedLayHosilItemInfo> BedLayHosilItem
		{
			get { return this._bedLayHosilItem; }
			set { this._bedLayHosilItem = value; }
		}

		public List<String> CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public INJ1001FormJusaBedLayGroupedResult() { }

	}
}