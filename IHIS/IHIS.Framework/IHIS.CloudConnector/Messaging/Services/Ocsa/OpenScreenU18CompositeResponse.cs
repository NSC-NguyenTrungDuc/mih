using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"OpenScreenU18CompositeResponse")]
    public partial class OpenScreenU18CompositeResponse : global::ProtoBuf.IExtensible
    {
        public OpenScreenU18CompositeResponse() { }

        private readonly global::System.Collections.Generic.List<LoadComboDataSourceResponse> _load_combo_data = new global::System.Collections.Generic.List<LoadComboDataSourceResponse>();
        [global::ProtoBuf.ProtoMember(1, Name = @"load_combo_data", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<LoadComboDataSourceResponse> load_combo_data
        {
            get { return _load_combo_data; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U18InitializeScreenResponse> _initialize_screen = new global::System.Collections.Generic.List<OCS0103U18InitializeScreenResponse>();
        [global::ProtoBuf.ProtoMember(2, Name = @"initialize_screen", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U18InitializeScreenResponse> initialize_screen
        {
            get { return _initialize_screen; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabResponse> _sangyong_tab = new global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabResponse>();
        [global::ProtoBuf.ProtoMember(3, Name = @"sangyong_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U12MakeSangyongTabResponse> sangyong_tab
        {
            get { return _sangyong_tab; }
        }

        private readonly global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderResponse> _sangyong_order = new global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderResponse>();
        [global::ProtoBuf.ProtoMember(4, Name = @"sangyong_order", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OCS0103U12GrdSangyongOrderResponse> sangyong_order
        {
            get { return _sangyong_order; }
        }

        private readonly global::System.Collections.Generic.List<GetNextGroupSerResponse> _next_group_ser = new global::System.Collections.Generic.List<GetNextGroupSerResponse>();
        [global::ProtoBuf.ProtoMember(5, Name = @"next_group_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<GetNextGroupSerResponse> next_group_ser
        {
            get { return _next_group_ser; }
        }

        private readonly global::System.Collections.Generic.List<OcsOrderBizGetUserOptionResponse> _user_option = new global::System.Collections.Generic.List<OcsOrderBizGetUserOptionResponse>();
        [global::ProtoBuf.ProtoMember(6, Name = @"user_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<OcsOrderBizGetUserOptionResponse> user_option
        {
            get { return _user_option; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
