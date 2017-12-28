using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
    public class CHT0115Q01grdCHT0115Info
    {
        private String _susikCode;
        private String _susikName;
        private String _susikNameGana;
        private String _susikCrDate;
        private String _susikUpdDate;
        private String _susikDisableDate;
        private String _susikGwanriNo;
        private String _susikGubun;
        private String _susikChangeCode;
        private String _susikDetailGubun;
        private String _startDate;
        private String _endDate;
        private String _sort;
        private String _rowState;

        public String SusikCode
        {
            get { return this._susikCode; }
            set { this._susikCode = value; }
        }

        public String SusikName
        {
            get { return this._susikName; }
            set { this._susikName = value; }
        }

        public String SusikNameGana
        {
            get { return this._susikNameGana; }
            set { this._susikNameGana = value; }
        }

        public String SusikCrDate
        {
            get { return this._susikCrDate; }
            set { this._susikCrDate = value; }
        }

        public String SusikUpdDate
        {
            get { return this._susikUpdDate; }
            set { this._susikUpdDate = value; }
        }

        public String SusikDisableDate
        {
            get { return this._susikDisableDate; }
            set { this._susikDisableDate = value; }
        }

        public String SusikGwanriNo
        {
            get { return this._susikGwanriNo; }
            set { this._susikGwanriNo = value; }
        }

        public String SusikGubun
        {
            get { return this._susikGubun; }
            set { this._susikGubun = value; }
        }

        public String SusikChangeCode
        {
            get { return this._susikChangeCode; }
            set { this._susikChangeCode = value; }
        }

        public String SusikDetailGubun
        {
            get { return this._susikDetailGubun; }
            set { this._susikDetailGubun = value; }
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

        public String Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CHT0115Q01grdCHT0115Info() { }

        public CHT0115Q01grdCHT0115Info(String susikCode, String susikName, String susikNameGana, String susikCrDate, String susikUpdDate, String susikDisableDate, String susikGwanriNo, String susikGubun, String susikChangeCode, String susikDetailGubun, String startDate, String endDate, String sort, String rowState)
        {
            this._susikCode = susikCode;
            this._susikName = susikName;
            this._susikNameGana = susikNameGana;
            this._susikCrDate = susikCrDate;
            this._susikUpdDate = susikUpdDate;
            this._susikDisableDate = susikDisableDate;
            this._susikGwanriNo = susikGwanriNo;
            this._susikGubun = susikGubun;
            this._susikChangeCode = susikChangeCode;
            this._susikDetailGubun = susikDetailGubun;
            this._startDate = startDate;
            this._endDate = endDate;
            this._sort = sort;
            this._rowState = rowState;
        }

    }
}