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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUTSANGU00findBoxToGwaResponse")]
  public partial class OUTSANGU00findBoxToGwaResponse : global::ProtoBuf.IExtensible
  {
    public OUTSANGU00findBoxToGwaResponse() {}
    
    private readonly global::System.Collections.Generic.List<OUTSANGU00findBoxToGwaInfo> _gwa_info = new global::System.Collections.Generic.List<OUTSANGU00findBoxToGwaInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"gwa_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OUTSANGU00findBoxToGwaInfo> gwa_info
    {
      get { return _gwa_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}