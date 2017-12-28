using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0108U00CreateComboResult : AbstractContractResult
	{
		private List<OCS0108U00CreateComboItemInfo> _comboItem = new List<OCS0108U00CreateComboItemInfo>();

		public List<OCS0108U00CreateComboItemInfo> ComboItem
		{
			get { return this._comboItem; }
			set { this._comboItem = value; }
		}

		public OCS0108U00CreateComboResult() { }

	}
}