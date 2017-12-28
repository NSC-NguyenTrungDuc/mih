using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00MentResult : AbstractContractResult
	{
		private String _ment;

		public String Ment
		{
			get { return this._ment; }
			set { this._ment = value; }
		}

		public XRT0201U00MentResult() { }

	}
}