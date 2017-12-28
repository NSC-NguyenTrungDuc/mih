using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL7001Q01LayDailyReportInfo
    {
        private String _gumsaDate;
        private String _bunho;
        private String _suname;
        private String _gwa;
        private String _doctorName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _specimenSer;
        private String _specimenName;

        public String GumsaDate
        {
            get { return this._gumsaDate; }
            set { this._gumsaDate = value; }
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

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public CPL7001Q01LayDailyReportInfo() { }

        public CPL7001Q01LayDailyReportInfo(String gumsaDate, String bunho, String suname, String gwa, String doctorName, String hangmogCode, String hangmogName, String specimenSer, String specimenName)
        {
            this._gumsaDate = gumsaDate;
            this._bunho = bunho;
            this._suname = suname;
            this._gwa = gwa;
            this._doctorName = doctorName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._specimenSer = specimenSer;
            this._specimenName = specimenName;
        }

    }
}