using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04GrdExcelInfo
    {
        private String _gwaName;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _doctorName;
        private String _birth;
        private String _ageSex;
        private String _jubsuTime;
        private String _orderEndYn;
        private String _holdYn;
        private String _sunabYn;
        private String _naewonYn;
        private String _jubsuGubun;
        private String _arriveTime;
        private String _lastNaewonDate;
        private String _gaein;
        private String _bpTo;
        private String _bpFrom;
        private String _pulse;
        private String _bodyHeat;

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

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
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

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String LastNaewonDate
        {
            get { return this._lastNaewonDate; }
            set { this._lastNaewonDate = value; }
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

        public PHY2001U04GrdExcelInfo() { }

        public PHY2001U04GrdExcelInfo(String gwaName, String bunho, String suname, String suname2, String doctorName, String birth, String ageSex, String jubsuTime, String orderEndYn, String holdYn, String sunabYn, String naewonYn, String jubsuGubun, String arriveTime, String lastNaewonDate, String gaein, String bpTo, String bpFrom, String pulse, String bodyHeat)
        {
            this._gwaName = gwaName;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._doctorName = doctorName;
            this._birth = birth;
            this._ageSex = ageSex;
            this._jubsuTime = jubsuTime;
            this._orderEndYn = orderEndYn;
            this._holdYn = holdYn;
            this._sunabYn = sunabYn;
            this._naewonYn = naewonYn;
            this._jubsuGubun = jubsuGubun;
            this._arriveTime = arriveTime;
            this._lastNaewonDate = lastNaewonDate;
            this._gaein = gaein;
            this._bpTo = bpTo;
            this._bpFrom = bpFrom;
            this._pulse = pulse;
            this._bodyHeat = bodyHeat;
        }

    }
}