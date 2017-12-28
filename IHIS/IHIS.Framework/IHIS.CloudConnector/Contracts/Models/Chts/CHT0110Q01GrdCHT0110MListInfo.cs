using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0110Q01GrdCHT0110MListInfo
	{
		private String _sangCode;
		private String _sangName;
		private String _sangNameHan;
		private String _sangNameSelf;
		private String _sangNameInx;
		private String _startDate;
		private String _bulyongYn;
		private String _sugaSangCode;
		private String _sugaSangName;
		private String _junyeomBunryu;
		private String _junyeomKind;
		private String _samangSangGroup;
		private String _samangGroupName;
		private String _rankCnt;

		public String SangCode
		{
			get { return this._sangCode; }
			set { this._sangCode = value; }
		}

		public String SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
		}

		public String SangNameHan
		{
			get { return this._sangNameHan; }
			set { this._sangNameHan = value; }
		}

		public String SangNameSelf
		{
			get { return this._sangNameSelf; }
			set { this._sangNameSelf = value; }
		}

		public String SangNameInx
		{
			get { return this._sangNameInx; }
			set { this._sangNameInx = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String BulyongYn
		{
			get { return this._bulyongYn; }
			set { this._bulyongYn = value; }
		}

		public String SugaSangCode
		{
			get { return this._sugaSangCode; }
			set { this._sugaSangCode = value; }
		}

		public String SugaSangName
		{
			get { return this._sugaSangName; }
			set { this._sugaSangName = value; }
		}

		public String JunyeomBunryu
		{
			get { return this._junyeomBunryu; }
			set { this._junyeomBunryu = value; }
		}

		public String JunyeomKind
		{
			get { return this._junyeomKind; }
			set { this._junyeomKind = value; }
		}

		public String SamangSangGroup
		{
			get { return this._samangSangGroup; }
			set { this._samangSangGroup = value; }
		}

		public String SamangGroupName
		{
			get { return this._samangGroupName; }
			set { this._samangGroupName = value; }
		}

		public String RankCnt
		{
			get { return this._rankCnt; }
			set { this._rankCnt = value; }
		}

		public CHT0110Q01GrdCHT0110MListInfo() { }

		public CHT0110Q01GrdCHT0110MListInfo(String sangCode, String sangName, String sangNameHan, String sangNameSelf, String sangNameInx, String startDate, String bulyongYn, String sugaSangCode, String sugaSangName, String junyeomBunryu, String junyeomKind, String samangSangGroup, String samangGroupName, String rankCnt)
		{
			this._sangCode = sangCode;
			this._sangName = sangName;
			this._sangNameHan = sangNameHan;
			this._sangNameSelf = sangNameSelf;
			this._sangNameInx = sangNameInx;
			this._startDate = startDate;
			this._bulyongYn = bulyongYn;
			this._sugaSangCode = sugaSangCode;
			this._sugaSangName = sugaSangName;
			this._junyeomBunryu = junyeomBunryu;
			this._junyeomKind = junyeomKind;
			this._samangSangGroup = samangSangGroup;
			this._samangGroupName = samangGroupName;
			this._rankCnt = rankCnt;
		}

	}
}