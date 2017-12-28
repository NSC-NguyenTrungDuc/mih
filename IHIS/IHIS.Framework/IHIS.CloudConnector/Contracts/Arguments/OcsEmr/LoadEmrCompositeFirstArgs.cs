using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class LoadEmrCompositeFirstArgs : IContractArgs
    {
        private OcsoOCS1003P01CheckYArgs _ocs1003p01CheckY;
        private OCS2015U00GetMaxSizeArgs _ocs2015u00GetMaxSize;
        private OCS2015U06EmrTagArgs _ocs2015u06EmrTag;
        private OcsoOCS1003P01LayPatArgs _ocs1003p01LayPat;
        private PatientInfoLoadPatientNaewonListArgs _patientInfoNaewonLst;
        private FormEnvironInfoSysDateArgs _environInfoSysDate;
        private PrOcsLoadNaewonInfoArgs _ocsLoadNaewonInfo;
        private OCS2015U00GetPatientInfoArgs _ocs2015u00GetPatientInfo;

        public OcsoOCS1003P01CheckYArgs Ocs1003p01CheckY
        {
            get { return this._ocs1003p01CheckY; }
            set { this._ocs1003p01CheckY = value; }
        }

        public OCS2015U00GetMaxSizeArgs Ocs2015u00GetMaxSize
        {
            get { return this._ocs2015u00GetMaxSize; }
            set { this._ocs2015u00GetMaxSize = value; }
        }

        public OCS2015U06EmrTagArgs Ocs2015u06EmrTag
        {
            get { return this._ocs2015u06EmrTag; }
            set { this._ocs2015u06EmrTag = value; }
        }

        public OcsoOCS1003P01LayPatArgs Ocs1003p01LayPat
        {
            get { return this._ocs1003p01LayPat; }
            set { this._ocs1003p01LayPat = value; }
        }

        public PatientInfoLoadPatientNaewonListArgs PatientInfoNaewonLst
        {
            get { return this._patientInfoNaewonLst; }
            set { this._patientInfoNaewonLst = value; }
        }

        public FormEnvironInfoSysDateArgs EnvironInfoSysDate
        {
            get { return this._environInfoSysDate; }
            set { this._environInfoSysDate = value; }
        }

        public PrOcsLoadNaewonInfoArgs OcsLoadNaewonInfo
        {
            get { return this._ocsLoadNaewonInfo; }
            set { this._ocsLoadNaewonInfo = value; }
        }

        public OCS2015U00GetPatientInfoArgs Ocs2015u00GetPatientInfo
        {
            get { return this._ocs2015u00GetPatientInfo; }
            set { this._ocs2015u00GetPatientInfo = value; }
        }

        public LoadEmrCompositeFirstArgs() { }

        public LoadEmrCompositeFirstArgs(OcsoOCS1003P01CheckYArgs ocs1003p01CheckY, OCS2015U00GetMaxSizeArgs ocs2015u00GetMaxSize, OCS2015U06EmrTagArgs ocs2015u06EmrTag, OcsoOCS1003P01LayPatArgs ocs1003p01LayPat, PatientInfoLoadPatientNaewonListArgs patientInfoNaewonLst, FormEnvironInfoSysDateArgs environInfoSysDate, PrOcsLoadNaewonInfoArgs ocsLoadNaewonInfo, OCS2015U00GetPatientInfoArgs ocs2015u00GetPatientInfo)
        {
            this._ocs1003p01CheckY = ocs1003p01CheckY;
            this._ocs2015u00GetMaxSize = ocs2015u00GetMaxSize;
            this._ocs2015u06EmrTag = ocs2015u06EmrTag;
            this._ocs1003p01LayPat = ocs1003p01LayPat;
            this._patientInfoNaewonLst = patientInfoNaewonLst;
            this._environInfoSysDate = environInfoSysDate;
            this._ocsLoadNaewonInfo = ocsLoadNaewonInfo;
            this._ocs2015u00GetPatientInfo = ocs2015u00GetPatientInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadEmrCompositeFirstRequest();
        }
    }
}