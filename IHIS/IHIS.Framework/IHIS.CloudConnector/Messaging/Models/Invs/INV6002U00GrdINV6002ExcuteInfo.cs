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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV6002U00GrdINV6002ExcuteInfo")]
  public partial class INV6002U00GrdINV6002ExcuteInfo : global::ProtoBuf.IExtensible
  {
    public INV6002U00GrdINV6002ExcuteInfo() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _magam_month = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"magam_month", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string magam_month
    {
      get { return _magam_month; }
      set { _magam_month = value; }
    }
    private string _jaeryo_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"jaeryo_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jaeryo_code
    {
      get { return _jaeryo_code; }
      set { _jaeryo_code = value; }
    }
    private string _exist_count = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"exist_count", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exist_count
    {
      get { return _exist_count; }
      set { _exist_count = value; }
    }
    private string _input_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_date
    {
      get { return _input_date; }
      set { _input_date = value; }
    }
    private string _input_user = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"input_user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_user
    {
      get { return _input_user; }
      set { _input_user = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}