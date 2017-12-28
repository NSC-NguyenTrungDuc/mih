using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADMS2015U01LoadMenuItemResult : AbstractContractResult
	{
		private List<ADMS2015U01MenuInfo> _menuInfo = new List<ADMS2015U01MenuInfo>();

		public List<ADMS2015U01MenuInfo> MenuInfo
		{
			get { return this._menuInfo; }
			set { this._menuInfo = value; }
		}

		public ADMS2015U01LoadMenuItemResult() { }

	}
}