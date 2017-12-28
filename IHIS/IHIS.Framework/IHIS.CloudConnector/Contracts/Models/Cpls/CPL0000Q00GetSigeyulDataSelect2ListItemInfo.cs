using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00GetSigeyulDataSelect2ListItemInfo
	{
		private String _cplResult;
		private String _standardYn;
		private String _gumsaName;
		private String _fromStandard;
		private String _toStandard;

		public String CplResult
		{
			get { return this._cplResult; }
			set { this._cplResult = value; }
		}

		public String StandardYn
		{
			get { return this._standardYn; }
			set { this._standardYn = value; }
		}

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public String FromStandard
		{
			get { return this._fromStandard; }
			set { this._fromStandard = value; }
		}

		public String ToStandard
		{
			get { return this._toStandard; }
			set { this._toStandard = value; }
		}

		public CPL0000Q00GetSigeyulDataSelect2ListItemInfo() { }

		public CPL0000Q00GetSigeyulDataSelect2ListItemInfo(String cplResult, String standardYn, String gumsaName, String fromStandard, String toStandard)
		{
			this._cplResult = cplResult;
			this._standardYn = standardYn;
			this._gumsaName = gumsaName;
			this._fromStandard = fromStandard;
			this._toStandard = toStandard;
		}

	}
}