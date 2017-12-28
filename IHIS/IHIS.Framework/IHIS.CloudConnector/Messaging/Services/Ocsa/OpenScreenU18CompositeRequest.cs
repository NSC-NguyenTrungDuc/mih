using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"OpenScreenU18CompositeRequest")]
    public partial class OpenScreenU18CompositeRequest : global::ProtoBuf.IExtensible
    {
        public OpenScreenU18CompositeRequest() { }

        private readonly global::System.Collections.Generic.List<LoadComboDataSourceRequest> _load_combo_data = new global::System.Collections.Generic.List<LoadComboDataSourceRequest>();
        [global::ProtoBuf.ProtoMember(1, Name = @"load_combo_data", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<LoadComboDataSourceRequest> load_combo_data
        {
            get { return _load_combo_data; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U18InitializeScreenRequest> _initialize_screen = new global::System.Collections.Generic.List<OCS0103U18InitializeScreenRequest>();
        [global::ProtoBuf.ProtoMember(2, Name = @"initialize_screen", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U18InitializeScreenRequest> initialize_screen
        {
            get { return _initialize_screen; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabRequest> _sangyong_tab = new global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabRequest>();
        [global::ProtoBuf.ProtoMember(3, Name = @"sangyong_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabRequest> sangyong_tab
        {
            get { return _sangyong_tab; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderRequest> _sangyong_order = new global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderRequest>();
        [global::ProtoBuf.ProtoMember(4, Name = @"sangyong_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderRequest> sangyong_order
        {
            get { return _sangyong_order; }
        }

        private readonly global::System.Collections.Generic.List<GetNextGroupSerRequest> _next_group_ser = new global::System.Collections.Generic.List<GetNextGroupSerRequest>();
        [global::ProtoBuf.ProtoMember(5, Name = @"next_group_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<GetNextGroupSerRequest> next_group_ser
        {
            get { return _next_group_ser; }
        }

        private readonly global::System.Collections.Generic.List<OcsOrderBizGetUserOptionRequest> _user_option = new global::System.Collections.Generic.List<OcsOrderBizGetUserOptionRequest>();
        [global::ProtoBuf.ProtoMember(6, Name = @"user_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OcsOrderBizGetUserOptionRequest> user_option
        {
            get { return _user_option; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
