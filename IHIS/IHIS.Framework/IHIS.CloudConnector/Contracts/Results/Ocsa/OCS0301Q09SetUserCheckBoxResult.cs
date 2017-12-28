using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301Q09SetUserCheckBoxResult : AbstractContractResult
	{
		private String _result;
		private String _gwaAllName;
		private String _gwaDoctorName;
		private String _userIdName;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public String GwaAllName
		{
			get { return this._gwaAllName; }
			set { this._gwaAllName = value; }
		}

		public String GwaDoctorName
		{
			get { return this._gwaDoctorName; }
			set { this._gwaDoctorName = value; }
		}

		public String UserIdName
		{
			get { return this._userIdName; }
			set { this._userIdName = value; }
		}

		public OCS0301Q09SetUserCheckBoxResult() { }

	}
}