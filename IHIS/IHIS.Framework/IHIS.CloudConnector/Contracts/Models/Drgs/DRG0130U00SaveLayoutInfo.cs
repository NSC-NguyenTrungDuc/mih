using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0130U00SaveLayoutInfo
	{
		private String _cautionCode;
		private String _cautionName;
		private String _cautionName2;
		private String _jobType;
		private String _userId;
		private String _rowState;

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

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public DRG0130U00SaveLayoutInfo() { }

		public DRG0130U00SaveLayoutInfo(String cautionCode, String cautionName, String cautionName2, String jobType, String userId, String rowState)
		{
			this._cautionCode = cautionCode;
			this._cautionName = cautionName;
			this._cautionName2 = cautionName2;
			this._jobType = jobType;
			this._userId = userId;
			this._rowState = rowState;
		}

	}
}