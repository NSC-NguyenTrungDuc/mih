using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class BIL0103U00LoadGridInfo
    {
        private String _bunho;
        private String _suname;
        private String _refId;
        private String _visitDate;
        private String _executedDatetime;
        private String _settleDatetime;
        private String _amount;
        private String _currency;
        private String _errorCode;
        private String _comment;
        private String _transStatus;
        private String _transStatusName;
        private String _errorCodeName;
        private String _requestId;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String RefId
        {
            get { return this._refId; }
            set { this._refId = value; }
        }

        public String VisitDate
        {
            get { return this._visitDate; }
            set { this._visitDate = value; }
        }

        public String ExecutedDatetime
        {
            get { return this._executedDatetime; }
            set { this._executedDatetime = value; }
        }

        public String SettleDatetime
        {
            get { return this._settleDatetime; }
            set { this._settleDatetime = value; }
        }

        public String Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public String Currency
        {
            get { return this._currency; }
            set { this._currency = value; }
        }

        public String ErrorCode
        {
            get { return this._errorCode; }
            set { this._errorCode = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public String TransStatus
        {
            get { return this._transStatus; }
            set { this._transStatus = value; }
        }

        public String TransStatusName
        {
            get { return this._transStatusName; }
            set { this._transStatusName = value; }
        }

        public String ErrorCodeName
        {
            get { return this._errorCodeName; }
            set { this._errorCodeName = value; }
        }

        public String RequestId
        {
            get { return this._requestId; }
            set { this._requestId = value; }
        }

        public BIL0103U00LoadGridInfo() { }

        public BIL0103U00LoadGridInfo(String bunho, String suname, String refId, String visitDate, String executedDatetime, String settleDatetime, String amount, String currency, String errorCode, String comment, String transStatus, String transStatusName, String errorCodeName, String requestId)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._refId = refId;
            this._visitDate = visitDate;
            this._executedDatetime = executedDatetime;
            this._settleDatetime = settleDatetime;
            this._amount = amount;
            this._currency = currency;
            this._errorCode = errorCode;
            this._comment = comment;
            this._transStatus = transStatus;
            this._transStatusName = transStatusName;
            this._errorCodeName = errorCodeName;
            this._requestId = requestId;
        }

    }
}