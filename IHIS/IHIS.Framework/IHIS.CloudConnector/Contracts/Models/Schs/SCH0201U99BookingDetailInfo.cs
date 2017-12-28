using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0201U99BookingDetailInfo
    {
        private String _bunho;
        private String _suname;
        private String _birth;
        private String _sex;
        private String _hospCode;
        private String _yoyangName;
        private String _tel;
        private String _reserDate;
        private String _reserTime;
        private String _bookingDate;
        private String _linkPatientFlg;
        private String _outHospCode;
        private String _hangmogCode;
        private String _linkEmrFlg;

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

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String BookingDate
        {
            get { return this._bookingDate; }
            set { this._bookingDate = value; }
        }

        public String LinkPatientFlg
        {
            get { return this._linkPatientFlg; }
            set { this._linkPatientFlg = value; }
        }

        public String OutHospCode
        {
            get { return this._outHospCode; }
            set { this._outHospCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String LinkEmrFlg
        {
            get { return this._linkEmrFlg; }
            set { this._linkEmrFlg = value; }
        }

        public SCH0201U99BookingDetailInfo() { }

        public SCH0201U99BookingDetailInfo(String bunho, String suname, String birth, String sex, String hospCode, String yoyangName, String tel, String reserDate, String reserTime, String bookingDate, String linkPatientFlg, String outHospCode, String hangmogCode, String linkEmrFlg)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._birth = birth;
            this._sex = sex;
            this._hospCode = hospCode;
            this._yoyangName = yoyangName;
            this._tel = tel;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._bookingDate = bookingDate;
            this._linkPatientFlg = linkPatientFlg;
            this._outHospCode = outHospCode;
            this._hangmogCode = hangmogCode;
            this._linkEmrFlg = linkEmrFlg;
        }

    }
}