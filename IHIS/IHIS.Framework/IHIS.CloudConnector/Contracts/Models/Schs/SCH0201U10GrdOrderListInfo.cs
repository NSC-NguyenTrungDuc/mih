using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U10GrdOrderListInfo
    {
        private String _pkkey;
        private String _gubun;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _reserTime;
        private String _seq;
        private String _sort;

        public String Pkkey
        {
            get { return this._pkkey; }
            set { this._pkkey = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

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

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
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

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        public SCH0201U10GrdOrderListInfo() { }

        public SCH0201U10GrdOrderListInfo(String pkkey, String gubun, String gwa, String gwaName, String doctor, String doctorName, String hangmogCode, String hangmogName, String reserTime, String seq, String sort)
        {
            this._pkkey = pkkey;
            this._gubun = gubun;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._reserTime = reserTime;
            this._seq = seq;
            this._sort = sort;
        }

    }
}