using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    public class OCS0301U00Membgrd307Info
    {
        private String _memb;
        private String _fkocs0300Seq;
        private String _yaksokCode;
        private String _pkocs0307;
        private String _dataRowState;
        private String _sangCode;
        private String _sangName;

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String Fkocs0300Seq
        {
            get { return this._fkocs0300Seq; }
            set { this._fkocs0300Seq = value; }
        }

        public String YaksokCode
        {
            get { return this._yaksokCode; }
            set { this._yaksokCode = value; }
        }

        public String Pkocs0307
        {
            get { return this._pkocs0307; }
            set { this._pkocs0307 = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public String SangCode
        {
            get { return this._sangCode; }
            set { this._sangCode = value; }
        }

        public String SangName
        {
            get { return this._sangName; }
            set { this._sangName = value; }
        }

        public OCS0301U00Membgrd307Info() { }

        public OCS0301U00Membgrd307Info(String memb, String fkocs0300Seq, String yaksokCode, String pkocs0307, String dataRowState, String sangCode, String sangName)
        {
            this._memb = memb;
            this._fkocs0300Seq = fkocs0300Seq;
            this._yaksokCode = yaksokCode;
            this._pkocs0307 = pkocs0307;
            this._dataRowState = dataRowState;
            this._sangCode = sangCode;
            this._sangName = sangName;
        }

    }
}