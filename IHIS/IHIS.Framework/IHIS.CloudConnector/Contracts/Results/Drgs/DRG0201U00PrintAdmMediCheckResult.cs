using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG0201U00PrintAdmMediCheckResult : AbstractContractResult
	{
		private String _msgResult;
		private String _retVal;
		private String _pkdrg;
		private String _errMsg;

		public String MsgResult
		{
			get { return this._msgResult; }
			set { this._msgResult = value; }
		}

		public String RetVal
		{
			get { return this._retVal; }
			set { this._retVal = value; }
		}

		public String Pkdrg
		{
			get { return this._pkdrg; }
			set { this._pkdrg = value; }
		}

		public String ErrMsg
		{
			get { return this._errMsg; }
			set { this._errMsg = value; }
		}

		public DRG0201U00PrintAdmMediCheckResult() { }

	}
}