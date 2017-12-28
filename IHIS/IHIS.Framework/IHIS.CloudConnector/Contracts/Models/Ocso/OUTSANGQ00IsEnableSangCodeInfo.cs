using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OUTSANGQ00IsEnableSangCodeInfo
    {
        private String _sangStartDate;
        private String _startDate;

        public String SangStartDate
        {
            get { return this._sangStartDate; }
            set { this._sangStartDate = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public OUTSANGQ00IsEnableSangCodeInfo() { }

        public OUTSANGQ00IsEnableSangCodeInfo(String sangStartDate, String startDate)
        {
            this._sangStartDate = sangStartDate;
            this._startDate = startDate;
        }

    }
}