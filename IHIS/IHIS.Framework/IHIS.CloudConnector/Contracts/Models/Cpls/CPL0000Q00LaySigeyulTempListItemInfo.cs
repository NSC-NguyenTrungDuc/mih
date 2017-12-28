using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00LaySigeyulTempListItemInfo
	{
		private String _hangmogCode;
		private String _specimenCode;
		private String _specimenName;
		private String _gumsaName;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public CPL0000Q00LaySigeyulTempListItemInfo() { }

		public CPL0000Q00LaySigeyulTempListItemInfo(String hangmogCode, String specimenCode, String specimenName, String gumsaName)
		{
			this._hangmogCode = hangmogCode;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._gumsaName = gumsaName;
		}

	}
}