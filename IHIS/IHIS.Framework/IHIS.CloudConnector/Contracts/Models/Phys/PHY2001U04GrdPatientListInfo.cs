using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04GrdPatientListInfo
    {
        private String _gwa;
        private String _gwaName;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _naewonDate;
        private String _doctor;
        private String _doctorName;
        private String _naewonType;
        private String _jubsuNo;
        private String _birth;
        private String _ageSex;
        private String _outResKey;
        private String _jubsuTime;
        private String _orderEndYn;
        private String _holdYn;
        private String _resultYn;
        private String _reserYn;
        private String _ipwonYn;
        private String _sunabYn;
        private String _naewonYn;
        private String _jubsuGubun;
        private String _jubsuGubunName;
        private String _remark;
        private String _arriveTime;
        private String _gubun;
        private String _lastNaewonDate;
        private String _ocsComment;
        private String _chojae;
        private String _groupKey;
        private String _bunhoType;
        private String _kaigoYn;
        private String _gaein;
        private String _bpTo;
        private String _bpFrom;
        private String _pulse;
        private String _bodyHeat;

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

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
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

        public String NaewonType
        {
            get { return this._naewonType; }
            set { this._naewonType = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String AgeSex
        {
            get { return this._ageSex; }
            set { this._ageSex = value; }
        }

        public String OutResKey
        {
            get { return this._outResKey; }
            set { this._outResKey = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String OrderEndYn
        {
            get { return this._orderEndYn; }
            set { this._orderEndYn = value; }
        }

        public String HoldYn
        {
            get { return this._holdYn; }
            set { this._holdYn = value; }
        }

        public String ResultYn
        {
            get { return this._resultYn; }
            set { this._resultYn = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String IpwonYn
        {
            get { return this._ipwonYn; }
            set { this._ipwonYn = value; }
        }

        public String SunabYn
        {
            get { return this._sunabYn; }
            set { this._sunabYn = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String JubsuGubunName
        {
            get { return this._jubsuGubunName; }
            set { this._jubsuGubunName = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String LastNaewonDate
        {
            get { return this._lastNaewonDate; }
            set { this._lastNaewonDate = value; }
        }

        public String OcsComment
        {
            get { return this._ocsComment; }
            set { this._ocsComment = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String GroupKey
        {
            get { return this._groupKey; }
            set { this._groupKey = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String KaigoYn
        {
            get { return this._kaigoYn; }
            set { this._kaigoYn = value; }
        }

        public String Gaein
        {
            get { return this._gaein; }
            set { this._gaein = value; }
        }

        public String BpTo
        {
            get { return this._bpTo; }
            set { this._bpTo = value; }
        }

        public String BpFrom
        {
            get { return this._bpFrom; }
            set { this._bpFrom = value; }
        }

        public String Pulse
        {
            get { return this._pulse; }
            set { this._pulse = value; }
        }

        public String BodyHeat
        {
            get { return this._bodyHeat; }
            set { this._bodyHeat = value; }
        }

        public PHY2001U04GrdPatientListInfo() { }

        public PHY2001U04GrdPatientListInfo(String gwa, String gwaName, String bunho, String suname, String suname2, String naewonDate, String doctor, String doctorName, String naewonType, String jubsuNo, String birth, String ageSex, String outResKey, String jubsuTime, String orderEndYn, String holdYn, String resultYn, String reserYn, String ipwonYn, String sunabYn, String naewonYn, String jubsuGubun, String jubsuGubunName, String remark, String arriveTime, String gubun, String lastNaewonDate, String ocsComment, String chojae, String groupKey, String bunhoType, String kaigoYn, String gaein, String bpTo, String bpFrom, String pulse, String bodyHeat)
        {
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._naewonDate = naewonDate;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._naewonType = naewonType;
            this._jubsuNo = jubsuNo;
            this._birth = birth;
            this._ageSex = ageSex;
            this._outResKey = outResKey;
            this._jubsuTime = jubsuTime;
            this._orderEndYn = orderEndYn;
            this._holdYn = holdYn;
            this._resultYn = resultYn;
            this._reserYn = reserYn;
            this._ipwonYn = ipwonYn;
            this._sunabYn = sunabYn;
            this._naewonYn = naewonYn;
            this._jubsuGubun = jubsuGubun;
            this._jubsuGubunName = jubsuGubunName;
            this._remark = remark;
            this._arriveTime = arriveTime;
            this._gubun = gubun;
            this._lastNaewonDate = lastNaewonDate;
            this._ocsComment = ocsComment;
            this._chojae = chojae;
            this._groupKey = groupKey;
            this._bunhoType = bunhoType;
            this._kaigoYn = kaigoYn;
            this._gaein = gaein;
            this._bpTo = bpTo;
            this._bpFrom = bpFrom;
            this._pulse = pulse;
            this._bodyHeat = bodyHeat;
        }

    }
}