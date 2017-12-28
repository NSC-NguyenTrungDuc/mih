using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0117GrdCHT0118InitListItemInfo
	{
		private String _startDate;
		private String _endDate;
		private String _buwi;
		private String _subBuwi;
		private String _subBuwiName;
		private String _sortKey;
		private String _remark;
		private String _contKey;
		private String _nosaiJyRate;
		private String _rowState;

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public String SubBuwi
		{
			get { return this._subBuwi; }
			set { this._subBuwi = value; }
		}

		public String SubBuwiName
		{
			get { return this._subBuwiName; }
			set { this._subBuwiName = value; }
		}

		public String SortKey
		{
			get { return this._sortKey; }
			set { this._sortKey = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public String NosaiJyRate
		{
			get { return this._nosaiJyRate; }
			set { this._nosaiJyRate = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public CHT0117GrdCHT0118InitListItemInfo() { }

		public CHT0117GrdCHT0118InitListItemInfo(String startDate, String endDate, String buwi, String subBuwi, String subBuwiName, String sortKey, String remark, String contKey, String nosaiJyRate, String rowState)
		{
			this._startDate = startDate;
			this._endDate = endDate;
			this._buwi = buwi;
			this._subBuwi = subBuwi;
			this._subBuwiName = subBuwiName;
			this._sortKey = sortKey;
			this._remark = remark;
			this._contKey = contKey;
			this._nosaiJyRate = nosaiJyRate;
			this._rowState = rowState;
		}

	}
}