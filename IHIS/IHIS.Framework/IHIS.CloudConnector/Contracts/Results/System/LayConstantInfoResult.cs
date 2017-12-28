using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class LayConstantInfoResult : AbstractContractResult
	{
		private List<LayConstantInfo> _layConstantItem = new List<LayConstantInfo>();

		public List<LayConstantInfo> LayConstantItem
		{
			get { return this._layConstantItem; }
			set { this._layConstantItem = value; }
		}

		public LayConstantInfoResult() { }

	}
}