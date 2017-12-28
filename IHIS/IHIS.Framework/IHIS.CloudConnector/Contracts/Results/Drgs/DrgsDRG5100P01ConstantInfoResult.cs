using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01ConstantInfoResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01ConstantInfo> _constantInfoList = new List<DrgsDRG5100P01ConstantInfo>();

		public List<DrgsDRG5100P01ConstantInfo> ConstantInfoList
		{
			get { return this._constantInfoList; }
			set { this._constantInfoList = value; }
		}

		public DrgsDRG5100P01ConstantInfoResult() { }

	}
}