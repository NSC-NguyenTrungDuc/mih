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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U12GrdGeneralResponse")]
  public partial class OCS0103U12GrdGeneralResponse : global::ProtoBuf.IExtensible
  {
    public OCS0103U12GrdGeneralResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS0103U12GrdGeneralInfo> _info1 = new global::System.Collections.Generic.List<OCS0103U12GrdGeneralInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"info1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0103U12GrdGeneralInfo> info1
    {
      get { return _info1; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
