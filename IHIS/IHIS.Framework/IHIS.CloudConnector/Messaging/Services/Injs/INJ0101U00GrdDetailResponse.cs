//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ0101U00GrdDetailResponse")]
  public partial class INJ0101U00GrdDetailResponse : global::ProtoBuf.IExtensible
  {
    public INJ0101U00GrdDetailResponse() {}
    
    private readonly global::System.Collections.Generic.List<INJ0101U00GrdDetailInfo> _list_item = new global::System.Collections.Generic.List<INJ0101U00GrdDetailInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INJ0101U00GrdDetailInfo> list_item
    {
      get { return _list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
