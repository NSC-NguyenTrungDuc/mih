using System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class GetPatientInfoResult : AbstractContractResult
	{
		private String _deleteYn;
		private String _jubsubreak;
		private String _jubsubreakreason;
		private String _jaewonpatientYn;
		private String _mPkinp1001;

		public String DeleteYn
		{
			get { return this._deleteYn; }
			set { this._deleteYn = value; }
		}

		public String Jubsubreak
		{
			get { return this._jubsubreak; }
			set { this._jubsubreak = value; }
		}

		public String Jubsubreakreason
		{
			get { return this._jubsubreakreason; }
			set { this._jubsubreakreason = value; }
		}

		public String JaewonpatientYn
		{
			get { return this._jaewonpatientYn; }
			set { this._jaewonpatientYn = value; }
		}

		public String MPkinp1001
		{
			get { return this._mPkinp1001; }
			set { this._mPkinp1001 = value; }
		}

		public GetPatientInfoResult() { }

	}
}