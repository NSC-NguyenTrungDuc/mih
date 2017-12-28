using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00NaewonDateResult : AbstractContractResult
	{
		private String _naewonDate;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public XRT0201U00NaewonDateResult() { }

	}
}