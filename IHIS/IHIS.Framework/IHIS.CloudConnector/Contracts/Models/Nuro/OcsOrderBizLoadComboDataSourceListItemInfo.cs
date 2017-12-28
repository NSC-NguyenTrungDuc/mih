using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OcsOrderBizLoadComboDataSourceListItemInfo
	{
		private String _code;
		private String _codeName;
		private String _groupKey;
		private String _valuePoint;
		private String _sortKey;
		private String _caseDvToiwonEmpty1;
		private String _caseDvToiwonEmpty2;
		private String _caseDvToiwonZeroValue;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public String ValuePoint
		{
			get { return this._valuePoint; }
			set { this._valuePoint = value; }
		}

		public String SortKey
		{
			get { return this._sortKey; }
			set { this._sortKey = value; }
		}

		public String CaseDvToiwonEmpty1
		{
			get { return this._caseDvToiwonEmpty1; }
			set { this._caseDvToiwonEmpty1 = value; }
		}

		public String CaseDvToiwonEmpty2
		{
			get { return this._caseDvToiwonEmpty2; }
			set { this._caseDvToiwonEmpty2 = value; }
		}

		public String CaseDvToiwonZeroValue
		{
			get { return this._caseDvToiwonZeroValue; }
			set { this._caseDvToiwonZeroValue = value; }
		}

		public OcsOrderBizLoadComboDataSourceListItemInfo() { }

		public OcsOrderBizLoadComboDataSourceListItemInfo(String code, String codeName, String groupKey, String valuePoint, String sortKey, String caseDvToiwonEmpty1, String caseDvToiwonEmpty2, String caseDvToiwonZeroValue)
		{
			this._code = code;
			this._codeName = codeName;
			this._groupKey = groupKey;
			this._valuePoint = valuePoint;
			this._sortKey = sortKey;
			this._caseDvToiwonEmpty1 = caseDvToiwonEmpty1;
			this._caseDvToiwonEmpty2 = caseDvToiwonEmpty2;
			this._caseDvToiwonZeroValue = caseDvToiwonZeroValue;
		}

	}
}