using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U04LoadBookmarkByPk0ut1001Result : AbstractContractResult
	{
		private List<OCS2015U04LoadBookmarkByPk0ut1001Info> _emrOneBookmarkList = new List<OCS2015U04LoadBookmarkByPk0ut1001Info>();

		public List<OCS2015U04LoadBookmarkByPk0ut1001Info> EmrOneBookmarkList
		{
			get { return this._emrOneBookmarkList; }
			set { this._emrOneBookmarkList = value; }
		}

		public OCS2015U04LoadBookmarkByPk0ut1001Result() { }

	}
}