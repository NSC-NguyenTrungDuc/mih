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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORDERTRANSGrdEditResponse")]
  public partial class ORDERTRANSGrdEditResponse : global::ProtoBuf.IExtensible
  {
    public ORDERTRANSGrdEditResponse() {}
    
    private readonly global::System.Collections.Generic.List<ORDERTRANSGrdEditInfo> _grd_edit_item = new global::System.Collections.Generic.List<ORDERTRANSGrdEditInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_edit_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ORDERTRANSGrdEditInfo> grd_edit_item
    {
      get { return _grd_edit_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
