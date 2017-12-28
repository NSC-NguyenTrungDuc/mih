using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class Schs0201U99InsertResultInfo
    {
        private String _doctor;
        private String _gwa;
        private String _fkout1001;
        private String _hospCode;
        private String _bunho;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public Schs0201U99InsertResultInfo() { }

        public Schs0201U99InsertResultInfo(String doctor, String gwa, String fkout1001, String hospCode, String bunho)
        {
            this._doctor = doctor;
            this._gwa = gwa;
            this._fkout1001 = fkout1001;
            this._hospCode = hospCode;
            this._bunho = bunho;
        }

    }
}