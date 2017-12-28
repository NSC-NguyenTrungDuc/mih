using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04GrdPaCntInfo
    {
        private String _gwa;
        private String _gwaName;
        private String _doctorName;
        private String _paCnt;

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

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String PaCnt
        {
            get { return this._paCnt; }
            set { this._paCnt = value; }
        }

        public PHY2001U04GrdPaCntInfo() { }

        public PHY2001U04GrdPaCntInfo(String gwa, String gwaName, String doctorName, String paCnt)
        {
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._paCnt = paCnt;
        }

    }
}