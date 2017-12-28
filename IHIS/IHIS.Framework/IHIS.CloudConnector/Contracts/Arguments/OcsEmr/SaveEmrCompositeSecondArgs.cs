using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class SaveEmrCompositeSecondArgs : IContractArgs
    {
        private OCS1003P01GrdPatientArgs _grdPatient;
        private OcsoOCS1003P01BtnListQueryArgs _btnListQuery;
        private NUR1016U00GrdNUR1016Args _grdNur1016;
        private NUR1017U00GrdNUR1017Args _grdNur1017;
        private OUT0106U00GridListArgs _grdListOut0106;
        private OCS2015U00GetPatientInfoArgs _getPatientInfo;
        private PatientInfoLoadPatientNaewonListArgs _patientInfoLoad;
        private FormEnvironInfoSysDateArgs _envSysDate;
        private PrOcsLoadNaewonInfoArgs _ocsLoadNaewon;
        private OCS2015U09GetTemplateComboBoxArgs _templateCombo;
        private OCS2015U06OrderTypeComboArgs _orderTypeCombo;

        public OCS1003P01GrdPatientArgs GrdPatient
        {
            get { return this._grdPatient; }
            set { this._grdPatient = value; }
        }

        public OcsoOCS1003P01BtnListQueryArgs BtnListQuery
        {
            get { return this._btnListQuery; }
            set { this._btnListQuery = value; }
        }

        public NUR1016U00GrdNUR1016Args GrdNur1016
        {
            get { return this._grdNur1016; }
            set { this._grdNur1016 = value; }
        }

        public NUR1017U00GrdNUR1017Args GrdNur1017
        {
            get { return this._grdNur1017; }
            set { this._grdNur1017 = value; }
        }

        public OUT0106U00GridListArgs GrdListOut0106
        {
            get { return this._grdListOut0106; }
            set { this._grdListOut0106 = value; }
        }

        public OCS2015U00GetPatientInfoArgs GetPatientInfo
        {
            get { return this._getPatientInfo; }
            set { this._getPatientInfo = value; }
        }

        public PatientInfoLoadPatientNaewonListArgs PatientInfoLoad
        {
            get { return this._patientInfoLoad; }
            set { this._patientInfoLoad = value; }
        }

        public FormEnvironInfoSysDateArgs EnvSysDate
        {
            get { return this._envSysDate; }
            set { this._envSysDate = value; }
        }

        public PrOcsLoadNaewonInfoArgs OcsLoadNaewon
        {
            get { return this._ocsLoadNaewon; }
            set { this._ocsLoadNaewon = value; }
        }

        public OCS2015U09GetTemplateComboBoxArgs TemplateCombo
        {
            get { return this._templateCombo; }
            set { this._templateCombo = value; }
        }

        public OCS2015U06OrderTypeComboArgs OrderTypeCombo
        {
            get { return this._orderTypeCombo; }
            set { this._orderTypeCombo = value; }
        }

        public SaveEmrCompositeSecondArgs() { }

        public SaveEmrCompositeSecondArgs(OCS1003P01GrdPatientArgs grdPatient, OcsoOCS1003P01BtnListQueryArgs btnListQuery, NUR1016U00GrdNUR1016Args grdNur1016, NUR1017U00GrdNUR1017Args grdNur1017, OUT0106U00GridListArgs grdListOut0106, OCS2015U00GetPatientInfoArgs getPatientInfo, PatientInfoLoadPatientNaewonListArgs patientInfoLoad, FormEnvironInfoSysDateArgs envSysDate, PrOcsLoadNaewonInfoArgs ocsLoadNaewon, OCS2015U09GetTemplateComboBoxArgs templateCombo, OCS2015U06OrderTypeComboArgs orderTypeCombo)
        {
            this._grdPatient = grdPatient;
            this._btnListQuery = btnListQuery;
            this._grdNur1016 = grdNur1016;
            this._grdNur1017 = grdNur1017;
            this._grdListOut0106 = grdListOut0106;
            this._getPatientInfo = getPatientInfo;
            this._patientInfoLoad = patientInfoLoad;
            this._envSysDate = envSysDate;
            this._ocsLoadNaewon = ocsLoadNaewon;
            this._templateCombo = templateCombo;
            this._orderTypeCombo = orderTypeCombo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveEmrCompositeSecondRequest();
        }
    }
}