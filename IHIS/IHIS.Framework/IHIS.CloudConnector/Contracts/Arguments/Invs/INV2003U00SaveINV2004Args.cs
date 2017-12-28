using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Invs
{
    public class INV2003U00SaveINV2004Args : IContractArgs
    {
        private String _hospCode;
        private String _fkinv2004;
        private String _jaeryoCode;
        private String _sysDate;
        private String _sysId;
        private String _updDate;
        private String _updId;
        private String _pkinv2004;
        private String _fkinv2003;
        private String _chulgoQty;
        private String _chulgoDanga;
        private String _remark;
        private String _dataRowState;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkinv2004
        {
            get { return this._fkinv2004; }
            set { this._fkinv2004 = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

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

        public String Pkinv2004
        {
            get { return this._pkinv2004; }
            set { this._pkinv2004 = value; }
        }

        public String Fkinv2003
        {
            get { return this._fkinv2003; }
            set { this._fkinv2003 = value; }
        }

        public String ChulgoQty
        {
            get { return this._chulgoQty; }
            set { this._chulgoQty = value; }
        }

        public String ChulgoDanga
        {
            get { return this._chulgoDanga; }
            set { this._chulgoDanga = value; }
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

        public INV2003U00SaveINV2004Args() { }

        public INV2003U00SaveINV2004Args(String hospCode, String fkinv2004, String jaeryoCode, String sysDate, String sysId, String updDate, String updId, String pkinv2004, String fkinv2003, String chulgoQty, String chulgoDanga, String remark, String dataRowState)
        {
            this._hospCode = hospCode;
            this._fkinv2004 = fkinv2004;
            this._jaeryoCode = jaeryoCode;
            this._sysDate = sysDate;
            this._sysId = sysId;
            this._updDate = updDate;
            this._updId = updId;
            this._pkinv2004 = pkinv2004;
            this._fkinv2003 = fkinv2003;
            this._chulgoQty = chulgoQty;
            this._chulgoDanga = chulgoDanga;
            this._remark = remark;
            this._dataRowState = dataRowState;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.INV2003U00SaveINV2004Request();
        }
    }
}