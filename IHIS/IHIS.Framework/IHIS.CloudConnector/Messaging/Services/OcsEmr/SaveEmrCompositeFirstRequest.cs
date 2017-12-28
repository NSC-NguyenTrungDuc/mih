using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"SaveEmrCompositeFirstRequest")]
    public partial class SaveEmrCompositeFirstRequest : global::ProtoBuf.IExtensible
    {
        public SaveEmrCompositeFirstRequest() { }

        private OcsoOCS1003P01CheckXRequest _ocs1003p01_checkx = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"ocs1003p01_checkx", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public OcsoOCS1003P01CheckXRequest ocs1003p01_checkx
        {
            get { return _ocs1003p01_checkx; }
            set { _ocs1003p01_checkx = value; }
        }
        private readonly global::System.Collections.Generic.List<CheckPatientStatusRequest> _check_patient_status = new global::System.Collections.Generic.List<CheckPatientStatusRequest>();
        [global::ProtoBuf.ProtoMember(2, Name = @"check_patient_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<CheckPatientStatusRequest> check_patient_status
        {
            get { return _check_patient_status; }
        }

        private readonly global::System.Collections.Generic.List<OcsoOCS1003P01GetChuciRequest> _ocs1003p01_get_chuci = new global::System.Collections.Generic.List<OcsoOCS1003P01GetChuciRequest>();
        [global::ProtoBuf.ProtoMember(3, Name = @"ocs1003p01_get_chuci", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OcsoOCS1003P01GetChuciRequest> ocs1003p01_get_chuci
        {
            get { return _ocs1003p01_get_chuci; }
        }

        private readonly global::System.Collections.Generic.List<DupCheckInputOutOrderRequest> _dup_check_input_out_order = new global::System.Collections.Generic.List<DupCheckInputOutOrderRequest>();
        [global::ProtoBuf.ProtoMember(4, Name = @"dup_check_input_out_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<DupCheckInputOutOrderRequest> dup_check_input_out_order
        {
            get { return _dup_check_input_out_order; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
