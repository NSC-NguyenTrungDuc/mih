using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class BasManageZipCodeResult : AbstractContractResult
    {
		private List<BasManageZipCodeInfo> _manageZipCodeItem = new List<BasManageZipCodeInfo>();

		public List<BasManageZipCodeInfo> ManageZipCodeItem
		{
			get { return this._manageZipCodeItem; }
			set { this._manageZipCodeItem = value; }
		}

		public BasManageZipCodeResult() { }

	}

}
