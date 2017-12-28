using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class PublicInsInfo
    {
        private String _gongbiCode;
        private String _budamjaBunho;
        private String _sugubjaBunho;
        private String _startDate;
        private String _endDate;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
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

        public PublicInsInfo() { }

        public PublicInsInfo(String gongbiCode, String budamjaBunho, String sugubjaBunho, String startDate, String endDate)
        {
            this._gongbiCode = gongbiCode;
            this._budamjaBunho = budamjaBunho;
            this._sugubjaBunho = sugubjaBunho;
            this._startDate = startDate;
            this._endDate = endDate;
        }

    }
}