using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01ChkbStateItemInfo2
	{
		private String _bunho;
		private String _doctor;
		private String _result;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public InjsINJ1001U01ChkbStateItemInfo2() { }

		public InjsINJ1001U01ChkbStateItemInfo2(String bunho, String doctor, String result)
		{
			this._bunho = bunho;
			this._doctor = doctor;
			this._result = result;
		}

	}
}