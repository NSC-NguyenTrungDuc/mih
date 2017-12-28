using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCALibGetClaimDiagnosisInfo
    {
        private String _updDate;
        private String _pkoif5101;
        private String _license;
        private String _gwa;
        private String _gwaName;
        private String _categoriTd;
        private String _categoriName;
        private String _code;
        private String _system;
        private String _codeName;
        private String _startDate;
        private String _endDate;
        private String _outCome;
        private String _docId;

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String Pkoif5101
        {
            get { return this._pkoif5101; }
            set { this._pkoif5101 = value; }
        }

        public String License
        {
            get { return this._license; }
            set { this._license = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String CategoriTd
        {
            get { return this._categoriTd; }
            set { this._categoriTd = value; }
        }

        public String CategoriName
        {
            get { return this._categoriName; }
            set { this._categoriName = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String System
        {
            get { return this._system; }
            set { this._system = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
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

        public String OutCome
        {
            get { return this._outCome; }
            set { this._outCome = value; }
        }

        public String DocId
        {
            get { return this._docId; }
            set { this._docId = value; }
        }

        public ORCALibGetClaimDiagnosisInfo() { }

        public ORCALibGetClaimDiagnosisInfo(String updDate, String pkoif5101, String license, String gwa, String gwaName, String categoriTd, String categoriName, String code, String system, String codeName, String startDate, String endDate, String outCome, String docId)
        {
            this._updDate = updDate;
            this._pkoif5101 = pkoif5101;
            this._license = license;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._categoriTd = categoriTd;
            this._categoriName = categoriName;
            this._code = code;
            this._system = system;
            this._codeName = codeName;
            this._startDate = startDate;
            this._endDate = endDate;
            this._outCome = outCome;
            this._docId = docId;
        }

    }
}