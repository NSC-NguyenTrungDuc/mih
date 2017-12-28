using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdINP2004Info
    {
        private String _bunho;
        private String _suname;
        private String _ipwonDate;
        private String _dataDate;
        private String _fkinp1001;
        private String _pkinp1002;
        private String _fromGwa;
        private String _toGwa;
        private String _fromDoctor;
        private String _toDoctor;
        private String _fromHoDong1;
        private String _toHoDong1;
        private String _fromHoCode1;
        private String _toHoCode1;
        private String _fromBedNo;
        private String _toBedNo;
        private String _sendYn;
        private String _ifFlag;

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

        public String IpwonDate
        {
            get { return this._ipwonDate; }
            set { this._ipwonDate = value; }
        }

        public String DataDate
        {
            get { return this._dataDate; }
            set { this._dataDate = value; }
        }

        public String Fkinp1001
        {
            get { return this._fkinp1001; }
            set { this._fkinp1001 = value; }
        }

        public String Pkinp1002
        {
            get { return this._pkinp1002; }
            set { this._pkinp1002 = value; }
        }

        public String FromGwa
        {
            get { return this._fromGwa; }
            set { this._fromGwa = value; }
        }

        public String ToGwa
        {
            get { return this._toGwa; }
            set { this._toGwa = value; }
        }

        public String FromDoctor
        {
            get { return this._fromDoctor; }
            set { this._fromDoctor = value; }
        }

        public String ToDoctor
        {
            get { return this._toDoctor; }
            set { this._toDoctor = value; }
        }

        public String FromHoDong1
        {
            get { return this._fromHoDong1; }
            set { this._fromHoDong1 = value; }
        }

        public String ToHoDong1
        {
            get { return this._toHoDong1; }
            set { this._toHoDong1 = value; }
        }

        public String FromHoCode1
        {
            get { return this._fromHoCode1; }
            set { this._fromHoCode1 = value; }
        }

        public String ToHoCode1
        {
            get { return this._toHoCode1; }
            set { this._toHoCode1 = value; }
        }

        public String FromBedNo
        {
            get { return this._fromBedNo; }
            set { this._fromBedNo = value; }
        }

        public String ToBedNo
        {
            get { return this._toBedNo; }
            set { this._toBedNo = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public String IfFlag
        {
            get { return this._ifFlag; }
            set { this._ifFlag = value; }
        }

        public ORDERTRANSGrdINP2004Info() { }

        public ORDERTRANSGrdINP2004Info(String bunho, String suname, String ipwonDate, String dataDate, String fkinp1001, String pkinp1002, String fromGwa, String toGwa, String fromDoctor, String toDoctor, String fromHoDong1, String toHoDong1, String fromHoCode1, String toHoCode1, String fromBedNo, String toBedNo, String sendYn, String ifFlag)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._ipwonDate = ipwonDate;
            this._dataDate = dataDate;
            this._fkinp1001 = fkinp1001;
            this._pkinp1002 = pkinp1002;
            this._fromGwa = fromGwa;
            this._toGwa = toGwa;
            this._fromDoctor = fromDoctor;
            this._toDoctor = toDoctor;
            this._fromHoDong1 = fromHoDong1;
            this._toHoDong1 = toHoDong1;
            this._fromHoCode1 = fromHoCode1;
            this._toHoCode1 = toHoCode1;
            this._fromBedNo = fromBedNo;
            this._toBedNo = toBedNo;
            this._sendYn = sendYn;
            this._ifFlag = ifFlag;
        }

    }
}