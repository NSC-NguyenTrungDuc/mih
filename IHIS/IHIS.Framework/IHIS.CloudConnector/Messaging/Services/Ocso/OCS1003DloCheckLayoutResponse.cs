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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS1003DloCheckLayoutResponse")]
  public partial class OCS1003DloCheckLayoutResponse : global::ProtoBuf.IExtensible
  {
    public OCS1003DloCheckLayoutResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS1003Q09GridOUT1001Info> _gridout1001_info = new global::System.Collections.Generic.List<OCS1003Q09GridOUT1001Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"gridout1001_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS1003Q09GridOUT1001Info> gridout1001_info
    {
      get { return _gridout1001_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
