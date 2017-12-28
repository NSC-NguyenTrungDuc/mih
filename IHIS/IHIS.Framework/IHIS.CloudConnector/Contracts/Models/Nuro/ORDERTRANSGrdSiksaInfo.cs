using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdSiksaInfo
    {
        private String _fkinp1001;
        private String _pkocs2015;
        private String _bunho;
        private String _inputGubun;
        private String _directGubun;
        private String _nurGrName;
        private String _directCode;
        private String _nurMdName;
        private String _directCont1;
        private String _nurSoName;
        private String _orderDate;
        private String _drtFromDate;
        private String _drtToDate;
        private String _actDate;
        private String _pkSeq;
        private String _actingYn;
        private String _selectYn;
        private String _sendYn;

        public String Fkinp1001
        {
            get { return this._fkinp1001; }
            set { this._fkinp1001 = value; }
        }

        public String Pkocs2015
        {
            get { return this._pkocs2015; }
            set { this._pkocs2015 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String DirectGubun
        {
            get { return this._directGubun; }
            set { this._directGubun = value; }
        }

        public String NurGrName
        {
            get { return this._nurGrName; }
            set { this._nurGrName = value; }
        }

        public String DirectCode
        {
            get { return this._directCode; }
            set { this._directCode = value; }
        }

        public String NurMdName
        {
            get { return this._nurMdName; }
            set { this._nurMdName = value; }
        }

        public String DirectCont1
        {
            get { return this._directCont1; }
            set { this._directCont1 = value; }
        }

        public String NurSoName
        {
            get { return this._nurSoName; }
            set { this._nurSoName = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String DrtFromDate
        {
            get { return this._drtFromDate; }
            set { this._drtFromDate = value; }
        }

        public String DrtToDate
        {
            get { return this._drtToDate; }
            set { this._drtToDate = value; }
        }

        public String ActDate
        {
            get { return this._actDate; }
            set { this._actDate = value; }
        }

        public String PkSeq
        {
            get { return this._pkSeq; }
            set { this._pkSeq = value; }
        }

        public String ActingYn
        {
            get { return this._actingYn; }
            set { this._actingYn = value; }
        }

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public ORDERTRANSGrdSiksaInfo() { }

        public ORDERTRANSGrdSiksaInfo(String fkinp1001, String pkocs2015, String bunho, String inputGubun, String directGubun, String nurGrName, String directCode, String nurMdName, String directCont1, String nurSoName, String orderDate, String drtFromDate, String drtToDate, String actDate, String pkSeq, String actingYn, String selectYn, String sendYn)
        {
            this._fkinp1001 = fkinp1001;
            this._pkocs2015 = pkocs2015;
            this._bunho = bunho;
            this._inputGubun = inputGubun;
            this._directGubun = directGubun;
            this._nurGrName = nurGrName;
            this._directCode = directCode;
            this._nurMdName = nurMdName;
            this._directCont1 = directCont1;
            this._nurSoName = nurSoName;
            this._orderDate = orderDate;
            this._drtFromDate = drtFromDate;
            this._drtToDate = drtToDate;
            this._actDate = actDate;
            this._pkSeq = pkSeq;
            this._actingYn = actingYn;
            this._selectYn = selectYn;
            this._sendYn = sendYn;
        }

    }
}