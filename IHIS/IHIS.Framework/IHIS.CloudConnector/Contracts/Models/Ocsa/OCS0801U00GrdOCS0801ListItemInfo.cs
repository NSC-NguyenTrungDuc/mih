using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0801U00GrdOCS0801ListItemInfo
    {
        private String _patStatus;
        private String _patStatusName;
        private String _ment;
        private String _seq;
        private String _rowSate;

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

        public String RowSate
        {
            get { return this._rowSate; }
            set { this._rowSate = value; }
        }

        public OCS0801U00GrdOCS0801ListItemInfo() { }

        public OCS0801U00GrdOCS0801ListItemInfo(String patStatus, String patStatusName, String ment, String seq, String rowSate)
        {
            this._patStatus = patStatus;
            this._patStatusName = patStatusName;
            this._ment = ment;
            this._seq = seq;
            this._rowSate = rowSate;
        }

    }
}