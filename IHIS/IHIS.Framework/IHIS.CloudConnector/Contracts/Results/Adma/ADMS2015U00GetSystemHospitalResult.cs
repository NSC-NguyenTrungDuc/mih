using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADMS2015U00GetSystemHospitalResult : AbstractContractResult
	{
		private List<ADMS2015U00SystemHospitalInfo> _systemListInfo = new List<ADMS2015U00SystemHospitalInfo>();

		public List<ADMS2015U00SystemHospitalInfo> SystemListInfo
		{
			get { return this._systemListInfo; }
			set { this._systemListInfo = value; }
		}

		public ADMS2015U00GetSystemHospitalResult() { }

	}
}