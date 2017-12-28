using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0803U00grdOCS0804ItemInfo
    {
        private String _patStatusGr;
        private String _patStatus;
        private String _patStatusName;
        private String _indispensableYn;
        private String _breakPatStatusCode;
        private String _patStatusCodeName;
        private String _ment;
        private String _seq;
        private String _rowState;

        public String PatStatusGr
        {
            get { return this._patStatusGr; }
            set { this._patStatusGr = value; }
        }

        public String PatStatus
        {
            get { return this._patStatus; }
            set { this._patStatus = value; }
        }

        public String PatStatusName
        {
            get { return this._patStatusName; }
            set { this._patStatusName = value; }
        }

        public String IndispensableYn
        {
            get { return this._indispensableYn; }
            set { this._indispensableYn = value; }
        }

        public String BreakPatStatusCode
        {
            get { return this._breakPatStatusCode; }
            set { this._breakPatStatusCode = value; }
        }

        public String PatStatusCodeName
        {
            get { return this._patStatusCodeName; }
            set { this._patStatusCodeName = value; }
        }

        public String Ment
        {
            get { return this._ment; }
            set { this._ment = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0803U00grdOCS0804ItemInfo() { }

        public OCS0803U00grdOCS0804ItemInfo(String patStatusGr, String patStatus, String patStatusName, String indispensableYn, String breakPatStatusCode, String patStatusCodeName, String ment, String seq, String rowState)
        {
            this._patStatusGr = patStatusGr;
            this._patStatus = patStatus;
            this._patStatusName = patStatusName;
            this._indispensableYn = indispensableYn;
            this._breakPatStatusCode = breakPatStatusCode;
            this._patStatusCodeName = patStatusCodeName;
            this._ment = ment;
            this._seq = seq;
            this._rowState = rowState;
        }

    }
}