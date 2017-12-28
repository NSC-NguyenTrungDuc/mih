using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DRG0201U00GrdOrderInfo
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
        private String _actTime;
        private String _actYn;
        private String _sunabDate;
        private String _chulgoDate;
        private String _actUserName;
        private String _wonyoiOrderYn;
        private String _disGubun;
        private String _orderRemark;
        private String _drgRemark;
        private String _fkout1001;
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

        public String ActTime
        {
            get { return this._actTime; }
            set { this._actTime = value; }
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

        public String ActUserName
        {
            get { return this._actUserName; }
            set { this._actUserName = value; }
        }

        public String WonyoiOrderYn
        {
            get { return this._wonyoiOrderYn; }
            set { this._wonyoiOrderYn = value; }
        }

        public String DisGubun
        {
            get { return this._disGubun; }
            set { this._disGubun = value; }
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

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String IfDataSendYn
        {
            get { return this._ifDataSendYn; }
            set { this._ifDataSendYn = value; }
        }

        public DRG0201U00GrdOrderInfo() { }

        public DRG0201U00GrdOrderInfo(String drgBunho, String bunho, String orderDate, String jubsuDate, String drgJubsuDate, String jubsuTime, String doctor, String doctorName, String gwa, String buseoName, String actDate, String actTime, String actYn, String sunabDate, String chulgoDate, String actUserName, String wonyoiOrderYn, String disGubun, String orderRemark, String drgRemark, String fkout1001, String ifDataSendYn)
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
            this._actTime = actTime;
            this._actYn = actYn;
            this._sunabDate = sunabDate;
            this._chulgoDate = chulgoDate;
            this._actUserName = actUserName;
            this._wonyoiOrderYn = wonyoiOrderYn;
            this._disGubun = disGubun;
            this._orderRemark = orderRemark;
            this._drgRemark = drgRemark;
            this._fkout1001 = fkout1001;
            this._ifDataSendYn = ifDataSendYn;
        }

    }
}