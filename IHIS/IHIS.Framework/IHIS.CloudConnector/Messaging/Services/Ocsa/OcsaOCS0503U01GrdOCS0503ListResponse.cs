//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsaOCS0503U01GrdOCS0503ListResponse")]
  public partial class OcsaOCS0503U01GrdOCS0503ListResponse : global::ProtoBuf.IExtensible
  {
    public OcsaOCS0503U01GrdOCS0503ListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OcsaOCS0503U01GrdOCS0503ListInfo> _grid_list_item = new global::System.Collections.Generic.List<OcsaOCS0503U01GrdOCS0503ListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grid_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsaOCS0503U01GrdOCS0503ListInfo> grid_list_item
    {
      get { return _grid_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
