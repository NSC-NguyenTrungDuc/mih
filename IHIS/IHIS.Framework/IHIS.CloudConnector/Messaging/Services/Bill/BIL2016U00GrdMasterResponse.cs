//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL2016U00GrdMasterResponse")]
  public partial class BIL2016U00GrdMasterResponse : global::ProtoBuf.IExtensible
  {
    public BIL2016U00GrdMasterResponse() {}
    
    private readonly global::System.Collections.Generic.List<BIL2016U00ServiceInfo> _list_info = new global::System.Collections.Generic.List<BIL2016U00ServiceInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BIL2016U00ServiceInfo> list_info
    {
      get { return _list_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
