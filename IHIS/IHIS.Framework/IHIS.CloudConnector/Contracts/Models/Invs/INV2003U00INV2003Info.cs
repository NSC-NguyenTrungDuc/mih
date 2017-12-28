using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV2003U00INV2003Info
    {
        private String _sysDate;
        private String _sysId;
        private String _updDate;
        private String _updId;
        private String _hospCode;
        private String _pkinv2003;
        private String _churiDate;
        private String _churiBuseo;
        private String _chulgoType;
        private String _churiSeq;
        private String _jaeryoGubun;
        private String _ipchulType;
        private String _inOutGubun;
        private String _remark;
        private String _dataRowState;

        public String SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpdDate
        {
            get { return this._updDate; }
            set { this._updDate = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkinv2003
        {
            get { return this._pkinv2003; }
            set { this._pkinv2003 = value; }
        }

        public String ChuriDate
        {
            get { return this._churiDate; }
            set { this._churiDate = value; }
        }

        public String ChuriBuseo
        {
            get { return this._churiBuseo; }
            set { this._churiBuseo = value; }
        }

        public String ChulgoType
        {
            get { return this._chulgoType; }
            set { this._chulgoType = value; }
        }

        public String ChuriSeq
        {
            get { return this._churiSeq; }
            set { this._churiSeq = value; }
        }

        public String JaeryoGubun
        {
            get { return this._jaeryoGubun; }
            set { this._jaeryoGubun = value; }
        }

        public String IpchulType
        {
            get { return this._ipchulType; }
            set { this._ipchulType = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public INV2003U00INV2003Info() { }

        public INV2003U00INV2003Info(String sysDate, String sysId, String updDate, String updId, String hospCode, String pkinv2003, String churiDate, String churiBuseo, String chulgoType, String churiSeq, String jaeryoGubun, String ipchulType, String inOutGubun, String remark, String dataRowState)
        {
            this._sysDate = sysDate;
            this._sysId = sysId;
            this._updDate = updDate;
            this._updId = updId;
            this._hospCode = hospCode;
            this._pkinv2003 = pkinv2003;
            this._churiDate = churiDate;
            this._churiBuseo = churiBuseo;
            this._chulgoType = chulgoType;
            this._churiSeq = churiSeq;
            this._jaeryoGubun = jaeryoGubun;
            this._ipchulType = ipchulType;
            this._inOutGubun = inOutGubun;
            this._remark = remark;
            this._dataRowState = dataRowState;
        }

    }
}