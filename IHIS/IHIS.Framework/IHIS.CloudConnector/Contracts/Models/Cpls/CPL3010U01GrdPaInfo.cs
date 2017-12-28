using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01GrdPaInfo
    {
        private String _recodeGubun;
        private String _centerCode;
        private String _requestKey;
        private String _hospitalCode;
        private String _gwaName;
        private String _hoDongName;
        private String _inOutGubun;
        private String _doctorName;
        private String _bunho;
        private String _jinryoCard;
        private String _suname2;
        private String _sex;
        private String _ageGubun;
        private String _age;
        private String _birthGubun;
        private String _birth;
        private String _jubsuDate;
        private String _jubsuTime;
        private String _hangmogCnt;
        private String _height;
        private String _weight;
        private String _nyoRyang;
        private String _nyoDanui;
        private String _pregnancyJusu;
        private String _dialysis;
        private String _emergency;
        private String _comments;
        private String _emptyString;
        private String _nString;
        private String _sendYn;
        private String _specimenSer;

        public String RecodeGubun
        {
            get { return this._recodeGubun; }
            set { this._recodeGubun = value; }
        }

        public String CenterCode
        {
            get { return this._centerCode; }
            set { this._centerCode = value; }
        }

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public String HospitalCode
        {
            get { return this._hospitalCode; }
            set { this._hospitalCode = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String HoDongName
        {
            get { return this._hoDongName; }
            set { this._hoDongName = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String JinryoCard
        {
            get { return this._jinryoCard; }
            set { this._jinryoCard = value; }
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

        public String AgeGubun
        {
            get { return this._ageGubun; }
            set { this._ageGubun = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String BirthGubun
        {
            get { return this._birthGubun; }
            set { this._birthGubun = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String HangmogCnt
        {
            get { return this._hangmogCnt; }
            set { this._hangmogCnt = value; }
        }

        public String Height
        {
            get { return this._height; }
            set { this._height = value; }
        }

        public String Weight
        {
            get { return this._weight; }
            set { this._weight = value; }
        }

        public String NyoRyang
        {
            get { return this._nyoRyang; }
            set { this._nyoRyang = value; }
        }

        public String NyoDanui
        {
            get { return this._nyoDanui; }
            set { this._nyoDanui = value; }
        }

        public String PregnancyJusu
        {
            get { return this._pregnancyJusu; }
            set { this._pregnancyJusu = value; }
        }

        public String Dialysis
        {
            get { return this._dialysis; }
            set { this._dialysis = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String EmptyString
        {
            get { return this._emptyString; }
            set { this._emptyString = value; }
        }

        public String NString
        {
            get { return this._nString; }
            set { this._nString = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public CPL3010U01GrdPaInfo() { }

        public CPL3010U01GrdPaInfo(String recodeGubun, String centerCode, String requestKey, String hospitalCode, String gwaName, String hoDongName, String inOutGubun, String doctorName, String bunho, String jinryoCard, String suname2, String sex, String ageGubun, String age, String birthGubun, String birth, String jubsuDate, String jubsuTime, String hangmogCnt, String height, String weight, String nyoRyang, String nyoDanui, String pregnancyJusu, String dialysis, String emergency, String comments, String emptyString, String nString, String sendYn, String specimenSer)
        {
            this._recodeGubun = recodeGubun;
            this._centerCode = centerCode;
            this._requestKey = requestKey;
            this._hospitalCode = hospitalCode;
            this._gwaName = gwaName;
            this._hoDongName = hoDongName;
            this._inOutGubun = inOutGubun;
            this._doctorName = doctorName;
            this._bunho = bunho;
            this._jinryoCard = jinryoCard;
            this._suname2 = suname2;
            this._sex = sex;
            this._ageGubun = ageGubun;
            this._age = age;
            this._birthGubun = birthGubun;
            this._birth = birth;
            this._jubsuDate = jubsuDate;
            this._jubsuTime = jubsuTime;
            this._hangmogCnt = hangmogCnt;
            this._height = height;
            this._weight = weight;
            this._nyoRyang = nyoRyang;
            this._nyoDanui = nyoDanui;
            this._pregnancyJusu = pregnancyJusu;
            this._dialysis = dialysis;
            this._emergency = emergency;
            this._comments = comments;
            this._emptyString = emptyString;
            this._nString = nString;
            this._sendYn = sendYn;
            this._specimenSer = specimenSer;
        }

    }
}