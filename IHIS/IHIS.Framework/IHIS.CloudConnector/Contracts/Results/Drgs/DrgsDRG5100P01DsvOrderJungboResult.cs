using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01DsvOrderJungboResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01OrderJungboInfo> _orderJungboItem = new List<DrgsDRG5100P01OrderJungboInfo>();
		private String _barDrgBunho;

		public List<DrgsDRG5100P01OrderJungboInfo> OrderJungboItem
		{
			get { return this._orderJungboItem; }
			set { this._orderJungboItem = value; }
		}

		public String BarDrgBunho
		{
			get { return this._barDrgBunho; }
			set { this._barDrgBunho = value; }
		}

		public DrgsDRG5100P01DsvOrderJungboResult() { }

	}
}