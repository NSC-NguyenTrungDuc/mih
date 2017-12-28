using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADMS2015U00LoadGroupSystemHospitalResult : AbstractContractResult
	{
		private List<ADMS2015U00GroupHospitalInfo> _groupListInfo = new List<ADMS2015U00GroupHospitalInfo>();
		private List<ADMS2015U00SystemHospitalInfo> _systemListInfo = new List<ADMS2015U00SystemHospitalInfo>();

		public List<ADMS2015U00GroupHospitalInfo> GroupListInfo
		{
			get { return this._groupListInfo; }
			set { this._groupListInfo = value; }
		}

		public List<ADMS2015U00SystemHospitalInfo> SystemListInfo
		{
			get { return this._systemListInfo; }
			set { this._systemListInfo = value; }
		}

		public ADMS2015U00LoadGroupSystemHospitalResult() { }

	}
}