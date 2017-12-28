using System;

namespace EmrDocker.Models
{
    public class OrderInfo
    {
        private String _content;
        private String _gubunBass;
        private String _hangmogCode;
        private String _actionDoYn;
        private String _bunho;
        private String _doctor;
        private String _gwa;
        private String _naewonDate;
        private String _naewonKey;
        private String _inputTab;
        private string _hangmogName;
        private string _inputGubunName;
        private string _orderGubunName;
        private string _inputTabAndGroupSer;
        private string _orderDisplayOther;
        private string _nalsu;
        private string _dv;
        private string _ordDanuiName;
        private string _suryang;
        private string _bogyongName;

        private string _dvTime;
        private string _mixSet;
        private string _jusaName;
        private string _unequalDosage;
        private string _hopeDate;
        private string _comment;
        private string _numberOfDay;
        private string _groupSer;

        public string DvTime
        {
            get { return _dvTime; }
            set { _dvTime = value; }
        }

        public string MixSet
        {
            get { return _mixSet; }
            set { _mixSet = value; }
        }

        public string JusaName
        {
            get { return _jusaName; }
            set { _jusaName = value; }
        }

        public string UnequalDosage
        {
            get { return _unequalDosage; }
            set { _unequalDosage = value; }
        }

        public string HopeDate
        {
            get { return _hopeDate; }
            set { _hopeDate = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string Nalsu
        {
            get { return _nalsu; }
            set { _nalsu = value; }
        }

        public string Dv
        {
            get { return _dv; }
            set { _dv = value; }
        }

        public string OrdDanuiName
        {
            get { return _ordDanuiName; }
            set { _ordDanuiName = value; }
        }

        public string Suryang
        {
            get { return _suryang; }
            set { _suryang = value; }
        }

        public string BogyongName
        {
            get { return _bogyongName; }
            set { _bogyongName = value; }
        }

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public String GubunBass
        {
            get { return _gubunBass; }
            set { _gubunBass = value; }
        }

        public String HangmogCode
        {
            get { return _hangmogCode; }
            set { _hangmogCode = value; }
        }

        public String ActionDoYn
        {
            get { return _actionDoYn; }
            set { _actionDoYn = value; }
        }

        public String Bunho
        {
            get { return _bunho; }
            set { _bunho = value; }
        }

        public String Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public String Gwa
        {
            get { return _gwa; }
            set { _gwa = value; }
        }

        public String NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }

        public String NaewonKey
        {
            get { return _naewonKey; }
            set { _naewonKey = value; }
        }

        public String InputTab
        {
            get { return _inputTab; }
            set { _inputTab = value; }
        }

        public string HangmogName
        {
            get
            {
                return _hangmogName;
            }
            set
            {
                _hangmogName = value;
            }
        }

        public string InputGubunName
        {
            get
            {
                return _inputGubunName;
            }
            set
            {
                _inputGubunName = value;
            }
        }

        public string OrderGubunName
        {
            get
            {
                return _orderGubunName;
            }
            set
            {
                _orderGubunName = value;
            }
        }

        public string InputTabAndGroupSer
        {
            get
            {
                return _inputTabAndGroupSer;
            }
            set
            {
                _inputTabAndGroupSer = value;
            }
        }
        public string NumberOfDay
        {
            get { return _numberOfDay; }
            set { _numberOfDay = value; }
        }

        public string GroupSer
        {
            get { return _groupSer; }
            set { _groupSer = value; }
        }


        public String OrderDisplayOther
        {
            get { return _orderDisplayOther; }
            set { _orderDisplayOther = value; }
        }

        public OrderInfo() { }

        public OrderInfo(string content, string gubunBass, string hangmogCode, string actionDoYn, string bunho, string doctor, string gwa, string naewonDate, string naewonKey, string inputTab, string hangmogName, string inputGubunName, string orderGubunName, string inputTabAndGroupSer, string orderDisplayOther, string nalsu, string dv, string ordDanuiName, string suryang, string bogyongName, string dvTime, string mixSet, string jusaName, string unequalDosage, string hopeDate, string comment, string numberOfDay, string groupSer)
        {
            _content = content;
            _gubunBass = gubunBass;
            _hangmogCode = hangmogCode;
            _actionDoYn = actionDoYn;
            _bunho = bunho;
            _doctor = doctor;
            _gwa = gwa;
            _naewonDate = naewonDate;
            _naewonKey = naewonKey;
            _inputTab = inputTab;
            _hangmogName = hangmogName;
            _inputGubunName = inputGubunName;
            _orderGubunName = orderGubunName;
            _inputTabAndGroupSer = inputTabAndGroupSer;
            _orderDisplayOther = orderDisplayOther;
            _nalsu = nalsu;
            _dv = dv;
            _ordDanuiName = ordDanuiName;
            _suryang = suryang;
            _bogyongName = bogyongName;
            _dvTime = dvTime;
            _mixSet = mixSet;
            _jusaName = jusaName;
            _unequalDosage = unequalDosage;
            _hopeDate = hopeDate;
            _comment = comment;
            _numberOfDay = numberOfDay;
            _groupSer = groupSer;
        }
    }
}