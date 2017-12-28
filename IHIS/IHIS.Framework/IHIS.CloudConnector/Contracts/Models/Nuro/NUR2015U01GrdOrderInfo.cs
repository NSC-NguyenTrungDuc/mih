using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NUR2015U01GrdOrderInfo
    {
        private String _examDate;
        private String _gwa;
        private String _naewonKey;
        private String _gwaName;

        public String ExamDate
        {
            get { return this._examDate; }
            set { this._examDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String NaewonKey
        {
            get { return this._naewonKey; }
            set { this._naewonKey = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public NUR2015U01GrdOrderInfo() { }

        public NUR2015U01GrdOrderInfo(String examDate, String gwa, String naewonKey, String gwaName)
        {
            this._examDate = examDate;
            this._gwa = gwa;
            this._naewonKey = naewonKey;
            this._gwaName = gwaName;
        }

    }
}