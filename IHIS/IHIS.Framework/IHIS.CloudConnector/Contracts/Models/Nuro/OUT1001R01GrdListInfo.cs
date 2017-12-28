using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class OUT1001R01GrdListInfo
    {
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _dateConvert1;
        private String _dateConvert2;
        private String _naewonDate;
        private String _sujinNo;
        private String _jubsuNo;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _jubsuGubun;
        private String _gubunName;
        private String _jubsuTime;
        private String _chojaeName;
        private String _reserYn;
        private String _arriveTime;
        private String _naewonYn;
        private String _yoyangName;
        private String _sortKey;
        private String _jundalPart;

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

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String DateConvert1
        {
            get { return this._dateConvert1; }
            set { this._dateConvert1 = value; }
        }

        public String DateConvert2
        {
            get { return this._dateConvert2; }
            set { this._dateConvert2 = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String SujinNo
        {
            get { return this._sujinNo; }
            set { this._sujinNo = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
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

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String ChojaeName
        {
            get { return this._chojaeName; }
            set { this._chojaeName = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String SortKey
        {
            get { return this._sortKey; }
            set { this._sortKey = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public OUT1001R01GrdListInfo() { }

        public OUT1001R01GrdListInfo(String bunho, String suname, String suname2, String dateConvert1, String dateConvert2, String naewonDate, String sujinNo, String jubsuNo, String gwa, String gwaName, String doctor, String doctorName, String jubsuGubun, String gubunName, String jubsuTime, String chojaeName, String reserYn, String arriveTime, String naewonYn, String yoyangName, String sortKey, String jundalPart)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._dateConvert1 = dateConvert1;
            this._dateConvert2 = dateConvert2;
            this._naewonDate = naewonDate;
            this._sujinNo = sujinNo;
            this._jubsuNo = jubsuNo;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._jubsuGubun = jubsuGubun;
            this._gubunName = gubunName;
            this._jubsuTime = jubsuTime;
            this._chojaeName = chojaeName;
            this._reserYn = reserYn;
            this._arriveTime = arriveTime;
            this._naewonYn = naewonYn;
            this._yoyangName = yoyangName;
            this._sortKey = sortKey;
            this._jundalPart = jundalPart;
        }

    }
}