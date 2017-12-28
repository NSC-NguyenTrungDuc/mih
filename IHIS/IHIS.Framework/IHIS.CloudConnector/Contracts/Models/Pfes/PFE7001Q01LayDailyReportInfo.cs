using System;

namespace IHIS.CloudConnector.Contracts.Models.Pfes
{
    [Serializable]
    public class PFE7001Q01LayDailyReportInfo
    {
        private String _gumsaDate;
        private String _ioGubun;
        private String _bunho;
        private String _suname;
        private String _gwa;
        private String _doctorName;
        private String _jundalPart;
        private String _hangmogCode;
        private String _hangmogName;

        public String GumsaDate
        {
            get { return this._gumsaDate; }
            set { this._gumsaDate = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public PFE7001Q01LayDailyReportInfo() { }

        public PFE7001Q01LayDailyReportInfo(String gumsaDate, String ioGubun, String bunho, String suname, String gwa, String doctorName, String jundalPart, String hangmogCode, String hangmogName)
        {
            this._gumsaDate = gumsaDate;
            this._ioGubun = ioGubun;
            this._bunho = bunho;
            this._suname = suname;
            this._gwa = gwa;
            this._doctorName = doctorName;
            this._jundalPart = jundalPart;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
        }

    }
}