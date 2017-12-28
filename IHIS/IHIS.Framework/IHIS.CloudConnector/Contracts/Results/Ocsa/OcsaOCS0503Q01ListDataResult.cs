using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0503Q01ListDataResult : AbstractContractResult
	{
		private List<OcsaOCS0503Q01ListDataInfo> _listItem = new List<OcsaOCS0503Q01ListDataInfo>();

		public List<OcsaOCS0503Q01ListDataInfo> ListItem
		{
			get { return this._listItem; }
			set { this._listItem = value; }
		}

		public OcsaOCS0503Q01ListDataResult() { }

	}
}