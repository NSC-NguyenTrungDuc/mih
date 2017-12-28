using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0212U00GrdItemInfo
    {
        private String _gongbiCode;
        private String _startDate;
        private String _endDate;
        private String _lawNo;
        private String _gongbiName;
        private String _totalYn;
        private String _gongbiJiyeok;
        private String _rowState;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
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

        public String LawNo
        {
            get { return this._lawNo; }
            set { this._lawNo = value; }
        }

        public String GongbiName
        {
            get { return this._gongbiName; }
            set { this._gongbiName = value; }
        }

        public String TotalYn
        {
            get { return this._totalYn; }
            set { this._totalYn = value; }
        }

        public String GongbiJiyeok
        {
            get { return this._gongbiJiyeok; }
            set { this._gongbiJiyeok = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public BAS0212U00GrdItemInfo() { }

        public BAS0212U00GrdItemInfo(String gongbiCode, String startDate, String endDate, String lawNo, String gongbiName, String totalYn, String gongbiJiyeok, String rowState)
        {
            this._gongbiCode = gongbiCode;
            this._startDate = startDate;
            this._endDate = endDate;
            this._lawNo = lawNo;
            this._gongbiName = gongbiName;
            this._totalYn = totalYn;
            this._gongbiJiyeok = gongbiJiyeok;
            this._rowState = rowState;
        }

    }
}