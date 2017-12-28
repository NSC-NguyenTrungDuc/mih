using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0000Q00GetModalityCodeResult : AbstractContractResult
	{
		private String _modality;

		public String Modality
		{
			get { return this._modality; }
			set { this._modality = value; }
		}

		public XRT0000Q00GetModalityCodeResult() { }

	}
}