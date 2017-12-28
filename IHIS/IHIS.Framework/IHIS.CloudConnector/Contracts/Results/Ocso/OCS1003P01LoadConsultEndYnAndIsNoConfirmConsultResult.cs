using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult : AbstractContractResult
	{
		private String _reqDate;
		private Boolean _isNoReturnConsultYn;

		public String ReqDate
		{
			get { return this._reqDate; }
			set { this._reqDate = value; }
		}

		public Boolean IsNoReturnConsultYn
		{
			get { return this._isNoReturnConsultYn; }
			set { this._isNoReturnConsultYn = value; }
		}

		public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult() { }

	}
}