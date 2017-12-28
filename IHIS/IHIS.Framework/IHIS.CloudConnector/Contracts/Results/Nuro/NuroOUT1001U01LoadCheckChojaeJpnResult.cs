using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroOUT1001U01LoadCheckChojaeJpnResult : AbstractContractResult
	{
		private NuroOUT1001U01LoadCheckChojaeJpnInfo _chojaeJpnItem;

		public NuroOUT1001U01LoadCheckChojaeJpnInfo ChojaeJpnItem
		{
			get { return this._chojaeJpnItem; }
			set { this._chojaeJpnItem = value; }
		}

		public NuroOUT1001U01LoadCheckChojaeJpnResult() { }

	}
}