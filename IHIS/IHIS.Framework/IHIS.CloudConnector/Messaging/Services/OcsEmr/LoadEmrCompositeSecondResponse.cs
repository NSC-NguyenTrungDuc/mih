using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"LoadEmrCompositeSecondResponse")]
    public partial class LoadEmrCompositeSecondResponse : global::ProtoBuf.IExtensible
    {
        public LoadEmrCompositeSecondResponse() { }

        private StringResponse _environ_info_sys_date = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"environ_info_sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public StringResponse environ_info_sys_date
        {
            get { return _environ_info_sys_date; }
            set { _environ_info_sys_date = value; }
        }
        private OCS2015U21ControlDataValidatingResponse _ocs2015u21_control_data_validate = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"ocs2015u21_control_data_validate", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U21ControlDataValidatingResponse ocs2015u21_control_data_validate
        {
            get { return _ocs2015u21_control_data_validate; }
            set { _ocs2015u21_control_data_validate = value; }
        }
        private OpenAllergyInfoResponse _open_allergy_info = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"open_allergy_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OpenAllergyInfoResponse open_allergy_info
        {
            get { return _open_allergy_info; }
            set { _open_allergy_info = value; }
        }
        private LoadConsultEndYNResponse _load_consult_end_yn = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"load_consult_end_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public LoadConsultEndYNResponse load_consult_end_yn
        {
            get { return _load_consult_end_yn; }
            set { _load_consult_end_yn = value; }
        }
        private OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse _ocs1003p01_load_consult_end = null;
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"ocs1003p01_load_consult_end", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResponse ocs1003p01_load_consult_end
        {
            get { return _ocs1003p01_load_consult_end; }
            set { _ocs1003p01_load_consult_end = value; }
        }
        private LoadPatientSpecificCommentResponse _load_patient_spec_comment = null;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"load_patient_spec_comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public LoadPatientSpecificCommentResponse load_patient_spec_comment
        {
            get { return _load_patient_spec_comment; }
            set { _load_patient_spec_comment = value; }
        }
        private GetOutJinryoCommentCntResponse _get_out_jinryo_comment = null;
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"get_out_jinryo_comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public GetOutJinryoCommentCntResponse get_out_jinryo_comment
        {
            get { return _get_out_jinryo_comment; }
            set { _get_out_jinryo_comment = value; }
        }
        private IpwonReserStatusResponse _ipwon_reser_status = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"ipwon_reser_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public IpwonReserStatusResponse ipwon_reser_status
        {
            get { return _ipwon_reser_status; }
            set { _ipwon_reser_status = value; }
        }
        private XPaInfoBoxResponse _xpa_info_box = null;
        [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"xpa_info_box", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public XPaInfoBoxResponse xpa_info_box
        {
            get { return _xpa_info_box; }
            set { _xpa_info_box = value; }
        }
        private OCS1003P01SettingVisibleByUserResponse _ocs1003p01_setting_visible = null;
        [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name = @"ocs1003p01_setting_visible", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS1003P01SettingVisibleByUserResponse ocs1003p01_setting_visible
        {
            get { return _ocs1003p01_setting_visible; }
            set { _ocs1003p01_setting_visible = value; }
        }
        private OcsoOCS1003P01GridReserOrderListResponse _ocs1003p01_grid_reser_order = null;
        [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name = @"ocs1003p01_grid_reser_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01GridReserOrderListResponse ocs1003p01_grid_reser_order
        {
            get { return _ocs1003p01_grid_reser_order; }
            set { _ocs1003p01_grid_reser_order = value; }
        }
        private OUT0106U00GridListResponse _out0106u00_grid_lst = null;
        [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name = @"out0106u00_grid_lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OUT0106U00GridListResponse out0106u00_grid_lst
        {
            get { return _out0106u00_grid_lst; }
            set { _out0106u00_grid_lst = value; }
        }
        private NuroPatientReceptionHistoryListResponse _nuro_patient_reception_his = null;
        [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name = @"nuro_patient_reception_his", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public NuroPatientReceptionHistoryListResponse nuro_patient_reception_his
        {
            get { return _nuro_patient_reception_his; }
            set { _nuro_patient_reception_his = value; }
        }
        private EMRSetDataForTvExamHistResponse _emr_set_data_tvxam = null;
        [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name = @"emr_set_data_tvxam", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public EMRSetDataForTvExamHistResponse emr_set_data_tvxam
        {
            get { return _emr_set_data_tvxam; }
            set { _emr_set_data_tvxam = value; }
        }
        private OcsEmrHistoryClinicReferResponse _ocsemr_his_clinic_refer = null;
        [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name = @"ocsemr_his_clinic_refer", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsEmrHistoryClinicReferResponse ocsemr_his_clinic_refer
        {
            get { return _ocsemr_his_clinic_refer; }
            set { _ocsemr_his_clinic_refer = value; }
        }
        private OCS2015U06EmrRecordResponse _ocs2015u06_emr_record = null;
        [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name = @"ocs2015u06_emr_record", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U06EmrRecordResponse ocs2015u06_emr_record
        {
            get { return _ocs2015u06_emr_record; }
            set { _ocs2015u06_emr_record = value; }
        }
        private SettingDiscussResponse _setting_discuss = null;
        [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name = @"setting_discuss", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public SettingDiscussResponse setting_discuss
        {
            get { return _setting_discuss; }
            set { _setting_discuss = value; }
        }
        private OCS2015U00GetDiscussNotifyResponse _ocs2015u00_get_discuss_notify = null;
        [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name = @"ocs2015u00_get_discuss_notify", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U00GetDiscussNotifyResponse ocs2015u00_get_discuss_notify
        {
            get { return _ocs2015u00_get_discuss_notify; }
            set { _ocs2015u00_get_discuss_notify = value; }
        }
        private EMRGetLatestWarningStatusResponse _emr_get_lastest_warning = null;
        [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name = @"emr_get_lastest_warning", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public EMRGetLatestWarningStatusResponse emr_get_lastest_warning
        {
            get { return _emr_get_lastest_warning; }
            set { _emr_get_lastest_warning = value; }
        }
        private OCS0103U13CboListResponse _ocs0103u13_cbo_lst = null;
        [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name = @"ocs0103u13_cbo_lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS0103U13CboListResponse ocs0103u13_cbo_lst
        {
            get { return _ocs0103u13_cbo_lst; }
            set { _ocs0103u13_cbo_lst = value; }
        }
        private OCS1003P01GrdPatientResponse _ocs1003p01_grd_patient = null;
        [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name = @"ocs1003p01_grd_patient", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS1003P01GrdPatientResponse ocs1003p01_grd_patient
        {
            get { return _ocs1003p01_grd_patient; }
            set { _ocs1003p01_grd_patient = value; }
        }
        private OcsoOCS1003P01BtnListQueryResponse _ocs1003p01_btn_list_query = null;
        [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name = @"ocs1003p01_btn_list_query", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01BtnListQueryResponse ocs1003p01_btn_list_query
        {
            get { return _ocs1003p01_btn_list_query; }
            set { _ocs1003p01_btn_list_query = value; }
        }
        private NUR1016U00GrdNUR1016Response _nur1016u00_grd = null;
        [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name = @"nur1016u00_grd", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public NUR1016U00GrdNUR1016Response nur1016u00_grd
        {
            get { return _nur1016u00_grd; }
            set { _nur1016u00_grd = value; }
        }
        private NUR1017U00GrdNUR1017Response _nur1017u00_grd = null;
        [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name = @"nur1017u00_grd", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public NUR1017U00GrdNUR1017Response nur1017u00_grd
        {
            get { return _nur1017u00_grd; }
            set { _nur1017u00_grd = value; }
        }
        private OCS2015U00GetPatientInfoResponse _ocs2015u00_get_patient_info = null;
        [global::ProtoBuf.ProtoMember(25, IsRequired = false, Name = @"ocs2015u00_get_patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U00GetPatientInfoResponse ocs2015u00_get_patient_info
        {
            get { return _ocs2015u00_get_patient_info; }
            set { _ocs2015u00_get_patient_info = value; }
        }
        private OCS2015U09GetTemplateComboBoxResponse _ocs2015u09_get_template_combo = null;
        [global::ProtoBuf.ProtoMember(26, IsRequired = false, Name = @"ocs2015u09_get_template_combo", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U09GetTemplateComboBoxResponse ocs2015u09_get_template_combo
        {
            get { return _ocs2015u09_get_template_combo; }
            set { _ocs2015u09_get_template_combo = value; }
        }
        private OCS2015U06OrderTypeComboResponse _ocs2015u06_order_type_combo = null;
        [global::ProtoBuf.ProtoMember(27, IsRequired = false, Name = @"ocs2015u06_order_type_combo", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U06OrderTypeComboResponse ocs2015u06_order_type_combo
        {
            get { return _ocs2015u06_order_type_combo; }
            set { _ocs2015u06_order_type_combo = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
