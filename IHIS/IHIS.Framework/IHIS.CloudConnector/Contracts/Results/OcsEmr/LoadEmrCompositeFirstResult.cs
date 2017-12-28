using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class LoadEmrCompositeFirstResult : AbstractContractResult
    {
        private OcsoOCS1003P01CheckYResult _ocs1003p01CheckY;
        private OCS2015U00GetMaxSizeResult _ocs2015u00GetMaxSize;
        private OCS2015U06EmrTagResult _ocs2015u06EmrTag;
        private OcsoOCS1003P01LayPatResult _ocs1003p01LayPat;
        private PatientInfoLoadPatientNaewonListResult _patientInfoNaewonLst;
        private StringResult _environInfoSysDate;
        private PrOcsLoadNaewonInfoResult _ocsLoadNaewonInfo;
        private OCS2015U00GetPatientInfoResult _ocs2015u00GetPatientInfo;

        public OcsoOCS1003P01CheckYResult Ocs1003p01CheckY
        {
            get { return this._ocs1003p01CheckY; }
            set { this._ocs1003p01CheckY = value; }
        }

        public OCS2015U00GetMaxSizeResult Ocs2015u00GetMaxSize
        {
            get { return this._ocs2015u00GetMaxSize; }
            set { this._ocs2015u00GetMaxSize = value; }
        }

        public OCS2015U06EmrTagResult Ocs2015u06EmrTag
        {
            get { return this._ocs2015u06EmrTag; }
            set { this._ocs2015u06EmrTag = value; }
        }

        public OcsoOCS1003P01LayPatResult Ocs1003p01LayPat
        {
            get { return this._ocs1003p01LayPat; }
            set { this._ocs1003p01LayPat = value; }
        }

        public PatientInfoLoadPatientNaewonListResult PatientInfoNaewonLst
        {
            get { return this._patientInfoNaewonLst; }
            set { this._patientInfoNaewonLst = value; }
        }

        public StringResult EnvironInfoSysDate
        {
            get { return this._environInfoSysDate; }
            set { this._environInfoSysDate = value; }
        }

        public PrOcsLoadNaewonInfoResult OcsLoadNaewonInfo
        {
            get { return this._ocsLoadNaewonInfo; }
            set { this._ocsLoadNaewonInfo = value; }
        }

        public OCS2015U00GetPatientInfoResult Ocs2015u00GetPatientInfo
        {
            get { return this._ocs2015u00GetPatientInfo; }
            set { this._ocs2015u00GetPatientInfo = value; }
        }

        public LoadEmrCompositeFirstResult() { }

    }
}