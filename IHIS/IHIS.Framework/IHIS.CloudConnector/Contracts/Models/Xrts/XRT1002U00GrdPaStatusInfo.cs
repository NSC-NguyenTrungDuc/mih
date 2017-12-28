using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00GrdPaStatusInfo
    {
        private String _bunho;
        private String _patStatus;
        private String _patStatusName;
        private String _patStatusCode;
        private String _patStatusCodeName;
        private String _ment;
        private String _seq;
        private String _indispensableYn;
        private String _contKey;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public String PatStatusCode
        {
            get { return this._patStatusCode; }
            set { this._patStatusCode = value; }
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

        public String IndispensableYn
        {
            get { return this._indispensableYn; }
            set { this._indispensableYn = value; }
        }

        public String ContKey
        {
            get { return this._contKey; }
            set { this._contKey = value; }
        }

        public XRT1002U00GrdPaStatusInfo() { }

        public XRT1002U00GrdPaStatusInfo(String bunho, String patStatus, String patStatusName, String patStatusCode, String patStatusCodeName, String ment, String seq, String indispensableYn, String contKey)
        {
            this._bunho = bunho;
            this._patStatus = patStatus;
            this._patStatusName = patStatusName;
            this._patStatusCode = patStatusCode;
            this._patStatusCodeName = patStatusCodeName;
            this._ment = ment;
            this._seq = seq;
            this._indispensableYn = indispensableYn;
            this._contKey = contKey;
        }

    }
}