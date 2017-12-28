using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class MultiResultViewGrdSigeyulInfo
	{
		private String _bunho;
		private String _hangmogCode;
		private String _gumsaName;
		private String _gubun;
		private String _baseDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String BaseDate
		{
			get { return this._baseDate; }
			set { this._baseDate = value; }
		}

		public MultiResultViewGrdSigeyulInfo() { }

		public MultiResultViewGrdSigeyulInfo(String bunho, String hangmogCode, String gumsaName, String gubun, String baseDate)
		{
			this._bunho = bunho;
			this._hangmogCode = hangmogCode;
			this._gumsaName = gumsaName;
			this._gubun = gubun;
			this._baseDate = baseDate;
		}

	}
}