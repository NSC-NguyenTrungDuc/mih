using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"SaveEmrCompositeSecondRequest")]
    public partial class SaveEmrCompositeSecondRequest : global::ProtoBuf.IExtensible
    {
        public SaveEmrCompositeSecondRequest() { }

        private OCS1003P01GrdPatientRequest _grd_patient = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"grd_patient", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS1003P01GrdPatientRequest grd_patient
        {
            get { return _grd_patient; }
            set { _grd_patient = value; }
        }
        private OcsoOCS1003P01BtnListQueryRequest _btn_list_query = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"btn_list_query", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01BtnListQueryRequest btn_list_query
        {
            get { return _btn_list_query; }
            set { _btn_list_query = value; }
        }
        private NUR1016U00GrdNUR1016Request _grd_nur1016 = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"grd_nur1016", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public NUR1016U00GrdNUR1016Request grd_nur1016
        {
            get { return _grd_nur1016; }
            set { _grd_nur1016 = value; }
        }
        private NUR1017U00GrdNUR1017Request _grd_nur1017 = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"grd_nur1017", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public NUR1017U00GrdNUR1017Request grd_nur1017
        {
            get { return _grd_nur1017; }
            set { _grd_nur1017 = value; }
        }
        private OUT0106U00GridListRequest _grd_list_out0106 = null;
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"grd_list_out0106", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OUT0106U00GridListRequest grd_list_out0106
        {
            get { return _grd_list_out0106; }
            set { _grd_list_out0106 = value; }
        }
        private OCS2015U00GetPatientInfoRequest _get_patient_info = null;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"get_patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U00GetPatientInfoRequest get_patient_info
        {
            get { return _get_patient_info; }
            set { _get_patient_info = value; }
        }
        private PatientInfoLoadPatientNaewonListRequest _patient_info_load = null;
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"patient_info_load", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public PatientInfoLoadPatientNaewonListRequest patient_info_load
        {
            get { return _patient_info_load; }
            set { _patient_info_load = value; }
        }
        private FormEnvironInfoSysDateRequest _env_sys_date = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"env_sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public FormEnvironInfoSysDateRequest env_sys_date
        {
            get { return _env_sys_date; }
            set { _env_sys_date = value; }
        }
        private PrOcsLoadNaewonInfoRequest _ocs_load_naewon = null;
        [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"ocs_load_naewon", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public PrOcsLoadNaewonInfoRequest ocs_load_naewon
        {
            get { return _ocs_load_naewon; }
            set { _ocs_load_naewon = value; }
        }
        private OCS2015U09GetTemplateComboBoxRequest _template_combo = null;
        [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name = @"template_combo", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U09GetTemplateComboBoxRequest template_combo
        {
            get { return _template_combo; }
            set { _template_combo = value; }
        }
        private OCS2015U06OrderTypeComboRequest _order_type_combo = null;
        [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name = @"order_type_combo", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U06OrderTypeComboRequest order_type_combo
        {
            get { return _order_type_combo; }
            set { _order_type_combo = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}