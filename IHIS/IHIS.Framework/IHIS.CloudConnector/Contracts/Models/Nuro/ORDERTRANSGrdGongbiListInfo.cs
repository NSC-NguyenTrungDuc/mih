using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdGongbiListInfo
    {
        private String _gongbiCode;
        private String _gongbiName;
        private String _lastCheckDate;
        private String _budamjaBunho;
        private String _sugubjaBunho;
        private String _selectYn;
        private String _priority;
        private String _ifValidYn;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String GongbiName
        {
            get { return this._gongbiName; }
            set { this._gongbiName = value; }
        }

        public String LastCheckDate
        {
            get { return this._lastCheckDate; }
            set { this._lastCheckDate = value; }
        }

        public String BudamjaBunho
        {
            get { return this._budamjaBunho; }
            set { this._budamjaBunho = value; }
        }

        public String SugubjaBunho
        {
            get { return this._sugubjaBunho; }
            set { this._sugubjaBunho = value; }
        }

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public String Priority
        {
            get { return this._priority; }
            set { this._priority = value; }
        }

        public String IfValidYn
        {
            get { return this._ifValidYn; }
            set { this._ifValidYn = value; }
        }

        public ORDERTRANSGrdGongbiListInfo() { }

        public ORDERTRANSGrdGongbiListInfo(String gongbiCode, String gongbiName, String lastCheckDate, String budamjaBunho, String sugubjaBunho, String selectYn, String priority, String ifValidYn)
        {
            this._gongbiCode = gongbiCode;
            this._gongbiName = gongbiName;
            this._lastCheckDate = lastCheckDate;
            this._budamjaBunho = budamjaBunho;
            this._sugubjaBunho = sugubjaBunho;
            this._selectYn = selectYn;
            this._priority = priority;
            this._ifValidYn = ifValidYn;
        }

    }
}