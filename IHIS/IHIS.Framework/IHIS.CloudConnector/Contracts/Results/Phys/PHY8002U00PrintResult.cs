using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Phys;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
	public class PHY8002U00PrintResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _info = new List<DataStringListItemInfo>();
		private List<PHY8002U00DtHospInfo> _dtInfo = new List<PHY8002U00DtHospInfo>();

		public List<DataStringListItemInfo> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public List<PHY8002U00DtHospInfo> DtInfo
		{
			get { return this._dtInfo; }
			set { this._dtInfo = value; }
		}

		public PHY8002U00PrintResult() { }

	}
}