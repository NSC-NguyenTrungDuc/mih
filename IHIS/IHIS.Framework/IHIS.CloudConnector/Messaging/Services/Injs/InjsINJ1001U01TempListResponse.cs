//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InjsINJ1001U01TempListResponse")]
  public partial class InjsINJ1001U01TempListResponse : global::ProtoBuf.IExtensible
  {
    public InjsINJ1001U01TempListResponse() {}
    
    private readonly global::System.Collections.Generic.List<InjsINJ1001U01TempListItemInfo> _temp_list_item = new global::System.Collections.Generic.List<InjsINJ1001U01TempListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"temp_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<InjsINJ1001U01TempListItemInfo> temp_list_item
    {
      get { return _temp_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}