using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01LayBongtuResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01LayBongtuInfo> _layBongtuItem = new List<DrgsDRG5100P01LayBongtuInfo>();

		public List<DrgsDRG5100P01LayBongtuInfo> LayBongtuItem
		{
			get { return this._layBongtuItem; }
			set { this._layBongtuItem = value; }
		}

		public DrgsDRG5100P01LayBongtuResult() { }

	}
}