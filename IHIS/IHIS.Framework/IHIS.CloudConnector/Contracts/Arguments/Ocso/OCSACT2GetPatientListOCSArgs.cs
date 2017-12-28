using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2GetPatientListOCSArgs : IContractArgs
    {
        private String _cboSystem;
        private String _cboVal;
        private String _cboPart;
        private String _fromDate;
        private String _toDate;
        private String _bunho;
        private String _actGubun;
        private String _jundalTableCode;
        private String _ioGubun;
        private String _systemId;

        public String CboSystem
        {
            get { return this._cboSystem; }
            set { this._cboSystem = value; }
        }

        public String CboVal
        {
            get { return this._cboVal; }
            set { this._cboVal = value; }
        }

        public String CboPart
        {
            get { return this._cboPart; }
            set { this._cboPart = value; }
        }

        public String FromDate
        {
            get { return this._fromDate; }
            set { this._fromDate = value; }
        }

        public String ToDate
        {
            get { return this._toDate; }
            set { this._toDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ActGubun
        {
            get { return this._actGubun; }
            set { this._actGubun = value; }
        }

        public String JundalTableCode
        {
            get { return this._jundalTableCode; }
            set { this._jundalTableCode = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public OCSACT2GetPatientListOCSArgs() { }

        public OCSACT2GetPatientListOCSArgs(String cboSystem, String cboVal, String cboPart, String fromDate, String toDate, String bunho, String actGubun, String jundalTableCode, String ioGubun, String systemId)
        {
            this._cboSystem = cboSystem;
            this._cboVal = cboVal;
            this._cboPart = cboPart;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._bunho = bunho;
            this._actGubun = actGubun;
            this._jundalTableCode = jundalTableCode;
            this._ioGubun = ioGubun;
            this._systemId = systemId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2GetPatientListOCSRequest();
        }
    }
}