using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0801U00GrdOCS0802ListItemInfo
    {
        private String _patStatus;
        private String _patStatusCode;
        private String _patStatusName;
        private String _ment;
        private String _seq;
        private String _contKey;
        private String _rowSate;

        public String PatStatus
        {
            get { return this._patStatus; }
            set { this._patStatus = value; }
        }

        public String PatStatusCode
        {
            get { return this._patStatusCode; }
            set { this._patStatusCode = value; }
        }

        public String PatStatusName
        {
            get { return this._patStatusName; }
            set { this._patStatusName = value; }
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

        public String ContKey
        {
            get { return this._contKey; }
            set { this._contKey = value; }
        }

        public String RowSate
        {
            get { return this._rowSate; }
            set { this._rowSate = value; }
        }

        public OCS0801U00GrdOCS0802ListItemInfo() { }

        public OCS0801U00GrdOCS0802ListItemInfo(String patStatus, String patStatusCode, String patStatusName, String ment, String seq, String contKey, String rowSate)
        {
            this._patStatus = patStatus;
            this._patStatusCode = patStatusCode;
            this._patStatusName = patStatusName;
            this._ment = ment;
            this._seq = seq;
            this._contKey = contKey;
            this._rowSate = rowSate;
        }

    }
}