using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DrgsDRG5100P01DrgwonneaOWnCurListInfo
    {
        private String _bunho;
        private String _drgBunho;
        private String _naewonDate;
        private String _jubsuDate;
        private String _orderDate;
        private String _serialV;
        private String _serialText;
        private String _gwaName;
        private String _doctorName;
        private String _suname;
        private String _suname2;
        private String _birth;
        private String _sexAge;
        private String _otherGwa;
        private String _doOrder;
        private String _gigamDate;
        private String _address;
        private String _tel;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String DrgBunho
        {
            get { return this._drgBunho; }
            set { this._drgBunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String SerialV
        {
            get { return this._serialV; }
            set { this._serialV = value; }
        }

        public String SerialText
        {
            get { return this._serialText; }
            set { this._serialText = value; }
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

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String SexAge
        {
            get { return this._sexAge; }
            set { this._sexAge = value; }
        }

        public String OtherGwa
        {
            get { return this._otherGwa; }
            set { this._otherGwa = value; }
        }

        public String DoOrder
        {
            get { return this._doOrder; }
            set { this._doOrder = value; }
        }

        public String GigamDate
        {
            get { return this._gigamDate; }
            set { this._gigamDate = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public DrgsDRG5100P01DrgwonneaOWnCurListInfo() { }

        public DrgsDRG5100P01DrgwonneaOWnCurListInfo(String bunho, String drgBunho, String naewonDate, String jubsuDate, String orderDate, String serialV, String serialText, String gwaName, String doctorName, String suname, String suname2, String birth, String sexAge, String otherGwa, String doOrder, String gigamDate, String address, String tel)
        {
            this._bunho = bunho;
            this._drgBunho = drgBunho;
            this._naewonDate = naewonDate;
            this._jubsuDate = jubsuDate;
            this._orderDate = orderDate;
            this._serialV = serialV;
            this._serialText = serialText;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._suname = suname;
            this._suname2 = suname2;
            this._birth = birth;
            this._sexAge = sexAge;
            this._otherGwa = otherGwa;
            this._doOrder = doOrder;
            this._gigamDate = gigamDate;
            this._address = address;
            this._tel = tel;
        }

    }
}