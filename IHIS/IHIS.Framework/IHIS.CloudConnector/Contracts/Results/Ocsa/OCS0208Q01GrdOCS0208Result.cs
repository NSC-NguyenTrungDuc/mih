using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0208Q01GrdOCS0208Result : AbstractContractResult
	{
		private List<OCS0208Q01GrdOCS0208Info> _grdOCS0208Info = new List<OCS0208Q01GrdOCS0208Info>();

		public List<OCS0208Q01GrdOCS0208Info> GrdOCS0208Info
		{
			get { return this._grdOCS0208Info; }
			set { this._grdOCS0208Info = value; }
		}

		public OCS0208Q01GrdOCS0208Result() { }

	}
}