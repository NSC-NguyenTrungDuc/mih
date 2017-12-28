using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00CreateTimeComboResult : AbstractContractResult
	{
		private List<OCS0503U00CreateTimeComboInfo> _createTime = new List<OCS0503U00CreateTimeComboInfo>();

		public List<OCS0503U00CreateTimeComboInfo> CreateTime
		{
			get { return this._createTime; }
			set { this._createTime = value; }
		}

		public OCS0503U00CreateTimeComboResult() { }

	}
}