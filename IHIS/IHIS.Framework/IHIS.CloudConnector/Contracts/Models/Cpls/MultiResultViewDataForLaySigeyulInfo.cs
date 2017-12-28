using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class MultiResultViewDataForLaySigeyulInfo
	{
		private String _fromStandard;
		private String _toStandard;
		private String _standardYn;
		private String _result;
		private String _resultDate;
		private String _tCnt;

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

		public String StandardYn
		{
			get { return this._standardYn; }
			set { this._standardYn = value; }
		}

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String TCnt
		{
			get { return this._tCnt; }
			set { this._tCnt = value; }
		}

		public MultiResultViewDataForLaySigeyulInfo() { }

		public MultiResultViewDataForLaySigeyulInfo(String fromStandard, String toStandard, String standardYn, String result, String resultDate, String tCnt)
		{
			this._fromStandard = fromStandard;
			this._toStandard = toStandard;
			this._standardYn = standardYn;
			this._result = result;
			this._resultDate = resultDate;
			this._tCnt = tCnt;
		}

	}
}