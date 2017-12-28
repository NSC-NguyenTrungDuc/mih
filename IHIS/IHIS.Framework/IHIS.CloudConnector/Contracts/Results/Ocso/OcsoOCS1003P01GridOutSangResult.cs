using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01GridOutSangResult : AbstractContractResult
	{
		private List<OcsoOCS1003P01GridOutSangInfo> _gridOutSangItem = new List<OcsoOCS1003P01GridOutSangInfo>();

		public List<OcsoOCS1003P01GridOutSangInfo> GridOutSangItem
		{
			get { return this._gridOutSangItem; }
			set { this._gridOutSangItem = value; }
		}

		public OcsoOCS1003P01GridOutSangResult() { }

	}
}