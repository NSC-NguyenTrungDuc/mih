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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckAdminUserResponse")]
  public partial class CheckAdminUserResponse : global::ProtoBuf.IExtensible
  {
    public CheckAdminUserResponse() {}
    
    private readonly global::System.Collections.Generic.List<CheckAdminUserInfo> _user_info = new global::System.Collections.Generic.List<CheckAdminUserInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"user_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckAdminUserInfo> user_info
    {
      get { return _user_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
