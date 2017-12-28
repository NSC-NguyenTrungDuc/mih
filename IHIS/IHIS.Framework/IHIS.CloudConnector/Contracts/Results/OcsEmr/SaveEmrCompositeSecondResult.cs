using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.Nuri;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class SaveEmrCompositeSecondResult : AbstractContractResult
    {
        private OCS1003P01GrdPatientResult _grdPatient;
        private OcsoOCS1003P01BtnListQueryResult _btnListQuery;
        private NUR1016U00GrdNUR1016Result _grdNur1016;
        private NUR1017U00GrdNUR1017Result _grdNur1017;
        private OUT0106U00GridListResult _grdListOut0106;
        private OCS2015U00GetPatientInfoResult _getPatientInfo;
        private PatientInfoLoadPatientNaewonListResult _patientInfoLoad;
        private StringResult _envSysDate;
        private PrOcsLoadNaewonInfoResult _ocsLoadNaewon;
        private OCS2015U09GetTemplateComboBoxResult _templateCombo;
        private OCS2015U06OrderTypeComboResult _orderTypeCombo;

        public OCS1003P01GrdPatientResult GrdPatient
        {
            get { return this._grdPatient; }
            set { this._grdPatient = value; }
        }

        public OcsoOCS1003P01BtnListQueryResult BtnListQuery
        {
            get { return this._btnListQuery; }
            set { this._btnListQuery = value; }
        }

        public NUR1016U00GrdNUR1016Result GrdNur1016
        {
            get { return this._grdNur1016; }
            set { this._grdNur1016 = value; }
        }

        public NUR1017U00GrdNUR1017Result GrdNur1017
        {
            get { return this._grdNur1017; }
            set { this._grdNur1017 = value; }
        }

        public OUT0106U00GridListResult GrdListOut0106
        {
            get { return this._grdListOut0106; }
            set { this._grdListOut0106 = value; }
        }

        public OCS2015U00GetPatientInfoResult GetPatientInfo
        {
            get { return this._getPatientInfo; }
            set { this._getPatientInfo = value; }
        }

        public PatientInfoLoadPatientNaewonListResult PatientInfoLoad
        {
            get { return this._patientInfoLoad; }
            set { this._patientInfoLoad = value; }
        }

        public StringResult EnvSysDate
        {
            get { return this._envSysDate; }
            set { this._envSysDate = value; }
        }

        public PrOcsLoadNaewonInfoResult OcsLoadNaewon
        {
            get { return this._ocsLoadNaewon; }
            set { this._ocsLoadNaewon = value; }
        }

        public OCS2015U09GetTemplateComboBoxResult TemplateCombo
        {
            get { return this._templateCombo; }
            set { this._templateCombo = value; }
        }

        public OCS2015U06OrderTypeComboResult OrderTypeCombo
        {
            get { return this._orderTypeCombo; }
            set { this._orderTypeCombo = value; }
        }

        public SaveEmrCompositeSecondResult() { }

    }
}