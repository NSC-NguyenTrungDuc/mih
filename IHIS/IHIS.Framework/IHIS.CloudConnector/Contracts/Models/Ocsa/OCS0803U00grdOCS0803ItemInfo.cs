using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0803U00grdOCS0803ItemInfo
    {
        private String _patStatusGr;
        private String _patStatusGrName;
        private String _ment;
        private String _seq;
        private String _rowState;

        public String PatStatusGr
        {
            get { return this._patStatusGr; }
            set { this._patStatusGr = value; }
        }

        public String PatStatusGrName
        {
            get { return this._patStatusGrName; }
            set { this._patStatusGrName = value; }
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

        public OCS0803U00grdOCS0803ItemInfo() { }

        public OCS0803U00grdOCS0803ItemInfo(String patStatusGr, String patStatusGrName, String ment, String seq, String rowState)
        {
            this._patStatusGr = patStatusGr;
            this._patStatusGrName = patStatusGrName;
            this._ment = ment;
            this._seq = seq;
            this._rowState = rowState;
        }

    }
}