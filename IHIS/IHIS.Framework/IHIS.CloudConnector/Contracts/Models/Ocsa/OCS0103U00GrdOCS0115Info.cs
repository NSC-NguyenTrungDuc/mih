using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0115Info
    {
        private String _hangmogCode;
        private String _inputGwa;
        private String _inputPart;
        private String _gwaName;
        private String _jundalTableOut;
        private String _jundalPartOut;
        private String _movePart;
        private String _jundalTableInp;
        private String _jundalPartInp;
        private String _gwaNameOut;
        private String _gwaNameInp;
        private String _movePartName;
        private String _startDate;
        private String _endDate;
        private String _hospCode;
        private String _hangmogStartDate;
        private String _rowState;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String InputGwa
        {
            get { return this._inputGwa; }
            set { this._inputGwa = value; }
        }

        public String InputPart
        {
            get { return this._inputPart; }
            set { this._inputPart = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String JundalTableOut
        {
            get { return this._jundalTableOut; }
            set { this._jundalTableOut = value; }
        }

        public String JundalPartOut
        {
            get { return this._jundalPartOut; }
            set { this._jundalPartOut = value; }
        }

        public String MovePart
        {
            get { return this._movePart; }
            set { this._movePart = value; }
        }

        public String JundalTableInp
        {
            get { return this._jundalTableInp; }
            set { this._jundalTableInp = value; }
        }

        public String JundalPartInp
        {
            get { return this._jundalPartInp; }
            set { this._jundalPartInp = value; }
        }

        public String GwaNameOut
        {
            get { return this._gwaNameOut; }
            set { this._gwaNameOut = value; }
        }

        public String GwaNameInp
        {
            get { return this._gwaNameInp; }
            set { this._gwaNameInp = value; }
        }

        public String MovePartName
        {
            get { return this._movePartName; }
            set { this._movePartName = value; }
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

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HangmogStartDate
        {
            get { return this._hangmogStartDate; }
            set { this._hangmogStartDate = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0103U00GrdOCS0115Info() { }

        public OCS0103U00GrdOCS0115Info(String hangmogCode, String inputGwa, String inputPart, String gwaName, String jundalTableOut, String jundalPartOut, String movePart, String jundalTableInp, String jundalPartInp, String gwaNameOut, String gwaNameInp, String movePartName, String startDate, String endDate, String hospCode, String hangmogStartDate, String rowState)
        {
            this._hangmogCode = hangmogCode;
            this._inputGwa = inputGwa;
            this._inputPart = inputPart;
            this._gwaName = gwaName;
            this._jundalTableOut = jundalTableOut;
            this._jundalPartOut = jundalPartOut;
            this._movePart = movePart;
            this._jundalTableInp = jundalTableInp;
            this._jundalPartInp = jundalPartInp;
            this._gwaNameOut = gwaNameOut;
            this._gwaNameInp = gwaNameInp;
            this._movePartName = movePartName;
            this._startDate = startDate;
            this._endDate = endDate;
            this._hospCode = hospCode;
            this._hangmogStartDate = hangmogStartDate;
            this._rowState = rowState;
        }

    }
}