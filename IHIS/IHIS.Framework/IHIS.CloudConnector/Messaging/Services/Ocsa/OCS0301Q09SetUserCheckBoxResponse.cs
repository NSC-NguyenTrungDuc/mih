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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0301Q09SetUserCheckBoxResponse")]
  public partial class OCS0301Q09SetUserCheckBoxResponse : global::ProtoBuf.IExtensible
  {
    public OCS0301Q09SetUserCheckBoxResponse() {}
    
    private string _result = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _gwa_all_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gwa_all_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_all_name
    {
      get { return _gwa_all_name; }
      set { _gwa_all_name = value; }
    }
    private string _gwa_doctor_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gwa_doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_doctor_name
    {
      get { return _gwa_doctor_name; }
      set { _gwa_doctor_name = value; }
    }
    private string _user_id_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"user_id_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id_name
    {
      get { return _user_id_name; }
      set { _user_id_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
