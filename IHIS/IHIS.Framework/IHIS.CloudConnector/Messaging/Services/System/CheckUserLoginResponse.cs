//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: system_service.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckUserLoginResponse")]
  public partial class CheckUserLoginResponse : global::ProtoBuf.IExtensible
  {
    public CheckUserLoginResponse() {}
    
    private string _sub_part_doctor;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"sub_part_doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string sub_part_doctor
    {
      get { return _sub_part_doctor; }
      set { _sub_part_doctor = value; }
    }
    private UserItemInfo _user_item_info = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"user_item_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public UserItemInfo user_item_info
    {
      get { return _user_item_info; }
      set { _user_item_info = value; }
    }
    private string _error_message = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"error_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error_message
    {
      get { return _error_message; }
      set { _error_message = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}