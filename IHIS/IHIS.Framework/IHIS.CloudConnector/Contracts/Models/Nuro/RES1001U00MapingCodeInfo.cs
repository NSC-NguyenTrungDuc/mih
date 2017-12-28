using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class RES1001U00MapingCodeInfo
    {
        private String _gwa;
        private String _doctor;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public RES1001U00MapingCodeInfo() { }

        public RES1001U00MapingCodeInfo(String gwa, String doctor)
        {
            this._gwa = gwa;
            this._doctor = doctor;
        }

    }
}