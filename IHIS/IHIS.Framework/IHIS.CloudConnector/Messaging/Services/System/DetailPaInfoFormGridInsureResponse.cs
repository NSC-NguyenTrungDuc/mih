//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: DetailPaInfoForm.proto
namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"DetailPaInfoFormGridInsureResponse")]
    public partial class DetailPaInfoFormGridInsureResponse : global::ProtoBuf.IExtensible
    {
        public DetailPaInfoFormGridInsureResponse() { }

        private readonly global::System.Collections.Generic.List<DetailPaInfoFormGridInsureInfo> _grid_insure_item = new global::System.Collections.Generic.List<DetailPaInfoFormGridInsureInfo>();
        [global::ProtoBuf.ProtoMember(1, Name = @"grid_insure_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<DetailPaInfoFormGridInsureInfo> grid_insure_item
        {
            get { return _grid_insure_item; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}