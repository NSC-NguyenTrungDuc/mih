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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckAdminUserInfo")]
  public partial class CheckAdminUserInfo : global::ProtoBuf.IExtensible
  {
    public CheckAdminUserInfo() {}
    
    private string _user_scrt = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_scrt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_scrt
    {
      get { return _user_scrt; }
      set { _user_scrt = value; }
    }
    private string _user_group = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"user_group", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_group
    {
      get { return _user_group; }
      set { _user_group = value; }
    }
    private string _user_yn = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_yn
    {
      get { return _user_yn; }
      set { _user_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}