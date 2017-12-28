using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U00VsvNoteResult : AbstractContractResult
	{
		private String _note;

		public String Note
		{
			get { return this._note; }
			set { this._note = value; }
		}

		public CPL3020U00VsvNoteResult() { }

	}
}