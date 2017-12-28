using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0113U00GrdOCS0113ListItemInfo
	{
		private String _hangmogCode;
		private String _seq;
		private String _defaultYn;
		private String _specimenCode;
		private String _specimenName;
		private String _hangmogStatDate;
		private String _rowState;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String DefaultYn
		{
			get { return this._defaultYn; }
			set { this._defaultYn = value; }
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

		public String HangmogStatDate
		{
			get { return this._hangmogStatDate; }
			set { this._hangmogStatDate = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public OCS0113U00GrdOCS0113ListItemInfo() { }

		public OCS0113U00GrdOCS0113ListItemInfo(String hangmogCode, String seq, String defaultYn, String specimenCode, String specimenName, String hangmogStatDate, String rowState)
		{
			this._hangmogCode = hangmogCode;
			this._seq = seq;
			this._defaultYn = defaultYn;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._hangmogStatDate = hangmogStatDate;
			this._rowState = rowState;
		}

	}
}