using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG0130U00GrdDrg0130ListItemInfo
	{
		private String _cautionCode;
		private String _cautionName;
		private String _cautionName2;
		private String _jobType;

		public String CautionCode
		{
			get { return this._cautionCode; }
			set { this._cautionCode = value; }
		}

		public String CautionName
		{
			get { return this._cautionName; }
			set { this._cautionName = value; }
		}

		public String CautionName2
		{
			get { return this._cautionName2; }
			set { this._cautionName2 = value; }
		}

		public String JobType
		{
			get { return this._jobType; }
			set { this._jobType = value; }
		}

		public DrgsDRG0130U00GrdDrg0130ListItemInfo() { }

		public DrgsDRG0130U00GrdDrg0130ListItemInfo(String cautionCode, String cautionName, String cautionName2, String jobType)
		{
			this._cautionCode = cautionCode;
			this._cautionName = cautionName;
			this._cautionName2 = cautionName2;
			this._jobType = jobType;
		}

	}
}