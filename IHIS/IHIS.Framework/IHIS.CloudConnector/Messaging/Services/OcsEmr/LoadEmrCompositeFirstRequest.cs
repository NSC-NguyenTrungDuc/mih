using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"LoadEmrCompositeFirstRequest")]
    public partial class LoadEmrCompositeFirstRequest : global::ProtoBuf.IExtensible
    {
        public LoadEmrCompositeFirstRequest() { }

        private OcsoOCS1003P01CheckYRequest _ocs1003p01_check_y = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"ocs1003p01_check_y", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01CheckYRequest ocs1003p01_check_y
        {
            get { return _ocs1003p01_check_y; }
            set { _ocs1003p01_check_y = value; }
        }
        private OCS2015U00GetMaxSizeRequest _ocs2015u00_get_max_size = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"ocs2015u00_get_max_size", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U00GetMaxSizeRequest ocs2015u00_get_max_size
        {
            get { return _ocs2015u00_get_max_size; }
            set { _ocs2015u00_get_max_size = value; }
        }
        private OCS2015U06EmrTagRequest _ocs2015u06_emr_tag = null;
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"ocs2015u06_emr_tag", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U06EmrTagRequest ocs2015u06_emr_tag
        {
            get { return _ocs2015u06_emr_tag; }
            set { _ocs2015u06_emr_tag = value; }
        }
        private OcsoOCS1003P01LayPatRequest _ocs1003p01_lay_pat = null;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"ocs1003p01_lay_pat", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01LayPatRequest ocs1003p01_lay_pat
        {
            get { return _ocs1003p01_lay_pat; }
            set { _ocs1003p01_lay_pat = value; }
        }
        private PatientInfoLoadPatientNaewonListRequest _patient_info_naewon_lst = null;
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"patient_info_naewon_lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public PatientInfoLoadPatientNaewonListRequest patient_info_naewon_lst
        {
            get { return _patient_info_naewon_lst; }
            set { _patient_info_naewon_lst = value; }
        }
        private FormEnvironInfoSysDateRequest _environ_info_sys_date = null;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"environ_info_sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public FormEnvironInfoSysDateRequest environ_info_sys_date
        {
            get { return _environ_info_sys_date; }
            set { _environ_info_sys_date = value; }
        }
        private PrOcsLoadNaewonInfoRequest _ocs_load_naewon_info = null;
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"ocs_load_naewon_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public PrOcsLoadNaewonInfoRequest ocs_load_naewon_info
        {
            get { return _ocs_load_naewon_info; }
            set { _ocs_load_naewon_info = value; }
        }
        private OCS2015U00GetPatientInfoRequest _ocs2015u00_get_patient_info = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"ocs2015u00_get_patient_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OCS2015U00GetPatientInfoRequest ocs2015u00_get_patient_info
        {
            get { return _ocs2015u00_get_patient_info; }
            set { _ocs2015u00_get_patient_info = value; }
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
