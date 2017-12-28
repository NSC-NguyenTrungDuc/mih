using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01GetChuciInfo
	{
		private String _code;
		private String _groupKey;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public OcsoOCS1003P01GetChuciInfo() { }

		public OcsoOCS1003P01GetChuciInfo(String code, String groupKey)
		{
			this._code = code;
			this._groupKey = groupKey;
		}

	}
}