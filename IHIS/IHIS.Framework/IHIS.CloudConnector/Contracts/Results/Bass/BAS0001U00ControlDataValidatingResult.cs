using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0001U00ControlDataValidatingResult : AbstractContractResult
	{
		private String _layCom;

		public String LayCom
		{
			get { return this._layCom; }
			set { this._layCom = value; }
		}

		public BAS0001U00ControlDataValidatingResult() { }

	}
}