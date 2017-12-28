using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01PrintNameResult : AbstractContractResult
	{
		private List<DrgsDRG5100P01PrintNameInfo> _printNameList = new List<DrgsDRG5100P01PrintNameInfo>();

		public List<DrgsDRG5100P01PrintNameInfo> PrintNameList
		{
			get { return this._printNameList; }
			set { this._printNameList = value; }
		}

		public DrgsDRG5100P01PrintNameResult() { }

	}
}