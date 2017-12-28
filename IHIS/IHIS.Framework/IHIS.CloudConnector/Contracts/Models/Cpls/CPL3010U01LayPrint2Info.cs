using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01LayPrint2Info
    {
        private String _partJubsuDate;
        private String _bunho;
        private String _suname2;
        private String _hangmogCode;
        private String _gumsaNm;
        private String _gwaName;
        private String _doctorName;
        private String _sex;
        private String _age;
        private String _specimenSer;
        private String _nyoRyang;
        private String _nyoDanui;
        private String _emergency;

        public String PartJubsuDate
        {
            get { return this._partJubsuDate; }
            set { this._partJubsuDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String GumsaNm
        {
            get { return this._gumsaNm; }
            set { this._gumsaNm = value; }
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

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
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

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public CPL3010U01LayPrint2Info() { }

        public CPL3010U01LayPrint2Info(String partJubsuDate, String bunho, String suname2, String hangmogCode, String gumsaNm, String gwaName, String doctorName, String sex, String age, String specimenSer, String nyoRyang, String nyoDanui, String emergency)
        {
            this._partJubsuDate = partJubsuDate;
            this._bunho = bunho;
            this._suname2 = suname2;
            this._hangmogCode = hangmogCode;
            this._gumsaNm = gumsaNm;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._sex = sex;
            this._age = age;
            this._specimenSer = specimenSer;
            this._nyoRyang = nyoRyang;
            this._nyoDanui = nyoDanui;
            this._emergency = emergency;
        }

    }
}