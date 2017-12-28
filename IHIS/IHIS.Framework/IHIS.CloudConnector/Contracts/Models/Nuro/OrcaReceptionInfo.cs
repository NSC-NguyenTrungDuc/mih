using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class OrcaReceptionInfo
    {
        private String _hospCode;
        private String _fkout1001;
        private String _orcaReceptionId;
        private String _gwa;
        private String _doctor;
        private String _orderTime;
        private String _appTime;
        private String _registTime;
        private String _performTime;
        private String _ioFlag;
        private String _timeClazz;
        private String _bundNum;
        private String _clazzCode;
        private String _subCode;
        private String _actCode;
        private String _activeFlg;
        private String _sysId;
        private String _udpId;
        private String _created;
        private String _updated;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String OrcaReceptionId
        {
            get { return this._orcaReceptionId; }
            set { this._orcaReceptionId = value; }
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

        public String OrderTime
        {
            get { return this._orderTime; }
            set { this._orderTime = value; }
        }

        public String AppTime
        {
            get { return this._appTime; }
            set { this._appTime = value; }
        }

        public String RegistTime
        {
            get { return this._registTime; }
            set { this._registTime = value; }
        }

        public String PerformTime
        {
            get { return this._performTime; }
            set { this._performTime = value; }
        }

        public String IoFlag
        {
            get { return this._ioFlag; }
            set { this._ioFlag = value; }
        }

        public String TimeClazz
        {
            get { return this._timeClazz; }
            set { this._timeClazz = value; }
        }

        public String BundNum
        {
            get { return this._bundNum; }
            set { this._bundNum = value; }
        }

        public String ClazzCode
        {
            get { return this._clazzCode; }
            set { this._clazzCode = value; }
        }

        public String SubCode
        {
            get { return this._subCode; }
            set { this._subCode = value; }
        }

        public String ActCode
        {
            get { return this._actCode; }
            set { this._actCode = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UdpId
        {
            get { return this._udpId; }
            set { this._udpId = value; }
        }

        public String Created
        {
            get { return this._created; }
            set { this._created = value; }
        }

        public String Updated
        {
            get { return this._updated; }
            set { this._updated = value; }
        }

        public OrcaReceptionInfo() { }

        public OrcaReceptionInfo(String hospCode, String fkout1001, String orcaReceptionId, String gwa, String doctor, String orderTime, String appTime, String registTime, String performTime, String ioFlag, String timeClazz, String bundNum, String clazzCode, String subCode, String actCode, String activeFlg, String sysId, String udpId, String created, String updated)
        {
            this._hospCode = hospCode;
            this._fkout1001 = fkout1001;
            this._orcaReceptionId = orcaReceptionId;
            this._gwa = gwa;
            this._doctor = doctor;
            this._orderTime = orderTime;
            this._appTime = appTime;
            this._registTime = registTime;
            this._performTime = performTime;
            this._ioFlag = ioFlag;
            this._timeClazz = timeClazz;
            this._bundNum = bundNum;
            this._clazzCode = clazzCode;
            this._subCode = subCode;
            this._actCode = actCode;
            this._activeFlg = activeFlg;
            this._sysId = sysId;
            this._udpId = udpId;
            this._created = created;
            this._updated = updated;
        }

    }
}