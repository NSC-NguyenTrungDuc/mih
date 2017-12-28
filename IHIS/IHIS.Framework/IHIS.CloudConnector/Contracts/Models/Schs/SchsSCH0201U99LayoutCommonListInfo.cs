using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201U99LayoutCommonListInfo
	{
		private String _doctorName;
		private String _reserYn;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public SchsSCH0201U99LayoutCommonListInfo() { }

		public SchsSCH0201U99LayoutCommonListInfo(String doctorName, String reserYn)
		{
			this._doctorName = doctorName;
			this._reserYn = reserYn;
		}

	}
}