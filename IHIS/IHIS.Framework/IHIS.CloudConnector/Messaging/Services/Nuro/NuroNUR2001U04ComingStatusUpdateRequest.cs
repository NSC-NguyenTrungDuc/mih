//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroNUR2001U04ComingStatusUpdateRequest")]
  public partial class NuroNUR2001U04ComingStatusUpdateRequest : global::ProtoBuf.IExtensible
  {
    public NuroNUR2001U04ComingStatusUpdateRequest() {}
    
    private string _coming_status;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"coming_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string coming_status
    {
      get { return _coming_status; }
      set { _coming_status = value; }
    }
    private string _pkout1001;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"pkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string pkout1001
    {
      get { return _pkout1001; }
      set { _pkout1001 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
