using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocs.Lib
{
    [Serializable]
	public class AdmMessageCallResult : AbstractContractResult
	{
		private String _errFlag;
		private String _sendSeq;

		public String ErrFlag
		{
			get { return this._errFlag; }
			set { this._errFlag = value; }
		}

		public String SendSeq
		{
			get { return this._sendSeq; }
			set { this._sendSeq = value; }
		}

		public AdmMessageCallResult() { }

	}
}