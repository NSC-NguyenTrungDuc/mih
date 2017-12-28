using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DrgsDRG5100P01OrderOrderListItemInfo
    {
        private String _drgBunho;
        private String _bunho;
        private String _orderDate;
        private String _jubsuDate;
        private String _drgJubsuDate;
        private String _jubsuTime;
        private String _doctor;
        private String _doctorName;
        private String _gwa;
        private String _buseoName;
        private String _actDate;
        private String _actYn;
        private String _sunabDate;
        private String _chulgoDate;
        private String _boryuYn;
        private String _chulgoBuseo;
        private String _orderRemark;
        private String _drgRemark;
        private String _wonyoiOrderYn;
        private String _fkout1001;
        private String _fkocs1003;
        private String _naewonYn;
        private String _ifDataSendYn;

        public String DrgBunho
        {
            get { return this._drgBunho; }
            set { this._drgBunho = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String JubsuDate
        {
            get { return this._jubsuDate; }
            set { this._jubsuDate = value; }
        }

        public String DrgJubsuDate
        {
            get { return this._drgJubsuDate; }
            set { this._drgJubsuDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
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

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String BuseoName
        {
            get { return this._buseoName; }
            set { this._buseoName = value; }
        }

        public String ActDate
        {
            get { return this._actDate; }
            set { this._actDate = value; }
        }

        public String ActYn
        {
            get { return this._actYn; }
            set { this._actYn = value; }
        }

        public String SunabDate
        {
            get { return this._sunabDate; }
            set { this._sunabDate = value; }
        }

        public String ChulgoDate
        {
            get { return this._chulgoDate; }
            set { this._chulgoDate = value; }
        }

        public String BoryuYn
        {
            get { return this._boryuYn; }
            set { this._boryuYn = value; }
        }

        public String ChulgoBuseo
        {
            get { return this._chulgoBuseo; }
            set { this._chulgoBuseo = value; }
        }

        public String OrderRemark
        {
            get { return this._orderRemark; }
            set { this._orderRemark = value; }
        }

        public String DrgRemark
        {
            get { return this._drgRemark; }
            set { this._drgRemark = value; }
        }

        public String WonyoiOrderYn
        {
            get { return this._wonyoiOrderYn; }
            set { this._wonyoiOrderYn = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String IfDataSendYn
        {
            get { return this._ifDataSendYn; }
            set { this._ifDataSendYn = value; }
        }

        public DrgsDRG5100P01OrderOrderListItemInfo() { }

        public DrgsDRG5100P01OrderOrderListItemInfo(String drgBunho, String bunho, String orderDate, String jubsuDate, String drgJubsuDate, String jubsuTime, String doctor, String doctorName, String gwa, String buseoName, String actDate, String actYn, String sunabDate, String chulgoDate, String boryuYn, String chulgoBuseo, String orderRemark, String drgRemark, String wonyoiOrderYn, String fkout1001, String fkocs1003, String naewonYn, String ifDataSendYn)
        {
            this._drgBunho = drgBunho;
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._jubsuDate = jubsuDate;
            this._drgJubsuDate = drgJubsuDate;
            this._jubsuTime = jubsuTime;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._gwa = gwa;
            this._buseoName = buseoName;
            this._actDate = actDate;
            this._actYn = actYn;
            this._sunabDate = sunabDate;
            this._chulgoDate = chulgoDate;
            this._boryuYn = boryuYn;
            this._chulgoBuseo = chulgoBuseo;
            this._orderRemark = orderRemark;
            this._drgRemark = drgRemark;
            this._wonyoiOrderYn = wonyoiOrderYn;
            this._fkout1001 = fkout1001;
            this._fkocs1003 = fkocs1003;
            this._naewonYn = naewonYn;
            this._ifDataSendYn = ifDataSendYn;
        }

    }
}