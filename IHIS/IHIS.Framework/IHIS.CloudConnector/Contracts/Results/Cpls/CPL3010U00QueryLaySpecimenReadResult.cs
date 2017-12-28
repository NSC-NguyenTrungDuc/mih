using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00QueryLaySpecimenReadResult : AbstractContractResult
	{
		private String _insertOk;
		private String _alreadyJubsu;
		private String _flag;

		public String InsertOk
		{
			get { return this._insertOk; }
			set { this._insertOk = value; }
		}

		public String AlreadyJubsu
		{
			get { return this._alreadyJubsu; }
			set { this._alreadyJubsu = value; }
		}

		public String Flag
		{
			get { return this._flag; }
			set { this._flag = value; }
		}

		public CPL3010U00QueryLaySpecimenReadResult() { }

	}
}