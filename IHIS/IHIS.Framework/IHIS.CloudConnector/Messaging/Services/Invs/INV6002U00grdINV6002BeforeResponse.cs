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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6002U00grdINV6002BeforeResponse")]
  public partial class INV6002U00grdINV6002BeforeResponse : global::ProtoBuf.IExtensible
  {
    public INV6002U00grdINV6002BeforeResponse() {}
    
    private readonly global::System.Collections.Generic.List<INV6002U00GrdINV6002BeforeInfo> _item = new global::System.Collections.Generic.List<INV6002U00GrdINV6002BeforeInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV6002U00GrdINV6002BeforeInfo> item
    {
      get { return _item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}