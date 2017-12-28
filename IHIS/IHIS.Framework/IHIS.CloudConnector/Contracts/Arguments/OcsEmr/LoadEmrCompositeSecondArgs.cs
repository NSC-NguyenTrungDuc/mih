using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Ocsemr;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class LoadEmrCompositeSecondArgs : IContractArgs
    {
        private FormEnvironInfoSysDateArgs _environInfoSysDate;
        private OCS2015U21ControlDataValidatingArgs _ocs2015u21ControlDataValidate;
        private OpenAllergyInfoArgs _openAllergyInfo;
        private LoadConsultEndYNArgs _loadConsultEndYn;
        private OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs _ocs1003p01LoadConsultEnd;
        private LoadPatientSpecificCommentArgs _loadPatientSpecComment;
        private GetOutJinryoCommentCntArgs _getOutJinryoComment;
        private IpwonReserStatusArgs _ipwonReserStatus;
        private XPaInfoBoxArgs _xpaInfoBox;
        private OCS1003P01SettingVisibleByUserArgs _ocs1003p01SettingVisible;
        private OcsoOCS1003P01GridReserOrderListArgs _ocs1003p01GridReserOrder;
        private OUT0106U00GridListArgs _out0106u00GridLst;
        private NuroPatientReceptionHistoryListArgs _nuroPatientReceptionHis;
        private EMRSetDataForTvExamHistArgs _emrSetDataTvxam;
        private OcsEmrHistoryClinicReferArgs _ocsemrHisClinicRefer;
        private OCS2015U06EmrRecordArgs _ocs2015u06EmrRecord;
        private SettingDiscussArgs _settingDiscuss;
        private OCS2015U00GetDiscussNotifyArgs _ocs2015u00GetDiscussNotify;
        private EMRGetLatestWarningStatusArgs _emrGetLastestWarning;
        private OCS0103U13CboListArgs _ocs0103u13CboLst;
        private OCS1003P01GrdPatientArgs _ocs1003p01GrdPatient;
        private OcsoOCS1003P01BtnListQueryArgs _ocs1003p01BtnListQuery;
        private NUR1016U00GrdNUR1016Args _nur1016u00Grd;
        private NUR1017U00GrdNUR1017Args _nur1017u00Grd;
        private OCS2015U00GetPatientInfoArgs _ocs2015u00GetPatientInfo;
        private OCS2015U09GetTemplateComboBoxArgs _ocs2015u09GetTemplateCombo;
        private OCS2015U06OrderTypeComboArgs _ocs2015u06OrderTypeCombo;

        public FormEnvironInfoSysDateArgs EnvironInfoSysDate
        {
            get { return this._environInfoSysDate; }
            set { this._environInfoSysDate = value; }
        }

        public OCS2015U21ControlDataValidatingArgs Ocs2015u21ControlDataValidate
        {
            get { return this._ocs2015u21ControlDataValidate; }
            set { this._ocs2015u21ControlDataValidate = value; }
        }

        public OpenAllergyInfoArgs OpenAllergyInfo
        {
            get { return this._openAllergyInfo; }
            set { this._openAllergyInfo = value; }
        }

        public LoadConsultEndYNArgs LoadConsultEndYn
        {
            get { return this._loadConsultEndYn; }
            set { this._loadConsultEndYn = value; }
        }

        public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs Ocs1003p01LoadConsultEnd
        {
            get { return this._ocs1003p01LoadConsultEnd; }
            set { this._ocs1003p01LoadConsultEnd = value; }
        }

        public LoadPatientSpecificCommentArgs LoadPatientSpecComment
        {
            get { return this._loadPatientSpecComment; }
            set { this._loadPatientSpecComment = value; }
        }

        public GetOutJinryoCommentCntArgs GetOutJinryoComment
        {
            get { return this._getOutJinryoComment; }
            set { this._getOutJinryoComment = value; }
        }

        public IpwonReserStatusArgs IpwonReserStatus
        {
            get { return this._ipwonReserStatus; }
            set { this._ipwonReserStatus = value; }
        }

        public XPaInfoBoxArgs XpaInfoBox
        {
            get { return this._xpaInfoBox; }
            set { this._xpaInfoBox = value; }
        }

        public OCS1003P01SettingVisibleByUserArgs Ocs1003p01SettingVisible
        {
            get { return this._ocs1003p01SettingVisible; }
            set { this._ocs1003p01SettingVisible = value; }
        }

        public OcsoOCS1003P01GridReserOrderListArgs Ocs1003p01GridReserOrder
        {
            get { return this._ocs1003p01GridReserOrder; }
            set { this._ocs1003p01GridReserOrder = value; }
        }

        public OUT0106U00GridListArgs Out0106u00GridLst
        {
            get { return this._out0106u00GridLst; }
            set { this._out0106u00GridLst = value; }
        }

        public NuroPatientReceptionHistoryListArgs NuroPatientReceptionHis
        {
            get { return this._nuroPatientReceptionHis; }
            set { this._nuroPatientReceptionHis = value; }
        }

        public EMRSetDataForTvExamHistArgs EmrSetDataTvxam
        {
            get { return this._emrSetDataTvxam; }
            set { this._emrSetDataTvxam = value; }
        }

        public OcsEmrHistoryClinicReferArgs OcsemrHisClinicRefer
        {
            get { return this._ocsemrHisClinicRefer; }
            set { this._ocsemrHisClinicRefer = value; }
        }

        public OCS2015U06EmrRecordArgs Ocs2015u06EmrRecord
        {
            get { return this._ocs2015u06EmrRecord; }
            set { this._ocs2015u06EmrRecord = value; }
        }

        public SettingDiscussArgs SettingDiscuss
        {
            get { return this._settingDiscuss; }
            set { this._settingDiscuss = value; }
        }

        public OCS2015U00GetDiscussNotifyArgs Ocs2015u00GetDiscussNotify
        {
            get { return this._ocs2015u00GetDiscussNotify; }
            set { this._ocs2015u00GetDiscussNotify = value; }
        }

        public EMRGetLatestWarningStatusArgs EmrGetLastestWarning
        {
            get { return this._emrGetLastestWarning; }
            set { this._emrGetLastestWarning = value; }
        }

        public OCS0103U13CboListArgs Ocs0103u13CboLst
        {
            get { return this._ocs0103u13CboLst; }
            set { this._ocs0103u13CboLst = value; }
        }

        public OCS1003P01GrdPatientArgs Ocs1003p01GrdPatient
        {
            get { return this._ocs1003p01GrdPatient; }
            set { this._ocs1003p01GrdPatient = value; }
        }

        public OcsoOCS1003P01BtnListQueryArgs Ocs1003p01BtnListQuery
        {
            get { return this._ocs1003p01BtnListQuery; }
            set { this._ocs1003p01BtnListQuery = value; }
        }

        public NUR1016U00GrdNUR1016Args Nur1016u00Grd
        {
            get { return this._nur1016u00Grd; }
            set { this._nur1016u00Grd = value; }
        }

        public NUR1017U00GrdNUR1017Args Nur1017u00Grd
        {
            get { return this._nur1017u00Grd; }
            set { this._nur1017u00Grd = value; }
        }

        public OCS2015U00GetPatientInfoArgs Ocs2015u00GetPatientInfo
        {
            get { return this._ocs2015u00GetPatientInfo; }
            set { this._ocs2015u00GetPatientInfo = value; }
        }

        public OCS2015U09GetTemplateComboBoxArgs Ocs2015u09GetTemplateCombo
        {
            get { return this._ocs2015u09GetTemplateCombo; }
            set { this._ocs2015u09GetTemplateCombo = value; }
        }

        public OCS2015U06OrderTypeComboArgs Ocs2015u06OrderTypeCombo
        {
            get { return this._ocs2015u06OrderTypeCombo; }
            set { this._ocs2015u06OrderTypeCombo = value; }
        }

        public LoadEmrCompositeSecondArgs() { }

        public LoadEmrCompositeSecondArgs(FormEnvironInfoSysDateArgs environInfoSysDate, OCS2015U21ControlDataValidatingArgs ocs2015u21ControlDataValidate, OpenAllergyInfoArgs openAllergyInfo, LoadConsultEndYNArgs loadConsultEndYn, OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs ocs1003p01LoadConsultEnd, LoadPatientSpecificCommentArgs loadPatientSpecComment, GetOutJinryoCommentCntArgs getOutJinryoComment, IpwonReserStatusArgs ipwonReserStatus, XPaInfoBoxArgs xpaInfoBox, OCS1003P01SettingVisibleByUserArgs ocs1003p01SettingVisible, OcsoOCS1003P01GridReserOrderListArgs ocs1003p01GridReserOrder, OUT0106U00GridListArgs out0106u00GridLst, NuroPatientReceptionHistoryListArgs nuroPatientReceptionHis, EMRSetDataForTvExamHistArgs emrSetDataTvxam, OcsEmrHistoryClinicReferArgs ocsemrHisClinicRefer, OCS2015U06EmrRecordArgs ocs2015u06EmrRecord, SettingDiscussArgs settingDiscuss, OCS2015U00GetDiscussNotifyArgs ocs2015u00GetDiscussNotify, EMRGetLatestWarningStatusArgs emrGetLastestWarning, OCS0103U13CboListArgs ocs0103u13CboLst, OCS1003P01GrdPatientArgs ocs1003p01GrdPatient, OcsoOCS1003P01BtnListQueryArgs ocs1003p01BtnListQuery, NUR1016U00GrdNUR1016Args nur1016u00Grd, NUR1017U00GrdNUR1017Args nur1017u00Grd, OCS2015U00GetPatientInfoArgs ocs2015u00GetPatientInfo, OCS2015U09GetTemplateComboBoxArgs ocs2015u09GetTemplateCombo, OCS2015U06OrderTypeComboArgs ocs2015u06OrderTypeCombo)
        {
            this._environInfoSysDate = environInfoSysDate;
            this._ocs2015u21ControlDataValidate = ocs2015u21ControlDataValidate;
            this._openAllergyInfo = openAllergyInfo;
            this._loadConsultEndYn = loadConsultEndYn;
            this._ocs1003p01LoadConsultEnd = ocs1003p01LoadConsultEnd;
            this._loadPatientSpecComment = loadPatientSpecComment;
            this._getOutJinryoComment = getOutJinryoComment;
            this._ipwonReserStatus = ipwonReserStatus;
            this._xpaInfoBox = xpaInfoBox;
            this._ocs1003p01SettingVisible = ocs1003p01SettingVisible;
            this._ocs1003p01GridReserOrder = ocs1003p01GridReserOrder;
            this._out0106u00GridLst = out0106u00GridLst;
            this._nuroPatientReceptionHis = nuroPatientReceptionHis;
            this._emrSetDataTvxam = emrSetDataTvxam;
            this._ocsemrHisClinicRefer = ocsemrHisClinicRefer;
            this._ocs2015u06EmrRecord = ocs2015u06EmrRecord;
            this._settingDiscuss = settingDiscuss;
            this._ocs2015u00GetDiscussNotify = ocs2015u00GetDiscussNotify;
            this._emrGetLastestWarning = emrGetLastestWarning;
            this._ocs0103u13CboLst = ocs0103u13CboLst;
            this._ocs1003p01GrdPatient = ocs1003p01GrdPatient;
            this._ocs1003p01BtnListQuery = ocs1003p01BtnListQuery;
            this._nur1016u00Grd = nur1016u00Grd;
            this._nur1017u00Grd = nur1017u00Grd;
            this._ocs2015u00GetPatientInfo = ocs2015u00GetPatientInfo;
            this._ocs2015u09GetTemplateCombo = ocs2015u09GetTemplateCombo;
            this._ocs2015u06OrderTypeCombo = ocs2015u06OrderTypeCombo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadEmrCompositeSecondRequest();
        }
    }
}