using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00DsvLDOCS0801Info
    {
        private String _patStatus;
        private String _patStatusName;
        private String _patStatusCode;
        private String _patStatusCodeName;
        private String _indispensableYn;

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

        public String IndispensableYn
        {
            get { return this._indispensableYn; }
            set { this._indispensableYn = value; }
        }

        public XRT1002U00DsvLDOCS0801Info() { }

        public XRT1002U00DsvLDOCS0801Info(String patStatus, String patStatusName, String patStatusCode, String patStatusCodeName, String indispensableYn)
        {
            this._patStatus = patStatus;
            this._patStatusName = patStatusName;
            this._patStatusCode = patStatusCode;
            this._patStatusCodeName = patStatusCodeName;
            this._indispensableYn = indispensableYn;
        }

    }
}