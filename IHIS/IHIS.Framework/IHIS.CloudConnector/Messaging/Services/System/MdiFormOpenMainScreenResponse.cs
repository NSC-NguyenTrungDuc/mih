//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MdiFormOpenMainScreenResponse")]
  public partial class MdiFormOpenMainScreenResponse : global::ProtoBuf.IExtensible
  {
    public MdiFormOpenMainScreenResponse() {}
    
    private readonly global::System.Collections.Generic.List<MdiFormOpenMainScreenInfo> _main_screen_item = new global::System.Collections.Generic.List<MdiFormOpenMainScreenInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"main_screen_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MdiFormOpenMainScreenInfo> main_screen_item
    {
      get { return _main_screen_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
