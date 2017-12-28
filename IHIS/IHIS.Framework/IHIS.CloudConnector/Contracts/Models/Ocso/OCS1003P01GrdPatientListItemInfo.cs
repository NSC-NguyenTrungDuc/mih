using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCS1003P01GrdPatientListItemInfo
    {
        private String _bunho;
        private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _naewonType;
        private String _reserYn;
        private String _jubsuTime;
        private String _arriveTime;
        private String _suname;
        private String _suname2;
        private String _sex;
        private String _age;
        private String _gubunName;
        private String _gwaName;
        private String _doctorName;
        private String _chojaeName;
        private String _jinryoEndYn;
        private String _pkNaewon;
        private String _naewonYn;
        private String _sunnabYn;
        private String _jubsuGubun1;
        private String _otherGwa;
        private String _consultYn;
        private String _jubsuGubun2;
        private String _commonDoctorYn;
        private String _gubun;
        private String _groupKey;
        private String _kensaYn;
        private String _unapproveYn;
        private String _sysId;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

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

        public String NaewonType
        {
            get { return this._naewonType; }
            set { this._naewonType = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
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

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
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

        public String ChojaeName
        {
            get { return this._chojaeName; }
            set { this._chojaeName = value; }
        }

        public String JinryoEndYn
        {
            get { return this._jinryoEndYn; }
            set { this._jinryoEndYn = value; }
        }

        public String PkNaewon
        {
            get { return this._pkNaewon; }
            set { this._pkNaewon = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String SunnabYn
        {
            get { return this._sunnabYn; }
            set { this._sunnabYn = value; }
        }

        public String JubsuGubun1
        {
            get { return this._jubsuGubun1; }
            set { this._jubsuGubun1 = value; }
        }

        public String OtherGwa
        {
            get { return this._otherGwa; }
            set { this._otherGwa = value; }
        }

        public String ConsultYn
        {
            get { return this._consultYn; }
            set { this._consultYn = value; }
        }

        public String JubsuGubun2
        {
            get { return this._jubsuGubun2; }
            set { this._jubsuGubun2 = value; }
        }

        public String CommonDoctorYn
        {
            get { return this._commonDoctorYn; }
            set { this._commonDoctorYn = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String GroupKey
        {
            get { return this._groupKey; }
            set { this._groupKey = value; }
        }

        public String KensaYn
        {
            get { return this._kensaYn; }
            set { this._kensaYn = value; }
        }

        public String UnapproveYn
        {
            get { return this._unapproveYn; }
            set { this._unapproveYn = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public OCS1003P01GrdPatientListItemInfo() { }

        public OCS1003P01GrdPatientListItemInfo(String bunho, String naewonDate, String gwa, String doctor, String naewonType, String reserYn, String jubsuTime, String arriveTime, String suname, String suname2, String sex, String age, String gubunName, String gwaName, String doctorName, String chojaeName, String jinryoEndYn, String pkNaewon, String naewonYn, String sunnabYn, String jubsuGubun1, String otherGwa, String consultYn, String jubsuGubun2, String commonDoctorYn, String gubun, String groupKey, String kensaYn, String unapproveYn, String sysId)
        {
            this._bunho = bunho;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._naewonType = naewonType;
            this._reserYn = reserYn;
            this._jubsuTime = jubsuTime;
            this._arriveTime = arriveTime;
            this._suname = suname;
            this._suname2 = suname2;
            this._sex = sex;
            this._age = age;
            this._gubunName = gubunName;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._chojaeName = chojaeName;
            this._jinryoEndYn = jinryoEndYn;
            this._pkNaewon = pkNaewon;
            this._naewonYn = naewonYn;
            this._sunnabYn = sunnabYn;
            this._jubsuGubun1 = jubsuGubun1;
            this._otherGwa = otherGwa;
            this._consultYn = consultYn;
            this._jubsuGubun2 = jubsuGubun2;
            this._commonDoctorYn = commonDoctorYn;
            this._gubun = gubun;
            this._groupKey = groupKey;
            this._kensaYn = kensaYn;
            this._unapproveYn = unapproveYn;
            this._sysId = sysId;
        }

    }
}