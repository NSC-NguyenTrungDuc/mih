//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT1001P03BunhoListResponse")]
  public partial class OUT1001P03BunhoListResponse : global::ProtoBuf.IExtensible
  {
    public OUT1001P03BunhoListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OUT1001P03BunhoListItemInfo> _Bunho_list = new global::System.Collections.Generic.List<OUT1001P03BunhoListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"Bunho_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OUT1001P03BunhoListItemInfo> Bunho_list
    {
      get { return _Bunho_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}