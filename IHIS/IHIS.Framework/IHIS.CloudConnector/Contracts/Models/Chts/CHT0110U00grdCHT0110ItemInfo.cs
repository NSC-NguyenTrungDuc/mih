using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
    public class CHT0110U00grdCHT0110ItemInfo
    {
        private String _sangCode;
        private String _sangName;
        private String _sangNameHan;
        private String _sangNameSelf;
        private String _startDate;
        private String _endDate;
        private String _bulyongYn;
        private String _sugaSangCode;
        private String _sugaSangName;
        private String _junyeomBuryn;
        private String _junyeomKind;
        private String _samangSangGroup;
        private String _rowState;

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

        public String JunyeomBuryn
        {
            get { return this._junyeomBuryn; }
            set { this._junyeomBuryn = value; }
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CHT0110U00grdCHT0110ItemInfo() { }

        public CHT0110U00grdCHT0110ItemInfo(String sangCode, String sangName, String sangNameHan, String sangNameSelf, String startDate, String endDate, String bulyongYn, String sugaSangCode, String sugaSangName, String junyeomBuryn, String junyeomKind, String samangSangGroup, String rowState)
        {
            this._sangCode = sangCode;
            this._sangName = sangName;
            this._sangNameHan = sangNameHan;
            this._sangNameSelf = sangNameSelf;
            this._startDate = startDate;
            this._endDate = endDate;
            this._bulyongYn = bulyongYn;
            this._sugaSangCode = sugaSangCode;
            this._sugaSangName = sugaSangName;
            this._junyeomBuryn = junyeomBuryn;
            this._junyeomKind = junyeomKind;
            this._samangSangGroup = samangSangGroup;
            this._rowState = rowState;
        }

    }
}