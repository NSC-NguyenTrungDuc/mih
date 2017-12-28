using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.Ocsemr;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Nuri;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class LoadEmrCompositeSecondResult : AbstractContractResult
    {
        private StringResult _environInfoSysDate;
        private OCS2015U21ControlDataValidatingResult _ocs2015u21ControlDataValidate;
        private OpenAllergyInfoResult _openAllergyInfo;
        private LoadConsultEndYNResult _loadConsultEndYn;
        private OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult _ocs1003p01LoadConsultEnd;
        private LoadPatientSpecificCommentResult _loadPatientSpecComment;
        private GetOutJinryoCommentCntResult _getOutJinryoComment;
        private IpwonReserStatusResult _ipwonReserStatus;
        private XPaInfoBoxResult _xpaInfoBox;
        private OCS1003P01SettingVisibleByUserResult _ocs1003p01SettingVisible;
        private OcsoOCS1003P01GridReserOrderListResult _ocs1003p01GridReserOrder;
        private OUT0106U00GridListResult _out0106u00GridLst;
        private NuroPatientReceptionHistoryListResult _nuroPatientReceptionHis;
        private EMRSetDataForTvExamHistResult _emrSetDataTvxam;
        private OcsEmrHistoryClinicReferResult _ocsemrHisClinicRefer;
        private OCS2015U06EmrRecordResult _ocs2015u06EmrRecord;
        private SettingDiscussResult _settingDiscuss;
        private OCS2015U00GetDiscussNotifyResult _ocs2015u00GetDiscussNotify;
        private EMRGetLatestWarningStatusResult _emrGetLastestWarning;
        private OCS0103U13CboListResult _ocs0103u13CboLst;
        private OCS1003P01GrdPatientResult _ocs1003p01GrdPatient;
        private OcsoOCS1003P01BtnListQueryResult _ocs1003p01BtnListQuery;
        private NUR1016U00GrdNUR1016Result _nur1016u00Grd;
        private NUR1017U00GrdNUR1017Result _nur1017u00Grd;
        private OCS2015U00GetPatientInfoResult _ocs2015u00GetPatientInfo;
        private OCS2015U09GetTemplateComboBoxResult _ocs2015u09GetTemplateCombo;
        private OCS2015U06OrderTypeComboResult _ocs2015u06OrderTypeCombo;

        public StringResult EnvironInfoSysDate
        {
            get { return this._environInfoSysDate; }
            set { this._environInfoSysDate = value; }
        }

        public OCS2015U21ControlDataValidatingResult Ocs2015u21ControlDataValidate
        {
            get { return this._ocs2015u21ControlDataValidate; }
            set { this._ocs2015u21ControlDataValidate = value; }
        }

        public OpenAllergyInfoResult OpenAllergyInfo
        {
            get { return this._openAllergyInfo; }
            set { this._openAllergyInfo = value; }
        }

        public LoadConsultEndYNResult LoadConsultEndYn
        {
            get { return this._loadConsultEndYn; }
            set { this._loadConsultEndYn = value; }
        }

        public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult Ocs1003p01LoadConsultEnd
        {
            get { return this._ocs1003p01LoadConsultEnd; }
            set { this._ocs1003p01LoadConsultEnd = value; }
        }

        public LoadPatientSpecificCommentResult LoadPatientSpecComment
        {
            get { return this._loadPatientSpecComment; }
            set { this._loadPatientSpecComment = value; }
        }

        public GetOutJinryoCommentCntResult GetOutJinryoComment
        {
            get { return this._getOutJinryoComment; }
            set { this._getOutJinryoComment = value; }
        }

        public IpwonReserStatusResult IpwonReserStatus
        {
            get { return this._ipwonReserStatus; }
            set { this._ipwonReserStatus = value; }
        }

        public XPaInfoBoxResult XpaInfoBox
        {
            get { return this._xpaInfoBox; }
            set { this._xpaInfoBox = value; }
        }

        public OCS1003P01SettingVisibleByUserResult Ocs1003p01SettingVisible
        {
            get { return this._ocs1003p01SettingVisible; }
            set { this._ocs1003p01SettingVisible = value; }
        }

        public OcsoOCS1003P01GridReserOrderListResult Ocs1003p01GridReserOrder
        {
            get { return this._ocs1003p01GridReserOrder; }
            set { this._ocs1003p01GridReserOrder = value; }
        }

        public OUT0106U00GridListResult Out0106u00GridLst
        {
            get { return this._out0106u00GridLst; }
            set { this._out0106u00GridLst = value; }
        }

        public NuroPatientReceptionHistoryListResult NuroPatientReceptionHis
        {
            get { return this._nuroPatientReceptionHis; }
            set { this._nuroPatientReceptionHis = value; }
        }

        public EMRSetDataForTvExamHistResult EmrSetDataTvxam
        {
            get { return this._emrSetDataTvxam; }
            set { this._emrSetDataTvxam = value; }
        }

        public OcsEmrHistoryClinicReferResult OcsemrHisClinicRefer
        {
            get { return this._ocsemrHisClinicRefer; }
            set { this._ocsemrHisClinicRefer = value; }
        }

        public OCS2015U06EmrRecordResult Ocs2015u06EmrRecord
        {
            get { return this._ocs2015u06EmrRecord; }
            set { this._ocs2015u06EmrRecord = value; }
        }

        public SettingDiscussResult SettingDiscuss
        {
            get { return this._settingDiscuss; }
            set { this._settingDiscuss = value; }
        }

        public OCS2015U00GetDiscussNotifyResult Ocs2015u00GetDiscussNotify
        {
            get { return this._ocs2015u00GetDiscussNotify; }
            set { this._ocs2015u00GetDiscussNotify = value; }
        }

        public EMRGetLatestWarningStatusResult EmrGetLastestWarning
        {
            get { return this._emrGetLastestWarning; }
            set { this._emrGetLastestWarning = value; }
        }

        public OCS0103U13CboListResult Ocs0103u13CboLst
        {
            get { return this._ocs0103u13CboLst; }
            set { this._ocs0103u13CboLst = value; }
        }

        public OCS1003P01GrdPatientResult Ocs1003p01GrdPatient
        {
            get { return this._ocs1003p01GrdPatient; }
            set { this._ocs1003p01GrdPatient = value; }
        }

        public OcsoOCS1003P01BtnListQueryResult Ocs1003p01BtnListQuery
        {
            get { return this._ocs1003p01BtnListQuery; }
            set { this._ocs1003p01BtnListQuery = value; }
        }

        public NUR1016U00GrdNUR1016Result Nur1016u00Grd
        {
            get { return this._nur1016u00Grd; }
            set { this._nur1016u00Grd = value; }
        }

        public NUR1017U00GrdNUR1017Result Nur1017u00Grd
        {
            get { return this._nur1017u00Grd; }
            set { this._nur1017u00Grd = value; }
        }

        public OCS2015U00GetPatientInfoResult Ocs2015u00GetPatientInfo
        {
            get { return this._ocs2015u00GetPatientInfo; }
            set { this._ocs2015u00GetPatientInfo = value; }
        }

        public OCS2015U09GetTemplateComboBoxResult Ocs2015u09GetTemplateCombo
        {
            get { return this._ocs2015u09GetTemplateCombo; }
            set { this._ocs2015u09GetTemplateCombo = value; }
        }

        public OCS2015U06OrderTypeComboResult Ocs2015u06OrderTypeCombo
        {
            get { return this._ocs2015u06OrderTypeCombo; }
            set { this._ocs2015u06OrderTypeCombo = value; }
        }

        public LoadEmrCompositeSecondResult() { }

    }
}