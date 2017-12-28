using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
	public class DrgsDRG5100P01NebokLabelListResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01NebokLabelListItemInfo> _nebokLabelList = new List<DrgsDRG5100P01NebokLabelListItemInfo>();

		public List<DrgsDRG5100P01NebokLabelListItemInfo> NebokLabelList
		{
			get { return this._nebokLabelList; }
			set { this._nebokLabelList = value; }
		}

		public DrgsDRG5100P01NebokLabelListResult() { }

	}
}