using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01GetChuciResult : AbstractContractResult
	{
		private List<OcsoOCS1003P01GetChuciInfo> _chuciItem = new List<OcsoOCS1003P01GetChuciInfo>();

		public List<OcsoOCS1003P01GetChuciInfo> ChuciItem
		{
			get { return this._chuciItem; }
			set { this._chuciItem = value; }
		}

		public OcsoOCS1003P01GetChuciResult() { }

	}
}