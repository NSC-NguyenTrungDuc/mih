//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsaOCS0503Q01ListDataResponse")]
  public partial class OcsaOCS0503Q01ListDataResponse : global::ProtoBuf.IExtensible
  {
    public OcsaOCS0503Q01ListDataResponse() {}
    
    private readonly global::System.Collections.Generic.List<OcsaOCS0503Q01ListDataInfo> _list_item = new global::System.Collections.Generic.List<OcsaOCS0503Q01ListDataInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsaOCS0503Q01ListDataInfo> list_item
    {
      get { return _list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
