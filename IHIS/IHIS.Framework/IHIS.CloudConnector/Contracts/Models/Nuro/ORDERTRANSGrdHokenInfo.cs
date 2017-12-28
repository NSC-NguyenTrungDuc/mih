using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdHokenInfo
    {
        private String _gubun;
        private String _gubunName;
        private String _startDate;
        private String _endDate;
        private String _johap;
        private String _selectYn;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
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

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public ORDERTRANSGrdHokenInfo() { }

        public ORDERTRANSGrdHokenInfo(String gubun, String gubunName, String startDate, String endDate, String johap, String selectYn)
        {
            this._gubun = gubun;
            this._gubunName = gubunName;
            this._startDate = startDate;
            this._endDate = endDate;
            this._johap = johap;
            this._selectYn = selectYn;
        }

    }
}