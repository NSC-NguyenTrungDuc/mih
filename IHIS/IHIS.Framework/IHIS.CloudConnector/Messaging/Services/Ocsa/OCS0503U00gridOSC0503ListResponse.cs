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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0503U00gridOSC0503ListResponse")]
  public partial class OCS0503U00gridOSC0503ListResponse : global::ProtoBuf.IExtensible
  {
    public OCS0503U00gridOSC0503ListResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS0503U00gridOSC0503ListInfo> _gridOSC0503 = new global::System.Collections.Generic.List<OCS0503U00gridOSC0503ListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"gridOSC0503", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0503U00gridOSC0503ListInfo> gridOSC0503
    {
      get { return _gridOSC0503; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
