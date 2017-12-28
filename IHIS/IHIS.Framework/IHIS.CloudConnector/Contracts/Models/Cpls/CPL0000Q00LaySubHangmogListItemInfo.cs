using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySubHangmogListItemInfo
	{
		private String _gumsaName;
		private String _resultDate;
		private String _cplResult;

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String CplResult
		{
			get { return this._cplResult; }
			set { this._cplResult = value; }
		}

		public CPL0000Q00LaySubHangmogListItemInfo() { }

		public CPL0000Q00LaySubHangmogListItemInfo(String gumsaName, String resultDate, String cplResult)
		{
			this._gumsaName = gumsaName;
			this._resultDate = resultDate;
			this._cplResult = cplResult;
		}

	}
}