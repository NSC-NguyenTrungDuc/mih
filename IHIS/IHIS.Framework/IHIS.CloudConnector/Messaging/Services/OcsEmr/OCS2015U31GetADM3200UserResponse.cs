//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U31GetADM3200UserResponse")]
  public partial class OCS2015U31GetADM3200UserResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U31GetADM3200UserResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U31GetADM3200UserInfo> _adm3200_user_info = new global::System.Collections.Generic.List<OCS2015U31GetADM3200UserInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"adm3200_user_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U31GetADM3200UserInfo> adm3200_user_info
    {
      get { return _adm3200_user_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
