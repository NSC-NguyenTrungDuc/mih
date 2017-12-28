using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3020U00GrdPaListItemInfo
    {
        private String _labNo;
        private String _suname;
        private String _specimenSer;
        private String _labSort;
        private String _partJubsuDate;
        private String _jundalGubun;
        private String _gubun;
        private String _resultYn;
        private String _confirmYn;
        private String _batchConfirmYn;
        private String _dataRowState;

        public String LabNo
        {
            get { return this._labNo; }
            set { this._labNo = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String LabSort
        {
            get { return this._labSort; }
            set { this._labSort = value; }
        }

        public String PartJubsuDate
        {
            get { return this._partJubsuDate; }
            set { this._partJubsuDate = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String ResultYn
        {
            get { return this._resultYn; }
            set { this._resultYn = value; }
        }

        public String ConfirmYn
        {
            get { return this._confirmYn; }
            set { this._confirmYn = value; }
        }

        public String BatchConfirmYn
        {
            get { return this._batchConfirmYn; }
            set { this._batchConfirmYn = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public CPL3020U00GrdPaListItemInfo() { }

        public CPL3020U00GrdPaListItemInfo(String labNo, String suname, String specimenSer, String labSort, String partJubsuDate, String jundalGubun, String gubun, String resultYn, String confirmYn, String batchConfirmYn, String dataRowState)
        {
            this._labNo = labNo;
            this._suname = suname;
            this._specimenSer = specimenSer;
            this._labSort = labSort;
            this._partJubsuDate = partJubsuDate;
            this._jundalGubun = jundalGubun;
            this._gubun = gubun;
            this._resultYn = resultYn;
            this._confirmYn = confirmYn;
            this._batchConfirmYn = batchConfirmYn;
            this._dataRowState = dataRowState;
        }

    }
}