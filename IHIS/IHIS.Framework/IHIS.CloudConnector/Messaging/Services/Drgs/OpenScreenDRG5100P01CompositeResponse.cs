using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"OpenScreenDRG5100P01CompositeResponse")]
    public partial class OpenScreenDRG5100P01CompositeResponse : global::ProtoBuf.IExtensible
    {
        public OpenScreenDRG5100P01CompositeResponse() { }

        private readonly global::System.Collections.Generic.List<DRG5100P01CheckActResponse> _check_act = new global::System.Collections.Generic.List<DRG5100P01CheckActResponse>();
        [global::ProtoBuf.ProtoMember(1, Name = @"check_act", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<DRG5100P01CheckActResponse> check_act
        {
            get { return _check_act; }
        }

        private readonly global::System.Collections.Generic.List<StringResponse> _sys_date = new global::System.Collections.Generic.List<StringResponse>();
        [global::ProtoBuf.ProtoMember(2, Name = @"sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<StringResponse> sys_date
        {
            get { return _sys_date; }
        }

        private readonly global::System.Collections.Generic.List<DrgsDRG5100P01GridPaidListResponse> _paid_list = new global::System.Collections.Generic.List<DrgsDRG5100P01GridPaidListResponse>();
        [global::ProtoBuf.ProtoMember(3, Name = @"paid_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<DrgsDRG5100P01GridPaidListResponse> paid_list
        {
            get { return _paid_list; }
        }

        private readonly global::System.Collections.Generic.List<GetPatientByCodeResponse> _patient_bycode = new global::System.Collections.Generic.List<GetPatientByCodeResponse>();
        [global::ProtoBuf.ProtoMember(4, Name = @"patient_bycode", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<GetPatientByCodeResponse> patient_bycode
        {
            get { return _patient_bycode; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
