//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GetPatientInsResponse")]
  public partial class GetPatientInsResponse : global::ProtoBuf.IExtensible
  {
    public GetPatientInsResponse() {}
    
    private readonly global::System.Collections.Generic.List<PrivateInsInfo> _pri_info = new global::System.Collections.Generic.List<PrivateInsInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"pri_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PrivateInsInfo> pri_info
    {
      get { return _pri_info; }
    }
  
    private readonly global::System.Collections.Generic.List<PublicInsInfo> _pub_info = new global::System.Collections.Generic.List<PublicInsInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"pub_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PublicInsInfo> pub_info
    {
      get { return _pub_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
